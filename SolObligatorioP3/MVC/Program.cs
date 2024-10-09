using LogicaAplicacion.CasosDeUso.Atletas;
using LogicaAplicacion.CasosDeUso.Disciplinas;
using LogicaAplicacion.CasosDeUso.Eventos;
using LogicaAplicacion.CasosDeUso.Usuarios;
using LogicaAplicacion.ICasosDeUso.Atletas;
using LogicaAplicacion.ICasosDeUso.Disciplinas;
using LogicaAplicacion.ICasosDeUso.Eventos;
using LogicaAplicacion.ICasosDeUso.Paises;
using LogicaAplicacion.ICasosDeUso.Usuarios;
using LogicaAccesoDatos;
using Microsoft.EntityFrameworkCore;
using LogicaAplicacion.CasosDeUso.Paises;
using LogicaNegocio.IRepositorios;
using LogicaAccesoDatos.Repositorios;

var builder = WebApplication.CreateBuilder(args);

// Sesión usuario
builder.Services.AddSession();

// Add services to the container.
builder.Services.AddControllersWithViews();
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
#endregion

#region Disciplina
builder.Services.AddScoped<IFindAllDisciplinas, FindAllDisciplinas>();
builder.Services.AddScoped<IAltaDisciplina, AltaDisciplina>();
builder.Services.AddScoped<IDeleteDisciplina, DeleteDisciplina>();
#endregion



builder.Services.AddScoped<IAltaEvento, AltaEvento>();
builder.Services.AddScoped<IAltaPais, AltaPais>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}");

app.UseSession();

app.Run();
