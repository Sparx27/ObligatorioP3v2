using Compartido.DTOs.Atletas;
using Compartido.Mappers;
using LogicaAplicacion.ICasosDeUso.Atletas;
using LogicaNegocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.Atletas
{
    public class FindAllAtletas : IFindAllAtletas
    {
        private readonly IRepositorioAtleta _repositorioAtleta;
        public FindAllAtletas(IRepositorioAtleta repositorioAtleta)
        {
            _repositorioAtleta = repositorioAtleta;
        }

        public IEnumerable<AtletaListaDTO> Ejectuar()
        {
            return AtletaMapper.AtletasToListaDTO(_repositorioAtleta.GetAll());
        }
    }
}
