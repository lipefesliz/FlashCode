using FlashCodeNFe.Dominio.Base;
using FlashCodeNFe.Dominio.Features.Valores;

namespace FlashCodeNFe.Dominio.Features.Produtos
{
    public class Produto : Entidade
    {
        public int CodigoProduto { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public virtual ValorProduto ValorProduto { get; set; }

        public Produto()
        {
            ValorProduto = new ValorProduto();
        }

        public void CalcularValorTotal()
        {
            ValorProduto.Total = Quantidade * ValorProduto.Unitario;
        }
    }
}
