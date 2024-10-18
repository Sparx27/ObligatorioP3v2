using LogicaNegocio.Entidades;
using LogicaNegocio.IRepositorios;
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

        public Evento GetById(int id) => _dbContext.Eventos.SingleOrDefault(e => e.Id == id);

        public Evento GetByNombre(string nombre) => _dbContext.Eventos.SingleOrDefault(e => e.NombrePrueba == nombre);

        public List<Evento> GetByFecha (DateTime fecha)
        {
            return _dbContext.Eventos.Where(e=> e.FchInicio <= fecha && e.FchFin >= fecha).ToList();
        }

        public void Update(Evento item)
        {
            throw new NotImplementedException();
        }
    }
}
