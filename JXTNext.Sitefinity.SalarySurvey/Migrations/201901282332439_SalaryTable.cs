namespace JXTNext.Sitefinity.SalarySurvey.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SalaryTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Salary",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        SiteId = c.Long(nullable: false),
                        JobTitle = c.String(maxLength: 255),
                        CountryId = c.Guid(nullable: false),
                        LocationId = c.Guid(nullable: false),
                        IndustryId = c.Guid(nullable: false),
                        ClassificationId = c.Guid(nullable: false),
                        SubClassificationId = c.Guid(nullable: false),
                        JobTypeId = c.Guid(nullable: false),
                        YearsOfExperienceId = c.Guid(),
                        HourlyRate = c.Int(),
                        AnnualSalary = c.Int(),
                        SuperIncluded = c.Boolean(nullable: false),
                        SuperAmount = c.Int(),
                        SuperPercentage = c.Decimal(precision: 18, scale: 2),
                        SectorId = c.Guid(),
                        EducationId = c.Guid(),
                        PreviousCompany = c.String(maxLength: 255),
                        ReasonForLeaving = c.String(),
                        CurrentCompany = c.String(maxLength: 255),
                        EmployerSizeId = c.Guid(),
                        PeopleManagedId = c.Guid(),
                        BonusAmount = c.Int(),
                        MoneyToLeave = c.Int(),
                        ProfessionalQualification = c.Boolean(nullable: false),
                        JobAlert = c.Boolean(nullable: false),
                        SalaryAlert = c.Boolean(nullable: false),
                        ContactRequest = c.Boolean(nullable: false),
                        Name = c.String(maxLength: 255),
                        Email = c.String(maxLength: 255),
                        Phone = c.String(maxLength: 255),
                        GenderId = c.Guid(),
                        Verified = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Guid(),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Site", t => t.SiteId, cascadeDelete: true)
                .Index(t => new { t.SiteId, t.Verified, t.JobTypeId, t.AnnualSalary }, name: "IX_AnnualSalary")
                .Index(t => new { t.SiteId, t.Verified, t.JobTypeId, t.HourlyRate }, name: "IX_HourlyRate")
                .Index(t => new { t.SiteId, t.Verified, t.JobTypeId, t.SuperAmount }, name: "IX_SuperAmount")
                .Index(t => new { t.SiteId, t.Verified, t.JobTypeId, t.BonusAmount }, name: "IX_BonusAmount")
                .Index(t => t.SiteId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Salary", "SiteId", "dbo.Site");
            DropIndex("dbo.Salary", new[] { "SiteId" });
            DropIndex("dbo.Salary", "IX_AnnualSalary");
            DropIndex("dbo.Salary", "IX_HourlyRate");
            DropIndex("dbo.Salary", "IX_SuperAmount");
            DropIndex("dbo.Salary", "IX_BonusAmount");
            DropTable("dbo.Salary");
        }
    }
}
