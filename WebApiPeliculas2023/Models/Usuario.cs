namespace WebApiPeliculas2023.Models
{
	public class Usuario
	{
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public string Contrasena { get; set; }
    }
}
