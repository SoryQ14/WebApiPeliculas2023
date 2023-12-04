using System.ComponentModel.DataAnnotations;

namespace WebApiPeliculas2023.DTOs
{
	public class GeneroEspecificoDTO
	{
		[Key]
		public string nombre { get; set; }
	}
}
