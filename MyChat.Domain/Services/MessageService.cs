using MyChat.Core.Models;
using MyChat.Core.Repository;
using MyChat.Domain.ViewModels;

namespace MyChat.Domain.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IUserRepository _userRepository;
        public MessageService(IMessageRepository messageRepository, IUserRepository userRepository)
        {
            _messageRepository = messageRepository;
            _userRepository = userRepository;
        }
        public DataViewModel<ChatViewModel> GetChatData(string contactId, string userId)
        {

            var contact = _userRepository.GetById(contactId);
            if (contact != null)
            {
                var messages = new ChatViewModel
                {
                    RecieverId = userId,
                    Messages = _messageRepository.GetLatestMessages(userId, contactId),
                    ContactAvatar = contact.Avatar,
                    ContactId = contact.Id,
                    ContactName = contact.UserName
                };

                return new DataViewModel<ChatViewModel>
                {
                    Data = messages,
                    Message = "Ok",
                    Succeded = true
                };
            }
            else
            {
                return new DataViewModel<ChatViewModel>
                {
                    Data = new ChatViewModel { },
                    Message = "Contact not found, something went wrong",
                    Succeded = false
                };
            }
        }


        public DataViewModel SendMessage(string text, string senderId, string recieverId)
        {
            var result = _messageRepository.AddMessage(new Message
            {
                Text = text,
                SenderId = senderId,
                RecieverId = recieverId,
                SendDateTime = DateTime.UtcNow,
                Delleted = false,
            });
            if (result)
                return new DataViewModel
                {
                    Succeded = true,
                    Message = "Ok"
                };

            else
                return new DataViewModel
                {
                    Succeded = false,
                    Message = "Couldn't send the message!"
                };

        }

    }
}
