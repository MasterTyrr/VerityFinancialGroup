namespace VerityFinancial.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testingAbbevs : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ClientPortfolio", "StockAbbev", c => c.String());
            AddColumn("dbo.ClientPortfolio", "BondAbbev", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ClientPortfolio", "BondAbbev");
            DropColumn("dbo.ClientPortfolio", "StockAbbev");
        }
    }
}
