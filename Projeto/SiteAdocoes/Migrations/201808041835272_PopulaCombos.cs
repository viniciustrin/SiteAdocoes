namespace SiteAdocoes.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulaCombos : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Especies (NomeEspecie) VALUES ('Cachorro')");
            Sql("INSERT INTO Especies (NomeEspecie) VALUES ('Gato')");
            Sql("INSERT INTO Especies (NomeEspecie) VALUES ('Ave')");
            Sql("INSERT INTO Especies (NomeEspecie) VALUES ('Tataruga')");

            Sql("INSERT INTO Portes (NomePorte) VALUES ('Pequeno')");
            Sql("INSERT INTO Portes (NomePorte) VALUES ('Médio')");
            Sql("INSERT INTO Portes (NomePorte) VALUES ('Grande')");
        }
        
        public override void Down()
        {
        }
    }
}
