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
        public static IEnumerable<DisciplinaDTO> DisciplinasToListaDTO(List<Disciplina> disciplinas)
        {
            IEnumerable<DisciplinaDTO> disciplinasListaDTO = disciplinas.Select(d => new DisciplinaDTO
            {
                Id = d.Id,
                Nombre = d.Nombre.Valor,
                AnioIntegracion = d.AnioIntegracion
            });

            return disciplinasListaDTO;
        }

        public static Disciplina InsertDTOToDisciplina(DisciplinaInsertDTO disciplinaInsertDTO)
        {
            if (disciplinaInsertDTO == null) throw new DisciplinaException("Discplina insert vacia en mapper");


            Disciplina res = new Disciplina
            {
                Nombre = new RDisciplinaNombre(disciplinaInsertDTO.Nombre),
                AnioIntegracion = disciplinaInsertDTO.AnioIntegracion,
            };

            return res;
        }
        public static Disciplina DTOToDisciplina(DisciplinaUpdateDTO dto)
        {
            if (dto == null) throw new DisciplinaException("Discplina update vacia en mapper");

            return new Disciplina
            {
                Id = dto.Id,
                Nombre = new RDisciplinaNombre(dto.Nombre),
                AnioIntegracion = dto.AnioIntegracion
            };
        }

        public static DisciplinaDTO DisciplinaToDTO(Disciplina disciplina)
        {
            if (disciplina == null) throw new DisciplinaException("Discplina vacia en mapper");

            return new DisciplinaDTO
            {
                Id = disciplina.Id,
                Nombre = disciplina.Nombre.Valor,
                AnioIntegracion = disciplina.AnioIntegracion
            };
        }
    }
}
