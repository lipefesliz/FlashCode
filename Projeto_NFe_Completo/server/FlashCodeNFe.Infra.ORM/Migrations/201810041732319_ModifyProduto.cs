namespace FlashCodeNFe.Infra.ORM.Initializer
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyProduto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Produto", "ValorProduto_Aliquota_ICMS", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Produto", "ValorProduto_Aliquota_Ipi", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Produto", "ValorProduto_Aliquota_Ipi");
            DropColumn("dbo.Produto", "ValorProduto_Aliquota_ICMS");
        }
    }
}
