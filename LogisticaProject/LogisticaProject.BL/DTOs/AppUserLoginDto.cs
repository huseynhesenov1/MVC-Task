using System.ComponentModel.DataAnnotations;
namespace LogisticaProject.BL.DTOs;
public class AppUserLoginDto
{
	[Required]
	public string UserName { get; set; }
	[Required]
	[DataType(DataType.Password)]
	public string Password { get; set; }
	public bool IsPersistant { get; set; }
}
