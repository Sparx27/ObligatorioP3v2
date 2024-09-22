namespace MVC.Models.Evento
{
    public class EventoInsertVM
    {
        public int DisciplinaId { get; set; } // puede ser tambien: public Disciplina Disciplina { get; set; }
                                              // depende de como se haga
        public string NombrePrueba { get; set; }
        public DateTime FchInicio { get; set; }
        public DateTime FchFin { get; set; }
    }
}
