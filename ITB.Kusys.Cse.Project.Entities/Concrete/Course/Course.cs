using ITB.Kusys.Cse.Project.Core.Entities.Abstract;
using ITB.Kusys.Cse.Project.Core.Entities.Concrete;

namespace ITB.Kusys.Cse.Project.Entities.Concrete
{
    public class Course : BaseEntity, IEntity
    {
        public string Name { get; set; }
        public ICollection<StudentCourse> StudentCourse { get; set; }
    }
}
