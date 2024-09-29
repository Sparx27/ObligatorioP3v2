using LogicaNegocio.Enums;
using LogicaNegocio.IEntidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class Atleta : IEquatable<Atleta>, IEntity
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public Sexo Sexo { get; set; }
        public Pais Pais { get; set; }

        [ForeignKey("Pais")]
        public int PaisId { get; set; }
        
        public List<Disciplina> LiDisciplinas { get; set; }

        public Atleta() { }
        public Atleta(int id, string nombre,string apellido, Sexo sexo, Pais pais)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Sexo = sexo;
            Pais = pais;
        }

        public bool Equals(Atleta? other)
        {
            return Nombre == other?.Nombre;
        }
    }
}
