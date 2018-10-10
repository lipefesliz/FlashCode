using FlashCodeNFe.Dominio.Features.Emitentes;
using System.Data.Entity.ModelConfiguration;
using System.Diagnostics.CodeAnalysis;

namespace FlashCodeNFe.Infra.ORM.Features.Products
{
    [ExcludeFromCodeCoverage]
    public class EmitenteEntityConfiguration : EntityTypeConfiguration<Emitente>
    {
        public EmitenteEntityConfiguration()
        {
            ToTable("Emitente");
            HasKey(e => e.Id);
            
            Property(e => e.Nome).HasMaxLength(50).IsRequired();
            Property(e => e.RazaoSocial).HasMaxLength(50).IsOptional();
            Property(e => e.InscricaoEstadual).HasMaxLength(50).IsOptional();
            Property(e => e.InscricaoMunicipal).IsOptional();
            Property(e => e.Cpf).IsOptional();
            Property(e => e.Cnpj).IsOptional();

            HasRequired(e => e.Endereco).WithMany().WillCascadeOnDelete(true);
        }
    }
}
