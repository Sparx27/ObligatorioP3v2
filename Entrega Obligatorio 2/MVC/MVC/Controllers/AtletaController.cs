
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

        public async Task<ActionResult> ListAtletasDisciplina(int? disciplinaId)
        {
            try
            {
                (string, HttpResponseMessage) disciplinas =
                    await ConexionServidor.ClientSinBody(_url + "/api/Disciplina", "GET");

                if (disciplinas.Item2.IsSuccessStatusCode)
                {
                    IEnumerable<DisciplinaVM> listaDiscplinas = JsonConvert.DeserializeObject<IEnumerable<DisciplinaVM>>(disciplinas.Item1) ??
                        throw new Exception("Fallo en obtener listado de disciplinas");

                    ViewBag.Disciplinas = listaDiscplinas;
                }
                else
                {
                    TempData["ErrorMessage"] = disciplinas.Item1;
                    return View();
                }

                if (disciplinaId != null)
                {
                    (string, HttpResponseMessage) atletas =
                        await ConexionServidor.ClientSinBody(_url + "/api/Atleta/" + disciplinaId, "GET");

                    if (atletas.Item2.IsSuccessStatusCode)
                    {
                        IEnumerable<AtletaListaVM> listaAtletasvm = JsonConvert.DeserializeObject<IEnumerable<AtletaListaVM>>(atletas.Item1) ??
                            throw new Exception("Fallo en obtener listado de atletas");

                        return View(listaAtletasvm);
                    }
                    else
                    {
                        TempData["ErrorMessage"] = atletas.Item1;
                    }
                }
                return View();

            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }
            return View();
        }
    }
}
