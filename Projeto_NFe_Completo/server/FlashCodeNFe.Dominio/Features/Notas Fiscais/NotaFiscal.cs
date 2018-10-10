using FlashCodeNFe.Dominio.Base;
using FlashCodeNFe.Dominio.Features.Destinatarios;
using FlashCodeNFe.Dominio.Features.Emitentes;
using FlashCodeNFe.Dominio.Features.Produtos;
using FlashCodeNFe.Dominio.Features.Transportadores;
using FlashCodeNFe.Dominio.Features.Valores;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FlashCodeNFe.Dominio.Features.Notas_Fiscais
{
    public class NotaFiscal : Entidade
    {
        public NotaFiscal()
        {
            Produtos = new List<Produto>();
            Valor = new ValorNota();
            DataEntrada = DateTime.Now;
        }

        public virtual string NotaFiscalXml { get; set; }
        public string NaturezaOperacao { get; set; }
        public DateTime? DataEmissao { get; set; }
        public DateTime DataEntrada { get; set; }
        public string ChaveAcesso { get; set; }
        public bool Emitido { get; set; }
        public List<Produto> Produtos { get; set; }
        public ValorNota Valor { get; set; }
        public virtual Destinatario Destinatario { get; set; }
        public virtual Emitente Emitente { get; set; }
        public virtual Transportador Transportador { get; set; }

        public int CodigoUfSC = 42;
        public int ModeloNFe = 55;

        Random rnd = new Random();

        public void Emitir()
        {
            Emitido = true;
            DataEmissao = DateTime.Now;
            Gerar();
            GerarChaveAcesso();
            //NotaFiscalXml
        }
        public void Gerar()
        {
            UnirProdutosIguais();
            CalcularValoresProdutos();
            Valor.CalcularICMS();
            Valor.CalcularIpi();
            Valor.CalcularValorNota();
        }
        private void UnirProdutosIguais()
        {
            var produtosAgrupados = Produtos
                .GroupBy(itemId => itemId.Id)
                .Select(prod => new Produto
                {
                    Id = prod.Key,
                    Quantidade = prod.Sum(prodQtd => prodQtd.Quantidade),
                    CodigoProduto = prod.First().CodigoProduto,
                    Descricao = prod.First().Descricao,
                    ValorProduto = new ValorProduto()
                    {
                        ICMS = prod.First().ValorProduto.ICMS,
                        Ipi = prod.First().ValorProduto.Ipi,
                        Total = prod.First().ValorProduto.Total,
                        Unitario = prod.First().ValorProduto.Unitario
                    }
                });
            Produtos = produtosAgrupados.ToList();
        }

        private void CalcularValoresProdutos()
        {
            foreach (var produto in Produtos)
            {
                produto.CalcularValorTotal();
                produto.ValorProduto.CalcularICMS();
                produto.ValorProduto.CalcularIpi();
                Valor.TotalProdutos += produto.ValorProduto.Total;
            }
        }

        private void GerarChaveAcesso()
        {
            string NumeroAleatorio = ((long)rnd.Next(0, 100000) * (long)rnd.Next(0, 100000)).ToString().PadLeft(10, '0');
            ChaveAcesso = string.Concat(CodigoUfSC, DataEntrada.Year, DataEntrada.Month, Emitente.Cnpj, ModeloNFe, NumeroAleatorio);
        }
        
        private void GerarTransportador()
        {
            Transportador = new Transportador();

            Transportador.Nome = Destinatario.Nome;
            Transportador.RazaoSocial = Destinatario.RazaoSocial;
            Transportador.Cpf = Destinatario.Cpf;
            Transportador.Cnpj = Destinatario.Cnpj;
            Transportador.Endereco = Destinatario.Endereco;
            Transportador.InscricaoEstadual = Destinatario.InscricaoEstadual;
            Transportador.ResponsabilidadeFrete = Frete.DESTINATARIO;
        }
    }
}
