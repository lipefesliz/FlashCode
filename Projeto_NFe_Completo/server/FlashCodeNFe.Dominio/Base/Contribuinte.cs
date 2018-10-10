using FlashCodeNFe.Dominio.Features.Enderecos;
using FlashCodeNFe.Infra.Features.Cnpj;
using FlashCodeNFe.Infra.Features.Cpf;
using System.Diagnostics.CodeAnalysis;

namespace FlashCodeNFe.Dominio.Base
{
    [ExcludeFromCodeCoverage]
    public abstract class Contribuinte : Entidade
    {
        private Cpf InfoCpf;
        private Cnpj InfoCnpj;

        public Contribuinte()
        {
            Endereco = new Endereco();
        }

        public string Nome { get; set; }
        public string RazaoSocial { get; set; }
        public string Cpf { get => InfoCpf.valorFormatado; set => InfoCpf = value; }
        public string Cnpj { get => InfoCnpj.valorFormatado; set => InfoCnpj = value; }


        public string InscricaoEstadual { get; set; }
        public string InscricaoMunicipal { get; set; }
        public virtual Endereco Endereco { get; set; }
    }
}
