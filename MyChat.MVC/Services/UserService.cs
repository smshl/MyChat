using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MyChat.MVC.Data;
using MyChat.MVC.Interfaces;
using MyChat.MVC.Models;
using MyChat.MVC.ViewModels;

namespace MyChat.MVC.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        public UserService(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public DataViewModel<List<User>> GetUsersList(string userId)
        {
            List<User> usersList = _context.Users.Where(u=>u.Id != userId).ToList();
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
            var user = _context.Users.SingleOrDefault(u => u.Id == id);

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
