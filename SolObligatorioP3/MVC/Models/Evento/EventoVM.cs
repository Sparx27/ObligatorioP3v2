using Compartido.DTOs.Eventos;

namespace MVC.Models.Evento
{
    public class EventoVM
    {
        public int Id { get; set; }
        public string NombrePrueba { get; set; }
        public DateTime FchInicio { get; set; }
        public DateTime FchFin { get; set; }

    }
}
