namespace CrudOperationWithRelation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Datanottion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false),
                        DepartmentName = c.String(),
                    })
                .PrimaryKey(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false),
                        DepartmentID = c.Int(nullable: false),
                        Name = c.String(),
                        Address = c.String(),
                        Email = c.String(),
                        Departments_DepartmentId = c.Int(),
                        Departments_DepartmentId1 = c.Int(),
                    })
                .PrimaryKey(t => new { t.EmployeeId, t.DepartmentID })
                .ForeignKey("dbo.Departments", t => t.DepartmentID, cascadeDelete: true)
                .ForeignKey("dbo.Departments", t => t.Departments_DepartmentId)
                .ForeignKey("dbo.Departments", t => t.Departments_DepartmentId1)
                .Index(t => t.DepartmentID)
                .Index(t => t.Departments_DepartmentId)
                .Index(t => t.Departments_DepartmentId1);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employee", "Departments_DepartmentId1", "dbo.Departments");
            DropForeignKey("dbo.Employee", "Departments_DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Employee", "DepartmentID", "dbo.Departments");
            DropIndex("dbo.Employee", new[] { "Departments_DepartmentId1" });
            DropIndex("dbo.Employee", new[] { "Departments_DepartmentId" });
            DropIndex("dbo.Employee", new[] { "DepartmentID" });
            DropTable("dbo.Employee");
            DropTable("dbo.Departments");
        }
    }
}
