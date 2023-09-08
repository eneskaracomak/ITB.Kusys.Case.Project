using ITB.Kusys.Cse.Project.DataAccess.Result;

namespace ITB.Kusys.Cse.Project.Bussiness.Abstract.User
{
    public interface IUserService
    {

        Result<Entities.Concrete.User.User> Insert(Entities.Concrete.User.User data);
        Result<Entities.Concrete.User.User> Update(Entities.Concrete.User.User data);
        Result<Entities.Concrete.User.User> GetUserById(int id);
        Result<Entities.Concrete.User.User> GetCurrentUser(int id);
        IQueryable<Entities.Concrete.User.User> GetAllUser();
    }
}