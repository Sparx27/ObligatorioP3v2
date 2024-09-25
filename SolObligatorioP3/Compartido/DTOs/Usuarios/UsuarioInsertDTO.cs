using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOs.Usuarios
{
    public class UsuarioInsertDTO
    {
        public string Email { get; set; }
        public string Contrasena { get; set; }
        public int RolUsuario { get; set; }
        public int IdAdminRegistro { get; set; }
        public string? Nombre { get; set; }
    }
}
