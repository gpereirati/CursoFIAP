using FIAPSmartCity.Models;
using FIAPSmartCity.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FIAPSmartCity.Controllers
{
    public class TipoProdutoEFController : Controller
    {

        private readonly TipoProdutoRepositoryEF TipoProdutoRepositoryEF;
        private readonly ProdutoRepository ProdutoRepository;

        public TipoProdutoEFController()
        {
            TipoProdutoRepositoryEF = new TipoProdutoRepositoryEF();
            ProdutoRepository = new ProdutoRepository();
        }

        [Filtros.LogFilter]
        [HttpGet]
        public IActionResult Index()
        {
            var listaTipo = TipoProdutoRepositoryEF.Listar();
            return View(listaTipo);
        }

        // Anotação de uso do Verb HTTP Get
        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View(new TipoProdutoEF());
        }

        // Anotação de uso do Verb HTTP Post
        [HttpPost]
        public ActionResult Cadastrar(Models.TipoProdutoEF TipoProdutoEF)
        {
            if (ModelState.IsValid)
            {
                TipoProdutoRepositoryEF.Inserir(TipoProdutoEF);

                @TempData["mensagem"] = "Tipo cadastrado com sucesso!";
                return RedirectToAction("Index", "TipoProdutoEF");

            }
            else
            {
                return View(TipoProdutoEF);
            }
        }

        [HttpGet]
        public ActionResult Editar(int Id)
        {
            var TipoProdutoEF = TipoProdutoRepositoryEF.Consultar(Id);
            return View(TipoProdutoEF);
        }

        [HttpPost]
        public ActionResult Editar(Models.TipoProdutoEF TipoProdutoEF)
        {

            if (ModelState.IsValid)
            {
                TipoProdutoRepositoryEF.Alterar(TipoProdutoEF);

                @TempData["mensagem"] = "Tipo alterado com sucesso!";
                return RedirectToAction("Index", "TipoProdutoEF");
            }
            else
            {
                return View(TipoProdutoEF);
            }

        }


        [HttpGet]
        public ActionResult Consultar(int Id)
        {
            var TipoProdutoEF = TipoProdutoRepositoryEF.Consultar(Id);
            return View(TipoProdutoEF);
        }

        [HttpGet]
        public ActionResult ConsultarProduto(int Id)
        {
            var Produto = ProdutoRepository.Consultar(Id);
            return View(Produto);
        }


        [HttpGet]
        public ActionResult Excluir(int Id)
        {
            TipoProdutoRepositoryEF.Excluir(Id);

            @TempData["mensagem"] = "Tipo removido com sucesso!";

            return RedirectToAction("Index", "TipoProdutoEF");
        }



    }
}