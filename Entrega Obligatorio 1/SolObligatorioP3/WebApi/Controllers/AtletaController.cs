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
        private readonly IEventosAtleta _eventosAtleta;
        public AtletaController(IEventosAtleta eventosAtleta)
        {
            _eventosAtleta = eventosAtleta;
        }

        [HttpGet("{atletaId}")]
        public IActionResult GetEventosAtleta(int atletaId)
        {
            try
            {
                if (atletaId <= 0) throw new EventoException("El Id del Atleta no es válido");

                return Ok(_eventosAtleta.Ejecutar(atletaId));
            }
            catch (EventoException eex)
            {
                return BadRequest(eex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
