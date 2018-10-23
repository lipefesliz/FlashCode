using AutoMapper;
using FlashCodeNFe.Aplicacao.Features.Transportadores.Commands;
using FlashCodeNFe.Dominio.Exceptions;
using FlashCodeNFe.Dominio.Features.Transportadores;
using System.Linq;

namespace FlashCodeNFe.Aplicacao.Features.Transportadores
{
    public class TransportadorServico : ITransportadorServico
    {
        private ITransportadorRepositorio _transportadorRepositorio;

        public TransportadorServico(ITransportadorRepositorio transportadorRepositorio)
        {
            _transportadorRepositorio = transportadorRepositorio;
        }
        public long Add(TransportadorRegistrarCommand transportadorRegistrarCommand)
        {
            var transportador = Mapper.Map<TransportadorRegistrarCommand, Transportador>(transportadorRegistrarCommand);

            return _transportadorRepositorio.Add(transportador).Id;

        }

        public bool Atualizar(TransportadorEditarCommand transportadorEditarCommand)
        {
            var transportadorDb = _transportadorRepositorio.PegarPorId(transportadorEditarCommand.Id) ?? throw new NotFoundException();

            Mapper.Map<TransportadorEditarCommand, Transportador>(transportadorEditarCommand, transportadorDb);

            return _transportadorRepositorio.Atualizar(transportadorDb);
        }

        public TransportadorResource PegarPorID(long id)
        {
            var transportador = _transportadorRepositorio.PegarPorId(id);

            return Mapper.Map<TransportadorResource>(transportador);
        }

        public IQueryable<Transportador> PegarTodos()
        {
            return _transportadorRepositorio.PegarTodos();
        }

        public bool Remover(TransportadorRemoverCommand produtoRemoverCommand)
        {
            return _transportadorRepositorio.Remover(produtoRemoverCommand.TransportadoresIDs);
        }
    }
}
