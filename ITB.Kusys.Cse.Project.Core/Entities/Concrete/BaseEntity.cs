namespace ITB.Kusys.Cse.Project.Core.Entities.Concrete
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime ModifiedTime { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
