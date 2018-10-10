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

namespace FlashCodeNFe.Aplicacao.Features.Enderecos.Commands
{
    public class EnderecoEditarCommand
    {
        public long Id { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Municipio { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public string Cep { get; set; }

        public virtual ValidationResult Validate()
        {
            return new Validator().Validate(this);
        }

        class Validator : AbstractValidator<EnderecoEditarCommand>
        {
            public Validator()
            {
                //RuleFor(c => c.EnderecoId).NotNull().NotEmpty().GreaterThan(0);
                //RuleFor(c => c.Id).NotEmpty().NotNull().GreaterThan(0);
            }
        }
    }
}
