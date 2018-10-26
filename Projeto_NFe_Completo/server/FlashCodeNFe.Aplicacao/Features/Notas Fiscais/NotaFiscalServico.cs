using AutoMapper;
using FlashCodeNFe.Aplicacao.Features.Notas_Fiscais.Commands;
using FlashCodeNFe.Dominio.Exceptions;
using FlashCodeNFe.Dominio.Features.Destinatarios;
using FlashCodeNFe.Dominio.Features.Emitentes;
using FlashCodeNFe.Dominio.Features.Notas_Fiscais;
using FlashCodeNFe.Dominio.Features.Produtos;
using FlashCodeNFe.Dominio.Features.Transportadores;
using System.Collections.Generic;
using System.Linq;

namespace FlashCodeNFe.Aplicacao.Features.Notas_Fiscais
{
    public class NotaFiscalServico : INotaFiscalServico
    {
        private INotaFiscalRepositorio _notaFiscalRepositorio;
        private IProdutoRepositorio _produtoRepositorio;
        private IEmitenteRepositorio _emitenteRepositorio;
        private ITransportadorRepositorio _transportadorRepositorio;
        private IDestinatarioRepositorio _destinatarioRepositorio;

        public NotaFiscalServico(INotaFiscalRepositorio notaFiscalRepositorio,
            IProdutoRepositorio produtoRepositorio,
            IEmitenteRepositorio emitenteRepositorio,
            ITransportadorRepositorio transportadorRepositorio,
            IDestinatarioRepositorio destinatarioRepositorio)
        {
            _notaFiscalRepositorio = notaFiscalRepositorio;
            _produtoRepositorio = produtoRepositorio;
            _emitenteRepositorio = emitenteRepositorio;
            _transportadorRepositorio = transportadorRepositorio;
            _destinatarioRepositorio = destinatarioRepositorio;
        }
        public long Add(NotaFiscalRegistroCommand notaFiscalRegistrarCommand)
        {
            var notaFiscal = Mapper.Map<NotaFiscalRegistroCommand, NotaFiscal>(notaFiscalRegistrarCommand);

            notaFiscal.Emitente = _emitenteRepositorio
                                   .PegarPorId(notaFiscalRegistrarCommand.EmitenteId);
            notaFiscal.Transportador = _transportadorRepositorio
                                        .PegarPorId(notaFiscalRegistrarCommand.TransportadorId);
            notaFiscal.Destinatario = _destinatarioRepositorio
                                        .PegarPorId(notaFiscalRegistrarCommand.DestinatarioId);

            foreach (var item in notaFiscalRegistrarCommand.ProdutoNota)
            {
                var produtoBD = _produtoRepositorio.PegarPorId(item.ProdutoId);
                notaFiscal.Produtos.Add(produtoBD);

            }

            foreach (var item in notaFiscal.ProdutoNota)
            {
                foreach (var produto in notaFiscalRegistrarCommand.ProdutoNota)
                {
                    var produtoBD = _produtoRepositorio.PegarPorId(item.ProdutoId);
                    item.Produto = produtoBD;
                }
            }

            notaFiscal.Gerar();

            return _notaFiscalRepositorio.Add(notaFiscal).Id;
        }

        public bool AdicionarProduto(ProdutoNotaRegisterCommand produtoNotaRegisterCommand)
        {
            return _notaFiscalRepositorio.AdicionarProduto(produtoNotaRegisterCommand.NotaFiscalId, produtoNotaRegisterCommand.ProdutoId, produtoNotaRegisterCommand.Quantidade);
        }

        public bool Atualizar(NotaFiscalEditarCommand notaFiscalEditarCommand)
        {
            var NotaFiscalDb = _notaFiscalRepositorio.PegarPorId(notaFiscalEditarCommand.Id) ?? throw new NotFoundException();

            Mapper.Map<NotaFiscalEditarCommand, NotaFiscal>(notaFiscalEditarCommand, NotaFiscalDb);

            NotaFiscalDb.Emitente = _emitenteRepositorio
                                   .PegarPorId(notaFiscalEditarCommand.EmitenteId);
            NotaFiscalDb.Transportador = _transportadorRepositorio
                                        .PegarPorId(notaFiscalEditarCommand.TransportadorId);
            NotaFiscalDb.Destinatario = _destinatarioRepositorio
                                        .PegarPorId(notaFiscalEditarCommand.DestinatarioId);

            return _notaFiscalRepositorio.Atualizar(NotaFiscalDb);
        }

        public NotaFiscal PegarPorID(long id)
        {
            return _notaFiscalRepositorio.PegarPorId(id);
        }

        public IQueryable<Produto> PegarPorProdutoPorNota(long notaId)
        {
            return _notaFiscalRepositorio.PegarProdutoPorNota(notaId);
        }


        public IQueryable<NotaFiscal> PegarTodos()
        {
            return _notaFiscalRepositorio.PegarTodos();
        }

        public bool Remover(NotaFiscalRemoverCommand notaFiscalRemoverCommand)
        {
            return _notaFiscalRepositorio.Remover(notaFiscalRemoverCommand.NotasIDs);
        }

        public bool RemoverProdutos(NotaFiscalRemoveProdutosCommand notaFiscalRemoveProdutosCommand)
        {
            return _notaFiscalRepositorio.RemoverProdutos(notaFiscalRemoveProdutosCommand.NotaId, notaFiscalRemoveProdutosCommand.ProdutosIds);
        }
    }
}
