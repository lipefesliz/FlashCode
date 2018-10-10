using FlashCodeNFe.Aplicacao.Features.Enderecos.Commands;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCodeNFe.Aplicacao.Features.Destinatarios.Commands
{
    public class DestinatarioRegistrarCommand
    {
        public virtual string Nome { get; set; }
        public virtual string RazaoSocial { get; set; }
        public virtual string Cpf { get; set; }
        public virtual string Cnpj { get; set; }
        public virtual string InscricaoEstadual { get; set; }
        public virtual string InscricaoMunicipal { get; set; }
        public virtual EnderecoRegistrarCommand Endereco { get; set; }

        public virtual ValidationResult Validate()
        {
            return new Validator().Validate(this);
        }

        class Validator : AbstractValidator<DestinatarioRegistrarCommand>
        {
            public Validator()
            {
                RuleFor(c => c.Endereco).NotNull();
            }
        }
    }
}
