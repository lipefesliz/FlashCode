using AutoMapper;
using FlashCodeNFe.Aplicacao.Features.Produtos.Commands;
using FlashCodeNFe.Dominio.Exceptions;
using FlashCodeNFe.Dominio.Features.Produtos;
using System.Linq;

namespace FlashCodeNFe.Aplicacao.Features.Produtos
{
    public class ProdutoServico : IProdutoServico
    {
        private IProdutoRepositorio _produtoRepositorio;

        public ProdutoServico(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }
        public long Add(ProdutoRegistrarCommand produtoRegistrarCommand)
        {
            var produto = Mapper.Map<ProdutoRegistrarCommand, Produto>(produtoRegistrarCommand);

            return _produtoRepositorio.Add(produto).Id;

        }

        public bool Atualizar(ProdutoEditarCommand produtoEditarCommand)
        {
            var produtoDb = _produtoRepositorio.PegarPorId(produtoEditarCommand.Id) ?? throw new NotFoundException();

            Mapper.Map<ProdutoEditarCommand, Produto>(produtoEditarCommand, produtoDb);

            return _produtoRepositorio.Atualizar(produtoDb);
        }

        public Produto PegarPorID(long id)
        {
            return _produtoRepositorio.PegarPorId(id);
        }

        public IQueryable<Produto> PegarTodos()
        {
            return _produtoRepositorio.PegarTodos();
        }

        public bool Remover(ProdutoRemoverCommand produtoRemoverCommand)
        {
            return _produtoRepositorio.Remover(produtoRemoverCommand.ProdutosIDs);
        }
    }
}
