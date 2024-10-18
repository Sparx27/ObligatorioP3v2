using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOs.Eventos
{
    public class EventoListaDTO
    {
        public int EventoId {  get; set; }
        public string NombrePrueba { get; set; }

        public DateTime FchInicio { get; set; }

        public DateTime FchFin { get; set; }
    }
}
