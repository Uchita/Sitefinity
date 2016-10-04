using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JXTEnworldImport.Models
{
    public class EnworldJson
    {
        public class Address
        {
            public string country { get; set; }
            public string region { get; set; }
            public string postal_code { get; set; }
            public string city { get; set; }
            public string address1 { get; set; }
            public string address2 { get; set; }
            public string ward { get; set; }
            public string nearest_station { get; set; }
        }

        public class Contact
        {
            public string email_secondary { get; set; }
            public string email_mobile { get; set; }
            public string phone_mobile { get; set; }
            public string phone_home { get; set; }
            public string[] preferred_contacts { get; set; }
        }

        public class Name
        {
            public string first { get; set; }
            public string last { get; set; }
            public string first_translated { get; set; }
            public string last_translated { get; set; }
        }

        public class Fixed
        {
            public string amount { get; set; }
            public string currency { get; set; }
        }

        public class Variable
        {
            public string amount { get; set; }
            public string currency { get; set; }
        }

        public class Total
        {
            public string amount { get; set; }
            public string currency { get; set; }
        }

        public class CurrentSalary
        {
            public Fixed @fixed { get; set; }
            public Variable variable { get; set; }
            public Total total { get; set; }
            public object currency { get; set; }
        }

        public class Attachment
        {
            public string id { get; set; }
            public string filename { get; set; }
            public string displayFilename { get; set; }
        }

        public class Language
        {
            public string[] levels { get; set; }
            public string other { get; set; }
            public int? toeic_score { get; set; }
        }

        public class Education
        {
            public string id { get; set; }
            public string startDate { get; set; }
            public string endDate { get; set; }
            public string type { get; set; }
            public string school { get; set; }
            public string location { get; set; }
            public string degree { get; set; }
            public string major { get; set; }
            public string certification { get; set; }
        }

        public class Salary
        {
            public long amount { get; set; }
            public string currency { get; set; }
        }

        public class DesiredPosition
        {
            public List<string> locations { get; set; }
            public List<int> job_categories { get; set; }
            public List<string> job_types { get; set; }
            public string max_commute_id { get; set; }
            public Salary salary { get; set; }
        }

        public class JobSalary
        {
            public long min { get; set; }
            public long max { get; set; }
            public string currency { get; set; }
        }

        public class Employment
        {
            public string id { get; set; }
            public string startDate { get; set; }
            public string endDate { get; set; }
            public string company { get; set; }
            public string location { get; set; }
            public string comments { get; set; }
            public string position { get; set; }
            public string staffManaged { get; set; }
            public string reasonForSeparation { get; set; }
            public Salary salary { get; set; }
            public string reference_name { get; set; }
            public string reference_phone { get; set; }
            public string reference_position { get; set; }
            public string reference_comments { get; set; }
        }

        public class En
        {
            public string title { get; set; }
        }

        public class Ja
        {
            public string title { get; set; }
        }

        public class Job
        {
            public int id { get; set; }
            public int[] categories { get; set; }
            public bool is_live { get; set; }
            public int location { get; set; }
            public string refNo { get; set; }
            public int type { get; set; }
            public string postDate { get; set; }
            public object hourlyWage { get; set; }
            public JobSalary salary { get; set; }
            public En en { get; set; }
            public Ja ja { get; set; }
        }

        public class Application
        {
            public DateTime applicationTime { get; set; }
            public Job job { get; set; }
        }

        public class RootObject
        {
            public string id { get; set; }
            public string primary_email { get; set; }
            public Address address { get; set; }
            public Contact contact { get; set; }
            public string date_of_birth { get; set; }
            public string gender_id { get; set; }
            public string marital_state_id { get; set; }
            public Name name { get; set; }
            public string personal_introduction { get; set; }
            public bool pipl_agreed { get; set; }
            public CurrentSalary current_salary { get; set; }
            public DesiredPosition desired_position { get; set; }
            public Attachment[] attachments { get; set; }
            public string[] skills { get; set; }
            public string[] industry_experiences { get; set; }
            public string[] job_function_experiences { get; set; }
            public string[] industries { get; set; }
            public Language language { get; set; }
            public Education[] educations { get; set; }
            public Employment[] employments { get; set; }
            public object[] job_search_activities { get; set; }
            public Application[] applications { get; set; }
        }


        public class GenderDescription
        {
            public string en { get; set; }
            public string ja { get; set; }
            public string ko { get; set; }
            public string vi { get; set; }
        }

        public class Gender
        {
            public Dictionary<string, string> _id { get; set; }
            public GenderDescription description { get; set; }
            public string public_id { get; set; }
        }


        public class LanguageLevelDescription
        {
            public string en { get; set; }
            public string ja { get; set; }
            public string ko { get; set; }
        }

        public class LanguageLevel
        {
            public Dictionary<string, string> _id { get; set; }
            public LanguageLevelDescription description { get; set; }
            public string public_id { get; set; }
            public Dictionary<string, string> parent_id { get; set; }
        }

        public class Countries
        {
            public Dictionary<string, string> _id { get; set; }
            public string iso_code { get; set; }
            public CountryDescription description { get; set; }
        }

        public class CountryEn
        {
            public string name { get; set; }
        }

        public class CountryJa
        {
            public string name { get; set; }
        }

        public class CountryDescription
        {
            public CountryEn en { get; set; }
            public CountryJa ja { get; set; }
        }

        public class Regions
        {
            public Dictionary<string, string> _id { get; set; }
            public RegionDescription description { get; set; }
            public Dictionary<string, string> parent_id { get; set; }
            public string public_id { get; set; }
        }

        public class RegionDescription
        {
            public string en { get; set; }
            public string ja { get; set; }
        }

        public class JobTypeDescription
        {
            public string en { get; set; }
            public string ja { get; set; }
            public string ko { get; set; }
        }

        public class JobType
        {
            public Dictionary<string, string> _id { get; set; }
            public JobTypeDescription description { get; set; }
            public string public_id { get; set; }
        }

    }
}
