using HitPoint.Models;
using HitPoint.Utils.Entidades;
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
        [HttpPost]
        public IActionResult CadastrarEmp(EmpresaModel model)
        {
            var empresa = new Empresa()
            {
                Nome = model.Nome,
                CNPJ = model.CNPJ,

            };

            empresa.Cadastrar();
            return RedirectToAction("Index");
        }

        public IActionResult Alterar(int id)
        {
            var empresa = new Empresa(id);
            var model = new EmpresaModel(empresa);
            return View(model);
        }

        [HttpPost]
        public IActionResult Alterar(EmpresaModel model)
        {
            var empresa = model.GerarEmpresa();
            empresa.Alterar();
            return RedirectToAction("Index");
        }
        public IActionResult Deletar(int id)
        {
            var empresa = new Empresa(id);
            var model = new EmpresaModel(empresa);
            return View(model);
        }
        [HttpPost]
        public IActionResult Deletar(EmpresaModel model)
        {
            var empresa = model.GerarEmpresa();
            empresa.Deletar();

            return RedirectToAction("Index");
        }
    }
}
