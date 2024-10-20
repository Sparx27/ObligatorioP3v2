using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.ValueObjects.Disciplina;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Validadores
{
    public static class ValidarDisciplina
    {
        public static void Nombre(string nombre)
        {
            if (nombre.Length < 10)
            {
                throw new DisciplinaException("El nombre de la disciplina debe contener al menos 10 caracteres");
            }
            if (nombre.Length > 50)
            {
                throw new DisciplinaException("El nombre de la disciplina puede contener hasta 50 caracteres");
            }
        }
    }
}
