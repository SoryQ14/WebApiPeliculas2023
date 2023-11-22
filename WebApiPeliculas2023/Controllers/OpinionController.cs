using Microsoft.AspNetCore.Mvc;
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
		//Endpoint pa agregar opinion
		[HttpPost("AgregarOpinion")]
		public async Task<ActionResult> AgregarOpinion(Opinion op)
		{
			context.Add(op);
			await context.SaveChangesAsync();
			return Ok(op); 
		}
		//Endpoint pa modificar opinion


	}
}
