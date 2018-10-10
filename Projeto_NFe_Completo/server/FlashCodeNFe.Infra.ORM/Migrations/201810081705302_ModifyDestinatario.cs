namespace FlashCodeNFe.Infra.ORM.Initializer
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyDestinatario : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Destinatario", "InscricaoMunicipal", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Destinatario", "InscricaoMunicipal");
        }
    }
}
