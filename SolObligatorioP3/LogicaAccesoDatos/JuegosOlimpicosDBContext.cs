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
        public DbSet<Usuario> Usuarios {  get; set; }
        public DbSet<Atleta> Atletas { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Pais> Paises { get; set; }

        public JuegosOlimpicosDBContext(DbContextOptions opt) : base(opt) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
            .OwnsOne(u => u.Email)
            .HasIndex(e => e.Valor)
            .IsUnique();
        }
    }
}
