using LogicaNegocio.ValueObjects.Disciplina;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOs.Disciplinas
{
    public class DisciplinaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int AnioIntegracion { get; set; }
    }
}
