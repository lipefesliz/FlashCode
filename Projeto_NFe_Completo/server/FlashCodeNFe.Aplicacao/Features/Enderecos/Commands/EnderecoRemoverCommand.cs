using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCodeNFe.Aplicacao.Features.Enderecos.Commands
{
    public class EnderecoRemoverCommand
    {
        public virtual long[] EnderecosIDs { get; set; }

        public virtual ValidationResult Validate()
        {
            return new Validator().Validate(this);
        }

        class Validator : AbstractValidator<EnderecoRemoverCommand>
        {
            public Validator()
            {
                RuleFor(c => c.EnderecosIDs).NotNull();
                RuleFor(c => c.EnderecosIDs.Length).GreaterThan(0);
            }
        }
    }
}
