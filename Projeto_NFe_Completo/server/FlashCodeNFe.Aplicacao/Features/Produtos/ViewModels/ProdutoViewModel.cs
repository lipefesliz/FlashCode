using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCodeNFe.Aplicacao.Features.Produtos.ViewModels
{
    public class ProdutoViewModel
    {
        public long Id { get; set; }
        public virtual string Descricao { get; set; }
        public decimal Valor { get; set; }
        public int CodigoProduto { get; set; }
    }
}
