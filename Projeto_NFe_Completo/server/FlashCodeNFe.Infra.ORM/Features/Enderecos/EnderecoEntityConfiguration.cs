using FlashCodeNFe.Dominio.Features.Enderecos;
using System.Data.Entity.ModelConfiguration;
using System.Diagnostics.CodeAnalysis;

namespace FlashCodeNFe.Infra.ORM.Features.Orders
{
    [ExcludeFromCodeCoverage]
    public class EnderecoEntityConfiguration : EntityTypeConfiguration<Endereco>
    {
        public EnderecoEntityConfiguration()
        {
            ToTable("Endereco");
            this.HasKey(e => e.Id);

            this.Property(e => e.Logradouro).HasMaxLength(50).IsRequired(); ;
            this.Property(e => e.Bairro).HasMaxLength(50).IsRequired(); ;
            this.Property(e => e.Municipio).HasMaxLength(20).IsRequired(); ;
            this.Property(e => e.Estado).HasMaxLength(20).IsRequired(); ;
            this.Property(e => e.Pais).HasMaxLength(10).IsRequired();
            this.Property(e => e.Numero).IsRequired();
            this.Property(e => e.Cep).HasMaxLength(10).IsRequired();
        }
    }
}
