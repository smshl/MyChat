using Microsoft.AspNetCore.Identity;

namespace MyChat.Models
{
    public class User : IdentityUser
    {
        public string? Biography { get; set; } = string.Empty;
        public string? Avatar { get; set; } = string.Empty;
    }
}
