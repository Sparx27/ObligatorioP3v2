using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOs.Eventos
{
    public class AtletaEventoListaDTO
    {
        public int Id { get; set; }
        public string NombrePrueba { get; set; }
        public string NombreDisciplina { get; set; }
        public DateTime FchInicio { get; set; }
        public DateTime FchFin { get; set; }
    }
}
