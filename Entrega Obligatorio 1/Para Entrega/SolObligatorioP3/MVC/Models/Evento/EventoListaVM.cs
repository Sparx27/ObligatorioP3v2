using MVC.Models.Atleta;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MVC.Models.Evento
{
    public class EventoListaVM
    {
        public int EventoId { get; set; }
        [DisplayName("Nombre de la Prueba")]
        public string NombrePrueba { get; set; }

        [DisplayName("Fecha Inicio")]
        [DataType(DataType.Date)]
        public DateTime FchInicio { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Fecha Finalización")]
        public DateTime FchFin { get; set; }
    }
}
