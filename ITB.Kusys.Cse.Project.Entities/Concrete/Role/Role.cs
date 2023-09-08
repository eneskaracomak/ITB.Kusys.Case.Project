using ITB.Kusys.Cse.Project.Core.Entities.Abstract;
using ITB.Kusys.Cse.Project.Core.Entities.Concrete;

namespace ITB.Kusys.Cse.Project.Entities.Concrete
{
    public class Role : BaseEntity, IEntity
    {
        public string Name { get; set; }
        public string SecretName { get; set; }
    }
}

