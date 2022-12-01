using Microsoft.AspNetCore.Mvc;

namespace HitPoint.Web.Controllers
{
    public class EmpresaController : Controller
    {
        public IActionResult ListarCol()
        {
            var model = new EmpresaModel();
            return View(model);
        }

        public IActionResult CadastrarCol()
        {
            return View();
        }
    }
}
