using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JXTPortal.JobApplications.Models
{
    [Serializable]
    public class AicdSponsorshipModel
    {
        public int? JobApplicationID { get; set; }
        public int JobID { get; set; }
        public int tabSubmit { get; set; }
        public Tab1Model tab1 { get; set; }
        public Tab2Model tab2 { get; set; }
        public List<DirectorshipExperience> tab3 { get; set; }
        public List<ProfessionalExperience> tab4 { get; set; }
        public Tab5Model tab5 { get; set; }
        //public Tab6Model tab6 { get; set; }
        public Tab7Model tab7 { get; set; }
        public Tab8Model tab8 { get; set; }

        public AicdSponsorshipModel()
        {
            tab2 = new Tab2Model();
            tab3 = new List<DirectorshipExperience>();
            tab4 = new List<ProfessionalExperience>();
            tab5 = new Tab5Model();
            //tab6 = new Tab6Model();
            tab7 = new Tab7Model();
            tab8 = new Tab8Model();
        }
    }

    [Serializable]
    public class Tab1Model
    {
    }

    [Serializable]
    public class QuestionaireValues
    {
        public string name {get;set;}
        public string value {get;set;}
        /*public string label { get; set; }
        public string type { get; set; }*/
    }

    [Serializable]
    public class Tab2Model
    {
        [Required(ErrorMessage = "Please fill in the required field")]
        public ENUM_Title title { get; set; }
        public string titleOthers { get; set; }

        [Required(ErrorMessage = "Please fill in the required field")]
        //[RegularExpression(@"^[a-zA-Z ']+$", ErrorMessage = "Must not contain numeric or invalid characters")]
        public string firstName { get; set; }
        //[RegularExpression(@"^[a-zA-Z ']+$", ErrorMessage = "Must not contain numeric or invalid characters")]
        public string middleName { get; set; }
        [Required(ErrorMessage = "Please fill in the required field")]
        //[RegularExpression(@"^[a-zA-Z ']+$", ErrorMessage = "Must not contain numeric or invalid characters")]
        public string lastName { get; set; }
        public string honorifics { get; set; }
        [Required(ErrorMessage = "Please fill in the required field")]
        //[EmailAddress(ErrorMessage = "Please enter a valid email address")]
        //[RegularExpression("^(([A-Za-z0-9]+_+)|([A-Za-z0-9]+\\-+)|([A-Za-z0-9]+\\.+)|([A-Za-z0-9]+\\++))*[A-Za-z0-9]+@((\\w+\\-+)|(\\w+\\.))*\\w{1,63}\\.[a-zA-Z]{2,6}$", ErrorMessage = "Please enter a valid email address")]
        [RegularExpression(@"^((([A-Za-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([A-Za-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([A-Za-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([A-Za-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([A-Za-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([A-Za-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([A-Za-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([A-Za-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([A-Za-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([A-Za-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))$", ErrorMessage = "Please enter a valid email address")]
        public string email { get; set; }

        [Required(ErrorMessage = "Please fill in the required field")]
        //[RegularExpression(@"^[0-9 +*#]+$", ErrorMessage = "Must only contain numbers")]
        public string phoneNumber { get; set; }
        [Required(ErrorMessage = "Please fill in the required field")]
        //[RegularExpression(@"^[0-9 +*#]+$", ErrorMessage = "Must only contain numbers")]
        public string postcode { get; set; }
        [Required(ErrorMessage = "Please fill in the required field")]
        public ENUM_State state { get; set; }

        public bool isAboriginal { get; set; }
        public bool isDiverseBG { get; set; }
        public bool isRural { get; set; }
        public bool isDisablility { get; set; }

        //public bool receiveEmail { get; set; }

        public List<ValidationResult> LogicValidate()
        {
            List<ValidationResult> results = new List<ValidationResult>();

            if (title == ENUM_Title.Others && string.IsNullOrEmpty(titleOthers))
                results.Add(new ValidationResult("Please fill in the required field", new List<string> { "titleOthers" }));

            return results;
        }

    }

    //Step3 Model
    [Serializable]
    public class DirectorshipExperience
    {
        public string internalGUID { get; set; }

        public string experienceSummary { get; set; }

        public ENUM_DirectorshipRole roleType { get; set; }
        public string roleType_Specify { get; set; }
        [Required(ErrorMessage = "Please fill in the required field")]
        public string positionTitle { get; set; }
        [Required(ErrorMessage = "Please fill in the required field")]
        public string organisationName { get; set; }
        public int dirStartDateMonth { get; set; }
        public int dirStartDateYear { get; set; }
        public int dirEndDateMonth { get; set; }
        public int dirEndDateYear { get; set; }
        public bool directorshipIsCurrent { get; set; }

        public bool role_isChairman { get; set; }
        //public bool role_isOwnerDirector { get; set; }
        //public bool role_isCompanySecretary { get; set; }

        public bool member_isAudit { get; set; }
        public bool member_isCompliance { get; set; }
        public bool member_isFinance { get; set; }
        public bool member_isNominations { get; set; }
        public bool member_isRemuneration { get; set; }
        public bool member_isRisk { get; set; }
        public bool member_isSustainability { get; set; }

        public string member_isOther_Specify { get; set; }

        [Range(1,10, ErrorMessage="Please fill in the required field")]
        public ENUM_DirectorshipOrgType organisationType { get; set; }

        [Required(ErrorMessage = "Please fill in the required field")]
        public string organisationIndustry { get; set; }

        public List<ValidationResult> LogicValidate()
        {
            List<ValidationResult> results = new List<ValidationResult>();

            if (roleType == ENUM_DirectorshipRole.Others && string.IsNullOrEmpty(roleType_Specify))
                results.Add(new ValidationResult("Please fill in the required field", new List<string> { "roleType_Specify" }));

            //if no checkbox selected and "Others" field is empty
            //if (!member_isAudit && !member_isCompliance && !member_isFinance && !member_isNominations && !member_isRemuneration && !member_isRisk && !member_isSustainability
            //    && string.IsNullOrEmpty(member_isOther_Specify))
            //    results.Add(new ValidationResult("Please fill in the required field", new List<string> { "member_isOther_Specify" }));

            //date check
            if (directorshipIsCurrent)
            {
                //make sure start date is not greater then today
                if (new DateTime(dirStartDateYear, dirStartDateMonth, 1) > DateTime.Now)
                    results.Add(new ValidationResult("Start Date is invalid", new List<string> { "dirStartDateMonth" }));
            }
            else
            {
                if (new DateTime(dirStartDateYear, dirStartDateMonth, 1) > new DateTime(dirEndDateYear, dirEndDateMonth, 1))
                    results.Add(new ValidationResult("End Date is invalid", new List<string> { "dirEndDateMonth" }));
            }


            return results;
        }
    }

    //Step4 Model
    [Serializable]
    public class ProfessionalExperience
    {
        public string internalGUID { get; set; }

        public string professionalExperienceSummary { get; set; }
        public ENUM_ProfessionalRole profRole { get; set; }
        public string profRole_Specify { get; set; }
        [Required(ErrorMessage = "Please fill in the required field")]
        public string jobTitle { get; set; }
        [Required(ErrorMessage = "Please fill in the required field")]
        public string profOrgName { get; set; }
        public int profStartDateMonth { get; set; }
        public int profStartDateYear { get; set; }
        public int profEndDateMonth { get; set; }
        public int profEndDateYear { get; set; }
        public bool profIsCurrent { get; set; }

        //public bool role_isSecretary { get; set; }

        [Range(1, 10, ErrorMessage = "Please fill in the required field")]
        public ENUM_DirectorshipOrgType organisationType { get; set; }

        [Required(ErrorMessage = "Please fill in the required field")]
        public string organisationIndustry { get; set; }

        public List<ValidationResult> LogicValidate()
        {
            List<ValidationResult> results = new List<ValidationResult>();

            /*if (profRole == ENUM_ProfessionalRole.Others && string.IsNullOrEmpty(profRole_Specify))
                results.Add(new ValidationResult("Please fill in the required field", new List<string> { "profRole_Specify" }));*/

            //date check
            if (profIsCurrent)
            {
                //make sure start date is not greater then today
                if (new DateTime(profStartDateYear, profStartDateMonth, 1) > DateTime.Now)
                    results.Add(new ValidationResult("Start Date is invalid", new List<string> { "profStartDateMonth" }));
            }
            else
            {
                if (new DateTime(profStartDateYear, profStartDateMonth, 1) > new DateTime(profEndDateYear, profEndDateMonth, 1))
                    results.Add(new ValidationResult("End Date is invalid", new List<string> { "profEndDateMonth" }));
            }
            return results;
        }
    }

    //Step5 Model
    [Serializable]
    public class Qualifications
    {
        public string internalGUID { get; set; }

        public string courseName { get; set; }
        public string institution { get; set; }

        public int qStartDateMonth { get; set; }
        public int qStartDateYear { get; set; }
        public int qEndDateMonth { get; set; }
        public int qEndDateYear { get; set; }
        public bool qIsCurrent { get; set; }

        public List<ValidationResult> LogicValidate()
        {
            List<ValidationResult> results = new List<ValidationResult>();

            if (new DateTime(qStartDateYear, qStartDateMonth, 1) > new DateTime(qEndDateYear, qEndDateMonth, 1))
                results.Add(new ValidationResult("End Date is invalid", new List<string> { "qEndDateMonth" }));

            return results;
        }
    }

    
    [Serializable]
    public class Tab5Model
    {
        public List<Qualifications> qualifications { get; set; }
        public Tab5Model()
        {
            qualifications = new List<Qualifications>();
        }

        public bool AreYouMemberOfAICD { get; set; }

        // Association Membership
        public bool CPA { get; set; }
        public bool ICAA { get; set; }
        public bool CSA { get; set; }
        public bool EA { get; set; }
        public bool LawSociety { get; set; }
        public bool IntDirectorshipOrg { get; set; }
        public string Other_Specify { get; set; }

        public bool _isFromPageSubmit { get; set; }
        //public List<ValidationResult> LogicValidate()
        //{
        //    List<ValidationResult> results = new List<ValidationResult>();

        //    //if (!CPA && !ICAA && !CSA && !EA && !LawSociety && !IntDirectorshipOrg
        //    //    && string.IsNullOrEmpty(Other_Specify))
        //    //    results.Add(new ValidationResult("Please fill in the required field", new List<string> { "Other_Specify" }));

        //    return results;
        //}
    }

    [Serializable]
    public class Tab7Model
    {
        [Required(ErrorMessage = "Please fill in the required field")]
        public string name1 { get; set; }
        [Required(ErrorMessage = "Please fill in the required field")]
        public string relationship1 { get; set; }
        [Required(ErrorMessage = "Please fill in the required field")]
        public string contact1 { get; set; }

        [Required(ErrorMessage = "Please fill in the required field")]
        public string name2 { get; set; }
        [Required(ErrorMessage = "Please fill in the required field")]
        public string relationship2 { get; set; }
        [Required(ErrorMessage = "Please fill in the required field")]
        public string contact2 { get; set; }

        public List<ValidationResult> LogicValidate()
        {
            return new List<ValidationResult>();
        }
    }

    [Serializable]
    public class Tab8Model
    {
        //public bool blnResumeFile { get; set; }

        public QuestionaireValues[] tab1Values { get; set; }

        public List<ValidationResult> LogicValidate()
        {
            List<ValidationResult> results = new List<ValidationResult>();

            FormGenerator frmGenerator = new FormGenerator();
            results = frmGenerator.ValidateForm(tab1Values);

            return results;
        }
    }

    public enum ENUM_DirectorshipOrgType
    {
        ASX200 = 1,
        Large_Listed,
        Large_Unlisted,
        Medium_Listed,
        Medium_Unlisted,
        Small,
        Non_Profit,
        Government
    }

    public enum ENUM_DirectorshipRole
    {
        NonExecutive_Director = 1,
        Executive_Director = 2,
        Business_Owner = 3,
        Others
    }

    public enum ENUM_ProfessionalRole
    {
        SeniorExecutive = 1,
        Manager = 2,
        Consultant = 3,
        Academic = 4,
        Student = 5,
        Others
    }

    public enum ENUM_Title
    {
        Doctor = 1,
        Miss,
        Mrs,
        Mr,
        Ms,
        Professor,
        Others
    }

    public enum ENUM_State
    {
        NSW,
        VIC,
        QLD,
        WA,
        SA,
        TAS,
        ACT,
        NT
    }





}