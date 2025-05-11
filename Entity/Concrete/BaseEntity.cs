namespace Entity.Concrete
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } 
        public bool IsActive { get; set; } 
    }
}
