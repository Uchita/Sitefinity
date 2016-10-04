using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Xml;

namespace JXTPortal.Website
{
    public partial class AICD_ApplictionForm : System.Web.UI.Page
    {
        private enum eAICDAppForm
        {
            LABEL = 0,
            SEQUENCE = 1,
            MAXLENGTH = 2,
            REQUIRED = 3,
            TYPE = 4,
            PLACEHOLDER = 5
        }

        private enum eAICDAppFormItem
        {
            NAME = 0,
            LISTITEMS = 1
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(MapPath("/xml/AICD_Sponsorships.xml"));

                RenderForm(xmlDoc);
            }
            catch (Exception ex)
            {
                Literal ltErrorMessage = new Literal();
                ltErrorMessage.Text = ex.Message;

                aicdApplicationFormContainer.Controls.Add(ltErrorMessage);
            }
        }

        private void RenderForm(XmlDocument xmldoc)
        {
            foreach (XmlNode itemnode in xmldoc.GetElementsByTagName("item"))
            {
                XmlNode LabelNode = itemnode.ChildNodes[(int)eAICDAppForm.LABEL];
                XmlNode SequenceNode = itemnode.ChildNodes[(int)eAICDAppForm.SEQUENCE];
                XmlNode MaxLengthNode = itemnode.ChildNodes[(int)eAICDAppForm.MAXLENGTH];
                XmlNode RequiredNode = itemnode.ChildNodes[(int)eAICDAppForm.REQUIRED];
                XmlNode TypeNode = itemnode.ChildNodes[(int)eAICDAppForm.TYPE];
                XmlNode PlaceHolderNode = itemnode.ChildNodes[(int)eAICDAppForm.PLACEHOLDER];

                string typename = TypeNode.ChildNodes[(int)eAICDAppFormItem.NAME].InnerText;
                XmlNode ListItemsNode = TypeNode.ChildNodes[(int)eAICDAppFormItem.LISTITEMS];
                string labelfor = ListItemsNode.ChildNodes[0]["name"].InnerText;

                if (typename == "Radio")
                {
                    System.Web.UI.HtmlControls.HtmlGenericControl formGroup = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                    formGroup.Attributes["class"] = "form-group";

                    aicdApplicationFormContainer.Controls.Add(formGroup);

                    System.Web.UI.HtmlControls.HtmlGenericControl label = new System.Web.UI.HtmlControls.HtmlGenericControl("label");
                    label.Attributes["class"] = "control-label";
                    label.Attributes["for"] = labelfor;
                    label.InnerText = LabelNode.InnerText;

                    formGroup.Controls.Add(label);


                    for (int i = 0; i < ListItemsNode.ChildNodes.Count; i++)
                    {
                        XmlNode xmlnode = ListItemsNode.ChildNodes[i];

                        System.Web.UI.HtmlControls.HtmlGenericControl divContol = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                        divContol.Attributes["class"] = "radio";

                        formGroup.Controls.Add(divContol);

                        System.Web.UI.HtmlControls.HtmlGenericControl itemLabel = new System.Web.UI.HtmlControls.HtmlGenericControl("label");
                        divContol.Controls.Add(itemLabel);

                        System.Web.UI.HtmlControls.HtmlInputRadioButton radiobutton = new System.Web.UI.HtmlControls.HtmlInputRadioButton();
                        radiobutton.ID = xmlnode["id"].InnerText;
                        radiobutton.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                        radiobutton.Name = xmlnode["name"].InnerText;
                        radiobutton.Value = xmlnode["value"].InnerText;
                        radiobutton.Checked = (xmlnode["checked"].InnerText == "true") ? true : false;

                        if (RequiredNode.InnerText == "true" && i == 0)
                        {
                            radiobutton.Attributes["required"] = "";
                        }

                        itemLabel.Controls.Add(radiobutton);

                        Literal radiolabel = new Literal();
                        radiolabel.Text = xmlnode["text"].InnerText;

                        itemLabel.Controls.Add(radiolabel);
                    }

                    if (RequiredNode.InnerText == "true")
                    {
                        System.Web.UI.HtmlControls.HtmlGenericControl spanRequired = new System.Web.UI.HtmlControls.HtmlGenericControl("span");
                        spanRequired.Attributes["class"] = "field-validation-valid";
                        spanRequired.Attributes["data-valmsg-for"] = labelfor;
                        spanRequired.Attributes["data-valmsg-replace"] = "true";
                        spanRequired.Attributes["style"] = "color: Red";

                        formGroup.Controls.Add(spanRequired);
                    }
                }
                else if (typename == "Checkbox")
                {
                    System.Web.UI.HtmlControls.HtmlGenericControl formGroup = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                    formGroup.Attributes["class"] = "form-group";

                    aicdApplicationFormContainer.Controls.Add(formGroup);

                    Label label = new Label();
                    label.CssClass = "control-label";
                    label.Attributes["for"] = labelfor;
                    label.Text = LabelNode.InnerText;

                    formGroup.Controls.Add(label);

                    foreach (XmlNode xmlnode in ListItemsNode.ChildNodes)
                    {
                        System.Web.UI.HtmlControls.HtmlGenericControl divcheckbox = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                        divcheckbox.Attributes["class"] = "checkbox";
                        formGroup.Controls.Add(divcheckbox);

                        System.Web.UI.HtmlControls.HtmlGenericControl itemLabel = new System.Web.UI.HtmlControls.HtmlGenericControl("label");
                        divcheckbox.Controls.Add(itemLabel);

                        System.Web.UI.HtmlControls.HtmlInputCheckBox checkbox = new System.Web.UI.HtmlControls.HtmlInputCheckBox();
                        checkbox.ID = xmlnode["id"].InnerText;
                        checkbox.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                        checkbox.Name = xmlnode["name"].InnerText;
                        checkbox.Value = xmlnode["value"].InnerText;
                        checkbox.Checked = (xmlnode["checked"].InnerText == "true") ? true : false;

                        itemLabel.Controls.Add(checkbox);

                        Literal radiolabel = new Literal();
                        radiolabel.Text = xmlnode["text"].InnerText;

                        itemLabel.Controls.Add(radiolabel);
                    }
                }
                else if (typename == "TextBox")
                {
                    System.Web.UI.HtmlControls.HtmlGenericControl formGroup = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                    formGroup.Attributes["class"] = "form-group";

                    aicdApplicationFormContainer.Controls.Add(formGroup);

                    System.Web.UI.HtmlControls.HtmlGenericControl label = new System.Web.UI.HtmlControls.HtmlGenericControl("label");
                    label.Attributes["class"] = "control-label";
                    label.Attributes["for"] = labelfor;
                    label.InnerText = LabelNode.InnerText;

                    formGroup.Controls.Add(label);

                    foreach (XmlNode xmlnode in ListItemsNode.ChildNodes)
                    {
                        System.Web.UI.HtmlControls.HtmlTextArea textarea = new System.Web.UI.HtmlControls.HtmlTextArea();
                        textarea.ID = xmlnode["id"].InnerText;
                        textarea.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                        textarea.Name = xmlnode["name"].InnerText;

                        if (!string.IsNullOrWhiteSpace(MaxLengthNode.InnerText))
                        {
                            textarea.Attributes["maxlength"] = MaxLengthNode.InnerText;
                        }

                        if (RequiredNode.InnerText == "true")
                        {
                            textarea.Attributes["required"] = "required";
                        }

                        formGroup.Controls.Add(textarea);

                        if (RequiredNode.InnerText == "true")
                        {
                            System.Web.UI.HtmlControls.HtmlGenericControl spanRequired = new System.Web.UI.HtmlControls.HtmlGenericControl("span");
                            spanRequired.Attributes["class"] = "field-validation-valid";
                            spanRequired.Attributes["data-valmsg-for"] = textarea.Name;
                            spanRequired.Attributes["data-valmsg-replace"] = "true";
                            spanRequired.Attributes["style"] = "color: Red";

                            formGroup.Controls.Add(spanRequired);
                        }
                    }
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

        }
    }
}