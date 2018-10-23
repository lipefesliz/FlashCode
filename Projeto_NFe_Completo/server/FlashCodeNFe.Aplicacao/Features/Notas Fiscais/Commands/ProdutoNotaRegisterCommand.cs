using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCodeNFe.Aplicacao.Features.Notas_Fiscais.Commands
{
    public class ProdutoNotaRegisterCommand
    {
        public virtual long ProdutoId { get; set; }
        public virtual long Quantidade { get; set; }

        public virtual ValidationResult Validate()
        {
            return new Validator().Validate(this);
        }

        class Validator : AbstractValidator<ProdutoNotaRegisterCommand>
        {
            public Validator()
            {
                RuleFor(c => c.ProdutoId).NotEmpty().NotNull().GreaterThan(0);
                RuleFor(c => c.Quantidade).NotEmpty().NotNull().GreaterThan(0);
            }
        }
    }
}
