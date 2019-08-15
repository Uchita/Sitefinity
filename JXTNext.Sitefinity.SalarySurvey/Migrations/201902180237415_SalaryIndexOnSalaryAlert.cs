namespace JXTNext.Sitefinity.SalarySurvey.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SalaryIndexOnSalaryAlert : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Salary", new[] { "SiteId" });
            CreateIndex("dbo.Salary", new[] { "SiteId", "Verified", "SalaryAlert" }, name: "IX_SalaryAlert");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Salary", "IX_SalaryAlert");
            CreateIndex("dbo.Salary", "SiteId");
        }
    }
}
