using Compartido.DTOs.Usuarios;
using LogicaNegocio.Entidades;
using LogicaNegocio.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.ValueObjects.Usuario;

namespace Compartido.Mappers
{
    public static class UsuarioMapper
    {
        public static UsuarioDTO UsuarioToDTO(Usuario usuario)
        {
            if(usuario == null)
            {
                throw new UsuarioException("Error en mapper: el Usuario ingresado está vacío");
            }
            return new UsuarioDTO
            {
                Id = usuario.Id,
                Email = usuario.Email.Valor,
                RolUsuario = usuario.RolUsuario.ToString(),
                Nombre = usuario.Nombre,
                FechaRegistro = usuario.FechaRegistro.ToString("dd/MM/yyyy")
        };
        }

        public static Usuario InsertDTOToUsuario(UsuarioInsertDTO usuarioInsertDto)
        {
            if(usuarioInsertDto == null)
            {
                throw new UsuarioException("Error en mapper: el Usuario insert está vacío");
            }
            return new Usuario
            {

                Email = new RUsuarioEmail(usuarioInsertDto.Email),
                Nombre = usuarioInsertDto.Nombre,
                Contrasena = new RUsuarioContrasena(usuarioInsertDto.Contrasena),
                RolUsuario =  usuarioInsertDto.RolUsuario == 0 ? Rol.Administrador : Rol.Digitador,
                IdAdminRegistro = usuarioInsertDto.IdAdminRegistro
                
            };
        }

        public static IEnumerable<UsuarioDTO> ListaUsuariosToDTOListaUsuarios(List<Usuario> usuarios)
        {
            IEnumerable<UsuarioDTO> usuariosDTOs = usuarios.Select(u => new UsuarioDTO()
            {
                Email = u.Email.Valor,
                Nombre = u.Nombre,
                Id = u.Id,
                RolUsuario = u.RolUsuario.ToString(),
                FechaRegistro = u.FechaRegistro.ToString("dd/MM/yyyy")
            });

            return usuariosDTOs;
        }

        public static UsuarioUpdateDTO UsuarioToUpdateDTO(Usuario usuario)
        {
            if (usuario == null)
            {
                throw new UsuarioException("Error en mapper: el Usuario está vacío");
            }
            return new UsuarioUpdateDTO
            {
                Email = usuario.Email.Valor,
                Nombre = usuario.Nombre
            };
        }
    }
}
