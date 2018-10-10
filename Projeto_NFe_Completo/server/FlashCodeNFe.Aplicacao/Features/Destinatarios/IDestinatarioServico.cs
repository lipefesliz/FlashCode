using FlashCodeNFe.Aplicacao.Features.Destinatarios.Commands;
using FlashCodeNFe.Aplicacao.Features.Destinatarios.Querys;
using FlashCodeNFe.Dominio.Features.Destinatarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCodeNFe.Aplicacao.Features.Destinatarios
{
  public interface IDestinatarioServico
    {
        long Add(DestinatarioRegistrarCommand DestinatarioRegistrarCommand);

        bool Atualizar(DestinatarioEditarCommand DestinatarioEditarCommand);

        Destinatario PegarPorID(long id);

        IQueryable<Destinatario> PegarTodos(DestinatarioQuery emitenteQuery = null);

        bool Remover(DestinatarioRemoverCommand DestinatarioRemoverCommand);
    }
}
