namespace JXTNext.Sitefinity.SalarySurvey.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SiteTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Site",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Domain = c.String(maxLength: 255),
                        AliasOfId = c.Long(),
                        Active = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Guid(),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Site", t => t.AliasOfId)
                .Index(t => t.Domain, unique: true)
                .Index(t => t.AliasOfId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Site", "AliasOfId", "dbo.Site");
            DropIndex("dbo.Site", new[] { "AliasOfId" });
            DropIndex("dbo.Site", new[] { "Domain" });
            DropTable("dbo.Site");
        }
    }
}
