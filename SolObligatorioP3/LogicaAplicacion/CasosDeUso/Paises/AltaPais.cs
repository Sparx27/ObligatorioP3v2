using Compartido.DTOs.Paises;
using LogicaAccesoDatos;
using LogicaAplicacion.ICasosDeUso.Paises;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.Paises
{
    public class AltaPais : IAltaPais
    {
        private JuegosOlimpicosDBContext _context;
        public AltaPais(JuegosOlimpicosDBContext context)
        {
            _context = context;
        }

        public void Ejecutar(PaisInsertDTO paisInsertDTO)
        {
            throw new NotImplementedException();
        }
    }
}
