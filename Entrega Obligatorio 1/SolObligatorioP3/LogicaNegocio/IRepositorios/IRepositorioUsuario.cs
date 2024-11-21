using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.IRepositorios
{
    public interface IRepositorioUsuario : IRepositorio<Usuario>
    {
        Usuario? LoginUsuario(string email, string password);
        Usuario? GetByEmail(string email);
    }
}
