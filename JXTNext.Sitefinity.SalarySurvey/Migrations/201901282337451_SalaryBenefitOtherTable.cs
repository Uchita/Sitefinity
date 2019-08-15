namespace JXTNext.Sitefinity.SalarySurvey.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SalaryBenefitOtherTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SalaryBenefitOther",
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
            DropForeignKey("dbo.SalaryBenefitOther", "SalaryId", "dbo.Salary");
            DropIndex("dbo.SalaryBenefitOther", new[] { "SalaryId" });
            DropTable("dbo.SalaryBenefitOther");
        }
    }
}
