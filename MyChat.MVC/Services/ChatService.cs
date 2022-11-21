using Microsoft.AspNetCore.Identity;
using MyChat.MVC.Data;
using MyChat.MVC.Interfaces;
using MyChat.MVC.Models;
using MyChat.MVC.ViewModels;
using System.Security.Claims;

namespace MyChat.MVC.Services
{
    public class ChatService : IChatService
    {
        private readonly ApplicationDbContext _context;
        public ChatService(ApplicationDbContext context)
        {
            _context = context;
        }
        public DataViewModel<ChatViewModel> GetChatData(string contactId , string userId)
        {
            var contact = _context.Users.FirstOrDefault(u => u.Id == contactId);
            if (contact != null)
            {
                var messages = new ChatViewModel
                {
                    RecieverId = userId,
                    Messages = _context.Messages.Where(m => ((m.SenderId == contactId && m.RecieverId == userId) ||
                    (m.SenderId == userId && m.RecieverId == contactId)) && m.Delleted == false).OrderBy(t => t.SendDateTime).ToList(),
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
            _context.Messages.Add(new Message
            {
                Text = text,
                SenderId = senderId,
                RecieverId = recieverId,
                SendDateTime = DateTime.UtcNow,
                Delleted = false,
            }) ;
            var result = _context.SaveChanges();
            if (result > 0)
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
