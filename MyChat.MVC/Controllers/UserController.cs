using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyChat.Domain.ViewModels;
using MyChat.Core.Models;
using MyChat.Domain.Services;
using System.Security.Claims;
using System.Text.Json;

namespace MyChat.MVC.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserService _usersService;
        private readonly IMessageService _chatService;
        private readonly SignInManager<User> _signInManager;
        public UserController(IUserService usersService , IMessageService chatService , SignInManager<User> signInManager)
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


            //var model = _chatService.GetChatData(id, userId);
            //return View(model);


            var jsonModel = JsonSerializer.Serialize(_chatService.GetChatData(id, userId));
            return View("Chat" , jsonModel);
        }

        [HttpPost]
        public IActionResult SendMessage(string text, string contactId)
        {
            var result = _chatService.SendMessage(text, _signInManager.UserManager.GetUserId(User), contactId);
            return RedirectToAction(nameof(Chat) , new {id = contactId });
        }

        [HttpGet]
        public string JsonData([FromRoute] string id)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var jsonModel = JsonSerializer.Serialize(_chatService.GetChatData(id, userId));

            return jsonModel;
        }

        [HttpPost]
        public void JsonData([FromBody] string messageText, [FromRoute] string id)
        {
            var result = _chatService.SendMessage(messageText, _signInManager.UserManager.GetUserId(User) , id);
        }

    }
}
