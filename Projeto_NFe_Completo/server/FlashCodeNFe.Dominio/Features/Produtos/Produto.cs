using FlashCodeNFe.Dominio.Base;
using FlashCodeNFe.Dominio.Features.Notas_Fiscais;
using FlashCodeNFe.Dominio.Features.Valores;
using System.Collections.Generic;

namespace FlashCodeNFe.Dominio.Features.Produtos
{
    public class Produto : Entidade
    {
        public int CodigoProduto { get; set; }
        public string Descricao { get; set; }
        public virtual ValorProduto ValorProduto { get; set; }
        public virtual List<NotaFiscal> NotasFiscais { get; set; }

        public Produto()
        {
            ValorProduto = new ValorProduto();
        }
    }
}
