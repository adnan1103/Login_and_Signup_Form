namespace ManyRelationship.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataAnnotations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PlayLists",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Videos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Desccription = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PlayListVideos",
                c => new
                    {
                        PlayList_ID = c.Int(nullable: false),
                        Video_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PlayList_ID, t.Video_ID })
                .ForeignKey("dbo.PlayLists", t => t.PlayList_ID, cascadeDelete: true)
                .ForeignKey("dbo.Videos", t => t.Video_ID, cascadeDelete: true)
                .Index(t => t.PlayList_ID)
                .Index(t => t.Video_ID);
            
            CreateTable(
                "dbo.PlayListVideo1",
                c => new
                    {
                        PlayList_ID = c.Int(nullable: false),
                        Video_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PlayList_ID, t.Video_ID })
                .ForeignKey("dbo.PlayLists", t => t.PlayList_ID, cascadeDelete: true)
                .ForeignKey("dbo.Videos", t => t.Video_ID, cascadeDelete: true)
                .Index(t => t.PlayList_ID)
                .Index(t => t.Video_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PlayListVideo1", "Video_ID", "dbo.Videos");
            DropForeignKey("dbo.PlayListVideo1", "PlayList_ID", "dbo.PlayLists");
            DropForeignKey("dbo.PlayListVideos", "Video_ID", "dbo.Videos");
            DropForeignKey("dbo.PlayListVideos", "PlayList_ID", "dbo.PlayLists");
            DropIndex("dbo.PlayListVideo1", new[] { "Video_ID" });
            DropIndex("dbo.PlayListVideo1", new[] { "PlayList_ID" });
            DropIndex("dbo.PlayListVideos", new[] { "Video_ID" });
            DropIndex("dbo.PlayListVideos", new[] { "PlayList_ID" });
            DropTable("dbo.PlayListVideo1");
            DropTable("dbo.PlayListVideos");
            DropTable("dbo.Videos");
            DropTable("dbo.PlayLists");
        }
    }
}
