using LogicaNegocio.Entidades;
using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        private JuegosOlimpicosDBContext _context;
        public RepositorioUsuario(JuegosOlimpicosDBContext context)
        {
            _context = context;
        }

        public void Add(Usuario item)
        {
            if (item == null)
            {
                throw new UsuarioException("El usuario no puede ser vacío");
            }
            _context.Add(item);
            _context.SaveChanges();
        }

        public void Delete(Usuario item)
        {
            _context.Remove(item);
            _context.SaveChanges();
        }

        public List<Usuario> GetAll()
        {
            return _context.Usuarios.ToList();
        }

        public Usuario? GetById(int id) => 
            _context.Usuarios.SingleOrDefault(usuario => usuario.Id == id);

        public Usuario? GetByEmail(string email) => 
            _context.Usuarios.SingleOrDefault(usuario => usuario.Email.Valor == email);

        public void Update(Usuario item)
        {
            _context.Usuarios.Update(item);
            _context.SaveChanges();
        }

        public Usuario? LoginUsuario(string email, string password) =>
            _context.Usuarios.SingleOrDefault(usuario => usuario.Email.Valor == email && usuario.Contrasena.Valor == password);
    }
}
