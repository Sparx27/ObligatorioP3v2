using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ExcepcionesEntidades
{
    public class PaisException : Exception
    {
        public PaisException() { }
        public PaisException(string message) : base(message) { }
        public PaisException(string message, Exception innerException) : base(message, innerException) { }
    }
}
