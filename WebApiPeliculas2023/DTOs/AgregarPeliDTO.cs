using System.ComponentModel.DataAnnotations;

namespace WebApiPeliculas2023.DTOs
{
	public class AgregarPeliDTO
	{
		[Key]
		public int Id { get; set; } 
		public string Titulo { get; set; }
		public string Descripcion { get; set; }
		public double calificacion { get; set; }
		public double Duracion { get; set; }
		public string Imagen { get; set; }
	}
}
