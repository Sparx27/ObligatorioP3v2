using Compartido.DTOs.Eventos;
using Compartido.Mappers;
using LogicaAplicacion.ICasosDeUso.Eventos;
using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.Eventos
{
    public class SelectByBusqueda : ISelectByBusqueda
    {
        private readonly IRepositorioEvento _repositorioEvento;
        public SelectByBusqueda(IRepositorioEvento repositorioEvento)
        {
            _repositorioEvento = repositorioEvento;
        }

        public IEnumerable<EventoListaDTO> Ejecutar(EventoBusquedaDTO busqueda)
        {
            // Validaciones de la búsqueda
            if (
                (busqueda.FchInicio != null && busqueda.FchFin == null) ||
                (busqueda.FchFin != null && busqueda.FchInicio == null) ||
                (busqueda.PuntajeMin != null && busqueda.PuntajeMax == null) ||
                (busqueda.PuntajeMax != null && busqueda.PuntajeMin == null)
            ) throw new EventoException("Si ingresa una fecha debe ingresar ambas, lo mismo para los puntajes");

            if (busqueda.FchInicio > busqueda.FchFin) throw new EventoException("Rango de fechas incorrecto");

            if (busqueda.PuntajeMax < busqueda.PuntajeMin) throw new EventoException("Rango de puntajes incorrecto");

            return EventoMapper.EventosToListaDTO(_repositorioEvento.SelectByBusqueda(
                busqueda.DisciplinaId,
                busqueda.FchInicio,
                busqueda.FchFin,
                busqueda.NombreEvento,
                busqueda.PuntajeMin,
                busqueda.PuntajeMax
            ));
        }
    }
}
