using MyChat.Domain.ViewModels;

namespace MyChat.Domain.Services
{
    public interface IChatService
    {
        DataViewModel<ChatViewModel> GetChatData(string contactId , string userId);
        DataViewModel SendMessage(string text, string senderId, string recieverId);
    }
}
