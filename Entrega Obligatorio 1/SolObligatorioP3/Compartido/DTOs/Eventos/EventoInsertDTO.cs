using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOs.Eventos
{
    public class EventoInsertDTO
    {
        public int DisciplinaId { get; set; }
        public string NombrePrueba { get; set; }
        public DateTime FchInicio { get; set; }
        public DateTime FchFin { get; set; }
        public int[]? AtletasId { get; set; }
    }
}
