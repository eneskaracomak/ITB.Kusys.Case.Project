using ITB.Kusys.Cse.Project.Core.Entities.Abstract;
using ITB.Kusys.Cse.Project.Core.Entities.Concrete;

namespace ITB.Kusys.Cse.Project.Entities.Concrete
{
    public class StudentCourse : BaseEntity, IEntity
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
