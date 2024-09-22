using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ExcepcionesEntidades
{
    public class Evento : Exception
    {
        public Evento() { }
        public Evento(string message) : base(message) { }
        public Evento(string message, Exception innerException) : base(message, innerException) { }
    }
}
