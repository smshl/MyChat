using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyChat.MVC.ViewModels;
using MyChat.MVC.Models;
using MyChat.MVC.Services;
using MyChat.MVC.Interfaces;
using System.Security.Claims;
using System.Text.Json;

namespace MyChat.MVC.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserService _usersService;
        private readonly IChatService _chatService;
        private readonly SignInManager<User> _signInManager;
        public UserController(IUserService usersService , IChatService chatService , SignInManager<User> signInManager)
        {
            _usersService = usersService;
            _chatService = chatService;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var model = _usersService.GetUsersList(userId);
            return View(model);
        }

        [HttpGet]
        public IActionResult Chat([FromRoute] string id)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(id))
            {
                return NotFound("User id not found!");
            }


            var model = _chatService.GetChatData(id, userId);

            //var jsonModel = JsonSerializer.Serialize(_chatService.GetChatData(id, userId));


            return View(model);
        }

        [HttpPost]
        public IActionResult SendMessage(string text, string contactId)
        {
            var result = _chatService.SendMessage(text, _signInManager.UserManager.GetUserId(User), contactId);
            return RedirectToAction(nameof(Chat) , new {id = contactId });
        }

    }
}
