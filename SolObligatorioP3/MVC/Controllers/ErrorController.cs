using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index(int? code, string? message)
        {
            if(code != null)
            {
                ViewBag.Message = new { code, message };
            }
            
            return View();
        }
    }
}
