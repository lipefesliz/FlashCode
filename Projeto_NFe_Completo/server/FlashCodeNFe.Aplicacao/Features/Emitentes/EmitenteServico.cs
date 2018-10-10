using AutoMapper;
using FlashCodeNFe.Aplicacao.Features.Emitentes.Commands;
using FlashCodeNFe.Aplicacao.Features.Emitentes.Querys;
using FlashCodeNFe.Dominio.Exceptions;
using FlashCodeNFe.Dominio.Features.Emitentes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCodeNFe.Aplicacao.Features.Emitentes
{
    public class EmitenteServico : IEmitenteServico
    {
        private IEmitenteRepositorio _emitenteRepositorio;

        public EmitenteServico(IEmitenteRepositorio emitenteRepositorio)
        {
            _emitenteRepositorio = emitenteRepositorio;
        }
        public long Add(EmitenteRegistrarCommand emitenteRegistrarCommand)
        {
            var emitente = Mapper.Map<EmitenteRegistrarCommand, Emitente>(emitenteRegistrarCommand);

            return _emitenteRepositorio.Add(emitente).Id;

        }

        public bool Atualizar(EmitenteEditarCommand emitenteEditarCommand)
        {
            var emitenteDb = _emitenteRepositorio.PegarPorId(emitenteEditarCommand.Id) ?? throw new NotFoundException();

            Mapper.Map(emitenteEditarCommand, emitenteDb);

            return _emitenteRepositorio.Atualizar(emitenteDb);
        }

        public EmitenteResource PegarPorID(long id)
        {
            var teste = _emitenteRepositorio.PegarPorId(id);
            
            return Mapper.Map<EmitenteResource>(teste);
        }

        public IQueryable<Emitente> PegarTodos(EmitenteQuery emitenteQuery)
        {
            var ret = emitenteQuery == null || emitenteQuery.Size == 0
                ? _emitenteRepositorio.PegarTodos()
                : _emitenteRepositorio.PegarTodos(emitenteQuery.Size);

            return ret;
        }

        public bool Remover(EmitenteRemoverCommand emitenteRemoverCommand)
        {
            return _emitenteRepositorio.Remover(emitenteRemoverCommand.EmitentesIDs);
        }
    }
}
