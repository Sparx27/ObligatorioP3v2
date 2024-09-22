using LogicaNegocio.Entidades;
using LogicaNegocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioAtleta : IRepositorioAtleta
    {
        private List<Atleta> _liAtletas = new List<Atleta>();
        public void Add(Atleta item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Atleta item)
        {
            throw new NotImplementedException();
        }

        public List<Atleta> GetAll()
        {
            throw new NotImplementedException();
        }

        public Atleta GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Atleta item)
        {
            throw new NotImplementedException();
        }
    }
}
