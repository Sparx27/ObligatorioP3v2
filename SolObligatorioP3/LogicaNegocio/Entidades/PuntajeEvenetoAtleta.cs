using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    [PrimaryKey(nameof(AtletaId), nameof(EventoId))]
    public class PuntajeEvenetoAtleta
    {
        public decimal Puntaje { get; set; }
        public int AtletaId { get; set; }
        public int EventoId { get; set; }

        public Atleta Atleta { get; set; }
        public PuntajeEvenetoAtleta() { }
        public PuntajeEvenetoAtleta(Atleta atleta, decimal puntaje)
        {
            Atleta = atleta;
            Puntaje = puntaje;
        }
    }
}
