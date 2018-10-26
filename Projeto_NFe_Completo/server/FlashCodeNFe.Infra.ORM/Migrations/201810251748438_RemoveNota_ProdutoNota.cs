namespace FlashCodeNFe.Infra.ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveNota_ProdutoNota : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProdutoNota", "NotaFiscal_Id", "dbo.NotaFiscal");
            DropIndex("dbo.ProdutoNota", new[] { "NotaFiscal_Id" });
            RenameColumn(table: "dbo.ProdutoNota", name: "NotaFiscal_Id", newName: "NotaFiscalId");
            AlterColumn("dbo.ProdutoNota", "NotaFiscalId", c => c.Long(nullable: false));
            CreateIndex("dbo.ProdutoNota", "NotaFiscalId");
            AddForeignKey("dbo.ProdutoNota", "NotaFiscalId", "dbo.NotaFiscal", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProdutoNota", "NotaFiscalId", "dbo.NotaFiscal");
            DropIndex("dbo.ProdutoNota", new[] { "NotaFiscalId" });
            AlterColumn("dbo.ProdutoNota", "NotaFiscalId", c => c.Long());
            RenameColumn(table: "dbo.ProdutoNota", name: "NotaFiscalId", newName: "NotaFiscal_Id");
            CreateIndex("dbo.ProdutoNota", "NotaFiscal_Id");
            AddForeignKey("dbo.ProdutoNota", "NotaFiscal_Id", "dbo.NotaFiscal", "Id");
        }
    }
}
