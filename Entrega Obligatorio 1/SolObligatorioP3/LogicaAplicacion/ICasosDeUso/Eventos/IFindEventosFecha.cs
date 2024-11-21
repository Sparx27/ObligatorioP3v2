using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compartido.DTOs.Eventos;

namespace LogicaAplicacion.ICasosDeUso.Eventos
{
    public interface IFindEventosFecha
    {
        IEnumerable<EventoListaDTO> Ejecutar(DateTime fecha);
    }
}
