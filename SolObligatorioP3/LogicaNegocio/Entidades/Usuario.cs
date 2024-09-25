using LogicaNegocio.Enums;
using LogicaNegocio.IEntidades;
using LogicaNegocio.ValueObjects.Usuario;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class Usuario : IEntity
    {
        public int Id { get; set; }
        public RUsuarioEmail Email { get; set; }
        public RUsuarioContrasena Contrasena { get; set; }
        public Rol RolUsuario { get; set; }
        public DateTime FechaRegistro { get; private set; } = DateTime.Now;
        public int IdAdminRegistro { get; set; }

        [MaxLength(50)]
        public string? Nombre { get; set; }

        public Usuario() { }
        public Usuario(string email, string contrasena, Rol rolUsuario, int idAdminRegistro)
        {
            Email = new RUsuarioEmail(email);
            Contrasena = new RUsuarioContrasena(contrasena);
            RolUsuario = rolUsuario;
            IdAdminRegistro = idAdminRegistro;
        }
        public Usuario(string email, string contrasena, Rol rolUsuario, int idAdminRegistro, string nombre)
        {
            Email = new RUsuarioEmail(email);
            Contrasena = new RUsuarioContrasena(contrasena);
            RolUsuario = rolUsuario;
            IdAdminRegistro = idAdminRegistro; 
            Nombre = nombre;
        }
    }
}
