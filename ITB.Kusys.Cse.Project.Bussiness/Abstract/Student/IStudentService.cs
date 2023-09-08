namespace ITB.Kusys.Cse.Project.Bussiness.Abstract.Student
{
    public interface IStudentService
    {
        public int AddStudent(Entities.Concrete.Student student);
        public int DeleteStudent(Entities.Concrete.Student student);
        public int UpdateStudent(Entities.Concrete.Student student);
        public Entities.Concrete.Student GetById(int studentId);
        IQueryable<Entities.Concrete.Student> Queryable();
        public Entities.Concrete.Student GetByMail(string email);
        public List<Entities.Concrete.Student> GetAllStudents();
        public Entities.Concrete.Student GetStudentDetail(int studentId);
    }
}
