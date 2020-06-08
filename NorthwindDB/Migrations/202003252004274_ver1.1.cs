namespace NorthwindDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ver11 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CreditCards",
                c => new
                    {
                        CreditCardID = c.Int(nullable: false, identity: true),
                        CardNumber = c.Int(nullable: false),
                        ExpiryDate = c.DateTime(nullable: false),
                        CarHolderName = c.String(nullable: false, maxLength: 30),
                        EmployeeID = c.Int(),
                    })
                .PrimaryKey(t => t.CreditCardID)
                .ForeignKey("dbo.Employees", t => t.EmployeeID)
                .Index(t => t.EmployeeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CreditCards", "EmployeeID", "dbo.Employees");
            DropIndex("dbo.CreditCards", new[] { "EmployeeID" });
            DropTable("dbo.CreditCards");
        }
    }
}
