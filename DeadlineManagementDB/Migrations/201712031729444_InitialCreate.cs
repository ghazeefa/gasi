namespace DeadlineManagementDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 40, unicode: false),
                        Company_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.Company_Id)
                .Index(t => t.Company_Id);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 40, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 40, unicode: false),
                        Branch_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branches", t => t.Branch_Id)
                .Index(t => t.Branch_Id);
            
            CreateTable(
                "dbo.FileCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FileToUploadedDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateToBeEntery = c.DateTime(),
                        Department_Id = c.Int(),
                        FileType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.Department_Id)
                .ForeignKey("dbo.FileTypes", t => t.FileType_Id)
                .Index(t => t.Department_Id)
                .Index(t => t.FileType_Id);
            
            CreateTable(
                "dbo.FileTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 40, unicode: false),
                        ReviseagainMonths = c.Int(nullable: false),
                        FileCategory_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FileCategories", t => t.FileCategory_Id)
                .Index(t => t.FileCategory_Id);
            
            CreateTable(
                "dbo.FileUploadeds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Path = c.String(maxLength: 100, unicode: false),
                        DateOfEntery = c.DateTime(nullable: false),
                        DateEntered = c.DateTime(),
                        FileUploadedDetail_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FileToUploadedDetails", t => t.FileUploadedDetail_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.FileUploadedDetail_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 20, unicode: false),
                        SecondName = c.String(maxLength: 20, unicode: false),
                        Password = c.String(maxLength: 20, unicode: false),
                        IsActive = c.Boolean(),
                        Department_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.Department_Id)
                .Index(t => t.Department_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FileUploadeds", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "Department_Id", "dbo.Departments");
            DropForeignKey("dbo.FileUploadeds", "FileUploadedDetail_Id", "dbo.FileToUploadedDetails");
            DropForeignKey("dbo.FileToUploadedDetails", "FileType_Id", "dbo.FileTypes");
            DropForeignKey("dbo.FileTypes", "FileCategory_Id", "dbo.FileCategories");
            DropForeignKey("dbo.FileToUploadedDetails", "Department_Id", "dbo.Departments");
            DropForeignKey("dbo.Departments", "Branch_Id", "dbo.Branches");
            DropForeignKey("dbo.Branches", "Company_Id", "dbo.Companies");
            DropIndex("dbo.Users", new[] { "Department_Id" });
            DropIndex("dbo.FileUploadeds", new[] { "User_Id" });
            DropIndex("dbo.FileUploadeds", new[] { "FileUploadedDetail_Id" });
            DropIndex("dbo.FileTypes", new[] { "FileCategory_Id" });
            DropIndex("dbo.FileToUploadedDetails", new[] { "FileType_Id" });
            DropIndex("dbo.FileToUploadedDetails", new[] { "Department_Id" });
            DropIndex("dbo.Departments", new[] { "Branch_Id" });
            DropIndex("dbo.Branches", new[] { "Company_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.FileUploadeds");
            DropTable("dbo.FileTypes");
            DropTable("dbo.FileToUploadedDetails");
            DropTable("dbo.FileCategories");
            DropTable("dbo.Departments");
            DropTable("dbo.Companies");
            DropTable("dbo.Branches");
        }
    }
}
