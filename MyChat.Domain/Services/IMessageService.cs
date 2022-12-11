using MyChat.Domain.ViewModels;

namespace MyChat.Domain.Services
{
    public interface IMessageService
    {
        DataViewModel<ChatViewModel> GetChatData(string contactId , string userId);
        DataViewModel SendMessage(string text, string senderId, string recieverId);
    }
}
