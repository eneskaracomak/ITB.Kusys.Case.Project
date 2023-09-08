using ITB.Kusys.Cse.Project.Core.DataAccess;
using ITB.Kusys.Cse.Project.DataAccess.Abstract;
using ITB.Kusys.Cse.Project.DataAccess.Context;
using ITB.Kusys.Cse.Project.Entities.Concrete;

namespace ITB.Kusys.Cse.Project.DataAccess.Concrete
{
    public class EfCourseDal : EfRepositoryBase<Course, ApplicationDbContext>, ICourseDal
    {

    }
}

