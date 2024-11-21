using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOs.Paises
{
    public class PaisInsertDTO
    {
        public string Nombre { get; set; }
        public int Habitantes { get; set; }
        public string NombreDelegado { get; set; }
        public string TelDelegado { get; set; }
    }
}
