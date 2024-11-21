using LogicaNegocio.Entidades;
using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.IRepositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioDisciplina : IRepositorioDisciplina
    {
        private readonly JuegosOlimpicosDBContext _context;

        public RepositorioDisciplina(JuegosOlimpicosDBContext context)
        {
            _context = context;
        }
        public void Add(Disciplina item)
        {
            _context.Disciplinas.Add(item);
            _context.SaveChanges();
        }


        public void Delete(Disciplina item)
        {
            _context.Disciplinas.Remove(item);
            _context.SaveChanges();
        }

        public List<Disciplina> GetAll() =>
            _context.Disciplinas
                .AsEnumerable()
                .OrderBy(d => d.Nombre.Valor)
                .ToList();
        // NOTA: AsEnumerable porque Nombre es un ValueObject

        public List<Atleta> GetAtletasDisciplina(int idDisciplina)
        {
            Disciplina buscar = _context.Disciplinas
                .Include(d => d.LiAtletas)
                .ThenInclude(a => a.Pais)
                .SingleOrDefault(d => d.Id == idDisciplina);
            if (buscar == null) throw new DisciplinaException("Disciplina no encontrada con ese id");
            return buscar.LiAtletas;
        }

        public Disciplina GetById(int id)
        {
            Disciplina disciplina = _context.Disciplinas.SingleOrDefault(d => d.Id == id);

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

        public Disciplina? GetByNombre(string nombre) =>
             _context.Disciplinas.SingleOrDefault(disiplina => disiplina.Nombre.Valor == nombre);
    }
}
