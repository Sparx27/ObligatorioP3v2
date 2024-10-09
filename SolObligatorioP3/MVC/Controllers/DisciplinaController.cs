using Compartido.DTOs.Disciplinas;
using LogicaAplicacion.ICasosDeUso.Disciplinas;
using LogicaNegocio.ExcepcionesEntidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Models.Disciplina;
using LogicaNegocio.ExcepcionesEntidades;
using Compartido.Mappers;

namespace MVC.Controllers
{
    public class DisciplinaController : Controller
    {
        private readonly IAltaDisciplina _altaDisciplina;
        private readonly IFindAllDisciplinas _findAllDisciplinas;
        private readonly IDeleteDisciplina _deleteDisciplina;

        public DisciplinaController(
            IAltaDisciplina altaDisciplina, 
            IFindAllDisciplinas findAllDisciplinas, 
            IDeleteDisciplina deleteDisciplina
        )
        {
            _altaDisciplina = altaDisciplina;
            _findAllDisciplinas = findAllDisciplinas;
            _deleteDisciplina = deleteDisciplina;
        }
        // GET: DisciplinaController
        public ActionResult Index()
        {
            try
            {
                return View(_findAllDisciplinas.Ejecutar().Select(d => new DisciplinaListaVM
                {
                    Id = d.Id,
                    Nombre = d.Nombre
                }));
            }
            catch(DisciplinaException dex)
            {
                return RedirectToAction("Index", "Error", new {code= 400, message =dex.Message });
            }
            catch(Exception ex)
            {
                return RedirectToAction("Index", "Error", new { code = 400, message = ex.Message });
            }
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
            try
            {
                _deleteDisciplina.Ejecutar(id);
                TempData["Message"] = "Disciplina eliminada correctamente";
                return RedirectToAction("Index");
            }
            catch(DisciplinaException dex)
            {
                TempData["ErrorMessage"] = dex.Message;
            }
            catch(Exception ex)
            {
                TempData["ErrorMessage"] = "Algo no salió correctamente. Es posible que existan referencias de esta Disciplina en Atletas.";
            }

            return RedirectToAction("Index");
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
