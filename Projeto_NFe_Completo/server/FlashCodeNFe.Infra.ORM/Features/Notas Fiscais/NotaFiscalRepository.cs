using FlashCodeNFe.Dominio.Exceptions;
using FlashCodeNFe.Dominio.Features.Notas_Fiscais;
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
    public class NotaFiscalRepository : INotaFiscalRepositorio
    {
        private FlashCodeNFeDbContext _context;

        public NotaFiscalRepository(FlashCodeNFeDbContext context)
        {
            _context = context;
        }

        #region ADD

        /// <summary>
        /// Adiciona um novo notaFiscal na base de dados
        /// </summary>
        // <param name="notaFiscal">É o notaFiscal que será adicionado da base de dados</param>
        /// <returns>Retorna o novo notaFiscal com os atributos atualizados (como id)</returns>
        public NotaFiscal Add(NotaFiscal notaFiscal)
        {
            var newNotaFiscal = _context.NotasFiscais.Add(notaFiscal);

            _context.SaveChanges();
            return newNotaFiscal;
        }

        #endregion

        #region GET
        public IQueryable<NotaFiscal> PegarTodos(int? tamanho = null)
        {
            if (tamanho != null)
                return _context.NotasFiscais
                .Include(n => n.Emitente)
                .Include(n => n.Destinatario)
                .Include(n => n.Transportador)
                .Include(n => n.ProdutoNota).Take((int)tamanho);
            else
                return _context.NotasFiscais
                .Include(n => n.Emitente)
                .Include(n => n.Destinatario)
                .Include(n => n.Transportador)
                .Include(n => n.ProdutoNota);
        }

        public NotaFiscal PegarPorId(long notaFiscalId)
        {
            var nota = _context.NotasFiscais
                .Include(n => n.Emitente)
                .Include(n => n.Emitente.Endereco)
                .Include(n => n.Destinatario)
                .Include(n => n.Destinatario.Endereco)
                .Include(n => n.Transportador)
                .Include(n => n.Transportador.Endereco)

                .Include(n => n.ProdutoNota)
                .FirstOrDefault(n => n.Id == notaFiscalId);

            var produtosIds = _context.ProdutoNota.Where(x => x.NotaFiscalId == notaFiscalId).Include(x => x.Produto).ToList();

            foreach (var item in produtosIds)
            {
                nota.Produtos.Add(_context.Produtos.Where(x => x.Id == item.Produto.Id).FirstOrDefault());

            }

            return nota;
        }

        public IQueryable<Produto> PegarProdutoPorNota(long notaFiscalId)
        {

            return _context.ProdutoNota.Where(x => x.NotaFiscalId == notaFiscalId).Select(x => x.Produto);
        }

        #endregion

        #region REMOVE

        public bool Remover(long[] notaFiscalsId)
        {
            var notaFiscais = new List<NotaFiscal>();
            foreach (var notaFiscal in notaFiscalsId)
            {
                notaFiscais.Add(_context.NotasFiscais.Where(p => p.Id == notaFiscal).FirstOrDefault());
            }
            if (notaFiscais.Count < 1)
                throw new NotFoundException();

            var produtosNota = new List<ProdutoNota>();

            foreach (var item in notaFiscais)
            {
                produtosNota.AddRange(_context.ProdutoNota.Where(x => x.NotaFiscalId == item.Id).ToList());
            }

            _context.ProdutoNota.RemoveRange(produtosNota);
            _context.NotasFiscais.RemoveRange(notaFiscais);

            return _context.SaveChanges() > 0;
        }

        #endregion

        #region UPDATE
        public bool Atualizar(NotaFiscal notaFiscal)
        {
            // Altera o estado
            _context.Entry(notaFiscal).State = EntityState.Modified;
            // Salva mudanças
            return _context.SaveChanges() > 0;
        }

        public bool AdicionarProduto(long notaId, long produtoId, long quantidade)
        {
            var nota = _context.NotasFiscais.Where(x => x.Id == notaId).FirstOrDefault() ?? throw new NotFoundException();
            var produto = _context.Produtos.Where(x => x.Id == produtoId).FirstOrDefault() ?? throw new NotFoundException();

            var produtoNotaDb = _context.ProdutoNota.Where(x => x.NotaFiscalId == notaId && x.Produto.Id == produtoId).FirstOrDefault();

            if (produtoNotaDb != null)
            {
                return false;
            }


            var produtoNota = new ProdutoNota();
            produtoNota.NotaFiscalId = nota.Id;
            produtoNota.Quantidade = quantidade;
            produtoNota.ProdutoId = produtoId;
            produtoNota.Produto = produto;

            _context.ProdutoNota.Add(produtoNota);

            return _context.SaveChanges() > 0;
        }

        public bool RemoverProdutos(long notaFiscalId, long[] produtosIds)
        {
            var nota = _context.NotasFiscais.FirstOrDefault(n => n.Id == notaFiscalId) ?? throw new NotFoundException();

            var produtosNota = new List<ProdutoNota>();
            foreach (var item in produtosIds)
            {
                produtosNota.AddRange(_context.ProdutoNota.Where(x => x.NotaFiscalId == notaFiscalId && x.Produto.Id == item).ToList());
            }

            _context.ProdutoNota.RemoveRange(produtosNota);

            // Salva mudanças
            return _context.SaveChanges() > 0;
        }
        #endregion
    }
}
