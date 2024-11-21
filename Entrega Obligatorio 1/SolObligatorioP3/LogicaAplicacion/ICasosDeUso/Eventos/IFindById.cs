using Compartido.DTOs.Eventos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ICasosDeUso.Eventos
{
    public interface IFindById
    {
        EventoDTO Ejecutar(int id);
    }
}
