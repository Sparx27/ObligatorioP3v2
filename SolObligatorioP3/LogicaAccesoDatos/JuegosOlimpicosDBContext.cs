using LogicaNegocio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos
{
    public class JuegosOlimpicosDBContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Atleta> Atletas { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Pais> Paises { get; set; }

        public JuegosOlimpicosDBContext(DbContextOptions opt) : base(opt)
        {
            //Pregunta si la base está creada
            if (Database.EnsureCreated())
            {
                //Se ejecuta el método para cargar los datos desde el principio
                InicializarDatos();
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .OwnsOne(u => u.Email)
                .HasIndex(e => e.Valor)
                .IsUnique();

            modelBuilder.Entity<Disciplina>()
                .OwnsOne(d => d.Nombre)
                .HasIndex(n => n.Valor)
                .IsUnique();
        }
        private void InicializarDatos()
        {
            //Consultar si las tablas ya tienen datos, en caso de estar vacías se cargan datos
            if (!Usuarios.Any())
            {
                EjecutarScript("Usuarios_Admin.sql");
            }
            if (!Paises.Any())
            {
                EjecutarScript("Paises.sql");
            }
            if (!Atletas.Any())
            {
                EjecutarScript("Atletas.sql");
            }
        }
        private void EjecutarScript(string nombreScript)
        {
            //Ruta relativa para acceder a los scripts 
            string rutaCompleta = Path.Combine(Directory.GetCurrentDirectory(), "..", "ScriptsDatos", nombreScript);
            //Leer el archivo
            string sql = File.ReadAllText(rutaCompleta);
            //Ejecutar el archivo en la base
            Database.ExecuteSqlRaw(sql);
        }
    }
}
