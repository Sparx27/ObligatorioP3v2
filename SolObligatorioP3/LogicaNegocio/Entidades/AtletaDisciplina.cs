using LogicaNegocio.ExcepcionesEntidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    [PrimaryKey(nameof(AtletaId), nameof(DisciplinaId))]
    public class AtletaDisciplina
    {
        [ForeignKey("Atleta")]
        public int AtletaId { get; set; }
        [ForeignKey("Disciplina")]
        public int DisciplinaId { get; set; }
        public Atleta Atleta { get; set; }
        public Disciplina Disciplina { get; set; }

        public AtletaDisciplina() { }

        public AtletaDisciplina(int atletaId, Atleta atleta, int disciplinaId, Disciplina disciplina)
        {
            AtletaId = atletaId;
            Atleta = atleta;
            DisciplinaId = disciplinaId;
            Disciplina = disciplina;
        }
    }
}
