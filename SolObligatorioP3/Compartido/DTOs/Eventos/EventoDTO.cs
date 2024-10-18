using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOs.Eventos
{
    public class EventoDTO
    {
        public int Id { get; set; }
        public string NombrePrueba { get; set; }
        public DateTime FchInicio { get; set; }
        public DateTime FchFin { get; set; }
    }
}
