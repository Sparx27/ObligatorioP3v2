using Compartido.DTOs.Eventos;
using Compartido.Mappers;
using LogicaAplicacion.ICasosDeUso.Eventos;
using LogicaNegocio.Entidades;
using LogicaNegocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.ExcepcionesEntidades;
using LogicaAplicacion.Validadores;

namespace LogicaAplicacion.CasosDeUso.Eventos
{
    public class CargarPuntajes:ICargarPuntajes
    {
        private readonly IRepositorioEvento _repositorioEvento;
        public CargarPuntajes(IRepositorioEvento repositorioEvento)
        {
            _repositorioEvento = repositorioEvento;
        }

        public EventoDTO Ejecutar(EventoUpdatePuntajesDTO eventoUpdatePuntajesDTO)
        {
            // Validar puntajes >= 0
            ValidarEvento.Puntajes(eventoUpdatePuntajesDTO);

            // Validar que existe el Evento
            Evento eventoAModificar = _repositorioEvento.GetById(eventoUpdatePuntajesDTO.Id);
            if (eventoAModificar == null) throw new EventoException("No se encontró un evento con ese Id");
            

            // Update
            eventoAModificar.LiPuntajes = EventoMapper.DtoListaModificadaToListaPuntaje(eventoUpdatePuntajesDTO.LiAtletas);
            _repositorioEvento.Update(eventoAModificar);

            return EventoMapper.EventoToDTO(eventoAModificar);
        }
    }
}
