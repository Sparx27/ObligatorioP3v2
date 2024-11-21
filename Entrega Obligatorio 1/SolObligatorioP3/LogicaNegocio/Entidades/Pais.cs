using LogicaNegocio.IEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class Pais : IEntity
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Habitantes { get; set; }
        public string NombreDelegado { get; set; }
        public string TelDelegado { get; set; }

        public Pais() { }
        Pais(int id, string nombre, int habitantes, string nombreDelegado, string telDelegado)
        {
            Id = id;
            Nombre = nombre;
            Habitantes = habitantes;
            NombreDelegado = nombreDelegado;
            TelDelegado = telDelegado;
        }
    }
}
