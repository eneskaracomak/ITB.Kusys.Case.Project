using ITB.Kusys.Cse.Project.Core.Entities.Abstract;
using ITB.Kusys.Cse.Project.Core.Entities.Concrete;

namespace ITB.Kusys.Cse.Project.Entities.Concrete
{
    public class Student : BaseEntity, IEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TrIdentityNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public ICollection<StudentCourse> StudentCourse { get; set; }

    }
}

