﻿using Compartido.DTOs.Atletas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ICasosDeUso.Atletas
{
    public interface ISelectByDisciplinaId
    {
        IEnumerable<AtletaListaDTO> Ejecutar(int disciplinaId);
    }
}
