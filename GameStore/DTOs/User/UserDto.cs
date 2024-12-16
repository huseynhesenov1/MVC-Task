using System.ComponentModel.DataAnnotations;

namespace GameStore.DTOs.User
{
    public class UserDto
    {
        [Display(Prompt = "FirstName")]
        [Required]
        public string FirstName { get; set; }
        [Display(Prompt = "LastName")]
        [Required]
        public string LastName { get; set; }
        [Display(Prompt = "Email")]
        [Required]
        public string Email { get; set; }
        [Display(Prompt = "UserName")]
        [Required]
        public string UserName { get; set; }
        [Display(Prompt = "Password")]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Prompt = "ConfirmPassword")]
        public string ConfirmPassword { get; set; }


    }
}
