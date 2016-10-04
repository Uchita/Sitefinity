using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Web.UI.WebControls;
using JXTPortal.JobApplications.Models;
using System.ComponentModel.DataAnnotations;
using System.Web.UI.HtmlControls;

namespace JXTPortal.JobApplications
{
    public class FormGenerator
    {
        public string FORM_XML_PATH = "/xml/AICD_Sponsorships.xml";

        public enum eAICDAppForm
        {
            LABEL = 0,
            SEQUENCE = 1,
            MAXLENGTH = 2,
            REQUIRED = 3,
            TYPE = 4,
            PLACEHOLDER = 5,
            ROWS = 6
        }

        public enum eAICDAppFormItem
        {
            NAME = 0,
            LISTITEMS = 1
        }

        public void GenerateForm(ref PlaceHolder plhFormHolder, QuestionaireValues[] questionaireValues, bool blnForPDF)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(System.Web.HttpContext.Current.Server.MapPath(FORM_XML_PATH));

                if (blnForPDF)
                    RenderForPDF(xmlDoc, ref plhFormHolder, questionaireValues);
                else
                    RenderForm(xmlDoc, ref plhFormHolder, questionaireValues);
            }
            catch (Exception ex)
            {
                Literal ltErrorMessage = new Literal();
                ltErrorMessage.Text = ex.Message;

                plhFormHolder.Controls.Add(ltErrorMessage);
            }
        }

        private bool AssignFormValue<T>(ref T control, QuestionaireValues[] questionaireValues) where T: System.Web.UI.Control
        {
            string id = control.ID;
            if (questionaireValues != null)
            {
                switch (control.GetType().Name)
                {
                    case "HtmlInputRadioButton":
                        {
                            if (questionaireValues.Where(q => q.name == id).FirstOrDefault() != null)
                                (control as HtmlInputRadioButton).Checked = true;
                            else
                                (control as HtmlInputRadioButton).Checked = false;
                        }
                        break;
                    case "HtmlInputCheckBox":
                        {
                            if (questionaireValues.Where(q => q.name == id).FirstOrDefault() != null)
                                (control as HtmlInputCheckBox).Checked = true;
                            else
                                (control as HtmlInputCheckBox).Checked = false;
                        }
                        break;
                    case "HtmlTextArea":
                        {
                            QuestionaireValues questionaireValue = questionaireValues.Where(q => q.name == id).FirstOrDefault();
                            if (questionaireValue != null)
                            {
                                (control as HtmlTextArea).InnerText = questionaireValue.value;
                            }
                        }
                        break;
                    default:
                        break;
                }
            }

            return true;
        }
        

        private void RenderForPDF(XmlDocument xmldoc, ref PlaceHolder plhFormHolder, QuestionaireValues[] questionaireValues)
        {

            XmlNode LabelNode = null;
            StringBuilder strBuilder = new StringBuilder();
            XmlNode ListItemsNode = null;
            XmlNode TypeNode = null;
            QuestionaireValues questionaireValue = new QuestionaireValues();
            string strValue = string.Empty;
            System.Collections.Specialized.NameValueCollection nvc = new System.Collections.Specialized.NameValueCollection();

            foreach (XmlNode itemnode in xmldoc.GetElementsByTagName("item"))
            {
                TypeNode = itemnode.ChildNodes[(int)eAICDAppForm.TYPE];
                LabelNode = itemnode.ChildNodes[(int)eAICDAppForm.LABEL];
                ListItemsNode = TypeNode.ChildNodes[(int)eAICDAppFormItem.LISTITEMS];

                strValue = string.Empty;

                if (questionaireValues != null)
                {
                    foreach (XmlNode xmlnode in ListItemsNode.ChildNodes)
                    {
                        questionaireValue = questionaireValues.Where(q => q.name == xmlnode["id"].InnerText).FirstOrDefault();
                        if (questionaireValue != null)
                        {
                            if (!string.IsNullOrWhiteSpace(strValue))
                                strValue = strValue + ", " + questionaireValue.value;
                            else
                                strValue = questionaireValue.value;
                        }
                    }
                }

                strBuilder.AppendFormat(@"<div class='col-md-4 question'><p>{0}</p></div><div class='col-md-8'><p>{1}</p></div>", LabelNode.InnerText, strValue);
            }

            Literal literal = new Literal();
            literal.Text = strBuilder.ToString();

            plhFormHolder.Controls.Add(literal);
        }

        private void RenderForm(XmlDocument xmldoc, ref PlaceHolder plhFormHolder, QuestionaireValues[] questionaireValues)
        {
            XmlNode LabelNode = null;
            XmlNode SequenceNode = null;
            XmlNode MaxLengthNode = null;
            XmlNode TextareaRowsNode = null;
            XmlNode RequiredNode = null;
            XmlNode TypeNode = null;
            XmlNode PlaceHolderNode = null;

            string typename = string.Empty;
            XmlNode ListItemsNode = null;
            string labelfor = string.Empty;

            System.Web.UI.HtmlControls.HtmlGenericControl formGroup = null;
            System.Web.UI.HtmlControls.HtmlGenericControl label = null;

            foreach (XmlNode itemnode in xmldoc.GetElementsByTagName("item"))
            {
                LabelNode = itemnode.ChildNodes[(int)eAICDAppForm.LABEL];
                SequenceNode = itemnode.ChildNodes[(int)eAICDAppForm.SEQUENCE];
                MaxLengthNode = itemnode.ChildNodes[(int)eAICDAppForm.MAXLENGTH];
                TextareaRowsNode = itemnode.ChildNodes[(int)eAICDAppForm.ROWS];
                RequiredNode = itemnode.ChildNodes[(int)eAICDAppForm.REQUIRED];
                TypeNode = itemnode.ChildNodes[(int)eAICDAppForm.TYPE];
                PlaceHolderNode = itemnode.ChildNodes[(int)eAICDAppForm.PLACEHOLDER];

                typename = TypeNode.ChildNodes[(int)eAICDAppFormItem.NAME].InnerText;
                ListItemsNode = TypeNode.ChildNodes[(int)eAICDAppFormItem.LISTITEMS];
                labelfor = ListItemsNode.ChildNodes[0]["name"].InnerText;
                XmlNode radionode = null;
                System.Web.UI.HtmlControls.HtmlGenericControl divContol = null;
                System.Web.UI.HtmlControls.HtmlGenericControl itemLabel = null;
                System.Web.UI.HtmlControls.HtmlInputRadioButton radiobutton = null;
                Literal radiolabel = null;
                System.Web.UI.HtmlControls.HtmlGenericControl spanRequired = null;
                System.Web.UI.HtmlControls.HtmlGenericControl divcheckbox = null;
                System.Web.UI.HtmlControls.HtmlTextArea textarea = new System.Web.UI.HtmlControls.HtmlTextArea();

                if (typename == "Radio")
                {
                    formGroup = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                    formGroup.Attributes["class"] = "form-group";

                    plhFormHolder.Controls.Add(formGroup);

                    label = new System.Web.UI.HtmlControls.HtmlGenericControl("label");
                    label.Attributes["class"] = "control-label";
                    label.Attributes["for"] = labelfor;
                    label.InnerText = LabelNode.InnerText;

                    formGroup.Controls.Add(label);


                    for (int i = 0; i < ListItemsNode.ChildNodes.Count; i++)
                    {
                        radionode = ListItemsNode.ChildNodes[i];

                        divContol = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                        divContol.Attributes["class"] = "radio";

                        formGroup.Controls.Add(divContol);

                        itemLabel = new System.Web.UI.HtmlControls.HtmlGenericControl("label");
                        divContol.Controls.Add(itemLabel);

                        radiobutton = new System.Web.UI.HtmlControls.HtmlInputRadioButton();
                        radiobutton.ID = radionode["id"].InnerText;
                        radiobutton.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                        radiobutton.Name = radionode["name"].InnerText;
                        radiobutton.Value = radionode["text"].InnerText; //radionode["value"].InnerText
                        radiobutton.Checked = (radionode["checked"].InnerText == "true") ? true : false;

                        radiobutton.ClientIDMode = System.Web.UI.ClientIDMode.Static;

                        if (RequiredNode.InnerText == "true" && i == 0)
                        {
                            radiobutton.Attributes["required"] = "";
                        }

                        // Assign the values
                        AssignFormValue(ref radiobutton, questionaireValues);

                        itemLabel.Controls.Add(radiobutton);

                        labelfor = itemLabel.Controls[0].UniqueID.Remove(itemLabel.Controls[0].UniqueID.Length - 1);

                        radiolabel = new Literal();
                        radiolabel.Text = radionode["text"].InnerText;

                        itemLabel.Controls.Add(radiolabel);
                    }

                    if (RequiredNode.InnerText == "true")
                    {
                        spanRequired = new System.Web.UI.HtmlControls.HtmlGenericControl("span");
                        spanRequired.Attributes["class"] = "field-validation-error";
                        spanRequired.Attributes["data-valmsg-for"] = radiobutton.Name; //labelfor;
                        spanRequired.Attributes["data-valmsg-replace"] = "true";
                        spanRequired.Attributes["style"] = "color: Red";

                        formGroup.Controls.Add(spanRequired);
                    }
                }
                else if (typename == "Checkbox")
                {
                    formGroup = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                    formGroup.Attributes["class"] = "form-group";

                    plhFormHolder.Controls.Add(formGroup);

                    label = new System.Web.UI.HtmlControls.HtmlGenericControl("label");
                    label.Attributes["class"] = "control-label";
                    label.Attributes["for"] = labelfor;
                    label.InnerText = LabelNode.InnerText;

                    formGroup.Controls.Add(label);

                    foreach (XmlNode xmlnode in ListItemsNode.ChildNodes)
                    {
                        divcheckbox = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                        divcheckbox.Attributes["class"] = "checkbox";
                        formGroup.Controls.Add(divcheckbox);

                        itemLabel = new System.Web.UI.HtmlControls.HtmlGenericControl("label");
                        divcheckbox.Controls.Add(itemLabel);

                        System.Web.UI.HtmlControls.HtmlInputCheckBox checkbox = new System.Web.UI.HtmlControls.HtmlInputCheckBox();
                        checkbox.ID = xmlnode["id"].InnerText;
                        checkbox.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                        checkbox.Name = xmlnode["name"].InnerText;
                        checkbox.Value = xmlnode["text"].InnerText; //xmlnode["value"].InnerText
                        checkbox.Checked = (xmlnode["checked"].InnerText == "true") ? true : false;

                        // Assign the values
                        AssignFormValue(ref checkbox, questionaireValues);

                        itemLabel.Controls.Add(checkbox);

                        radiolabel = new Literal();
                        radiolabel.Text = xmlnode["text"].InnerText;

                        itemLabel.Controls.Add(radiolabel);
                    }
                }
                else if (typename == "TextBox")
                {
                    formGroup = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                    formGroup.Attributes["class"] = "form-group";

                    plhFormHolder.Controls.Add(formGroup);

                    label = new System.Web.UI.HtmlControls.HtmlGenericControl("label");
                    label.Attributes["class"] = "control-label";
                    label.Attributes["for"] = labelfor;
                    label.InnerText = LabelNode.InnerText;

                    formGroup.Controls.Add(label);

                    foreach (XmlNode xmlnode in ListItemsNode.ChildNodes)
                    {
                        textarea = new System.Web.UI.HtmlControls.HtmlTextArea();
                        textarea.ID = xmlnode["id"].InnerText;
                        textarea.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                        textarea.Name = xmlnode["name"].InnerText;

                        if (!string.IsNullOrWhiteSpace(MaxLengthNode.InnerText))
                        {
                            textarea.Attributes["maxlength"] = MaxLengthNode.InnerText;
                        }
                        if (!string.IsNullOrWhiteSpace(TextareaRowsNode.InnerText))
                        {
                            textarea.Attributes["rows"] = TextareaRowsNode.InnerText;
                        }

                        //data-val="true" data-val-required="Please fill in the required field"
                        if (RequiredNode.InnerText == "true")
                        {
                            
                            //textarea.Attributes["data-val"] = "true";
                            //textarea.Attributes["data-val-required"] = "Please fill in the required field";
                        }
                        
                        textarea.ClientIDMode = System.Web.UI.ClientIDMode.Static;

                        textarea.Attributes["autocomplete"] = "off";

                        // Assign the values
                        AssignFormValue(ref textarea, questionaireValues);

                        formGroup.Controls.Add(textarea);

                        if (RequiredNode.InnerText == "true")
                        {
                            spanRequired = new System.Web.UI.HtmlControls.HtmlGenericControl("span");
                            spanRequired.Attributes["class"] = "field-validation-error";
                            spanRequired.Attributes["data-valmsg-for"] = textarea.ID;
                            spanRequired.Attributes["data-valmsg-replace"] = "true";
                            spanRequired.Attributes["style"] = "color: Red";

                            formGroup.Controls.Add(spanRequired);
                        }
                    }
                }
            }
        }

        private bool isCheckValid(string checkID, QuestionaireValues[] tabValues, bool blnCheckTextBoxEmpty)
        {
            QuestionaireValues tabValue = tabValues.Where(a => a.name == checkID).FirstOrDefault();

            // Textbox not empty validation
            if (tabValue != null && blnCheckTextBoxEmpty)
            {
                if (string.IsNullOrWhiteSpace(tabValue.value))
                    return true;
                else
                    return false;
            }

            // Find the radio button
            return (tabValue == null ? true : false);
        }

        public List<ValidationResult> ValidateForm(QuestionaireValues[] tabValues)
        {

            List<ValidationResult> logicResults = new List<ValidationResult>();
            
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(System.Web.HttpContext.Current.Server.MapPath(FORM_XML_PATH));

            string typename = string.Empty;
            XmlNode TypeNode = null;
            XmlNode ListItemsNode = null;
            XmlNode RequiredNode = null;

            bool blnNotValid = false;
            string strID = string.Empty;

            foreach (XmlNode itemnode in xmlDoc.GetElementsByTagName("item"))
            {
                TypeNode = itemnode.ChildNodes[(int)eAICDAppForm.TYPE];
                typename = TypeNode.ChildNodes[(int)eAICDAppFormItem.NAME].InnerText;
                ListItemsNode = TypeNode.ChildNodes[(int)eAICDAppFormItem.LISTITEMS];
                RequiredNode = itemnode.ChildNodes[(int)eAICDAppForm.REQUIRED];
                
                XmlNode radionode = null;
                
                blnNotValid = false;
                strID = string.Empty;

                if (typename == "Radio")
                {
                    if (RequiredNode.InnerText == "true")
                    {
                        // By default its not valid
                        blnNotValid = true;
                        for (int i = 0; i < ListItemsNode.ChildNodes.Count; i++)
                        {
                            radionode = ListItemsNode.ChildNodes[i];

                            strID = radionode["id"].InnerText;


                            QuestionaireValues tabValue = tabValues.Where(a => a.name == strID).FirstOrDefault();

                            if (tabValue != null)
                            {
                                blnNotValid = false;
                                break;
                            }
                            /*
                            if (isCheckValid(radionode["id"].InnerText, tabValues, false))
                            {
                                blnNotValid = false;
                                break;
                            }
                            else
                                blnNotValid = true;*/

                        }

                        if (blnNotValid)
                        {
                            logicResults.Add(new ValidationResult("Please fill in the required field", new List<string> { radionode["name"].InnerText }));
                        }

                    }
                }
                else if (typename == "Checkbox")
                {
                    /*
                    foreach (XmlNode xmlnode in ListItemsNode.ChildNodes)
                    {
                        
                        System.Web.UI.HtmlControls.HtmlInputCheckBox checkbox = new System.Web.UI.HtmlControls.HtmlInputCheckBox();
                        checkbox.ID = xmlnode["id"].InnerText;
                        checkbox.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                        checkbox.Name = xmlnode["name"].InnerText;
                        checkbox.Value = xmlnode["text"].InnerText; //xmlnode["value"].InnerText
                        checkbox.Checked = (xmlnode["checked"].InnerText == "true") ? true : false;

                    }*/
                }
                else if (typename == "TextBox")
                {
                    
                    foreach (XmlNode xmlnode in ListItemsNode.ChildNodes)
                    {
                    
                        //data-val="true" data-val-required="Please fill in the required field"
                        if (RequiredNode.InnerText == "true")
                        {
                            if (isCheckValid(xmlnode["id"].InnerText, tabValues,true))
                            {
                                logicResults.Add(new ValidationResult("Please fill in the required field", new List<string> { xmlnode["id"].InnerText }));
                            }
                        }

                    }
                }
            }

            return logicResults;
        }

        /*
         
<?xml version="1.0" encoding="utf-8" ?>
<items>
	<item>
		<id>blnScholarship1Q1</id>
		<label>For which course are you applying for a scholarship?</label>
		<type>Radio</type>
		<value>true</value>
		<text>Company Directors Course</text>
	</item>
	<item>
		<id>chkScholarship2Q1</id>
		<label>Have you attended any of the following courses with the Australian Institute of Company Directors?</label>
		<type>Checkbox</type>
		<value>true</value>
		<text>Foundations of Directorship</text>
	</item>
	
	<item>
		<id>scholarAdd1</id>
		<label>Your awards, achievements, community or social involvement</label>
		<type>TextBox</type>
		<value></value>
		<text>Some text goes here</text>
	</item>
</items>	
	
         
         */
    }
}
