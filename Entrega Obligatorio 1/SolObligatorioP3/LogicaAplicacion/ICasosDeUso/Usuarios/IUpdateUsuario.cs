using Compartido.DTOs.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ICasosDeUso.Usuarios
{
    public interface IUpdateUsuario
    {
        UsuarioUpdateDTO Ejecutar(int id, UsuarioUpdateDTO usuarioUpdateDTO);
        UsuarioUpdateDTO Ejecutar(int id, string contrasena, string contrasenaAnterior);
        UsuarioUpdateDTO Ejecutar(int id, string contrasena);
    }
}
