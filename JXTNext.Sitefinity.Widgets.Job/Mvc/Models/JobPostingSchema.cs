using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JXTNext.Sitefinity.Widgets.Job.Mvc.Models
{
    public class Identifier
    {
        public string schemaType { get; set; }
        public string name { get; set; }
        public string value { get; set; }
    }

    public class HiringOrganization
    {
        public string schemaType { get; set; }
        public string name { get; set; }
        public string sameAs { get; set; }
        public string logo { get; set; }
    }

    public class Address
    {
        public string schemaType { get; set; }
        public string streetAddress { get; set; }
        public string addressLocality { get; set; }
        public string addressRegion { get; set; }
        public string postalCode { get; set; }
        public string addressCountry { get; set; }
    }

    public class JobLocation
    {
        public string schemaType { get; set; }
        public Address address { get; set; }
    }

    public class JobPostingValue
    {
        public string schemaType { get; set; }
        public decimal? minValue { get; set; }
        public decimal? maxValue { get; set; }
        public string unitText { get; set; }
    }

    public class BaseSalary
    {
        public string schemaType { get; set; }
        public string currency { get; set; }
        public JobPostingValue value { get; set; }
    }

    public class JobPostingSchemaRoot
    {
        public string context { get; set; }
        public string schemaType { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public Identifier identifier { get; set; }
        public string datePosted { get; set; }
        public string validThrough { get; set; }
        public string employmentType { get; set; }
        public HiringOrganization hiringOrganization { get; set; }
        public JobLocation jobLocation { get; set; }
        public BaseSalary baseSalary { get; set; }
    }

}
