namespace Vidlyv2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMoviesData : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MOVIES (name,genreid,dateadded,releasedate,numberinstock) VALUES ('FOREST GUMP',3,'2014-05-02','2016-02-04',4)");
           
        }
        
        public override void Down()
        {
        }
    }
}
