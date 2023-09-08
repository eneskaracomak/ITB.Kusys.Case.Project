using ITB.Kusys.Cse.Project.Bussiness.Abstract.StudentCourseService;
using ITB.Kusys.Cse.Project.DataAccess.Abstract;
using ITB.Kusys.Cse.Project.DataAccess.Concrete;

namespace ITB.Kusys.Cse.Project.Bussiness.Concrete.StudentCourse
{

    public class StudentCourseManager : IStudentCourseService
    {
        private readonly IStudentCourseDal _studentCourseDal;

        public StudentCourseManager(IStudentCourseDal studentCourseDal)
        {
            _studentCourseDal = studentCourseDal;
        }

        public List<Entities.Concrete.StudentCourse> GetStudentCourseCategory()
        {
            return _studentCourseDal.GetList();
        }

        public Entities.Concrete.StudentCourse GetStudentCourseById(int id)
        {
            return _studentCourseDal.Get(x => x.Id == id);

        }

        public void Insert(Entities.Concrete.StudentCourse studentCourse)
        {
            _studentCourseDal.Add(studentCourse);
        }

        public void Update(Entities.Concrete.StudentCourse studentCourse)
        {
            _studentCourseDal.Update(studentCourse);

        }

        public void Delete(Entities.Concrete.StudentCourse studentCourse)
        {
            _studentCourseDal.Delete(studentCourse);
        }
    }
}