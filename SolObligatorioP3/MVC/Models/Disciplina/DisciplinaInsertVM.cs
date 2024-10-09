using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models.Disciplina
{
    public class DisciplinaInsertVM
    {
        [DisplayName("Nombre de disciplina")]
        [Length(10,50,ErrorMessage = "El nombre de la disciplina debe tener entre 10 y 50 caracteres")]
        public string Nombre { get; set; }
        [DisplayName("Año de integración")]
        public int AnioIntegracion { get; set; }
    }
}
