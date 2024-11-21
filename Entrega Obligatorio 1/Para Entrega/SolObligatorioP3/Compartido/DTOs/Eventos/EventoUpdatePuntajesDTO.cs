using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOs.Eventos
{
    public class EventoUpdatePuntajesDTO
    {
        public int Id { get; set; }
        public IEnumerable<PEAUpdateDTO> LiAtletas { get; set; }
    }
}
