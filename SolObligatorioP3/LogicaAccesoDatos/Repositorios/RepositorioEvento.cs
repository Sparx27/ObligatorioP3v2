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
        private List<Pais> _liPaises = new List<Pais>();
        public void Add(Evento item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Evento item)
        {
            throw new NotImplementedException();
        }

        public List<Evento> GetAll()
        {
            throw new NotImplementedException();
        }

        public Evento GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Evento item)
        {
            throw new NotImplementedException();
        }
    }
}
