using FlashCodeNFe.Aplicacao.Features.Enderecos.Commands;
using FlashCodeNFe.Dominio.Features.Transportadores;
using FluentValidation;
using FluentValidation.Results;

namespace FlashCodeNFe.Aplicacao.Features.Transportadores.Commands
{
    public class TransportadorEditarCommand
    {
        public long Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual string RazaoSocial { get; set; }
        public virtual string Cpf { get; set; }
        public virtual string Cnpj { get; set; }
        public virtual string InscricaoEstadual { get; set; }
        public virtual EnderecoEditarCommand Endereco { get; set; }
        public Frete ResponsabilidadeFrete { get; set; }

        public virtual ValidationResult Validate()
        {
            return new Validator().Validate(this);
        }

        class Validator : AbstractValidator<TransportadorEditarCommand>
        {
            public Validator()
            {
                RuleFor(c => c.Endereco).NotNull();
                RuleFor(c => c.Endereco.Id).NotNull().NotEmpty().GreaterThan(0);
                RuleFor(c => c.Id).NotEmpty().NotNull().GreaterThan(0);
            }
        }
    }
}
