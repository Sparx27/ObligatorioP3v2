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
        [DataType(DataType.Date)]
        public DateTime FchInicio { get; set; }

        [DisplayName("Fecha de finalización")]
        [DataType(DataType.Date)]
        public DateTime FchFin { get; set; }
        [Required(ErrorMessage = "Los puntajes son requeridos")]
        public List<PuntajeEventoAtletaVM> LiPuntajes { get; set; }
    }
}
