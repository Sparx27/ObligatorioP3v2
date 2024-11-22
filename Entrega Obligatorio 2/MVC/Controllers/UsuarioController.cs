using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Models.Usuario;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using MVC.Utils;
using System.Net.Http.Headers;
using System.Security.Policy;
using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MVC.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly string _url;

        public UsuarioController(IConfiguration config)
        {
            _url = config.GetConnectionString("API");
        }
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
        public async Task<ActionResult> Index(string email, string password)
        {
            try
            {
                CredencialesVM cred = new CredencialesVM
                {
                    Email = email,
                    Contrasena = password
                };
                (string, HttpResponseMessage) res = 
                    await ConexionServidor.ClientConBody<CredencialesVM>(_url + "/api/Usuario/iniciar-sesion", "POST", cred);

                if (res.Item2.IsSuccessStatusCode)
                {
                    UsuarioLogueadoVM vm = JsonConvert.DeserializeObject<UsuarioLogueadoVM>(res.Item1) ??
                        throw new Exception("Fallo en iniciar-sesion de API");

                    HttpContext.Session.SetInt32("idLogueado", vm.Id);
                    HttpContext.Session.SetString("rolLogueado", vm.Rol);
                    HttpContext.Session.SetString("token", vm.Token);

                    return RedirectToAction("Index", "Home");
                    return RedirectToAction("Details", new { id = vm.Id });
                }
                else
                {
                    ViewBag.ErrorMessage = res.Item1;
                }
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
    }
}
