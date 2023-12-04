using System.ComponentModel.DataAnnotations;

namespace WebApiPeliculas2023.Models
{
	public class Pelicula 
	{
        public int id { get; set; }
        [Required(ErrorMessage ="El campo {0} es requerido")]
        [StringLength(maximumLength:50, ErrorMessage ="El campo {0} no debe de tener más de {1} caracteres")]
        public String Titulo { get; set; }
        [Required(ErrorMessage ="El campo es requerido")]
        public string Descripcion { get; set; }
        public double Calificacion { get; set; }
        public double Duracion { get; set; }
        public string Imagen { get; set; }

		public ICollection<Opinion> Opinion { get; } = new List<Opinion>(); //relacion de uno a muchos 
        public List<Genero> Generos { get; } = new(); //Muchos a muchos 
	}
}
