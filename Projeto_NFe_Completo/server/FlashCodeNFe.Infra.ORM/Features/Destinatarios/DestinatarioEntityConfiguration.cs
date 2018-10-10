
using FlashCodeNFe.Dominio.Features.Destinatarios;
using System.Data.Entity.ModelConfiguration;
using System.Diagnostics.CodeAnalysis;

namespace FlashCodeNFe.Infra.ORM.Features.Destinatarios
{
    [ExcludeFromCodeCoverage]
    public class DestinatarioEntityConfiguration : EntityTypeConfiguration<Destinatario>
    {
        public DestinatarioEntityConfiguration()
        {
            ToTable("Destinatario");
            HasKey(d => d.Id);

            Property(d => d.Nome).HasMaxLength(50).IsRequired();
            Property(d => d.RazaoSocial).HasMaxLength(50).IsOptional();
            Property(d => d.InscricaoEstadual).HasMaxLength(50).IsOptional();
            Property(e => e.Cpf).IsOptional();
            Property(e => e.Cnpj).IsOptional();

            HasRequired(d => d.Endereco).WithMany().WillCascadeOnDelete(true);
        }
    }
}
