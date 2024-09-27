using Compartido.DTOs.Usuarios;
using LogicaAplicacion.ICasosDeUso.Usuarios;
using LogicaAplicacion.Validadores;
using LogicaNegocio.Entidades;
using LogicaNegocio.IRepositorios;
using LogicaNegocio.ExcepcionesEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compartido.Mappers;
using LogicaNegocio.ValueObjects.Usuario;
using LogicaNegocio.Enums;

namespace LogicaAplicacion.CasosDeUso.Usuarios
{
    public class UpdateUsuario : IUpdateUsuario
    {
        private readonly IRepositorioUsuario _repositorioUsuario;
        public UpdateUsuario(IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }

        public UsuarioUpdateDTO Ejecutar(int id, UsuarioUpdateDTO usuarioUpdateDTO)
        {
            var (email, nombre) =
                (usuarioUpdateDTO.Email, usuarioUpdateDTO.Nombre);

            ValidarUsuario.Email(email);
            ValidarUsuario.Nombre(nombre);

            Usuario actualizarUsuario = _repositorioUsuario.GetById(id);
            if (actualizarUsuario == null)
            {
                throw new UsuarioException("No se encontró el usuario que intenta actualizar");
            }

            actualizarUsuario.Email = new RUsuarioEmail(email);
            actualizarUsuario.Nombre = nombre;

            _repositorioUsuario.Update(actualizarUsuario);
            return UsuarioMapper.UsuarioToUpdateDTO(actualizarUsuario);

        }

        public UsuarioUpdateDTO Ejecutar(int id, string contrasena)
        {
            ValidarUsuario.Contrasena(contrasena);

            Usuario actualizarUsuario = _repositorioUsuario.GetById(id);
            if (actualizarUsuario == null)
            {
                throw new UsuarioException("No se encontró el usuario que intenta actualizar");
            }

            actualizarUsuario.Contrasena = new RUsuarioContrasena(contrasena);

            _repositorioUsuario.Update(actualizarUsuario);
            return UsuarioMapper.UsuarioToUpdateDTO(actualizarUsuario);
        }

        public UsuarioUpdateDTO Ejecutar(int id, string contrasena, string contrasenaAnterior)
        {
            ValidarUsuario.Contrasena(contrasena);

            Usuario actualizarUsuario = _repositorioUsuario.GetById(id);
            if (actualizarUsuario == null)
            {
                throw new UsuarioException("No se encontró el usuario que intenta actualizar");
            }

            if(contrasenaAnterior != actualizarUsuario.Contrasena.Valor)
            {
                throw new UsuarioException("La contraseña actual que ingresó es incorrecta");
            }

            if(contrasenaAnterior == contrasena)
            {
                throw new UsuarioException("La nueva contraseña que intenta ingresar es igual a la actual");
            }

            actualizarUsuario.Contrasena = new RUsuarioContrasena(contrasena);

            _repositorioUsuario.Update(actualizarUsuario);
            return UsuarioMapper.UsuarioToUpdateDTO(actualizarUsuario);
        }
    }
}
