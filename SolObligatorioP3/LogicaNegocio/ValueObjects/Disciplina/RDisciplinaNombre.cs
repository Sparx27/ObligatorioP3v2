using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ValueObjects.Disciplina
{
    [ComplexType]
    public record RDisciplinaNombre
    {
        [Required]
        [StringLength(50, MinimumLength = 10)]
        public string Valor { get; init; }

        public RDisciplinaNombre(string valor)
        {
            Valor = valor;
        }
    }
}
