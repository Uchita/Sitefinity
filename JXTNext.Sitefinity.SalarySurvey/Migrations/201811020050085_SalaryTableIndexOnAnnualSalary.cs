namespace JXTNext.Sitefinity.SalarySurvey.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SalaryTableIndexOnAnnualSalary : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Salary", new[] { "SiteId", "Verified", "JobTypeId", "AnnualSalary" }, name: "IX_AnnualSalary");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Salary", "IX_AnnualSalary");
        }
    }
}
