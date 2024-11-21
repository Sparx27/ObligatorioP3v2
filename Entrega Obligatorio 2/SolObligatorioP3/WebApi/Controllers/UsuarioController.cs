using Compartido.DTOs.Usuarios;
using LogicaAplicacion.ICasosDeUso.Usuarios;
using LogicaNegocio.ExcepcionesEntidades;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Login([FromBody] Credenciales dto)
        {
            Token token = new Token(_config);

            try
            {
                _login.Ejecutar(dto.Email, dto.Contrasena);
                return Ok();

            }
            catch(UsuarioException uex)
            {
                return BadRequest(uex);
            }
        }

        // GET: api/<UsuarioController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
