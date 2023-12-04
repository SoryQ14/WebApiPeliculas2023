using System.ComponentModel.DataAnnotations;

namespace WebApiPeliculas2023.DTOs
{
	public class ModificarPeliDTO
	{
		[Key]
		public string Titulo { get; set; }
		public string Descripcion { get; set; }
		public double calificacion { get; set; }
		public double Duracion { get; set; }
		public string Imagen { get; set; }
	}
}
