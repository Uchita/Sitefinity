namespace JXTNext.Sitefinity.SalarySurvey.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SalaryTableIndexOnHourlyRate : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Salary", new[] { "SiteId", "Verified", "JobTypeId", "HourlyRate" }, name: "IX_HourlyRate");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Salary", "IX_HourlyRate");
        }
    }
}
