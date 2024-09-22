using Compartido.DTOs.Usuarios;
using Compartido.Mappers;
using LogicaAplicacion.ICasosDeUso.Usuarios;
using LogicaNegocio.Entidades;
using LogicaNegocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.Usuarios
{
    public class FindAllUsuarios : IFindAllUsuarios
    {
        private IRepositorioUsuario _repoUsuario;
        public FindAllUsuarios(IRepositorioUsuario repoUsuario)
        {
            _repoUsuario = repoUsuario;
        }

        public IEnumerable<UsuarioDTO> Ejecutar()
        {
            List<Usuario> usuarios = _repoUsuario.GetAll();
            return UsuarioMapper.ListaUsuariosToDTOListaUsuarios(usuarios);
        }
    }
}
