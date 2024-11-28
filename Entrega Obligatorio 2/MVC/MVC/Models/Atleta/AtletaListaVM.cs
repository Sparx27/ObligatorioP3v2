
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Models.Atleta
{
    public class AtletaListaVM
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        [DisplayName("Nombre Completo")]
        public string NombreCompleto { get; set; }
        public string Sexo { get; set; }

        [DisplayName("País")]
        public string NombrePais { get; set; }
    }
}
