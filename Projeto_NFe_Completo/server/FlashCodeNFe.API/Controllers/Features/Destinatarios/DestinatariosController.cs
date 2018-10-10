using FlashCodeNFe.API.Controllers.Common;
using FlashCodeNFe.API.Filters;
using FlashCodeNFe.Aplicacao.Features.Destinatarios;
using FlashCodeNFe.Aplicacao.Features.Destinatarios.Commands;
using FlashCodeNFe.Aplicacao.Features.Destinatarios.ViewModels;
using FlashCodeNFe.Dominio.Features.Destinatarios;
using Microsoft.AspNet.OData.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FlashCodeNFe.API.Controllers.Features.Destinatarios
{
    [RoutePrefix("api/destinatarios")]
    public class DestinatariosController : ApiControllerBase
    {
        private readonly IDestinatarioServico _destinatarioService;
        public DestinatariosController(IDestinatarioServico destinatarioService) : base()
        {
            _destinatarioService = destinatarioService;
        }


        #region HttpGet
        [HttpGet]
        [ODataQueryOptionsValidate]
        public IHttpActionResult Get(ODataQueryOptions<Destinatario> queryOptions)
        {
            var query = _destinatarioService.PegarTodos();

            return HandleQuery<Destinatario, DestinatarioViewModel>(query, queryOptions);
        }
        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetById(int id)
        {
            return HandleCallback(() => _destinatarioService.PegarPorID(id));
        }
        #endregion

        #region HttpPost
        [HttpPost]
        public IHttpActionResult Post(DestinatarioRegistrarCommand productCmd)
        {
            var validator = productCmd.Validate();
            if (!validator.IsValid)
                return HandleValidationFailure(validator.Errors);

            return HandleCallback(() => _destinatarioService.Add(productCmd));
        }
        #endregion HttpPost

        #region HttpPut
        [HttpPut]
        public IHttpActionResult Update(DestinatarioEditarCommand command)
        {
            var validator = command.Validate();

            if (!validator.IsValid)
                return HandleValidationFailure(validator.Errors);

            return HandleCallback(() => _destinatarioService.Atualizar(command));
        }
        #endregion HttpPut

        #region HttpDelete
        [HttpDelete]
        public IHttpActionResult Delete(DestinatarioRemoverCommand command)
        {
            var validator = command.Validate();

            if (!validator.IsValid)
                return HandleValidationFailure(validator.Errors);

            return HandleCallback(() => _destinatarioService.Remover(command));
        }
        #endregion HttpDelete
    }
}
