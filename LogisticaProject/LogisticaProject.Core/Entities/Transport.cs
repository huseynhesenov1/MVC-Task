namespace LogisticaProject.Core.Entities;

public class Transport:BaseEntity
{
    public string Description { get; set; }
    public string Title { get; set; }
    public string ImgPath { get; set; }
    public int TransportTypeId { get; set; }


	public TransportType TransportType { get; set; }
}
