#region imports
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using JXTPortal.Web.UI;
using JXTPortal.Entities;
using JXTPortal.Common;
using System.Configuration;
#endregion

namespace JXTPortal.Website
{
    public partial class Download : System.Web.UI.Page
    {
        private int memberID = 0;
        private string _type = string.Empty;
        private int _id = -1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (type.Equals("mf") && id > 0)
                {
                    this.doDownload();
                }
                else
                {
                    //display - not found
                }
            }

        }

        private void doDownload()
        {
            //MemberFiles Download - mf
            if (this._type == "mf")
            {
                int MemberFileID = 0;
                //memberID = Entities.SessionData.Member.MemberId;

                bool blnAuthorised = false;

                try
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["id"]) && int.TryParse(Request.QueryString["id"], out MemberFileID) &&
                        (SessionData.Member != null || SessionData.AdminUser != null))
                    {
                        MemberFilesService memberFileService = new MemberFilesService();
                        MembersService membersService = new MembersService();

                        using (Entities.MemberFiles memberFile = memberFileService.GetByMemberFileId(MemberFileID))
                        {
                            if (memberFile != null)
                            {
                                int membersiteid = membersService.GetByMemberId(memberFile.MemberId).SiteId;

                                // Only a member can login his own file 
                                // OR when logged in Admin - then only download files if you are on that site.
                                if ((Entities.SessionData.Member != null && memberFile.MemberId == Entities.SessionData.Member.MemberId) || (SessionData.AdminUser != null && (SessionData.AdminUser.SiteId == membersiteid || SessionData.AdminUser.isAdminUser)))
                                {
                                    this.Response.ContentType = "application/octet-stream";
                                    this.Response.AppendHeader("Content-Disposition", "attachment;filename=" + memberFile.MemberFileName);

                                    if (!string.IsNullOrWhiteSpace(memberFile.MemberFileUrl))
                                    {
                                        string errormessage = string.Empty;

                                        FtpClient ftpclient = new FtpClient();
                                        ftpclient.Host = ConfigurationManager.AppSettings["FTPHost"];
                                        ftpclient.Username = ConfigurationManager.AppSettings["FTPJobApplyUsername"];
                                        ftpclient.Password = ConfigurationManager.AppSettings["FTPJobApplyPassword"];

                                        string filepath = string.Format("{0}{1}/{2}/{3}/{4}", ConfigurationManager.AppSettings["FTPHost"], ConfigurationManager.AppSettings["MemberRootFolder"], ConfigurationManager.AppSettings["MemberFilesFolder"], memberFile.MemberId, memberFile.MemberFileUrl);
                                        Stream ms = null;
                                        ftpclient.DownloadFileToClient(filepath, ref ms, out errormessage);

                                        if (string.IsNullOrEmpty(errormessage))
                                        {
                                            this.Response.BinaryWrite(((MemoryStream)ms).ToArray());
                                        }
                                    }
                                    else
                                    {
                                        this.Response.BinaryWrite(memberFile.MemberFileContent);
                                    }
                                    blnAuthorised = true;

                                }
                            }
                        }

                        if (blnAuthorised)
                        {
                            this.Response.Flush();
                            this.Response.End();
                        }

                    }
                }
                catch
                {

                }

                Response.Redirect("~/member/login.aspx?returnurl=" + Server.UrlEncode(Request.Url.PathAndQuery));
                //this.Response.End();

            }

        }

        #region Properties

        private string type
        {
            get
            {
                try
                {
                    if (Request.QueryString["type"] != null)
                    {
                        _type = Request.QueryString["type"].ToLower().Trim();
                    }
                    return _type;

                }
                catch
                {
                    return _type;
                }
            }

        }

        private int id
        {
            get
            {
                try
                {
                    if ((Request.QueryString["id"] != null))
                    {
                        if (int.TryParse((Request.QueryString["id"].Trim()), out _id))
                        {
                            _id = Convert.ToInt32(Request.QueryString["id"]);
                        }
                        return _id;
                    }

                }
                catch (Exception e)
                {

                }
                return _id;
            }
        }

        #endregion

    }
}
