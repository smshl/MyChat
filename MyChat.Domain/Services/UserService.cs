using Microsoft.AspNetCore.Identity;
using MyChat.Core.Models;
using MyChat.Core.RepositoryInterfaces;
using MyChat.Domain.ViewModels;

namespace MyChat.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<User> _userManager;
        public UserService(IUserRepository userRepository, UserManager<User> userManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;
        }

        public DataViewModel<List<User>> GetUsersList(string userId)
        {
            List<User> usersList = _userRepository.GetAllList();
            if (usersList == null || usersList.Count == 0)
                return new DataViewModel<List<User>>
                {
                    Data = new List<User> { },
                    Message = "Something went wrong, no users found",
                    Succeded = false
                };

            else
                return new DataViewModel<List<User>>
                {
                    Data = usersList,
                    Message = "Ok",
                    Succeded = true
                };
        }

        public DataViewModel<User> GetUser(string id)
        {
            var user = _userRepository.GetById(id);

            if (user == null)
                return new DataViewModel<User>
                {
                    Data = new User { },
                    Message = "User not found!",
                    Succeded = false
                };
            else
                return new DataViewModel<User>
                {
                    Data = user,
                    Message = "Ok",
                    Succeded = true
                };
        }

    }
}
