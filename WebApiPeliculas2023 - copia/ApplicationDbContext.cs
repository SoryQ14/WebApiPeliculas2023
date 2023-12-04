using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApiPeliculas2023.DTOs;
using WebApiPeliculas2023.Models;

namespace WebApiPeliculas2023
{
	public class ApplicationDbContext : IdentityDbContext //Se crea la tabla identity en la BD( capeta migracion)
	{
		//this the hart
		public ApplicationDbContext(DbContextOptions options) : base(options)
		{
			//clase: pa poder mapear de los clases a la base de datos, establecer entidades, llaves foraneas, etc, etc.
		}
		public DbSet<Pelicula> Peliculas { get; set; }
		public DbSet<Genero> Generos { get; set; }
		public DbSet<Opinion> Opiniones { get; set;}
		public DbSet<Usuario> Usuarios { get; set; }

		public DbSet<AgregarGeneroDTO> AgregarGeneroDTOs { get; set; }
		public IList<ListarGenerosDTO> ListarGenerosDTOs { get; } 
		public DbSet<GeneroEspecificoDTO> GeneroEspecificoDTOs { get;}
		public DbSet<ModificarGeneroDTO> ModificarGeneroDTOs { get; set;}
		public DbSet<EliminarGeneroDTO> EliminarGeneroDTOs { get; set;}
		public DbSet<AgregarPeliDTO> AgregarPeliDTOs { get; set; }
		public IList<ListarPeliculasDTO> listarPeliculasDTOs { get;}
		public DbSet<PeliculaEspecificDTO> peliculaEspecificDTOs { get;}
		public DbSet<ModificarPeliDTO> ModificarPeliDTOs { get; set; }
		public DbSet<EliminarPelisDTO> EliminarPelisDTOs { get; set; }

	}
}
