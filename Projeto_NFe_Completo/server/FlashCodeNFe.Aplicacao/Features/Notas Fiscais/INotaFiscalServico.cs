using FlashCodeNFe.Aplicacao.Features.Notas_Fiscais.Commands;
using FlashCodeNFe.Dominio.Features.Notas_Fiscais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCodeNFe.Aplicacao.Features.Notas_Fiscais
{
    public interface INotaFiscalServico
    {
        long Add(NotaFiscalRegistroCommand NotaFiscalRegistrarCommand);

        bool Atualizar(NotaFiscalEditarCommand NotaFiscalEditarCommand);

        NotaFiscal PegarPorID(long id);

        IQueryable<NotaFiscal> PegarTodos();

        bool Remover(NotaFiscalRemoverCommand NotaFiscalRemoverCommand);
    }
}
