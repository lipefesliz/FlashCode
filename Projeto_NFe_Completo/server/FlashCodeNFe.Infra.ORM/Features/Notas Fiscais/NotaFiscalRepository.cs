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
                .Include(n => n.Destinatario)
                .Include(n => n.Transportador)
                .Include(n => n.ProdutoNota)
                .FirstOrDefault(n => n.Id == notaFiscalId);

            var produtosIds = _context.ProdutoNota.Where(x => x.NotaFiscal.Id == notaFiscalId).Include(x => x.Produto).ToList();

            foreach (var item in produtosIds)
            {
                nota.Produtos.Add(_context.Produtos.Where(x => x.Id == item.Produto.Id).FirstOrDefault());

            }

            return nota;
        }

        #endregion

        #region REMOVE

        public bool Remover(long[] notaFiscalsId)
        {
            var notaFiscals = new List<NotaFiscal>();
            foreach (var notaFiscal in notaFiscalsId)
            {
                notaFiscals.Add(_context.NotasFiscais.Where(p => p.Id == notaFiscal).FirstOrDefault());
            }
            if (notaFiscals.Count < 1)
                throw new NotFoundException();
            
            _context.NotasFiscais.RemoveRange(notaFiscals);

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
        #endregion
    }
}
