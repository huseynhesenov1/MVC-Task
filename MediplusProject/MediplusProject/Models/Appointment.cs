using System.ComponentModel.DataAnnotations.Schema;

namespace MediplusProject.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        [NotMapped]
        public Doctor Doctor { get; set; }
        public int PatientId { get; set; }
        [NotMapped]
        public Patient Patient { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; }
        

    }
}
