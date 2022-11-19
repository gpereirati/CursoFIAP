using FIAPSmartCity.Models;
using FIAPSmartCity.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FIAPSmartCity.Controllers
{
    public class TipoProdutoController : Controller
    {

        private readonly TipoProdutoRepository tipoProdutoRepository;

        public TipoProdutoController()
        {
            tipoProdutoRepository = new TipoProdutoRepository();
        }

        [Filtros.LogFilter]
        [HttpGet]
        public IActionResult Index()
        {
            var listaTipo = tipoProdutoRepository.Listar();
            return View(listaTipo);
        }

        // Anotação de uso do Verb HTTP Get
        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View(new TipoProduto());
        }

        // Anotação de uso do Verb HTTP Post
        [HttpPost]
        public ActionResult Cadastrar(Models.TipoProduto tipoProduto)
        {
            if (ModelState.IsValid)
            {
                tipoProdutoRepository.Inserir(tipoProduto);

                @TempData["mensagem"] = "Tipo cadastrado com sucesso!";
                return RedirectToAction("Index", "TipoProduto");

            }
            else
            {
                return View(tipoProduto);
            }
        }

        [HttpGet]
        public ActionResult Editar(int Id)
        {
            var tipoProduto = tipoProdutoRepository.Consultar(Id);
            return View(tipoProduto);
        }

        [HttpPost]
        public ActionResult Editar(Models.TipoProduto tipoProduto)
        {

            if (ModelState.IsValid)
            {
                tipoProdutoRepository.Alterar(tipoProduto);

                @TempData["mensagem"] = "Tipo alterado com sucesso!";
                return RedirectToAction("Index", "TipoProduto");
            }
            else
            {
                return View(tipoProduto);
            }

        }


        [HttpGet]
        public ActionResult Consultar(int Id)
        {
            var tipoProduto = tipoProdutoRepository.Consultar(Id);
            return View(tipoProduto);
        }


        [HttpGet]
        public ActionResult Excluir(int Id)
        {
            tipoProdutoRepository.Excluir(Id);

            @TempData["mensagem"] = "Tipo removido com sucesso!";

            return RedirectToAction("Index", "TipoProduto");
        }



    }
}