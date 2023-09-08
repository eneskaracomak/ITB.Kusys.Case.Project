using ITB.Kusys.Cse.Project.Bussiness.Abstract.User;
using ITB.Kusys.Cse.Project.Core.AppConstant;
using ITB.Kusys.Cse.Project.DataAccess.Abstract;
using ITB.Kusys.Cse.Project.DataAccess.Result;

namespace ITB.Kusys.Cse.Project.Bussiness.Concrete.User
{

    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public Result<Entities.Concrete.User.User> GetUserById(int id)
        {
            var result = new Result<Entities.Concrete.User.User> { IsSuccess = true,Data = new Entities.Concrete.User.User(),Message=AppConstant.SQL_GET_OK};

            result.Data = _userDal.Get(x => x.Id == id && x.IsDeleted == false);

            if (result.Data == null)
            {
                result.IsSuccess = false;
            }

            return result;
        }
        public Result<Entities.Concrete.User.User> GetCurrentUser(int id)
        {
            var returnModel = new Result<Entities.Concrete.User.User> { IsSuccess = true, Data = new Entities.Concrete.User.User(), Message = AppConstant.SQL_GET_OK };

            var result = _userDal.Get(x => x.Id == id && x.IsDeleted == false);


            returnModel.Data = result;

            if (returnModel.Data == null)
            {
                returnModel.IsSuccess = false;
            }

            return returnModel;
        }
        public Result<Entities.Concrete.User.User> RemoveUserById(int id)
        {
            var returnModel = new Result<Entities.Concrete.User.User> { IsSuccess = true, Data = new Entities.Concrete.User.User(), Message = AppConstant.SQL_GET_OK };
            var user = _userDal.Get(x => x.Id == id);

            if (user != null)
            {
                user.IsDeleted = true;
                _userDal.Update(user);
            }
            

            return returnModel;
        }
        public Result<Entities.Concrete.User.User> Insert(Entities.Concrete.User.User data)
        {
            var returnModel = new Result<Entities.Concrete.User.User> { IsSuccess = true, Data = new Entities.Concrete.User.User(), Message = AppConstant.SQL_GET_OK };

            var user = _userDal.Get(x => x.Username == data.Username || x.Email == data.Email);
            returnModel.Data = data;

            if (user != null)
            {
                returnModel.IsSuccess = false;
            }
            else
            {
                _userDal.Add(returnModel.Data);
            }

            return returnModel;
        }
        public Result<Entities.Concrete.User.User> Update(Entities.Concrete.User.User data)
        {
            var returnModel = new Result<Entities.Concrete.User.User> { IsSuccess = true, Data = new Entities.Concrete.User.User(), Message = AppConstant.SQL_GET_OK };
            returnModel.Data = _userDal.Get(x => x.Id == data.Id);
            returnModel.Data.Email = data.Email;
            returnModel.Data.Password = data.Password;
            returnModel.Data.Username = data.Username;
            returnModel.Data.RoleId = data.RoleId;
            _userDal.Update(returnModel.Data);
            return returnModel;
        }
        public IQueryable<Entities.Concrete.User.User> GetAllUser()
        {
            return _userDal.Queryable().Where(x => x.IsDeleted == false);
        }
    }
}