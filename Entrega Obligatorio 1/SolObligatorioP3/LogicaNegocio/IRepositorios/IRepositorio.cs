using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.IRepositorios
{
    public interface IRepositorio<T>
    {
        List<T> GetAll();
        T? GetById(int id);
        void Add(T item);
        void Update(T item);
        void Delete(T item);
    }
}
