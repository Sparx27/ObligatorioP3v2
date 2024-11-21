using Compartido.DTOs.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ICasosDeUso.Usuarios
{
    public interface IFindAllUsuarios
    {
        IEnumerable<UsuarioDTO> Ejecutar();
    }
}
