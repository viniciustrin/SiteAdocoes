namespace SiteAdocoes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Adocaos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false),
                        AdotanteId = c.Int(nullable: false),
                        PetId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Adotantes", t => t.AdotanteId)
                .ForeignKey("dbo.Pets", t => t.PetId, cascadeDelete: true)
                .Index(t => t.AdotanteId)
                .Index(t => t.PetId);
            
            CreateTable(
                "dbo.Adotantes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100),
                        Endereco = c.String(nullable: false, maxLength: 300),
                        RG = c.String(nullable: false, maxLength: 14),
                        Telefone = c.String(),
                        EspecieId = c.Int(nullable: false),
                        PorteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Especies", t => t.EspecieId, cascadeDelete: true)
                .ForeignKey("dbo.Portes", t => t.PorteId, cascadeDelete: true)
                .Index(t => t.EspecieId)
                .Index(t => t.PorteId);
            
            CreateTable(
                "dbo.Especies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomeEspecie = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Portes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomePorte = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100),
                        Raca = c.String(nullable: false, maxLength: 100),
                        Castrado = c.Boolean(nullable: false),
                        Observacao = c.String(maxLength: 300),
                        Adotado = c.Boolean(nullable: false),
                        Vacinado = c.Boolean(nullable: false),
                        Idade = c.Int(nullable: false),
                        DataAlteracao = c.DateTime(nullable: false),
                        EspecieId = c.Int(nullable: false),
                        PorteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Especies", t => t.EspecieId, cascadeDelete: true)
                .ForeignKey("dbo.Portes", t => t.PorteId, cascadeDelete: true)
                .Index(t => t.EspecieId)
                .Index(t => t.PorteId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Nome = c.String(nullable: false, maxLength: 100),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Adocaos", "PetId", "dbo.Pets");
            DropForeignKey("dbo.Pets", "PorteId", "dbo.Portes");
            DropForeignKey("dbo.Pets", "EspecieId", "dbo.Especies");
            DropForeignKey("dbo.Adocaos", "AdotanteId", "dbo.Adotantes");
            DropForeignKey("dbo.Adotantes", "PorteId", "dbo.Portes");
            DropForeignKey("dbo.Adotantes", "EspecieId", "dbo.Especies");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Pets", new[] { "PorteId" });
            DropIndex("dbo.Pets", new[] { "EspecieId" });
            DropIndex("dbo.Adotantes", new[] { "PorteId" });
            DropIndex("dbo.Adotantes", new[] { "EspecieId" });
            DropIndex("dbo.Adocaos", new[] { "PetId" });
            DropIndex("dbo.Adocaos", new[] { "AdotanteId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Pets");
            DropTable("dbo.Portes");
            DropTable("dbo.Especies");
            DropTable("dbo.Adotantes");
            DropTable("dbo.Adocaos");
        }
    }
}
