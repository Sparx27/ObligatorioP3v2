using Compartido.DTOs.Disciplinas;
using Compartido.DTOs.Auditorias;
using LogicaAplicacion.ICasosDeUso.Atletas;
using LogicaAplicacion.ICasosDeUso.Auditorias;
using LogicaAplicacion.ICasosDeUso.Disciplinas;
using LogicaNegocio.ExcepcionesEntidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LogicaNegocio.Enums;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisciplinaController : ControllerBase
    {
        private readonly IEventosAtleta _eventosAtleta;
        private readonly IFindAllDisciplinas _finAllDisciplinas;
        private readonly IInsertDisciplina _altaDisciplina;
        private readonly IDeleteDisciplina _deleteDisciplina;
        private readonly IDisciplinaUpdate _disciplinaUpdate;
        private readonly IDisciplinaSelectById _disciplinaSelectById;
        private readonly IAuditoriaInsert _auditoriaInsert;
        public DisciplinaController(IEventosAtleta eventosAtleta, 
            IFindAllDisciplinas findAllDisciplinas, 
            IInsertDisciplina altaDisciplina, 
            IDeleteDisciplina deleteDisciplina, 
            IDisciplinaSelectById disciplinaSelectById,
            IAuditoriaInsert auditoriaInsert)
        {
            _eventosAtleta = eventosAtleta;
            _finAllDisciplinas = findAllDisciplinas;
            _altaDisciplina = altaDisciplina;
            _deleteDisciplina = deleteDisciplina;
            _disciplinaSelectById = disciplinaSelectById;
            _auditoriaInsert = auditoriaInsert;
        }

        [Authorize(Roles = "Digitador")]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                DisciplinaDTO? res = _disciplinaSelectById.Ejecutar(id);
                return res == null ? NotFound("No se encontró disciplina con ese id") : Ok(res);
            }
            catch (DisciplinaException dex)
            {
                return BadRequest(dex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Algo no salió correctamente");
            }

        }

        //[Authorize(Roles = "Digitador")]
        [HttpPost]
        public IActionResult Post([FromBody] DisciplinaInsertDTO disciplinaInsertDto)
        {
            try
            {
                int idDisciplina = _altaDisciplina.Ejecutar(disciplinaInsertDto);
                _auditoriaInsert.Ejecutar(new AuditoriaInsertDTO
                {
                    Accion = Accion.Create,
                    EmailUsuario = User.FindFirst("Email")?.Value,
                    Entidad = "Disciplina",
                    EntidadId = idDisciplina
                });

                return Created();

            }
            catch (ConflictException cex)
            {
                return Conflict(cex.Message);
            }
            catch (DisciplinaException dex)
            {
                return BadRequest(dex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Algo no salió correctamente");
            }

        }

        [Authorize(Roles = "Digitador")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] DisciplinaUpdateDTO disciplinaUpdateDTO)
        {
            try
            {
                DisciplinaDTO disciplinaDTO = _disciplinaUpdate.Ejecutar(id, disciplinaUpdateDTO);

                _auditoriaInsert.Ejecutar(new AuditoriaInsertDTO
                {
                    Accion = Accion.Update,
                    EmailUsuario = User.FindFirst("Email")?.Value,
                    Entidad = "Disciplina",
                    EntidadId = id
                });

                return Ok(disciplinaDTO);

            }
            catch (ConflictException cex)
            {
                return Conflict(cex.Message);
            }
            catch (DisciplinaException dex)
            {
                return BadRequest(dex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Algo no salió correctamente");
            }
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
                IEnumerable<DisciplinaDTO> disciplinas = _finAllDisciplinas.Ejecutar();
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
