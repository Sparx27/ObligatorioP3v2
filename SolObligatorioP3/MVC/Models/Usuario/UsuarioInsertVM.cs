using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models.Usuario
{
    public class UsuarioInsertVM
    {
        [Required(ErrorMessage = "El Email es requerido")]
        [RegularExpression(@"^[a-zA-Z0-9]+@[a-zA-Z0-9]+\.[a-zA-Z0-9]+$",
            ErrorMessage = "El formato del email no es correcto")]
        [MaxLength(255, ErrorMessage = "El email puede contener hasta 255 caracteres")]
        public string? Email { get; set; }

        [DisplayName("Contraseña")]
        [Required(ErrorMessage = "La contraseña es requerida")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[\.;,!]).{6,}$",
            ErrorMessage = "La contraseña debe contener al menos 6 caracteres y al menos una mayúscula, minúscula, dígito y [. ; , !]")]
        public string? Contrasena { get; set; }

        [DisplayName("Rol de usuario")]
        [Required(ErrorMessage = "El Rol es requerido")]
        public int RolUsuario { get; set; }

        [MaxLength(50, ErrorMessage = "El Nombre puede contener hasta 50 caracteres")]
        public string? Nombre { get; set; }
    }
}
