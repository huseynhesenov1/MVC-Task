namespace MediplusProject.Models
{
    public class Hosbital
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public ICollection<HosbitalDoctor>? HosbitalDoctors { get; set; }
       
    }
}
