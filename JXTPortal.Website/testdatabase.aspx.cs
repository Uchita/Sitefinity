using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace JXTPortal.Website
{
    partial class testdatabase : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string strConnection = System.Configuration.ConfigurationSettings.AppSettings["SQLServer1"];
            SqlConnection conn = new SqlConnection(strConnection);

            try
            {

                conn.Open();
                Response.Write("<h1>SUCCESS</h1>");

                if (!Page.IsPostBack)
                {
                    GenerateButtons();

                }
                if (Request.Form["__EVENTTARGET"] != null && Request.Form["__EVENTTARGET"] == "btnSave")
                {
                    btnAsp_Click(null, null);
                }

//                string dynamiccontent = @"First Name: [[FIRSTNAME]]<br />
//                                          Surame: [[SURNAME]]<br />
//                                           [[SAVE]]";


//                string firstnameinput = string.Format("<input id=\"BullHorn_FirstName\" type=\"text\"  />");

//                dynamiccontent = dynamiccontent.Replace("[[FIRSTNAME]]", firstnameinput);

//                string saveinput = string.Format("<input id=\"BullHorn_Save\" type=\"submit\" value=\"Save\" />");

//                dynamiccontent = dynamiccontent.Replace("[[SAVE]]", saveinput);

//                ltBullHorn.Text = dynamiccontent;

                
            }
            catch (Exception ex)
            {
                Response.Write(HttpUtility.HtmlEncode(ex.Message));
                Response.Write("<br>");
                Response.Write(HttpUtility.HtmlEncode(ex.StackTrace));
            }
            finally
            {
                conn.Close();
            }
        }

        private void GenerateButtons()
        {
            string dynamiccontent = @"First Name: [[FIRSTNAME]]<br />
                                      Surame: [[SURNAME]]<br />
                                      Drop Down: <select id=""BullHorn_DropDown"" name=""BullHorn_DropDown"">
                                                    <option value=""1"">Drop Down 1</option>
                                                    <option value=""2"">Drop Down 2</option>
                                                    <option value=""3"">Drop Down 3</option>
                                                 </select><br />
                                      Radio: <input type=""radio"" name=""BullHorn_Radio"" value=""1"" /> Radio 1 <input type=""radio"" name=""BullHorn_Radio"" value=""2"" /> Radio 2<input type=""radio"" name=""BullHorn_Radio"" value=""3"" /> Radio 3<br />
                                      CheckBox: <input type=""checkbox"" name=""BullHorn_CheckBox_1"" value=""1"" /> CheckBox 1<input type=""checkbox"" name=""BullHorn_CheckBox_2"" value=""2"" /> CheckBox 2<input type=""checkbox"" name=""BullHorn_CheckBox_3"" value=""3"" /> CheckBox 3
                                      [[SAVE]]";


            string firstnameinput = string.Format("<input id=\"BullHorn_FirstName\" name=\"BullHorn_FirstName\" type=\"text\"  />");

            dynamiccontent = dynamiccontent.Replace("[[FIRSTNAME]]", firstnameinput);

            string surnameinput = string.Format("<input id=\"BullHorn_Surname\" name=\"BullHorn_Surname\" type=\"text\"  />");

            dynamiccontent = dynamiccontent.Replace("[[SURNAME]]", surnameinput);

            string saveinput = string.Format("<input type='button' id='btnSave' value='Save' onclick='javascript:__doPostBack(\"btnSave\",\"\");' >");

            dynamiccontent = dynamiccontent.Replace("[[SAVE]]", saveinput);

            ltBullHorn.Text = dynamiccontent;
        }

        private void btnAsp_Click(object sender, System.EventArgs e)
        {
            Response.Write("You Clicked on " + Request.Form["__EVENTARGUMENT"].ToString());
        }   

    }
}
