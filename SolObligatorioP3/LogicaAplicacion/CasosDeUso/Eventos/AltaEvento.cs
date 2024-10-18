using Compartido.DTOs.Eventos;
using LogicaAccesoDatos;
using LogicaAccesoDatos.Repositorios;
using LogicaAplicacion.ICasosDeUso.Eventos;
using LogicaNegocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.ExcepcionesEntidades;
using LogicaAplicacion.Validadores;
using Compartido.Mappers;

namespace LogicaAplicacion.CasosDeUso.Eventos
{
    public class AltaEvento : IAltaEvento
    {
        private readonly IRepositorioEvento _repositorioEvento;
        private readonly IRepositorioDisciplina _repositorioDisciplina;
        public AltaEvento(IRepositorioEvento repositorioEvento, IRepositorioDisciplina repositorioDisciplina)
        {
            _repositorioEvento = repositorioEvento;
            _repositorioDisciplina = repositorioDisciplina;
        }

        public void Ejecutar(EventoInsertDTO eventoInsertDTO)
        {
            if (eventoInsertDTO == null)
                throw new EventoException("El Evento DTO se encuentra vacío");

            if (_repositorioEvento.GetByNombre(eventoInsertDTO.NombrePrueba) != null) 
                throw new EventoException("Ya existe un evento con ese nombre");

            ValidarEvento.CantidadAtletas(eventoInsertDTO);
            ValidarEvento.AtletasRegistradosEnDisciplina
                (_repositorioDisciplina.GetAtletasDisciplina(eventoInsertDTO.DisciplinaId) , eventoInsertDTO.AtletasId);

            _repositorioEvento.Add(EventoMapper.DtoToEvento(eventoInsertDTO));
        }
    }
}
