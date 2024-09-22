using Compartido.DTOs.Paises;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ICasosDeUso.Paises
{
    public interface IAltaPais
    {
        void Ejecutar(PaisInsertDTO paisInsertDTO);
    }
}
