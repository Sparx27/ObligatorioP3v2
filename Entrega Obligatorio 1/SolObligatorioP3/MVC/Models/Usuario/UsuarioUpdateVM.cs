using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MVC.Models.Usuario
{
    public class UsuarioUpdateVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El Email es requerido")]
        [RegularExpression(@"^[a-zA-Z0-9]+@[a-zA-Z0-9]+\.[a-zA-Z0-9]+$",
            ErrorMessage = "El formato del email no es correcto")]
        [MaxLength(255, ErrorMessage = "El email puede contener hasta 255 caracteres")]
        public string Email { get; set; }

        [MaxLength(50, ErrorMessage = "El Nombre puede contener hasta 50 caracteres")]
        public string? Nombre { get; set; }
    }
}
