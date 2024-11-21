using LogicaAplicacion.ICasosDeUso.Disciplinas;
using LogicaNegocio.Entidades;
using LogicaNegocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.ExcepcionesEntidades;

namespace LogicaAplicacion.CasosDeUso.Disciplinas
{
    public class DeleteDisciplina : IDeleteDisciplina
    {
        private readonly IRepositorioDisciplina _repositorioDisciplina;
        public DeleteDisciplina(IRepositorioDisciplina repositorioDisciplina)
        {
            _repositorioDisciplina = repositorioDisciplina;
        }

        public void Ejecutar(int id)
        {
            Disciplina buscarDisciplina = _repositorioDisciplina.GetById(id);
            if (buscarDisciplina == null) throw new DisciplinaException($"No se encontró una Disciplina con id: {id}");
            _repositorioDisciplina.Delete(buscarDisciplina);
        }
    }
}
