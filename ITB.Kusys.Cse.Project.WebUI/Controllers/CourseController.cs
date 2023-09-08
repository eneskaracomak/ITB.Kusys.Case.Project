using ITB.Cse.Project.WebUI.Attribute;
using ITB.Kusys.Cse.Project.Bussiness.Abstract.Course;
using ITB.Kusys.Cse.Project.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace ITB.Cse.Project.WebUI.Controllers
{

    [Authorations]
    [AdminAtt]
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public IActionResult Index()
        {
            var data = _courseService.GetAllCourses().ToList();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Course model)
        {          
            try
            {
                model.CreatedTime = DateTime.Now;
                model.ModifiedTime = DateTime.Now;
                var result = _courseService.AddCourse(model);
                return Redirect("/Course/Index");

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error",ex.Message);
                return View();

            }

        }

        [HttpPost]
        public IActionResult Delete(int Id)
        {
            try
            {
               var course = _courseService.GetById(Id);
                var result = _courseService.DeleteCourse(course);
                return Redirect("/Course/Index");

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", ex.Message);
                return View();

            }

        }


    }
}