namespace Vidlyv2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewMovies : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MOVIES (name,genreid,dateadded,releasedate,numberinstock) VALUES ('Star Wars ',1,'2016-05-02','2017-02-04',12)");
            Sql("INSERT INTO MOVIES (name,genreid,dateadded,releasedate,numberinstock) VALUES ('007',2,'2014-10-02','2015-09-04',8)");
            Sql("INSERT INTO MOVIES (name,genreid,dateadded,releasedate,numberinstock) VALUES ('Zootopia',2,'2005-12-02','2006-12-30',15)");
        }
        
        public override void Down()
        {
        }
    }
}
