using System.ComponentModel.DataAnnotations;

namespace Finexo.BL.DTOs
{
    public class AppUserDto
    {
        [Required]
        [Display(Prompt = "FirstName")]
        public string FirstName {  get; set; }
        [Required]
        [Display(Prompt = "LastName")]
        public string LastName {  get; set; }
        [Required]
        [Display(Prompt = "Email")]
        public string Email {  get; set; }
        [Required]
        [Display(Prompt = "UserName")]
        public string UserName {  get; set; }
        [Display(Prompt = "Password")]

        [Required]
        [DataType(DataType.Password)]
        public string Password {  get; set; }
        [Display(Prompt = "ConfirmPassword")]

        [Required]
        [DataType(DataType.Password)]
        public string ConfirmPassword {  get; set; }
    }
}
