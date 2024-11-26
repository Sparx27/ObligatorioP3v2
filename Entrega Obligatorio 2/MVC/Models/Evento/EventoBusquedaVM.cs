using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MVC.Models.Evento
{
    public class EventoBusquedaVM
    {
        [DisplayName("Disciplina Id")]
        public int? DisciplinaId { get; set; }
        [DisplayName("Fecha Inicio")]
        [DataType(DataType.Date)]
        public DateTime? FchInicio { get; set; }
        [DisplayName("Fecha Final")]
        [DataType(DataType.Date)]
        public DateTime? FchFin { get; set; }
        public string? NombreEvento { get; set; }
        [DisplayName("Puntaje Mínimo")]
        public int? PuntajeMin { get; set; }
        [DisplayName("Puntaje Máximo")]
        public int? PuntajeMax { get; set; }
    }
}
