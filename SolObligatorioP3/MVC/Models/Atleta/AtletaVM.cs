using Compartido.DTOs.Disciplinas;
using MVC.Models.Disciplina;

namespace MVC.Models.Atleta
{
    public class AtletaVM
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Sexo { get; set; }
        public string NombrePais { get; set; }
        public IEnumerable<DisciplinaListaVM> DisciplinasAtleta { get; set; }
    }
}
