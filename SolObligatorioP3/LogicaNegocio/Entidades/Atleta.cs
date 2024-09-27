using LogicaNegocio.Enums;
using LogicaNegocio.IEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class Atleta : IEquatable<Atleta>, IEntity
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Sexo Sexo { get; set; }
        public List<Disciplina> LiDisciplinas { get; set; }

        public Atleta() { }
        public Atleta(int id, string nombre, Sexo sexo)
        {
            Id = id;
            Nombre = nombre;
            Sexo = sexo;
        }

        public bool Equals(Atleta? other)
        {
            return Nombre == other?.Nombre;
        }
    }
}
