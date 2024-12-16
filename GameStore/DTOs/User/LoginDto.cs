using System.ComponentModel.DataAnnotations;

namespace GameStore.DTOs.User
{
    public class LoginDto
    {
        [Required]
        [Display(Prompt = "UserNameOrEmail")]
        public string UserNameOrEmail { get; set; }
        [Required]
        [Display(Prompt = "Password")]
        [DataType(DataType.Password)]

        public string Password { get; set; }
        public bool Ispersistant { get; set; }
    }
}
