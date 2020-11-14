namespace AIJIA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aijiaModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        ArticleId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        TypeArticleID = c.Int(nullable: false),
                        MarkID = c.Int(nullable: false),
                        ProviderID = c.Int(nullable: false),
                        Color = c.String(),
                        Size = c.String(),
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
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Providers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Mail = c.String(),
                        phone = c.String(),
                        City = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TypeArticles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
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
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdComment)
                .ForeignKey("dbo.Articles", t => t.ArticleID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.ArticleID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Lastename = c.String(),
                        Firstname = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        PostalCode = c.String(),
                        City = c.String(),
                        Country = c.String(),
                        Sex = c.String(),
                        Birthday = c.DateTime(nullable: false),
                        IsAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
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
                        UserID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        AmountArticle = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AmountDelivery = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
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
                "dbo.StatusOrders",
                c => new
                    {
                        OrderID = c.Int(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Orders", t => t.OrderID)
                .Index(t => t.OrderID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StatusOrders", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.Images", "ArticleID", "dbo.Articles");
            DropForeignKey("dbo.Deliveries", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.Orders", "UserID", "dbo.Users");
            DropForeignKey("dbo.Deliveries", "ModelDeliveryID", "dbo.ModelDeliveries");
            DropForeignKey("dbo.Comments", "UserID", "dbo.Users");
            DropForeignKey("dbo.Comments", "ArticleID", "dbo.Articles");
            DropForeignKey("dbo.Articles", "TypeArticleID", "dbo.TypeArticles");
            DropForeignKey("dbo.Articles", "ProviderID", "dbo.Providers");
            DropForeignKey("dbo.Articles", "MarkID", "dbo.Marks");
            DropIndex("dbo.StatusOrders", new[] { "OrderID" });
            DropIndex("dbo.Images", new[] { "ArticleID" });
            DropIndex("dbo.Orders", new[] { "UserID" });
            DropIndex("dbo.Deliveries", new[] { "OrderID" });
            DropIndex("dbo.Deliveries", new[] { "ModelDeliveryID" });
            DropIndex("dbo.Comments", new[] { "UserID" });
            DropIndex("dbo.Comments", new[] { "ArticleID" });
            DropIndex("dbo.Articles", new[] { "ProviderID" });
            DropIndex("dbo.Articles", new[] { "MarkID" });
            DropIndex("dbo.Articles", new[] { "TypeArticleID" });
            DropTable("dbo.StatusOrders");
            DropTable("dbo.Images");
            DropTable("dbo.Orders");
            DropTable("dbo.ModelDeliveries");
            DropTable("dbo.Deliveries");
            DropTable("dbo.Users");
            DropTable("dbo.Comments");
            DropTable("dbo.TypeArticles");
            DropTable("dbo.Providers");
            DropTable("dbo.Marks");
            DropTable("dbo.Articles");
        }
    }
}
