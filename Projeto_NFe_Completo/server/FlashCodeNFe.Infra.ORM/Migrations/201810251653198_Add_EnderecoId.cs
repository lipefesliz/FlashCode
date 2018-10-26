namespace FlashCodeNFe.Infra.ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_EnderecoId : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Destinatario", name: "Endereco_Id", newName: "EnderecoId");
            RenameColumn(table: "dbo.Emitente", name: "Endereco_Id", newName: "EnderecoId");
            RenameColumn(table: "dbo.Transportador", name: "Endereco_Id", newName: "EnderecoId");
            RenameIndex(table: "dbo.Destinatario", name: "IX_Endereco_Id", newName: "IX_EnderecoId");
            RenameIndex(table: "dbo.Emitente", name: "IX_Endereco_Id", newName: "IX_EnderecoId");
            RenameIndex(table: "dbo.Transportador", name: "IX_Endereco_Id", newName: "IX_EnderecoId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Transportador", name: "IX_EnderecoId", newName: "IX_Endereco_Id");
            RenameIndex(table: "dbo.Emitente", name: "IX_EnderecoId", newName: "IX_Endereco_Id");
            RenameIndex(table: "dbo.Destinatario", name: "IX_EnderecoId", newName: "IX_Endereco_Id");
            RenameColumn(table: "dbo.Transportador", name: "EnderecoId", newName: "Endereco_Id");
            RenameColumn(table: "dbo.Emitente", name: "EnderecoId", newName: "Endereco_Id");
            RenameColumn(table: "dbo.Destinatario", name: "EnderecoId", newName: "Endereco_Id");
        }
    }
}
