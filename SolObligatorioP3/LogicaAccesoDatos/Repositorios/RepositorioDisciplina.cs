using LogicaNegocio.Entidades;
using LogicaNegocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Repositorios
{
    internal class RepositorioDisciplina : IRepositorioDisciplina
    {
        private List<Disciplina> _liDisciplinas = new List<Disciplina>();
        public void Add(Disciplina item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Disciplina item)
        {
            throw new NotImplementedException();
        }

        public List<Disciplina> GetAll()
        {
            throw new NotImplementedException();
        }

        public Disciplina GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Disciplina item)
        {
            throw new NotImplementedException();
        }
    }
}
