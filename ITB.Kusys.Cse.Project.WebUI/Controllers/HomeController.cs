using ITB.Cse.Project.WebUI.Attribute;
using ITB.Kusys.Cse.Project.Bussiness.Abstract.Course;
using ITB.Kusys.Cse.Project.Bussiness.Abstract.Login;
using ITB.Kusys.Cse.Project.Bussiness.Abstract.Student;
using ITB.Kusys.Cse.Project.Bussiness.Abstract.StudentCourseService;
using ITB.Kusys.Cse.Project.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITB.Cse.Project.WebUI.Controllers
{

    [Authorations]
    public class HomeController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly ICourseService _courseService;
        private readonly IStudentCourseService _studentCourseService;

        public HomeController(IStudentService studentService,
            IStudentCourseService studentCourseService,
            ICourseService courseService)
        {
            _studentService = studentService;
            _studentCourseService = studentCourseService;
            _courseService = courseService;
        }
        public IActionResult Index()
        {

            return View(new DashboardModel
            {
                Course = _courseService.GetAllCourses().Count(),
                StudentCount = _studentService.GetAllStudents().Count(),
                CourseCategory = _studentService.GetAllStudents().Count(),
            });
        }
    }
}