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
using LogicaNegocio.Entidades;

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
        private readonly IDisciplinaSelectByNombre _disciplinaSelectByNombre;
        public DisciplinaController(IEventosAtleta eventosAtleta, 
            IFindAllDisciplinas findAllDisciplinas, 
            IInsertDisciplina altaDisciplina, 
            IDeleteDisciplina deleteDisciplina, 
            IDisciplinaSelectById disciplinaSelectById,
            IAuditoriaInsert auditoriaInsert,
            IDisciplinaSelectByNombre disciplinaSelectByNombre)
        {
            _eventosAtleta = eventosAtleta;
            _finAllDisciplinas = findAllDisciplinas;
            _altaDisciplina = altaDisciplina;
            _deleteDisciplina = deleteDisciplina;
            _disciplinaSelectById = disciplinaSelectById;
            _auditoriaInsert = auditoriaInsert;
            _disciplinaSelectByNombre = disciplinaSelectByNombre;
        }

        [Authorize(Roles = "Digitador")]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                DisciplinaDTO? res = _disciplinaSelectById.Ejecutar(id);
                return res == null ? NotFound("No se encontró disciplina con ese Id") : Ok(res);
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
        [HttpGet("Nombre/{nombre}")]
        public IActionResult GetByNombre(string nombre)
        {
            try
            {
                DisciplinaDTO? res = _disciplinaSelectByNombre.Ejecutar(nombre);
                return res == null ? NotFound("No se encontró disciplina con ese nombre") : Ok(res);
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
        [HttpPut("{nombre}")]
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
        [HttpDelete("{nombre}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _deleteDisciplina.Ejecutar(id);
                _auditoriaInsert.Ejecutar(new AuditoriaInsertDTO
                {
                    Accion = Accion.Delete,
                    EmailUsuario = User.FindFirst("Email")?.Value,
                    Entidad = "Disciplina",
                    EntidadId = id
                });
                return NoContent();
            }
            catch (ConflictException cex)
            {
                return Conflict(cex.Message);
            }
            catch (DisciplinaException dex)
            {
                return BadRequest(dex.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Algo no salió correctamente");
            }
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
                return Ok(disciplinas);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Algo no salió correctamente");
            }

        }
    }
}
