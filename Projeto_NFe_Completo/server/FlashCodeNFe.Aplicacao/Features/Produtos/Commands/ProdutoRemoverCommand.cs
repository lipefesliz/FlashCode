using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCodeNFe.Aplicacao.Features.Produtos.Commands
{
    public class ProdutoRemoverCommand
    {
        public virtual long[] ProdutosIDs { get; set; }

        public virtual ValidationResult Validate()
        {
            return new Validator().Validate(this);
        }

        class Validator : AbstractValidator<ProdutoRemoverCommand>
        {
            public Validator()
            {
                RuleFor(c => c.ProdutosIDs).NotNull();
                RuleFor(c => c.ProdutosIDs.Length).GreaterThan(0);
            }
        }
    }
}
