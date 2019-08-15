namespace JXTNext.Sitefinity.SalarySurvey.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SiteTableUrlColumnAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Site", "Url", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Site", "Url");
        }
    }
}
