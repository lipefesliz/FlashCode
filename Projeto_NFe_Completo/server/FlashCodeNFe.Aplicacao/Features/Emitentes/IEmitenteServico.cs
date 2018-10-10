using FlashCodeNFe.Aplicacao.Features.Emitentes.Commands;
using FlashCodeNFe.Aplicacao.Features.Emitentes.Querys;
using FlashCodeNFe.Dominio.Features.Emitentes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCodeNFe.Aplicacao.Features.Emitentes
{
    public interface IEmitenteServico
    {
        long Add(EmitenteRegistrarCommand emitenteRegistrarCommand);

        bool Atualizar(EmitenteEditarCommand emitenteEditarCommand);

        EmitenteResource PegarPorID(long id);

        IQueryable<Emitente> PegarTodos(EmitenteQuery emitenteQuery = null);

        bool Remover(EmitenteRemoverCommand emitenteRemoverCommand);
    }
}
