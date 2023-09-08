using ITB.Kusys.Cse.Project.Bussiness.Abstract.Course;
using ITB.Kusys.Cse.Project.Bussiness.Abstract.Login;
using ITB.Kusys.Cse.Project.Bussiness.Abstract.Student;
using ITB.Kusys.Cse.Project.Bussiness.Abstract.StudentCourseService;
using ITB.Kusys.Cse.Project.Bussiness.Abstract.User;
using ITB.Kusys.Cse.Project.Bussiness.Concrete.Course;
using ITB.Kusys.Cse.Project.Bussiness.Concrete.Login;
using ITB.Kusys.Cse.Project.Bussiness.Concrete.Student;
using ITB.Kusys.Cse.Project.Bussiness.Concrete.StudentCourse;
using ITB.Kusys.Cse.Project.Bussiness.Concrete.User;
using ITB.Kusys.Cse.Project.DataAccess;
using ITB.Kusys.Cse.Project.DataAccess.Abstract;
using ITB.Kusys.Cse.Project.DataAccess.Concrete;
using ITB.Kusys.Cse.Project.DataAccess.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITB.Cse.Project.WebUI.Extensions
{
    public static class ServiceCollectionExtensions
    {
    
  
        public static IServiceCollection AddWebUIRegistration(this IServiceCollection services, IHostBuilder hostBuilder)
        {
            var configFilePath = "appsettings.json";

            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(configFilePath, optional: true, reloadOnChange: true);

            // IConfiguration nesnesini oluşturun
            IConfiguration configuration = builder.Build();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("ApplicationConnectionString")), ServiceLifetime.Transient);


            services.AddSingleton<IUserService, UserManager>();
            services.AddSingleton<IUserDal, EfUserDal>();

            services.AddSingleton<IStudentService, StudentService>();
            services.AddSingleton<IStudentDal, EfStudentDal>();

            services.AddSingleton<ICourseService, CourseService>();
            services.AddSingleton<ICourseDal, EfCourseDal>();


            services.AddSingleton<IStudentCourseService, StudentCourseManager>();
            services.AddSingleton<IStudentCourseDal, EfStudentCourseMappingDal>();

            services.AddSingleton<ILoginService, LoginManager>();

            _GlobalFields.ConnectionStr = configuration.GetConnectionString("ApplicationConnectionString");
            return services;
        }

        public static WebApplication UseWebUIMiddleware(this WebApplication app)
        {
            if (!app.Environment.IsDevelopment())
                app.UseExceptionHandler("/Login/Error");

            app.UseStaticFiles();

            app.UseRouting();

            //sen kimsin?
            app.UseAuthentication();

            // yetkin var mı?
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");


            return app;
        }
    }
}
