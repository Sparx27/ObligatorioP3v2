using Compartido.DTOs.Disciplinas;
using LogicaNegocio.Entidades;
using LogicaNegocio.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOs.Atletas
{
    public class AtletaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Sexo { get; set; }
        public string NombrePais { get; set; }
        public IEnumerable<DisciplinaListaDTO> DisciplinasAtleta { get; set; }
    }
}
