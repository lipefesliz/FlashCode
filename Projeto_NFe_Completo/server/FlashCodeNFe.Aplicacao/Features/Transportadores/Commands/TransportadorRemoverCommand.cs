using FluentValidation;
using FluentValidation.Results;

namespace FlashCodeNFe.Aplicacao.Features.Transportadores.Commands
{
    public class TransportadorRemoverCommand
    {
        public virtual long[] DestinatariosIDs { get; set; }

        public virtual ValidationResult Validate()
        {
            return new Validator().Validate(this);
        }

        class Validator : AbstractValidator<TransportadorRemoverCommand>
        {
            public Validator()
            {
                RuleFor(c => c.DestinatariosIDs).NotNull();
                RuleFor(c => c.DestinatariosIDs.Length).GreaterThan(0);
            }
        }
    }
}
