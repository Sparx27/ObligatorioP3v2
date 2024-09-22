using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOs.Eventos
{
    public class EventoInsertDTO
    {
        public int DisciplinaId { get; set; } // puede ser tambien: public Disciplina Disciplina { get; set; }
                                              // depende de como se haga
        public string NombrePrueba { get; set; }
        public DateTime FchInicio { get; set; }
        public DateTime FchFin { get; set; }
    }
}
