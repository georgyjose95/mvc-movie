namespace Udemy_VidlyApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateNameToMemberShipTypes1 : DbMigration
    {
        public override void Up()
        {

            Sql("UPDATE dbo.MemberShipTypes SET Name = 'YEARLY'  WHERE Id = 4 ");
        }
        
        public override void Down()
        {
        }
    }
}
