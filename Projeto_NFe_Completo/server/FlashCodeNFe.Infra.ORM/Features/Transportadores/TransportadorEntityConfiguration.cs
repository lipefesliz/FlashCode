using FlashCodeNFe.Dominio.Features.Transportadores;
using System.Data.Entity.ModelConfiguration;
using System.Diagnostics.CodeAnalysis;

namespace FlashCodeNFe.Infra.ORM.Features.Orders
{
    [ExcludeFromCodeCoverage]
    public class TransportadorEntityConfiguration : EntityTypeConfiguration<Transportador>
    {
        public TransportadorEntityConfiguration()
        {
            ToTable("Transportador");
            HasKey(t => t.Id);

            Property(t => t.Nome).HasMaxLength(50).IsRequired();
            Property(t => t.ResponsabilidadeFrete).IsRequired();

            Property(t => t.RazaoSocial).HasMaxLength(50).IsOptional();
            Property(t => t.InscricaoEstadual).HasMaxLength(50).IsOptional();
            Property(t => t.InscricaoMunicipal).HasMaxLength(50).IsOptional();
            this.Property(e => e.Cpf).IsOptional();
            this.Property(e => e.Cnpj).IsOptional();
            HasRequired(t => t.Endereco).WithMany().WillCascadeOnDelete(true);
        }
    }
}
