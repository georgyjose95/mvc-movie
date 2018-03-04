namespace Udemy_VidlyApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsSubscribedToCustomer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MemberShipTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        SignUpFee = c.Short(nullable: false),
                        DurationInMonths = c.Byte(nullable: false),
                        DiscountRate = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Customers", "IsSuscribed", c => c.Boolean(nullable: false));
            AddColumn("dbo.Customers", "memberShipType_Id", c => c.Byte());
            CreateIndex("dbo.Customers", "memberShipType_Id");
            AddForeignKey("dbo.Customers", "memberShipType_Id", "dbo.MemberShipTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "memberShipType_Id", "dbo.MemberShipTypes");
            DropIndex("dbo.Customers", new[] { "memberShipType_Id" });
            DropColumn("dbo.Customers", "memberShipType_Id");
            DropColumn("dbo.Customers", "IsSuscribed");
            DropTable("dbo.MemberShipTypes");
        }
    }
}
