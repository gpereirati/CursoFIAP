using FIAPSmartCity.Models;
using FIAPSmartCity.Repository.Context;


namespace FIAPSmartCity.Repository
{
    public class TipoProdutoRepositoryEF
    {
        // Propriedade que terá a instância do DataBaseContext
        private readonly DataBaseContext context;

        public TipoProdutoRepositoryEF()
        {
            // Criando um instância da classe de contexto do EntityFramework
            context = new DataBaseContext();
        }


        public IList<TipoProdutoEF> Listar()
        {
            return context.TipoProdutoEF.ToList();
        }

        public IList<TipoProdutoEF> ListarOrdenadoPorNome()
        {
            var lista =
                context.TipoProdutoEF.OrderBy(t => t.DescricaoTipo).ToList<TipoProdutoEF>();

            return lista;
        }

        public IList<TipoProdutoEF> ListarOrdenadoPorNomeDescendente()
        {
            var lista =
                context.TipoProdutoEF.OrderByDescending(t => t.DescricaoTipo).ToList<TipoProdutoEF>();

            return lista;
        }
        public IList<TipoProdutoEF> ListarTiposComercializados()
        {
            // Filtro com Where
            var lista =
                context.TipoProdutoEF.Where(t => t.Comercializado == false)
                        .OrderByDescending(t => t.DescricaoTipo).ToList<TipoProdutoEF>();

            return lista;
        }

        public IList<TipoProdutoEF> ListarTiposComercializadosCriterio(bool selecao)
        {
            // Filtro com Where
            var lista =
                context.TipoProdutoEF.Where(t => t.Comercializado == selecao)
                        .OrderByDescending(t => t.DescricaoTipo).ToList<TipoProdutoEF>();

            return lista;
        }

        public IList<TipoProdutoEF> ListarTiposComercializados(bool selecao)
        {
            // Filtro com Where
            var lista =
                context.TipoProdutoEF.Where(t => t.Comercializado == selecao && t.IdTipo > 2)
                        .OrderByDescending(t => t.DescricaoTipo).ToList<TipoProdutoEF>();

            return lista;
        }

        public TipoProdutoEF ConsultaPorDescricao(string descricao)
        {
            // Retorno único
            TipoProdutoEF tipo =
                context.TipoProdutoEF.Where(t => t.DescricaoTipo == descricao)
                    .FirstOrDefault<TipoProdutoEF>();

            return tipo;
        }

        public IList<TipoProdutoEF> ListarTiposParteDescricao(string parteDescricao)
        {
            // Filtro com Where e Contains
            var lista =
                context.TipoProdutoEF.Where(t => t.DescricaoTipo.Contains(parteDescricao))
                        .ToList<TipoProdutoEF>();

            return lista;
        }

        public TipoProdutoEF Consultar(int id)
        {
            return context.TipoProdutoEF.Find(id);
        }


        public void Inserir(TipoProdutoEF tipoProduto)
        {
            context.TipoProdutoEF.Add(tipoProduto);
            context.SaveChanges();
        }

        public void Alterar(TipoProdutoEF tipoProduto)
        {
            context.TipoProdutoEF.Update(tipoProduto);
            context.SaveChanges();
        }

        public void Excluir(int id)
        {
            // Criar um tipo produto apenas com o Id
            var tipoProduto = new TipoProdutoEF()
            {
                IdTipo = id
            };

            context.TipoProdutoEF.Remove(tipoProduto);
            context.SaveChanges();
        }

    }
}