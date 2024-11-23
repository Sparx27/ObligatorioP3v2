using Compartido.DTOs.Disciplinas;
using Compartido.Mappers;
using LogicaAccesoDatos;
using LogicaAplicacion.ICasosDeUso.Disciplinas;
using LogicaAplicacion.Validadores;
using LogicaNegocio.Entidades;
using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.Disciplinas
{
    public class InsertDisciplina : IInsertDisciplina
    {
        private IRepositorioDisciplina _repositorioDisciplina;
        public InsertDisciplina(IRepositorioDisciplina repositorioDisciplina)
        {
            _repositorioDisciplina = repositorioDisciplina;
        }

        public int Ejecutar(DisciplinaInsertDTO disciplinaInsertDTO)
        {
            ValidarDisciplina.Nombre(disciplinaInsertDTO.Nombre);
            ValidarDisciplina.Anio(disciplinaInsertDTO.AnioIntegracion);

            Disciplina? BuscarSiExiste = _repositorioDisciplina.GetByNombre(disciplinaInsertDTO.Nombre);
            if (BuscarSiExiste != null) throw new ConflictException("Ya existe una disciplina con ese nombre");

            Disciplina disciplina = _repositorioDisciplina.Insert(DisciplinaMapper.InsertDTOToDisciplina(disciplinaInsertDTO));
            return disciplina.Id;
        }
    }
}
