using ITB.Kusys.Cse.Project.DataAccess.Result;
using ITB.Kusys.Cse.Project.Entities.Dto;

namespace ITB.Kusys.Cse.Project.Bussiness.Abstract.Login
{

    public interface ILoginService
    {

        Result<Entities.Concrete.User.User> Register(UserRegisterDto registerViewModel,int? RoleId);
        Result<Entities.Concrete.User.User> Login(UserLoginDto loginViewModel);

    }
}