using HitPoint.Models;
using Microsoft.AspNetCore.Mvc;

namespace HitPoint.Web.Controllers
{
    public class EmpresaController : Controller
    {
        public IActionResult ListarEmp()
        {
            var model = new EmpresasModel();
            return View(model);
        }

        public IActionResult CadastrarEmp()
        {
            return View();
        }
    }
}
