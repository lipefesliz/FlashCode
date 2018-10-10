using FlashCodeNFe.API.Controllers.Common;
using FlashCodeNFe.API.Filters;
using FlashCodeNFe.Aplicacao.Features.Produtos;
using FlashCodeNFe.Aplicacao.Features.Produtos.Commands;
using FlashCodeNFe.Aplicacao.Features.Produtos.ViewModels;
using FlashCodeNFe.Dominio.Features.Produtos;
using Microsoft.AspNet.OData.Query;
using System.Web.Http;

namespace FlashCodeNFe.API.Controllers.Features.Produtos
{
    [RoutePrefix("api/produtos")]
    public class ProdutosController : ApiControllerBase
    {
        private readonly IProdutoServico _produtoService;

        public ProdutosController(IProdutoServico produtoService) : base()
        {
            _produtoService = produtoService;
        }

        #region HttpGet
        [HttpGet]
        [ODataQueryOptionsValidate]
        public IHttpActionResult Get(ODataQueryOptions<Produto> queryOptions)
        {
            var query = _produtoService.PegarTodos();

            return HandleQuery<Produto, ProdutoViewModel>(query, queryOptions);
        }
        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetById(int id)
        {
            return HandleCallback(() => _produtoService.PegarPorID(id));
        }
        #endregion

        #region HttpPost
        [HttpPost]
        public IHttpActionResult Post(ProdutoRegistrarCommand productCmd)
        {
            var validator = productCmd.Validate();
            if (!validator.IsValid)
                return HandleValidationFailure(validator.Errors);

            return HandleCallback(() => _produtoService.Add(productCmd));
        }
        #endregion HttpPost

        #region HttpPut
        [HttpPut]
        public IHttpActionResult Update(ProdutoEditarCommand command)
        {
            var validator = command.Validate();

            if (!validator.IsValid)
                return HandleValidationFailure(validator.Errors);

            return HandleCallback(() => _produtoService.Atualizar(command));
        }
        #endregion HttpPut

        #region HttpDelete
        [HttpDelete]
        public IHttpActionResult Delete(ProdutoRemoverCommand command)
        {
            var validator = command.Validate();

            if (!validator.IsValid)
                return HandleValidationFailure(validator.Errors);

            return HandleCallback(() => _produtoService.Remover(command));
        }
        #endregion HttpDelete
    }
}
