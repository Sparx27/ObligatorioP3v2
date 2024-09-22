using Compartido.DTOs.Eventos;
using LogicaAccesoDatos;
using LogicaAplicacion.ICasosDeUso.Eventos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.Eventos
{
    public class AltaEvento : IAltaEvento
    {
        private JuegosOlimpicosDBContext _context;
        public AltaEvento(JuegosOlimpicosDBContext context)
        {
            _context = context;
        }

        public void Ejecutar(EventoInsertDTO eventoInsertDTO)
        {
            throw new NotImplementedException();
        }
    }
}
