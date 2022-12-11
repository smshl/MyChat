using System.ComponentModel.DataAnnotations;

namespace MyChat.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public string SenderId { get; set; }
        public string RecieverId { get; set; }
        public DateTime SendDateTime { get; set; }
        public bool Delleted { get; set; }
    }
}
