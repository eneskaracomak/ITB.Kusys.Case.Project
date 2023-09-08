using ITB.Kusys.Cse.Project.Bussiness.Abstract.Course;
using ITB.Kusys.Cse.Project.DataAccess.Abstract;
using ITB.Kusys.Cse.Project.DataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace ITB.Kusys.Cse.Project.Bussiness.Concrete.Course
{
    public class CourseService : ICourseService
    {
        ICourseDal _courseDal;
        public CourseService(ICourseDal courseDal)
        {
            _courseDal = courseDal;
        }

        public int AddCourse(Entities.Concrete.Course course)
        {
            return _courseDal.Add(course);
        }
        public int DeleteCourse(Entities.Concrete.Course course)
        {
            return _courseDal.Delete(course);
        }
        public IQueryable<Entities.Concrete.Course> GetAllCourses()
        {
            return _courseDal.Queryable();
        }
        public Entities.Concrete.Course GetById(int courseId)
        {
            return _courseDal.Get(x=>x.Id == courseId);
        }
        public int UpdateCourse(Entities.Concrete.Course course)
        {
            return _courseDal.Update(course);
        }
        public List<Entities.Concrete.Student> GetStudentCourses()
        {
            using var context = new ApplicationDbContext();
            { 
            var result = context.Students
            .Include(s => s.StudentCourse)
            .AsNoTracking()
            .ToList();
            return result;
            }
        }
    }
}
