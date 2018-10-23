using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCodeNFe.Aplicacao.Features.Produtos.Commands
{
    public class ProdutoRegistrarCommand
    {
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public int CodigoProduto { get; set; }
        
        public virtual ValidationResult Validate()
        {
            return new Validator().Validate(this);
        }

        class Validator : AbstractValidator<ProdutoRegistrarCommand>
        {
            public Validator()
            {
                RuleFor(c => c.Descricao).NotNull().NotEmpty();
                RuleFor(c => c.CodigoProduto).NotNull().NotEmpty();
                RuleFor(c => c.Valor).NotEmpty().NotNull().GreaterThan(0);
            }
        }
    }
}
