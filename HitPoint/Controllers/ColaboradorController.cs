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
            var model = new ColaboradorModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult CadastrarCol(ColaboradorModel model)
        {
            var colaborador = new Colaborador()
            {
                Nome = model.Nome,
                EmpresaID = model.EmpresaID,
                FilialID = model.FilialID,
                PIS = model.PIS,

            };

            colaborador.Cadastrar();
            return RedirectToAction("ListarCol");
        }

        public IActionResult Alterar(int id)
        {
            var colaborador = new Colaborador(id);
            var model = new ColaboradorModel(colaborador);
            return View(model);
        }

        [HttpPost]
        public IActionResult Alterar(ColaboradorModel model)
        {
            var colaborador = model.GerarColaborador();
            colaborador.Alterar();
            return RedirectToAction("ListarCol");
        }
        public IActionResult Deletar(int id)
        {
            var colaborador = new Colaborador(id);
            var model = new ColaboradorModel(colaborador);
            return View(model);
        }
        [HttpPost]
        public IActionResult Deletar(ColaboradorModel model)
        {
            var colaborador = model.GerarColaborador();
            colaborador.Deletar();

            return RedirectToAction("ListarCol");
        }
    }
}
