using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class PuntajeEvenetoAtleta
    {
        public Atleta Atleta { get; set; }
        public decimal Puntaje { get; set; }
        public PuntajeEvenetoAtleta() { }
        public PuntajeEvenetoAtleta(Atleta atleta, decimal puntaje)
        {
            Atleta = atleta;
            Puntaje = puntaje;
        }
    }
}
