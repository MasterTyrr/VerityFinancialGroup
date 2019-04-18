namespace VerityFinancial.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intialafterdropdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bond",
                c => new
                    {
                        BondID = c.Int(nullable: false, identity: true),
                        BondGuid = c.Guid(nullable: false),
                        BondName = c.String(nullable: false),
                        BondAbbev = c.String(nullable: false),
                        BCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BCostCurrent = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.BondID);
            
            CreateTable(
                "dbo.ClientPortfolio",
                c => new
                    {
                        PortfolioID = c.Int(nullable: false, identity: true),
                        PortfolioGuid = c.Guid(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        Lastname = c.String(),
                        StockID = c.Int(nullable: false),
                        StockQuantity = c.Int(nullable: false),
                        BondID = c.Int(nullable: false),
                        BondQuantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PortfolioID)
                .ForeignKey("dbo.Bond", t => t.BondID, cascadeDelete: true)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Stock", t => t.StockID, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.StockID)
                .Index(t => t.BondID);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        CustomerGuid = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        PhoneNumber = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.Stock",
                c => new
                    {
                        StockID = c.Int(nullable: false, identity: true),
                        StockGuid = c.Guid(nullable: false),
                        StockName = c.String(nullable: false),
                        StockAbbev = c.String(nullable: false),
                        SCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SCostCurrent = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.StockID);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.RoleId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.ClientPortfolio", "StockID", "dbo.Stock");
            DropForeignKey("dbo.ClientPortfolio", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.ClientPortfolio", "BondID", "dbo.Bond");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.ClientPortfolio", new[] { "BondID" });
            DropIndex("dbo.ClientPortfolio", new[] { "StockID" });
            DropIndex("dbo.ClientPortfolio", new[] { "CustomerId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Stock");
            DropTable("dbo.Customer");
            DropTable("dbo.ClientPortfolio");
            DropTable("dbo.Bond");
        }
    }
}
