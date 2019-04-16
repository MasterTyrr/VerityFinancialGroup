namespace VerityFinancial.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Stock_Bond_Changes_With_Portfolio_Addition_To_DB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClientPortfolio",
                c => new
                    {
                        PortfolioID = c.Int(nullable: false, identity: true),
                        PortfolioGuid = c.Guid(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PhoneNumber = c.String(),
                        StockID = c.Int(nullable: false),
                        StockName = c.String(),
                        StockAbbev = c.String(),
                        SCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SCostCurrent = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BondID = c.Int(nullable: false),
                        BondName = c.String(),
                        BondAbbev = c.String(),
                        BCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BCostCurrent = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.PortfolioID)
                .ForeignKey("dbo.Bond", t => t.BondID, cascadeDelete: true)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Stock", t => t.StockID, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.StockID)
                .Index(t => t.BondID);
            
            AddColumn("dbo.Bond", "BCost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Bond", "BCostCurrent", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Stock", "SCost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Stock", "SCostCurrent", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Bond", "Cost");
            DropColumn("dbo.Bond", "CostCurrent");
            DropColumn("dbo.Stock", "Cost");
            DropColumn("dbo.Stock", "CostCurrent");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stock", "CostCurrent", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Stock", "Cost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Bond", "CostCurrent", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Bond", "Cost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropForeignKey("dbo.ClientPortfolio", "StockID", "dbo.Stock");
            DropForeignKey("dbo.ClientPortfolio", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.ClientPortfolio", "BondID", "dbo.Bond");
            DropIndex("dbo.ClientPortfolio", new[] { "BondID" });
            DropIndex("dbo.ClientPortfolio", new[] { "StockID" });
            DropIndex("dbo.ClientPortfolio", new[] { "CustomerId" });
            DropColumn("dbo.Stock", "SCostCurrent");
            DropColumn("dbo.Stock", "SCost");
            DropColumn("dbo.Bond", "BCostCurrent");
            DropColumn("dbo.Bond", "BCost");
            DropTable("dbo.ClientPortfolio");
        }
    }
}
