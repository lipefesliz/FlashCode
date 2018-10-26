using FlashCodeNFe.API.Controllers.Common;
using FlashCodeNFe.API.Filters;
using FlashCodeNFe.Aplicacao.Features.Notas_Fiscais;
using FlashCodeNFe.Aplicacao.Features.Notas_Fiscais.Commands;
using FlashCodeNFe.Aplicacao.Features.Notas_Fiscais.ViewModels;
using FlashCodeNFe.Aplicacao.Features.Produtos.ViewModels;
using FlashCodeNFe.Dominio.Features.Notas_Fiscais;
using FlashCodeNFe.Dominio.Features.Produtos;
using Microsoft.AspNet.OData.Query;
using System;
using System.Linq;
using System.Web.Http;

namespace FlashCodeNFe.API.Controllers.Features.NotasFiscais
{
    [RoutePrefix("api/notasfiscais")]
    public class NotasFiscaisController : ApiControllerBase
    {
        private readonly INotaFiscalServico _notaFiscalService;

        public NotasFiscaisController(INotaFiscalServico notaFiscalService) : base()
        {
            _notaFiscalService = notaFiscalService;
        }

        #region HttpGet
        [HttpGet]
        [ODataQueryOptionsValidate]
        public IHttpActionResult Get(ODataQueryOptions<NotaFiscal> queryOptions)
        {
            var query = _notaFiscalService.PegarTodos();

            return HandleQuery<NotaFiscal, NotaFiscalViewModel>(query, queryOptions);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetById(int id)
        {
            return HandleCallback(() => _notaFiscalService.PegarPorID(id));
        }

        [HttpGet]
        [Route("{id:int}/produtos")]
        public IHttpActionResult GetProductsById(ODataQueryOptions<Produto> queryOptions, [FromUri]int id)
        {
            var query = _notaFiscalService.PegarPorProdutoPorNota(id);

            return HandleQuery<Produto, ProdutoViewModel>(query, queryOptions);
        }
        #endregion

        #region HttpPost
        [HttpPost]
        public IHttpActionResult Post(NotaFiscalRegistroCommand notaFiscalCmd)
        {
            var validator = notaFiscalCmd.Validate();
            if (!validator.IsValid)
                return HandleValidationFailure(validator.Errors);

            return HandleCallback(() => _notaFiscalService.Add(notaFiscalCmd));
        }
        #endregion HttpPost

        #region HttpPut
        [HttpPut]
        public IHttpActionResult Update(NotaFiscalEditarCommand command)
        {
            var validator = command.Validate();

            if (!validator.IsValid)
                return HandleValidationFailure(validator.Errors);

            return HandleCallback(() => _notaFiscalService.Atualizar(command));
        }
        [HttpDelete]
        [Route("produtos")]
        public IHttpActionResult RemoveProdutos(NotaFiscalRemoveProdutosCommand notaFiscalRemoveProdutosCommand)
        {
            var validator = notaFiscalRemoveProdutosCommand.Validate();

            if (!validator.IsValid)
                return HandleValidationFailure(validator.Errors);

            return HandleCallback(() => _notaFiscalService.RemoverProdutos(notaFiscalRemoveProdutosCommand));
        }
        [HttpPatch]
        public IHttpActionResult AdicionarProduto(ProdutoNotaRegisterCommand command)
        {
            var validator = command.Validate();

            if (!validator.IsValid)
                return HandleValidationFailure(validator.Errors);

            return HandleCallback(() => _notaFiscalService.AdicionarProduto(command));
        }
        #endregion HttpPut

        #region HttpDelete
        [HttpDelete]
        public IHttpActionResult Delete(NotaFiscalRemoverCommand command)
        {
            var validator = command.Validate();

            if (!validator.IsValid)
                return HandleValidationFailure(validator.Errors);

            return HandleCallback(() => _notaFiscalService.Remover(command));
        }
        #endregion HttpDelete
    }
}
