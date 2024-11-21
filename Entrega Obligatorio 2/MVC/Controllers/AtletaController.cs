
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Models.Atleta;
using MVC.Models.Disciplina;
using MVC.Utils;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace MVC.Controllers
{
    public class AtletaController : Controller
    {
        private readonly string _url;
        
        public AtletaController(IConfiguration config)
        {
            _url = config.GetConnectionString("API");
        }
       

        // GET: AtletaController
        public ActionResult Index()
        {

            IEnumerable<AtletaListaVM> listaAltetas = new List<AtletaListaVM>();
            HttpClient cliente = new HttpClient();           
            
            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
            Task<HttpResponseMessage> tarea = cliente.GetAsync(_url + "/api/Pais");
            tarea.Wait();
            HttpResponseMessage respuesta = tarea.Result;
            Task<string> contenido = respuesta.Content.ReadAsStringAsync();
            contenido.Wait();
            string datos = contenido.Result;
            if (respuesta.IsSuccessStatusCode)
            {
                listaPaises = JsonConvert.DeserializeObject<IEnumerable<PaisListadoViewModel>>(datos);
            }
            else if (StatusCodes.Status401Unauthorized == (int)respuesta.StatusCode)
            {
                return RedirectToAction("IniciarSesion", "Usuario");
            }
            else if (StatusCodes.Status403Forbidden == (int)respuesta.StatusCode)
            {
                return RedirectToAction("Create", "Pais");
            }
            else
            {
                ViewBag.Mensaje = datos;
            }







            if (ManejoSession.GetIdLogueado(HttpContext) != null && ManejoSession.GetRolLogueado(HttpContext) == "Digitador")
            {
                IEnumerable<AtletaListaVM> res = null;
                try
                {
                    //res = _findAllAtletas.Ejectuar().Select(a => new AtletaListaVM
                    //{
                    //    Id = a.Id,
                    //    Nombre = a.Nombre,
                    //    Apellido = a.Apellido,
                    //    NombrePais = a.NombrePais,
                    //    Sexo = a.Sexo,
                    //});
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Index", "Error");
                }
                return View(res);
            }
            else
            {
                return RedirectToAction("Index", "Error", new { code = 401, message = "No tiene permisos para ver esta información" });
            }
        }

        // GET: AtletaController/Details/5
        public ActionResult Details(int id)
        {
            if (ManejoSession.GetIdLogueado(HttpContext) != null && ManejoSession.GetRolLogueado(HttpContext) == "Digitador")
            {
                try
                {
                    //IEnumerable<DisciplinaListaDTO> liD = _findAllDisciplinas.Ejecutar();
                    //ViewBag.Disciplinas = liD.Select(l => new DisciplinaListaVM
                    //{
                    //    Id = l.Id,
                    //    Nombre = l.Nombre,
                    //});

                    //AtletaDTO atletaDTO = _getByIdAtleta.Ejecutar(id);
                    //AtletaVM atletaVM = new AtletaVM
                    //{
                    //    Id = atletaDTO.Id,
                    //    Nombre = atletaDTO.Nombre,
                    //    Apellido = atletaDTO.Apellido,
                    //    Sexo = atletaDTO.Sexo,
                    //    NombrePais = atletaDTO.NombrePais,
                    //    DisciplinasAtleta = atletaDTO.DisciplinasAtleta.Select(d => new DisciplinaListaVM
                    //    {
                    //        Id = d.Id,
                    //        Nombre = d.Nombre,
                    //    })
                    //};

                    return View(/*atletaVM*/);

                }               
                catch (Exception ex)
                {
                    return View();
                }
            }
            else
            {
                return RedirectToAction("Index", "Error", new { code = 401, message = "No tiene permisos para ver esta información" });
            }


        }

        // GET: AtletaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AtletaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AtletaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AtletaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AtletaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AtletaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult AgregarDisciplina(int? id, int? idDisciplina)
        {
            if (ManejoSession.GetIdLogueado(HttpContext) != null && ManejoSession.GetRolLogueado(HttpContext) == "Digitador")
            {
                if (id == null)
                {
                    return RedirectToAction("Index", "Error", new { code = 404, message = "El Atleta no existe" });
                }

                //IEnumerable<DisciplinaListaDTO> liD = _findAllDisciplinas.Ejecutar();
                //ViewBag.Disciplinas = liD.Select(l => new DisciplinaListaVM
                //{
                //    Id = l.Id,
                //    Nombre = l.Nombre,
                //});

                //try
                //{
                //    _agregarDisciplina.Ejecutar(id.Value, idDisciplina);
                //    TempData["Message"] = "Atleta registrado correctamente en la disciplina";

                //}
                //catch (AtletaException aex)
                //{
                //    TempData["ErrorMessage"] = aex.Message;

                //}
                //catch (DisciplinaException dex)
                //{
                //    TempData["ErrorMessage"] = dex.Message;
                //}
                //catch (Exception ex)
                //{
                //    TempData["ErrorMessage"] = "Algo no sucedió correctamente";

                //}

                return RedirectToAction("Details", new { id = id.Value });
            }
            else
            {
                return RedirectToAction("Index", "Error", new { code = 401, message = "No tiene permisos para ver esta información" });
            }

        }
    }
}
