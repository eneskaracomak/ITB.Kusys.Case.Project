using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using ITB.Cse.Project.WebUI.Sessions;

namespace ITB.Cse.Project.WebUI.Attribute
{
    public class Authorations : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var currentUser = Session.User;
            if (currentUser == null)
            {
                context.Result = new RedirectToActionResult("Index", "Login", null);
            }
        }
    }
    public class AdminAtt : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var currentUser = Session.User;
            if (currentUser is not { Role.SecretName: "Admin" })
            {
                context.Result = new RedirectToActionResult("Index", "Home", null);
            }
        }
    }
    public class LoginAtt : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var currentUser = Session.User;
            if (currentUser != null)
            {
                context.Result = new RedirectResult("/");
            }
        }
    }
    public class UserAtt : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var currentUser = Session.User;
            if (currentUser is not { Role.SecretName: "User" })
            {
                context.Result = new RedirectToActionResult("Index", "Home", null);
            }
        }
    }

}
