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
    public class AltaDisciplina : IAltaDisciplina
    {
        private IRepositorioDisciplina _repositorioDisciplina;
        public AltaDisciplina(IRepositorioDisciplina repositorioDisciplina)
        {
            _repositorioDisciplina = repositorioDisciplina;
        }

        public void Ejecutar(DisciplinaInsertDTO disciplinaInsertDTO)
        {
            Disciplina? BuscarSiExiste = _repositorioDisciplina.GetByNombre(disciplinaInsertDTO.Nombre);
            if (BuscarSiExiste != null)
            {
                throw new DisciplinaException("Ya existe una disciplina con ese nombre");                
            }

            ValidarDisciplina.Nombre(disciplinaInsertDTO.Nombre);

            _repositorioDisciplina.Add(DisciplinaMapper.InsertDTOToDisciplina(disciplinaInsertDTO));
        }
            

    }
}
