using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Models.Disciplina;
using MVC.Utils;
using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MVC.Controllers
{
    public class DisciplinaController : Controller
    {
        private readonly string _url;

        public DisciplinaController(IConfiguration config)
        {
            _url = config.GetConnectionString("API");
        }

        public async Task<ActionResult> Index()
        {
            if (ManejoSession.GetRolLogueado(HttpContext) == "Digitador")
            {
                try
                {
                    (string, HttpResponseMessage) disciplinas =
                        await ConexionServidor.ClientSinBody(_url + "/api/Disciplina", "GET");

                    if (disciplinas.Item2.IsSuccessStatusCode)
                    {
                        IEnumerable<DisciplinaVM> listaDiscplinas = JsonConvert.DeserializeObject<IEnumerable<DisciplinaVM>>(disciplinas.Item1) ??
                            throw new Exception("Error al intentar obtener listado de disciplinas");

                        return View(listaDiscplinas);
                    }
                    else
                    {
                        throw new Exception(disciplinas.Item1);
                    }
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Index", "Error", new { code = 500, message = ex.Message });
                }
            }
            else
            {
                return RedirectToAction("Index", "Error", new { code = 401, message = "No tiene permisos para ver esta información" });
            }
        }

        public async Task<ActionResult> Details(int id)
        {
            if (id == 0)
            {
                TempData["ErrorMessage"] = "Id incorrecto";
                return View();
            }

            if (ManejoSession.GetRolLogueado(HttpContext) == "Digitador")
            {
                try
                {
                    string token = ManejoSession.GetToken(HttpContext)
                        ?? throw new Exception("Fallo en la obtención del token");

                    (string, HttpResponseMessage) disciplinas =
                        await ConexionServidor.ClientSinBody(_url + "/api/Disciplina/" + id.ToString(), "GET", token);

                    if (disciplinas.Item2.IsSuccessStatusCode)
                    {
                        DisciplinaVM res = JsonConvert.DeserializeObject<DisciplinaVM>(disciplinas.Item1);

                        return View(res);
                    }
                    else if ((int)disciplinas.Item2.StatusCode == StatusCodes.Status500InternalServerError)
                    {
                        throw new Exception(disciplinas.Item1);
                    }
                    else
                    {
                        TempData["ErrorMessage"] = disciplinas.Item1;
                        return View();
                    }
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Index", "Error", new { code = 500, message = ex.Message });
                }
            }
            else
            {
                return RedirectToAction("Index", "Error", new { code = 401, message = "No tiene permisos para ver esta información" });
            }
        }

        [HttpGet]
        public async Task<ActionResult> Buscar(int? tipoBusqueda, int? iId, string? iNa)
        {
            if (ManejoSession.GetRolLogueado(HttpContext) == "Digitador")
            {
                try
                {
                    if (tipoBusqueda is null || tipoBusqueda <= 0)
                    {
                        return View();
                    }
                    else if (tipoBusqueda == 1)
                    {
                        if(iId is null || iId <= 0)
                        {
                            TempData["ErrorMessage"] = "Error: Id incorrecto";
                            return View();
                        }

                        string token = ManejoSession.GetToken(HttpContext)
                            ?? throw new Exception("Fallo en la obtención del token");

                        (string, HttpResponseMessage) disciplinas =
                            await ConexionServidor.ClientSinBody(_url + "/api/Disciplina/" + iId, "GET", token);

                        if (disciplinas.Item2.IsSuccessStatusCode)
                        {
                            DisciplinaVM res = JsonConvert.DeserializeObject<DisciplinaVM>(disciplinas.Item1);

                            return View(res);
                        }
                        else if ((int)disciplinas.Item2.StatusCode == StatusCodes.Status500InternalServerError)
                        {
                            throw new Exception(disciplinas.Item1);
                        }
                        else
                        {
                            TempData["ErrorMessage"] = disciplinas.Item1;
                            return RedirectToAction("Buscar");
                        }
                    }
                    else
                    {
                        if(string.IsNullOrEmpty(iNa))
                        {
                            TempData["ErrorMessage"] = "Error: Nombre vacío";
                            return View();
                        }

                        iNa = iNa.Trim();

                        string token = ManejoSession.GetToken(HttpContext)
                            ?? throw new Exception("Fallo en la obtención del token");

                        (string, HttpResponseMessage) disciplinas =
                            await ConexionServidor.ClientSinBody(_url + "/api/Disciplina/Nombre/" + iNa, "GET", token);

                        if (disciplinas.Item2.IsSuccessStatusCode)
                        {
                            DisciplinaVM res = JsonConvert.DeserializeObject<DisciplinaVM>(disciplinas.Item1);

                            return View(res);
                        }
                        else if ((int)disciplinas.Item2.StatusCode == StatusCodes.Status500InternalServerError)
                        {
                            throw new Exception(disciplinas.Item1);
                        }
                        else
                        {
                            TempData["ErrorMessage"] = disciplinas.Item1;
                            return View();
                        }
                    }
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Index", "Error", new { code = 500, message = ex.Message });
                }
            }
            else
            {
                return RedirectToAction("Index", "Error", new { code = 401, message = "No tiene permisos para ver esta información" });
            }
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            if (ManejoSession.GetRolLogueado(HttpContext) == "Digitador")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Error", new { code = 401, message = "No tiene permisos para ver esta información" });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(DisciplinaInsertVM disciplinaInsertVM)
        {
            if (ManejoSession.GetRolLogueado(HttpContext) == "Digitador")
            {
                try
                {
                    string token = ManejoSession.GetToken(HttpContext)
                        ?? throw new Exception("Fallo en la obtención del token");

                    (string, HttpResponseMessage) disciplinas =
                        await ConexionServidor.ClientConBody(_url + "/api/Disciplina/", "POST", disciplinaInsertVM, token);

                    if (disciplinas.Item2.IsSuccessStatusCode)
                    {
                        TempData["Message"] = "Disciplina creada correctamente";
                        return RedirectToAction(nameof(Create));
                    }
                    else if ((int)disciplinas.Item2.StatusCode == StatusCodes.Status500InternalServerError)
                    {
                        throw new Exception(disciplinas.Item1);
                    }
                    else
                    {
                        TempData["ErrorMessage"] = disciplinas.Item1;
                        return View();
                    }
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Index", "Error", new { code = 500, message = ex.Message });
                }

            }
            else
            {
                return RedirectToAction("Index", "Error", new { code = 401, message = "No tiene permisos para ver esta información" });
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            if (id == 0)
            {
                TempData["ErrorMessage"] = "Id incorrecto";
                return View();
            }

            if (ManejoSession.GetRolLogueado(HttpContext) == "Digitador")
            {
                try
                {
                    string token = ManejoSession.GetToken(HttpContext)
                        ?? throw new Exception("Fallo en la obtención del token");

                    (string, HttpResponseMessage) disciplinas =
                        await ConexionServidor.ClientSinBody(_url + "/api/Disciplina/" + id.ToString(), "GET", token);

                    if (disciplinas.Item2.IsSuccessStatusCode)
                    {
                        DisciplinaUpdateVM res = JsonConvert.DeserializeObject<DisciplinaUpdateVM>(disciplinas.Item1);

                        return View(res);
                    }
                    else if ((int)disciplinas.Item2.StatusCode == StatusCodes.Status500InternalServerError)
                    {
                        throw new Exception(disciplinas.Item1);
                    }
                    else
                    {
                        TempData["ErrorMessage"] = disciplinas.Item1;
                        return View();
                    }
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Index", "Error", new { code = 500, message = ex.Message });
                }
            }
            else
            {
                return RedirectToAction("Index", "Error", new { code = 401, message = "No tiene permisos para ver esta información" });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, DisciplinaUpdateVM disciplinaUpdate)
        {
            if (id == 0)
            {
                TempData["ErrorMessage"] = "Id incorrecto";
                return View();
            }

            if (ManejoSession.GetRolLogueado(HttpContext) == "Digitador")
            {
                try
                {
                    disciplinaUpdate.Nombre = disciplinaUpdate.Nombre.Trim();

                    string token = ManejoSession.GetToken(HttpContext)
                        ?? throw new Exception("Fallo en la obtención del token");

                    (string, HttpResponseMessage) updated =
                        await ConexionServidor.ClientConBody(_url + "/api/Disciplina/" + id.ToString(), "PUT", disciplinaUpdate, token);

                    if (updated.Item2.IsSuccessStatusCode)
                    {
                        DisciplinaUpdateVM res = JsonConvert.DeserializeObject<DisciplinaUpdateVM>(updated.Item1);
                        TempData["Message"] = "Disciplina actualizada correctamente";
                        return RedirectToAction("Edit", new { Id = id });
                    }
                    else if ((int)updated.Item2.StatusCode == StatusCodes.Status500InternalServerError)
                    {
                        throw new Exception(updated.Item1);
                    }
                    else
                    {
                        TempData["ErrorMessage"] = updated.Item1;
                        return RedirectToAction("Edit", new { Id = id });
                    }
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Index", "Error", new { code = 500, message = ex.Message });
                }
            }
            else
            {
                return RedirectToAction("Index", "Error", new { code = 401, message = "No tiene permisos para ver esta información" });
            }
        }

        public async Task<ActionResult> DeleteDesdeBuscar(int id)
        {
            if (ManejoSession.GetIdLogueado(HttpContext) != null && ManejoSession.GetRolLogueado(HttpContext) == "Digitador")
            {
                try
                {
                    string token = ManejoSession.GetToken(HttpContext)
                       ?? throw new Exception("Fallo en la obtención del token");

                    (string, HttpResponseMessage) disciplinas =
                        await ConexionServidor.ClientSinBody(_url + "/api/Disciplina/" + id.ToString(), "DELETE", token);

                    if (disciplinas.Item2.IsSuccessStatusCode)
                    {
                        TempData["Message"] = "Disciplina eliminada correctamente";
                        return RedirectToAction("Buscar");
                    }
                    else if ((int)disciplinas.Item2.StatusCode == StatusCodes.Status500InternalServerError)
                    {
                        throw new Exception(disciplinas.Item1);
                    }
                    else
                    {
                        TempData["ErrorMessage"] = disciplinas.Item1;
                        return RedirectToAction("Buscar");
                    }
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Index", "Error", new { code = 500, message = ex.Message });
                }

            }
            else
            {
                return RedirectToAction("Index", "Error", new { code = 401, message = "No tiene permisos para ver esta información" });
            }
        }

        public async Task<ActionResult> Delete(int id)
        {
            if (ManejoSession.GetIdLogueado(HttpContext) != null && ManejoSession.GetRolLogueado(HttpContext) == "Digitador")
            {
                try
                {
                    string token = ManejoSession.GetToken(HttpContext)
                       ?? throw new Exception("Fallo en la obtención del token");

                    (string, HttpResponseMessage) disciplinas =
                        await ConexionServidor.ClientSinBody(_url + "/api/Disciplina/" + id.ToString(), "DELETE", token);

                    if (disciplinas.Item2.IsSuccessStatusCode)
                    {
                        TempData["Message"] = "Disciplina eliminada correctamente";
                        return RedirectToAction("Index");
                    }
                    else if ((int)disciplinas.Item2.StatusCode == StatusCodes.Status500InternalServerError)
                    {
                        throw new Exception(disciplinas.Item1);
                    }
                    else
                    {
                        TempData["ErrorMessage"] = disciplinas.Item1;
                        return RedirectToAction("Index");
                    }
                }

                catch (Exception ex)
                {
                    return RedirectToAction("Index", "Error", new { code = 500, message = ex.Message });
                }

            }
            else
            {
                return RedirectToAction("Index", "Error", new { code = 401, message = "No tiene permisos para ver esta información" });
            }

        }
    }
}
