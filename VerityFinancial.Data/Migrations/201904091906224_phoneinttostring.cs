namespace VerityFinancial.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class phoneinttostring : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customer", "PhoneNumber", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customer", "PhoneNumber", c => c.Double(nullable: false));
        }
    }
}
