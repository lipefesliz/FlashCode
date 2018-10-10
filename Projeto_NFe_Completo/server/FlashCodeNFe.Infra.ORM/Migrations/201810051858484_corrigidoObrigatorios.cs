namespace FlashCodeNFe.Infra.ORM.Initializer
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class corrigidoObrigatorios : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Emitente", "InscricaoMunicipal", c => c.String());
            AlterColumn("dbo.Emitente", "RazaoSocial", c => c.String(maxLength: 50));
            AlterColumn("dbo.Emitente", "InscricaoEstadual", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Emitente", "InscricaoEstadual", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Emitente", "RazaoSocial", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Emitente", "InscricaoMunicipal", c => c.String(nullable: false));
        }
    }
}
