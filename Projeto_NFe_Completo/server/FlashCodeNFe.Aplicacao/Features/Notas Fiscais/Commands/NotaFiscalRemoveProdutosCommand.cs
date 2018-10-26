using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCodeNFe.Aplicacao.Features.Notas_Fiscais.Commands
{
   public class NotaFiscalRemoveProdutosCommand
    {
        public virtual long NotaId { get; set; }
        public virtual long[] ProdutosIds { get; set; }

        public virtual ValidationResult Validate()
        {
            return new Validator().Validate(this);
        }

        class Validator : AbstractValidator<NotaFiscalRemoveProdutosCommand>
        {
            public Validator()
            {
                RuleFor(c => c.NotaId).NotNull().GreaterThan(0);
                RuleFor(c => c.ProdutosIds.Length).GreaterThan(0);
                RuleFor(c => c.ProdutosIds).NotEmpty().NotNull() ;
            }
        }
    }
}
