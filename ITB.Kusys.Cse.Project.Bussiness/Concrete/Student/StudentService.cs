using ITB.Kusys.Cse.Project.Bussiness.Abstract.Student;
using ITB.Kusys.Cse.Project.DataAccess.Abstract;
using ITB.Kusys.Cse.Project.DataAccess.Context;
using ITB.Kusys.Cse.Project.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace ITB.Kusys.Cse.Project.Bussiness.Concrete.Student
{
    public class StudentService : IStudentService
    {
        IStudentDal _studentDal;

        public StudentService(IStudentDal studentDal)
        {
            _studentDal = studentDal;
        }

        public int AddStudent(Entities.Concrete.Student student)
        {
            return _studentDal.Add(student);
        }

        public int DeleteStudent(Entities.Concrete.Student student)
        {
            return _studentDal.Delete(student);
        }

        public List<Entities.Concrete.Student> GetAllStudents()
        {
            return _studentDal.GetList();
        }
        public IQueryable<Entities.Concrete.Student> Queryable()
        {
            return _studentDal.Queryable().Where(x => x.IsDeleted == false);
        }

        public Entities.Concrete.Student GetById(int studentId)
        {
            return _studentDal.Get(x=>x.Id == studentId);
        }

        public int UpdateStudent(Entities.Concrete.Student student)
        {
            return _studentDal.Update(student);
        }
        public Entities.Concrete.Student GetStudentDetail(int studentId)
        {
            using var context = new ApplicationDbContext();
            {
                var result = context.Students
          .Include(s => s.StudentCourse)
          .Where(s => s.Id == studentId)
          .FirstOrDefault();
                return result;
            }
          
        }

        public Entities.Concrete.Student GetByMail(string email)
        {
            return _studentDal.Get(x => x.Email == email);
        }
    }
}
