using Microsoft.AspNetCore.Mvc;
using HitPoint.Utils.Entidades;
using HitPoint.Models;

namespace HitPoint.Web.Controllers
{
    public class ColaboradorController : Controller
    {
        public IActionResult ListarCol()
        {
            var model = new ColaboradoresModel();
            return View(model);
        }

        public IActionResult CadastrarCol()
        {
            return View();
        }

        
    }
}
