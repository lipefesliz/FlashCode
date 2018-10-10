using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCodeNFe.Aplicacao.Features.Notas_Fiscais.Commands
{
    public class NotaFiscalRemoverCommand
    {
        public virtual long[] NotasIDs { get; set; }

        public virtual ValidationResult Validate()
        {
            return new Validator().Validate(this);
        }

        class Validator : AbstractValidator<NotaFiscalRemoverCommand>
        {
            public Validator()
            {
                RuleFor(c => c.NotasIDs).NotNull();
                RuleFor(c => c.NotasIDs.Length).GreaterThan(0);
            }
        }
    }
}
