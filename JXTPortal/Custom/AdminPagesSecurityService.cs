using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Web;
using JXTPortal.Entities;
using System.Configuration;

namespace JXTPortal
{
    public static class AdminPagesSecurityService
    {
        public static bool CheckAccess(int roleID, string adminPageName)
        {
            bool valid = true;

            try
            {
                if (adminPageName.ToLower() != "login.aspx")
                {
                    int count = 0;
                    string strAdminXMLPage = ConfigurationManager.AppSettings["WebsiteFullPath"] + @"\admin\AdminPagesSecurity.xml";

                    if (roleID == (int)PortalEnums.Admin.AdminRole.Administrator)
                    {

                        XDocument xmlDoc = XDocument.Load(strAdminXMLPage);

                        var adminPages = xmlDoc.Descendants("AdminPage").Elements();
                        foreach (XElement e in adminPages)
                        {
                            if (e.Value.ToLower() == adminPageName.ToLower())
                            {
                                count++;
                                break;
                            }
                        }

                        //from adminPage in xmlDoc.Descendants("AdminPage")
                        //                 where Convert.ToInt32(adminPage.Elements("AdminRoleID").) == roleID
                        //                 && ((string)adminPage.Element("PageName").Value).ToLower() == adminPageName.ToLower()
                        //                 select adminPage;

                        //if (adminPages.Count() == 0) valid = false;

                    }
                    else if (roleID == (int)PortalEnums.Admin.AdminRole.ContentEditor)
                    {
                        if (adminPageName.ToLower() == "default.aspx")
                        {
                            count++;
                        }

                        XDocument xmlDoc = XDocument.Load(strAdminXMLPage);

                        var adminPages = xmlDoc.Descendants("ContentEditorPage").Elements();
                        foreach (XElement e in adminPages)
                        {
                            if (e.Value.ToLower() == adminPageName.ToLower())
                            {
                                count++;
                                break;
                            }
                        }
                    }
                    else if (roleID == (int)PortalEnums.Admin.AdminRole.Developer)
                    {
                        if (adminPageName.ToLower() == "default.aspx")
                        {
                            count++;
                        }

                        XDocument xmlDoc = XDocument.Load(strAdminXMLPage);

                        var adminPages = xmlDoc.Descendants("DeveloperPage").Elements();
                        foreach (XElement e in adminPages)
                        {
                            if (e.Value.ToLower() == adminPageName.ToLower())
                            {
                                count++;
                                break;
                            }
                        }
                    }
                    else if (roleID == (int)PortalEnums.Admin.AdminRole.ExternalUser)
                    {

                        return valid = false;
                    }
                    else if (roleID == (int)PortalEnums.Admin.AdminRole.Contributor)
                    {

                        if (adminPageName.ToLower() == "default.aspx")
                        {
                            count++;
                        }

                        XDocument xmlDoc = XDocument.Load(strAdminXMLPage);

                        var adminPages = xmlDoc.Descendants("ContributorPage").Elements();
                        foreach (XElement e in adminPages)
                        {
                            if (e.Value.ToLower() == adminPageName.ToLower())
                            {
                                count++;
                                break;
                            }
                        }
                    }

                    valid = (count > 0);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return valid;
        }
    }
}
