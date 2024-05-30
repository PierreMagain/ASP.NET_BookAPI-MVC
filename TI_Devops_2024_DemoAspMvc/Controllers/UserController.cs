using Microsoft.AspNetCore.Mvc;
using TI_Devops_2024_DemoAspMvc.BLL.Interfaces;
using TI_Devops_2024_DemoAspMvc.Infrastuctures;
using TI_Devops_2024_DemoAspMvc.Mappers;
using TI_Devops_2024_DemoAspMvc.Models;

namespace TI_Devops_2024_DemoAspMvc.Controllers
{
    public class UserController : Controller
    {

        private readonly IUserService _userService;
        private readonly SessionManager _sessionManager;

        public UserController(IUserService userService, SessionManager sessionManager)
        {
            _userService = userService;
            _sessionManager = sessionManager;
        }

        public IActionResult Register()
        {
            return View(new UserRegisterFormDTO());
        }

        [HttpPost]
        public IActionResult Register([FromForm]UserRegisterFormDTO form)
        {
            if(!ModelState.IsValid)
            {
                return View(form);
            }
            _userService.Register(form.ToEntity());
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Login()
        {
            return View(new UserLoginFormDTO());
        }

        [HttpPost]
        public IActionResult Login([FromForm] UserLoginFormDTO form)
        {
            if(!ModelState.IsValid)
            {
                return View(form);
            }

            _sessionManager.CurrentUser = _userService.Login(form.Login, form.Password).ToSessionDTO();

            return RedirectToAction("Index", "Home");
        }
    }
}
