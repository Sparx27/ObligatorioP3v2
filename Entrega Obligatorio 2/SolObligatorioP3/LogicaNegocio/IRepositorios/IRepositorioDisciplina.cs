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
        Disciplina Insert(Disciplina item);
        Disciplina? GetByNombre(string nombre);
        List<Atleta> GetAtletasDisciplina(int idDisciplina);
    }
}
