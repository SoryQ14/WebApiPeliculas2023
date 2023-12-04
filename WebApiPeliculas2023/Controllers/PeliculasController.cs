using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiPeliculas2023.Models;

namespace WebApiPeliculas2023.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class PeliculasController : Controller
	{
		private readonly ApplicationDbContext context;
		private readonly IMapper _mapper;
		public PeliculasController(IMapper mapper, ApplicationDbContext context)
		{
			_mapper = mapper;
			this.context = context;
		}
		//private readonly ApplicationDbContext context;
		//public PeliculasController(ApplicationDbContext context)
		//{
		//	this.context = context;
		//}
		//Endpoint pa agregar peliculas(post)
		[HttpPost("RegistrarPeli")]
		public async Task<ActionResult> RegistrarPeli(Pelicula peliculaDTO)
		{

			var existePeli = await context.Peliculas.AnyAsync(x => x.Titulo == peliculaDTO.Titulo);
			if (existePeli)
			{
				return BadRequest($"El titulo {peliculaDTO.Titulo} ya existe");
			}
			var genero = _mapper.Map<Pelicula>(peliculaDTO);
			context.Add(peliculaDTO);
			await context.SaveChangesAsync();
			return Ok(peliculaDTO);
		}


		//Endpoint pa buscar peliculas
		[HttpGet("ListarPeliculas")]
		public async Task<ActionResult<List<Pelicula>>> ListarPeliculas()
		{
			var peli = await context.Peliculas.ToListAsync();
			var pelisDTO = _mapper.Map<List<Pelicula>>(peli);
			return Ok(pelisDTO);
		}

		//Endpoint pa buscar una peli especifica
		[HttpGet("PeliEspecifico/{nombre}")]
		public async Task<ActionResult<Pelicula>> PeliEspecifico(string Titulo)
		{
			var peli = await context.Peliculas.FirstOrDefaultAsync(x => x.Titulo == Titulo);
			if (peli == null)
			{
				return NotFound();
			}
			var peliDTO = _mapper.Map<Pelicula>(peli);
			return Ok(peliDTO);
		}

		//Endpoint pa modificar pelicula
		[HttpPut("ModificarPeli/{id:int}")]
		public async Task<ActionResult> ModificarPeli(int Id, Pelicula peliDTO)
		{
			var existe = await context.Peliculas.AnyAsync(x => x.id == Id);
			if (!existe) return NotFound("La pelcula no existe");
			var peli = _mapper.Map<Pelicula>(peliDTO);
			context.Update(peliDTO);
			await context.SaveChangesAsync();
			return Ok(peliDTO);
		}
		//Endpoint pa eliminar una pelicula
		[HttpDelete("EliminarPeliDTO/{id:int}")]
		public async Task<ActionResult> EliminarPeli(int Id, IMapper mapper)
		{
			var pelicula = await context.Peliculas.SingleOrDefaultAsync(z => z.id == Id);
			if (pelicula == null)
			{
				return NotFound();
			}
			var generoDTO = mapper.Map<Genero>(pelicula);
			context.Remove(pelicula);
			await context.SaveChangesAsync();
			return Ok();
		}

	}
}
