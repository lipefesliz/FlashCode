using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCodeNFe.Aplicacao.Features.Emitentes.Commands
{
    public class EmitenteRemoverCommand
    {
        public virtual long[] EmitentesIDs { get; set; }

        public virtual ValidationResult Validate()
        {
            return new Validator().Validate(this);
        }

        class Validator : AbstractValidator<EmitenteRemoverCommand>
        {
            public Validator()
            {
                RuleFor(c => c.EmitentesIDs).NotNull();
                RuleFor(c => c.EmitentesIDs.Length).GreaterThan(0);
            }
        }
    }
}
