namespace ITB.Kusys.Cse.Project.Bussiness.Abstract.Course
{
    public interface ICourseService
    {
        public int AddCourse(Entities.Concrete.Course course);
        public int DeleteCourse(Entities.Concrete.Course course);
        public int UpdateCourse(Entities.Concrete.Course course);
        public Entities.Concrete.Course GetById(int courseId);
        public IQueryable<Entities.Concrete.Course> GetAllCourses();
    }
}
