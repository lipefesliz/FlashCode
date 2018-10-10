using FlashCodeNFe.Aplicacao.Features.Enderecos.Commands;
using FluentValidation;
using FluentValidation.Results;

namespace FlashCodeNFe.Aplicacao.Features.Destinatarios.Commands
{
    public class DestinatarioEditarCommand
    {
        public long Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual string RazaoSocial { get; set; }
        public virtual string Cpf { get; set; }
        public virtual string Cnpj { get; set; }
        public virtual string InscricaoEstadual { get; set; }
        public virtual string InscricaoMunicipal { get; set; }
        public virtual EnderecoEditarCommand Endereco { get; set; }

        public virtual ValidationResult Validate()
        {
            return new Validator().Validate(this);
        }

        class Validator : AbstractValidator<DestinatarioEditarCommand>
        {
            public Validator()
            {
                RuleFor(c => c.Endereco).NotNull();
                RuleFor(c => c.Endereco.Id).NotNull().GreaterThan(0);
                RuleFor(c => c.Id).NotEmpty().NotNull().GreaterThan(0);
            }
        }
    }
}
