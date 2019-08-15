namespace JXTNext.Sitefinity.SalarySurvey.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SalaryCareerMoveTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SalaryCareerMove",
                c => new
                    {
                        SalaryId = c.Long(nullable: false),
                        CareerMoveId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.SalaryId, t.CareerMoveId })
                .ForeignKey("dbo.Salary", t => t.SalaryId, cascadeDelete: true)
                .Index(t => t.SalaryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SalaryCareerMove", "SalaryId", "dbo.Salary");
            DropIndex("dbo.SalaryCareerMove", new[] { "SalaryId" });
            DropTable("dbo.SalaryCareerMove");
        }
    }
}
