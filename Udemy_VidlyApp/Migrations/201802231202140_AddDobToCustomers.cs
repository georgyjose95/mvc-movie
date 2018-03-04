namespace Udemy_VidlyApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDobToCustomers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Dob", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Dob");
        }
    }
}
