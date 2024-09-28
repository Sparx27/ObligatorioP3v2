using LogicaNegocio.IEntidades;
using LogicaNegocio.ValueObjects.Disciplina;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class Disciplina : IEntity, IEquatable<Disciplina>
    {
        public int Id { get; set; }
        public RDisciplinaNombre Nombre { get; set; }
        public int AnioIntegracion { get; set; }
        //Consulta el tema del código que habla la letra, en primera instancia habla de guardar un numero que identifica a la disciplina
        //Luego en los RF habla de un código que no debe ser vacio ni que se repita

        public List<Atleta> LiAtletas { get; set; }

        public Disciplina() { }
        public Disciplina(int id, string nombre, int anioIntegracion)
        {
            Id = id;
            Nombre = new RDisciplinaNombre(nombre);
            AnioIntegracion = anioIntegracion;
        }

        public bool Equals(Disciplina? other)
        {
            return Nombre == other?.Nombre;
        }
    }
}
