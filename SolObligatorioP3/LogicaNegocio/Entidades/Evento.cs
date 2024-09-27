using LogicaNegocio.IEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class Evento : IEntity, IEquatable<Evento>
    {
        public int Id { get; set; }
        public Disciplina Disciplina { get; set; }
        public string NombrePrueba { get; set; }
        public DateTime FchInicio { get; set; }
        public DateTime FchFin { get; set; }
        public List<PuntajeEvenetoAtleta> LiPuntajes { get; set; }

        public Evento() { }
        public Evento(int id, Disciplina disciplina, string nombrePrueba, DateTime fchInicio, DateTime fchFin)
        {
            Id = id;
            Disciplina = disciplina;
            NombrePrueba = nombrePrueba;
            FchInicio = fchInicio;
            FchFin = fchFin;
        }

        public bool Equals(Evento? other)
        {
            return Disciplina.Equals(other?.Disciplina) && NombrePrueba == other?.NombrePrueba;
        }
    }
}
