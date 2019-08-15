namespace JXTNext.Sitefinity.SalarySurvey.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SalaryMotivatorTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SalaryMotivator",
                c => new
                    {
                        SalaryId = c.Long(nullable: false),
                        MotivatorId = c.Guid(nullable: false),
                        Position = c.Int(),
                    })
                .PrimaryKey(t => new { t.SalaryId, t.MotivatorId })
                .ForeignKey("dbo.Salary", t => t.SalaryId, cascadeDelete: true)
                .Index(t => t.SalaryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SalaryMotivator", "SalaryId", "dbo.Salary");
            DropIndex("dbo.SalaryMotivator", new[] { "SalaryId" });
            DropTable("dbo.SalaryMotivator");
        }
    }
}
