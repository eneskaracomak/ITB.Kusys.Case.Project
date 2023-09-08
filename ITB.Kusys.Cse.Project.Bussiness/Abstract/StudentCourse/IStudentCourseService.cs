using ITB.Kusys.Cse.Project.Entities.Concrete;

namespace ITB.Kusys.Cse.Project.Bussiness.Abstract.StudentCourseService
{

    public interface IStudentCourseService
    {

        List<StudentCourse> GetStudentCourseCategory();
        StudentCourse GetStudentCourseById(int id);
        void Insert(StudentCourse studentCourse);
        void Update(StudentCourse studentCourse);
        void Delete(StudentCourse studentCourse);
    }
}