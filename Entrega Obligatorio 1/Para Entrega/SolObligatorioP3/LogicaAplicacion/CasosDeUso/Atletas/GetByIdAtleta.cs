using Compartido.DTOs.Atletas;
using Compartido.Mappers;
using LogicaAplicacion.ICasosDeUso.Atletas;
using LogicaNegocio.Entidades;
using LogicaNegocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.Atletas
{
    public class GetByIdAtleta : IGetByIdAtleta
    {
        private readonly IRepositorioAtleta _repositorioAtleta;
        public GetByIdAtleta(IRepositorioAtleta repositorioAtleta)
        {
            _repositorioAtleta = repositorioAtleta;
        }

        public AtletaDTO Ejecutar(int id) => AtletaMapper.AtletaToDTO(_repositorioAtleta.GetById(id));
    }
}
