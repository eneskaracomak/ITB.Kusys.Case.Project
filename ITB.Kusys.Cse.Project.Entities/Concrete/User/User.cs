using ITB.Kusys.Cse.Project.Core.Entities.Abstract;
using ITB.Kusys.Cse.Project.Core.Entities.Concrete;

namespace ITB.Kusys.Cse.Project.Entities.Concrete.User
{
    public class User : BaseEntity, IEntity
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}

