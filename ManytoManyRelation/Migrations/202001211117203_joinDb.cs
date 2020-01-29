namespace ManytoManyRelation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class joinDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseID = c.Int(nullable: false, identity: true),
                        CourseName = c.String(),
                    })
                .PrimaryKey(t => t.CourseID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentID = c.Int(nullable: false, identity: true),
                        StudentName = c.String(),
                    })
                .PrimaryKey(t => t.StudentID);
            
            CreateTable(
                "dbo.StudentCourse",
                c => new
                    {
                        StudentID = c.Int(nullable: false),
                        CourseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.StudentID, t.CourseID })
                .ForeignKey("dbo.Students", t => t.StudentID, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .Index(t => t.StudentID)
                .Index(t => t.CourseID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentCourse", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.StudentCourse", "StudentID", "dbo.Students");
            DropIndex("dbo.StudentCourse", new[] { "CourseID" });
            DropIndex("dbo.StudentCourse", new[] { "StudentID" });
            DropTable("dbo.StudentCourse");
            DropTable("dbo.Students");
            DropTable("dbo.Courses");
        }
    }
}
