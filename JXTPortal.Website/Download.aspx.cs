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
        private string _type = string.Empty;
        private int _id = -1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (type.Equals("mf") && id > 0)
                {
                    DoDownload();    
                }
            }

        }

        private void DoDownload()
        {
            //MemberFiles Download - mf
            if (this._type == "mf")
            {
                int MemberFileID = 0;
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
                                // OR when logged in Advertiser - then only download files if you are on that site.
                                if (CanUserDownload(memberFile.MemberId, membersiteid))
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
                                       
                                        ms.Position = 0;
                                        
                                        if (string.IsNullOrEmpty(errormessage))
                                        {
                                            Response.BinaryWrite(((MemoryStream)ms).ToArray());
                                        }
                                    }
                                    else
                                    {
                                        Response.BinaryWrite(memberFile.MemberFileContent);
                                    }

                                    blnAuthorised = true;

                                }
                            }
                        }

                        if (blnAuthorised)
                        {
                            Response.Flush();
                            Response.End();
                        }

                    }
                }
                catch
                {

                }

                Response.Redirect("~/member/login.aspx?returnurl=" + Server.UrlEncode(Request.Url.PathAndQuery));
            }

        }

        private bool CanUserDownload(int memberID, int membersiteID)
        {
            var advertiserSiteId = GetAdvertiserSiteID();

            if( Entities.SessionData.Member != null && memberID == Entities.SessionData.Member.MemberId )
            {
                return true;
            }
            else if( SessionData.AdminUser != null && (SessionData.AdminUser.SiteId == membersiteID || SessionData.AdminUser.isAdminUser) )
            {
                return true;
            }
            else if( SessionData.AdvertiserUser != null && (advertiserSiteId == membersiteID || advertiserSiteId > 0) )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private int GetAdvertiserSiteID()
        {
            AdvertisersService _advertiserservice = new AdvertisersService();

            if (SessionData.AdvertiserUser != null)
            {
                JXTPortal.Entities.Advertisers advertiser = _advertiserservice.GetByAdvertiserId(SessionData.AdvertiserUser.AdvertiserId);

                return advertiser.SiteId.Value;
            }
            else
            {
                return 0;
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
