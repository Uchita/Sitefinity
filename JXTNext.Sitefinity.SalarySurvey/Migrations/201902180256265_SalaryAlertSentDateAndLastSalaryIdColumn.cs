namespace JXTNext.Sitefinity.SalarySurvey.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SalaryAlertSentDateAndLastSalaryIdColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Salary", "AlertSentDate", c => c.DateTime());
            AddColumn("dbo.Salary", "AlertLastSalaryId", c => c.Long());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Salary", "AlertLastSalaryId");
            DropColumn("dbo.Salary", "AlertSentDate");
        }
    }
}
