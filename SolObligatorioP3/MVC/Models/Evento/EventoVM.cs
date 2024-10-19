using Compartido.DTOs.Atletas;
using Compartido.DTOs.Eventos;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models.Evento
{
    public class EventoVM
    {
        public int Id { get; set; }

        [DisplayName("Nombre de la prueba")]
        public string NombrePrueba { get; set; }
        [DisplayName("Fecha de inicio")]
        public DateTime FchInicio { get; set; }
        [DisplayName("Fecha de finalización")]
        public DateTime FchFin { get; set; }
        public IEnumerable<PuntajeEventoAtletaVM> LiAtletas { get; set; }
    }
}
