

#region Using directives
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml;
using JXTPortal.Web.UI;
using JXTPortal.Website.Admin.UserControls;
using JXTPortal.Entities;
using JXTPortal;
using JXTPortal.Common;
#endregion

public partial class SiteProfession : System.Web.UI.Page
{
    #region Declarations

    private ProfessionService _professionService;
    private RolesService _rolesService;
    private SiteProfessionService _siteprofessionservice;
    private SiteRolesService _siterolesservice;

    #endregion

    #region Properties

    private ProfessionService ProfessionService
    {
        get
        {
            if (_professionService == null)
            {
                _professionService = new ProfessionService();
            }
            return _professionService;
        }
    }

    private RolesService RolesService
    {
        get
        {
            if (_rolesService == null)
            {
                _rolesService = new RolesService();
            }
            return _rolesService;
        }
    }

    private SiteProfessionService SiteProfessionService
    {
        get
        {
            if (_siteprofessionservice == null)
            {
                _siteprofessionservice = new SiteProfessionService();
            }
            return _siteprofessionservice;
        }
    }

    private SiteRolesService SiteRolesService
    {
        get
        {
            if (_siterolesservice == null)
            {
                _siterolesservice = new SiteRolesService();
            }
            return _siterolesservice;
        }
    }

    #endregion

    #region Page
    protected void Page_Load(object sender, EventArgs e)
    {
        btnImport.Visible = false;
        if (JXTPortal.Entities.SessionData.Site.UseCustomProfessionRole)
        {
            btnImport.Visible = true;

            SiteCustomMappingService _service = new SiteCustomMappingService();
            SiteCustomMapping siteMapping = _service.GetAll().Find(s => s.SiteId == SessionData.Site.SiteId);

            // Check if there is custom mapping then disable it.
            if (siteMapping != null)
            {
                btnImport.Enabled = false;
                btnImport.Text = "Import Disabled. Please update Master Site.";
            }
        }



        if (!Page.IsPostBack)
        {
            LoadTree();
        }
    }

    #endregion

    #region Methods
    private void LoadTree()
    {
        int siteid = SessionData.Site.SiteId;
        string strTemp = string.Empty;

        try
        {
            DataSet dsProfession = ProfessionService.GetSiteTree(siteid);
            XmlDocument professionalxmldoc = new XmlDocument();
            if (dsProfession.Tables[0].Rows.Count > 0)
            {
                professionalxmldoc.LoadXml(dsProfession.GetXml());
            }

            DataSet dsRoles = RolesService.GetSiteTree(siteid);
            XmlDocument rolesxmldoc = new XmlDocument();
            if (dsRoles.Tables[0].Rows.Count > 0)
            {
                rolesxmldoc.LoadXml(dsRoles.GetXml());
            }

            foreach (XmlNode roleNode in rolesxmldoc.GetElementsByTagName("Table"))
            {
                string RoleID = roleNode.ChildNodes[0].InnerText;
                string ProfessionID = roleNode.ChildNodes[1].InnerText;
                string RoleName = Server.HtmlEncode(roleNode.ChildNodes[2].InnerText);

                if (roleNode.ChildNodes.Count == 3)
                {
                    roleNode.AppendChild(rolesxmldoc.CreateElement("SiteRoleID"));
                    roleNode.AppendChild(rolesxmldoc.CreateElement("SiteRoleName"));
                    roleNode.AppendChild(rolesxmldoc.CreateElement("Valid"));
                    roleNode.AppendChild(rolesxmldoc.CreateElement("Sequence"));
                    roleNode.AppendChild(rolesxmldoc.CreateElement("SiteRoleFrienddlyUrl"));
                }

                string SiteRoleID = roleNode.ChildNodes[3].InnerText;
                string SiteRoleName = Server.HtmlEncode(roleNode.ChildNodes[4].InnerText);
                string Valid = roleNode.ChildNodes[5].InnerText;
                string Sequence = roleNode.ChildNodes[6].InnerText;
                string SiteRoleFrienddlyUrl = Server.HtmlEncode(roleNode.ChildNodes[7].InnerText);
                string MetaTitle = Server.HtmlEncode(roleNode.ChildNodes[8].InnerText);
                string MetaKeyword = Server.HtmlEncode(roleNode.ChildNodes[9].InnerText);
                string MetaDescription = Server.HtmlEncode(roleNode.ChildNodes[10].InnerText);


                foreach (XmlNode professionNode in professionalxmldoc.GetElementsByTagName("Table"))
                {
                    string pid = professionNode.ChildNodes[0].InnerText;

                    if (professionNode.ChildNodes.Count == 2)
                    {
                        professionNode.AppendChild(professionalxmldoc.CreateElement("SiteProfessionID"));
                        professionNode.AppendChild(professionalxmldoc.CreateElement("SiteProfessionName"));
                        professionNode.AppendChild(professionalxmldoc.CreateElement("Valid"));
                        professionNode.AppendChild(professionalxmldoc.CreateElement("Sequence"));
                        professionNode.AppendChild(professionalxmldoc.CreateElement("SiteProfessionFrienddlyUrl"));
                    }

                    if (ProfessionID == pid)
                    {
                        if (professionNode.ChildNodes.Count == 10)
                        {
                            professionNode.AppendChild(professionalxmldoc.CreateElement("Roles"));
                        }
                        strTemp = string.Format("<Role><RoleID>{0}</RoleID><ProfessionID>{1}</ProfessionID><RoleName>{2}</RoleName><SiteRoleID>{3}</SiteRoleID><SiteRoleName>{4}</SiteRoleName><Valid>{5}</Valid><Sequence>{6}</Sequence><SiteRoleFrienddlyUrl>{7}</SiteRoleFrienddlyUrl><MetaTitle>{8}</MetaTitle><MetaKeywords>{9}</MetaKeywords><MetaDescription>{10}</MetaDescription></Role>", RoleID,
                        ProfessionID, RoleName, SiteRoleID, SiteRoleName, Valid, Sequence, SiteRoleFrienddlyUrl, MetaTitle, MetaKeyword, MetaDescription);

                        professionNode.ChildNodes[10].InnerXml += string.Format("<Role><RoleID>{0}</RoleID><ProfessionID>{1}</ProfessionID><RoleName>{2}</RoleName><SiteRoleID>{3}</SiteRoleID><SiteRoleName>{4}</SiteRoleName><Valid>{5}</Valid><Sequence>{6}</Sequence><SiteRoleFrienddlyUrl>{7}</SiteRoleFrienddlyUrl><MetaTitle>{8}</MetaTitle><MetaKeywords>{9}</MetaKeywords><MetaDescription>{10}</MetaDescription></Role>", RoleID,
                        ProfessionID, RoleName, SiteRoleID, SiteRoleName, Valid, Sequence, SiteRoleFrienddlyUrl, MetaTitle, MetaKeyword, MetaDescription);

                        break;
                    }
                }
            }

            foreach (XmlNode professionNode in professionalxmldoc.GetElementsByTagName("Table"))
            {
                if (professionNode.ChildNodes.Count == 2)
                {
                    professionNode.AppendChild(professionalxmldoc.CreateElement("SiteProfessionID"));
                    professionNode.AppendChild(professionalxmldoc.CreateElement("SiteProfessionName"));
                    professionNode.AppendChild(professionalxmldoc.CreateElement("Valid"));
                    professionNode.AppendChild(professionalxmldoc.CreateElement("Sequence"));
                    professionNode.AppendChild(professionalxmldoc.CreateElement("SiteProfessionFrienddlyUrl"));
                }

                string ProfessionID = professionNode.ChildNodes[0].InnerText;
                string ProfessionName = Server.HtmlEncode(professionNode.ChildNodes[1].InnerText);
                string SiteProfessionID = professionNode.ChildNodes[2].InnerText;
                string SiteProfessionName = Server.HtmlEncode(professionNode.ChildNodes[3].InnerText);
                string Valid = professionNode.ChildNodes[4].InnerText;
                string Sequence = professionNode.ChildNodes[5].InnerText;
                string SiteProfessionFriendlyUrl = Server.HtmlEncode(professionNode.ChildNodes[6].InnerText);
                string PMetaTitle = professionNode.ChildNodes[7].InnerText;
                string PMetaKeyword = professionNode.ChildNodes[8].InnerText;
                string PMetaDescription = professionNode.ChildNodes[9].InnerText;

                ProfessionRoleTreeView.ProfessionRoleTreeNode professionnode = new ProfessionRoleTreeView.ProfessionRoleTreeNode();
                professionnode.Text = ProfessionName;
                professionnode.NavigateUrl = "SiteProfessionEdit.aspx?ProfessionId=" + ProfessionID;
                professionnode.Value = ProfessionID;
                professionnode.Expanded = true;

                TreeNode siteprofessionnode = new TreeNode();
                siteprofessionnode.ShowCheckBox = true;
                siteprofessionnode.Expanded = true;
                siteprofessionnode.Text = ProfessionName;
                siteprofessionnode.Value = ProfessionID;
                siteprofessionnode.NavigateUrl = "SiteProfessionEdit.aspx?ProfessionId=" + ProfessionID;

                if (!string.IsNullOrEmpty(SiteProfessionName))
                {
                    siteprofessionnode.Text = SiteProfessionName;
                    professionnode.SiteChecked = true;
                    siteprofessionnode.Checked = true;
                    siteprofessionnode.Value += "|" + SiteProfessionID;
                }
                siteprofessionnode.Value += "#" + PMetaTitle + "#" + PMetaKeyword + "#" + PMetaDescription;

                if (professionNode.ChildNodes.Count == 11)
                {
                    XmlNode rolesNode = professionNode.ChildNodes[10];
                    foreach (XmlNode roleNode in rolesNode.ChildNodes)
                    {
                        string RoleID = roleNode.ChildNodes[0].InnerText;
                        string RoleName = roleNode.ChildNodes[2].InnerText;
                        string SiteRoleID = roleNode.ChildNodes[3].InnerText;
                        string SiteRoleName = roleNode.ChildNodes[4].InnerText;
                        string SiteRoleFrienddlyUrl = Server.HtmlEncode(roleNode.ChildNodes[7].InnerText);
                        string RMetaTitle = roleNode.ChildNodes[8].InnerText;
                        string RMetaKeyword = roleNode.ChildNodes[9].InnerText;
                        string RMetaDescription = roleNode.ChildNodes[10].InnerText;

                        ProfessionRoleTreeView.ProfessionRoleTreeNode rolenode = new ProfessionRoleTreeView.ProfessionRoleTreeNode();
                        rolenode.Text = RoleName;
                        rolenode.NavigateUrl = "SiteRolesEdit.aspx?RoleId=" + RoleID;
                        rolenode.Value = RoleID;
                        rolenode.Expanded = true;

                        TreeNode siterolenode = new TreeNode();
                        siterolenode.ShowCheckBox = true;
                        siterolenode.Text = RoleName;
                        siterolenode.NavigateUrl = "SiteRolesEdit.aspx?RoleId=" + RoleID;
                        siterolenode.Value = RoleID;
                        siterolenode.Expanded = true;

                        professionnode.ChildNodes.Add(rolenode);
                        siteprofessionnode.ChildNodes.Add(siterolenode);

                        if (!string.IsNullOrEmpty(SiteRoleName))
                        {
                            siterolenode.Text = SiteRoleName;
                            rolenode.SiteChecked = true;
                            siterolenode.Checked = true;
                            siterolenode.Value += "|" + SiteRoleID;
                        }

                        siterolenode.Value += "#" + RMetaTitle + "#" + RMetaKeyword + "#" + RMetaDescription;
                    }
                }

                TreeView1.Nodes.Add(professionnode);
                TreeView2.Nodes.Add(siteprofessionnode);
            }
        }
        catch (Exception ex)
        {
            hfErrorText.Value = strTemp;
        }

    }
    #endregion

    #region TreeView1 Events

    protected void TreeView1_TreeNodeCheckChanged(object sender, TreeNodeEventArgs e)
    {
        TreeNode node = (TreeNode)sender;
        if (node.Parent != null)
        {
            if (e.Node.Checked)
            {
                node.Parent.Checked = true;
            }
        }
    }

    #endregion

    #region Events
    protected void btnEditSave_Click(object sender, EventArgs e)
    {
        TList<JXTPortal.Entities.Profession> professions = null;
        TList<JXTPortal.Entities.Roles> roles = RolesService.GetAll();

        StringBuilder sbProfessionInsert = new StringBuilder();
        StringBuilder sbRolesInsert = new StringBuilder();
        StringBuilder sbProfessionDelete = new StringBuilder();
        StringBuilder sbRolesDelete = new StringBuilder();

        if (SessionData.Site.UseCustomProfessionRole)
        {
            SiteCustomMappingService _service = new SiteCustomMappingService();
            SiteCustomMapping siteMapping = _service.GetAll().Find(s => s.SiteId == SessionData.Site.SiteId);

            // Check if there is custom mapping then filter by the master site.
            if (siteMapping != null)
                professions = ProfessionService.GetByReferredSiteId(siteMapping.MasterSiteId);
            else
                professions = ProfessionService.GetByReferredSiteId(SessionData.Site.SiteId);

        }
        else
        {
            professions = ProfessionService.GetByReferredSiteId(null);
        }

        string professionlist = string.Empty;

        foreach (JXTPortal.Entities.Profession profession in professions)
        {
            professionlist += profession.ProfessionId.ToString() + ",";
        }

        professionlist = professionlist.TrimEnd(new char[] { ',' });

        //if (!string.IsNullOrWhiteSpace(professionlist))
        //{
        //    roles.Filter = "ProfessionID IN (" + professionlist + ")";
        //}

        using (TList<JXTPortal.Entities.SiteRoles> siteroles = new TList<JXTPortal.Entities.SiteRoles>())
        using (TList<JXTPortal.Entities.SiteProfession> siteprofessions = new TList<JXTPortal.Entities.SiteProfession>())
        {
            using (TList<JXTPortal.Entities.SiteRoles> backupsiteroles = SiteRolesService.GetBySiteId(SessionData.Site.SiteId))
            using (TList<JXTPortal.Entities.SiteProfession> backupsiteprofessions = SiteProfessionService.GetBySiteId(SessionData.Site.SiteId))
            {
                for (int i = 0; i < TreeView2.Nodes.Count; i++)
                {
                    TreeNode node = TreeView2.Nodes[i];

                    int professionid = 0;
                    int siteprofessionid = 0;
                    string pmetatitle = string.Empty;
                    string pmetakeyword = string.Empty;
                    string pmetadescription = string.Empty;

                    bool hasSiteProfession = false;

                    if (node.Value.Contains("|"))
                    {
                        professionid = Convert.ToInt32(node.Value.Split(new char[] { '|', '#' })[0]);
                        siteprofessionid = Convert.ToInt32(node.Value.Split(new char[] { '|', '#' })[1]);

                        hasSiteProfession = true;
                    }
                    else
                    {
                        professionid = Convert.ToInt32(node.Value.Split(new char[] { '|', '#' })[0]);
                    }

                    pmetatitle = node.Value.Split(new char[] { '#' })[1];
                    pmetakeyword = node.Value.Split(new char[] { '#' })[2];
                    pmetadescription = node.Value.Split(new char[] { '#' })[3];

                    if (node.Checked && hasSiteProfession == false)
                    {
                        // Insert
                        using (JXTPortal.Entities.SiteProfession siteprofession = new JXTPortal.Entities.SiteProfession())
                        {
                            siteprofession.SiteId = SessionData.Site.SiteId;
                            siteprofession.SiteProfessionName = node.Text;
                            siteprofession.ProfessionId = professionid;
                            siteprofession.MetaTitle = pmetatitle;
                            siteprofession.MetaKeywords = pmetakeyword;
                            siteprofession.MetaDescription = pmetadescription;
                            siteprofession.Valid = node.Checked;

                            // Set Friendly name for Professions if empty
                            siteprofession.SiteProfessionFriendlyUrl = Utils.UrlFriendlyName(Server.HtmlDecode(node.Text));
                            // SiteProfessionService.Insert(siteprofession);
                            sbProfessionInsert.AppendFormat("({0}, {1}, '{2}', {3}, '{4}', '{5}', '{6}', {7}, '{8}', 0),",
                                SessionData.Site.SiteId, professionid, node.Text.Replace("'", "''"), 1, pmetatitle.Replace("'", "''"), pmetakeyword.Replace("'", "''"), pmetadescription.Replace("'", "''"), 0, Utils.UrlFriendlyName(Server.HtmlDecode(node.Text)));
                        }
                    }
                    else
                    {
                        if (node.Checked == false && hasSiteProfession)
                        {
                            sbProfessionDelete.Append(siteprofessionid.ToString() + ",");

                            // SiteProfessionService.Delete(currentprofession);
                        }
                    }

                    foreach (TreeNode rolenode in node.ChildNodes)
                    {
                        int roleid = 0;
                        int siteroleid = 0;
                        bool hasSiteRole = false;

                        string rmetatitle = string.Empty;
                        string rmetakeyword = string.Empty;
                        string rmetadescription = string.Empty;

                        if (rolenode.Value.Contains("|"))
                        {
                            roleid = Convert.ToInt32(rolenode.Value.Split(new char[] { '|', '#' })[0]);
                            siteroleid = Convert.ToInt32(rolenode.Value.Split(new char[] { '|', '#' })[1]);

                            hasSiteRole = true;
                        }
                        else
                        {
                            roleid = Convert.ToInt32(rolenode.Value.Split(new char[] { '|', '#' })[0]);
                        }

                        rmetatitle = node.Value.Split(new char[] { '#' })[1];
                        rmetakeyword = node.Value.Split(new char[] { '#' })[2];
                        rmetadescription = node.Value.Split(new char[] { '#' })[3];

                        if (rolenode.Checked && hasSiteRole == false)
                        {
                            // Insert
                            using (JXTPortal.Entities.SiteRoles siterole = new JXTPortal.Entities.SiteRoles())
                            {
                                siterole.SiteId = SessionData.Site.SiteId;
                                siterole.SiteRoleName = rolenode.Text;

                                // Set Friendly name for Professions if empty
                                siterole.SiteRoleFriendlyUrl = Utils.UrlFriendlyName(Server.HtmlDecode(rolenode.Text));

                                siterole.RoleId = roleid;
                                siterole.MetaTitle = rmetatitle;
                                siterole.MetaKeywords = rmetakeyword;
                                siterole.MetaDescription = rmetadescription;
                                siterole.Valid = rolenode.Checked;
                                // SiteRolesService.Insert(siterole);

                                // (SiteID, RoleID, SiteRoleName, Valid, MetaTitle, MetaKeywords, MetaDescription, Sequence, SiteRoleFriendlyUrl)
                                sbRolesInsert.AppendFormat("({0}, {1}, '{2}', {3}, '{4}', '{5}', '{6}', {7}, '{8}', 0),",
                                SessionData.Site.SiteId, roleid, rolenode.Text.Replace("'", "''"), 1, rmetatitle.Replace("'", "''"), rmetakeyword.Replace("'", "''"), rmetadescription.Replace("'", "''"), 0, Utils.UrlFriendlyName(Server.HtmlDecode(rolenode.Text)));
                            }
                        }
                        else
                        {
                            if (rolenode.Checked == false && siteroleid != 0)
                            {
                                sbRolesDelete.Append(siteroleid.ToString() + ",");
                                // SiteRolesService.Delete(currentrole);
                            }
                        }
                    }
                }
            }
        }

        if (sbRolesDelete.Length > 0)
        {
            SiteRolesService.CustomBulkDelete(sbRolesDelete.ToString().TrimEnd(new char[] { ',' }));
        }

        if (sbProfessionDelete.Length > 0)
        {
            SiteProfessionService.CustomBulkDelete(sbProfessionDelete.ToString().TrimEnd(new char[] { ',' }));
        }

        if (sbProfessionInsert.Length > 0)
        {
            SiteProfessionService.CustomBulkInsert(sbProfessionInsert.ToString().TrimEnd(new char[] { ',' }));
        }

        if (sbRolesInsert.Length > 0)
        {
            SiteRolesService.CustomBulkInsert(sbRolesInsert.ToString().TrimEnd(new char[] { ',' }));
        }

        // Update the Job count of the website.
        JobsService js = new JobsService();
        js.CustomUpdateSiteJobCount(SessionData.Site.SiteId);

        TreeView1.Nodes.Clear();
        TreeView2.Nodes.Clear();
        LoadTree();
        ltlMessage.Text = "Profession & Roles allocated successfully.";
    }

    protected void btnImport_Click(object sender, EventArgs e)
    {
        Response.Redirect("SiteProfessionRoleImport.aspx");
    }
    #endregion
}


