namespace MediplusProject.Models
{
    public class HosbitalDoctor
    {
        public int Id { get; set; }
        public int HosbitalId { get; set; }
        public int DoctorId { get; set; }
        public Hosbital? Hosbital { get; set; }
        public Doctor? Doctor { get; set; }

    }
}
