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
    public class AltaDisciplina : IAltaDisciplina
    {
        private IRepositorioDisciplina _repositorioDisciplina;
        public AltaDisciplina(IRepositorioDisciplina repositorioDisciplina)
        {
            _repositorioDisciplina = repositorioDisciplina;
        }

        public void Ejecutar(DisciplinaInsertDTO disciplinaInsertDTO) =>
            _repositorioDisciplina.Add(DisciplinaMapper.InsertDTOToDisciplina(disciplinaInsertDTO));

    }
}
