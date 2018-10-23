using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCodeNFe.Aplicacao.Features.Produtos.Commands
{
    public class ProdutoEditarCommand
    {
        public long Id { get; set; }
        public virtual string Descricao { get; set; }
        public virtual decimal Valor { get; set; }
        public virtual string CodigoProduto { get; set; }

        public virtual ValidationResult Validate()
        {
            return new Validator().Validate(this);
        }

        class Validator : AbstractValidator<ProdutoEditarCommand>
        {
            public Validator()
            {
                RuleFor(c => c.Id).NotEmpty().NotNull().GreaterThan(0);
                RuleFor(c => c.Descricao).NotNull().NotEmpty();
                RuleFor(c => c.CodigoProduto).NotNull().NotEmpty();
                RuleFor(c => c.Valor).NotEmpty().NotNull().GreaterThan(0);
            }
        }
    }
}
