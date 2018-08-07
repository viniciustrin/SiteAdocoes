namespace SiteAdocoes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterandoAdotante : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Adotantes", "Telefone", c => c.String(nullable: false, maxLength: 11));
            DropColumn("dbo.Adotantes", "RG");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Adotantes", "RG", c => c.String(nullable: false, maxLength: 14));
            AlterColumn("dbo.Adotantes", "Telefone", c => c.String());
        }
    }
}
