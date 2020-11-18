namespace AIJIA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aijiaModelsVal : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Providers", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Providers", "Mail", c => c.String(nullable: false));
            AlterColumn("dbo.Providers", "phone", c => c.String(nullable: false));
            AlterColumn("dbo.Providers", "City", c => c.String(nullable: false));
            AlterColumn("dbo.TypeArticles", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TypeArticles", "Name", c => c.String());
            AlterColumn("dbo.Providers", "City", c => c.String());
            AlterColumn("dbo.Providers", "phone", c => c.String());
            AlterColumn("dbo.Providers", "Mail", c => c.String());
            AlterColumn("dbo.Providers", "Name", c => c.String());
        }
    }
}
