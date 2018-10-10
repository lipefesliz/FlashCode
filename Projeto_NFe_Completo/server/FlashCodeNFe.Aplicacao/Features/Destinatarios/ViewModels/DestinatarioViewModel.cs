using FlashCodeNFe.Aplicacao.Features.Enderecos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCodeNFe.Aplicacao.Features.Destinatarios.ViewModels
{
    public class DestinatarioViewModel
    {
        public long Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual string RazaoSocial { get; set; }
        public virtual string Cpf { get; set; }
        public virtual string Cnpj { get; set; }
        public virtual string InscricaoEstadual { get; set; }
        public virtual string InscricaoMunicipal { get; set; }
        public string Cidade { get; set; }

        public DestinatarioViewModel()
        {

        }
    }
}
