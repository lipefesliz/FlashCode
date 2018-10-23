using FlashCodeNFe.Dominio.Features.Destinatarios;
using FlashCodeNFe.Dominio.Features.Emitentes;
using FlashCodeNFe.Dominio.Features.Enderecos;
using FlashCodeNFe.Dominio.Features.Notas_Fiscais;
using FlashCodeNFe.Dominio.Features.Produtos;
using FlashCodeNFe.Dominio.Features.Transportadores;
using System.Data.Common;
using System.Data.Entity;
using System.Diagnostics.CodeAnalysis;

namespace FlashCodeNFe.Infra.ORM.Contexts
{
    /// <summary>
    /// Contexto de banco de dados do FlashCodeNFe
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class FlashCodeNFeDbContext : DbContext
    {
        public FlashCodeNFeDbContext(string connection = "Name=FlashCodeNFeDb") : base(connection)
        {
            this.Configuration.LazyLoadingEnabled = true;
        }

        /// <summary>
        /// Test Only.
        /// 
        /// Esse construtor deve ser chamado pela classe de teste que herdará desse contexto.
        /// Para classes externas esse construtor não está acessível (protected).
        /// 
        /// </summary>
        /// <param name="connection"></param>
        protected FlashCodeNFeDbContext(DbConnection connection) : base(connection, true) { }

        public DbSet<Destinatario> Destinatarios { get; set; }
        public DbSet<Emitente> Emitentes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<NotaFiscal> NotasFiscais { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Transportador> Transportadores { get; set; }
        public DbSet<ProdutoNota> ProdutoNota { get; set; }

        /// <summary>
        /// Método que é executado quando o modelo de banco de dados está sendo criado pelo EF.
        /// Útil para realizar configurações
        /// </summary>
        /// <param name="modelBuilder">É o construtor de modelos do EF</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Busca todos as configurações criadas nesse assembly, que são as classes que são derivadas de EntityTypeConfiguration
            modelBuilder.Configurations.AddFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());
            // Chama o OnModelCreating do EF para dar continuidade na criação do modelo
            base.OnModelCreating(modelBuilder);
        }
    }
}
