using FlashCodeNFe.Aplicacao.Features.Enderecos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCodeNFe.Aplicacao.Features.Transportadores
{
    public class TransportadorResource
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string RazaoSocial { get; set; }
        public string Cpf { get; set; }
        public string Cnpj { get; set; }
        public string InscricaoEstadual { get; set; }
        public string InscricaoMunicipal { get; set; }
        public virtual EnderecoViewModel Endereco { get; set; }
    }
}
