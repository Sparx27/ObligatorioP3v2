using Compartido.DTOs.Atletas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ICasosDeUso.Disciplinas
{
    public interface IFindAtletasDisciplina
    {
        IEnumerable<AtletaListaDTO> Ejecutar(int idDisciplina);
    }
}
