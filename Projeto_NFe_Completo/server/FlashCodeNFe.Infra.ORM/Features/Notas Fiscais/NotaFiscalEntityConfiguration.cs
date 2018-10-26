using FlashCodeNFe.Dominio.Features.Notas_Fiscais;
using System.Data.Entity.ModelConfiguration;
using System.Diagnostics.CodeAnalysis;

namespace FlashCodeNFe.Infra.ORM.Features.Orders
{
    [ExcludeFromCodeCoverage]
    public class NotaFiscalEntityConfiguration : EntityTypeConfiguration<NotaFiscal>
    {
        public NotaFiscalEntityConfiguration()
        {
            ToTable("NotaFiscal");
            this.HasKey(n => n.Id);

            this.Property(n => n.DataEntrada).IsRequired();
            this.Property(n => n.NaturezaOperacao).HasMaxLength(50).IsRequired();

            this.Property(n => n.Valor.Frete).IsRequired();
            this.Property(n => n.Valor.ICMS).IsRequired();
            this.Property(n => n.Valor.Ipi).IsRequired();
            this.Property(n => n.Valor.TotalProdutos).IsRequired();
            this.Property(n => n.Valor.TotalNota).IsRequired();

            this.Property(n => n.ChaveAcesso)
                .HasMaxLength(50)
                .IsOptional();
            this.Property(n => n.DataEmissao)
                .IsOptional();
            this.Property(n => n.Emitido)
                .IsOptional();
            this.Property(n => n.NotaFiscalXml)
                .IsOptional();

            this.HasRequired(n => n.Destinatario);
            this.HasRequired(n => n.Emitente).WithMany().WillCascadeOnDelete(false);
            this.HasRequired(n => n.Transportador);
            this.Ignore(x => x.Produtos);
            HasMany(x => x.ProdutoNota).WithRequired().HasForeignKey(p => p.NotaFiscalId);
        }
    }
}
