using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApiPeliculas2023.Models;

namespace WebApiPeliculas2023.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CuentasController : Controller
	{
		private readonly UserManager<IdentityUser> userManager;
		private readonly IConfiguration config;
		private readonly SignInManager<IdentityUser> signInManager;

		public CuentasController(SignInManager<IdentityUser> signInManager,
			IConfiguration config,
			UserManager<IdentityUser> userManager)
		{
			this.signInManager = signInManager;
			this.config = config;
			this.userManager = userManager;
		}

		private async Task<RespuestaAutentificacion> ConstruirToken(CredencialesUsuario credencialesUsuario)
		{
			var claims = new List<Claim>()
			{
				new Claim("email", credencialesUsuario.Email)
			};
			var usuario = await userManager.FindByEmailAsync(credencialesUsuario.Email);
			var claimsRoles = await userManager.GetClaimsAsync(usuario!);//claim: pa guardar los roles de susario
			claims.AddRange(claimsRoles); //fusiono los claims

			var llave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["LlaveJWT"]!));
			var creds = new SigningCredentials(llave, SecurityAlgorithms.HmacSha256);

			var expiracion = DateTime.UtcNow.AddDays(1);
			var securityToken = new JwtSecurityToken(issuer: null, audience: null,
				claims: claims, expires: expiracion, signingCredentials: creds);
			return new RespuestaAutentificacion
			{
				Token = new JwtSecurityTokenHandler().WriteToken(securityToken),
				Expiracion = expiracion
			};
		}
		[HttpPost("registrar")]
		public async Task<ActionResult<RespuestaAutentificacion>> registrar(CredencialesUsuario credencialesUsuario)
		{
			var usuario = new IdentityUser
			{
				UserName = credencialesUsuario.Email,
				Email = credencialesUsuario.Email
			};
			var resultado = await userManager.CreateAsync(usuario, credencialesUsuario.Password);
			if (resultado.Succeeded)
				return await ConstruirToken(credencialesUsuario);
			return BadRequest(resultado.Errors);
		}
	}
		
}


