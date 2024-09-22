﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ValueObjects.Usuario
{
    [ComplexType]
    public record RUsuarioEmail
    {
        [Required]
        [MaxLength(255)]
        public string Valor { get; set; }
        public RUsuarioEmail(string valor)
        {
            Valor = valor;
            Validar();
        }
        private void Validar()
        {
            Console.WriteLine("Validar Usuario Email");
        }
    }
}
