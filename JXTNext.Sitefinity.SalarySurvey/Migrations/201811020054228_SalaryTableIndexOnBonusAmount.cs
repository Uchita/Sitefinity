namespace JXTNext.Sitefinity.SalarySurvey.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SalaryTableIndexOnBonusAmount : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Salary", new[] { "SiteId", "Verified", "JobTypeId", "BonusAmount" }, name: "IX_BonusAmount");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Salary", "IX_BonusAmount");
        }
    }
}
