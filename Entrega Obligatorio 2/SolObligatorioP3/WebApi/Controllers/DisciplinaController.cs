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
using System.Security.Claims;

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
            IDisciplinaSelectByNombre disciplinaSelectByNombre,
            IDisciplinaUpdate disciplinaUpdate)
        {
            _eventosAtleta = eventosAtleta;
            _finAllDisciplinas = findAllDisciplinas;
            _altaDisciplina = altaDisciplina;
            _deleteDisciplina = deleteDisciplina;
            _disciplinaSelectById = disciplinaSelectById;
            _auditoriaInsert = auditoriaInsert;
            _disciplinaSelectByNombre = disciplinaSelectByNombre;
            _disciplinaUpdate = disciplinaUpdate;
        }

        /// <summary>
        /// Permite obtener una disciplina por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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

        /// <summary>
        /// Permite obtener una disciplina por nombre
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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

        /// <summary>
        /// Permite dar de alta una disciplina
        /// </summary>
        /// <param name="disciplinaInsertDto"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = "Digitador")]
        [HttpPost]
        public IActionResult Post([FromBody] DisciplinaInsertDTO disciplinaInsertDto)
        {
            try
            {
                int idDisciplina = _altaDisciplina.Ejecutar(disciplinaInsertDto);

                _auditoriaInsert.Ejecutar(new AuditoriaInsertDTO
                {
                    Accion = Accion.Create,
                    EmailUsuario = User.FindFirst(ClaimTypes.Email)?.Value,
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
            catch (AuditoriaException aex)
            {
                // Esto es un tema interno de servidor, si llego hasta _auditoriaInsert.Ejecutar ya hizo la inserción
                Console.WriteLine(aex.Message);
                return Created();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Algo no salió correctamente");
            }

        }

        /// <summary>
        /// Permite modificar una disciplina
        /// </summary>
        /// <param name="id"></param>
        /// <param name="disciplinaUpdateDTO"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = "Digitador")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] DisciplinaUpdateDTO disciplinaUpdateDTO)
        {
            DisciplinaDTO disciplinaDTO = new DisciplinaDTO();
            try
            {
                disciplinaDTO = _disciplinaUpdate.Ejecutar(id, disciplinaUpdateDTO);

                _auditoriaInsert.Ejecutar(new AuditoriaInsertDTO
                {
                    Accion = Accion.Update,
                    EmailUsuario = User.FindFirst(ClaimTypes.Email)?.Value,
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
            catch (AuditoriaException aex)
            {
                Console.WriteLine(aex.Message);
                return Ok(disciplinaDTO);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Algo no salió correctamente");
            }
        }

        /// <summary>
        /// Permite eliminar una disciplina
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = "Digitador")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _deleteDisciplina.Ejecutar(id);
                _auditoriaInsert.Ejecutar(new AuditoriaInsertDTO
                {
                    Accion = Accion.Delete,
                    EmailUsuario = User.FindFirst(ClaimTypes.Email)?.Value,
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
            catch (AuditoriaException aex)
            {
                Console.WriteLine(aex.Message);
                return NoContent();
            }
            catch (Exception ex)
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
