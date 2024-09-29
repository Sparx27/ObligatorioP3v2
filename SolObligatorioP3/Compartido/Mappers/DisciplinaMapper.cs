using Compartido.DTOs.Disciplinas;
using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.Mappers
{
    public static class DisciplinaMapper
    {
        public static IEnumerable<DisciplinaListaDTO> DisciplinasToListaDTO(List<Disciplina> disciplinas)
        {
            IEnumerable<DisciplinaListaDTO> disciplinasListaDTO = disciplinas.Select(d => new DisciplinaListaDTO
            {
                Id = d.Id,
                Nombre = d.Nombre.Valor,
            });

            return disciplinasListaDTO;
        }

    }
}
