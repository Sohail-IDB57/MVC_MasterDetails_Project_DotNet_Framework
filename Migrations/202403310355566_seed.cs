namespace MVCProject_1280293.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seed : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                {
                    CourseId = c.Int(nullable: false, identity: true),
                    CourseName = c.String(),
                    CourseCategoryId = c.Int(nullable: false),
                    Duration = c.String(),
                    CourseFee = c.Decimal(nullable: false, precision: 18, scale: 2),
                })
                .PrimaryKey(t => t.CourseId);
        }
        
        public override void Down()
        {
            DropTable("dbo.Courses");
        }
    }
}
