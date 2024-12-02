using MediplusProject.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediplusProject.ViewModels.Home
{
    public class AppointmentVM
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "DoctorId mütləqdir.")]
        public int DoctorId { get; set; }
       

        [NotMapped]
        public Doctor Doctor { get; set; }
        [Required(ErrorMessage = "PatientId mütləqdir.")]


        public int PatientId { get; set; }

        [NotMapped]
        public Patient Patient { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        [Required(ErrorMessage = "IsActive mütləqdir.")]

        public bool IsActive { get; set; }

    }
}
