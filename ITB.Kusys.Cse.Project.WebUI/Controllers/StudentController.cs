using ITB.Cse.Project.WebUI.Attribute;
using ITB.Cse.Project.WebUI.Sessions;
using ITB.Kusys.Cse.Project.Bussiness.Abstract.Course;
using ITB.Kusys.Cse.Project.Bussiness.Abstract.Login;
using ITB.Kusys.Cse.Project.Bussiness.Abstract.Student;
using ITB.Kusys.Cse.Project.Bussiness.Abstract.StudentCourseService;
using ITB.Kusys.Cse.Project.Bussiness.Concrete.Login;
using ITB.Kusys.Cse.Project.Entities.Concrete;
using ITB.Kusys.Cse.Project.Entities.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITB.Cse.Project.WebUI.Controllers
{

    [Authorations]
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly ICourseService _courseService;
        private readonly ILoginService _loginService;
        private readonly IStudentCourseService _studentCourseService;

        public StudentController(IStudentService studentService,
            IStudentCourseService studentCourseService,
            ILoginService loginManager,
            ICourseService courseService)
        {
            _studentService = studentService;
            _studentCourseService = studentCourseService;
            _loginService = loginManager;
            _courseService = courseService;
        }


        [Authorations]
        public IActionResult Index()
        {
            return View(_studentService.GetAllStudents());
        }
    
        [AdminAtt]
        public IActionResult Create()
        {
            ViewBag.Courses = _courseService.GetAllCourses().ToList();
            return View();
        }

        [HttpPost]
        [AdminAtt]
        public IActionResult Create(Student model, string password, List<int> tags)
        {
            var data = _studentService.AddStudent(model);
            if (data <= 0)
            {
                return View("Error");
            }
            var student = _studentService.GetByMail(model.Email);
            if (!tags.Any()) return Redirect("/student-list");
            foreach (var mapping in tags.Select(tagId => new StudentCourse()
            {
                CourseId = tagId,
                StudentId = student.Id
            }))
            {
                _studentCourseService.Insert(mapping);
            }
            UserRegisterDto userRegisterDto = new UserRegisterDto()
            {
                Email = model.Email,
                Password = password,
                Username = model.FirstName + model.LastName,
            };
            var register = _loginService.Register(userRegisterDto, 2);

            return Redirect("/Student/Index");
        }


        [UserAtt]
        public IActionResult StudentCourseList()
        {
            var currentUser = _studentService.GetByMail(Session.User.Email);
            var students = _studentService.Queryable()
          .Include(s => s.StudentCourse)
          .ThenInclude(sc => sc.Course)
          .ToList().SingleOrDefault(x => x.Id == currentUser.Id);

            var studentViewModels = new List<StudentViewModel>
        {
            new StudentViewModel
            {
                CourseName = students.StudentCourse
                    .Select(sc => $"{sc.Course.Name}").ToList()
            }
        };


            return View(studentViewModels);
        }




    }
}