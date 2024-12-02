using System.ComponentModel.DataAnnotations;

namespace Employe.DTOs.UserDTOs
{
    public class LoginUserDto
    {
        [Required]
        [Display(Prompt = "EmailorUsername")]
        public string EmailOrUsername { get; set; }
        [DataType(DataType.Password), Required]
        [Display(Prompt = "Password")]
        public string Password { get; set; }
        [Required]

        public bool Ispersistant { get; set; }
    }
}
