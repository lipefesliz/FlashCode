
using FlashCodeNFe.Dominio.Features.Produtos;
using System.Data.Entity.ModelConfiguration;
using System.Diagnostics.CodeAnalysis;

namespace FlashCodeNFe.Infra.ORM.Features.Orders
{
    [ExcludeFromCodeCoverage]
    public class ProdutoEntityConfiguration : EntityTypeConfiguration<Produto>
    {
        public ProdutoEntityConfiguration()
        {
            ToTable("Produto");
            this.HasKey(p => p.Id);

            this.Property(p => p.Descricao).HasMaxLength(50).IsRequired();
            this.Property(p => p.CodigoProduto).IsRequired();
            this.Property(p => p.ValorProduto.ICMS).IsRequired();
            this.Property(p => p.ValorProduto.Ipi).IsRequired();
            this.Property(p => p.ValorProduto.Unitario).IsRequired();
            this.Property(p => p.ValorProduto.Total).IsRequired();

        }
    }
}
