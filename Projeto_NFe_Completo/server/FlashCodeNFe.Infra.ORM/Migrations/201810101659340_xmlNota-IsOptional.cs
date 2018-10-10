namespace FlashCodeNFe.Infra.ORM.Initializer
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class xmlNotaIsOptional : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.NotaFiscal", "NotaFiscalXml", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.NotaFiscal", "NotaFiscalXml", c => c.String(nullable: false));
        }
    }
}
