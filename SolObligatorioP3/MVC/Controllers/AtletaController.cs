using Compartido.DTOs.Atletas;
using LogicaAplicacion.ICasosDeUso.Atletas;
using LogicaNegocio.ExcepcionesEntidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Models.Atleta;
using MVC.Models.Disciplina;

namespace MVC.Controllers
{
    public class AtletaController : Controller
    {
        private readonly IFindAllAtletas _findAllAtletas;
        private readonly IGetByIdAtleta _getByIdAtleta;
        public AtletaController(IFindAllAtletas findAllAtletas, IGetByIdAtleta getByIdAtleta)
        {
            _findAllAtletas = findAllAtletas;
            _getByIdAtleta = getByIdAtleta;
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
            try
            {
                AtletaDTO atletaDTO = _getByIdAtleta.Ejecutar(id);
                AtletaVM atletaVM = new AtletaVM
                {
                    Id = atletaDTO.Id,
                    Nombre = atletaDTO.Nombre,
                    Apellido = atletaDTO.Apellido,
                    Sexo = atletaDTO.Sexo,
                    NombrePais = atletaDTO.NombrePais,
                    DisciplinasAtleta = atletaDTO.DisciplinasAtleta.Select(d => new DisciplinaListaVM
                    {
                        Id = d.Id,
                        Nombre = d.Nombre,
                    })
                };

                return View(atletaVM);

            }
            catch (AtletaException aex)
            {
                return RedirectToAction("Index", "Error", new {code=404, message = aex.Message});
            }
            catch (Exception ex)
            {
                return View();
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
    }
}
