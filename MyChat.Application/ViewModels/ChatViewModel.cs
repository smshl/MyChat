using MyChat.Domain.Models;

namespace MyChat.Application.ViewModels
{
    public class ChatViewModel
    {
        public string RecieverId { get; set; }
        public string ContactId { get; set; }
        public string ContactName { get; set; }
        public string ContactAvatar { get; set; }
        public List<Message> Messages { get; set; }

    }
}
