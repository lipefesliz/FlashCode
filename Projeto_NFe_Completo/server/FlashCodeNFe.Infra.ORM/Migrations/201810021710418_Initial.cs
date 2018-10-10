namespace FlashCodeNFe.Infra.ORM.Initializer
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Destinatario",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50),
                        RazaoSocial = c.String(nullable: false, maxLength: 50),
                        Cpf = c.String(),
                        Cnpj = c.String(),
                        InscricaoEstadual = c.String(nullable: false, maxLength: 50),
                        Endereco_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Endereco", t => t.Endereco_Id, cascadeDelete: true)
                .Index(t => t.Endereco_Id);
            
            CreateTable(
                "dbo.Endereco",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Logradouro = c.String(nullable: false, maxLength: 50),
                        Numero = c.String(nullable: false),
                        Bairro = c.String(nullable: false, maxLength: 50),
                        Municipio = c.String(nullable: false, maxLength: 20),
                        Estado = c.String(nullable: false, maxLength: 20),
                        Pais = c.String(nullable: false, maxLength: 10),
                        Cep = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Emitente",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        InscricaoMunicipal = c.String(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 50),
                        RazaoSocial = c.String(nullable: false, maxLength: 50),
                        Cpf = c.String(),
                        Cnpj = c.String(),
                        InscricaoEstadual = c.String(nullable: false, maxLength: 50),
                        Endereco_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Endereco", t => t.Endereco_Id, cascadeDelete: true)
                .Index(t => t.Endereco_Id);
            
            CreateTable(
                "dbo.NotaFiscal",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        NotaFiscalXml = c.String(nullable: false),
                        NaturezaOperacao = c.String(nullable: false, maxLength: 50),
                        DataEmissao = c.DateTime(nullable: false),
                        DataEntrada = c.DateTime(nullable: false),
                        ChaveAcesso = c.String(nullable: false, maxLength: 50),
                        Emitido = c.Boolean(nullable: false),
                        Valor_Frete = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Valor_TotalProdutos = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Valor_TotalNota = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Valor_ICMS = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Valor_Ipi = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Destinatario_Id = c.Long(nullable: false),
                        Emitente_Id = c.Long(nullable: false),
                        Transportador_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Destinatario", t => t.Destinatario_Id, cascadeDelete: true)
                .ForeignKey("dbo.Emitente", t => t.Emitente_Id)
                .ForeignKey("dbo.Transportador", t => t.Transportador_Id, cascadeDelete: true)
                .Index(t => t.Destinatario_Id)
                .Index(t => t.Emitente_Id)
                .Index(t => t.Transportador_Id);
            
            CreateTable(
                "dbo.Produto",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CodigoProduto = c.Int(nullable: false),
                        Descricao = c.String(nullable: false, maxLength: 50),
                        Quantidade = c.Int(nullable: false),
                        ValorProduto_Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ValorProduto_Unitario = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ValorProduto_ICMS = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ValorProduto_Ipi = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NotaFiscal_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NotaFiscal", t => t.NotaFiscal_Id)
                .Index(t => t.NotaFiscal_Id);
            
            CreateTable(
                "dbo.Transportador",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ResponsabilidadeFrete = c.Int(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 50),
                        RazaoSocial = c.String(nullable: false, maxLength: 50),
                        Cpf = c.String(),
                        Cnpj = c.String(),
                        InscricaoEstadual = c.String(nullable: false, maxLength: 50),
                        Endereco_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Endereco", t => t.Endereco_Id)
                .Index(t => t.Endereco_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NotaFiscal", "Transportador_Id", "dbo.Transportador");
            DropForeignKey("dbo.Transportador", "Endereco_Id", "dbo.Endereco");
            DropForeignKey("dbo.Produto", "NotaFiscal_Id", "dbo.NotaFiscal");
            DropForeignKey("dbo.NotaFiscal", "Emitente_Id", "dbo.Emitente");
            DropForeignKey("dbo.NotaFiscal", "Destinatario_Id", "dbo.Destinatario");
            DropForeignKey("dbo.Emitente", "Endereco_Id", "dbo.Endereco");
            DropForeignKey("dbo.Destinatario", "Endereco_Id", "dbo.Endereco");
            DropIndex("dbo.Transportador", new[] { "Endereco_Id" });
            DropIndex("dbo.Produto", new[] { "NotaFiscal_Id" });
            DropIndex("dbo.NotaFiscal", new[] { "Transportador_Id" });
            DropIndex("dbo.NotaFiscal", new[] { "Emitente_Id" });
            DropIndex("dbo.NotaFiscal", new[] { "Destinatario_Id" });
            DropIndex("dbo.Emitente", new[] { "Endereco_Id" });
            DropIndex("dbo.Destinatario", new[] { "Endereco_Id" });
            DropTable("dbo.Transportador");
            DropTable("dbo.Produto");
            DropTable("dbo.NotaFiscal");
            DropTable("dbo.Emitente");
            DropTable("dbo.Endereco");
            DropTable("dbo.Destinatario");
        }
    }
}
