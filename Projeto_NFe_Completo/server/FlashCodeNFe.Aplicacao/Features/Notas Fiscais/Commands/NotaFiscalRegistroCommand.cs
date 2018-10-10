using FlashCodeNFe.Aplicacao.Features.Produtos.ViewModels;
using FlashCodeNFe.Dominio.Features.Valores;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCodeNFe.Aplicacao.Features.Notas_Fiscais.Commands
{
    public class NotaFiscalRegistroCommand
    {
        public virtual string NaturezaOperacao { get; set; }
        public DateTime DataEntrada { get; set; }
        public int[] ProdutosId { get; set; }
        public decimal Frete { get; set; }
        public decimal TotalProdutos { get; set; }
        public virtual long DestinatarioId { get; set; }
        public virtual long EmitenteId { get; set; }
        public virtual long TransportadorId { get; set; }

        public virtual ValidationResult Validate()
        {
            return new Validator().Validate(this);
        }

        class Validator : AbstractValidator<NotaFiscalRegistroCommand>
        {
            public Validator()
            {   
                RuleFor(c => c.DestinatarioId).NotNull().NotEmpty().GreaterThan(0);
                RuleFor(c => c.EmitenteId).NotNull().NotEmpty().GreaterThan(0);
                RuleFor(c => c.TransportadorId).NotNull().NotEmpty().GreaterThan(0);
                RuleFor(c => c.NaturezaOperacao).NotNull().NotEmpty();
                RuleFor(c => c.DataEntrada).NotEmpty().NotNull();
                RuleFor(c => c.ProdutosId).NotEmpty().NotNull();
                RuleFor(c => c.Frete).NotEmpty().NotNull();
                RuleFor(c => c.TotalProdutos).NotEmpty().NotNull();
            }
        }
    }
}
