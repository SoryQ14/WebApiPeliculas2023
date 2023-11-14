using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using WebApiPeliculas2023.Models;

namespace WebApiPeliculas2023.Controllers
{
	[ApiController]
	[Route("api/[controller]")]//por si cambiamos el nombre de la casa
	public class GeneroController : Controller
	{
		private readonly ApplicationDbContext context;
		public GeneroController(ApplicationDbContext context)
		{
			this.context = context;
		}
		//Endpoint pa dar de alta genero (post)
		[HttpPost("RegistrarGenero")]
		//task:para poder mandar la informacion que se neceita mandar(dif tipos de valores)
		//Async: la forma de trabajar es asincrona, la direccion es al mismo tiempo, siempre va junto async y await
		public async Task<ActionResult> RegistrarGenero(Genero genero)
		{
			//validacion de ke existe genero, consulta con el lenguaje de identity 
			//Buscar consultas basicas de EntityFramework 
			var existeGenero = await context.Generos.AnyAsync(x => x.Nombre == genero.Nombre);
			if (existeGenero)
			{
				return BadRequest($"El genero {genero.Nombre} ya existe"); 
			}
			context.Add(genero);
			await context.SaveChangesAsync();//se guardan los cambios de forma asincrona
			return Ok(genero);
		}
		//End point para listar todas las categorias 
		[HttpGet("ListarGeneros")]
		public async Task<ActionResult<List<Genero>>> ListarGeneros()
		{
			var generos = await context.Generos.ToListAsync();
			return Ok(generos); 
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
			return Ok(genero); 
		}
		//put actualizar todo
		[HttpPut("ActualizarGenero/")]
		public async Task<ActionResult<Genero>> ActualizarGenero(string nombre, string nuevoNomb)
		{
			var genero = await context.Generos.FirstOrDefaultAsync(x => x.Nombre==nombre);

			if (genero == null)
			{
				return NotFound();
			}
			if (genero.Nombre == nuevoNomb)
			{
				return BadRequest($"El genero {genero.Nombre} tiene el mismo nombre");

			}
			genero.Nombre = nuevoNomb;
			context.Generos.Update(genero);
			await context.SaveChangesAsync();
			return Ok(genero);
		}
		[HttpPut("ModificarGenero/{id:int}")]
		public async Task<ActionResult> ModificarGenero(int id, Genero genero)
		{
			var existe = await context.Generos.AnyAsync(x => x.Id == id);
			if(!existe) return NotFound("El producto no existe");
			context.Update(genero); 
			await context.SaveChangesAsync();
			return Ok(genero); 
		}
	/*Put profe
	 * 
	 */
	//Endpoint pa eliminar un genero
	[HttpDelete("EliminarGenero/{id:int}")]
		public async Task<ActionResult> EliminarCategoria(int id)
		{
			var existe = await context.Generos.AnyAsync(z => z.Id == id);
			if (!existe) return NotFound();
			context.Remove(new Genero() { Id = id });
			await context.SaveChangesAsync();
			return Ok(); 
		}
	}
}
