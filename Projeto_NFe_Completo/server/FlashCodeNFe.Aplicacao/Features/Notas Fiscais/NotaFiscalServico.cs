using AutoMapper;
using FlashCodeNFe.Aplicacao.Features.Notas_Fiscais.Commands;
using FlashCodeNFe.Dominio.Exceptions;
using FlashCodeNFe.Dominio.Features.Destinatarios;
using FlashCodeNFe.Dominio.Features.Emitentes;
using FlashCodeNFe.Dominio.Features.Notas_Fiscais;
using FlashCodeNFe.Dominio.Features.Produtos;
using FlashCodeNFe.Dominio.Features.Transportadores;
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
            var NotaFiscal = Mapper.Map<NotaFiscalRegistroCommand, NotaFiscal>(notaFiscalRegistrarCommand);

            NotaFiscal.Emitente = _emitenteRepositorio
                                   .PegarPorId(notaFiscalRegistrarCommand.EmitenteId);
            NotaFiscal.Transportador = _transportadorRepositorio
                                        .PegarPorId(notaFiscalRegistrarCommand.TransportadorId);
            NotaFiscal.Destinatario = _destinatarioRepositorio
                                        .PegarPorId(notaFiscalRegistrarCommand.DestinatarioId);

            foreach (var produtoId in notaFiscalRegistrarCommand.ProdutosId)
            {
                var produto = _produtoRepositorio.PegarPorId(produtoId);
                NotaFiscal.Produtos.Add(produto);
            }
            NotaFiscal.Gerar();
            return _notaFiscalRepositorio.Add(NotaFiscal).Id;
        }

        public bool Atualizar(NotaFiscalEditarCommand NotaFiscalEditarCommand)
        {
            var NotaFiscalDb = _notaFiscalRepositorio.PegarPorId(NotaFiscalEditarCommand.Id) ?? throw new NotFoundException();

            Mapper.Map<NotaFiscalEditarCommand, NotaFiscal>(NotaFiscalEditarCommand, NotaFiscalDb);

            return _notaFiscalRepositorio.Atualizar(NotaFiscalDb);
        }

        public NotaFiscal PegarPorID(long id)
        {
            return _notaFiscalRepositorio.PegarPorId(id);
        }

        public IQueryable<NotaFiscal> PegarTodos()
        {
            return _notaFiscalRepositorio.PegarTodos();
        }

        public bool Remover(NotaFiscalRemoverCommand notaFiscalRemoverCommand)
        {
            return _notaFiscalRepositorio.Remover(notaFiscalRemoverCommand.NotasIDs);
        }
    }
}
