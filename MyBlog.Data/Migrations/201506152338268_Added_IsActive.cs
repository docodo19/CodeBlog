namespace MyBlog.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_IsActive : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BlogGroups", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Blogs", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Topics", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Topics", "IsActive");
            DropColumn("dbo.Blogs", "IsActive");
            DropColumn("dbo.BlogGroups", "IsActive");
        }
    }
}
