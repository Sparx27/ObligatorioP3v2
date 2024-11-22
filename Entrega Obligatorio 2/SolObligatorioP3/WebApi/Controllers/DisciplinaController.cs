using LogicaAplicacion.ICasosDeUso.Atletas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisciplinaController : ControllerBase
    {
        private readonly IEventosAtleta _eventosAtleta;
        public DisciplinaController(IEventosAtleta eventosAtleta)
        {
            _eventosAtleta = eventosAtleta;
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
