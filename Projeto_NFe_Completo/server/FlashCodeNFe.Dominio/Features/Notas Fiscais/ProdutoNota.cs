using FlashCodeNFe.Dominio.Base;
using FlashCodeNFe.Dominio.Features.Produtos;
using FlashCodeNFe.Dominio.Features.Valores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCodeNFe.Dominio.Features.Notas_Fiscais
{
    public class ProdutoNota : Entidade
    {
        public long NotaFiscalId { get; set; }
        public Produto Produto { get; set; }
        public long Quantidade { get; set; }
        public virtual ValorProduto ValorProduto { get; set; }
        public virtual long ProdutoId { get; set; }

        public ProdutoNota()
        {
            ValorProduto = new ValorProduto();
        }
    }
}
