using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Usuario;
using Usuario.Models;
using Usuario.Repositorios;
using Usuario.Servicios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

//builder.Services.AddDbContext<UsuarioDbContext>(o => o.UseSqlServer("Data Source=app-db;Initial Catalog=Usuarios;User Id=sa;Password=Pass@word;Trusted_Connection=True;MultipleActiveResultSets=True"));
//builder.Services.AddEntityFramework().AddSqlServer()
//    .AddDbContext<UsuarioDbContext>(options => options.UseSqlServer("Data Source=app-db;Initial Catalog=Usuarios;User Id=sa;Password=Pass@word;Trusted_Connection=True;MultipleActiveResultSets=True"));
builder.Services.AddDbContext<UsuarioDbContext>(options =>
  options.UseSqlServer("Data Source=app-db;Initial Catalog=Usuarios;User Id=sa;Password=Pass@word;TrustServerCertificate=True;MultipleActiveResultSets=True"));

builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IRepositorio<Cliente>, ClienteRepository>();
builder.Services.AddScoped<IRepositorio<Cuenta>, CuentaRepository>();
builder.Services.AddScoped<IRepositorio<Movimiento>, MovimientoRepository>();
builder.Services.AddScoped<IServicioTransacciones,ServicioTransacciones>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    using (var scope = app.Services.CreateScope())
    {
        var userContext = scope.ServiceProvider.GetRequiredService<UsuarioDbContext>();//get
        userContext.Database.EnsureDeleted();
        userContext.Database.EnsureCreated();
        //DbInitializer.Initialize(UsuarioDbContext);
    }
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
