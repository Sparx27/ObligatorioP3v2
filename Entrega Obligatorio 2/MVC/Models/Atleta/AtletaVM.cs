
using MVC.Models.Disciplina;
using System.ComponentModel;

namespace MVC.Models.Atleta
{
    public class AtletaVM
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Sexo { get; set; }
        [DisplayName("Nombre del país")]
        public string NombrePais { get; set; }
        [DisplayName("Lista de disciplinas")]
        public IEnumerable<DisciplinaVM> DisciplinasAtleta { get; set; }
    }
}
