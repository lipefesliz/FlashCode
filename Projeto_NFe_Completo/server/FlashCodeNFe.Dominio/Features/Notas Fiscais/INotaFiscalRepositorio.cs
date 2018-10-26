using FlashCodeNFe.Dominio.Base;
using FlashCodeNFe.Dominio.Features.Produtos;
using System.Linq;

namespace FlashCodeNFe.Dominio.Features.Notas_Fiscais
{
    public interface INotaFiscalRepositorio : IRepositorio<NotaFiscal>
    {
        bool RemoverProdutos(long notaFiscalId, long[] produtosIds);
        bool AdicionarProduto(long notaId, long produtoId, long quantidade);
        IQueryable<Produto> PegarProdutoPorNota(long notaFiscalId);
    }
}
