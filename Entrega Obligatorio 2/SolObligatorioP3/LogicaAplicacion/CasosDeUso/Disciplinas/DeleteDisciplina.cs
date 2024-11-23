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
            if (id <= 0) throw new DisciplinaException("Id incorrecto");

            Disciplina buscarDisciplina = _repositorioDisciplina.GetById(id)
                ?? throw new DisciplinaException($"No se encontró una Disciplina con id: {id}");

            if (buscarDisciplina.LiAtletas.Count > 0) 
                throw new ConflictException("No se puede eliminar una disciplina con atletlas registrados");

            _repositorioDisciplina.Delete(buscarDisciplina);
        }
    }
}
