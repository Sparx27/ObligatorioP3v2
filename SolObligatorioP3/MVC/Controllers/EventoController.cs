using Compartido.DTOs.Disciplinas;
using LogicaAplicacion.ICasosDeUso.Atletas;
using LogicaAplicacion.ICasosDeUso.Disciplinas;
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

        public EventoController(IFindAtletasDisciplina findAtletasDisciplina, IFindAllDisciplinas findAllDisciplinas)
        {
            _findAtletasDisciplina = findAtletasDisciplina;
            _findAllDisciplinas = findAllDisciplinas;
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
                try
                {
                    EventoInsertVM EventoVM = new EventoInsertVM();
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
                catch (Exception ex)
                {

                }
            }
            return RedirectToAction("Index", "Error");

        }

        // POST: EventoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EventoInsertVM eventoInsertVM)
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
