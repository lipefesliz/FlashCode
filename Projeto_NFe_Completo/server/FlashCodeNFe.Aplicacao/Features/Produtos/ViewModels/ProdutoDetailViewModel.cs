using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCodeNFe.Aplicacao.Features.Produtos.ViewModels
{
    public class ProdutoDetailViewModel
    {
        public long Id { get; set; }
        public virtual string Descricao { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal ICMS { get; set; }
        public decimal IPI { get; set; }
        public int CodigoProduto { get; set; }
    }
}
