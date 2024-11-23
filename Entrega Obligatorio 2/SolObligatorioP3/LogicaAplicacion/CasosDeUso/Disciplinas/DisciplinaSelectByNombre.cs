using Compartido.DTOs.Disciplinas;
using LogicaAplicacion.ICasosDeUso.Disciplinas;
using LogicaNegocio.Entidades;
using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.Disciplinas
{
    public class DisciplinaSelectByNombre : IDisciplinaSelectByNombre
    {
        private readonly IRepositorioDisciplina _repositorioDisciplina;
        public DisciplinaSelectByNombre(IRepositorioDisciplina repositorioDisciplina)
        {
            _repositorioDisciplina = repositorioDisciplina;
        }

        public DisciplinaDTO? Ejecutar(string nombre)
        {
            if (string.IsNullOrEmpty(nombre)) throw new DisciplinaException("Se requieren un Nombre");

            Disciplina? res = _repositorioDisciplina.GetByNombre(nombre);
            return res == null ? null : new DisciplinaDTO
            {
                Id = res.Id,
                AnioIntegracion = res.AnioIntegracion,
                Nombre = nombre
            };
        }
    }
}
