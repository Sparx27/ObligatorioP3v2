using LogicaAccesoDatos;
using LogicaAccesoDatos.Repositorios;
using LogicaAplicacion.CasosDeUso.Atletas;
using LogicaAplicacion.CasosDeUso.Disciplinas;
using LogicaAplicacion.CasosDeUso.Eventos;
using LogicaAplicacion.CasosDeUso.Paises;
using LogicaAplicacion.CasosDeUso.Usuarios;
using LogicaAplicacion.ICasosDeUso.Atletas;
using LogicaAplicacion.ICasosDeUso.Disciplinas;
using LogicaAplicacion.ICasosDeUso.Eventos;
using LogicaAplicacion.ICasosDeUso.Paises;
using LogicaAplicacion.ICasosDeUso.Usuarios;
using LogicaNegocio.IRepositorios;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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

            // Casos de uso
            #region Usuario
            builder.Services.AddScoped<ILoginUsuario, LoginUsuario>();
            builder.Services.AddScoped<IGetByIdUsuario, GetByIdUsuario>();
            builder.Services.AddScoped<IAltaUsuario, AltaUsuario>();
            builder.Services.AddScoped<IFindAllUsuarios, FindAllUsuarios>();
            builder.Services.AddScoped<IUpdateUsuario, UpdateUsuario>();
            builder.Services.AddScoped<IDeleteUsuario, DeleteUsuario>();
            #endregion

            #region Atleta
            builder.Services.AddScoped<IAltaAtleta, AltaAtleta>();
            builder.Services.AddScoped<IFindAllAtletas, FindAllAtletas>();
            builder.Services.AddScoped<IGetByIdAtleta, GetByIdAtleta>();
            builder.Services.AddScoped<IAgregarDisciplina, AgregarDisciplina>();
            builder.Services.AddScoped<ISelectByDisciplinaId, SelectByDisciplinaId>();
            #endregion

            #region Disciplina
            builder.Services.AddScoped<IFindAllDisciplinas, FindAllDisciplinas>();
            builder.Services.AddScoped<IAltaDisciplina, AltaDisciplina>();
            builder.Services.AddScoped<IDeleteDisciplina, DeleteDisciplina>();
            builder.Services.AddScoped<IFindAtletasDisciplina, FindAtletasDisciplina>();
            #endregion

            #region Evento
            builder.Services.AddScoped<IAltaEvento, AltaEvento>();
            builder.Services.AddScoped<IFindEventosFecha, FindEventosFecha>();
            builder.Services.AddScoped<IFindById, FindById>();
            builder.Services.AddScoped<ICargarPuntajes, CargarPuntajes>();
            #endregion

            builder.Services.AddScoped<IAltaPais, AltaPais>();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            
            builder.Services.AddAuthentication(aut =>
            {
                aut.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                aut.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(aut =>
            {
                aut.RequireHttpsMetadata = false;
                aut.SaveToken = true;
                aut.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes(builder.Configuration.GetValue<string>("JWT:Secret"))),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(opts =>
            {
                opts.IncludeXmlComments("WebAPIDoc.xml");
            });

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
