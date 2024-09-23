using LogicaAplicacion.ICasosDeUso.Usuarios;
using LogicaNegocio.Entidades;
using LogicaNegocio.IRepositorios;
using LogicaNegocio.ExcepcionesEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.Usuarios
{
    public class DeleteUsuario : IDeleteUsuario
    {
        private readonly IRepositorioUsuario _repositorioUsuario;
        public DeleteUsuario(IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }

        public void Ejecutar(int id)
        {
            Usuario resDB = _repositorioUsuario.GetById(id);
            if(resDB == null)
            {
                throw new UsuarioException("Usuario no encontrado por ese ID");
            }
            _repositorioUsuario.Delete(resDB);
        }
    }
}
