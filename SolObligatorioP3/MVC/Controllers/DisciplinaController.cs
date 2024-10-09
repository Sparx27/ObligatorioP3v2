using Compartido.DTOs.Disciplinas;
using LogicaAplicacion.ICasosDeUso.Disciplinas;
using LogicaNegocio.ExcepcionesEntidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Models.Disciplina;

namespace MVC.Controllers
{
    public class DisciplinaController : Controller
    {
        private readonly IAltaDisciplina _altaDisciplina;

        public DisciplinaController(IAltaDisciplina altaDisciplina)
        {
            _altaDisciplina = altaDisciplina;
        }
        // GET: DisciplinaController
        public ActionResult Index()
        {
            return View();
        }

        // GET: DisciplinaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DisciplinaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DisciplinaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DisciplinaInsertVM disciplinaInsertVM)
        {
            
            try
            {
                DisciplinaInsertDTO disciplina = new DisciplinaInsertDTO
                {
                    Nombre = disciplinaInsertVM.Nombre,
                    AnioIntegracion = disciplinaInsertVM.AnioIntegracion
                };
                _altaDisciplina.Ejecutar(disciplina);
                TempData["Message"] = "Disciplina creada correctamente";

                return RedirectToAction("Create");
            }
            catch (DisciplinaException dex)
            {
                ViewBag.ErrorMessage = dex.Message;
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();

            }
        }

        // GET: DisciplinaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DisciplinaController/Edit/5
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

        // GET: DisciplinaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DisciplinaController/Delete/5
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
