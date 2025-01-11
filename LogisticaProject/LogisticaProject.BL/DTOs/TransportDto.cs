using Microsoft.AspNetCore.Http;

namespace LogisticaProject.BL.DTOs;

public class TransportDto
{
    public string Description { get; set; }
    public string Title { get; set; }
	public IFormFile Image { get; set; }
	public int TransportTypeId { get; set; }
}

