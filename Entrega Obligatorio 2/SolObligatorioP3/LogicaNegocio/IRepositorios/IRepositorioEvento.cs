using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.IRepositorios
{
    public interface IRepositorioEvento : IRepositorio<Evento>
    {
        Evento GetByNombre(string nombre);
        List<Evento> GetByFecha (DateTime fecha);
        List<Evento> GetEventosAtleta(int atletaId);
        List<Evento> SelectByBusqueda
            (int? disciplinaId, DateTime? fchInicio, DateTime? fchFin, string? nombreEvento, int? puntajeMin, int? puntajeMax);
    }
}
