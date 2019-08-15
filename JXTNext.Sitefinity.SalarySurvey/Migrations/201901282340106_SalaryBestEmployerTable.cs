namespace JXTNext.Sitefinity.SalarySurvey.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SalaryBestEmployerTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SalaryBestEmployer",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        SalaryId = c.Long(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Salary", t => t.SalaryId, cascadeDelete: true)
                .Index(t => t.SalaryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SalaryBestEmployer", "SalaryId", "dbo.Salary");
            DropIndex("dbo.SalaryBestEmployer", new[] { "SalaryId" });
            DropTable("dbo.SalaryBestEmployer");
        }
    }
}
