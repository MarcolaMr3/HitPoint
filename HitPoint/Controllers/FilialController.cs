using HitPoint.Models;
using Microsoft.AspNetCore.Mvc;


namespace HitPoint.Web.Controllers
{
    public class FilialController : Controller
    {
        public IActionResult ListarFil()
        {
            var model = new FilialModel();
            return View(model);
        }

        public IActionResult CadastrarFil()
        {
            return View();
        }
    }
}
