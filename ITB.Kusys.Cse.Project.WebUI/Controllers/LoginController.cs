using ITB.Cse.Project.WebUI.Attribute;
using ITB.Cse.Project.WebUI.Sessions;
using ITB.Kusys.Cse.Project.Bussiness.Abstract.Login;
using ITB.Kusys.Cse.Project.Bussiness.Abstract.User;
using ITB.Kusys.Cse.Project.Entities.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ITB.Cse.Project.WebUI.Controllers
{


    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;
        private readonly IUserService _userService;

        public LoginController(ILoginService loginService, IUserService userService)
        {
            _loginService = loginService;
            _userService = userService;
        }

        [LoginAtt]
        [Route("login")]
        public IActionResult Index()
        {
            return View();
        }

        [LoginAtt]
        [Route("login")]
        [HttpPost]
        public IActionResult Index(UserLoginDto model)
        {
            var login = _loginService.Login(model);           
            Session.Set("login", login.Data);
            return Redirect("/");
        }

        [Authorations]
        public IActionResult LogOut()
        {
            Session.Remove("login");
            return Redirect("/login");
        }

    


    }
}