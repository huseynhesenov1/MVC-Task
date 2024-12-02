using System.ComponentModel.DataAnnotations.Schema;

namespace MediplusProject.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Finkod { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public bool IsActive { get; set; }
       
        public ICollection<Appointment> Appointments { get; set; }

    }
}
