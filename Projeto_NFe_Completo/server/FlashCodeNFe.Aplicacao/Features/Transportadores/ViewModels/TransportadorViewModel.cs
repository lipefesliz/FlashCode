using FlashCodeNFe.Aplicacao.Features.Enderecos.ViewModels;
using FlashCodeNFe.Dominio.Features.Transportadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCodeNFe.Aplicacao.Features.Transportadores.ViewModels
{
    public class TransportadorViewModel
    {
        public long Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Cpf { get; set; }
        public virtual string Cnpj { get; set; }
        public string Cidade { get; set; }

    }
}
