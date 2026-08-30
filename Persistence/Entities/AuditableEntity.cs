namespace Employee_API.Persistence.Entities
{
    public abstract class AuditableEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
