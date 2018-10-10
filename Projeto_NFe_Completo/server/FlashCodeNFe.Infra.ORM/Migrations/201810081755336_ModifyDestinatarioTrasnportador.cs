namespace FlashCodeNFe.Infra.ORM.Initializer
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyDestinatarioTrasnportador : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transportador", "InscricaoMunicipal", c => c.String());
            AlterColumn("dbo.Destinatario", "RazaoSocial", c => c.String(maxLength: 50));
            AlterColumn("dbo.Destinatario", "InscricaoEstadual", c => c.String(maxLength: 50));
            AlterColumn("dbo.Transportador", "RazaoSocial", c => c.String(maxLength: 50));
            AlterColumn("dbo.Transportador", "InscricaoEstadual", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Transportador", "InscricaoEstadual", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Transportador", "RazaoSocial", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Destinatario", "InscricaoEstadual", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Destinatario", "RazaoSocial", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Transportador", "InscricaoMunicipal");
        }
    }
}
