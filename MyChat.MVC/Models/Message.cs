using System.ComponentModel.DataAnnotations;

namespace MyChat.MVC.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public string SenderId { get; set; }
        public string RecieverId { get; set; }
        public string SendDate { get; set; }
        public string SendTime { get; set; }
        public bool Delleted { get; set; }
    }
}
