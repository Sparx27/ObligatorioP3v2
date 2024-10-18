using Compartido.DTOs.Eventos;
using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.ExcepcionesEntidades;

namespace Compartido.Mappers
{
    public static class EventoMapper
    {
        public static Evento DtoToEvento(EventoInsertDTO dto)
        {
            if (dto == null) throw new EventoException("Evento insert DTO vacío en mapper");

             Evento res = new Evento
            {
                DisciplinaId = dto.DisciplinaId,
                FchInicio = dto.FchInicio,
                FchFin = dto.FchFin,
                NombrePrueba = dto.NombrePrueba,
                LiPuntajes = dto.AtletasId.Select(id => new PuntajeEventoAtleta
                 {
                     AtletaId = id,
                     Puntaje = -1 //-1 Para indicar el caso en que aún un Atleta no recibió un puntaje
                 }).ToList()

             };

            return res;

        }

        public static IEnumerable<EventoListaDTO> EventosToListaDTO(List<Evento> listaEventos)
        {
            IEnumerable<EventoListaDTO> eventos = listaEventos.Select(e => new EventoListaDTO
            {
                EventoId = e.Id,
                NombrePrueba = e.NombrePrueba,
                FchInicio = e.FchInicio,
                FchFin = e.FchFin
            });

            return eventos;
        }

        public static EventoDTO EventoToDTO(Evento evento)
        {
            EventoDTO eventoDto = new EventoDTO
            {
                Id = evento.Id,
                FchInicio = evento.FchInicio,
                FchFin = evento.FchFin,
                NombrePrueba = evento.NombrePrueba
            };

            return eventoDto;
        }
    }
}
