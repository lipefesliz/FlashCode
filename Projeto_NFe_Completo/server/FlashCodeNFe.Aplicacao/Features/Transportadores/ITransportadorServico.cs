using FlashCodeNFe.Aplicacao.Features.Transportadores.Commands;
using FlashCodeNFe.Dominio.Features.Transportadores;
using System.Linq;

namespace FlashCodeNFe.Aplicacao.Features.Transportadores
{
    public interface ITransportadorServico
    {
        long Add(TransportadorRegistrarCommand transportadorRegistrarCommand);

        bool Atualizar(TransportadorEditarCommand transportadorEditarCommand);

        TransportadorResource PegarPorID(long id);

        IQueryable<Transportador> PegarTodos();

        bool Remover(TransportadorRemoverCommand transportadorRemoverCommand);
    }
}
