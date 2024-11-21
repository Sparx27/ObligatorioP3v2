
using System.ComponentModel;

namespace MVC.Models.Usuario
{
    public class UsuarioVM
    {
        [DisplayName("ID")]
        public int Id { get; set; }
        public string Email { get; set; }
        [DisplayName("Rol")]
        public string RolUsuario { get; set; }
        public string? Nombre { get; set; }
        [DisplayName("Fecha de registro")]
        public string FechaRegistro { get; set; }
    }
}
