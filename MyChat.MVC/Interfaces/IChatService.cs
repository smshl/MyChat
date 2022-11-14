using MyChat.MVC.ViewModels;

namespace MyChat.MVC.Interfaces
{
    public interface IChatService
    {
        DataViewModel<ChatViewModel> GetChatData(string contactId , string userId);
        DataViewModel SendMessage(string text, string senderId, string recieverId);
    }
}
