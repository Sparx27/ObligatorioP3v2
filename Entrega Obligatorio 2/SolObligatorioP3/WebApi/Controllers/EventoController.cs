using Compartido.DTOs.Eventos;
using LogicaAplicacion.ICasosDeUso.Eventos;
using LogicaNegocio.ExcepcionesEntidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private readonly ISelectByBusqueda _selectByBusqueda;
        public EventoController(ISelectByBusqueda selectByBusqueda)
        {
            _selectByBusqueda = selectByBusqueda;
        }

        [HttpGet]
        [Authorize(Roles = "Digitador")]
        public IActionResult GetByBusqueda([FromQuery] EventoBusquedaDTO dto)
        {
            try
            {
                return Ok(_selectByBusqueda.Ejecutar(dto));
            }
            catch (EventoException eex)
            {
                return BadRequest(eex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Algo no salió correctamente");
            }
        }
    }
}
