using Compartido.DTOs.Usuarios;
using Compartido.Mappers;
using LogicaAccesoDatos;
using LogicaAplicacion.ICasosDeUso.Usuarios;
using LogicaAplicacion.Validadores;
using LogicaNegocio.Entidades;
using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.Usuarios
{
    public partial class AltaUsuario : IAltaUsuario
    {
        private IRepositorioUsuario _repoUsuario;
        public AltaUsuario(IRepositorioUsuario repoUsuario)
        {
            _repoUsuario = repoUsuario;
        }

        public void Ejecutar(UsuarioInsertDTO usuarioInsertDTO)
        {
            if (usuarioInsertDTO == null)
            {
                throw new UsuarioException("El usuario no puede ser vacío");
            }

            Usuario? buscarSiExiste = _repoUsuario.GetByEmail(usuarioInsertDTO.Email);
            if (buscarSiExiste != null)
            {
                throw new UsuarioException("Ya se registró un usuario con ese email");
            }

            // Validaciones
            var (email, contrasena, rol, nombre) =
                (usuarioInsertDTO.Email, usuarioInsertDTO.Contrasena, usuarioInsertDTO.RolUsuario, usuarioInsertDTO.Nombre);

            ValidarUsuario.Email(email);
            ValidarUsuario.Contrasena(contrasena);
            ValidarUsuario.Rol(rol);
            ValidarUsuario.Nombre(nombre);

            _repoUsuario.Add(UsuarioMapper.InsertDTOToUsuario(usuarioInsertDTO));
        }
    }
}
