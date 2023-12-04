using System.ComponentModel.DataAnnotations;

namespace WebApiPeliculas2023.DTOs
{
	public class ModificarGeneroDTO
	{
		[Key]
		public int Id { get; set; }
		public string nombre { get; set; }
	}
}
