using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    [PrimaryKey(nameof(AtletaId), nameof(EventoId))]
    public class PuntajeEventoAtleta
    {
        public decimal Puntaje { get; set; }
        public int AtletaId { get; set; }
        public int EventoId { get; set; }

        [ForeignKey("AtletaId")]
        public Atleta Atleta { get; set; }
        public PuntajeEventoAtleta() { }
        public PuntajeEventoAtleta(Atleta atleta, decimal puntaje)
        {
            Atleta = atleta;
            Puntaje = puntaje;
        }
    }
}
