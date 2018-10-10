namespace FlashCodeNFe.Infra.ORM.Initializer
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Produto", "NotaFiscal_Id", "dbo.NotaFiscal");
            DropIndex("dbo.Produto", new[] { "NotaFiscal_Id" });
            CreateTable(
                "dbo.NotaFiscal_Produto",
                c => new
                    {
                        NotaFiscalId = c.Long(nullable: false),
                        ProdutoId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.NotaFiscalId, t.ProdutoId })
                .ForeignKey("dbo.NotaFiscal", t => t.NotaFiscalId, cascadeDelete: true)
                .ForeignKey("dbo.Produto", t => t.ProdutoId, cascadeDelete: true)
                .Index(t => t.NotaFiscalId)
                .Index(t => t.ProdutoId);
            
            DropColumn("dbo.Produto", "NotaFiscal_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Produto", "NotaFiscal_Id", c => c.Long());
            DropForeignKey("dbo.NotaFiscal_Produto", "ProdutoId", "dbo.Produto");
            DropForeignKey("dbo.NotaFiscal_Produto", "NotaFiscalId", "dbo.NotaFiscal");
            DropIndex("dbo.NotaFiscal_Produto", new[] { "ProdutoId" });
            DropIndex("dbo.NotaFiscal_Produto", new[] { "NotaFiscalId" });
            DropTable("dbo.NotaFiscal_Produto");
            CreateIndex("dbo.Produto", "NotaFiscal_Id");
            AddForeignKey("dbo.Produto", "NotaFiscal_Id", "dbo.NotaFiscal", "Id");
        }
    }
}
