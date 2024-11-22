
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Models.Atleta;
using MVC.Models.Disciplina;
using MVC.Utils;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace MVC.Controllers
{
    public class AtletaController : Controller
    {
        private readonly string _url;
        
        public AtletaController(IConfiguration config)
        {
            _url = config.GetConnectionString("API");
        }
        

    }
}
