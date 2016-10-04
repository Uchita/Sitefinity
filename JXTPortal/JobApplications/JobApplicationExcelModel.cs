using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXTPortal.JobApplications.Models;
using System.Xml;

namespace JXTPortal.JobApplications
{

    public class JobApplicationExcelModel
    {
        int HARDCODED_VALUES = 7;

        public Dictionary<int, string> headers { get; set; }
        public List<ExcelDisplayRow> rows { get; set; }

        public JobApplicationExcelModel()
        {
            headers = new Dictionary<int, string>();
            rows = new List<ExcelDisplayRow>();
        }

        private bool AddNewHeaderColumnValue(int sequence, string value)
        {
            if (headers.Keys.Contains(sequence))
                return false;

            headers.Add(sequence, value);
            return true;
        }




        public JobApplicationExcelModel GenerateExcelModel(XmlDocument customDefinitionXML, List<JobAppCustomValues> applications)
        {
            JobApplicationExcelModel excelModel = new JobApplicationExcelModel();

            XmlNode LabelNode;
            XmlNode sequenceNode;

            Dictionary<int, string> appValuesDictBase = new Dictionary<int, string>();

            excelModel.AddNewHeaderColumnValue(0, "ApplicationDate");
            excelModel.AddNewHeaderColumnValue(1, "ApplicationStatus");
            excelModel.AddNewHeaderColumnValue(2, "FirstName");
            excelModel.AddNewHeaderColumnValue(3, "Surname");
            excelModel.AddNewHeaderColumnValue(4, "EmailAddress");
            excelModel.AddNewHeaderColumnValue(5, "MobilePhone");
            excelModel.AddNewHeaderColumnValue(6, "Postcode");
            excelModel.AddNewHeaderColumnValue(7, "State");

            appValuesDictBase.Add(0, "ApplicationDate");
            appValuesDictBase.Add(1, "ApplicationStatus");
            appValuesDictBase.Add(2, "FirstName");
            appValuesDictBase.Add(3, "Surname");
            appValuesDictBase.Add(4, "EmailAddress");
            appValuesDictBase.Add(5, "MobilePhone");
            appValuesDictBase.Add(6, "Postcode");
            appValuesDictBase.Add(7, "State");

            //process the header
            foreach (XmlNode itemnode in customDefinitionXML.GetElementsByTagName("item"))
            {
                //get label value
                LabelNode = itemnode.ChildNodes[(int)FormGenerator.eAICDAppForm.LABEL];

                //get sequence value
                sequenceNode = itemnode.ChildNodes[(int)FormGenerator.eAICDAppForm.SEQUENCE];

                //this adds the label and sequence of the question into the header display
                //this will also return true if added, or false if sequence already exists
                excelModel.AddNewHeaderColumnValue(int.Parse(sequenceNode.InnerText) + HARDCODED_VALUES, LabelNode.InnerText);

                appValuesDictBase.Add(int.Parse(sequenceNode.InnerText) + HARDCODED_VALUES, string.Empty);

            }

            XmlNode TypeNode;
            XmlNode ListItemsInItemType;
            XmlNode SequenceNode;
            ExcelDisplayRow newRow;

            //process each application
            foreach (JobAppCustomValues app in applications)
            {

                Dictionary<int, string> thisAppValues = new Dictionary<int,string>(appValuesDictBase);

                //loop each selected value for this application
                if (app.selectedValues != null)
                {
                    foreach (QuestionaireValues qVal in app.selectedValues)
                    {
                        //loop through each <item> in the xml
                        foreach (XmlNode itemnode in customDefinitionXML.GetElementsByTagName("item"))
                        {
                            TypeNode = itemnode.ChildNodes[(int)FormGenerator.eAICDAppForm.TYPE];
                            ListItemsInItemType = TypeNode.ChildNodes[(int)FormGenerator.eAICDAppFormItem.LISTITEMS];

                            //loop through each <listitem> under the <item>
                            foreach (XmlNode xmlnode in ListItemsInItemType.ChildNodes)
                            {
                                if (qVal.name == xmlnode["id"].InnerText)
                                {
                                    SequenceNode = itemnode.ChildNodes[(int)FormGenerator.eAICDAppForm.SEQUENCE];
                                    //newRow.AddColumnValue(int.Parse(SequenceNode.InnerText), qVal.value);

                                    // If checkbox multiple are ticked then append with ,
                                    if (!string.IsNullOrWhiteSpace(thisAppValues[(int.Parse(SequenceNode.InnerText)) + HARDCODED_VALUES]))
                                        thisAppValues[(int.Parse(SequenceNode.InnerText)) + HARDCODED_VALUES] = thisAppValues[(int.Parse(SequenceNode.InnerText)) + HARDCODED_VALUES] + ", " + qVal.value;
                                    else
                                        thisAppValues[(int.Parse(SequenceNode.InnerText)) + HARDCODED_VALUES] = qVal.value;
                                }


                            }//end foreach <listitem>

                        }//end foreach <item>

                    }
                }

                thisAppValues[0] = app.ApplicationDate;
                thisAppValues[1] =app.ApplicationStatus;
                thisAppValues[2] =app.FirstName;
                thisAppValues[3] =app.Surname;
                thisAppValues[4] = app.EmailAddress;
                thisAppValues[5] = app.MobilePhone;
                thisAppValues[6] = app.Postcode;
                thisAppValues[7] = app.State;

                //put the dictionary back to the row
                newRow = new ExcelDisplayRow(app.applicationID, thisAppValues);
                
                //add the row to the excel data
                excelModel.rows.Add(newRow);

            }

            return excelModel;
        }

    }

    public class ExcelDisplayRow
    {
        public string applicationID { get; set; }
        public Dictionary<int, string> rowValues { get; set; }

        public ExcelDisplayRow(string appID, Dictionary<int, string> _rowValues)
        {
            applicationID = appID;
            rowValues = _rowValues;
        }
    }

    public class JobAppCustomValues
    {
        public string applicationID { get; set; }
        public string ApplicationDate { get; set; } 
        public string ApplicationStatus { get; set; } 
        public string FirstName { get; set; } 
        public string Surname { get; set; }
        public string EmailAddress { get; set; }
        public string MobilePhone { get; set; }
        public string Postcode { get; set; }
        public string State { get; set; } 
        

        public QuestionaireValues[] selectedValues { get; set; }

        public JobAppCustomValues(string _applicationID, string _ApplicationDate, string _ApplicationStatus,
                                    string _FirstName, string _Surname, string _EmailAddress, string _MobilePhone, string _Postcode, string _State, QuestionaireValues[] _selectedValues)
        
        {
            applicationID = _applicationID;
            selectedValues = _selectedValues;
            ApplicationDate = _ApplicationDate;
            ApplicationStatus = _ApplicationStatus;
            FirstName = _FirstName;
            Surname = _Surname;
            EmailAddress = _EmailAddress;
            MobilePhone = _MobilePhone;
            Postcode = _Postcode;
            State = _State;
        }
    }


}
