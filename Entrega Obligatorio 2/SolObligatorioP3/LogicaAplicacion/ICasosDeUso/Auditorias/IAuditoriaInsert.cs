using Compartido.DTOs.Auditorias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ICasosDeUso.Auditorias
{
    public interface IAuditoriaInsert
    {
        void Ejecutar(AuditoriaInsertDTO dto);
    }
}
