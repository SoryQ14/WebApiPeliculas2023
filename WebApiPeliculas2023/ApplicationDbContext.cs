using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApiPeliculas2023.Models;

namespace WebApiPeliculas2023
{
	public class ApplicationDbContext : IdentityDbContext
	{
		//this the hart
		public ApplicationDbContext(DbContextOptions options) : base(options)
		{
			//clase: pa poder mapear de los clases a la base de datos, establecer entidades, llaves foraneas, etc, etc.
		}
		public DbSet<Pelicula> Peliculas { get; set; }
		public DbSet<Genero> Generos { get; set; }
		public DbSet<Opinion> Opiniones { get; set;}
		public DbSet<GeneroPelicula> GenerosPeliculas { get; set; }
		public DbSet<Usuario> Usuarios { get; set; }



	}
}
