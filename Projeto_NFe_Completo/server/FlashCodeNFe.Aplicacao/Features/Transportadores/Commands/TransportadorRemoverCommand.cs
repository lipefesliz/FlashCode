using FluentValidation;
using FluentValidation.Results;

namespace FlashCodeNFe.Aplicacao.Features.Transportadores.Commands
{
    public class TransportadorRemoverCommand
    {
        public virtual long[] TransportadoresIDs { get; set; }

        public virtual ValidationResult Validate()
        {
            return new Validator().Validate(this);
        }

        class Validator : AbstractValidator<TransportadorRemoverCommand>
        {
            public Validator()
            {
                RuleFor(c => c.TransportadoresIDs).NotNull();
                RuleFor(c => c.TransportadoresIDs.Length).GreaterThan(0);
            }
        }
    }
}
