namespace LogisticaProject.Core.Entities;

public class BaseAuditableEntity
{
    public DateTime CreateAt { get; set; }
    public DateTime? UpdateAt { get; set; }
    public DateTime? DeleteAt { get; set; }
}
