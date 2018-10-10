using FlashCodeNFe.Aplicacao.Features.Enderecos.ViewModels;

namespace FlashCodeNFe.Aplicacao.Features.Emitentes.ViewModels
{
    public class EmitenteViewModel
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string RazaoSocial { get; set; }
        public string Cpf { get; set; }
        public string Cnpj { get; set; }
        public string InscricaoEstadual { get; set; }
        public string InscricaoMunicipal { get; set; }
        public string Cidade { get; set; }
    }
}
