using HitPoint.Models;
using Microsoft.AspNetCore.Mvc;

namespace HitPoint.Web.Controllers
{
    public class EmpresaController : Controller
    {
        public IActionResult ListarEmp()
        {
            var model = new EmpresaModel();
            return View(model);
        }

        public IActionResult CadastrarEmp()
        {
            return View();
        }
    }
}
