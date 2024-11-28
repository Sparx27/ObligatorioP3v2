using System.ComponentModel;

namespace MVC.Models.Disciplina
{
    public class DisciplinaVM
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        [DisplayName("Año integración")]
        public int AnioIntegracion { get; set; }
    }
}
