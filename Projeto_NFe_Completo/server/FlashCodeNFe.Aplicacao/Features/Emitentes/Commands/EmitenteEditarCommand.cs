using FlashCodeNFe.Aplicacao.Features.Enderecos.Commands;
using FlashCodeNFe.Dominio.Features.Enderecos;
using FlashCodeNFe.Infra.Features.Cnpj;
using FlashCodeNFe.Infra.Features.Cpf;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCodeNFe.Aplicacao.Features.Emitentes.Commands
{
    public class EmitenteEditarCommand
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

        class Validator : AbstractValidator<EmitenteEditarCommand>
        {
            public Validator()
            {
                RuleFor(c => c.Id).NotEmpty().NotNull().GreaterThan(0);
            }
        }
    }
}
