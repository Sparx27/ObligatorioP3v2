using LogicaAplicacion.ICasosDeUso.Usuarios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Compartido.DTOs.Usuarios;
using MVC.Models.Usuario;
using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.Enums;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using MVC.Utils;

namespace MVC.Controllers
{
    public class UsuarioController : Controller
    {
        private ILoginUsuario _loginUsuario;
        private IGetByIdUsuario _getByIdUsuario;
        private IAltaUsuario _altaUsuario;
        private IFindAllUsuarios _findAllUsuarios;
        private IUpdateUsuario _updateUsuario;
        private IDeleteUsuario _deleteUsuario;
        public UsuarioController(
            ILoginUsuario loginUsuario,
            IGetByIdUsuario getByIdUsuario,
            IAltaUsuario altaUsuario,
            IFindAllUsuarios findAllUsuarios,
            IUpdateUsuario updateUsuario,
            IDeleteUsuario deleteUsuario
        )
        {
            _loginUsuario = loginUsuario;
            _getByIdUsuario = getByIdUsuario;
            _altaUsuario = altaUsuario;
            _findAllUsuarios = findAllUsuarios;
            _updateUsuario = updateUsuario;
            _deleteUsuario = deleteUsuario;
        }


        // GET: UsuarioController
        public ActionResult Index()
        {
            int? usuarioId = ManejoSession.GetIdLogueado(HttpContext);
            if (usuarioId != null)
            {
                return RedirectToAction("Details", new { id = usuarioId });
            }

            return View();
        }

        [HttpPost]
        public ActionResult Index(string email, string password)
        {
            try
            {
                UsuarioDTO res = _loginUsuario.Ejecutar(email, password);
                HttpContext.Session.SetInt32("idLogueado", res.Id);
                HttpContext.Session.SetString("rolLogueado", res.RolUsuario);
                return RedirectToAction("Details", new { id = res.Id });
            }
            catch (UsuarioException uex)
            {
                ViewBag.ErrorMessage = uex.Message;
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }
            return View();
        }

        [HttpGet]
        public ActionResult CerrarSesion()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        // GET: UsuarioController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                if (ManejoSession.GetRolLogueado(HttpContext) == "Administrador" && ManejoSession.GetIdLogueado(HttpContext) != null)
                {
                    UsuarioDTO usuarioDTO = _getByIdUsuario.Ejecutar(id);
                    UsuarioVM usuarioVM = new UsuarioVM
                    {
                        Email = usuarioDTO.Email,
                        Nombre = usuarioDTO.Nombre,
                        Id = id,
                        RolUsuario = usuarioDTO.RolUsuario,
                        FechaRegistro = usuarioDTO.FechaRegistro
                    };
                    return View(usuarioVM);
                }

                // Caso de que no sea administrador
                if (id != ManejoSession.GetIdLogueado(HttpContext))
                {
                    return RedirectToAction("Index", "Error", new { code = 401, message = "No tiene permisos para ver esta información" });
                }
                else
                {
                    UsuarioDTO usuarioDTO = _getByIdUsuario.Ejecutar(id);
                    UsuarioVM usuarioVM = new UsuarioVM
                    {
                        Email = usuarioDTO.Email,
                        Nombre = usuarioDTO.Nombre,
                        Id = id,
                        RolUsuario = usuarioDTO.RolUsuario,
                        FechaRegistro = usuarioDTO.FechaRegistro
                    };
                    return View(usuarioVM);
                }
            }
            catch (UsuarioException uex)
            {
                ViewBag.ErrorMessage = uex.Message;
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }

            return View();
        }

        // GET: UsuarioController/Create
        public ActionResult Create()
        {
            if (ManejoSession.GetRolLogueado(HttpContext) == "Administrador" && ManejoSession.GetIdLogueado(HttpContext) != null)
            {
                ViewBag.Roles = GetUsuarioRoles();
                return View();
            }
            return RedirectToAction("Index", "Error", new { code = 401, message = "No tiene permisos para ver esta información" });
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioInsertVM usuarioInsertVM)
        {
            if (ManejoSession.GetRolLogueado(HttpContext) == "Administrador" && ManejoSession.GetIdLogueado(HttpContext) != null)
            {
                ViewBag.Roles = GetUsuarioRoles();

                try
                {
                    if (usuarioInsertVM == null)
                    {
                        throw new UsuarioException("El usuario no puede ser vacío");
                    }
                    UsuarioInsertDTO usuarioNuevo = new UsuarioInsertDTO()
                    {
                        Email = usuarioInsertVM.Email,
                        Contrasena = usuarioInsertVM.Contrasena,
                        Nombre = usuarioInsertVM.Nombre,
                        RolUsuario = usuarioInsertVM.RolUsuario,
                        IdAdminRegistro = (int)ManejoSession.GetIdLogueado(HttpContext)

                    };

                    _altaUsuario.Ejecutar(usuarioNuevo);

                    TempData["Message"] = "Alta realizada con éxito";
                    return RedirectToAction("Create");
                }
                catch (UsuarioException uex)
                {
                    ViewBag.ErrorMessage = uex.Message;
                    return View();
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = ex.Message;
                    return View();

                }
            }
            else
            {
                return RedirectToAction("Index", "Error", new { code = 401, message = "No tiene permisos para ver esta información" });
            }
        }

        // GET: UsuarioController/Edit/5
        public ActionResult Edit(int id)
        {
            // Lo primero chequear si hay sesion
            int? idLogueado = ManejoSession.GetIdLogueado(HttpContext);

            if (idLogueado != null)
            {
                // Si es administrador o digitador con mismo id al que intenta modificar
                if (ManejoSession.GetRolLogueado(HttpContext) == "Administrador" || idLogueado == id)
                {
                    try
                    {
                        // Obtengo los datos
                        UsuarioDTO usuarioDTO = _getByIdUsuario.Ejecutar(id);

                        UsuarioUpdateVM vm = new UsuarioUpdateVM
                        {
                            Email = usuarioDTO.Email,
                            Id = usuarioDTO.Id,
                            Nombre = usuarioDTO.Nombre
                        };

                        ViewBag.Roles = GetUsuarioRoles();

                        return View(vm);
                    }
                    catch (UsuarioException uex)
                    {
                        ViewBag.ErrorMessage = uex.Message;
                    }
                    catch (Exception ex)
                    {
                        ViewBag.ErrorMessage = ex.Message;
                    }
                    return View();
                }
            }
            // Si no cumplio ninguno de esos escenarios
            return RedirectToAction("Index", "Error", new { code = 401, message = "No tiene permisos para ver esta información" });
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, UsuarioUpdateVM usuarioUpdateVM)
        {
            int? idLogueado = ManejoSession.GetIdLogueado(HttpContext);

            if (idLogueado != null)
            {
                ViewBag.Roles = GetUsuarioRoles();

                UsuarioUpdateDTO usuarioUpdateDTO = new UsuarioUpdateDTO
                {
                    Email = usuarioUpdateVM.Email,
                    Nombre = usuarioUpdateVM.Nombre
                };
                // En caso de ser o Administrador un digitador con mismo id
                if (ManejoSession.GetRolLogueado(HttpContext) == "Administrador" || idLogueado == id)
                {
                    try
                    {
                        // Luego de actualizar, devuelvo los nuevos datos para mantenerlos en la vista
                        UsuarioUpdateDTO nuevosDatosUsuario = _updateUsuario.Ejecutar(id, usuarioUpdateDTO);
                        UsuarioUpdateVM vm = new UsuarioUpdateVM
                        {
                            Email = nuevosDatosUsuario.Email,
                            Nombre = nuevosDatosUsuario.Nombre,
                            Id = id,
                        };

                        ViewBag.Message = "Actualizado correctamente";
                        return View(vm);
                    }
                    catch (UsuarioException uex)
                    {
                        ViewBag.ErrorMessage = uex.Message;
                    }
                    catch (Exception ex)
                    {
                        ViewBag.ErrorMessage = ex.Message;
                    }
                    return View(usuarioUpdateVM); // VM que llega por parametro al Edit
                }
            }
            return RedirectToAction("Index", "Error", new { code = 401, message = "No tiene permisos para ver esta información" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CambiarContrasena(int id, string contrasena, string contrasenaAnterior)
        {
            int? idLogueado = ManejoSession.GetIdLogueado(HttpContext);
            string? rolLogueado = ManejoSession.GetRolLogueado(HttpContext);

            if (idLogueado != null)
            {
                // Obtengo los datos
                // No se tira excepcion aca porque el metodo getById ya lo hace si no lo encuentra
                UsuarioDTO usuarioDTO = _getByIdUsuario.Ejecutar(id);

                UsuarioUpdateVM vm = new UsuarioUpdateVM
                {
                    Email = usuarioDTO.Email,
                    Id = usuarioDTO.Id,
                    Nombre = usuarioDTO.Nombre
                };

                ViewBag.Roles = GetUsuarioRoles();

                if (rolLogueado == "Administrador")
                {
                    try
                    {
                        // Intento cambiar la contraseña
                        // El admin puede cambiar la constraseña sin necesidad de escribir la actual, sobreescribe 
                        UsuarioUpdateDTO usuarioActualizado = _updateUsuario.Ejecutar(id, contrasena);

                        TempData["MessageContrasena"] = "Contraseña actualizada correctamente";
                        return RedirectToAction("Edit", new { Id = id });
                    }
                    catch (UsuarioException uex)
                    {
                        TempData["ErrorContrasena"] = uex.Message;
                    }
                    catch (Exception ex)
                    {
                        TempData["ErrorContrasena"] = ex.Message;
                    }
                    return RedirectToAction("Edit", new { Id = id });
                }
                if (id == idLogueado)
                {
                    try
                    {
                        // Intento cambiar la contraseña
                        UsuarioUpdateDTO usuarioActualizado = _updateUsuario.Ejecutar(id, contrasena, contrasenaAnterior);

                        TempData["MessageContrasena"] = "Contraseña actualizada correctamente";
                        return RedirectToAction("Edit", new { Id = id });
                    }
                    catch (UsuarioException uex)
                    {
                        TempData["ErrorContrasena"] = uex.Message;
                    }
                    catch (Exception ex)
                    {
                        TempData["ErrorContrasena"] = ex.Message;
                    }
                    return RedirectToAction("Edit", new { Id = id });
                }
            }

            return RedirectToAction("Index", "Error", new { code = 401, message = "No tiene permisos para ver esta información" });
        }


        // GET: UsuarioController/Delete/5
        public ActionResult Delete(int id)
        {
            if (ManejoSession.GetRolLogueado(HttpContext) == "Administrador" && ManejoSession.GetIdLogueado(HttpContext) != null)
            {
                try
                {
                    _deleteUsuario.Ejecutar(id);
                    TempData["MessageDelete"] = "Usuario eliminado con éxito";
                }
                catch (UsuarioException uex)
                {
                    TempData["MessageDelete"] = uex.Message;
                }
                catch (Exception ex)
                {
                    TempData["MessageDelete"] = ex.Message;
                }
                return RedirectToAction("ListaUsuarios");
            }
            return RedirectToAction("Index", "Error", new { code = 401, message = "No tiene permisos para ver esta información" });
        }

        [HttpGet("Usuario/Lista-Usuarios")]
        public ActionResult ListaUsuarios()
        {
            if (ManejoSession.GetRolLogueado(HttpContext) == "Administrador" && ManejoSession.GetIdLogueado(HttpContext) != null)
            {
                IEnumerable<UsuarioVM> listaUsuarios =
                    _findAllUsuarios.Ejecutar().Select(u => new UsuarioVM()
                    {
                        Email = u.Email,
                        Nombre = u.Nombre,
                        Id = u.Id,
                        RolUsuario = u.RolUsuario,
                    }).ToList();
                return View(listaUsuarios);
            }

            return RedirectToAction("Index", "Error", new { code = 401, message = "No tiene permisos para ver esta información" });
        }

        public IEnumerable<UsuarioRolVM> GetUsuarioRoles()
        {
            // Primero se obtienen los valores del enum Rol
            var roles = Enum.GetValues(typeof(Rol)).Cast<Rol>().ToList();

            // Convertir a lista con el valor int y string de cada Rol
            return roles.Select(r => new UsuarioRolVM
            {
                Id = (int)r,
                Name = r.ToString()
            });
        }
    }
}
