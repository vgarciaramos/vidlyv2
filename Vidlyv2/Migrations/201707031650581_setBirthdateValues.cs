namespace Vidlyv2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class setBirthdateValues : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET Birthdate = '1983-06-12' WHERE Id = 2");
        }
        
        public override void Down()
        {
        }
    }
}
