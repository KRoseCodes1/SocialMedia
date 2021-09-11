namespace SocialMedia.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixingDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Post",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Text = c.String(nullable: false),
                        AuthorId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Like",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PostID = c.Int(nullable: false),
                        OwnerID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Post", t => t.PostID, cascadeDelete: true)
                .Index(t => t.PostID);
            
            AddColumn("dbo.Comment", "Text", c => c.String());
            AddColumn("dbo.Comment", "AuthorId", c => c.Guid(nullable: false));
            AddColumn("dbo.Comment", "PostId", c => c.Int(nullable: false));
            CreateIndex("dbo.Comment", "PostId");
            AddForeignKey("dbo.Comment", "PostId", "dbo.Post", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Like", "PostID", "dbo.Post");
            DropForeignKey("dbo.Comment", "PostId", "dbo.Post");
            DropIndex("dbo.Like", new[] { "PostID" });
            DropIndex("dbo.Comment", new[] { "PostId" });
            DropColumn("dbo.Comment", "PostId");
            DropColumn("dbo.Comment", "AuthorId");
            DropColumn("dbo.Comment", "Text");
            DropTable("dbo.Like");
            DropTable("dbo.Post");
        }
    }
}
