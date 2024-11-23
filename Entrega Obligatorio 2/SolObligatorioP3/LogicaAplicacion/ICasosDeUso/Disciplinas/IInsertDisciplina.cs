using Compartido.DTOs.Disciplinas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ICasosDeUso.Disciplinas
{
    public interface IInsertDisciplina
    {
        int Ejecutar(DisciplinaInsertDTO disciplinaInsertDTO);
    }
}
