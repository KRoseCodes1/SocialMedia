namespace SocialMedia.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangingIDsToWork : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comment", "PostId", "dbo.Post");
            DropForeignKey("dbo.Like", "PostID", "dbo.Post");
            DropPrimaryKey("dbo.Post");
            AddColumn("dbo.Post", "PostId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Post", "PostId");
            AddForeignKey("dbo.Comment", "PostId", "dbo.Post", "PostId", cascadeDelete: true);
            AddForeignKey("dbo.Like", "PostID", "dbo.Post", "PostId", cascadeDelete: true);
            DropColumn("dbo.Post", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Post", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Like", "PostID", "dbo.Post");
            DropForeignKey("dbo.Comment", "PostId", "dbo.Post");
            DropPrimaryKey("dbo.Post");
            DropColumn("dbo.Post", "PostId");
            AddPrimaryKey("dbo.Post", "Id");
            AddForeignKey("dbo.Like", "PostID", "dbo.Post", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Comment", "PostId", "dbo.Post", "Id", cascadeDelete: true);
        }
    }
}
