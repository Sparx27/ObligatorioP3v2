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
            throw new NotImplementedException();
        }

        public void Add(Evento item, int[] atletasId)
        {
            _dbContext.Eventos.Add(item);
            _dbContext.SaveChanges();

            item.LiPuntajes = atletasId.Select(id => new PuntajeEvenetoAtleta
            {
                AtletaId = id,
                EventoId = item.Id,
                Puntaje = -1            // -1 Para indicar el caso en que aún un Atleta no recibió un puntaje
            }).ToList();
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

        public void Update(Evento item)
        {
            throw new NotImplementedException();
        }
    }
}
