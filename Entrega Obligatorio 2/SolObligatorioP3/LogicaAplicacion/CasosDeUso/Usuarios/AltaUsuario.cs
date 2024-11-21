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
        private readonly IRepositorioUsuario _repositorioUsuario;
        public AltaUsuario(IRepositorioUsuario repoUsuario)
        {
            _repositorioUsuario = repoUsuario;
        }

        public void Ejecutar(UsuarioInsertDTO usuarioInsertDTO)
        {
            if (usuarioInsertDTO == null)
            {
                throw new UsuarioException("El usuario no puede ser vacío");
            }

            Usuario? buscarSiExiste = _repositorioUsuario.GetByEmail(usuarioInsertDTO.Email);
            if (buscarSiExiste != null)
            {
                throw new ConflictException("Ya se registró un usuario con ese email");
            }

            // Validaciones
            var (email, contrasena, rol, nombre) =
                (usuarioInsertDTO.Email, usuarioInsertDTO.Contrasena, usuarioInsertDTO.RolUsuario, usuarioInsertDTO.Nombre);

            ValidarUsuario.Email(email);
            ValidarUsuario.Contrasena(contrasena);
            ValidarUsuario.Rol(rol);
            ValidarUsuario.Nombre(nombre);

            _repositorioUsuario.Add(UsuarioMapper.InsertDTOToUsuario(usuarioInsertDTO));
        }
    }
}
