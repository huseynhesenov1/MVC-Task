using System.ComponentModel.DataAnnotations;
namespace LogisticaProject.BL.DTOs;

public class AppUserCreateDto
{
    [Required]
    
	[Display(Prompt = "FirstName")]
	public string FirstName { get; set; }
    [Display(Prompt = "LastName")]
    [Required]
    public string LastName { get; set; }
    [Display(Prompt = "UserName")]
    [Required]
    public string UserName { get; set; }
    [Display(Prompt = "Email")]
    [Required]
    public string Email { get; set; }
    [Display(Prompt = "Password")]
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    [Display(Prompt = "ConfirmPassword")]
    [Required]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; }
}
