using Compartido.DTOs.Usuarios;
using LogicaNegocio.Entidades;
using LogicaNegocio.Enums;
using LogicaNegocio.ExcepcionesEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LogicaAplicacion.Validadores
{
    public static class ValidarUsuario
    {
        public static void Email(string email)
        {
            if (!Regex.IsMatch(email, @"^[a-zA-Z0-9]+@[a-zA-Z0-9]+\.[a-zA-Z0-9]+$"))
            {
                throw new UsuarioException("El formato del mail no es correcto");
            }
            if (email.Length > 255)
            {
                throw new UsuarioException("El email puede contener hasta 255 caracteres");
            }
        }

        public static void Contrasena(string contrasena)
        {
            if (!Regex.IsMatch(contrasena, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[\.;,!]).{6,}$"))
            {
                throw new UsuarioException("La contraseña debe contener al menos 6 caracteres y al menos una mayúscula, minúscula, dígito y [. ; , !]");
            }
        }

        public static void Rol(int rolId)
        {
            if (rolId < 0 || rolId > 1)
            {
                throw new UsuarioException("El rol solamente puede ser como Administrador o Digitador");
            }
        }

        public static void Nombre(string nombre)
        {
            if (nombre != null && nombre.Length > 50)
            {
                throw new UsuarioException("El Nombre puede contener hasta 50 caracteres");
            }
        }
    }
}
