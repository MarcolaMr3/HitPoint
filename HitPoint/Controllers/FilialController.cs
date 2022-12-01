using HitPoint.Models;
using HitPoint.Utils.Entidades;
using Microsoft.AspNetCore.Mvc;


namespace HitPoint.Web.Controllers
{
    public class FilialController : Controller
    {
        public IActionResult ListarFil()
        {
            var model = new FiliaisModel();
            return View(model);
        }

        public IActionResult CadastrarFil()
        {
            var model = new FilialModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult CadastrarFil(FilialModel model)
        {
            var filial = new Filial()
            {
                Nome = model.Nome,
                CNPJ = model.CNPJ,
                EmpresaID = model.EmpresaID,

            };

            filial.Cadastrar();
            return RedirectToAction("ListarFil");
        }

        public IActionResult Alterar(int id)
        {
            var filial = new Filial(id);
            var model = new FilialModel(filial);
            return View(model);
        }

        [HttpPost]
        public IActionResult Alterar(FilialModel model)
        {
            var filial = model.GerarFilial();
            filial.Alterar();
            return RedirectToAction("ListarFil");
        }
        public IActionResult Deletar(int id)
        {
            var filial = new Filial(id);
            var model = new FilialModel(filial);
            return View(model);
        }
        [HttpPost]
        public IActionResult Deletar(FilialModel model)
        {
            var filial = model.GerarFilial();
            filial.Deletar();

            return RedirectToAction("ListarFil");
        }
    }
}