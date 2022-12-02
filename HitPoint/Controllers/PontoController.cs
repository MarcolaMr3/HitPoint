using HitPoint.Models;
using HitPoint.Utils.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace HitPoint.Web.Controllers
{
    public class PontoController : Controller
    {
        public IActionResult Index()
        {
            var model = new PontoModel();
            return View(model);
        }

        public IActionResult ListarMar()
        {
            var model = new PontosModel();
            return View(model);
        }

        //[HttpPost]
        //public IActionResult Index(PontoModel model)
        //{
        //    var ponto = new Ponto()
        //    {
        //        Funcionario = model.Funcionario
        //    };

        //    ponto.MarcarPonto();
        //    return RedirectToAction("ListarMar");
        //}

        [HttpPost]
        public IActionResult Index(PontoModel model)
        {
            var ponto = model.GerarMarcacao();
            ponto.MarcarPonto();

            return RedirectToAction("ListarMar");
        }
    }
}
