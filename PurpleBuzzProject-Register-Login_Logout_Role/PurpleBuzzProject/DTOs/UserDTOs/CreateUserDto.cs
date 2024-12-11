using System.ComponentModel.DataAnnotations;

namespace PurpleBuzzProject.DTOs.UserDTOs
{
    public class CreateUserDto
    {
        [Required]
        [Length(2,30)]
        [Display(Prompt = "FirstName")]
        public string FirstName { get; set; }
        [Required]
        [Length(2, 30)]
        [Display(Prompt = "LastName")]

        public string LastName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Prompt = "Email")]

        public string Email { get; set; }
        [Required]
        [Display(Prompt = "Username")]

        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Prompt = "Password")]

        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password),Compare(nameof(Password),ErrorMessage = "Password is same ConfirmPassword")]
        [Display(Prompt = "ConfirmPassword")]

        public string ConfirmPassword { get; set; }


    }
}
