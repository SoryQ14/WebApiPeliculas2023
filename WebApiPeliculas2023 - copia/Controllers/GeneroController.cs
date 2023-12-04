using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.IO.MemoryMappedFiles;
using WebApiPeliculas2023.DTOs;
using WebApiPeliculas2023.Models;

namespace WebApiPeliculas2023.Controllers
{
	[ApiController]
	[Route("api/[controller]")]//por si cambiamos el nombre de la casa
	public class GeneroController : Controller
	{
		private readonly ApplicationDbContext context;
		private readonly IMapper _mapper; 
		public GeneroController(IMapper mapper, ApplicationDbContext context)
		{
			_mapper = mapper;
			this.context = context; 
		}
		/*public GeneroController(ApplicationDbContext context)
		{
		//	this.context = context;
		//}
		//Endpoint pa dar de alta genero (post)

		//task:para poder mandar la informacion que se neceita mandar(dif tipos de valores)
		//Async: la forma de trabajar es asincrona, la direccion es al mismo tiempo, siempre va junto async y await
		//[HttpPost("RegistrarGenero")]
		//public async Task<ActionResult> RegistrarGenero(Genero genero)
		//{
		//	validacion de ke existe genero, consulta con el lenguaje de identity 
		//	Buscar consultas basicas de EntityFramework 
		//	var existeGenero = await context.Generos.AnyAsync(x => x.Nombre == genero.Nombre);
		//	if (existeGenero)
		//	{
		//		return BadRequest($"El genero {genero.Nombre} ya existe"); 
		//	}
		//	context.Add(genero);
		//	await context.SaveChangesAsync();se guardan los cambios de forma asincrona
		return Ok(genero);
		}*/

		[HttpPost("RegistrarGenero")]
		public async Task<ActionResult> RegistrarGenero(AgregarGeneroDTO generoDTO)
		{
			
			var existeGenero = await context.Generos.AnyAsync(x => x.Nombre == generoDTO.Nombre);
			if (existeGenero)
			{
				return BadRequest($"El genero {generoDTO.Nombre} ya existe");
			}
			var genero = _mapper.Map<Genero>(generoDTO);
			context.Add(genero);
			await context.SaveChangesAsync();
			return Ok(generoDTO);
		}

		//End point para listar todas las categorias 
		[HttpGet("ListarGeneros")]
		public async Task<ActionResult<List<Genero>>> ListarGeneros()
		{
			var genero = await context.Generos.ToListAsync();
			var generoDTO = _mapper.Map<List<Genero>>(genero);
			return Ok(generoDTO); 
		}

		//Endpoint pa buscar inf de un genero especific
		[HttpGet("GeneroEspecifico/{nombre}")]
		public async Task<ActionResult<Genero>> GeneroEspecifico(string nombre)
		{
			var genero =await context.Generos.FirstOrDefaultAsync( x=> x.Nombre == nombre);
			if (genero == null)
			{
				return NotFound(); 
			}
			var generoDTO = _mapper.Map<Genero>(genero); 
			return Ok(generoDTO); 
		}
		//put actualizar todo
		//[HttpPut("ActualizarGenero/")]
		//public async Task<ActionResult<Genero>> ActualizarGenero(string nombre, string nuevoNomb)
		//{
		//	var genero = await context.Generos.FirstOrDefaultAsync(x => x.Nombre==nombre);

		//	if (genero == null)
		//	{
		//		return NotFound();
		//	}
		//	if (genero.Nombre == nuevoNomb)
		//	{
		//		return BadRequest($"El genero {genero.Nombre} tiene el mismo nombre");

		//	}
		//	genero.Nombre = nuevoNomb;
		//	context.Generos.Update(genero);
		//	await context.SaveChangesAsync();
		//	return Ok(genero);
		//}
		[HttpPut("ModificarGenero/{id:int}")]
		public async Task<ActionResult> ModificarGenero(int id, Genero generoDTO)
		{
			var existe = await context.Generos.AnyAsync(x => x.Id == id);
			if(!existe) return NotFound("El producto no existe");
			var genero = _mapper.Map<Genero>(generoDTO);
			context.Update(generoDTO); 
			await context.SaveChangesAsync();
			return Ok(generoDTO); 
		}

	/*Put profe
	 * 
	 */
	//Endpoint pa eliminar un genero
	[HttpDelete("EliminarGeneroDTO/{id:int}")]
		public async Task<ActionResult> EliminarCategoria(int id, IMapper mapper)
		{
			var genero = await context.Generos.SingleOrDefaultAsync(z => z.Id == id);
			if (genero == null)
			{
				return NotFound();
			}
			var generoDTO = mapper.Map<Genero>(genero);
			context.Remove(genero);
			await context.SaveChangesAsync();
			return Ok(); 
		}
	}
}
