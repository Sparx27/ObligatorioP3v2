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
            Evento eventoAModificar = _repositorioEvento.GetById(eventoUpdatePuntajesDTO.Id);

            if (eventoAModificar == null) throw new EventoException("No se encontró un evento con ese Id");

            eventoAModificar.LiPuntajes = EventoMapper.DtoListaModificadaToListaPuntaje(eventoUpdatePuntajesDTO.LiAtletas);

            _repositorioEvento.Update(eventoAModificar);

            return EventoMapper.EventoToDTO(eventoAModificar);
        }
    }
}
