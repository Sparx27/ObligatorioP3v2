using LogicaNegocio.Entidades;
using LogicaNegocio.IRepositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.ExcepcionesEntidades;

namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioAtleta : IRepositorioAtleta
    {
        private readonly JuegosOlimpicosDBContext _context;
        public RepositorioAtleta(JuegosOlimpicosDBContext context)
        {
            _context = context;
        }

        public void Add(Atleta item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Atleta item)
        {
            throw new NotImplementedException();
        }

        public List<Atleta> GetAll() =>
            _context.Atletas
                .Include(a => a.Pais)
                .OrderBy(a => a.Pais.Nombre)
                .ThenBy(a => a.Apellido)
                .ThenBy(a => a.Nombre)
                .ToList();

        public Atleta GetById(int id)
        {
            Atleta atleta = _context.Atletas
                                .Include(a => a.Pais)
                                .Include(a => a.LiDisciplinas)
                                .SingleOrDefault(a => a.Id == id);

            if (atleta == null)
            {
                throw new AtletaException("Atleta no encontrado por id");
            }

            return atleta;

        }

        public void Update(Atleta item)
        {
            throw new NotImplementedException();
        }

        public void GuardarCambios()
        {
            _context.SaveChanges();
        }
    }
}
