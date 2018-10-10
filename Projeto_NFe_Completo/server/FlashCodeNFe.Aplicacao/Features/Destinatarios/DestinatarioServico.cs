using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FlashCodeNFe.Aplicacao.Features.Destinatarios.Commands;
using FlashCodeNFe.Aplicacao.Features.Destinatarios.Querys;
using FlashCodeNFe.Dominio.Exceptions;
using FlashCodeNFe.Dominio.Features.Destinatarios;

namespace FlashCodeNFe.Aplicacao.Features.Destinatarios
{
    public class DestinatarioServico : IDestinatarioServico
    {
        private IDestinatarioRepositorio _destinatarioRepositorio;

        public DestinatarioServico(IDestinatarioRepositorio destinatarioRepositorio)
        {
            _destinatarioRepositorio = destinatarioRepositorio;
        }
        public long Add(DestinatarioRegistrarCommand destinatarioRegistrarCommand)
        {
            var Destinatario = Mapper.Map<DestinatarioRegistrarCommand, Destinatario>(destinatarioRegistrarCommand);

            return _destinatarioRepositorio.Add(Destinatario).Id;

        }

        public bool Atualizar(DestinatarioEditarCommand DestinatarioEditarCommand)
        {
            var DestinatarioDb = _destinatarioRepositorio.PegarPorId(DestinatarioEditarCommand.Id) ?? throw new NotFoundException();

            Mapper.Map<DestinatarioEditarCommand, Destinatario>(DestinatarioEditarCommand, DestinatarioDb);

            return _destinatarioRepositorio.Atualizar(DestinatarioDb);
        }

        public Destinatario PegarPorID(long id)
        {
            return _destinatarioRepositorio.PegarPorId(id);
        }

        public IQueryable<Destinatario> PegarTodos(DestinatarioQuery emitenteQuery)
        {
            var ret = emitenteQuery == null || emitenteQuery.Size == 0
                ? _destinatarioRepositorio.PegarTodos()
                : _destinatarioRepositorio.PegarTodos(emitenteQuery.Size);

            return ret;
        }

        public bool Remover(DestinatarioRemoverCommand DestinatarioRemoverCommand)
        {
            return _destinatarioRepositorio.Remover(DestinatarioRemoverCommand.DestinatariosIDs);
        }
    }
}
