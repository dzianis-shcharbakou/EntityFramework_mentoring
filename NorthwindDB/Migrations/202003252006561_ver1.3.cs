namespace NorthwindDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ver13 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Region", newName: "Regions");
            AddColumn("dbo.Customers", "BirthdayDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "BirthdayDate");
            RenameTable(name: "dbo.Regions", newName: "Region");
        }
    }
}
