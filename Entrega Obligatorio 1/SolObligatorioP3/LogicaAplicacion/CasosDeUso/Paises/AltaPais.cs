using Compartido.DTOs.Paises;
using LogicaAccesoDatos;
using LogicaAplicacion.ICasosDeUso.Paises;
using LogicaNegocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.Paises
{
    public class AltaPais : IAltaPais
    {
        private readonly IRepositorioPais _repositorioPais;
        public AltaPais(IRepositorioPais repositorioPais)
        {
            _repositorioPais = repositorioPais;
        }

        public void Ejecutar(PaisInsertDTO paisInsertDTO)
        {
            throw new NotImplementedException();
        }
    }
}
