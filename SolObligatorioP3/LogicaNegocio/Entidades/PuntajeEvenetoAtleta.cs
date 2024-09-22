using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class PuntajeEvenetoAtleta
    {
        public Evento Evento { get; set; }
        public Atleta Atleta { get; set; }
        public decimal Puntaje { get; set; }
        public PuntajeEvenetoAtleta() { }
        public PuntajeEvenetoAtleta(Evento evento, Atleta atleta, decimal puntaje)
        {
            Evento = evento;
            Atleta = atleta;
            Puntaje = puntaje;
        }
    }
}
