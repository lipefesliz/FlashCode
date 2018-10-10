namespace FlashCodeNFe.Dominio.Features.Valores.Aliquotas
{
    public class Aliquota
    {
        private decimal _icms = 0.04m;
        private decimal _ipi = 0.01m;
        public decimal ICMS { get => _icms; set => _icms = value; }
        public decimal Ipi { get => _ipi; set => _ipi = value; }
    }
}
