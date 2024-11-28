using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Models.Atleta;
using MVC.Models.Disciplina;
using MVC.Models.Evento;
using MVC.Utils;
using Newtonsoft.Json;

namespace MVC.Controllers
{
    public class EventoController : Controller
    {
        private readonly string _url;

        public EventoController(IConfiguration config)
        {
            _url = config.GetConnectionString("API");
        }

        [HttpGet]
        public async Task<ActionResult> Busqueda(EventoBusquedaVM? vm)
        {
            if (ManejoSession.GetRolLogueado(HttpContext) == "Digitador")
            {
                // En teoría vm nunc debería ser null, pero por las dudas
                if (vm is null || vm.GetType().GetProperties().All(prop => prop.GetValue(vm) == null))
                {
                    return View();
                }
                else
                {
                    try
                    {
                        // Validaciones del VM
                        if(vm.DisciplinaId <= 0)
                        {
                            ViewBag.ErrorMessage = "Id incorrecto";
                            return View();
                        }

                        if (
                            (vm.FchInicio != null && vm.FchFin == null) ||
                            (vm.FchFin != null && vm.FchInicio == null) ||
                            (vm.PuntajeMin != null && vm.PuntajeMax == null) ||
                            (vm.PuntajeMax != null && vm.PuntajeMin == null)
                        )
                        {
                            ViewBag.ErrorMessage = "Si ingresa una fecha debe ingresar ambas, lo mismo para los puntajes";
                            return View();
                        }

                        if (vm.FchInicio > vm.FchFin)
                        {
                            ViewBag.ErrorMessage = "Rango de fechas incorrecto";
                            return View();
                        }

                        if (vm.PuntajeMax < vm.PuntajeMin || 
                            vm.PuntajeMin < 0 || 
                            vm.PuntajeMin > 10 || 
                            vm.PuntajeMax < 0 || 
                            vm.PuntajeMax > 10
                        )
                        {
                            ViewBag.ErrorMessage = "Rango de puntajes incorrecto";
                            return View();
                        }

                        // Reflección para generar URL dinámicamente:
                        List<string> queries = vm.GetType()
                            .GetProperties()
                            .Where(p => p.GetValue(vm) != null)
                            .Select(p =>
                            {
                                if (p.PropertyType == typeof(DateTime?))
                                { 
                                    DateTime? otroP = p.GetValue(vm) as DateTime?;
                                    return $"{p.Name}={otroP.Value.ToString("yyyy-MM-dd")}";
                                }
                                else
                                {
                                    return $"{p.Name}={p.GetValue(vm)}";
                                 }
                            })
                            .ToList();

                        // Ej. api/Evento?DisciplinaId=2&NombreEvento=Salto | Si no hay filtro que traiga todos
                        string queryString = queries.Any() ? "?" + string.Join("&", queries) : "";

                        string token = ManejoSession.GetToken(HttpContext)
                            ?? throw new Exception("Fallo en la obtención del token");

                        (string, HttpResponseMessage) disciplinas =
                            await ConexionServidor.ClientSinBody(_url + "/api/Evento" + queryString, "GET", token);

                        if (disciplinas.Item2.IsSuccessStatusCode)
                        {
                            var res = JsonConvert.DeserializeObject<IEnumerable<EventoListaVM>>(disciplinas.Item1)
                                ?? throw new Exception("Fallo en obtener listado de disciplinas");

                            return View(res);
                        }
                        else if ((int)disciplinas.Item2.StatusCode == StatusCodes.Status500InternalServerError)
                        {
                            throw new Exception(disciplinas.Item1);
                        }
                        else
                        {
                            ViewBag.ErrorMessage = disciplinas.Item2;
                            return View();
                        }
                    }
                    catch (Exception ex)
                    {
                        return RedirectToAction("Index", "Error", new { code = 500, message = ex.Message });
                    }
                }

            }
            else
            {
                return RedirectToAction("Index", "Error", new { code = 401, message = "No tiene permisos para ver esta información" });
            }
        }
    
    }
}
