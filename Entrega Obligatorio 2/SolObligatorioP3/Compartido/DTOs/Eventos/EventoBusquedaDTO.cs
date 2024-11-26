using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOs.Eventos
{
    public class EventoBusquedaDTO
    {
        public int? DisciplinaId { get; set; }
        public DateTime? FchInicio { get; set; }
        public DateTime? FchFin { get; set; }
        public string? NombreEvento { get; set; }
        public int? PuntajeMin { get; set; }
        public int? PuntajeMax { get; set; }
    }
}
