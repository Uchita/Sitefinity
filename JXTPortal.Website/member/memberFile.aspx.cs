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

namespace JXTPortal.Website.members
{
    public partial class memberFile : System.Web.UI.Page
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

        #endregion

        #region Page Event handlers

        protected void Page_Init(object sender, EventArgs e)
        {
            CommonPage.SetBrowserPageTitle(Page, "Member Files");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            toolkitScriptManager.RegisterPostBackControl(this.btnSubmit);

            if (!IsPostBack)
            {
                this.loadForm();
            }
            SetFormValues();
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

                using (JXTPortal.Entities.MemberFiles memberFile = e.Item.DataItem as JXTPortal.Entities.MemberFiles)
                {
                    ltResumeName.Text = memberFile.MemberFileTitle;
                    ltResumeDateEntered.Text = string.Format("{0:" + SessionData.Site.DateFormat + "}", memberFile.LastModifiedDate);
                }
            }
        }

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

                using (JXTPortal.Entities.MemberFiles memberFile = e.Item.DataItem as JXTPortal.Entities.MemberFiles)
                {
                    ltCoverName.Text = memberFile.MemberFileTitle;
                    ltCoverDateEntered.Text = string.Format("{0:" + SessionData.Site.DateFormat + "}", memberFile.LastModifiedDate);
                }
            }
        }

        #endregion

        #region Methods

        public void SetFormValues()
        {
            btnSubmit.Text = CommonFunction.GetResourceValue("ButtonSave");
        }

        protected void loadForm()
        {
            if (Entities.SessionData.Member != null)
            {
                MembersService service = new MembersService();
                Entities.Members member = service.GetByMemberId(Entities.SessionData.Member.MemberId);

                if (member.RequiredPasswordChange.HasValue && ((bool)member.RequiredPasswordChange))
                {
                    Response.Redirect("~/member/changepassword.aspx?returnurl=" + Server.UrlEncode(Request.Url.OriginalString));
                }
            }
            else
            {
                Response.Redirect("~/member/login.aspx?returnurl=" + Server.UrlEncode(Request.Url.OriginalString));
                return;
            }

            memberID = Entities.SessionData.Member.MemberId;

            using (TList<Entities.MemberFiles> objmembers = MembersFilesService.GetByMemberId(memberID))
            {
                ddlMemberFileType.DataSource = CommonFunction.GetEnumFormattedNames<PortalEnums.Members.MemberFileTypes>();

                ddlMemberFileType.DataTextField = "Key";
                ddlMemberFileType.DataValueField = "Value";
                ddlMemberFileType.DataBind();

                //Repeater Member Resume
                if (objmembers.Count > 0)
                {
                    ltMemberFileNoResume.Visible = false;
                    rptResume.Visible = true;
                    rptResume.DataSource = objmembers;
                    objmembers.Filter = "DocumentTypeID = 2";
                    rptResume.DataBind();
                }
                else
                {
                    ltMemberFileNoResume.Visible = true;
                    rptResume.Visible = false;
                }

                //Repeater Member Cover Letter
                if (objmembers.Count > 0)
                {
                    ltMemberFileNoCoverLetter.Visible = false;
                    rptCoverLetter.Visible = true;
                    rptCoverLetter.DataSource = objmembers;
                    objmembers.Filter = "DocumentTypeID = 1";
                    rptCoverLetter.DataBind();
                }
                else
                {
                    ltMemberFileNoCoverLetter.Visible = true;
                    rptCoverLetter.Visible = false;
                }

            }

        }

        protected void uploadFile()
        {
            if (this.IsValid)
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

                            MemberFilesService mfs = new MemberFilesService();
                            mfs.Insert(objMemberFiles);
                        }
                    }

                    Response.Redirect("memberfile.aspx");
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

            Response.Redirect("memberfile.aspx");
        }

        protected void cvalDocument_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (docInput.PostedFile == null || docInput.PostedFile.ContentLength == 0)
            {
                args.IsValid = false;
                this.cvalDocument.ErrorMessage = "Please ensure you have selected a document to upload";
                return;
            }
            else if (this.MemberFileTypeID <= 0)
            {
                args.IsValid = false;
                this.cvalDocument.ErrorMessage = "File type extension is not accepted";
                return;
            }
            else if (CheckFileName == true)
            {
                args.IsValid = false;
                this.cvalDocument.ErrorMessage = "File already exists, please select another file or change the file name";
                return;
            }
            else
            {
                args.IsValid = true;
            }

        }

        #endregion

    }
}
