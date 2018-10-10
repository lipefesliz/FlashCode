using FlashCodeNFe.Dominio.Base;

namespace FlashCodeNFe.Dominio.Features.Enderecos
{
    public class Endereco : Entidade
    {
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Municipio { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public string Cep { get; set; }
        public Endereco() { }
    }
}
