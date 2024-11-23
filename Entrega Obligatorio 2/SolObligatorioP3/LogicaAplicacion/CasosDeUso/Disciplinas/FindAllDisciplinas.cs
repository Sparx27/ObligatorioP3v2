using Compartido.DTOs.Disciplinas;
using Compartido.Mappers;
using LogicaAccesoDatos;
using LogicaAplicacion.ICasosDeUso.Disciplinas;
using LogicaNegocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.Disciplinas
{
    public class FindAllDisciplinas : IFindAllDisciplinas
    {
        private readonly IRepositorioDisciplina _repositorioDisciplina;
        public FindAllDisciplinas(IRepositorioDisciplina repositorioDisciplina)
        {
            _repositorioDisciplina = repositorioDisciplina;
        }

        public IEnumerable<DisciplinaDTO> Ejecutar() => DisciplinaMapper.DisciplinasToListaDTO(_repositorioDisciplina.GetAll());
    }
}
