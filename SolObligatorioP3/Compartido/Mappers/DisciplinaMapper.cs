using Compartido.DTOs.Disciplinas;
using LogicaNegocio.Entidades;
using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.ValueObjects.Disciplina;
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

        public static Disciplina InsertDTOToDisciplina(DisciplinaInsertDTO disciplinaInsertDTO)
        {
            if(disciplinaInsertDTO == null)
            {
                throw new DisciplinaException("Discplina insert vacia en mapper");
            }

            Disciplina res = new Disciplina
            {
                Nombre = new RDisciplinaNombre(disciplinaInsertDTO.Nombre),
                AnioIntegracion = disciplinaInsertDTO.AnioIntegracion,
            };

            return res;
        }

    }
}
