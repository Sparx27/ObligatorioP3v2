using Compartido.DTOs.Atletas;
using LogicaAccesoDatos;
using LogicaAplicacion.ICasosDeUso.Atletas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.Atletas
{
    public class AltaAtleta : IAltaAtleta
    {
        private JuegosOlimpicosDBContext _context;
        public AltaAtleta(JuegosOlimpicosDBContext context)
        {
            _context = context;
        }

        public void Ejecutar(AtletaInsertDTO atletaInsertDTO)
        {
            throw new NotImplementedException();
        }
    }
}
