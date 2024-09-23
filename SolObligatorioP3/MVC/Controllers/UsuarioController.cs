using LogicaAplicacion.ICasosDeUso.Usuarios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Compartido.DTOs.Usuarios;
using MVC.Models.Usuario;
using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.Enums;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

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
            int? usuarioId = HttpContext.Session.GetInt32("idLogueado");
            if (usuarioId != null)
            {
                return RedirectToAction("Details", new { id = usuarioId});
            }

            return View();
        }

        [HttpPost]
        public ActionResult Index(string email, string password)
        {
            SiNoHaySesion();

            try
            {
                UsuarioDTO res  = _loginUsuario.Ejecutar(email, password);
                HttpContext.Session.SetInt32("idLogueado", res.Id);
                HttpContext.Session.SetString("rolLogueado", res.RolUsuario);
                return RedirectToAction("Details", new { id= res.Id } );
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
            SiNoHaySesion(401, "Por favor, inicie sesión para continuar");
            try
            {
                if(HttpContext.Session.GetString("rolLogueado") == "Administrador")
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
                if(id != HttpContext.Session.GetInt32("idLogueado"))
                {
                    return RedirectToAction("Index", "Error", new { code=401, message="No tiene permisos para ver esta información" });
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
                    };
                    return View(usuarioVM);
                }
            }
            catch(UsuarioException uex)
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
            if (HttpContext.Session.GetString("rolLogueado") == "Administrador")
            {

                ViewBag.Roles = GetUsuarioRoles();
                return View();
            }

            return RedirectToAction("Index", "Error");
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioInsertVM usuarioInsertVM)
        {
            if (HttpContext.Session.GetString("rolLogueado") == "Administrador")
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
                        RolUsuario = usuarioInsertVM.RolUsuario
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
            int? idLogueado = HttpContext.Session.GetInt32("idLogueado");

            if(idLogueado != null)
            {
                // Si es administrador o digitador con mismo id al que intenta modificar
                if (HttpContext.Session.GetString("rolLogueado") == "Administrador" || idLogueado == id)
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
                    catch(UsuarioException uex)
                    {
                        ViewBag.ErrorMessage = uex.Message;
                    }
                    catch(Exception ex)
                    {
                        ViewBag.ErrorMessage = ex.Message;
                    }
                    return View();
                }
            }
            // Si no cumplio ninguno de esos escenarios
            return RedirectToAction("Index", "Error");
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, UsuarioUpdateVM usuarioUpdateVM)
        {
            int? idLogueado = HttpContext.Session.GetInt32("idLogueado");

            if (idLogueado != null)
            {
                ViewBag.Roles = GetUsuarioRoles();

                UsuarioUpdateDTO usuarioUpdateDTO = new UsuarioUpdateDTO
                {
                    Email = usuarioUpdateVM.Email,
                    Nombre = usuarioUpdateVM.Nombre
                };
                                                                                       // En caso de ser un digitador
                if (HttpContext.Session.GetString("rolLogueado") == "Administrador" || idLogueado == id)
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
                    catch(UsuarioException uex)
                    {
                        ViewBag.ErrorMessage = uex.Message;
                    }
                    catch(Exception ex)
                    {
                        ViewBag.ErrorMessage = ex.Message;
                    }
                    return View(usuarioUpdateVM); // VM que llega por parametro al Edit
                }
            }
            return RedirectToAction("Index", "Error");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CambiarContrasena(int id, string contrasena, string contrasenaAnterior)
        {
            int? idLogueado = HttpContext.Session.GetInt32("idLogueado");

            if(idLogueado != null)
            {
                if (HttpContext.Session.GetString("rolLogueado") == "Administrador" || id == idLogueado)
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

                    try
                    {
                        // Intento cambiar la contraseña
                        UsuarioUpdateDTO usuarioActualizado = _updateUsuario.Ejecutar(id, contrasena, contrasenaAnterior);

                        TempData["MessageContrasena"] = "Contraseña actualizada correctamente";
                        return RedirectToAction("Edit", new { Id = id });
                    }
                    catch(UsuarioException uex)
                    {
                        TempData["ErrorContrasena"] = uex.Message;
                    }
                    catch(Exception ex)
                    {
                        TempData["ErrorContrasena"] = ex.Message;
                    }
                    return RedirectToAction("Edit", new { Id = id });
                }
            }

            return RedirectToAction("Index", "Error");
        }

        

        // GET: UsuarioController/Delete/5
        public ActionResult Delete(int id)
        {
            if (HttpContext.Session.GetString("rolLogueado") == "Administrador")
            {
                try
                {
                    _deleteUsuario.Ejecutar(id);
                    TempData["MessageDelete"] = "Usuario eliminado con éxito";
                }
                catch(UsuarioException uex)
                {
                    TempData["MessageDelete"] = uex.Message;
                }
                catch(Exception ex)
                {
                    TempData["MessageDelete"] = ex.Message;
                }
                return RedirectToAction("ListaUsuarios");
                
            }

            return RedirectToAction("Index", "Error");
        }

        [HttpGet("Usuario/Lista-Usuarios")]
        public ActionResult ListaUsuarios ()
        {
            SiNoHaySesion();

            if (HttpContext.Session.GetString("rolLogueado") == "Administrador")
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

        public ActionResult? SiNoHaySesion()
        {
            if (HttpContext.Session.GetInt32("idLogueado") == null)
            {
                return RedirectToAction("Index", "Error");
            }
            return null;
        }
        public ActionResult? SiNoHaySesion(int code, string message)
        {
            if (HttpContext.Session.GetInt32("idLogueado") == null)
            {
                return RedirectToAction("Index", "Error", new { httpCode = code,  message });
            }
            return null;
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
