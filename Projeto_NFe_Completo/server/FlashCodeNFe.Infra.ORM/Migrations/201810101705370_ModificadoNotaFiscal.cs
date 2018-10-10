namespace FlashCodeNFe.Infra.ORM.Initializer
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModificadoNotaFiscal : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.NotaFiscal", "DataEmissao", c => c.DateTime());
            AlterColumn("dbo.NotaFiscal", "ChaveAcesso", c => c.String(maxLength: 50));
            AlterColumn("dbo.NotaFiscal", "Emitido", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.NotaFiscal", "Emitido", c => c.Boolean(nullable: false));
            AlterColumn("dbo.NotaFiscal", "ChaveAcesso", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.NotaFiscal", "DataEmissao", c => c.DateTime(nullable: false));
        }
    }
}
