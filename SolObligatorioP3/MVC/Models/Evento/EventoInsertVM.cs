using MVC.Models.Atleta;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models.Evento
{
    public class EventoInsertVM
    {
        public int DisciplinaId { get; set; } // puede ser tambien: public Disciplina Disciplina { get; set; }
                                              // depende de como se haga

        [Required(ErrorMessage = "El Nombre no puede estar vacío")]
        [DisplayName("Nombre de la Prueba")]
        public string NombrePrueba { get; set; }

        [Required(ErrorMessage = "La fecha de inicio es requerida")]
        [DisplayName("Fecha Inicio")]
        [DataType(DataType.Date)]
        public DateTime FchInicio { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "La fecha de finalización es requerida")]
        [DisplayName("Fecha Finalización")]
        public DateTime FchFin { get; set; }
        public int[] ? AtletasId { get; set; } 
        public IEnumerable<AtletaListaVM> Atletas { get; set; }
    }
}
