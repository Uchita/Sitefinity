using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;

namespace JXTPortal.Website.Admin
{
    public partial class MemberProfileManageableFields : System.Web.UI.Page
    {
        MembersService _membersService;
        MembersService MembersService
        {
            get
            {
                if (_membersService == null)
                {
                    _membersService = new JXTPortal.MembersService();
                }
                return _membersService;
            }
        }

        MemberWizardService _memberWizardService;
        MemberWizardService MemberWizardServicea
        {
            get
            {
                if (_memberWizardService == null)
                {
                    _memberWizardService = new JXTPortal.MemberWizardService();
                }
                return _memberWizardService;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            /* Admin Skills */
            MemberWizardService _mws = new MemberWizardService();
            using (JXTPortal.Entities.MemberWizard objMW = _mws.GetMemberWizardBySite(SessionData.Site.SiteId))
            {
                if (objMW != null)
                {
                    if (objMW.GlobalTemplate)
                    {
                        Response.Redirect("/admin/memberwizard.aspx");
                        return;
                    }

                    if (!string.IsNullOrEmpty(objMW.Skills))
                    {
                        string[] split = objMW.Skills.Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries);
                        split = split.OrderBy(c => c).Select(c => c).ToArray();

                        //set count display
                        ltSkillsCount.Text = split.Count().ToString();

                        rptSkills.DataSource = split;
                        rptSkills.DataBind();
                    }


                    if (!string.IsNullOrEmpty(objMW.LicenseTypes))
                    {
                        string[] split = objMW.LicenseTypes.Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries);
                        split = split.OrderBy(c => c).Select(c => c).ToArray();

                        //set count display
                        ltLicenseCount.Text = split.Count().ToString();

                        rptLicenseType.DataSource = split;
                        rptLicenseType.DataBind();
                    }

                    if (!string.IsNullOrEmpty(objMW.QualificationNames))
                    {
                        string[] split = objMW.QualificationNames.Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries);
                        split = split.OrderBy(c => c).Select(c => c).ToArray();

                        //set count display
                        ltQNCount.Text = split.Count().ToString();

                        rptQualificationName.DataSource = split;
                        rptQualificationName.DataBind();
                    }

                }
            }
        }

        protected void rptLicenseType_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label thisLabel = e.Item.FindControl("lblLicense") as Label;
                LinkButton thisButton = e.Item.FindControl("lbLicenseRemove") as LinkButton;

                string licenseValue = (string) e.Item.DataItem;

                thisLabel.Text = HttpUtility.HtmlEncode(licenseValue);
                thisButton.CommandArgument = licenseValue;
            }
        }

        protected void rptLicenseType_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Remove")
            {
                string licenseValue = (string)e.CommandArgument;

                string targetValue = licenseValue;

                MemberWizardService _serv = new MemberWizardService();
                using (JXTPortal.Entities.MemberWizard objMW = _serv.GetMemberWizardBySite(SessionData.Site.SiteId))
                {
                    if (objMW != null)
                    {
                        //if (objMW.GlobalTemplate)
                        //{
                        //    #region Clone and Create
                        //    JXTPortal.Entities.MemberWizard objMWClone = (JXTPortal.Entities.MemberWizard)objMW.Clone();

                        //    objMWClone.SiteId = SessionData.Site.SiteId;
                        //    objMWClone.GlobalTemplate = false;

                        //    if (!string.IsNullOrEmpty(objMWClone.LicenseTypes))
                        //    {
                        //        string targetPattern = @"||" + targetValue + @"||";
                        //        int targetIndex = objMWClone.LicenseTypes.IndexOf(targetPattern);

                        //        if (targetIndex != -1)
                        //        {
                        //            targetIndex += 2; //add 2 to avoid the "||" prior
                        //            objMWClone.LicenseTypes = objMWClone.LicenseTypes.Remove(targetIndex, targetPattern.Length - 2);

                        //            _serv.Insert(objMWClone);

                        //            List<string> skillsList = objMWClone.LicenseTypes.Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries).OrderBy(c => c).Select(c => c).ToList();

                        //            rptLicenseType.DataSource = skillsList;
                        //            rptLicenseType.DataBind();
                        //        }

                        //    }

                        //    #endregion
                        //}
                        //else
                        //{
                            #region Update
                            if (!string.IsNullOrEmpty(objMW.LicenseTypes))
                            {
                                string targetPattern = @"||" + targetValue + @"||";
                                int targetIndex = objMW.LicenseTypes.IndexOf(targetPattern);

                                if (targetIndex != -1)
                                {
                                    targetIndex += 2; //add 2 to avoid the "||" prior
                                    objMW.LicenseTypes = objMW.LicenseTypes.Remove(targetIndex, targetPattern.Length - 2);

                                    _serv.Update(objMW);

                                    List<string> skillsList = objMW.LicenseTypes.Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries).OrderBy(c => c).Select(c => c).ToList();

                                    //set count display
                                    ltLicenseCount.Text = skillsList.Count().ToString();

                                    rptLicenseType.DataSource = skillsList;
                                    rptLicenseType.DataBind();

                                }

                            //}

                            #endregion
                        }
                    }
                    //else
                    //    return new { Success = false, SessionFailed = true };
                }

            }
        }

        protected void UpdateLicenseButton_Click(object sender, EventArgs e)
        {
            ltLicenseMessage.Visible = false;

            //note all targetValues passed in are js escaped (url encoded)
            string targetValue = tbLicenseType.Text;

            if (string.IsNullOrEmpty(targetValue))
                return;

            MemberWizardService _serv = new MemberWizardService();
            using (JXTPortal.Entities.MemberWizard objMW = _serv.GetMemberWizardBySite(SessionData.Site.SiteId))
            {
                if (objMW != null)
                {
                    //if (objMW.GlobalTemplate)
                    //{
                    //    #region Clone and Create
                    //    JXTPortal.Entities.MemberWizard objMWClone = (JXTPortal.Entities.MemberWizard)objMW.Clone();

                    //    objMWClone.SiteId = SessionData.Site.SiteId;
                    //    objMWClone.GlobalTemplate = false;

                    //    bool alreadyExists = !string.IsNullOrEmpty(objMWClone.LicenseTypes) && objMWClone.LicenseTypes.ToLower().Contains("||" + targetValue.ToLower() + "||");


                    //    if (!alreadyExists)
                    //    {
                    //        if (string.IsNullOrEmpty(objMWClone.LicenseTypes))
                    //            objMWClone.LicenseTypes += "||";

                    //        objMWClone.LicenseTypes += targetValue + "||";
                    //        _serv.Insert(objMWClone);

                    //        List<string> skillsList = objMWClone.LicenseTypes.Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries).OrderBy(c => c).Select(c => c).ToList();

                    //        objMWClone.Dispose();

                    //        rptLicenseType.DataSource = skillsList;
                    //        rptLicenseType.DataBind();
                    //        //return new { Success = true, data = skillsList };
                    //    }

                    //    objMWClone.Dispose();
                    //    //return new { Success = false, Message = "'" + targetValue + "' already exists" };
                    //    #endregion
                    //}
                    //else
                    //{
                        #region Update
                        bool alreadyExists = !string.IsNullOrEmpty(objMW.LicenseTypes) && objMW.LicenseTypes.ToLower().Contains("||" + targetValue.ToLower() + "||");

                        if (!alreadyExists)
                        {
                            if (string.IsNullOrEmpty(objMW.LicenseTypes))
                                objMW.LicenseTypes += "||";

                            objMW.LicenseTypes += targetValue + "||";
                            _serv.Update(objMW);

                            List<string> skillsList = objMW.LicenseTypes.Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries).OrderBy(c => c).Select(c => c).ToList();

                            //set count display
                            ltLicenseCount.Text = skillsList.Count().ToString();

                            rptLicenseType.DataSource = skillsList;
                            rptLicenseType.DataBind();

                            tbLicenseType.Text = string.Empty;
                            tbSkills.Focus();
                        }
                        else
                        {
                            ltLicenseMessage.Text = "'" + targetValue + "' already exists";
                            ltLicenseMessage.Visible = true;
                        }

                        #endregion
                    //}

                }
                //else
                //    return new { Success = false, SessionFailed = true };
            }


        }

        protected void rptSkills_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label thisLabel = e.Item.FindControl("lblSkills") as Label;
                LinkButton thisButton = e.Item.FindControl("lbSkillsRemove") as LinkButton;

                string licenseValue = (string)e.Item.DataItem;

                thisLabel.Text = HttpUtility.HtmlEncode(licenseValue);
                thisButton.CommandArgument = licenseValue;
            }
        }

        protected void rptSkills_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Remove")
            {
                string skillsValue = (string)e.CommandArgument;

                string targetValue = skillsValue;

                MemberWizardService _serv = new MemberWizardService();
                using (JXTPortal.Entities.MemberWizard objMW = _serv.GetMemberWizardBySite(SessionData.Site.SiteId))
                {
                    if (objMW != null)
                    {
                        //if (objMW.GlobalTemplate)
                        //{
                        //    #region Clone and Create
                        //    JXTPortal.Entities.MemberWizard objMWClone = (JXTPortal.Entities.MemberWizard)objMW.Clone();

                        //    objMWClone.SiteId = SessionData.Site.SiteId;
                        //    objMWClone.GlobalTemplate = false;

                        //    if (!string.IsNullOrEmpty(objMWClone.LicenseTypes))
                        //    {
                        //        string targetPattern = @"||" + targetValue + @"||";
                        //        int targetIndex = objMWClone.LicenseTypes.IndexOf(targetPattern);

                        //        if (targetIndex != -1)
                        //        {
                        //            targetIndex += 2; //add 2 to avoid the "||" prior
                        //            objMWClone.LicenseTypes = objMWClone.LicenseTypes.Remove(targetIndex, targetPattern.Length - 2);

                        //            _serv.Insert(objMWClone);

                        //            List<string> skillsList = objMWClone.LicenseTypes.Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries).OrderBy(c => c).Select(c => c).ToList();

                        //            rptLicenseType.DataSource = skillsList;
                        //            rptLicenseType.DataBind();
                        //        }

                        //    }

                        //    #endregion
                        //}
                        //else
                        //{
                        #region Update
                        if (!string.IsNullOrEmpty(objMW.Skills))
                        {
                            string targetPattern = @"||" + targetValue + @"||";
                            int targetIndex = objMW.Skills.IndexOf(targetPattern);

                            if (targetIndex != -1)
                            {
                                targetIndex += 2; //add 2 to avoid the "||" prior
                                objMW.Skills = objMW.Skills.Remove(targetIndex, targetPattern.Length - 2);

                                _serv.Update(objMW);

                                List<string> skillsList = objMW.Skills.Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries).OrderBy(c => c).Select(c => c).ToList();

                                //set count display
                                ltSkillsCount.Text = skillsList.Count().ToString();

                                rptSkills.DataSource = skillsList;
                                rptSkills.DataBind();

                            }

                            //}

                        #endregion
                        }
                    }
                    //else
                    //    return new { Success = false, SessionFailed = true };
                }

            }
        }

        protected void UpdateSkillsButton_Click(object sender, EventArgs e)
        {
            ltSkillsMessage.Visible = false;

            //note all targetValues passed in are js escaped (url encoded)
            string targetValue = tbSkills.Text;

            if (string.IsNullOrEmpty(targetValue))
                return;

            MemberWizardService _serv = new MemberWizardService();
            using (JXTPortal.Entities.MemberWizard objMW = _serv.GetMemberWizardBySite(SessionData.Site.SiteId))
            {
                if (objMW != null)
                {
                    //if (objMW.GlobalTemplate)
                    //{
                    //    #region Clone and Create
                    //    JXTPortal.Entities.MemberWizard objMWClone = (JXTPortal.Entities.MemberWizard)objMW.Clone();

                    //    objMWClone.SiteId = SessionData.Site.SiteId;
                    //    objMWClone.GlobalTemplate = false;

                    //    bool alreadyExists = !string.IsNullOrEmpty(objMWClone.LicenseTypes) && objMWClone.LicenseTypes.ToLower().Contains("||" + targetValue.ToLower() + "||");


                    //    if (!alreadyExists)
                    //    {
                    //        if (string.IsNullOrEmpty(objMWClone.LicenseTypes))
                    //            objMWClone.LicenseTypes += "||";

                    //        objMWClone.LicenseTypes += targetValue + "||";
                    //        _serv.Insert(objMWClone);

                    //        List<string> skillsList = objMWClone.LicenseTypes.Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries).OrderBy(c => c).Select(c => c).ToList();

                    //        objMWClone.Dispose();

                    //        rptLicenseType.DataSource = skillsList;
                    //        rptLicenseType.DataBind();
                    //        //return new { Success = true, data = skillsList };
                    //    }

                    //    objMWClone.Dispose();
                    //    //return new { Success = false, Message = "'" + targetValue + "' already exists" };
                    //    #endregion
                    //}
                    //else
                    //{
                    #region Update
                    bool alreadyExists = !string.IsNullOrEmpty(objMW.Skills) && objMW.Skills.ToLower().Contains("||" + targetValue.ToLower() + "||");

                    if (!alreadyExists)
                    {
                        if (string.IsNullOrEmpty(objMW.Skills))
                            objMW.Skills += "||";

                        objMW.Skills += targetValue + "||";
                        _serv.Update(objMW);

                        List<string> skillsList = objMW.Skills.Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries).OrderBy(c => c).Select(c => c).ToList();

                        //set count display
                        ltSkillsCount.Text = skillsList.Count().ToString();

                        rptSkills.DataSource = skillsList;
                        rptSkills.DataBind();

                        tbSkills.Text = string.Empty;
                        tbSkills.Focus();
                    }
                    else
                    {
                        ltSkillsMessage.Text = "'" + targetValue + "' already exists";
                        ltSkillsMessage.Visible = true;
                    }

                    #endregion
                    //}

                }
                //else
                //    return new { Success = false, SessionFailed = true };
            }


        }


        protected void rptQualificationName_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label thisLabel = e.Item.FindControl("lblQualificationNames") as Label;
                LinkButton thisButton = e.Item.FindControl("lbQualificationNamesRemove") as LinkButton;

                string QNValue = (string)e.Item.DataItem;

                thisLabel.Text = HttpUtility.HtmlEncode(QNValue);
                thisButton.CommandArgument = QNValue;
            }
        }

        protected void rptQualificationName_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Remove")
            {
                string QNsValue = (string)e.CommandArgument;

                string targetValue = QNsValue;

                MemberWizardService _serv = new MemberWizardService();
                using (JXTPortal.Entities.MemberWizard objMW = _serv.GetMemberWizardBySite(SessionData.Site.SiteId))
                {
                    if (objMW != null)
                    {
                        
                        #region Update
                        if (!string.IsNullOrEmpty(objMW.QualificationNames))
                        {
                            string targetPattern = @"||" + targetValue + @"||";
                            int targetIndex = objMW.QualificationNames.IndexOf(targetPattern);

                            if (targetIndex != -1)
                            {
                                targetIndex += 2; //add 2 to avoid the "||" prior
                                objMW.QualificationNames = objMW.QualificationNames.Remove(targetIndex, targetPattern.Length - 2);

                                _serv.Update(objMW);

                                List<string> QNList = objMW.QualificationNames.Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries).OrderBy(c => c).Select(c => c).ToList();

                                //set count display
                                ltQNCount.Text = QNList.Count().ToString();

                                rptQualificationName.DataSource = QNList;
                                rptQualificationName.DataBind();

                            }
                        }
                        #endregion
                    }
                    //else
                    //    return new { Success = false, SessionFailed = true };
                }

            }
        }

        protected void UpdateQualificationNameButton_Click(object sender, EventArgs e)
        {
            ltQNsMessage.Visible = false;

            //note all targetValues passed in are js escaped (url encoded)
            string targetValue = tbQualificationName.Text;

            if (string.IsNullOrEmpty(targetValue))
                return;

            MemberWizardService _serv = new MemberWizardService();
            using (JXTPortal.Entities.MemberWizard objMW = _serv.GetMemberWizardBySite(SessionData.Site.SiteId))
            {
                if (objMW != null)
                {
                    
                    #region Update
                    bool alreadyExists = !string.IsNullOrEmpty(objMW.QualificationNames) && objMW.QualificationNames.ToLower().Contains("||" + targetValue.ToLower() + "||");

                    if (!alreadyExists)
                    {
                        if (string.IsNullOrEmpty(objMW.QualificationNames))
                            objMW.QualificationNames += "||";

                        objMW.QualificationNames += targetValue + "||";
                        _serv.Update(objMW);

                        List<string> QNsList = objMW.QualificationNames.Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries).OrderBy(c => c).Select(c => c).ToList();

                        //set count display
                        ltQNCount.Text = QNsList.Count().ToString();

                        rptQualificationName.DataSource = QNsList;
                        rptQualificationName.DataBind();

                        tbQualificationName.Text = string.Empty;
                        tbQualificationName.Focus();
                    }
                    else
                    {
                        ltSkillsMessage.Text = "'" + targetValue + "' already exists";
                        ltSkillsMessage.Visible = true;
                    }

                    #endregion
                    

                }
                //else
                //    return new { Success = false, SessionFailed = true };
            }


        }

        #region WebMethods

        [System.Web.Services.WebMethod]
        public static object adminskilladd(string targetValue)
        {
            //note all targetValues passed in are js escaped (url encoded)
            targetValue = HttpUtility.HtmlDecode(HttpUtility.UrlDecode(targetValue));

            MemberWizardService _serv = new MemberWizardService();
            using (JXTPortal.Entities.MemberWizard objMW = _serv.GetMemberWizardBySite(SessionData.Site.SiteId))
            {
                if (objMW != null)
                {
                    if (objMW.GlobalTemplate)
                    {
                        #region Clone and Create
                        JXTPortal.Entities.MemberWizard objMWClone = (JXTPortal.Entities.MemberWizard)objMW.Clone();

                        objMWClone.SiteId = SessionData.Site.SiteId;
                        objMWClone.GlobalTemplate = false;

                        bool alreadyExists = !string.IsNullOrEmpty(objMWClone.Skills) && objMWClone.Skills.ToLower().Contains("||" + targetValue.ToLower() + "||");

                        if (!alreadyExists)
                        {
                            if (string.IsNullOrEmpty(objMWClone.Skills))
                                objMWClone.Skills += "||";

                            objMWClone.Skills += targetValue + "||";
                            _serv.Insert(objMWClone);

                            List<string> skillsList = objMWClone.Skills.Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries).OrderBy(c => c).Select(c => HttpUtility.UrlEncode(HttpUtility.HtmlEncode(c))).ToList();

                            objMWClone.Dispose();
                            return new { Success = true, data = skillsList };
                        }

                        objMWClone.Dispose();
                        return new { Success = false, Message = "'" + targetValue + "' already exists" };
                        #endregion
                    }
                    else
                    {
                        #region Update
                        bool alreadyExists = !string.IsNullOrEmpty(objMW.Skills) && objMW.Skills.ToLower().Contains("||" + targetValue.ToLower() + "||");

                        if (!alreadyExists)
                        {
                            if (string.IsNullOrEmpty(objMW.Skills))
                                objMW.Skills += "||";

                            objMW.Skills += targetValue + "||";
                            _serv.Update(objMW);

                            List<string> skillsList = objMW.Skills.Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries).OrderBy(c => c).Select(c => HttpUtility.UrlEncode(HttpUtility.HtmlEncode(c))).ToList();

                            return new { Success = true, data = skillsList };
                        }

                        return new { Success = false, Message = "'" + targetValue + "' already exists" };
                        #endregion
                    }
                }
                else
                    return new { Success = false, SessionFailed = true };
            }


        }

        [System.Web.Services.WebMethod]
        public static object adminskilldelete(string targetValue)
        {
            //note all targetValues passed in are js escaped (url encoded)
            targetValue = HttpUtility.HtmlDecode(HttpUtility.UrlDecode(targetValue));

            MemberWizardService _serv = new MemberWizardService();
            using (JXTPortal.Entities.MemberWizard objMW = _serv.GetMemberWizardBySite(SessionData.Site.SiteId))
            {
                if (objMW != null)
                {
                    if (objMW.GlobalTemplate)
                    {
                        #region Clone and Create
                        JXTPortal.Entities.MemberWizard objMWClone = (JXTPortal.Entities.MemberWizard)objMW.Clone();

                        objMWClone.SiteId = SessionData.Site.SiteId;
                        objMWClone.GlobalTemplate = false;

                        if (!string.IsNullOrEmpty(objMWClone.Skills))
                        {
                            string targetPattern = @"||" + targetValue + @"||";
                            int targetIndex = objMWClone.Skills.IndexOf(targetPattern);

                            if (targetIndex != -1)
                            {
                                targetIndex += 2; //add 2 to avoid the "||" prior
                                objMWClone.Skills = objMWClone.Skills.Remove(targetIndex, targetPattern.Length - 2);

                                _serv.Insert(objMWClone);

                                List<string> skillsList = objMWClone.Skills.Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries).OrderBy(c => c).Select(c=>HttpUtility.UrlEncode(HttpUtility.HtmlEncode(c))).ToList();

                                return new { Success = true, data = skillsList };
                            }

                        }

                        return new { Success = false, Message = "'" + targetValue + "' does not exists" };
                        #endregion
                    }
                    else
                    {
                        #region Update
                        if (!string.IsNullOrEmpty(objMW.Skills))
                        {
                            string targetPattern = @"||" + targetValue + @"||";
                            int targetIndex = objMW.Skills.IndexOf(targetPattern);

                            if (targetIndex != -1)
                            {
                                targetIndex += 2; //add 2 to avoid the "||" prior
                                objMW.Skills = objMW.Skills.Remove(targetIndex, targetPattern.Length - 2);

                                _serv.Update(objMW);

                                List<string> skillsList = objMW.Skills.Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries).OrderBy(c => c).Select(c=>HttpUtility.UrlEncode(HttpUtility.HtmlEncode(c))).ToList();

                                return new { Success = true, data = skillsList };
                            }

                        }

                        return new { Success = false, Message = "'" + targetValue + "' does not exists" };
                        #endregion
                    }
                }
                else
                    return new { Success = false, SessionFailed = true };
            }

        }

        [System.Web.Services.WebMethod]
        public static object adminlicenseadd(string targetValue)
        {
            //note all targetValues passed in are js escaped (url encoded)
            targetValue = HttpUtility.HtmlDecode(HttpUtility.UrlDecode(targetValue));

            MemberWizardService _serv = new MemberWizardService();
            using (JXTPortal.Entities.MemberWizard objMW = _serv.GetMemberWizardBySite(SessionData.Site.SiteId))
            {
                if (objMW != null)
                {
                    if (objMW.GlobalTemplate)
                    {
                        #region Clone and Create
                        JXTPortal.Entities.MemberWizard objMWClone = (JXTPortal.Entities.MemberWizard)objMW.Clone();

                        objMWClone.SiteId = SessionData.Site.SiteId;
                        objMWClone.GlobalTemplate = false;

                        bool alreadyExists = !string.IsNullOrEmpty(objMWClone.LicenseTypes) && objMWClone.LicenseTypes.ToLower().Contains("||" + targetValue.ToLower() + "||");

                        if (!alreadyExists)
                        {
                            if (string.IsNullOrEmpty(objMWClone.LicenseTypes))
                                objMWClone.LicenseTypes += "||";

                            objMWClone.LicenseTypes += targetValue + "||";
                            _serv.Insert(objMWClone);

                            List<string> skillsList = objMWClone.LicenseTypes.Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries).OrderBy(c => c).Select(c => HttpUtility.UrlEncode(HttpUtility.HtmlEncode(c))).ToList();

                            objMWClone.Dispose();
                            return new { Success = true, data = skillsList };
                        }

                        objMWClone.Dispose();
                        return new { Success = false, Message = "'" + targetValue + "' already exists" };
                        #endregion
                    }
                    else
                    {
                        #region Update
                        bool alreadyExists = !string.IsNullOrEmpty(objMW.LicenseTypes) && objMW.LicenseTypes.ToLower().Contains("||" + targetValue.ToLower() + "||");

                        if (!alreadyExists)
                        {
                            if (string.IsNullOrEmpty(objMW.LicenseTypes))
                                objMW.LicenseTypes += "||";

                            objMW.LicenseTypes += targetValue + "||";
                            _serv.Update(objMW);

                            List<string> skillsList = objMW.LicenseTypes.Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries).OrderBy(c => c).Select(c => HttpUtility.UrlEncode(HttpUtility.HtmlEncode(c))).ToList();

                            return new { Success = true, data = skillsList };
                        }

                        return new { Success = false, Message = "'" + targetValue + "' already exists" };
                        #endregion
                    }
                }
                else
                    return new { Success = false, SessionFailed = true };
            }


        }

        [System.Web.Services.WebMethod]
        public static object adminlicensedelete(string targetValue)
        {
            //note all targetValues passed in are js escaped (url encoded)
            targetValue = HttpUtility.HtmlDecode(HttpUtility.UrlDecode(targetValue));

            MemberWizardService _serv = new MemberWizardService();
            using (JXTPortal.Entities.MemberWizard objMW = _serv.GetMemberWizardBySite(SessionData.Site.SiteId))
            {
                if (objMW != null)
                {
                    if (objMW.GlobalTemplate)
                    {
                        #region Clone and Create
                        JXTPortal.Entities.MemberWizard objMWClone = (JXTPortal.Entities.MemberWizard)objMW.Clone();

                        objMWClone.SiteId = SessionData.Site.SiteId;
                        objMWClone.GlobalTemplate = false;

                        if (!string.IsNullOrEmpty(objMWClone.LicenseTypes))
                        {
                            string targetPattern = @"||" + targetValue + @"||";
                            int targetIndex = objMWClone.LicenseTypes.IndexOf(targetPattern);

                            if (targetIndex != -1)
                            {
                                targetIndex += 2; //add 2 to avoid the "||" prior
                                objMWClone.LicenseTypes = objMWClone.LicenseTypes.Remove(targetIndex, targetPattern.Length - 2);

                                _serv.Insert(objMWClone);

                                List<string> skillsList = objMWClone.LicenseTypes.Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries).OrderBy(c => c).Select(c => HttpUtility.UrlEncode(HttpUtility.HtmlEncode(c))).ToList();

                                return new { Success = true, data = skillsList };
                            }

                        }

                        return new { Success = false, Message = "'" + targetValue + "' does not exists" };
                        #endregion
                    }
                    else
                    {
                        #region Update
                        if (!string.IsNullOrEmpty(objMW.LicenseTypes))
                        {
                            string targetPattern = @"||" + targetValue + @"||";
                            int targetIndex = objMW.LicenseTypes.IndexOf(targetPattern);

                            if (targetIndex != -1)
                            {
                                targetIndex += 2; //add 2 to avoid the "||" prior
                                objMW.LicenseTypes = objMW.LicenseTypes.Remove(targetIndex, targetPattern.Length - 2);

                                _serv.Update(objMW);

                                List<string> skillsList = objMW.LicenseTypes.Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries).OrderBy(c => c).Select(c => HttpUtility.UrlEncode(HttpUtility.HtmlEncode(c))).ToList();

                                return new { Success = true, data = skillsList };
                            }

                        }

                        return new { Success = false, Message = "'" + targetValue + "' does not exists" };
                        #endregion
                    }
                }
                else
                    return new { Success = false, SessionFailed = true };
            }

        }



        #endregion

    }
}