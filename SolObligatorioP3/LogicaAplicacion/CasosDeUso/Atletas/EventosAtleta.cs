using Compartido.DTOs.Eventos;
using Compartido.Mappers;
using LogicaAplicacion.ICasosDeUso.Atletas;
using LogicaNegocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.Atletas
{
    public class EventosAtleta : IEventosAtleta
    {
        private readonly IRepositorioEvento _repositorioEvento;
        public EventosAtleta(IRepositorioEvento repositorioEvento)
        {
            _repositorioEvento = repositorioEvento;
        }
        public IEnumerable<AtletaEventoListaDTO> Ejecutar(int atletaId)
            => EventoMapper.EventoToListaAtletaEventoDTO(_repositorioEvento.GetEventosAtleta(atletaId));
    }
}
