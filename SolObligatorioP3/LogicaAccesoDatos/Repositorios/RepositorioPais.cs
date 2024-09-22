using LogicaNegocio.Entidades;
using LogicaNegocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioPais : IRepositorioPais
    {
        private List<Pais> _liPaises = new List<Pais>();
        public void Add(Pais item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Pais item)
        {
            throw new NotImplementedException();
        }

        public List<Pais> GetAll()
        {
            throw new NotImplementedException();
        }

        public Pais GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Pais item)
        {
            throw new NotImplementedException();
        }
    }
}
