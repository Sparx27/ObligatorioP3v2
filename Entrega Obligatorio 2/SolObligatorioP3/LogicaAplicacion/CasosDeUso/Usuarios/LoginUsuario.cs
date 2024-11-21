using LogicaAccesoDatos;
using LogicaNegocio.Entidades;
using LogicaNegocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.Entidades;
using LogicaAplicacion.ICasosDeUso.Usuarios;
using Compartido.DTOs.Usuarios;
using Compartido.Mappers;
using LogicaNegocio.ExcepcionesEntidades;

namespace LogicaAplicacion.CasosDeUso.Usuarios
{
    public class LoginUsuario : ILoginUsuario
    {
        private readonly IRepositorioUsuario _repositorioUsuario;
        public LoginUsuario(IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }

        public UsuarioDTO Ejecutar(string email, string password)
        {
            Usuario resBD = _repositorioUsuario.LoginUsuario(email, password)
                ?? throw new UsuarioException("Usuario o contraseña incorrectos");

            return UsuarioMapper.UsuarioToDTO(resBD);
        }
    }
}
