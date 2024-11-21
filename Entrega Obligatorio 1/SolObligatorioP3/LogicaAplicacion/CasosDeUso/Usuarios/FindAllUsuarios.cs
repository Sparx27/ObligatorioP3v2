using Compartido.DTOs.Usuarios;
using Compartido.Mappers;
using LogicaAplicacion.ICasosDeUso.Usuarios;
using LogicaNegocio.Entidades;
using LogicaNegocio.IRepositorios;

namespace LogicaAplicacion.CasosDeUso.Usuarios
{
    public class FindAllUsuarios : IFindAllUsuarios
    {
        private readonly IRepositorioUsuario _repositorioUsuario;
        public FindAllUsuarios(IRepositorioUsuario repoUsuario)
        {
            _repositorioUsuario = repoUsuario;
        }

        public IEnumerable<UsuarioDTO> Ejecutar()
        {
            List<Usuario> usuarios = _repositorioUsuario.GetAll();
            return UsuarioMapper.ListaUsuariosToDTOListaUsuarios(usuarios);
        }
    }
}
