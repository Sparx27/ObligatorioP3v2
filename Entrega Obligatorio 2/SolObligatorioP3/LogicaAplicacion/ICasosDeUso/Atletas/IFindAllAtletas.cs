using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compartido.DTOs.Atletas;

namespace LogicaAplicacion.ICasosDeUso.Atletas
{
    public interface IFindAllAtletas
    {
        IEnumerable<AtletaListaDTO> Ejectuar();
    }
}
