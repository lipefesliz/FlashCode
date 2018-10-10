using FlashCodeNFe.API.Controllers.Common;
using FlashCodeNFe.API.Filters;
using FlashCodeNFe.Aplicacao.Features.Transportadores;
using FlashCodeNFe.Aplicacao.Features.Transportadores.Commands;
using FlashCodeNFe.Aplicacao.Features.Transportadores.ViewModels;
using FlashCodeNFe.Dominio.Features.Transportadores;
using Microsoft.AspNet.OData.Query;
using System.Web.Http;

namespace FlashCodeNFe.API.Controllers.Features.Transportadores
{
    [RoutePrefix("api/transportadores")]
    public class TransportadoresController : ApiControllerBase
    {
        private readonly ITransportadorServico _transportadorService;

        public TransportadoresController(ITransportadorServico transportadorService) : base()
        {
            _transportadorService = transportadorService;
        }

        #region HttpGet
        [HttpGet]
        [ODataQueryOptionsValidate]
        public IHttpActionResult Get(ODataQueryOptions<Transportador> queryOptions)
        {
            var query = _transportadorService.PegarTodos();

            return HandleQuery<Transportador, TransportadorViewModel>(query, queryOptions);
        }
        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetById(int id)
        {
            return HandleCallback(() => _transportadorService.PegarPorID(id));
        }
        #endregion

        #region HttpPost
        [HttpPost]
        public IHttpActionResult Post(TransportadorRegistrarCommand productCmd)
        {
            var validator = productCmd.Validate();
            if (!validator.IsValid)
                return HandleValidationFailure(validator.Errors);

            return HandleCallback(() => _transportadorService.Add(productCmd));
        }
        #endregion HttpPost

        #region HttpPut
        [HttpPut]
        public IHttpActionResult Update(TransportadorEditarCommand command)
        {
            var validator = command.Validate();

            if (!validator.IsValid)
                return HandleValidationFailure(validator.Errors);

            return HandleCallback(() => _transportadorService.Atualizar(command));
        }
        #endregion HttpPut

        #region HttpDelete
        [HttpDelete]
        public IHttpActionResult Delete(TransportadorRemoverCommand command)
        {
            var validator = command.Validate();

            if (!validator.IsValid)
                return HandleValidationFailure(validator.Errors);

            return HandleCallback(() => _transportadorService.Remover(command));
        }
        #endregion HttpDelete
    }
}
