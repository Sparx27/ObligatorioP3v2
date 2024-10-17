using LogicaNegocio.IEntidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class Evento : IEntity
    {
        public int Id { get; set; }
        
        public string NombrePrueba { get; set; }
        public int DisciplinaId { get; set; }
        public DateTime FchInicio { get; set; }
        public DateTime FchFin { get; set; }
        public List<PuntajeEvenetoAtleta> LiPuntajes { get; set; }

        [ForeignKey("DisciplinaId")]
        public Disciplina Disciplina { get; set; }

        public Evento() { }
        public Evento(int id, Disciplina disciplina, string nombrePrueba, DateTime fchInicio, DateTime fchFin)
        {
            Id = id;
            Disciplina = disciplina;
            NombrePrueba = nombrePrueba;
            FchInicio = fchInicio;
            FchFin = fchFin;
        }
    }
}
