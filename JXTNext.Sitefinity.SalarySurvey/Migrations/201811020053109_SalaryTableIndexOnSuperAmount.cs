namespace JXTNext.Sitefinity.SalarySurvey.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SalaryTableIndexOnSuperAmount : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Salary", new[] { "SiteId", "Verified", "JobTypeId", "SuperAmount" }, name: "IX_SuperAmount");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Salary", "IX_SuperAmount");
        }
    }
}
