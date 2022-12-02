using HitPoint.Models;
using HitPoint.Utils.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace HitPoint.Web.Controllers
{
    public class PontoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GerarMarcacao()
        {
            var model = new PontoModel();
            return View(model);
        }

    }
}
