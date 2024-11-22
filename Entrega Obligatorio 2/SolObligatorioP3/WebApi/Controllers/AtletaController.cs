using Compartido.DTOs.Atletas;
using Compartido.DTOs.Eventos;
using LogicaAplicacion.ICasosDeUso.Atletas;
using LogicaNegocio.ExcepcionesEntidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtletaController : ControllerBase
    {
        private readonly ISelectByDisciplinaId _selectByDisciplinaId;
        public AtletaController(ISelectByDisciplinaId selectByDisciplinaId)
        {
            _selectByDisciplinaId = selectByDisciplinaId;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{disciplinaId}")]
        public IActionResult GetByDisciplina(int disciplinaId)
        {
            try
            {
                IEnumerable<AtletaListaDTO> res = _selectByDisciplinaId.Ejecutar(disciplinaId);
                return res == null
                    ? NotFound("No existe disciplina con esa id")
                    : Ok(res);
            }
            catch(AtletaException aex)
            {
                return BadRequest(aex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Algo no salió correctamente");
            }
        }




    }
}
