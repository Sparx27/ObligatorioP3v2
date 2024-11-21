using Compartido.DTOs.Atletas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOs.Eventos
{
    public class PuntajeEventoAtletaDTO
    {
        public AtletaDTO Atleta { get; set; }
        public decimal Puntaje { get; set; }
    }
}
