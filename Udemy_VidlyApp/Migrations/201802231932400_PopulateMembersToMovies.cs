namespace Udemy_VidlyApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembersToMovies : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies(Name,ReleaseDate,DateAdded,Stock,GenreId) VALUES('Shutter Island',10-02-2006,11-10-2010,3,1)");
            Sql("INSERT INTO Movies(Name,ReleaseDate,DateAdded,Stock,GenreId) VALUES('Inception',25-10-2015,01-04-2016,8,2)");
            Sql("INSERT INTO Movies(Name,ReleaseDate,DateAdded,Stock,GenreId) VALUES('The Conjuring',12-06-2012,19-12-2012,4,3)");
            Sql("INSERT INTO Movies(Name,ReleaseDate,DateAdded,Stock,GenreId) VALUES('The Mask',05-03-1996,10-10-2000,7,4)");
            Sql("INSERT INTO Movies(Name,ReleaseDate,DateAdded,Stock,GenreId) VALUES('Interstellar',13-08-2017,14-02-2018,1,2)");
            Sql("INSERT INTO Movies(Name,ReleaseDate,DateAdded,Stock,GenreId) VALUES('Insidious',23-09-2006,12-12-2010,12,3)");
        }
        
        public override void Down()
        {
        }
    }
}
