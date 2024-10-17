using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.IRepositorios
{
    public interface IRepositorioDisciplina : IRepositorio<Disciplina>
    {
        public Disciplina? GetByNombre(string nombre);

        public List<Atleta> GetAtletasDisciplina(int idDisciplina);
    }
}
