using Compartido.DTOs.Eventos;
using Compartido.Mappers;
using LogicaAplicacion.ICasosDeUso.Eventos;
using LogicaNegocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.Eventos
{
    public class FindEventosFecha : IFindEventosFecha
    {
        private readonly IRepositorioEvento _repositorioEvento;

        public FindEventosFecha(IRepositorioEvento repositorioEvento)
        {
            _repositorioEvento = repositorioEvento;
        }
        public IEnumerable<EventoListaDTO> Ejecutar(DateTime fecha) => EventoMapper.EventosToListaDTO(_repositorioEvento.GetByFecha(fecha));


    }
}
