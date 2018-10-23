using FlashCodeNFe.Dominio.Features.Notas_Fiscais;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCodeNFe.Infra.ORM.Features.Produtos_Notas
{
    public class ProdutoNotaEntityConfiguration : EntityTypeConfiguration<ProdutoNota>
    {
        public ProdutoNotaEntityConfiguration()
        {
            ToTable("ProdutoNota");

            HasKey(x => x.Id);

            Ignore(x => x.ValorProduto);
            Ignore(x => x.ProdutoId);
        }
    }
}
