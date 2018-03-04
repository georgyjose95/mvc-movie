namespace Udemy_VidlyApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "memberShipType_Id", "dbo.MemberShipTypes");
            DropIndex("dbo.Customers", new[] { "memberShipType_Id" });
            RenameColumn(table: "dbo.Customers", name: "memberShipType_Id", newName: "MemberShipTypeId");
            AlterColumn("dbo.Customers", "MemberShipTypeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Customers", "MemberShipTypeId");
            AddForeignKey("dbo.Customers", "MemberShipTypeId", "dbo.MemberShipTypes", "Id", cascadeDelete: true);

            Sql("INSERT INTO MembershipTypes(Id,SignUpFee,DurationInMonths,DiscountRate) VALUES (1,0,0,0)");
            Sql("INSERT INTO MembershipTypes(Id,SignUpFee,DurationInMonths,DiscountRate) VALUES (2,30,1,10)");
            Sql("INSERT INTO MembershipTypes(Id,SignUpFee,DurationInMonths,DiscountRate) VALUES (3,90,3,15)");
            Sql("INSERT INTO MembershipTypes(Id,SignUpFee,DurationInMonths,DiscountRate) VALUES (4,300,12,20)");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "MemberShipTypeId", "dbo.MemberShipTypes");
            DropIndex("dbo.Customers", new[] { "MemberShipTypeId" });
            AlterColumn("dbo.Customers", "MemberShipTypeId", c => c.Byte());
            RenameColumn(table: "dbo.Customers", name: "MemberShipTypeId", newName: "memberShipType_Id");
            CreateIndex("dbo.Customers", "memberShipType_Id");
            AddForeignKey("dbo.Customers", "memberShipType_Id", "dbo.MemberShipTypes", "Id");
        }
    }
}
