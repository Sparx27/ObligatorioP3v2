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

namespace LogicaAplicacion.CasosDeUso.Eventos
{
    public class CargarPuntajes:ICargarPuntajes
    {
        private readonly IRepositorioEvento _repositorioEvento;
        public CargarPuntajes(IRepositorioEvento repositorioEvento)
        {
            _repositorioEvento = repositorioEvento;
        }

        public void Ejecutar(EventoDTO eventoModificado)
        {
           Evento eventoAModificar = _repositorioEvento.GetById(eventoModificado.Id);

            eventoAModificar.LiPuntajes = EventoMapper.DtoListaModificadaToListaPuntaje(eventoModificado.LiAtletas);

            _repositorioEvento.Update(eventoAModificar);
        }
    }
}
