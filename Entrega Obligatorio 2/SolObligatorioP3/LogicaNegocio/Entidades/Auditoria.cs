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
    [Table("Auditorias")]
    public class Auditoria : IEntity
    {
        public int Id { get ; set; }
        public DateTime Fecha { get; set; }
        public Accion Accion {  get; set; }
        public string Entidad { get; set; }
        public int EntidadId { get; set; }
        public string EmailUsuario { get; set; }
    }
}
