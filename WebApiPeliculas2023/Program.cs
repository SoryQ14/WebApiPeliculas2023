using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApiPeliculas2023;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); //pruebas

//conexion a la BD
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
/*pa sql
 * builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseUseSqlServe(builder.Configuration.GetConnectionString("DefaultConnection")));
 */
//Configurar la seguridad de la BD
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext
>().AddDefaultTokenProviders(); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
