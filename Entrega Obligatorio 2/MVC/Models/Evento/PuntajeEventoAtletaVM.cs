
using MVC.Models.Atleta;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models.Evento
{
    public class PuntajeEventoAtletaVM
    {
        public AtletaVM Atleta { get; set; }

        public decimal Puntaje { get; set; }
    }
}
