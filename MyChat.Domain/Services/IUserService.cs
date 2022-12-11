using MyChat.Domain.ViewModels;
using MyChat.Models;

namespace MyChat.Domain.Services
{
    public interface IUserService
    {
        public DataViewModel<List<User>> GetUsersList(string userId);
        public DataViewModel<User> GetUser(string id);

    }
}
