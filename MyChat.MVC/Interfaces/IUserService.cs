using Microsoft.AspNetCore.Identity;
using MyChat.MVC.Models;
using MyChat.MVC.ViewModels;

namespace MyChat.MVC.Interfaces
{
    public interface IUserService
    {
        public DataViewModel<List<User>> GetUsersList(string userId);
        public DataViewModel<User> GetUser(string id);

    }
}
