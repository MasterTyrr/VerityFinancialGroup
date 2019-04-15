namespace VerityFinancial.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Bonds : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bond",
                c => new
                    {
                        BondID = c.Int(nullable: false, identity: true),
                        BondGuid = c.Guid(nullable: false),
                        StockName = c.String(nullable: false),
                        StockAbbev = c.String(nullable: false),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CostCurrent = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.BondID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Bond");
        }
    }
}
