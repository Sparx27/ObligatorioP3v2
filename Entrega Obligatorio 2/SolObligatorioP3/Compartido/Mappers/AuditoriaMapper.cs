using Compartido.DTOs.Auditorias;
using LogicaNegocio.Entidades;
using LogicaNegocio.Enums;
using LogicaNegocio.ExcepcionesEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.Mappers
{
    public static class AuditoriaMapper
    {
        public static Auditoria DtoInsertToAuditoria(AuditoriaInsertDTO dto)
        {
            if (dto == null) throw new AuditoriaException("DTO vacío en Auditoria mapper");

            return new Auditoria
            {
                Accion = dto.Accion,
                EmailUsuario = dto.EmailUsuario,
                Entidad = dto.Entidad,
                EntidadId = dto.EntidadId,
                Fecha = DateTime.Now
            };

        }
    }
}
