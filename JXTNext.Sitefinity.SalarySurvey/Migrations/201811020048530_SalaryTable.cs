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
                        SiteId = c.Guid(nullable: false),
                        JobTitle = c.String(maxLength: 255),
                        CountryId = c.Guid(),
                        LocationId = c.Guid(nullable: false),
                        ClassificationId = c.Guid(nullable: false),
                        SubClassificationId = c.Guid(nullable: false),
                        JobTypeId = c.Guid(nullable: false),
                        YearsOfExperienceId = c.Guid(),
                        HourlyRate = c.Int(),
                        AnnualSalary = c.Int(),
                        SuperIncluded = c.Boolean(nullable: false, defaultValue: false),
                        SuperAmount = c.Int(),
                        SuperPercentage = c.Decimal(precision: 18, scale: 2),                        
                        SectorId = c.Guid(),
                        IndustryId = c.Guid(),
                        EducationId = c.Guid(),
                        PreviousCompany = c.String(maxLength: 255),
                        ReasonForLeaving = c.String(),
                        CurrentCompany = c.String(maxLength: 255),
                        EmployerSizeId = c.Guid(),
                        PeopleManagedId = c.Guid(),
                        BonusAmount = c.Int(),
                        MoneyToLeave = c.Int(),
                        ProfessionalQualification = c.Boolean(nullable: false, defaultValue: false),
                        JobAlert = c.Boolean(nullable: false, defaultValue: false),
                        SalaryAlert = c.Boolean(nullable: false, defaultValue: false),
                        ContactRequest = c.Boolean(nullable: false, defaultValue: false),
                        Name = c.String(maxLength: 255),
                        Email = c.String(maxLength: 255),
                        Phone = c.String(maxLength: 255),
                        GenderId = c.Guid(),
                        Verified = c.Boolean(nullable: false, defaultValue: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Guid(),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.Guid(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Salary");
        }
    }
}
