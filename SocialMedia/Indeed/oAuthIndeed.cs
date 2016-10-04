using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Web;
using System.Text.RegularExpressions;
using System.IO;
using System.Web.Script.Serialization;
using JXTPortal.Entities.Models;
using System.Xml;
using System.Globalization;

public class oAuthIndeed
{
    
    public class IndeedContract
    {
        public IndeedApplicationContract applicant;
        public string appliedOnMillis;
        public IndeedJobContract job;
        public string locale;
    }

    public class IndeedApplicationContract
    {
        public string email;
        public string fullName;
        public string phoneNumber;
        public IndeedResumeContract resume;
    }

    public class IndeedJobContract
    {
        public string jobCompany;
        public string jobId;
        public string jobLocation;
        public string jobMeta;
        public string jobTitle;
        public string jobUrl;
    }

    public class IndeedResumeContract
    {
        public IndeedFileContract file;
        public IndeedJsonContract json;
    }

    public class IndeedJsonContract
    {
        public string firstName;
        public string lastName;
    }

    public class IndeedFileContract
    {
        public string contentType;
        public string data;
        public string fileName;
    }
}