using Microsoft.AspNetCore.Mvc;
using HitPoint.Web.Models;
using HitPoint.Utils.Entidades;



namespace HitPoint.Web.Controllers
{
    public class ColaboradorController : Controller
    {
        public IActionResult ListarCol()
        {
            var model = new ColaboradorModel();
            return View(model);
        }

        public IActionResult CadastrarCol()
        {
            return View();
        }

        
    }
}
