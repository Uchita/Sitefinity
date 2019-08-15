namespace JXTNext.Sitefinity.SalarySurvey.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SalaryMotivatorOtherTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SalaryMotivatorOther",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        SalaryId = c.Long(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                        Position = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Salary", t => t.SalaryId, cascadeDelete: true)
                .Index(t => t.SalaryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SalaryMotivatorOther", "SalaryId", "dbo.Salary");
            DropIndex("dbo.SalaryMotivatorOther", new[] { "SalaryId" });
            DropTable("dbo.SalaryMotivatorOther");
        }
    }
}
