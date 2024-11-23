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
    public class DisciplinaSelectById: IDisciplinaSelectById
    {
        private readonly IRepositorioDisciplina _repositorioDisciplina;
        public DisciplinaSelectById(IRepositorioDisciplina repositorioDisciplina)
        {
            _repositorioDisciplina = repositorioDisciplina;
        }

        public DisciplinaDTO? Ejecutar(int id)
        {
            if (id <= 0) throw new DisciplinaException("Id Incorrecto");
            Disciplina? res = _repositorioDisciplina.GetById(id);
            return res == null ? null : new DisciplinaDTO
            {
                Id = id,
                AnioIntegracion = res.AnioIntegracion,
                Nombre = res.Nombre.Valor
            };
        }
    }
}
