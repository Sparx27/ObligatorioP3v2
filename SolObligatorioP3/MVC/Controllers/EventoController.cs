using Compartido.DTOs.Disciplinas;
using Compartido.DTOs.Eventos;
using LogicaAplicacion.ICasosDeUso.Atletas;
using LogicaAplicacion.ICasosDeUso.Disciplinas;
using LogicaAplicacion.ICasosDeUso.Eventos;
using LogicaNegocio.Entidades;
using LogicaNegocio.ExcepcionesEntidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Models.Atleta;
using MVC.Models.Disciplina;
using MVC.Models.Evento;
using MVC.Utils;

namespace MVC.Controllers
{
    public class EventoController : Controller
    {
        private readonly IFindAtletasDisciplina _findAtletasDisciplina;
        private readonly IFindAllDisciplinas _findAllDisciplinas;
        private readonly IAltaEvento _altaEvento;

        public EventoController(IFindAtletasDisciplina findAtletasDisciplina, IFindAllDisciplinas findAllDisciplinas, IAltaEvento altaEvento)
        {
            _findAtletasDisciplina = findAtletasDisciplina;
            _findAllDisciplinas = findAllDisciplinas;
            _altaEvento = altaEvento;
        }

        // GET: EventoController
        public ActionResult Index()
        {
            if (ManejoSession.GetIdLogueado(HttpContext) != null)
            {
                try
                {
                    ViewBag.Disciplinas = _findAllDisciplinas.Ejecutar().Select(d => new DisciplinaListaVM
                    {
                        Id = d.Id,
                        Nombre = d.Nombre,
                    });
                }
                catch (DisciplinaException dex)
                {
                    ViewBag.ErrorMessage = dex.Message;
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = ex.Message;
                }
                return View();
            }
            return RedirectToAction("Index", "Error");

        }

        // GET: EventoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EventoController/Create
        public ActionResult Create(int idDisciplina)
        {
            if (ManejoSession.GetIdLogueado(HttpContext) != null)
            {
                EventoInsertVM EventoVM = new EventoInsertVM();

                try
                {
                    IEnumerable<AtletaListaVM> atletas = _findAtletasDisciplina.Ejecutar(idDisciplina).Select(a => new AtletaListaVM()
                    {
                        Id = a.Id,
                        Nombre = a.Nombre,
                        Apellido = a.Apellido,
                        NombrePais = a.NombrePais,
                        Sexo = a.Sexo
                    });
                    EventoVM.DisciplinaId = idDisciplina;
                    EventoVM.Atletas = atletas;
                    return View(EventoVM);
                }
                catch (EventoException eex)
                {
                    TempData["ErrorMessage"] = eex.Message;
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = ex.Message;
                }
                return View(EventoVM);
            }
            return RedirectToAction("Index", "Error");

        }

        // POST: EventoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EventoInsertVM eventoInsertVM)
        {
            if(ManejoSession.GetIdLogueado(HttpContext) != null)
            {
                

                try
                {
                    EventoInsertDTO evento = new EventoInsertDTO()
                    {
                        DisciplinaId = eventoInsertVM.DisciplinaId,
                        FchInicio = eventoInsertVM.FchInicio,
                        FchFin = eventoInsertVM.FchFin,
                        NombrePrueba = eventoInsertVM.NombrePrueba,
                        AtletasId = eventoInsertVM.AtletasId
                    };

                    _altaEvento.Ejecutar(evento);
                    TempData["Message"] = "Evento agregado con éxito";
                    return RedirectToAction("Create", new { idDisciplina = eventoInsertVM.DisciplinaId });
                }
                catch (EventoException eex) {
                    TempData["ErrorMessage"] = eex.Message;
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = ex.Message;
                }

                EventoInsertVM EventoVM = new EventoInsertVM();
                IEnumerable<AtletaListaVM> atletas;
                try
                {
                    atletas = _findAtletasDisciplina.Ejecutar(eventoInsertVM.DisciplinaId).Select(a => new AtletaListaVM()
                    {
                        Id = a.Id,
                        Nombre = a.Nombre,
                        Apellido = a.Apellido,
                        NombrePais = a.NombrePais,
                        Sexo = a.Sexo
                    });
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Index", "Error");
                }
                EventoVM.DisciplinaId = eventoInsertVM.DisciplinaId;
                EventoVM.Atletas = atletas;

                return View(EventoVM);
            }
            return RedirectToAction("Index", "Error", new { code = 404, message = "No tiene permisos para ver este recurso"});
        }

        // GET: EventoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EventoController/Edit/5
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

        // GET: EventoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EventoController/Delete/5
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
    }
}
