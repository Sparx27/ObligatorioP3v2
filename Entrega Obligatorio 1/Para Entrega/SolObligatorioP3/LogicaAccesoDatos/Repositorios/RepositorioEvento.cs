using LogicaNegocio.Entidades;
using LogicaNegocio.IRepositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioEvento : IRepositorioEvento
    {
        private readonly JuegosOlimpicosDBContext _dbContext;
        public RepositorioEvento(JuegosOlimpicosDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Evento item)
        {
            _dbContext.Eventos.Add(item);
            _dbContext.SaveChanges();
        }

        public void Delete(Evento item)
        {
            throw new NotImplementedException();
        }

        public List<Evento> GetAll()
        {
            throw new NotImplementedException();
        }

        public Evento GetById(int id) =>
            _dbContext.Eventos
                .Include(e => e.LiPuntajes)
                .ThenInclude(p => p.Atleta)
                .ThenInclude(a => a.Pais)
                .SingleOrDefault(e => e.Id == id);

        public Evento GetByNombre(string nombre) => _dbContext.Eventos.SingleOrDefault(e => e.NombrePrueba == nombre);

        public List<Evento> GetByFecha(DateTime fecha)
        {
            return _dbContext.Eventos.Where(e => e.FchInicio <= fecha && e.FchFin >= fecha).ToList();
        }

        public void Update(Evento item)
        {
            _dbContext.Eventos.Update(item);
            _dbContext.SaveChanges();
        }

        public List<Evento> GetEventosAtleta(int atletaId) =>
            _dbContext.Eventos
                .Include(e => e.Disciplina)
                .Where(e => e.LiPuntajes.Any(p => p.AtletaId == atletaId))
                .OrderBy(e => e.Disciplina.Nombre.Valor)
                .ToList();
    }
}
