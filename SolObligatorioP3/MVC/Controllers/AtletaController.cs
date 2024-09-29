using LogicaAplicacion.ICasosDeUso.Atletas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Models.Atleta;

namespace MVC.Controllers
{
    public class AtletaController : Controller
    {
        private readonly IFindAllAtletas _findAllAtletas;
        public AtletaController(IFindAllAtletas findAllAtletas)
        {
            _findAllAtletas = findAllAtletas;
        }


        // GET: AtletaController
        public ActionResult Index()
        {
            IEnumerable<AtletaListaVM> res = null;
            try
            {
                 res = _findAllAtletas.Ejectuar().Select(a => new AtletaListaVM
                {
                    Id = a.Id,
                    Nombre = a.Nombre,
                    Apellido = a.Apellido,
                    NombrePais = a.NombrePais,
                    Sexo = a.Sexo,
                });
            }
            catch (Exception ex)
            {
                RedirectToAction("Index", "Error");
            }
            return View(res);
        }

        // GET: AtletaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
    }
}
