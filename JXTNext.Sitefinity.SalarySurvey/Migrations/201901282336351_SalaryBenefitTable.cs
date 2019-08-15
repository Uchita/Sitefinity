namespace JXTNext.Sitefinity.SalarySurvey.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SalaryBenefitTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SalaryBenefit",
                c => new
                    {
                        SalaryId = c.Long(nullable: false),
                        BenefitId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.SalaryId, t.BenefitId })
                .ForeignKey("dbo.Salary", t => t.SalaryId, cascadeDelete: true)
                .Index(t => t.SalaryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SalaryBenefit", "SalaryId", "dbo.Salary");
            DropIndex("dbo.SalaryBenefit", new[] { "SalaryId" });
            DropTable("dbo.SalaryBenefit");
        }
    }
}
