using LogicaNegocio.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Models.Atleta
{
    public class AtletaListaVM
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Sexo { get; set; }
        public string NombrePais { get; set; }
    }
}
