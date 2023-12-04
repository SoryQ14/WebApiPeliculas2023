using System.ComponentModel.DataAnnotations; 
namespace WebApiPeliculas2023.DTOs
{
	public class AgregarGeneroDTO
	{
		[Key]
		public int Id { get; set; }
		public string Nombre { get; set; }
	}
}
