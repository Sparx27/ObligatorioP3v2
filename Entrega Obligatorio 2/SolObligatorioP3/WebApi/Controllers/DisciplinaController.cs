using Compartido.DTOs.Disciplinas;
using LogicaAplicacion.ICasosDeUso.Atletas;
using LogicaAplicacion.ICasosDeUso.Disciplinas;
using LogicaNegocio.ExcepcionesEntidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisciplinaController : ControllerBase
    {
        private readonly IEventosAtleta _eventosAtleta;
        private readonly IFindAllDisciplinas _finAllDisciplinas;
        private readonly IAltaDisciplina _altaDisciplina;
        private readonly IDeleteDisciplina _deleteDisciplina;
        //private readonly IUpdateDisciplina _updateDisciplina;
        //private readonly IFindByIdDisciplina _findByIdDisciplina;
        public DisciplinaController(IEventosAtleta eventosAtleta, IFindAllDisciplinas findAllDisciplinas, IAltaDisciplina altaDisciplina, IDeleteDisciplina deleteDisciplina)
        {
            _eventosAtleta = eventosAtleta;
            _finAllDisciplinas = findAllDisciplinas;
            _altaDisciplina = altaDisciplina;
            _deleteDisciplina = deleteDisciplina;
        }

        [Authorize(Roles ="Digitador")]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            //Falta implementar
            return Ok();
        }

        [Authorize(Roles = "Digitador")]
        [HttpPost]
        public IActionResult Post([FromBody] DisciplinaInsertDTO disciplinaDto)
        {
            //Falta implementar
            return Created();
        }

        [Authorize(Roles = "Digitador")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] DisciplinaUpdateDTO discplinaUpdateDTO)
        {
            //Falta implementar
            return Ok();
        }


        [Authorize(Roles = "Digitador")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //Falta implementar
            return NoContent();
        }

        /// <summary>
        /// Permite obtener todas las disciplinas
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //Ver en este el tema de la autenticación, es utilizado para obtener el listado para el anterior que es sin autenticación
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                IEnumerable<DisciplinaListaDTO> disciplinas = _finAllDisciplinas.Ejecutar();
                return disciplinas == null
                    ? NotFound("No se encontraron disciplinas")
                    : Ok(disciplinas);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Algo no salió correctamente");
            }

        }
        /*
         RF3– CRUD de disciplinas a través de Webapi. - Autenticación Jwt
        - Se podrán agregar disciplinas, modificarlas, eliminarlas, obtener una disciplina dado su Id, obtener una
        disciplina dado su nombre (recordar que es único), obtener todas las disciplinas.
        - Estas operaciones se expondrán a través de una Web Api, y se probarán a través de un cliente
        HttpClient.
         */




    }
}
