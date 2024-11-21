using System.ComponentModel;

namespace MVC.Models.Disciplina
{
    public class DisciplinaListaVM
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        [DisplayName("Año integración")]
        public int AnioIntegracion { get; set; }
    }
}
