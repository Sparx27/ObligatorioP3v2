using LogicaNegocio.Entidades;
using LogicaNegocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioAuditoria:IRepositorioAuditoria
    {
        private readonly JuegosOlimpicosDBContext _context;
        public RepositorioAuditoria(JuegosOlimpicosDBContext context)
        {
            _context = context;
        }

        public void Add(Auditoria item)
        {
            _context.Add(item);
            _context.SaveChanges();
        }

        public void Delete(Auditoria item)
        {
            throw new NotImplementedException();
        }

        public List<Auditoria> GetAll()
        {
            throw new NotImplementedException();
        }

        public Auditoria? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Auditoria item)
        {
            throw new NotImplementedException();
        }
    }
}
