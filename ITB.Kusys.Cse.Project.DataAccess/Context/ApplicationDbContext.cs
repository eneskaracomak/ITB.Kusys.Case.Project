
using ITB.Kusys.Cse.Project.Entities.Concrete;
using ITB.Kusys.Cse.Project.Entities.Concrete.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ITB.Kusys.Cse.Project.DataAccess.Context
{
    public class ApplicationDbContext : DbContext
    {
        private string connectionName;
        protected readonly IConfiguration Configuration;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration)
       : base(options)
        {
            Configuration = configuration;
        }

        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(string connectionName)
        {
            this.connectionName = connectionName;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            var str = _GlobalFields.ConnectionStr;

            if (string.IsNullOrEmpty(_GlobalFields.ConnectionStr))
            {
                str = "Data Source=.;Initial Catalog=KusysCaseProject;Trusted_Connection=True;Encrypt=false;TrustServerCertificate=True";
            }
            optionsBuilder.UseSqlServer(str,sqlServerOptionsAction:sqlOptions =>
            {
                sqlOptions.EnableRetryOnFailure(
               maxRetryCount: 5,
               maxRetryDelay: System.TimeSpan.FromSeconds(30),
               errorNumbersToAdd: null);
            });

            base.OnConfiguring(optionsBuilder);

        }
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<StudentCourse> StudentCourse { get; set; }
    }
}
