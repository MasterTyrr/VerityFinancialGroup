namespace VerityFinancial.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stocks : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Stock",
                c => new
                    {
                        StockID = c.Int(nullable: false, identity: true),
                        StockGuid = c.Guid(nullable: false),
                        StockName = c.String(nullable: false),
                        StockAbbev = c.String(nullable: false),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CostCurrent = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.StockID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Stock");
        }
    }
}
