using Compartido.DTOs.Usuarios;
using LogicaAplicacion.ICasosDeUso.Usuarios;
using LogicaNegocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.ExcepcionesEntidades;
using Compartido.Mappers;

namespace LogicaAplicacion.CasosDeUso.Usuarios
{
    public class GetByIdUsuario : IGetByIdUsuario
    {
        private IRepositorioUsuario _repositorioUsuario;
        public GetByIdUsuario(IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }
        public UsuarioDTO Ejecutar(int id)
        {
            LogicaNegocio.Entidades.Usuario? res = _repositorioUsuario.GetById(id);

            if(res == null)
            {
                throw new UsuarioException("Usuario no encontrado por ID");
            }

           
            return UsuarioMapper.UsuarioToDTO(res);
        }
    }
}
