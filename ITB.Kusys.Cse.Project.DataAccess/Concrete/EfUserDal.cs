using ITB.Kusys.Cse.Project.Core.DataAccess;
using ITB.Kusys.Cse.Project.DataAccess.Abstract;
using ITB.Kusys.Cse.Project.DataAccess.Context;
using ITB.Kusys.Cse.Project.Entities.Concrete;
using ITB.Kusys.Cse.Project.Entities.Concrete.User;

namespace ITB.Kusys.Cse.Project.DataAccess.Concrete
{
    public class EfUserDal : EfRepositoryBase<User, ApplicationDbContext>, IUserDal
    {
  
    }
}

