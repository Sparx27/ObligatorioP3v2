using Compartido.DTOs.Auditorias;
using Compartido.Mappers;
using LogicaAplicacion.ICasosDeUso.Auditorias;
using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.Auditorias
{
    public class AuditoriaInsert:IAuditoriaInsert
    {
        private readonly IRepositorioAuditoria _repositorioAuditoria;
        public AuditoriaInsert(IRepositorioAuditoria repositorioAuditoria)
        {
            _repositorioAuditoria = repositorioAuditoria;
        }

        public void Ejecutar(AuditoriaInsertDTO dto)
        {
            if (dto == null) throw new AuditoriaException("Error al registrar la auditoría");

            _repositorioAuditoria.Add(AuditoriaMapper.DtoInsertToAuditoria(dto));
        }
    }
}
