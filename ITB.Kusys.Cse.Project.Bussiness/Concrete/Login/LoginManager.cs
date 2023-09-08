using ITB.Kusys.Cse.Project.Bussiness.Abstract.Login;
using ITB.Kusys.Cse.Project.Core.AppConstant;
using ITB.Kusys.Cse.Project.DataAccess.Abstract;
using ITB.Kusys.Cse.Project.DataAccess.Result;
using ITB.Kusys.Cse.Project.Entities.Dto;
using Microsoft.EntityFrameworkCore;

namespace ITB.Kusys.Cse.Project.Bussiness.Concrete.Login
{

    public class LoginManager : ILoginService
    {
        private readonly IUserDal _userDal;

        public LoginManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public Result<Entities.Concrete.User.User> Register(UserRegisterDto registerViewModel,int? RoleId = 1)
        {
            var resultData = new Result<Entities.Concrete.User.User> { Data = null, IsSuccess = true, Message = AppConstant.SQL_GET_OK };

            var user = _userDal.Get(x =>
                x.Email == registerViewModel.Email || x.Username == registerViewModel.Username);

            if (user != null)
            {
                resultData.IsSuccess = false;
                resultData.Message = AppConstant.USER_ALREADY;
                return resultData;
            }
            var newUser = new Entities.Concrete.User.User()
            {
                Username = registerViewModel.Username,
                Email = registerViewModel.Email,
                Password = registerViewModel.Password,
                RoleId = Convert.ToInt32(RoleId),
                IsDeleted = false,
                CreatedTime = DateTime.Now,
                ModifiedTime = DateTime.Now,
                IsActive = true

            };

            _userDal.Add(newUser);
            resultData.Data = newUser;
            return resultData;
        }

        public Result<Entities.Concrete.User.User> Login(UserLoginDto loginViewModel)
        {
            try
            {
                var resultData = new Result<Entities.Concrete.User.User> { Data = null, IsSuccess = true, Message = AppConstant.SQL_GET_OK };
                var data = _userDal.Queryable().Where(x =>
                    x.Email == loginViewModel.Email).Include(x => x.Role).SingleOrDefault();

                if (data == null)
                {
                    resultData.IsSuccess = false;
                    resultData.Message = AppConstant.NOT_FOUND_USER;
                    return resultData;

                }

                if (data.Password != loginViewModel.Password)
                {
                    resultData.IsSuccess = false;
                    resultData.Message = AppConstant.PASSWORD_ERROR;
                    return resultData;
                }
                else
                {
                    resultData.Data = data;
                    return resultData;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }
    }
}