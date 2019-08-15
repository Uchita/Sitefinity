namespace JXTNext.Sitefinity.SalarySurvey.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SalaryRequiredCountryId : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Salary", "CountryId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Salary", "CountryId", c => c.Guid());
        }
    }
}
