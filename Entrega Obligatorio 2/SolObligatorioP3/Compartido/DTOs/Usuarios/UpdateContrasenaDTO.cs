using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOs.Usuarios
{
    public class UpdateContrasenaDTO
    {
        public string ContrasenaNueva {  get; set; }
        public string ContrasenaAnterior { get; set; }
    }
}
