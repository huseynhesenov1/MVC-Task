namespace LogisticaProject.Core.Entities;

public class BaseEntity:BaseAuditableEntity
{
    public int Id { get; set; } 
    public bool IsDeleted { get; set; }
}
