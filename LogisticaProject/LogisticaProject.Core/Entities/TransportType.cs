namespace LogisticaProject.Core.Entities;

public class TransportType:BaseEntity
{
    public string Name { get; set; }
    public ICollection<Transport> Transports { get; set; }
}
