using Compartido.DTOs.Atletas;
using MVC.Models.Atleta;

namespace MVC.Models.Evento
{
    public class PuntajeEventoAtletaVM
    {
        public AtletaVM Atleta { get; set; }
        public decimal Puntaje { get; set; }
    }
}
