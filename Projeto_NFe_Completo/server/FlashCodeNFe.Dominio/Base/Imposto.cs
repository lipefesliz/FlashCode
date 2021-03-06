﻿using System.Diagnostics.CodeAnalysis;

namespace FlashCodeNFe.Dominio.Base
{
    [ExcludeFromCodeCoverage]
    public abstract class Imposto
    {
        public decimal ICMS { get; set; }
        public decimal Ipi { get; set; }

        public abstract void CalcularICMS();
        public abstract void CalcularIpi();
    }
}
