using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ExcepcionesEntidades
{
    public class DisciplinaException : Exception
    {
        public DisciplinaException() { }
        public DisciplinaException(string message) : base(message) { }
        public DisciplinaException(string message, Exception innerException) : base(message, innerException) { }
    }
}
