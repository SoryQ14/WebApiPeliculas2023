using System.ComponentModel.DataAnnotations;

namespace WebApiPeliculas2023.DTOs
{
	
	public class EliminarPelisDTO
	{
		[Key]
		public int id { get; set; }
		public string Titulo { get; set; }
	}
}
