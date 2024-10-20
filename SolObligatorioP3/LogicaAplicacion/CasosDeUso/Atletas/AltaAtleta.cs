using Compartido.DTOs.Atletas;
using LogicaAccesoDatos;
using LogicaAplicacion.ICasosDeUso.Atletas;
using LogicaNegocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.Atletas
{
    public class AltaAtleta : IAltaAtleta
    {
        private readonly IRepositorioAtleta _repositorioAtleta;
        public AltaAtleta(IRepositorioAtleta repositorioAtleta)
        {
            _repositorioAtleta = repositorioAtleta;
        }

        public void Ejecutar(AtletaInsertDTO atletaInsertDTO)
        {
            throw new NotImplementedException();
        }
    }
}
