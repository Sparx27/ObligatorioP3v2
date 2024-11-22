using Compartido.DTOs.Usuarios;
using LogicaAplicacion.ICasosDeUso.Usuarios;
using LogicaNegocio.ExcepcionesEntidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApi.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly ILoginUsuario _login;
        private readonly IGetByIdUsuario _getById;
        private readonly IFindAllUsuarios _getAll;
        private readonly IAltaUsuario _alta;
        private readonly IUpdateUsuario _update;
        private readonly IDeleteUsuario _delete;
        private readonly IConfiguration _config;

        public UsuarioController(
            ILoginUsuario login,
            IAltaUsuario alta,
            IUpdateUsuario update,
            IGetByIdUsuario getById,
            IFindAllUsuarios getAll,
            IDeleteUsuario delete,
            IConfiguration config)
        {
            _login = login;
            _alta = alta;
            _update = update;
            _getById = getById;
            _getAll = getAll;
            _delete = delete;
            _config = config;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("iniciar-sesion")]
        public IActionResult Login([FromBody] CredencialesDTO dto)
        {
            Token token = new Token(_config);

            try
            {
                UsuarioDTO usuario = _login.Ejecutar(dto.Email, dto.Contrasena);
                UsuarioLogueadoDTO usuarioRes = new UsuarioLogueadoDTO
                {
                    Id = usuario.Id,
                    Rol = usuario.RolUsuario,
                    Token = token.Crear(usuario)

                };
                return Ok(usuarioRes);
            }
            catch (UsuarioException uex)
            {
                return BadRequest(uex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }


        // GET: api/<UsuarioController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_getAll.Ejecutar());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Algo no salió correctamente");
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = "Administrador,Digitador")]
        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                string idUsuario = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                string rol = User.FindFirst(ClaimTypes.Role)?.Value;

                if (rol == "Digitador")
                    if (idUsuario != id.ToString()) return Unauthorized("No tiene permisos para acceder a estos recursos");

                return Ok(_getById.Ejecutar(id));
            }
            catch (UsuarioException uex)
            {
                return BadRequest(uex);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Algo no salió correctamente");
            }

        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = "Administrador")]
        // POST api/<UsuarioController>
        [HttpPost()]
        public IActionResult Post([FromBody] UsuarioInsertDTO usuarioInsert)
        {
            try
            {
                _alta.Ejecutar(usuarioInsert);
                return Created();

            }
            catch (ConflictException cex)
            {
                return Conflict(cex.Message);
            }
            catch (UsuarioException uex)
            {
                return BadRequest(uex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Algo no salió correctamente");
            }

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = "Administrador,Digitador")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UsuarioUpdateDTO dtoUpdate)
        {
            try
            {
                string idUsuario = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                string rol = User.FindFirst(ClaimTypes.Role)?.Value;

                if (rol == "Digitador")
                    if (idUsuario != id.ToString()) return Unauthorized("No tiene permisos para acceder a estos recursos");

                return Ok(_update.Ejecutar(id, dtoUpdate));
            }
            catch (ConflictException cex)
            {
                return Conflict(cex.Message);
            }
            catch (UsuarioException uex)
            {
                return BadRequest(uex);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Algo no salió correctamente");
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = "Administrador,Digitador")]
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody] UpdateContrasenaDTO dto)
        {
            try
            {
                string idUsuario = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                string rol = User.FindFirst(ClaimTypes.Role)?.Value;

                if (rol == "Digitador")
                    if (idUsuario != id.ToString()) return Unauthorized("No tiene permisos para acceder a estos recursos");

                if(rol == "Digitador")
                {
                    return Ok(_update.Ejecutar(id, dto.ContrasenaNueva, dto.ContrasenaAnterior));
                }

                return Ok(_update.Ejecutar(id, dto.ContrasenaNueva));
            }
            catch (UsuarioException uex)
            {
                return BadRequest(uex);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Algo no salió correctamente");
            }
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = "Administrador")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _delete.Ejecutar(id);
                return NoContent();
            }
            catch (UsuarioException uex)
            {
                return BadRequest(uex);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Algo no salió correctamente");
            }
        }
    }
}
