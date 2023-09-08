using ITB.Kusys.Cse.Project.DataAccess.Context;

namespace ITB.Kusys.Cse.Project.DataAccess.BaseRepository
{
    public class RepositoryBase
    {
        protected static ApplicationDbContext context;
        protected static object _lockSync = new object();

        protected RepositoryBase()
        {
            CreateContext();
        }

        private static void CreateContext()
        {
            if (context == null)
            {
                lock (_lockSync)
                {
                    if (context == null)
                    {
                        context = new ApplicationDbContext();
                    }
                }
            }
        }
    }
}
