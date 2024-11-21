using LogicaNegocio.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOs.Usuarios
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string RolUsuario { get; set; }
        public string? Nombre { get; set; }
        public string FechaRegistro { get; set; }
    }
}
