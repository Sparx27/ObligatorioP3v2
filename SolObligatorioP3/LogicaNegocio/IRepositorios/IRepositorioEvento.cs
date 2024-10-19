﻿using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.IRepositorios
{
    public interface IRepositorioEvento : IRepositorio<Evento>
    {
        Evento GetByNombre(string nombre);
        List<Evento> GetByFecha (DateTime fecha);
        void Add(Evento item, int[] atletasId);
        List<Evento> GetEventosAtleta(int atletaId);
    }
}
