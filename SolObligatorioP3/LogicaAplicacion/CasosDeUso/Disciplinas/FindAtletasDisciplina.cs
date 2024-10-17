using Compartido.DTOs.Atletas;
using Compartido.Mappers;
using LogicaAplicacion.ICasosDeUso.Disciplinas;
using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.Disciplinas
{
    public class FindAtletasDisciplina : IFindAtletasDisciplina
    {
        private IRepositorioDisciplina _repositorioDisciplina;

        public FindAtletasDisciplina(IRepositorioDisciplina repositorioDisciplina)
        {
            _repositorioDisciplina = repositorioDisciplina;
        }

        public IEnumerable<AtletaListaDTO> Ejecutar(int idDisciplina)
        {
            if(idDisciplina == 0)
            {
                throw new DisciplinaException("El id de la disciplina no es correcto");
            }

            return AtletaMapper.AtletasToListaDTO(_repositorioDisciplina.GetAtletasDisciplina(idDisciplina));
        }
    }
}
