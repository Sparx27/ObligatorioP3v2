using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ICasosDeUso.Atletas
{
    public interface IAgregarDisciplina
    {
        void Ejecutar(int id, int? idDisciplina);
    }
}
