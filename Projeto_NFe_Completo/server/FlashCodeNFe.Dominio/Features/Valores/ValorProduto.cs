using FlashCodeNFe.Dominio.Base;
using FlashCodeNFe.Dominio.Features.Valores.Aliquotas;

namespace FlashCodeNFe.Dominio.Features.Valores
{
    public class ValorProduto : Imposto
    {
        public ValorProduto()
        {
            Aliquota = new Aliquota();
        }

        public decimal Total { get; set; }
        public decimal Unitario { get; set; }
        public virtual Aliquota Aliquota { get; set; }

        public override void CalcularICMS()
        {
            ICMS = Aliquota.ICMS;
        }

        public override void CalcularIpi()
        {
            Ipi = Aliquota.Ipi;
        }

        public void CalcularTotal()
        {
            Total = ICMS + Ipi + Unitario;
        }
    }
}
