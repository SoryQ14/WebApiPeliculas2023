using AutoMapper;
using WebApiPeliculas2023.DTOs;
using WebApiPeliculas2023.Models;

namespace WebApiPeliculas2023
{
	public class AutoMapping: Profile
	{
		public AutoMapping()
		{
			CreateMap<AgregarGeneroDTO, Genero>();
			CreateMap<ListarGenerosDTO, Genero>();
			CreateMap<GeneroEspecificoDTO, Genero>();
			CreateMap<ModificarGeneroDTO, Genero>();
			CreateMap<EliminarGeneroDTO, Genero>();
			CreateMap<AgregarPeliDTO, Pelicula>();
			CreateMap<ListarPeliculasDTO, Pelicula>();
			CreateMap<PeliculaEspecificDTO, Pelicula>();
			CreateMap<ModificarPeliDTO, Pelicula>(); 
		}
	}
}
