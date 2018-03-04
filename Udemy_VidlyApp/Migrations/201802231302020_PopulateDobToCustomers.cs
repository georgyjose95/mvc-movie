namespace Udemy_VidlyApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateDobToCustomers : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE dbo.Customers SET Dob=1995/07/08 WHERE Id=1");
            

        }
        
        public override void Down()
        {
        }
    }
}
