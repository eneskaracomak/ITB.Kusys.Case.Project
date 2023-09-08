using ITB.Cse.Project.WebUI.Attribute;
using ITB.Kusys.Cse.Project.Bussiness.Abstract.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITB.Cse.Project.WebUI.Controllers
{

    [Authorations]
    public class UserController : Controller
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("list")]
        public IActionResult Index()
        {
            var data = _userService.GetAllUser().Include(x => x.Role).ToList();
            return View(data);
        }
    }
}