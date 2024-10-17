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

            return new Evento
            {
                DisciplinaId = dto.DisciplinaId,
                FchInicio = dto.FchInicio,
                FchFin = dto.FchFin,
                NombrePrueba = dto.NombrePrueba
            };
        }
    }
}
