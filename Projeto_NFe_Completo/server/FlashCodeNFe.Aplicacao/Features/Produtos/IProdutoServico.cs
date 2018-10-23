using FlashCodeNFe.Aplicacao.Features.Produtos.Commands;
using FlashCodeNFe.Aplicacao.Features.Produtos.ViewModels;
using FlashCodeNFe.Dominio.Features.Produtos;
using System.Linq;

namespace FlashCodeNFe.Aplicacao.Features.Produtos
{
    public interface IProdutoServico
    {
        long Add(ProdutoRegistrarCommand produtoRegistrarCommand);

        bool Atualizar(ProdutoEditarCommand produtoEditarCommand);

        ProdutoDetailViewModel PegarPorID(long id);

        IQueryable<Produto> PegarTodos();

        bool Remover(ProdutoRemoverCommand produtoRemoverCommand);
    }
}
