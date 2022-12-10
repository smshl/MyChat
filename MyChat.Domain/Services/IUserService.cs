using MyChat.Core.Models;
using MyChat.Domain.ViewModels;

namespace MyChat.Domain.Services
{
    public interface IUserService
    {
        public DataViewModel<List<User>> GetUsersList(string userId);
        public DataViewModel<User> GetUser(string id);

    }
}
