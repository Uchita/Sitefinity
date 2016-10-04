using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace JXTPortal.JobApplications
{
    public class AicdSponsorshipFrontEndHelper
    {
        public static string GenerateEnumDropDown(string id, string name, string classes, Type enumType, string selectedValue, object attributes)
        {
            string attr = string.Empty;
            if (attributes != null)
            {
                var type = attributes.GetType();
                var props = type.GetProperties();
                var pairs = props.Select(x => x.Name + @"=""" + x.GetValue(attributes, null) + @"""").ToArray();
                attr = string.Join(" ", pairs);

                //because inputs not allow "-"
                attr = attr.Replace("datastyle", "data-style");
                attr = attr.Replace("datawidth", "data-width");
                attr = attr.Replace("datasize", "data-size");
            }

            StringBuilder sb = new StringBuilder();
            sb.Append(@"<select id=""" + id + @""" name=""" + name + @"""" + (string.IsNullOrEmpty(classes) ? string.Empty : @" class=""" + classes + @"""") + " " + attr + ">");

            foreach (var enumValue in Enum.GetValues(enumType))
            {
                string selected =
                        selectedValue != null
                        &&
                        (
                            enumValue.ToString().ToUpper().Equals(selectedValue.ToUpper()) //string compare of enum
                            ||
                            ((int)enumValue).ToString() == selectedValue //int value compare
                        )
                        ? @"selected=""selected""" : string.Empty;

                sb.Append(@"<option value=""" + enumValue.ToString() + @""" " + selected + ">" + enumValue.ToString() + "</option>");

            }
            sb.Append(@"</select>");

            return sb.ToString();
        }


        public static string GenerateDirectorshipOrgTypeDropDown(string id, string name, string classes, string defaultValue, object attributes)
        {
            Dictionary<string, string> orgTypes = new Dictionary<string, string> { 
                { "0", "- Please select -"},
                { "1", "ASX 200"},
                { "2", "Large (200+ employees) - listed"},
                { "3", "Large (200+ employees) - unlisted"},
                { "4", "Small-to-medium (10-199 employees) - listed"},
                { "5", "Small-to-medium (10-199 employees) - unlisted"},
                { "6", "Small (1-9 employees)"},
                { "7", "Not-for-profit"},
                { "8", "Government"}
            };

            string attr = string.Empty;
            if (attributes != null)
            {
                var type = attributes.GetType();
                var props = type.GetProperties();
                var pairs = props.Select(x => x.Name + @"=""" + x.GetValue(attributes, null) + @"""").ToArray();
                attr = string.Join(" ", pairs);
            }

            StringBuilder sb = new StringBuilder();

            sb.Append(@"<select id=""" + id + @""" name=""" + name + @"""" + (string.IsNullOrEmpty(classes) ? string.Empty : @" class=""" + classes + @"""") + " " + attr + ">");

            foreach (KeyValuePair<string, string> t in orgTypes)
            {
                string selectedText = defaultValue.ToUpper() == t.Key.ToUpper() ? @" selected=""selected""" : string.Empty;
                sb.Append(@"<option value=""" + t.Key + @"""" + selectedText + ">" + t.Value + "</option>");
            }

            sb.Append(@"</select>");

            return sb.ToString();
        }

        public static string GenerateDirectorshipOrgIndustryDropDown(string id, string name, string classes, string defaultValue, object attributes)
        {
            Dictionary<string, string> orgInds = new Dictionary<string, string> { 
                { "", "- Please select -"},
                { "1", "Accommodation and food services" },
                { "2", "Administrative and support services" },
                { "3", "Agriculture, forestry and fishing" },
                { "4", "Arts and recreation services" },
                { "5", "Construction" },
                { "6", "Education and training" },
                { "7", "Electricity, gas, water and waste services" },
                { "8", "Financial and insurance services" },
                { "9", "Healthcare and social assistance" },
                { "10", "Information media and telecommunications" },
                { "11", "Manufacturing" },
                { "12", "Mining" },
                { "14", "Professional, scientific and technical" },
                { "15", "Public administration safety"},
                { "16", "Retail, hiring and real estate services"},
                { "17", "Retail trade"},
                { "18", "Transport, postal and warehousing"},
                { "19", "Wholesale trade"},
                { "13", "Other" }
            };

            string attr = string.Empty;
            if (attributes != null)
            {
                var type = attributes.GetType();
                var props = type.GetProperties();
                var pairs = props.Select(x => x.Name + @"=""" + x.GetValue(attributes, null) + @"""").ToArray();
                attr = string.Join(" ", pairs);
            }

            StringBuilder sb = new StringBuilder();

            sb.Append(@"<select id=""" + id + @""" name=""" + name + @"""" + (string.IsNullOrEmpty(classes) ? string.Empty : @" class=""" + classes + @"""") + " " + attr + ">");

            foreach (KeyValuePair<string, string> t in orgInds)
            {
                string selectedText = defaultValue.ToUpper() == t.Key.ToUpper() ? @" selected=""selected""" : string.Empty;
                if (t.Key.Equals(string.Empty))
                    sb.Append(@"<option value=""" + t.Key + @"""" + selectedText + ">" + t.Value + "</option>");
                else
                    sb.Append(@"<option value=""" + t.Value + @"""" + selectedText + ">" + t.Value + "</option>");
            }

            sb.Append(@"</select>");

            return sb.ToString();
        }


        public static string GenerateMonthDropDown(string id, string name, string classes, int defaultValue, string spaceHolder)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(@"<select id=""" + id + @""" name=""" + name + @"""" + (string.IsNullOrEmpty(classes) ? string.Empty : @" class=""" + classes + @"""") + ">");

            if (!string.IsNullOrEmpty(spaceHolder))
                sb.Append("<option>" + spaceHolder + "</option>");

            DateTime startDate = new DateTime(2000, 1, 1);

            for (int i = 0; i < 12; i++)
            {
                DateTime thisDate = startDate.AddMonths(i);
                string selectedText = thisDate.Month == defaultValue ? @"selected=""selected""" : string.Empty;
                sb.Append(@"<option value=""" + thisDate.Month + @"""" + selectedText + ">" + thisDate.ToString("MMM") + "</option>");
            }

            sb.Append(@"</select>");

            return sb.ToString();
        }

        public static string GenerateYearDropDown(string id, string name, string classes, int lowerValue, int higherValue, int defaultValue, string placeHolder, string placeHolderValue)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(@"<select id=""" + id + @""" name=""" + name + @"""" + (string.IsNullOrEmpty(classes) ? string.Empty : @" class=""" + classes + @"""") + ">");

            if (!string.IsNullOrEmpty(placeHolder))
            {
                sb.Append(@"<option value=""" + placeHolderValue + @""">" + placeHolder + @"</option>");
            }

            for (int i = higherValue; i >= lowerValue; i--)
            {
                string selectedText = i == defaultValue ? @" selected=""selected""" : string.Empty;
                sb.Append(@"<option value=""" + i + @"""" + selectedText + ">" + i + "</option>");
            }

            sb.Append(@"</select>");

            return sb.ToString();
        }

        public static class ProfessionalRole
        {
            private static Dictionary<string, string> orgTypes = new Dictionary<string, string> { 
                    { "1", "Senior executive reporting directly to a board" },
                    { "2", "Manager" },
                    { "3", "Consultant" },
                    { "4", "Academic" },
                    //{ "5", "Student" }
                    { "6", "Other" } 
                    
                };

            public static string GenerateProfessionalRoleDropDown(string id, string name, string classes, string defaultValue, object attributes)
            {
                string attr = string.Empty;
                if (attributes != null)
                {
                    var type = attributes.GetType();
                    var props = type.GetProperties();
                    var pairs = props.Select(x => x.Name + @"=""" + x.GetValue(attributes, null) + @"""").ToArray();
                    attr = string.Join(" ", pairs);
                }

                StringBuilder sb = new StringBuilder();

                sb.Append(@"<select id=""" + id + @""" name=""" + name + @"""" + (string.IsNullOrEmpty(classes) ? string.Empty : @" class=""" + classes + @"""") + " " + attr + ">");

                foreach (KeyValuePair<string, string> t in orgTypes)
                {
                    string selectedText = defaultValue.ToUpper() == t.Key.ToUpper() ? @" selected=""selected""" : string.Empty;
                    sb.Append(@"<option value=""" + t.Key + @"""" + selectedText + ">" + t.Value + "</option>");
                }

                sb.Append(@"</select>");

                return sb.ToString();
            }

            public static string ProfessionalRoleFullTextFromEnumGet(string keyValue)
            {
                foreach (KeyValuePair<string, string> pair in orgTypes)
                {
                    if (keyValue.ToUpper().Equals(pair.Key.ToUpper()))
                        return pair.Value;
                }
                return string.Empty;

            }
        }

        public static class DirectorshipRole
        {
            private static Dictionary<string, string> orgTypes = new Dictionary<string, string> { 
                    { "1", "Non-executive director" },
                    { "2", "Executive director" },
                    { "3", "Business owner, partner or sole trader" }
                    //, { "4", "Others" } 
                };

            public static string GenerateDirectorshipRoleDropDown(string id, string name, string classes, string defaultValue, object attributes)
            {
                string attr = string.Empty;
                if (attributes != null)
                {
                    var type = attributes.GetType();
                    var props = type.GetProperties();
                    var pairs = props.Select(x => x.Name + @"=""" + x.GetValue(attributes, null) + @"""").ToArray();
                    attr = string.Join(" ", pairs);
                }

                StringBuilder sb = new StringBuilder();

                sb.Append(@"<select id=""" + id + @""" name=""" + name + @"""" + (string.IsNullOrEmpty(classes) ? string.Empty : @" class=""" + classes + @"""") + " " + attr + ">");

                foreach (KeyValuePair<string, string> t in orgTypes)
                {
                    string selectedText = defaultValue.ToUpper() == t.Key.ToUpper() ? @" selected=""selected""" : string.Empty;
                    sb.Append(@"<option value=""" + t.Key + @"""" + selectedText + ">" + t.Value + "</option>");
                }

                sb.Append(@"</select>");

                return sb.ToString();
            }

            public static string DirectorshipRoleFullTextFromEnumGet(string keyValue)
            {

                foreach (KeyValuePair<string, string> pair in orgTypes)
                {
                    if (keyValue.ToUpper().Equals(pair.Key.ToUpper()))
                        return pair.Value;
                }
                return string.Empty;

            }
        }



    }
}