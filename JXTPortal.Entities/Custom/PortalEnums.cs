using System.Collections.Generic;
using System.ComponentModel;
using JXTPortal.Entities.Custom;


namespace JXTPortal.Entities
{
    public class PortalEnums
    {
        // ToDo: Move this class to JXTPortal.Common
        public class Admin
        {
            public enum AdminRole
            {
                //[Description("Super Administrator")]
                //SuperAdministrator = 0,
                [Description("Super Administrator")]
                Administrator = 1,
                [Description("Administrator")]
                ContentEditor = 2,
                [Description("External User")]
                ExternalUser = 4,
                [Description("Developer")]
                Developer = 5,
                [Description("Contributor")]
                Contributor = 6
            };

            public enum SiteType
            {
                Recruiter = 1,
                JobBoard = 2
            }

            public enum AdvertiserApproval
            {
                [Description("All advertisers auto approved")]
                AutoApproved = 0,
                [Description("All advertisers types approval process")]
                AllApprovalProcess = 1,
                [Description("Account type approval process / Credit card type is auto approved")]
                CreditCardApproved = 2
            }

            public enum UserStatus
            {
                Valid = 0,
                Locked = 1,
                Closed = 2
            }

            public enum ConsultantStatus
            {
                All = 0,
                Visible = 1, 
                NotVisible = 2,
                Archived = 3
            }

            public enum SiteSummaryValid
            {
                Live = 1,
                Prelive = 2,
                Hide = 3,
                Custom = 4
            }

            public enum IntegrationMappingType
            {
                [Description("BH Advertiser")]
                BH_Mapping_Advertiser = 1,
                [Description("BH Advertiser User")]
                BH_Mapping_AdvertiserUser = 2,
                /*[Description("BH Candidate")]
                BH_Mapping_Candidate = 3,
                [Description("BH Candidate Education")]
                BH_Mapping_CandidateEducation = 4,
                [Description("BH Candidate Experience")]
                BH_Mapping_CandidateExperience = 5,*/
                
            }
        }

        public class Languages
        {
            public enum Language //Please also update URLLanguage ENUM below and Language Enum C:\Developments\MiniJXT\MiniJXT\JXTPortal.Common\Utils.cs
            {
                English = 1,
                Chinese = 2,
                US = 3,
                Japanese = 4,
                Korean = 5,
                Thai = 6,
                SimplifiedChinese = 7,
                Vietnamese = 8,
                Dutch = 9,
                French = 10,
                German = 11,
                Spanish = 12,
                LatinAmericanSpanish = 13
            }

            //WARNING: the int value must match Languages.Language Enum above
            //NOTE: When adding to the following list, you will need to add to web.config in the <rewriter /> section
            //      in order for it to work for the home page
            //NOTE: Use the Description for language specifier in the URL
            //NOTE: Use the enum value and replace _ to - for SEO hreflang
            //NOTE: the enum value must also comply with the ISO_639-1 language code https://en.wikipedia.org/wiki/List_of_ISO_639-1_codes
            //      because it is used for language SEO in ucCommonHeader.ascx
            public enum URLLanguage
            {
                [Description("en")]
                en = 1,
                [Description("zh")]
                zh = 2,
                [Description("en-us")]
                en_us = 3,
                [Description("jp")]
                ja = 4, //do not touch this, and yes Japanese is ja not jp
                [Description("ko")]
                ko = 5,
                [Description("th")]
                th = 6,
                [Description("zh-cn")]
                zh_Hans = 7,
                [Description("vi")]
                vi = 8,
                [Description("nl")]
                nl = 9,
                [Description("fr")]
                fr = 10,
                [Description("de")]
                de = 11,
                [Description("es")]
                es = 12,
                [Description("es-xl")]
                es_xl = 13 //es_xl comes from microsoft, otherwise could not find this reference anywhere

            }
        }

        public class DynamicContent
        {
            public enum DynamicContentType
            {
                AdvertiserTermsAndConditions = 0,
                MemberTermsAndConditions = 1,
                AdminLoginContent = 2
            };

        }

        public class DynamicPage
        {
            public enum WidgetPosition
            {
                Left_Column = 1,
                Right_Column = 2
            };

            public enum Status
            {
                None = 0,
                Published = 1,
                Pending = 2,
                Draft = 3,
                Decline = 4,
                Approved = 5
            }

            public enum Visiblity
            {
                Public = 1,
                Private = 0,
                Secured = 2
            }
        }

        public class Advertiser
        {
            public enum AccountType
            {
                Account = 1,
                Credit_Card = 2
            };

            public enum AccountStatus
            {
                ApprovedPending = 1,
                Approved = 2,
                Declined = 3,
                Suspended = 4
            };

            public enum JobItemType
            {
                Normal = 1,
                StandOut = 2,
                Premium = 3
            };

            public enum ContactMethod
            {
                [Description("LabelEmail")]
                Email = 1,
                [Description("LabelPhone")]
                Phone = 2,
                [Description("LabelSMS")]
                SMS = 3
            };
        }

        public class AdvertiserUser
        {
            public enum AccountStatus
            {
                ApprovalPending = 1,
                Approved = 2,
                Declined = 3,
                Suspended = 4,
                Rejected = 5
            };

            public enum UserStatus
            {
                Valid = 0,
                Locked = 1,
                Closed = 2
            }
        }

        public class Members
        {
            public enum MemberFileTypes
            {
                [Description("LabelCoverLetter")]
                CoverLetter = 1,
                [Description("LabelResume")]
                Resume = 2,
                [Description("LabelAdditionalDocuments")]
                AdditionalDocument = 3
            };

            public enum UserStatus
            {
                Valid = 0,
                Locked = 1,
                Closed = 2
            }

            public enum CurrentlySeeking
            {
                [Description("LabelSeeking")]
                Seeking = 1,
                [Description("LabelTempted")]
                Tempted = 2, //RN72 - Changed to "Possibily Seeking"
                [Description("LabelNotSeeking")]
                NotSeeking = 3
            }

            public enum QualificationLevel
            {
                [Description("LabelSecondarySchool")]
                [SequenceAttribute(10)]
                SecondarySchool = 1,

                [Description("LabelTertiaryEducation")]
                [SequenceAttribute(20)]
                TertiaryEducation = 2,

                [SequenceAttribute(15)]
                [Description("LabelDiploma")]
                Diploma = 3,

                [SequenceAttribute(25)]
                [Description("LabelAssociatesDegree")]
                AssociatesDegree = 4,

                [SequenceAttribute(30)]
                [Description("LabelBachelorsDegree")]
                BachelorsDegree = 5,

                [SequenceAttribute(40)]
                [Description("LabelMastersDegree")]
                MastersDegree = 6,

                [SequenceAttribute(42)]
                [Description("LabelPostGraduateDegree")]
                PostGraduateDegree = 7,

                [SequenceAttribute(41)]
                [Description("LabelMastersOfBusinessAdministration")]
                MastersOfBusinessAdministration = 8,

                [SequenceAttribute(50)]
                [Description("LabelJurisDoctor")]
                JurisDoctor = 9,

                [SequenceAttribute(60)]
                [Description("LabelDoctorOfMedicine")]
                DoctorOfMedicine = 10,

                [SequenceAttribute(61)]
                [Description("LabelDoctorOfPhilosophy")]
                DoctorOfPhilosophy = 11,

                [SequenceAttribute(70)]
                [Description("LabelOther")]
                Other = 12,

                [SequenceAttribute(10)]
                [Description("LabelHighSchool")]
                HighSchool = 13,

                [SequenceAttribute(50)]
                [Description("LabelDoctorate")]
                Doctorate = 14
                
            }

            public enum LanguagesProfieciency 
            {
                [Description("LabelElementaryProficiency")]
                Elementary = 1,
                [Description("LabelLimitedWorkProficiency")]
                LimitedWork = 2,
                [Description("LabelProfessionalWorkingProficiency")]
                ProfessionalWorking = 3,
                [Description("LabelFullProfessionalProficiency")]
                FullProfessional = 4,
                [Description("LabelNativeOrBilingualProficiency")]
                NativeOrBilingual = 5,
            }

            public enum ReferencesRelationship
            {
                [Description("LabelAdvisor")]
                Advisor = 1,
                [Description("LabelColleague")]
                Colleague  = 2,
                [Description("LabelDirectReport")]
                DirectReport = 3,
                [Description("LabelFormerEmployer")]
                FormerEmployer  = 4,
                [Description("LabelIndirectReport")]
                IndirectReport = 5,
                [Description("LabelManager")]
                Manager = 6,
                [Description("LabelMentor")]
                Mentor = 7,
                [Description("LabelSupervisor")]
                Supervisor  = 8,
                [Description("LabelTeacher")]
                Teacher = 9
            }

            //public static string GetMemberFilesDescription(Enum value)
            //{
            //    FieldInfo fi = value.GetType().GetField(value.ToString());

            //    DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            //    foreach (var desc in attributes)
            //    {
            //        return attributes[0].Description;
            //    }

            //    return value.ToString();

            //}

        }

        public class Email
        {
            public enum EmailFormat
            {
                HTML = 1,
                Text = 2
            };
        }

        public class SiteWebParts
        {
            public enum SiteWebPartTypes
            {
                Header = 1,
                Footer = 2,
                LeftNavigation = 3,
                RightNavigation = 4,
                AboveHeader = 5,
                BelowFooter = 6
            };
        }

        public class Files
        {
            public enum FileTypes
            {
                Word = 1,
                TextFile = 4,
                WordDocx = 5,
                Jpg = 6,
                PNG = 7,
                Gif = 8,
                Tif = 9,
                Excel = 10,
                Pdf = 12,
                Other = 13,
                Xml = 14,
                Javascript = 15,
                CSS = 16
            }

        }

        public class Payment
        {
            public enum PaymentTypes
            {
                [Description("LabelAccount")]
                Account = 1,
                [Description("LabelCreditCard")]
                CreditCard = 2,
                [Description("LabelPaypal")]
                PayPal = 3,
                [Description("LabelFree")]
                Free = 4,
                [Description("LabelAdvertiserTrial")]
                AdvertiserTrial = 5,
                [Description("LabelAdvertiserCredit")]
                AdvertiserCredit = 6
            }

            public enum PaymentSuccessStatus
            {
                Failed = 0,
                Success = 1,
                Webservice = 2
            }
        }

        public class Jobs
        {
            public enum ApplicationMethod
            {
                [Description("LabelViaEmail")] //LabelDefault
                Default = 1,
                [Description("LabelURLLinkOut")] //LabelURL
                URL = 2,
                [Description("LabelNone")]
                None = 3
            }

            public enum UploadMethod
            {
                [Description("LabelWebsite")]
                Website = 1,
                [Description("LabelWebservice")]
                Webservice = 2
            }

            public enum JobStatus
            {
                [Description("Live")]
                Live = 0,
                [Description("Expired")]
                Expired = 1,
                [Description("Pending")]
                Pending = 2,
                [Description("Draft")]
                Draft = 3,
                [Description("Declined")]
                Declined = 4,
                [Description("Suspended")]
                Suspended = 5
            }

            public enum JobItemType
            {
                [Description("Normal")]
                Normal = 1,
                [Description("Stand Out")]
                StandOut = 2,
                [Description("Premium")]
                Premium = 3
            }

            public enum JobGeocodeStatus
            {
                [Description("Invalid")]
                Invalid = 0,
                [Description("Valid")]
                Valid = 1,
                [Description("Queued")]
                Queued = 2
            }

            public enum CurrencySymbol
            {
                [Description("$")]
                AUD = 1,
                [Description("R$")] //This currency is supported as a payment currency and a currency balance for in-country PayPal accounts only.
                BRL = 2,
                [Description("$")]
                CAD = 3,
                [Description("Kč")]
                CZK = 4,
                [Description("kr")]
                DKK = 5,
                [Description("€")]
                EUR = 6,
                [Description("$")]
                HKD = 7,
                [Description("Hungarian Forint**")] //Decimal amounts are not supported for this currency. Passing a decimal amount will throw an error.
                HUF = 8,
                [Description("₪")]
                ILS = 9,
                [Description("¥")] //This currency does not support decimals. Passing a decimal amount will throw an error.
                JPY = 10,
                [Description("RM")] // This currency is supported as a payment currency and a currency balance for in-country PayPal accounts only.
                MYR = 11,
                [Description("$")]
                MXN = 12,
                [Description("kr")]
                NOK = 13,
                [Description("$")]
                NZD = 14,
                [Description("₱")]
                PHP = 15,
                [Description("zł")]
                PLN = 16,
                [Description("£")]
                GBP = 17,
                [Description("Russian Ruble")]
                RUB = 18,
                [Description("$")]
                SGD = 19,
                [Description("kr")]
                SEK = 20,
                [Description("Fr")]
                CHF = 21,
                [Description("$")] //This currency does not support decimals. Passing a decimal amount will throw an error.
                TWD = 22,
                [Description("฿")]
                THB = 23,
                [Description("Turkish Lira*")] //This currency is supported as a payment currency and a currency balance for in-country PayPal accounts only.
                TRY = 24,
                [Description("$")]
                USD = 25
            }

            //https://developer.paypal.com/webapps/developer/docs/classic/api/currency_codes/
            public enum Currency
            {
                [Description("Australian Dollar")]
                AUD = 1,
                [Description("Brazilian Real*")] //This currency is supported as a payment currency and a currency balance for in-country PayPal accounts only.
                BRL = 2,
                [Description("Canadian Dollar")]
                CAD = 3,
                [Description("Czech Koruna")]
                CZK = 4,
                [Description("Danish Krone")]
                DKK = 5,
                [Description("Euro")]
                EUR = 6,
                [Description("Hong Kong Dollar")]
                HKD = 7,
                [Description("Hungarian Forint**")] //Decimal amounts are not supported for this currency. Passing a decimal amount will throw an error.
                HUF = 8,
                [Description("Israeli New Sheqel")]
                ILS = 9,
                [Description("Japanese Yen**")] //This currency does not support decimals. Passing a decimal amount will throw an error.
                JPY = 10,
                [Description("Malaysian Ringgit*")] // This currency is supported as a payment currency and a currency balance for in-country PayPal accounts only.
                MYR = 11,
                [Description("Mexican Peso")]
                MXN = 12,
                [Description("Norwegian Krone")]
                NOK = 13,
                [Description("New Zealand Dollar")]
                NZD = 14,
                [Description("Philippine Peso")]
                PHP = 15,
                [Description("Polish Zloty")]
                PLN = 16,
                [Description("Pound Sterling")]
                GBP = 17,
                [Description("Russian Ruble")]
                RUB = 18,
                [Description("Singapore Dollar")]
                SGD = 19,
                [Description("Swedish Krona")]
                SEK = 20,
                [Description("Swiss Franc")]
                CHF = 21,
                [Description("Taiwan New Dollar**")] //This currency does not support decimals. Passing a decimal amount will throw an error.
                TWD = 22,
                [Description("Thai Baht")] 
                THB = 23,
                [Description("Turkish Lira*")] //This currency is supported as a payment currency and a currency balance for in-country PayPal accounts only.
                TRY = 24,
                [Description("US Dollar")]
                USD = 25
            }

            public enum CustomType
            {
                Job = 1
            }

            public enum ScreeningQuestionsType
            {
                [Description("LabelTextBox")]
                TextBox = 1,
                [Description("LabelTextArea")]
                TextArea = 2,
                [Description("LabelDropdown")]
                Dropdown = 3,
                [Description("LabelMultiSelect")]
                MultiSelect = 4,
                [Description("LabelRadioButtons")]
                RadioButtons = 5
            }
        }

        public class JobApplications
        {
            public enum ApplicationStatus
            {
                [Description("LabelApplied")]
                Applied = 1,
                [Description("LabelShortList")]
                ShortList = 2,
                [Description("LabelRejected")]
                Rejected = 4,
                [Description("LabelInterview")]
                Interview = 8,
                [Description("LabelOnHold")]
                OnHold = 16
            }

            public enum DocumentType
            {
                CoverLetter = 1,
                Resume = 2
            }
        }

        /// <summary>
        /// Created MimeTypes table this instead of the Database table
        /// </summary>
        public class MimeTypes
        {
            private static Dictionary<string, string> _dictionaryMimeTypes = new Dictionary<string, string>(){
                    {".cgm", "image/cgm"},
                    {".gif", "image/gif"},
                    {".jpeg", "image/jpeg"},
                    {".jpg", "image/jpeg"},
                    {".tiff", "image/tiff"},
                    {".png", "image/png"},
                    {".swf", "application/x-shockwave-flash"},
                    {".css", "text/css"},
                    {".xml", "text/xml"}
                };

            /// <summary>
            /// Get the Mime Type of the File Extension
            /// </summary>
            /// <param name="strFileExtension">File Extension</param>
            /// <returns></returns>
            public static string GetMimeType(string strFileExtension)
            {
                string value;

                if (_dictionaryMimeTypes.TryGetValue(strFileExtension, out value))
                {
                    return value;
                }

                return string.Empty;
            }
        }

        public class Search
        {
            public enum Redefine
            {
                Classification = 0,
                SubClassification = 1,
                Location = 2,
                Area = 3,
                WorkType = 4,
                Company = 5,
                Salary = 6,
                Country = 7
            }

            public enum SalaryType
            {
                Annual = 1,
                Hourly = 2,
                NA = 3,
                Daily = 4,
                Weekly = 5,
                Fortnightly = 6,
                BiWeekly = 7,
                BiMonthly = 8,
                Monthly = 9,
                Quarterly = 10,
                Yearly = 11
            }
        }

        public class SocialMedia
        {
            public enum SocialMediaType
            {
                Google = 1,
                Facebook = 2,
                //Twitter = 3,
                LinkedIn = 4,
                Indeed = 5,
                Seek = 6,
                Dropbox = 7,               
                GoogleDrive = 8,
                Salesforce = 9,
                GoogleMap = 10,
                Bullhorn = 11,
                BullhornOnBoardingSSO = 12,
                Invenias = 13
            }

            public enum OAuthCallbackAction
            {
                Login,
                Register,
                Apply,
                ApplyLogin,
            }

        }

    }
}
