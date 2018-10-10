using FlashCodeNFe.Aplicacao.Features.Enderecos.Commands;
using FlashCodeNFe.Dominio.Features.Transportadores;
using FluentValidation;
using FluentValidation.Results;

namespace FlashCodeNFe.Aplicacao.Features.Transportadores.Commands
{
    public class TransportadorRegistrarCommand
    {
        public virtual string Nome { get; set; }
        public virtual string RazaoSocial { get; set; }
        public virtual string Cpf { get; set; }
        public virtual string Cnpj { get; set; }
        public virtual string InscricaoEstadual { get; set; }
        public virtual EnderecoRegistrarCommand Endereco { get; set; }
        public Frete ResponsabilidadeFrete { get; set; }

        public virtual ValidationResult Validate()
        {
            return new Validator().Validate(this);
        }

        class Validator : AbstractValidator<TransportadorRegistrarCommand>
        {
            public Validator()
            {
                RuleFor(c => c.Endereco).NotNull();
            }
        }
    }
}
