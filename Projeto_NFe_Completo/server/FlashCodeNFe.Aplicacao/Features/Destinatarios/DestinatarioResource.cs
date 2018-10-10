using FlashCodeNFe.Aplicacao.Features.Enderecos.ViewModels;

namespace FlashCodeNFe.Aplicacao.Features.Destinatarios
{
    public class DestinatarioResource
    {
        public string Nome { get; set; }
        public string RazaoSocial { get; set; }
        public string Cpf { get; set; }
        public string Cnpj { get; set; }
        public string InscricaoEstadual { get; set; }
        public virtual EnderecoViewModel Endereco { get; set; }
    }
}
