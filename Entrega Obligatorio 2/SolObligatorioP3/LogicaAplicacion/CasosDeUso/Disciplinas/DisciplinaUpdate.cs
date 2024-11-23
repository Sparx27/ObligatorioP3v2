using Compartido.DTOs.Disciplinas;
using Compartido.Mappers;
using LogicaAplicacion.ICasosDeUso.Disciplinas;
using LogicaAplicacion.Validadores;
using LogicaNegocio.Entidades;
using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.IRepositorios;
using LogicaNegocio.ValueObjects.Disciplina;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.Disciplinas
{
    public class DisciplinaUpdate : IDisciplinaUpdate
    {
        private readonly IRepositorioDisciplina _repositorioDisciplina;
        public DisciplinaUpdate(IRepositorioDisciplina repositorioDisciplina)
        {
            _repositorioDisciplina = repositorioDisciplina;
        }

        public DisciplinaDTO Ejecutar(int id, DisciplinaUpdateDTO dto)
        {
            ValidarDisciplina.Nombre(dto.Nombre);
            ValidarDisciplina.Anio(dto.AnioIntegracion);

            Disciplina Existe = _repositorioDisciplina.GetById(id)
                 ?? throw new DisciplinaException("Disciplina no encontrada");

            if (dto.Nombre == Existe.Nombre.Valor) throw new ConflictException("Ya existe una disciplina con ese nombre");

            Existe.Nombre = new RDisciplinaNombre( dto.Nombre);
            Existe.AnioIntegracion = dto.AnioIntegracion;
                
            _repositorioDisciplina.Update(Existe);

            return DisciplinaMapper.DisciplinaToDTO(Existe);
        }
    }
}
