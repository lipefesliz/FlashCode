using FlashCodeNFe.API.Controllers.Common;
using FlashCodeNFe.API.Filters;
using FlashCodeNFe.Aplicacao.Features.Emitentes;
using FlashCodeNFe.Aplicacao.Features.Emitentes.Commands;
using FlashCodeNFe.Aplicacao.Features.Emitentes.Querys;
using FlashCodeNFe.Aplicacao.Features.Emitentes.ViewModels;
using FlashCodeNFe.Dominio.Features.Emitentes;
using Microsoft.AspNet.OData.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FlashCodeNFe.API.Controllers.Features.Emitentes
{
    [RoutePrefix("api/emitentes")]
    public class EmitentesController : ApiControllerBase
    {
        private readonly IEmitenteServico _emitenteService;

        public EmitentesController(IEmitenteServico emitenteService) : base()
        {
            _emitenteService = emitenteService;
        }

        #region HttpGet
        [HttpGet]
        [ODataQueryOptionsValidate]
        public IHttpActionResult Get(ODataQueryOptions<Emitente> queryOptions)
        {
            var query = _emitenteService.PegarTodos();

            return HandleQuery<Emitente, EmitenteViewModel>(query, queryOptions);
        }
        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetById(int id)
        {
            return HandleCallback(() => _emitenteService.PegarPorID(id));
        }
        #endregion

        #region HttpPost
         [HttpPost]
        public IHttpActionResult Post(EmitenteRegistrarCommand productCmd)
        {
            var validator = productCmd.Validate();
            if (!validator.IsValid)
                return HandleValidationFailure(validator.Errors);

            return HandleCallback(() => _emitenteService.Add(productCmd));
        }
        #endregion HttpPost

        #region HttpPut
        [HttpPut]
        public IHttpActionResult Update(EmitenteEditarCommand command)
        {
            var validator = command.Validate();

            if (!validator.IsValid)
                return HandleValidationFailure(validator.Errors);

            return HandleCallback(() => _emitenteService.Atualizar(command));
        }
        #endregion HttpPut

        #region HttpDelete
       [HttpDelete]
        public IHttpActionResult Delete(EmitenteRemoverCommand command)
        {
            var validator = command.Validate();

            if (!validator.IsValid)
                return HandleValidationFailure(validator.Errors);

            return HandleCallback(() => _emitenteService.Remover(command));
        }
        #endregion HttpDelete
    }
}
