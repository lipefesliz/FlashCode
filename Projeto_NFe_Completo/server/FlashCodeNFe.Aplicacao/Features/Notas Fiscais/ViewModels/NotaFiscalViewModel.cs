using FlashCodeNFe.Aplicacao.Features.Produtos.ViewModels;
using System;

namespace FlashCodeNFe.Aplicacao.Features.Notas_Fiscais.ViewModels
{
    public class NotaFiscalViewModel
    {
        public long Id { get; set; }
        public string NaturezaOperacao { get; set; }
        public DateTime DataEntrada { get; set; }
        public decimal TotalNota { get; set; }
        public string NomeDestinatario { get; set; }
        public string NomeEmitente { get; set; }
        public string NomeTransportador { get; set; }
        public decimal ValorFrete { get; set; }
    }
}
