namespace MVC.Models.Evento
{
    public class EventoBusquedaYListaVM
    {
        public EventoBusquedaVM BusquedaVM { get; set; } = new EventoBusquedaVM();
        public IEnumerable<EventoListaVM>? ListaVM { get; set; }
    }
}
