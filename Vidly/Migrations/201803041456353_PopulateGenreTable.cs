namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenreTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres(Name) VALUES('Drama')");
            Sql("INSERT INTO Genres(Name) VALUES('Family')");
            Sql("INSERT INTO Genres(Name) VALUES('Romance')");
            Sql("INSERT INTO Genres(Name) VALUES('Thriller')");
            Sql("INSERT INTO Genres(Name) VALUES('Comedy')");

            Sql("INSERT INTO Movies(Name,GenreId) VALUES ('Shrek',5)");
            Sql("INSERT INTO Movies(Name,GenreId) VALUES ('Wall-E',1)");
        }
        
        public override void Down()
        {
        }
    }
}
