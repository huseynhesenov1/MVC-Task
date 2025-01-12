using System.ComponentModel.DataAnnotations;

namespace Finexo.BL.DTOs
{
    public class AppUserLoginDto
    {
        [Required]
        public string UserName { get; set; }
		[Required]
        [DataType(DataType.Password)]
		public string Password { get; set; }

    }
}
