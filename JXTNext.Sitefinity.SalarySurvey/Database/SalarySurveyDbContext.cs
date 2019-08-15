using JXTNext.Sitefinity.SalarySurvey.Database.Models;
using System;
using System.Data.Entity;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Data.Configuration;

namespace JXTNext.Sitefinity.SalarySurvey.Database
{
    public class SalarySurveyDbContext : DbContext
    {
        public const string ConnectionName = "SalarySurvey";

        public DbSet<Site> Site { get; set; }
        public DbSet<Salary> Salary { get; set; }
        public DbSet<SalaryBenefit> SalaryBenefit { get; set; }
        public DbSet<SalaryBenefitOther> SalaryBenefitOther { get; set; }
        public DbSet<SalaryMotivator> SalaryMotivator { get; set; }
        public DbSet<SalaryMotivatorOther> SalaryMotivatorOther { get; set; }
        public DbSet<SalaryBestEmployer> SalaryBestEmployer { get; set; }
        public DbSet<SalaryCareerMove> SalaryCareerMove { get; set; }

        public SalarySurveyDbContext() : base("name=" + ConnectionName)
        {

        }

        public SalarySurveyDbContext(string siteFinityConnectionName) : base(siteFinityConnectionName)
        {

        }

        /// <summary>
        /// Creates a new DB context by reading the connection string from Sitefinity data settings
        /// </summary>
        /// <returns>SalarySurveyDbContext</returns>
        public static SalarySurveyDbContext CreateInstance()
        {
            DataConfig dataConfig = Config.Get<DataConfig>();

            if (!dataConfig.ConnectionStrings.TryGetValue(ConnectionName, out ConnStringSettings connSettings))
            {
                throw new Exception("Database connection not defined.");
            }

            return new SalarySurveyDbContext(connSettings.ConnectionString);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
        }
    }
}
