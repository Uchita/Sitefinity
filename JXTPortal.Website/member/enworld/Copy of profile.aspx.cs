using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Client.Salesforce;
using System.Web.Script.Serialization;
using System.Text;
using System.Web.Services;
using System.ComponentModel.DataAnnotations;
using JXTPortal.Entities;
using System.Configuration;

namespace JXTPortal.Website.member.enworld
{
    public partial class __profile : System.Web.UI.Page
    {
        public string _SFContactID;
        private SalesforceIntegration.SObjDescribeResponse _SFFormModel;
        private SalesforceIntegration.SObjBatchObject _SFContactModel;

        protected void Page_Init(object sender, EventArgs e)
        {
            //redirect to custom
            if (!string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["EnworldSiteID"]) &&
            !ConfigurationManager.AppSettings["EnworldSiteID"].Contains(" " + SessionData.Site.SiteId + " "))
            {
                Response.Redirect("/member/default.aspx");
                return;
            }

            CommonPage.SetBrowserPageTitle(Page, "Update Profile");
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (SessionData.Member == null)
            {
                Response.Redirect("~/member/login.aspx?returnurl=" + Server.UrlEncode(Request.Url.PathAndQuery));
                return;
            }

            _SFContactID = SFContactIDGetFromSessionMember();


            if (string.IsNullOrEmpty(_SFContactID))
            {
                //error
                MembersService _ms = new MembersService();
                Entities.Members thisMember = _ms.GetByMemberId(SessionData.Member.MemberId);

                SalesforceMemberSync sfSync = new SalesforceMemberSync();
                sfSync.CheckContactAndSaveInSalesForce(thisMember, SessionData.Site.SiteId, false, out _SFContactID);

                if (string.IsNullOrEmpty(_SFContactID))
                {
                    ltGeneralMessage.Text = Common.Utils.MessageDisplayWrapper("Unable to validate member record. Please contact support.", Common.BootstrapAlertType.Danger);
                    plCVBuilder.Visible = false;
                    return;
                }
            }


            bool dataGetSuccess = FormGetFromSF();
            if (!dataGetSuccess)
            {
                ltGeneralMessage.Text = Common.Utils.MessageDisplayWrapper("Unable to connect to integration service. Please contact support.", Common.BootstrapAlertType.Danger);
                plCVBuilder.Visible = false;
                return;
            }

            bool data2GetSuccess = FormGetObjectsFromSF();
            if (!data2GetSuccess)
            {
                ltGeneralMessage.Text = Common.Utils.MessageDisplayWrapper("Unable to connect to integration service. Please contact support.", Common.BootstrapAlertType.Danger);
                plCVBuilder.Visible = false;
                return;
            }

            FormSetup();


            return;
        }

        private bool FormGetFromSF()
        {
            //get from salesforce
            SalesforceIntegration sfInt = new SalesforceIntegration();

            string errorMsg;
            bool describeGetSuccess = sfInt.PostSObjectDescribeBatchRequest(new string[] { "ts2__Education_History__c", "jsexpobjects__Team__c", "jsexpobjects__Ranking__c", "jsexpobjects__Legodo_Email_Batch__c" }, out _SFFormModel, out errorMsg);

            if (!describeGetSuccess)
            {
                //show error message
            }
            return describeGetSuccess;
        }

        #region Form Setup
        private void FormSetup()
        {
            PreserveDataToJavascript();

            JobFunctionSetup();
            SectorExperienceSetup();
            EducationHistorySetup();
        }

        private void PreserveDataToJavascript()
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            StringBuilder sb = new StringBuilder();

            sb.Append(@"<script type=""text/javascript"">");

            #region Describes

            #region Skill - SkillName

            SalesforceIntegration.SObjDescribe skillObj = (from m in _SFFormModel.results where m.result.name == "jsexpobjects__Team__c" select m.result).FirstOrDefault();

            if (skillObj != null)
            {
                SalesforceIntegration.SObjField skill__c_field = (from m in skillObj.fields where m.name == "Skill__c" select m).First();
                sb.Append("skill__c = jQuery.parseJSON('" + ser.Serialize(skill__c_field.picklistValues.Where(c => c.active)) + "');\n");

                SalesforceIntegration.SObjField skill_name__c_field = (from m in skillObj.fields where m.name == "Skill_Name__c" select m).First();
                sb.Append("skill__name__c = jQuery.parseJSON('" + ser.Serialize(skill_name__c_field.picklistValues.Where(c => c.active)) + "');\n");
            }

            #endregion

            #region Sector Experience - Sector Details

            SalesforceIntegration.SObjDescribe secExpObj = (from m in _SFFormModel.results where m.result.name == "jsexpobjects__Ranking__c" select m.result).FirstOrDefault();

            if (secExpObj != null)
            {
                SalesforceIntegration.SObjField Sector_Experience__c_field = (from m in secExpObj.fields where m.name == "Sector_Experience__c" select m).First();
                sb.Append("sector_experience__c = jQuery.parseJSON('" + ser.Serialize(Sector_Experience__c_field.picklistValues.Where(c => c.active)) + "');\n");

                SalesforceIntegration.SObjField Sector_Detail__c_field = (from m in secExpObj.fields where m.name == "Sector_Detail__c" select m).First();
                sb.Append("sector_detail__c = jQuery.parseJSON('" + ser.Serialize(Sector_Detail__c_field.picklistValues.Where(c => c.active)) + "');\n");
            }

            #endregion

            #region Job Function - Experience
            SalesforceIntegration.SObjDescribe jobFuncObj = (from m in _SFFormModel.results where m.result.name == "jsexpobjects__Legodo_Email_Batch__c" select m.result).FirstOrDefault();
            if (jobFuncObj != null)
            {
                SalesforceIntegration.SObjField Job_Function__c_field = (from m in jobFuncObj.fields where m.name == "Job_Function__c" select m).First();
                sb.Append("job_function__c = jQuery.parseJSON('" + ser.Serialize(Job_Function__c_field.picklistValues.Where(c => c.active)) + "');\n");

                SalesforceIntegration.SObjField Experience__c_field = (from m in jobFuncObj.fields where m.name == "Experience__c" select m).First();
                sb.Append("job_function_experience__c = jQuery.parseJSON('" + ser.Serialize(Experience__c_field.picklistValues.Where(c => c.active)) + "');\n");
            }
            #endregion

            #endregion

            #region Data


            #region Sector Experience Experience

            SalesforceIntegration.SObjResults secExpExpData = _SFContactModel.results[1];

            if (secExpExpData != null)
            {
                SalesforceIntegration.SObjResult Sector_Experience = secExpExpData.result;
                sb.Append("sector_experience_records = jQuery.parseJSON('" + ser.Serialize(Sector_Experience.records) + "');\n");
            }

            #endregion

            #region Sector Experience Reference

            SalesforceIntegration.SObjResults secExpRefData = _SFContactModel.results[2];

            if (secExpExpData != null)
            {
                SalesforceIntegration.SObjResult Sector_Reference = secExpRefData.result;
                sb.Append("sector_reference_records = jQuery.parseJSON('" + ser.Serialize(Sector_Reference.records) + "');\n");
            }

            #endregion

            #region Education History
            
            SalesforceIntegration.SObjResults eduHistData = _SFContactModel.results[3];

            if (secExpExpData != null)
            {
                SalesforceIntegration.SObjResult Education_History = eduHistData.result;
                sb.Append("education_history_records = jQuery.parseJSON('" + ser.Serialize(Education_History.records) + "');\n");
            }
            

            #endregion


            #endregion




            sb.Append(@"</script>");

            ModelPreserveJSBlock.Text = sb.ToString();
        }

        private void JobFunctionSetup()
        {
            #region DDL - Skill - SkillName
            SalesforceIntegration.SObjDescribe skillObj = (from m in _SFFormModel.results where m.result.name == "jsexpobjects__Team__c" select m.result).FirstOrDefault();
            if (skillObj != null)
            {
                SalesforceIntegration.SObjField skill__c_field = (from m in skillObj.fields where m.name == "Skill__c" select m).First();
                //assume always exists

                SkillDDL.DataSource = skill__c_field.picklistValues.Where(c => c.active);
                SkillDDL.DataTextField = "label";
                SkillDDL.DataValueField = "value";
                SkillDDL.DataBind();
                SkillDDL.Items.Insert(0, new ListItem { Text = "- Please select -", Value = "-1" });

                SkillNameDDL.Items.Insert(0, new ListItem { Text = "- Please select a skill -", Value = "-1" });
            }

            //Skill - SkillName Databind
            SalesforceIntegration.SObjResults skillBatchObj = _SFContactModel.results[4];
            if (skillBatchObj.statusCode == 200)
            {
                if (skillBatchObj.result.totalSize > 0)
                {
                    rptSkillSkillName.DataSource = skillBatchObj.result.records;
                }
                rptSkillSkillName.DataBind();
            }
            #endregion

            #region DDL - Sector Experience - Sector Details
            SalesforceIntegration.SObjDescribe secExpObj = (from m in _SFFormModel.results where m.result.name == "jsexpobjects__Ranking__c" select m.result).FirstOrDefault();
            if (secExpObj != null)
            {
                SalesforceIntegration.SObjField Sector_Experience__c_field = (from m in secExpObj.fields where m.name == "Sector_Experience__c" select m).First();
                //assume always exists

                SecExpDDL.DataSource = Sector_Experience__c_field.picklistValues.Where(c => c.active);
                SecExpDDL.DataTextField = "label";
                SecExpDDL.DataValueField = "value";
                SecExpDDL.DataBind();
                SecExpDDL.Items.Insert(0, new ListItem { Text = "- Please select -", Value = "-1" });

                SecDetailDDL.Items.Insert(0, new ListItem { Text = "Please select a Sector Experience", Value = "-1" });
            }

            //Sector Experience - Sector Details Databind
            SalesforceIntegration.SObjResults secExpBatchObj = _SFContactModel.results[5];
            if (secExpBatchObj.statusCode == 200)
            {
                if (secExpBatchObj.result.totalSize > 0)
                {
                    rptSecExpDetail.DataSource = secExpBatchObj.result.records;
                }
                rptSecExpDetail.DataBind();
            }
            #endregion

            #region DDL - Job Function - Experience
            SalesforceIntegration.SObjDescribe jobFuncObj = (from m in _SFFormModel.results where m.result.name == "jsexpobjects__Legodo_Email_Batch__c" select m.result).FirstOrDefault();
            if (secExpObj != null)
            {
                SalesforceIntegration.SObjField Job_Function__c_field = (from m in jobFuncObj.fields where m.name == "Job_Function__c" select m).First();
                //assume always exists

                JobFuncDDL.DataSource = Job_Function__c_field.picklistValues.Where(c => c.active);
                JobFuncDDL.DataTextField = "label";
                JobFuncDDL.DataValueField = "value";
                JobFuncDDL.DataBind();

                JobFuncDDL.Items.Insert(0, new ListItem { Text = "- Please select -", Value = "-1" });

                JobFuncExpDDL.Items.Insert(0, new ListItem { Text = "Please select a Job Function", Value = "-1" });
            }


            //Job function - Databind
            SalesforceIntegration.SObjResults jobfunctionBatchObj = _SFContactModel.results[6];
            if (jobfunctionBatchObj.statusCode == 200)
            {
                if (jobfunctionBatchObj.result.totalSize > 0)
                {
                    rptJobFunction.DataSource = jobfunctionBatchObj.result.records;
                }
                rptJobFunction.DataBind();
            }
            #endregion
        }

        private void SectorExperienceSetup()
        {
            #region Experience

            tbSecExpStart.Text = DateTime.Now.ToString("yyyy-MM-dd");
            tbSecExpStart.ReadOnly = true;
            tbSecExpEnd.Text = DateTime.Now.ToString("yyyy-MM-dd");
            tbSecExpEnd.ReadOnly = true;

            //Databind
            //SalesforceIntegration.SObjResults expBatchObj = _SFContactModel.results[1];
            //if (expBatchObj.statusCode == 200)
            //{
            //    if (expBatchObj.result.totalSize > 0)
            //    {
            //        rptSecExp_Experience.DataSource = expBatchObj.result.records;
            //    }
            //    rptSecExp_Experience.DataBind();
            //}

            #endregion

            #region References

            //Databind
            //SalesforceIntegration.SObjResults refBatchObj = _SFContactModel.results[2];
            //if (refBatchObj.statusCode == 200)
            //{
            //    if (refBatchObj.result.totalSize > 0)
            //    {
            //        rptSecExp_Reference.DataSource = refBatchObj.result.records;
            //    }
            //    rptSecExp_Reference.DataBind();
            //}

            #endregion
        }

        private void EducationHistorySetup()
        {
            //DDL grad year
            List<object> GradYearDDLValues = new List<object>();
            for (int i = DateTime.Now.Year; i >= DateTime.Now.Year - 80; i--)
            {
                GradYearDDLValues.Add(new { label = i.ToString(), value = i.ToString() });
            }
            ddlEduGradYear.DataSource = GradYearDDLValues;
            ddlEduGradYear.DataTextField = "label";
            ddlEduGradYear.DataValueField = "value";
            ddlEduGradYear.DataBind();

            SalesforceIntegration.SObjDescribe eduDegreeObj = (from m in _SFFormModel.results where m.result.name == "ts2__Education_History__c" select m.result).FirstOrDefault();
            if (eduDegreeObj != null)
            {
                SalesforceIntegration.SObjField ts2__DegreePicklist__c_field = (from m in eduDegreeObj.fields where m.name == "ts2__DegreePicklist__c" select m).First();

                //DDL degree
                ddlEduDegree.DataSource = ts2__DegreePicklist__c_field.picklistValues.Where(c => c.active); ;
                ddlEduDegree.DataTextField = "label";
                ddlEduDegree.DataValueField = "value";
                ddlEduDegree.DataBind();
            }

            //Databind
            //SalesforceIntegration.SObjResults eduHistoryBatchObj = _SFContactModel.results[3];
            //if (eduHistoryBatchObj.statusCode == 200)
            //{
            //    if (eduHistoryBatchObj.result.totalSize > 0)
            //    {
            //        rptEducationHistory.DataSource = eduHistoryBatchObj.result.records;
            //    }
            //    rptEducationHistory.DataBind();
            //}
        }

        #endregion


        private bool FormGetObjectsFromSF()
        {
            //get from salesforce
            SalesforceIntegration sfInt = new SalesforceIntegration();
            string errorMsg;
            bool describeGetSuccess = sfInt.PostSObjectBatchRequest(new string[]
                                        {
                                            string.Format("SELECT Id, Firstname, lastname FROM Contact Where Id = '{0}'", _SFContactID),
                                            string.Format("SELECT Id, ts2__Job_Title__c,ts2__Employment_Start_Date__c, ts2__Employment_End_Date__c, ts2__Name__c,ts2__Location__c,Resume_RFL__c FROM ts2__Employment_History__c WHERE ts2__Contact__c = '{0}'", _SFContactID),
                                            string.Format("SELECT Id, ts2__Name__c, ts2__Company__c, ts2__Role_Title__c, ts2__Phone__c, ts2__Email__c  FROM ts2__Reference__c  WHERE ts2__Candidate__c = '{0}'", _SFContactID),
                                            string.Format("SELECT Id, ts2__Name__c, ts2__Graduation_Year__c, ts2__DegreePicklist__c, ts2__Major__c FROM ts2__Education_History__c WHERE ts2__Contact__c= '{0}'", _SFContactID),
                                            string.Format("SELECT Id, Skill__c, Skill_Name__c  FROM jsexpobjects__Team__c  WHERE Contact__c = '{0}'", _SFContactID), // Skill (EW)
                                            string.Format("SELECT Id, Sector_Experience__c, Sector_Detail__c FROM jsexpobjects__Ranking__c WHERE Contact__c = '{0}'", _SFContactID), // Sector Experience
                                            string.Format("SELECT Id, Job_Function__c, Experience__c FROM jsexpobjects__Legodo_Email_Batch__c  WHERE Contact__c = '{0}'", _SFContactID) // Job function
                                        }, out _SFContactModel, out errorMsg);

            if (!describeGetSuccess)
            {
                //show error message
            }
            return describeGetSuccess;
        }


        #region Databinds

        //protected void rptEducationHistory_ItemDataBound(object sender, RepeaterItemEventArgs e)
        //{
        //    if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        //    {
        //        Literal ltCol0 = e.Item.FindControl("ltCol0") as Literal;
        //        Literal ltCol1 = e.Item.FindControl("ltCol1") as Literal;
        //        Literal ltCol2 = e.Item.FindControl("ltCol2") as Literal;
        //        Literal ltCol3 = e.Item.FindControl("ltCol3") as Literal;
        //        Literal ltCol4 = e.Item.FindControl("ltCol4") as Literal;

        //        SalesforceIntegration.SObjRecord secExpRef = e.Item.DataItem as SalesforceIntegration.SObjRecord;
        //        ltCol0.Text = secExpRef.Id;
        //        ltCol1.Text = secExpRef.ts2__Name__c;
        //        ltCol2.Text = secExpRef.ts2__DegreePicklist__c;
        //        ltCol3.Text = secExpRef.ts2__Major__c;
        //        ltCol4.Text = secExpRef.ts2__Graduation_Year__c;
        //    }
        //}

        protected void rptSecExpDetail_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //Literal ltCol0 = e.Item.FindControl("ltCol0") as Literal;
                Literal ltCol1 = e.Item.FindControl("ltCol1") as Literal;
                Literal ltCol2 = e.Item.FindControl("ltCol2") as Literal;

                SalesforceIntegration.SObjRecord secExp = e.Item.DataItem as SalesforceIntegration.SObjRecord;
                //ltCol0.Text = secExp.Id;
                ltCol1.Text = secExp.Sector_Experience__c;
                ltCol2.Text = secExp.Sector_Detail__c;
            }
        }

        protected void rptSkillSkillName_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //Literal ltReference = e.Item.FindControl("ltReference") as Literal;
                Literal ltSkill = e.Item.FindControl("ltSkill") as Literal;
                Literal ltSkillName = e.Item.FindControl("ltSkillName") as Literal;

                SalesforceIntegration.SObjRecord skill = e.Item.DataItem as SalesforceIntegration.SObjRecord;
                //ltReference.Text = skill.Id;
                ltSkill.Text = skill.Skill__c;
                ltSkillName.Text = skill.Skill_Name__c;
            }
        }

        protected void rptJobFunction_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //Literal ltCol0 = e.Item.FindControl("ltCol0") as Literal;
                Literal ltCol1 = e.Item.FindControl("ltCol1") as Literal;
                Literal ltCol2 = e.Item.FindControl("ltCol2") as Literal;

                SalesforceIntegration.SObjRecord secExp = e.Item.DataItem as SalesforceIntegration.SObjRecord;
                //ltCol0.Text = secExp.Id;
                ltCol1.Text = secExp.Job_Function__c;
                ltCol2.Text = secExp.Experience__c;
            }
        }

        //protected void rptSecExp_Reference_ItemDataBound(object sender, RepeaterItemEventArgs e)
        //{
        //    //string.Format("SELECT Id, ts2__Name__c, ts2__Company__c, ts2__Role_Title__c, ts2__Phone__c, ts2__Email__c  FROM ts2__Reference__c  WHERE ts2__Candidate__c = '{0}'", _SFContactID),
        //    if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        //    {
        //        Literal ltCol0 = e.Item.FindControl("ltCol0") as Literal;
        //        Literal ltCol1 = e.Item.FindControl("ltCol1") as Literal;
        //        Literal ltCol2 = e.Item.FindControl("ltCol2") as Literal;
        //        Literal ltCol3 = e.Item.FindControl("ltCol3") as Literal;
        //        Literal ltCol4 = e.Item.FindControl("ltCol4") as Literal;
        //        Literal ltCol5 = e.Item.FindControl("ltCol5") as Literal;

        //        SalesforceIntegration.SObjRecord secExpRef = e.Item.DataItem as SalesforceIntegration.SObjRecord;
        //        ltCol0.Text = secExpRef.Id;
        //        ltCol1.Text = secExpRef.ts2__Name__c;
        //        ltCol2.Text = secExpRef.ts2__Company__c;
        //        ltCol3.Text = secExpRef.ts2__Role_Title__c;
        //        ltCol4.Text = secExpRef.ts2__Phone__c;
        //        ltCol5.Text = secExpRef.ts2__Email__c;
        //    }
        //}

        //protected void rptSecExp_Experience_ItemDataBound(object sender, RepeaterItemEventArgs e)
        //{
        //    //Id, ts2__Job_Title__c,ts2__Employment_Start_Date__c, ts2__Employment_End_Date__c, ts2__Name__c,ts2__Location__c,Resume_RFL__c 
        //    if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        //    {
        //        Literal ltCol1 = e.Item.FindControl("ltCol1") as Literal;
        //        Literal ltCol2 = e.Item.FindControl("ltCol2") as Literal;
        //        Literal ltCol3 = e.Item.FindControl("ltCol3") as Literal;
        //        Literal ltCol5 = e.Item.FindControl("ltCol5") as Literal;
        //        Literal ltCol6 = e.Item.FindControl("ltCol6") as Literal;

        //        SalesforceIntegration.SObjRecord secExpExp = e.Item.DataItem as SalesforceIntegration.SObjRecord;
        //        ltCol1.Text = secExpExp.ts2__Name__c;
        //        ltCol2.Text = secExpExp.ts2__Job_Title__c;
        //        ltCol3.Text = secExpExp.ts2__Location__c;
        //        ltCol5.Text = secExpExp.ts2__Employment_Start_Date__c;
        //        ltCol6.Text = secExpExp.ts2__Employment_End_Date__c;
        //    }
        //}


        #endregion

        #region Click Events

        #region Job Function / Experience

        protected void rptSkillSkillName_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
            }
            else if (e.CommandName == "Delete")
            {
            }

        }

        #endregion


        protected void lbSaveAndContinue_Click(object sender, EventArgs e)
        {
        }

        protected void lbFinish_Click(object sender, EventArgs e)
        {
        }

        #region Experience
        protected void lbAddExperience_Click(object sender, EventArgs e)
        {
        }

        protected void lbEditExperience_Click(object sender, EventArgs e)
        {

        }
        protected void lbCancelExperience_Click(object sender, EventArgs e)
        {
        }

        protected void rptExperience_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
            }
            else if (e.CommandName == "Delete")
            {
            }
        }

        #endregion

        #region Education

        #endregion
        #endregion

        #region WebMethod

        [WebMethod(EnableSession = true)]
        public static object SFObjAdd(string dependantValue, string dependedValue, string objType)
        {
            string sfContactID = SFContactIDGetFromSessionMember();

            if (!string.IsNullOrEmpty(sfContactID))
            {
                string errorMsg = null;
                string sfEntityID = null;

                bool postSuccess = false;

                switch (objType)
                {
                    case "skill":
                        postSuccess = FormActionPostToSF("jsexpobjects__Team__c", new { Contact__c = sfContactID, Skill__c = dependantValue, Skill_Name__c = dependedValue }, out sfEntityID, out errorMsg);
                        break;
                    case "sector":
                        postSuccess = FormActionPostToSF("jsexpobjects__Ranking__c", new { Contact__c = sfContactID, Sector_Experience__c = dependantValue, Sector_Detail__c = dependedValue }, out sfEntityID, out errorMsg);
                        break;
                    case "jobfunction":
                        postSuccess = FormActionPostToSF("jsexpobjects__Legodo_Email_Batch__c", new { Contact__c = sfContactID, Job_Function__c = dependantValue, Experience__c = dependedValue }, out sfEntityID, out errorMsg);
                        break;
                }

                if (postSuccess)
                    return new { Success = true, EntityID = sfEntityID };
                else
                    return new { Success = false, Message = errorMsg };
            }
            return new { Success = false, Message = "Session expired, please reload the page." };
        }

        [WebMethod(EnableSession = true)]
        public static object SFObjDelete(string sfID, string objType)
        {
            string sfContactID = SFContactIDGetFromSessionMember();

            if (!string.IsNullOrEmpty(sfContactID))
            {
                string errorMsg = null;
                bool deleteSuccess = false;

                switch (objType)
                {
                    case "skill":
                        deleteSuccess = FormActionDeleteToSF("jsexpobjects__Team__c", sfContactID, sfID, out errorMsg);
                        break;
                    case "sector":
                        deleteSuccess = FormActionDeleteToSF("jsexpobjects__Ranking__c", sfContactID, sfID, out errorMsg);
                        break;
                    case "jobfunction":
                        deleteSuccess = FormActionDeleteToSF("jsexpobjects__Legodo_Email_Batch__c", sfContactID, sfID, out errorMsg);
                        break;
                }

                if (deleteSuccess)
                    return new { Success = true };
                else
                    return new { Success = false, Message = errorMsg };
            }
            return new { Success = false, Message = "Session expired, please reload the page." };
        }

        #region Sector Experience

        [WebMethod(EnableSession = true)]
        public static object SFSecExpExperienceAdd(string SFID, string expTitle, string expCompany, string expLocation, string expReason, string expStart, string expEnd)
        {
            string sfContactID = SFContactIDGetFromSessionMember();

            if (!string.IsNullOrEmpty(sfContactID))
            {
                string errorMsg = null;
                string sfEntityID = null;

                bool postSuccess = false;

                if (string.IsNullOrEmpty(SFID))
                    postSuccess = FormActionPostToSF("ts2__Employment_History__c", new { ts2__Contact__c = sfContactID, ts2__Job_Title__c = expTitle, ts2__Employment_Start_Date__c = expStart, ts2__Employment_End_Date__c = expEnd, ts2__Name__c = expCompany, ts2__Location__c = expLocation, Resume_RFL__c = expReason }, out sfEntityID, out errorMsg);
                else
                    postSuccess = FormActionPatchToSF(SFID, "ts2__Employment_History__c", new { ts2__Job_Title__c = expTitle, ts2__Employment_Start_Date__c = expStart, ts2__Employment_End_Date__c = expEnd, ts2__Name__c = expCompany, ts2__Location__c = expLocation, Resume_RFL__c = expReason }, out sfEntityID, out errorMsg);

                if (postSuccess)
                {
                    SalesforceIntegration.SObjRecord newRecordJson = new SalesforceIntegration.SObjRecord { Id = sfEntityID, Resume_RFL__c = expReason, ts2__Employment_End_Date__c = expEnd, ts2__Employment_Start_Date__c = expStart, ts2__Job_Title__c = expTitle, ts2__Location__c = expLocation, ts2__Name__c = expCompany };
                    JavaScriptSerializer ser = new JavaScriptSerializer();

                    return new { Success = true, EntityID = sfEntityID, RecordJson = ser.Serialize(newRecordJson) };
                }
                else
                    return new { Success = false, Message = errorMsg };
            }

            return new { Success = false, Message = "Session expired, please reload the page." };
        }

        [WebMethod(EnableSession = true)]
        public static object SFSecExpExperienceDelete(string sfID)
        {
            string sfContactID = SFContactIDGetFromSessionMember();

            if (!string.IsNullOrEmpty(sfContactID))
            {
                string errorMsg = null;
                bool deleteSuccess = FormActionDeleteToSF("ts2__Employment_History__c", sfContactID, sfID, out errorMsg);

                if (deleteSuccess)
                    return new { Success = true };
                else
                    return new { Success = false, Message = errorMsg };
            }
            return new { Success = false, Message = "Session expired, please reload the page." };
        }


        [WebMethod(EnableSession = true)]
        public static object SFSecExpRefAdd(string SFID, string refName, string refComp, string refRole, string refPhone, string refEmail)
        {
            string sfContactID = SFContactIDGetFromSessionMember();

            if (!string.IsNullOrEmpty(sfContactID))
            {
                string errorMsg = null;
                string sfEntityID = null;

                bool postSuccess = false;

                if (string.IsNullOrEmpty(SFID))
                    postSuccess = FormActionPostToSF("ts2__Reference__c", new { ts2__Candidate__c = sfContactID, ts2__Name__c = refName, ts2__Company__c = refComp, ts2__Role_Title__c = refRole, ts2__Phone__c = refPhone, ts2__Email__c = refEmail }, out sfEntityID, out errorMsg);
                else
                    postSuccess = FormActionPatchToSF(SFID, "ts2__Reference__c", new { ts2__Name__c = refName, ts2__Company__c = refComp, ts2__Role_Title__c = refRole, ts2__Phone__c = refPhone, ts2__Email__c = refEmail }, out sfEntityID, out errorMsg);

                if (postSuccess)
                {
                    JavaScriptSerializer ser = new JavaScriptSerializer();
                    SalesforceIntegration.SObjRecord newRecordJson = new SalesforceIntegration.SObjRecord { Id = sfEntityID, ts2__Name__c = refName, ts2__Company__c = refComp, ts2__Role_Title__c = refRole, ts2__Phone__c = refPhone, ts2__Email__c = refEmail };

                    return new { Success = true, EntityID = sfEntityID, RecordJson = ser.Serialize(newRecordJson) };
                }
                else
                    return new { Success = false, Message = errorMsg };
            }

            return new { Success = false, Message = "Session expired, please reload the page." };
        }

        [WebMethod(EnableSession = true)]
        public static object SFSecExpRefDelete(string sfID)
        {
            string sfContactID = SFContactIDGetFromSessionMember();

            if (!string.IsNullOrEmpty(sfContactID))
            {
                string errorMsg = null;
                bool deleteSuccess = FormActionDeleteToSF("ts2__Reference__c", sfContactID, sfID, out errorMsg);

                if (deleteSuccess)
                    return new { Success = true };
                else
                    return new { Success = false, Message = errorMsg };
            }
            return new { Success = false, Message = "Session expired, please reload the page." };
        }

        #endregion

        #region EducationHistory

        [WebMethod(EnableSession = true)]
        public static object SFEduHistoryAdd(string SFID, string refInstitution, string refDegree, string refMajor, string refYear)
        {
            string sfContactID = SFContactIDGetFromSessionMember();

            if (!string.IsNullOrEmpty(sfContactID))
            {
                string errorMsg = null;
                string sfEntityID = null;

                bool postSuccess = false;

                if (string.IsNullOrEmpty(SFID))
                    postSuccess = FormActionPostToSF("ts2__Education_History__c", new { ts2__Contact__c = sfContactID, ts2__Name__c = refInstitution, ts2__DegreePicklist__c = refDegree, ts2__Major__c = refMajor, ts2__Graduation_Year__c = refYear }, out sfEntityID, out errorMsg);
                else
                    postSuccess = FormActionPatchToSF(SFID, "ts2__Education_History__c", new { ts2__Name__c = refInstitution, ts2__DegreePicklist__c = refDegree, ts2__Major__c = refMajor, ts2__Graduation_Year__c = refYear }, out sfEntityID, out errorMsg);

                if (postSuccess)
                {
                    JavaScriptSerializer ser = new JavaScriptSerializer();
                    SalesforceIntegration.SObjRecord newRecordJson = new SalesforceIntegration.SObjRecord { Id = sfEntityID, ts2__Name__c = refInstitution, ts2__DegreePicklist__c = refDegree, ts2__Major__c = refMajor, ts2__Graduation_Year__c = refYear };

                    return new { Success = true, EntityID = sfEntityID, RecordJson = ser.Serialize(newRecordJson) };
                }
                else
                    return new { Success = false, Message = errorMsg };
            }

            return new { Success = false, Message = "Session expired, please reload the page." };
        }

        [WebMethod(EnableSession = true)]
        public static object SFEduHistoryDelete(string sfID)
        {
            string sfContactID = SFContactIDGetFromSessionMember();

            if (!string.IsNullOrEmpty(sfContactID))
            {
                string errorMsg = null;
                bool deleteSuccess = FormActionDeleteToSF("ts2__Education_History__c", sfContactID, sfID, out errorMsg);

                if (deleteSuccess)
                    return new { Success = true };
                else
                    return new { Success = false, Message = errorMsg };
            }
            return new { Success = false, Message = "Session expired, please reload the page." };
        }



        #endregion

        private static bool FormActionPostToSF(string entity, object jsonObj, out string sfEntityID, out string errorMsg)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            SalesforceIntegration sfInt = new SalesforceIntegration();
            bool postSuccess = sfInt.EntityPost(entity, ser.Serialize(jsonObj), out sfEntityID, out errorMsg);

            return postSuccess;
        }

        private static bool FormActionPatchToSF(string SFID, string entity, object jsonObj, out string sfEntityID, out string errorMsg)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            SalesforceIntegration sfInt = new SalesforceIntegration();
            bool postSuccess = sfInt.EntityPatch(SFID, entity, ser.Serialize(jsonObj), out sfEntityID, out errorMsg);

            return postSuccess;
        }



        private static bool FormActionDeleteToSF(string entity, string sfContactID, string sfID, out string errorMsg)
        {
            //TODO: Query for the reference of SFContactID with the SF object ID before executing the DELETE

            //Execute Delete
            SalesforceIntegration sfInt = new SalesforceIntegration();
            bool deleteSuccess = sfInt.EntityDelete(entity, sfID, out errorMsg);

            return deleteSuccess;
        }


        private static string SFContactIDGetFromSessionMember()
        {
            if (SessionData.Member != null)
            {
                using (Entities.Members thisMember = new MembersService().GetByMemberId(SessionData.Member.MemberId))
                {
                    return thisMember.ExternalMemberId;
                }
            }

            // If not logged in
            return string.Empty;
        }

        #endregion

    }
}