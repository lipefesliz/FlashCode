using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCodeNFe.Aplicacao.Features.Destinatarios.Commands
{
    public class DestinatarioRemoverCommand
    {
        public virtual long[] DestinatariosIDs { get; set; }

        public virtual ValidationResult Validate()
        {
            return new Validator().Validate(this);
        }

        class Validator : AbstractValidator<DestinatarioRemoverCommand>
        {
            public Validator()
            {
                RuleFor(c => c.DestinatariosIDs).NotNull();
                RuleFor(c => c.DestinatariosIDs.Length).GreaterThan(0);
            }
        }
    }
}
