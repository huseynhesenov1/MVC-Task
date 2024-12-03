using MediplusProject.Models;

namespace MediplusProject.Areas.Admin.DTOs.DoctorDTOs
{
    public class CreateDoctorDto
    {
       
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Finkod { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public List<int> HosbitalDoctorIds { get; set; }
       
    }
}
