namespace VerityFinancial.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BondsUpdatedBeforeLaunch : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bond", "BondName", c => c.String(nullable: false));
            AddColumn("dbo.Bond", "BondAbbev", c => c.String(nullable: false));
            DropColumn("dbo.Bond", "StockName");
            DropColumn("dbo.Bond", "StockAbbev");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bond", "StockAbbev", c => c.String(nullable: false));
            AddColumn("dbo.Bond", "StockName", c => c.String(nullable: false));
            DropColumn("dbo.Bond", "BondAbbev");
            DropColumn("dbo.Bond", "BondName");
        }
    }
}
