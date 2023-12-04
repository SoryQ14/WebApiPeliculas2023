using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiPeliculas2023.Models;

namespace WebApiPeliculas2023.Controllers
{
	[ApiController]
	[Route("api/controller")]
	public class OpinionController : Controller
	{
		private readonly ApplicationDbContext context;
		public OpinionController(ApplicationDbContext context)
		{
			this.context = context;
		}
		//Endpoint pa agregar opinion(post)
		[HttpPost("AgregarOpinion")]
		public async Task<ActionResult> AgregarOpinion(Opinion op)
		{
			context.Add(op);
			await context.SaveChangesAsync();
			return Ok(op);
		}
		//Endpoint pa modificar opinion(put)
		[HttpPut("ModificarOpinion/{id:int}")]
		public async Task<ActionResult> ModificarOpinion(int id, Opinion opinion)
		{
			var existe = await context.Opiniones.AnyAsync(x => x.Id == id);
			if (!existe) return NotFound("El producto no existe");
			context.Update(opinion);
			await context.SaveChangesAsync();
			return Ok(opinion);
		}
		//Endpoint pa ver una opinion especifica
		[HttpGet("VerOpinion/int:id")]
		public async Task<ActionResult> VerOpinion(int id)
		{
			var opinion = await context.Opiniones.FirstOrDefaultAsync(x => x.Id == id);
			if (opinion == null)
			{
				return NotFound();
			}
			return Ok(opinion);
		}
		//Endpoint pa eliminar opinion
		[HttpDelete("EliminarOpinion")]
		public async Task<ActionResult> EliminarOpinion(int id)
		{
			var exist = await context.Opiniones.AnyAsync(x => x.Id == id);
			if (!exist) return NotFound();
			context.Remove(new Opinion() { Id = id });
			await context.SaveChangesAsync();
			return Ok();
		}

	}
}
