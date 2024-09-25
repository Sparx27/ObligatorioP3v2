﻿using System;
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
        public string Valor { get; set; }

        public RDisciplinaNombre(string valor)
        {
            Valor = valor;
            Validar();
        }

        public void Validar()
        {
        }

    }
}
