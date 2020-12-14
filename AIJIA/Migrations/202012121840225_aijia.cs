namespace AIJIA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aijia : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        ArticleId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        TypeArticleID = c.Int(nullable: false),
                        MarkID = c.Int(nullable: false),
                        ProviderID = c.Int(nullable: false),
                        Color = c.String(),
                        Size = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        QuantityStock = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ArticleId)
                .ForeignKey("dbo.Marks", t => t.MarkID, cascadeDelete: true)
                .ForeignKey("dbo.Providers", t => t.ProviderID, cascadeDelete: true)
                .ForeignKey("dbo.TypeArticles", t => t.TypeArticleID, cascadeDelete: true)
                .Index(t => t.TypeArticleID)
                .Index(t => t.MarkID)
                .Index(t => t.ProviderID);
            
            CreateTable(
                "dbo.Marks",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Providers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Mail = c.String(nullable: false),
                        phone = c.String(nullable: false),
                        City = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TypeArticles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        IdComment = c.Int(nullable: false, identity: true),
                        NoteArticle = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DateComment = c.DateTime(nullable: false),
                        ArticleID = c.Int(nullable: false),
                        UserID = c.String(),
                    })
                .PrimaryKey(t => t.IdComment)
                .ForeignKey("dbo.Articles", t => t.ArticleID, cascadeDelete: true)
                .Index(t => t.ArticleID);
            
            CreateTable(
                "dbo.Deliveries",
                c => new
                    {
                        IdDelivery = c.Int(nullable: false, identity: true),
                        ModelDeliveryID = c.Int(nullable: false),
                        OrderID = c.Int(nullable: false),
                        RefDelivery = c.String(),
                        DescriptionDelivery = c.String(),
                        DateDelivery = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdDelivery)
                .ForeignKey("dbo.ModelDeliveries", t => t.ModelDeliveryID, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderID, cascadeDelete: true)
                .Index(t => t.ModelDeliveryID)
                .Index(t => t.OrderID);
            
            CreateTable(
                "dbo.ModelDeliveries",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Model = c.String(),
                        DescriptionModel = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DateOrder = c.DateTime(nullable: false),
                        UserID = c.String(),
                        FactureID = c.Int(nullable: false),
                        AmountDelivery = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Factures",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DateFacture = c.DateTime(nullable: false),
                        Vat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ExclVat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InclVat = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        ArticleID = c.Int(nullable: false),
                        SrcImage = c.String(),
                    })
                .PrimaryKey(t => t.ArticleID)
                .ForeignKey("dbo.Articles", t => t.ArticleID)
                .Index(t => t.ArticleID);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ArticleId = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Articles", t => t.ArticleId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.ArticleId)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.StatusOrders",
                c => new
                    {
                        OrderID = c.Int(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Orders", t => t.OrderID)
                .Index(t => t.OrderID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Lastename = c.String(),
                        Firstname = c.String(),
                        PostalCode = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                        City = c.String(),
                        Country = c.String(),
                        Sex = c.String(),
                        Birthday = c.String(),
                        IsAdmin = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.StatusOrders", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.OrderDetails", "ArticleId", "dbo.Articles");
            DropForeignKey("dbo.Images", "ArticleID", "dbo.Articles");
            DropForeignKey("dbo.Deliveries", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.Deliveries", "ModelDeliveryID", "dbo.ModelDeliveries");
            DropForeignKey("dbo.Comments", "ArticleID", "dbo.Articles");
            DropForeignKey("dbo.Articles", "TypeArticleID", "dbo.TypeArticles");
            DropForeignKey("dbo.Articles", "ProviderID", "dbo.Providers");
            DropForeignKey("dbo.Articles", "MarkID", "dbo.Marks");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.StatusOrders", new[] { "OrderID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.OrderDetails", new[] { "OrderId" });
            DropIndex("dbo.OrderDetails", new[] { "ArticleId" });
            DropIndex("dbo.Images", new[] { "ArticleID" });
            DropIndex("dbo.Deliveries", new[] { "OrderID" });
            DropIndex("dbo.Deliveries", new[] { "ModelDeliveryID" });
            DropIndex("dbo.Comments", new[] { "ArticleID" });
            DropIndex("dbo.Articles", new[] { "ProviderID" });
            DropIndex("dbo.Articles", new[] { "MarkID" });
            DropIndex("dbo.Articles", new[] { "TypeArticleID" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.StatusOrders");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Images");
            DropTable("dbo.Factures");
            DropTable("dbo.Orders");
            DropTable("dbo.ModelDeliveries");
            DropTable("dbo.Deliveries");
            DropTable("dbo.Comments");
            DropTable("dbo.TypeArticles");
            DropTable("dbo.Providers");
            DropTable("dbo.Marks");
            DropTable("dbo.Articles");
        }
    }
}
