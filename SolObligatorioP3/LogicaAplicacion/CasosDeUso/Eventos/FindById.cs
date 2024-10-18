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
    public class FindById : IFindById
    {
        private readonly IRepositorioEvento _repositorioEvento;

        public FindById(IRepositorioEvento repositorioEvento)
        {
            _repositorioEvento = repositorioEvento;
        }

        public EventoDTO Ejecutar(int id)
        {
            if (id < 1) throw new EventoException("No existe atleta con ese id");
            return EventoMapper.EventoToDTO(_repositorioEvento.GetById(id));
         
        }
    }
}
