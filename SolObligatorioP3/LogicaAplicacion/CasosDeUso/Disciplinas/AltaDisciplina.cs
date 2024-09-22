using Compartido.DTOs.Disciplinas;
using LogicaAccesoDatos;
using LogicaAplicacion.ICasosDeUso.Disciplinas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.Disciplinas
{
    public class AltaDisciplina : IAltaDisciplina
    {
        private JuegosOlimpicosDBContext _context;
        public AltaDisciplina(JuegosOlimpicosDBContext context)
        {
            _context = context;
        }

        public void Ejecutar(DisciplinaInsertDTO disciplinaInsertDTO)
        {
            throw new NotImplementedException();
        }
    }
}
