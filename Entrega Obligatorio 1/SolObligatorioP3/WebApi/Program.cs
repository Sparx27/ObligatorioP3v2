using LogicaAccesoDatos;
using LogicaAccesoDatos.Repositorios;
using LogicaAplicacion.CasosDeUso.Atletas;
using LogicaAplicacion.ICasosDeUso.Atletas;
using LogicaNegocio.IRepositorios;
using Microsoft.EntityFrameworkCore;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Conección DB
            builder.Services.AddDbContext<JuegosOlimpicosDBContext>(opt =>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("dbconnection"));
            });

            // Repositorios 
            builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
            builder.Services.AddScoped<IRepositorioAtleta, RepositorioAtleta>();
            builder.Services.AddScoped<IRepositorioEvento, RepositorioEvento>();
            builder.Services.AddScoped<IRepositorioPais, RepositorioPais>();
            builder.Services.AddScoped<IRepositorioDisciplina, RepositorioDisciplina>();

            // Services
            builder.Services.AddScoped<IEventosAtleta, EventosAtleta>();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
