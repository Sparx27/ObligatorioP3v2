using LogicaNegocio.Entidades;
using LogicaNegocio.ExcepcionesEntidades;
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
        private readonly JuegosOlimpicosDBContext _context;

        public RepositorioDisciplina(JuegosOlimpicosDBContext context)
        {
            _context = context;
        }
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
            Disciplina disciplina = _context.Disciplinas.FirstOrDefault(d => d.Id == id);

            if (disciplina == null)
            {
                throw new DisciplinaException("Disciplina no encontrada por id");
            }

            return disciplina;
        }

        public void Update(Disciplina item)
        {
            throw new NotImplementedException();
        }
    }
}
