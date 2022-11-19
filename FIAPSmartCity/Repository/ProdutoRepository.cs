using FIAPSmartCity.Models;
using FIAPSmartCity.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace FIAPSmartCity.Repository
{
    public class ProdutoRepository
    {
        private readonly DataBaseContext context;

        public ProdutoRepository()
        {
            // Criando um instância da classe de contexto do EntityFramework
            context = new DataBaseContext();
        }

        public Produto Consultar(int id)
        {
            id = 1; // Apenas para teste. Um código que já existe.
            var prod = context.Produto
                .FirstOrDefault(p => p.IdProduto == id);

            return prod;
        }
    }
}
