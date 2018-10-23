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
            ProdutoNota = new List<ProdutoNota>();
            Valor = new ValorNota();
            DataEntrada = DateTime.Now;
            Produtos = new List<Produto>();
        }

        public virtual string NotaFiscalXml { get; set; }
        public string NaturezaOperacao { get; set; }
        public DateTime? DataEmissao { get; set; }
        public DateTime DataEntrada { get; internal set; }
        public string ChaveAcesso { get; set; }
        public bool Emitido { get; set; }
        public List<ProdutoNota> ProdutoNota { get; set; }
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
            CalcularValoresProdutos();
            Valor.CalcularICMS();
            Valor.CalcularIpi();
            Valor.CalcularValorNota();
        }

        private void CalcularValoresProdutos()
        {
            foreach (var produto in Produtos)
            {
                foreach (var item in this.ProdutoNota)
                {
                    Valor.TotalProdutos += (produto.ValorProduto.Total * item.Quantidade);
                }
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
