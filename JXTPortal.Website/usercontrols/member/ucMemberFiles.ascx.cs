using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;
using System.Data;
using System.IO;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using JXTPortal.Web.UI;
using System.Collections;

namespace JXTPortal.Website.usercontrols.member
{
    public partial class ucMemberFiles : System.Web.UI.UserControl
    {
        #region Declare Variables

        private int memberID = 0;

        #endregion

        #region "Properties"

        private MemberFilesService _membersFilesService;

        private MemberFilesService MembersFilesService
        {
            get
            {
                if (_membersFilesService == null)
                {
                    _membersFilesService = new MemberFilesService();
                }
                return _membersFilesService;
            }
        }

        private MemberFileTypesService _memberFileTypesService;

        private MemberFileTypesService MemberFileTypesService
        {
            get
            {
                if (_memberFileTypesService == null)
                {
                    _memberFileTypesService = new MemberFileTypesService();
                }
                return _memberFileTypesService;
            }
        }

        public int CurrentPage
        {
            get
            {
                if (this.ViewState["CurrentPage"] == null)
                    return 0;
                else
                    return Convert.ToInt16(this.ViewState["CurrentPage"].ToString());
            }
            set
            {
                this.ViewState["CurrentPage"] = value;
            }
        }

        #endregion

        #region Page Event handlers

        protected void Page_Init(object sender, EventArgs e)
        {
            CommonPage.SetBrowserPageTitle(Page, "Member Files");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //toolkitScriptManager.RegisterPostBackControl(this.btnSubmit);

            if (!IsPostBack)
            {
                SetFormValues();
                this.loadForm();
            }
        }

        protected void rptResume_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Header)
            {
                Literal ltHeaderResumeName = e.Item.FindControl("ltHeaderResumeName") as Literal;
                Literal ltHeaderResumeDateEntered = e.Item.FindControl("ltHeaderResumeDateEntered") as Literal;

                ltHeaderResumeName.Text = CommonFunction.GetResourceValue("LabelDocumentName");
                ltHeaderResumeDateEntered.Text = CommonFunction.GetResourceValue("LabelDateEntered");
            }

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                LinkButton lnkDeleteFile = e.Item.FindControl("lnkDeleteFile") as LinkButton;
                Literal ltResumeName = e.Item.FindControl("ltResumeName") as Literal;
                Literal ltResumeDateEntered = e.Item.FindControl("ltResumeDateEntered") as Literal;

                string message = CommonFunction.GetResourceValue("LabelConfirmDeleteRecord");
                lnkDeleteFile.OnClientClick = "return confirm('" + message + "')";
                lnkDeleteFile.Text = CommonFunction.GetResourceValue("LinkButtonDelete");

                using (JXTPortal.Entities.MemberFiles memberFile = e.Item.DataItem as JXTPortal.Entities.MemberFiles)
                {
                    ltResumeName.Text = memberFile.MemberFileTitle;
                    ltResumeDateEntered.Text = string.Format("{0:" + SessionData.Site.DateFormat + "}", memberFile.LastModifiedDate);
                }

                //DataRowView rowResume = (DataRowView)e.Item.DataItem;                
                //ltResumeName.Text = Convert.ToString(rowResume["MemberFileTitle"]);
                //ltResumeDateEntered.Text = string.Format("{0:dd/MM/yyy}", rowResume["LastModifiedDate"]);
            }
        }

        //protected void rptResumePage_ItemCommand(object source, RepeaterCommandEventArgs e)
        //{
        //    if (e.CommandName == "Page")
        //    {
        //        CurrentPage = Convert.ToInt32(e.CommandArgument);
        //        loadForm();
        //    }
        //}

        //protected void rptResumePage_ItemDataBound(object sender, RepeaterItemEventArgs e)
        //{
        //    if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        //    {
        //        LinkButton lbPageNo = e.Item.FindControl("lbPageNo") as LinkButton;
        //        lbPageNo.CommandArgument = e.Item.DataItem.ToString();
        //        lbPageNo.Text = (Convert.ToInt32(e.Item.DataItem) + 1).ToString();

        //        if (lbPageNo.CommandArgument == CurrentPage.ToString())
        //        {
        //            lbPageNo.CssClass = "active_tnt_link";
        //        }
        //    }
        //}

        protected void rptCoverLetter_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Header)
            {
                Literal ltHeaderCoverName = e.Item.FindControl("ltHeaderCoverName") as Literal;
                Literal ltHeaderCoverDateEntered = e.Item.FindControl("ltHeaderCoverDateEntered") as Literal;

                ltHeaderCoverName.Text = CommonFunction.GetResourceValue("LabelDocumentName");
                ltHeaderCoverDateEntered.Text = CommonFunction.GetResourceValue("LabelDateEntered");
            }

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                LinkButton lnkCoverLetterDeleteFile = e.Item.FindControl("lnkCoverLetterDeleteFile") as LinkButton;
                Literal ltCoverName = e.Item.FindControl("ltCoverName") as Literal;
                Literal ltCoverDateEntered = e.Item.FindControl("ltCoverDateEntered") as Literal;

                string message = CommonFunction.GetResourceValue("LabelConfirmDeleteRecord");
                lnkCoverLetterDeleteFile.OnClientClick = "return confirm('" + message + "')";
                lnkCoverLetterDeleteFile.Text = CommonFunction.GetResourceValue("LinkButtonDelete");

                using (JXTPortal.Entities.MemberFiles memberFile = e.Item.DataItem as JXTPortal.Entities.MemberFiles)
                {
                    ltCoverName.Text = memberFile.MemberFileTitle;
                    ltCoverDateEntered.Text = string.Format("{0:" + SessionData.Site.DateFormat + "}", memberFile.LastModifiedDate);
                }

                //DataRowView rowCoverLetter = (DataRowView)e.Item.DataItem;
                //ltCoverName.Text = Convert.ToString(rowCoverLetter["MemberFileTitle"]);
                //ltCoverDateEntered.Text = string.Format("{0:dd/MM/yyy}", rowCoverLetter["LastModifiedDate"]);
            }
        }

        protected void rptAdditionalDocuments_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Header)
            {
                Literal ltHeaderAdditionalName = e.Item.FindControl("ltHeaderAdditionalName") as Literal;
                Literal ltHeaderAdditionalDateEntered = e.Item.FindControl("ltHeaderAdditionalDateEntered") as Literal;

                ltHeaderAdditionalName.Text = CommonFunction.GetResourceValue("LabelDocumentName");
                ltHeaderAdditionalDateEntered.Text = CommonFunction.GetResourceValue("LabelDateEntered");
            }

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                LinkButton lnkAdditionalFilesDeleteFile = e.Item.FindControl("lnkAdditionalFilesDeleteFile") as LinkButton;
                Literal ltAdditionalName = e.Item.FindControl("ltAdditionalName") as Literal;
                Literal ltAdditionalDateEntered = e.Item.FindControl("ltAdditionalDateEntered") as Literal;

                string message = CommonFunction.GetResourceValue("LabelConfirmDeleteRecord");
                lnkAdditionalFilesDeleteFile.OnClientClick = "return confirm('" + message + "')";
                lnkAdditionalFilesDeleteFile.Text = CommonFunction.GetResourceValue("LinkButtonDelete");

                using (JXTPortal.Entities.MemberFiles memberFile = e.Item.DataItem as JXTPortal.Entities.MemberFiles)
                {
                    ltAdditionalName.Text = memberFile.MemberFileTitle;
                    ltAdditionalDateEntered.Text = string.Format("{0:" + SessionData.Site.DateFormat + "}", memberFile.LastModifiedDate);
                }

                //DataRowView rowCoverLetter = (DataRowView)e.Item.DataItem;
                //ltCoverName.Text = Convert.ToString(rowCoverLetter["MemberFileTitle"]);
                //ltCoverDateEntered.Text = string.Format("{0:dd/MM/yyy}", rowCoverLetter["LastModifiedDate"]);
            }
        }

        //protected void rptCoverLetterPage_ItemCommand(object source, RepeaterCommandEventArgs e)
        //{
        //    if (e.CommandName == "Page")
        //    {
        //        CurrentPage = Convert.ToInt32(e.CommandArgument);
        //        loadForm();
        //    }
        //}

        //protected void rptCoverLetterPage_ItemDataBound(object sender, RepeaterItemEventArgs e)
        //{
        //    if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        //    {
        //        LinkButton lbPageNo = e.Item.FindControl("lbPageNo") as LinkButton;
        //        lbPageNo.CommandArgument = e.Item.DataItem.ToString();
        //        lbPageNo.Text = (Convert.ToInt32(e.Item.DataItem) + 1).ToString();

        //        if (lbPageNo.CommandArgument == CurrentPage.ToString())
        //        {
        //            lbPageNo.CssClass = "active_tnt_link";
        //        }
        //    }
        //}

        //protected void rptResume_ItemCommand(object source, RepeaterCommandEventArgs e)
        //{
        //    if (e.CommandName == "Delete")
        //    {

        //    }
        //}

        #endregion

        #region Methods

        public void SetFormValues()
        {
            btnSubmit.Text = CommonFunction.GetResourceValue("ButtonSave");
            ltMemberFileNoResume.Text = CommonFunction.GetResourceValue("LabelNoResume");
            ltMemberFileNoCoverLetter.Text = CommonFunction.GetResourceValue("LabelNoCoverLetter");
            ltMemberFileNoAdditionalDocuments.Text = CommonFunction.GetResourceValue("LabelNoAdditionalDocuments");
            rfvDocumentTitle.ErrorMessage = CommonFunction.GetResourceValue("LabelTitleRequired");
            cfDocumentTitle.ErrorMessage = CommonFunction.GetResourceValue("LabelTitleSizeError");

        }


        protected void loadForm()
        {
            if (Entities.SessionData.Member == null)
            {
                Response.Redirect("~/member/login.aspx?returnurl=" + Server.UrlEncode(Request.Url.OriginalString));
                return;
            }

            memberID = Entities.SessionData.Member.MemberId;
            //int totalCount = 0;
            //int pageCount = 0;
            //int sitePageCount = 5;

            //using (DataSet objmembers = MembersFilesService.GetPagingByMemberId(memberID, sitePageCount, CurrentPage + 1))

            using (TList<Entities.MemberFiles> objmembers = MembersFilesService.GetByMemberId(memberID))
            {
                //ddlMemberFileType.DataSource = CommonFunction.GetTranslatedValuesForArray(Enum.GetNames(typeof(PortalEnums.Members.MemberFileTypes)));
                //ddlMemberFileType.DataSource = PortalEnums.Members.GetMemberFilesDescription(Enum.GetNames(typeof(PortalEnums.Members.MemberFileTypes)));
                //string filterCoverLetter = "DocumentTypeID = 1";
                //string filterResume = "DocumentTypeID = 2";

                ddlMemberFileType.DataSource = CommonFunction.GetEnumFormattedNames<PortalEnums.Members.MemberFileTypes>();
                ddlMemberFileType.DataTextField = "Key";
                ddlMemberFileType.DataValueField = "Value";
                ddlMemberFileType.DataBind();

                //Repeater Member Resume
                if (objmembers.Count > 0)
                {
                    //lblHeaderResume.Visible = true;
                    ltMemberFileNoResume.Visible = true;
                    rptResume.Visible = false;

                    rptResume.DataSource = objmembers;
                    objmembers.Filter = "DocumentTypeID = 2";
                    if (objmembers.Count > 0)
                    {
                        ltMemberFileNoResume.Visible = false;
                        rptResume.Visible = true;
                    }
                    rptResume.DataBind();

                    ltMemberFileNoCoverLetter.Visible = true;
                    rptCoverLetter.Visible = false;

                    rptCoverLetter.DataSource = objmembers;
                    objmembers.Filter = "DocumentTypeID = 1";
                    if (objmembers.Count > 0)
                    {
                        ltMemberFileNoCoverLetter.Visible = false;
                        rptCoverLetter.Visible = true;
                    }

                    rptCoverLetter.DataBind();

                    ltMemberFileNoAdditionalDocuments.Visible = true;
                    rptAdditionalDocuments.Visible = false;


                    rptAdditionalDocuments.DataSource = objmembers;
                    objmembers.Filter = "DocumentTypeID = 3";
                    if (objmembers.Count > 0)
                    {
                        ltMemberFileNoAdditionalDocuments.Visible = false;
                        rptAdditionalDocuments.Visible = true;
                    }

                    rptAdditionalDocuments.DataBind();
                }

                //Code for paging
                ////Repeater Member Resume
                //if (objmembers.Tables[0].Rows.Count > 0)
                //{
                //    totalCount = Convert.ToInt32(objmembers.Tables[0].Rows[0].ItemArray[10]);

                //    DataView memberFiles = new DataView(objmembers.Tables[0]);
                //    memberFiles.RowFilter = filterResume;

                //    ArrayList pagelist = new ArrayList();

                //    if (totalCount % sitePageCount == 0)
                //        pageCount = totalCount / sitePageCount;
                //    else
                //        pageCount = (totalCount / sitePageCount) + 1;

                //    for (int i = 0; i < pageCount; i++)
                //    {
                //        pagelist.Add(i);
                //    }

                //    if (pagelist.Count > 1)
                //    {
                //        rptResumePage.DataSource = pagelist;
                //        rptResumePage.DataBind();
                //        rptResumePage.Visible = true;
                //    }
                //    else
                //    {
                //        rptResumePage.Visible = false;
                //    }

                //    //lblHeaderResume.Visible = true;
                //    ltMemberFileNoResume.Visible = false;
                //    rptResume.Visible = true;

                //    //DataView memberFiles = new DataView(objmembers.Tables[0]);
                //    //memberFiles.RowFilter = filterResume;
                //    rptResume.DataSource = memberFiles;
                //    rptResume.DataBind();
                //}


                ////Repeater Member Cover Letter
                //if (objmembers.Tables[0].Rows.Count > 0)
                //{
                //    totalCount = Convert.ToInt32(objmembers.Tables[0].Rows[0].ItemArray[10]);

                //    ArrayList pagelist = new ArrayList();

                //    if (totalCount % sitePageCount == 0)
                //        pageCount = totalCount / sitePageCount;
                //    else
                //        pageCount = (totalCount / sitePageCount) + 1;

                //    for (int i = 0; i < pageCount; i++)
                //    {
                //        pagelist.Add(i);
                //    }

                //    if (pagelist.Count > 1)
                //    {
                //        rptCoverLetterPage.DataSource = pagelist;
                //        rptCoverLetterPage.DataBind();
                //        rptCoverLetterPage.Visible = true;
                //    }
                //    else
                //    {
                //        rptCoverLetterPage.Visible = false;
                //    }

                //    ltMemberFileNoCoverLetter.Visible = false;
                //    rptCoverLetter.Visible = true;

                //    DataView memberFiles = new DataView(objmembers.Tables[0]);
                //    memberFiles.RowFilter = filterCoverLetter;
                //    rptCoverLetter.DataSource = memberFiles;
                //    rptCoverLetter.DataBind();
                //}



            }
        }

        protected void uploadFile()
        {
            if (Page.IsValid)
            {
                using (Entities.MemberFiles objMemberFiles = new Entities.MemberFiles())
                {
                    memberID = Entities.SessionData.Member.MemberId;

                    if ((docInput.PostedFile != null) && docInput.PostedFile.ContentLength > 0)
                    {
                        if (MemberFileTypeID > 0)
                        {
                            foreach (char c in Path.GetInvalidFileNameChars())
                            {
                                objMemberFiles.MemberFileName = Path.GetFileName(docInput.PostedFile.FileName).Trim().Replace(c.ToString(), "");
                            }
                            objMemberFiles.MemberFileSearchExtension = Path.GetExtension(docInput.PostedFile.FileName).Trim();
                            objMemberFiles.MemberFileContent = this.getArray(this.docInput.PostedFile);
                            objMemberFiles.MemberFileTitle = txtDocumentTitle.Text;
                            objMemberFiles.MemberId = memberID;
                            objMemberFiles.MemberFileTypeId = MemberFileTypeID;
                            objMemberFiles.DocumentTypeId = (int)Enum.Parse(typeof(PortalEnums.Members.MemberFileTypes), ddlMemberFileType.SelectedValue);

                            MemberFilesService mfs = new MemberFilesService();
                            mfs.Insert(objMemberFiles);
                        }
                    }

                    Response.Redirect("~/member/myresumecoverletter.aspx");
                }
            }
        }

        private byte[] getArray(HttpPostedFile f)
        {
            int i = 0;
            byte[] b = new byte[f.ContentLength];

            f.InputStream.Read(b, 0, f.ContentLength);

            return b;
        }

        private int MemberFileTypeID
        {
            get
            {
                int _memberFileTypeID = 0;

                using (TList<Entities.MemberFileTypes> objMemberFileTypes = MemberFileTypesService.GetAll())
                {

                    Entities.MemberFileTypes objMemberFileType = objMemberFileTypes.Find("MemberFileExtensions", Path.GetExtension(docInput.PostedFile.FileName).Trim());

                    if (objMemberFileType != null)
                    {
                        _memberFileTypeID = objMemberFileType.MemberFileTypeId;
                    }

                }
                return _memberFileTypeID;
            }
        }

        private Boolean CheckFileName
        {
            get
            {
                String ss = string.Empty;
                memberID = Entities.SessionData.Member.MemberId;

                foreach (char c in Path.GetInvalidFileNameChars())
                {
                    ss = Path.GetFileName(docInput.PostedFile.FileName).Trim().Replace(c.ToString(), "");
                }

                MemberFilesService memberFileService = new MemberFilesService();
                Entities.MemberFiles memberFile = memberFileService.GetByMemberIdMemberFileName(memberID, ss);

                if (memberFile != null)
                {
                    return true;
                }

                return false;
            }
        }

        #endregion

        #region Click Event handlers

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //((JXTPortal.Website.members._default)Page).SelectedTabIndex = 4;
            this.uploadFile();
        }

        protected void lnkDeleteFile_Click(object sender, EventArgs e)
        {

            int MemberFileID = 0;
            memberID = Entities.SessionData.Member.MemberId;

            LinkButton lb = (LinkButton)sender;
            MemberFileID = Convert.ToInt32(lb.CommandArgument);

            using (TList<Entities.MemberFiles> objmembers = MembersFilesService.GetByMemberId(memberID))
            {
                MemberFilesService memberFileService = new MemberFilesService();
                memberFileService.Delete(MemberFileID);
            }

            Response.Redirect("~/member/myresumecoverletter.aspx");

            //loadForm();
        }

        protected void cvalDocument_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (docInput.PostedFile == null || docInput.PostedFile.ContentLength == 0)
            {
                args.IsValid = false;
                this.cvalDocument.ErrorMessage = CommonFunction.GetResourceValue("ErrorEnsureDocumentSelected");
                return;
            }
            else if (!CommonFunction.CheckExtension(docInput.PostedFile.FileName))
            {
                args.IsValid = false;
                this.cvalDocument.ErrorMessage = CommonFunction.GetResourceValue("ErrorFileExtension");
                return;
            }
            else if (CheckFileName == true)
            {
                args.IsValid = false;
                this.cvalDocument.ErrorMessage = CommonFunction.GetResourceValue("ErrorFileExist");
                return;
            }
            else
            {
                args.IsValid = true;
            }
        }

        protected void cfDocumentTitle_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (txtDocumentTitle.Text.Length > 500)
            {
                args.IsValid = false;
            }
        }

        #endregion


    }
}