using FlashCodeNFe.Dominio.Exceptions;
using FlashCodeNFe.Dominio.Features.Produtos;
using FlashCodeNFe.Infra.ORM.Contexts;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace FlashCodeNFe.Infra.ORM.Features.Orders
{
    /// <summary>
    /// Repositório de orders
    /// </summary>
    public class ProdutoRepository : IProdutoRepositorio
    {
        private FlashCodeNFeDbContext _context;

        public ProdutoRepository(FlashCodeNFeDbContext context)
        {
            _context = context;
        }

        #region ADD

        /// <summary>
        /// Adiciona um novo produto na base de dados
        /// </summary>
        // <param name="produto">É o produto que será adicionado da base de dados</param>
        /// <returns>Retorna o novo produto com os atributos atualizados (como id)</returns>
        public Produto Add(Produto produto)
        {
            // Adiciona a nova produto
            var newProduto = _context.Produtos.Add(produto);
            // Salva no banco
            _context.SaveChanges();
            // Retorna a nova produto com id atualizado
            return newProduto;
        }

        #endregion
        
        #region GET
        public IQueryable<Produto> PegarTodos(int? tamanho = null)
        {
            if (tamanho != null)
                return _context.Produtos.Take((int)tamanho);
            else
                return _context.Produtos;
        }

        public Produto PegarPorId(long produtoId)
        {
            return _context.Produtos.FirstOrDefault(e => e.Id == produtoId);
        }

        #endregion

        #region REMOVE

        public bool Remover(long[] produtosId)
        {
            var produtos = new List<Produto>();
            foreach (var id in produtosId)
            {
                var produtoVendido = _context.ProdutoNota.Where(x => x.Produto.Id == id).FirstOrDefault();
                if (produtoVendido == null)
                {
                    produtos.Add(_context.Produtos.Where(p => p.Id == id).FirstOrDefault());
                }
            }
            if (produtos.Count < 1)
                throw new NotFoundException();

            _context.Produtos.RemoveRange(produtos);

            return _context.SaveChanges() > 0;
        }

        #endregion

        #region UPDATE
        public bool Atualizar(Produto produto)
        {
            // Altera o estado
            _context.Entry(produto).State = EntityState.Modified;
            // Salva mudanças
            return _context.SaveChanges() > 0;
        }
        #endregion
    }
}