using MVC.Models.Atleta;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models.Evento
{
    public class EventoInsertVM
    {
        public int DisciplinaId { get; set; } 

        [Required(ErrorMessage = "El Nombre no puede estar vacío")]
        [DisplayName("Nombre de la Prueba")]
        public string NombrePrueba { get; set; }

        [Required(ErrorMessage = "La fecha de inicio es requerida")]
        [DisplayName("Fecha Inicio")]
        [DataType(DataType.Date)]
        public DateTime FchInicio { get; set; } = DateTime.Now;

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "La fecha de finalización es requerida")]
        [DisplayName("Fecha Finalización")]
        public DateTime FchFin { get; set; } = DateTime.Now;
        public int[] ? AtletasId { get; set; } 
        public IEnumerable<AtletaListaVM> Atletas { get; set; }
    }
}
