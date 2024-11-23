using LogicaNegocio.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOs.Auditorias
{
    public class AuditoriaInsertDTO
    {
        public Accion Accion { get; set; }  
        public string Entidad { get; set; }
        public int EntidadId { get; set; }
        public string EmailUsuario { get; set; }
    }
}
