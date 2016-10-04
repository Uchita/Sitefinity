using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using JXTPortal;
using JXTPortal.Entities;
using JXTPortal.Website.Admin.UserControls;
using System.Xml;

namespace JXTPortal.Website
{
    public partial class SiteLocationArea : System.Web.UI.Page
    {
        #region Declarations

        private CountriesService _countriesservice;
        private LocationService _locationservice;
        private AreaService _areaservice;
        private SiteCountriesService _sitecountriesservice;
        private SiteLocationService _sitelocationservice;
        private SiteAreaService _siteareaservice;

        #endregion

        #region Properties

        private CountriesService CountriesService
        {
            get
            {
                if (_countriesservice == null)
                {
                    _countriesservice = new CountriesService();
                }
                return _countriesservice;
            }
        }

        private LocationService LocationService
        {
            get
            {
                if (_locationservice == null)
                {
                    _locationservice = new LocationService();
                }
                return _locationservice;
            }
        }

        private AreaService AreaService
        {
            get
            {
                if (_areaservice == null)
                {
                    _areaservice = new AreaService();
                }
                return _areaservice;
            }
        }

        private SiteCountriesService SiteCountriesService
        {
            get
            {
                if (_sitecountriesservice == null)
                {
                    _sitecountriesservice = new SiteCountriesService();
                }
                return _sitecountriesservice;
            }
        }

        private SiteLocationService SiteLocationService
        {
            get
            {
                if (_sitelocationservice == null)
                {
                    _sitelocationservice = new SiteLocationService();
                }
                return _sitelocationservice;
            }
        }

        private SiteAreaService SiteAreaService
        {
            get
            {
                if (_siteareaservice == null)
                {
                    _siteareaservice = new SiteAreaService();
                }
                return _siteareaservice;
            }
        }

        #endregion

        #region Page
        protected void Page_Load(object sender, EventArgs e)
        {
            ltlMessage.Text = string.Empty;

            if (!Page.IsPostBack)
            {
                LoadCountry();
                LoadTree();
            }
        }
        #endregion

        #region Methods

        private void LoadCountry()
        {
            using (TList<Entities.SiteCountries> sitecountries = SiteCountriesService.GetBySiteId(SessionData.Site.SiteId))
            {
                if (sitecountries.Count > 0)
                {
                    dataCountry.DataTextField = "SiteCountryName";
                    dataCountry.DataValueField = "CountryID";

                    dataCountry.DataSource = sitecountries;
                    dataCountry.DataBind();
                }
            }

        }

        private void LoadTree()
        {
            TreeView1.Nodes.Clear();
            TreeView2.Nodes.Clear();

            int siteid = SessionData.Site.SiteId;
            DataSet dsCountry = CountriesService.GetSiteTree(siteid);

            XmlDocument countryxmldoc = new XmlDocument();
            if (dsCountry.Tables[0].Rows.Count > 0)
            {
                countryxmldoc.LoadXml(dsCountry.GetXml());
            }

            DataSet dsLocation = LocationService.GetSiteTree(siteid);
            DataView dvLocation = new DataView(dsLocation.Tables[0]);
            dvLocation.RowFilter = string.Format("CountryID = {0}", dataCountry.SelectedValue);

            XmlDocument locationxmldoc = new XmlDocument();
            if (dvLocation.ToTable().Rows.Count > 0)
            {
                dsLocation.Tables.Clear();
                dsLocation.Tables.Add(dvLocation.ToTable());
                locationxmldoc.LoadXml(dsLocation.GetXml());


                DataSet dsArea = AreaService.GetSiteTree(siteid);
                DataView dvArea = new DataView(dsArea.Tables[0]);
                string loclist = string.Empty;
                foreach (DataRowView dr in dvLocation)
                {
                    loclist += dr["LocationID"].ToString() + ",";
                }

                loclist = loclist.TrimEnd(new char[] { ',' });
                dvArea.RowFilter = string.Format("LocationID IN ({0})", loclist);

                XmlDocument areaxmldoc = new XmlDocument();
                if (dsArea.Tables[0].Rows.Count > 0)
                {
                    areaxmldoc.LoadXml(dsArea.GetXml());
                }

                foreach (XmlNode areaNode in areaxmldoc.GetElementsByTagName("Table"))
                {
                    string AreaID = areaNode.ChildNodes[0].InnerText;
                    string AreaName = areaNode.ChildNodes[1].InnerText;
                    string LocationID = areaNode.ChildNodes[2].InnerText;

                    if (areaNode.ChildNodes.Count == 3)
                    {
                        areaNode.AppendChild(areaxmldoc.CreateElement("SiteAreaID"));
                        areaNode.AppendChild(areaxmldoc.CreateElement("SiteAreaName"));
                        areaNode.AppendChild(areaxmldoc.CreateElement("Valid"));
                    }

                    string SiteAreaID = areaNode.ChildNodes[3].InnerText;
                    string SiteAreaName = Server.HtmlEncode(areaNode.ChildNodes[4].InnerText);
                    string Valid = areaNode.ChildNodes[5].InnerText;

                    foreach (XmlNode locationNode in locationxmldoc.GetElementsByTagName("Table"))
                    {
                        string lid = locationNode.ChildNodes[0].InnerText;

                        if (locationNode.ChildNodes.Count == 2)
                        {
                            locationNode.AppendChild(locationxmldoc.CreateElement("SiteLocationID"));
                            locationNode.AppendChild(locationxmldoc.CreateElement("SiteLocationName"));
                            locationNode.AppendChild(locationxmldoc.CreateElement("Valid"));
                            locationNode.AppendChild(locationxmldoc.CreateElement("SiteLocationFriendlyUrl"));
                        }

                        string SiteLocationID = locationNode.ChildNodes[2].InnerText;
                        string SiteLocationName = Server.HtmlEncode(locationNode.ChildNodes[3].InnerText);
                        string lValid = locationNode.ChildNodes[4].InnerText;
                        string SiteLocationFriendlyUrl = locationNode.ChildNodes[5].InnerText;

                        if (LocationID == lid)
                        {
                            if (locationNode.ChildNodes.Count == 7)
                            {
                                locationNode.AppendChild(locationxmldoc.CreateElement("Areas"));
                            }

                            locationNode.ChildNodes[7].InnerXml += string.Format("<Area><AreaID>{0}</AreaID><AreaName>{1}</AreaName><LocationID>{2}</LocationID><SiteAreaID>{3}</SiteAreaID><SiteAreaName>{4}</SiteAreaName><Valid>{5}</Valid></Area>", AreaID,
                           Server.HtmlEncode(AreaName), LocationID, SiteAreaID, SiteAreaName, lValid);
                            break;
                        }
                    }
                }

                foreach (XmlNode locationNode in locationxmldoc.GetElementsByTagName("Table"))
                {
                    string LocationID = locationNode.ChildNodes[0].InnerText;
                    string LocationName = Server.HtmlEncode(locationNode.ChildNodes[1].InnerText);
                    string SiteLocationID = locationNode.ChildNodes[2].InnerText;
                    string SiteLocationName = Server.HtmlEncode(locationNode.ChildNodes[3].InnerText);
                    string Valid = locationNode.ChildNodes[4].InnerText;
                    string Areas = string.Empty;
                    if (locationNode.ChildNodes.Count == 8)
                    {
                        Areas = locationNode.ChildNodes[7].InnerXml;
                    }

                    if (!string.IsNullOrEmpty(Areas))
                    {
                        Areas = "<Areas>" + Areas + "</Areas>";
                    }

                    ProfessionRoleTreeView.ProfessionRoleTreeNode locationnode = new ProfessionRoleTreeView.ProfessionRoleTreeNode();
                    locationnode.Text = Server.HtmlDecode(LocationName);
                    locationnode.NavigateUrl = "SiteLocationEdit.aspx?LocationId=" + LocationID;
                    locationnode.Value = LocationID;
                    locationnode.Expanded = true;

                    TreeNode sitelocationnode = new TreeNode();
                    sitelocationnode.ShowCheckBox = true;
                    sitelocationnode.Text = Server.HtmlDecode(LocationName);
                    sitelocationnode.NavigateUrl = "SiteLocationEdit.aspx?LocationId=" + LocationID;
                    sitelocationnode.Value = LocationID;
                    sitelocationnode.Expanded = true;

                    if (!string.IsNullOrEmpty(SiteLocationName))
                    {
                        sitelocationnode.Text = SiteLocationName;
                        locationnode.SiteChecked = true;
                        sitelocationnode.Checked = true;
                    }

                    if (locationNode.ChildNodes.Count == 8)
                    {
                        XmlNode areasNode = locationNode.ChildNodes[7];
                        foreach (XmlNode areaNode in areasNode.ChildNodes)
                        {
                            string AreaID = areaNode.ChildNodes[0].InnerText;
                            string AreaName = Server.HtmlEncode(areaNode.ChildNodes[1].InnerText);
                            string SiteAreaID = areaNode.ChildNodes[3].InnerText;
                            string SiteAreaName = Server.HtmlEncode(areaNode.ChildNodes[4].InnerText);

                            ProfessionRoleTreeView.ProfessionRoleTreeNode areanode = new ProfessionRoleTreeView.ProfessionRoleTreeNode();
                            areanode.Text = Server.HtmlDecode(AreaName);
                            areanode.NavigateUrl = "SiteAreaEdit.aspx?AreaId=" + AreaID;
                            areanode.Value = AreaID;
                            areanode.Expanded = true;

                            TreeNode siteareanode = new TreeNode();
                            siteareanode.ShowCheckBox = true;
                            siteareanode.Expanded = true;
                            siteareanode.Text = Server.HtmlDecode(AreaName);
                            siteareanode.Value = AreaID;
                            siteareanode.NavigateUrl = "SiteAreaEdit.aspx?AreaId=" + AreaID;

                            locationnode.ChildNodes.Add(areanode);
                            sitelocationnode.ChildNodes.Add(siteareanode);

                            if (!string.IsNullOrEmpty(SiteAreaName))
                            {
                                siteareanode.Text = SiteAreaName;
                                areanode.SiteChecked = true;
                                siteareanode.Checked = true;
                            }
                        }
                    }

                    TreeView1.Nodes.Add(locationnode);
                    TreeView2.Nodes.Add(sitelocationnode);

                }
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
            using (DataSet dssitelocations = SiteLocationService.CustomGetBySiteID(SessionData.Site.SiteId, Convert.ToInt32(dataCountry.SelectedValue)))
            {
                foreach (TreeNode locationnode in TreeView2.Nodes)
                {
                    bool locationfound = false;
                    foreach (DataRow drlocation in dssitelocations.Tables[0].Rows)
                    {
                        if (Convert.ToInt32(drlocation["LocationID"]) == Convert.ToInt32(locationnode.Value))
                        {
                            locationfound = true;
                            break;
                        }
                    }

                    if (locationnode.Checked)
                    {
                        if (!locationfound)
                        {
                            SiteLocation sl = new SiteLocation();
                            sl.SiteId = SessionData.Site.SiteId;
                            sl.SiteLocationName = locationnode.Text;
                            sl.SiteLocationFriendlyUrl = JXTPortal.Common.Utils.UrlFriendlyName(locationnode.Text);
                            sl.LocationId = Convert.ToInt32(locationnode.Value);
                            sl.Valid = locationnode.Checked;

                            SiteLocationService.Insert(sl);
                        }

                        // Area 
                        foreach (TreeNode areanode in locationnode.ChildNodes)
                        {
                            bool areafound = false;

                            using (TList<Entities.SiteArea> siteareas = SiteAreaService.GetByLocationID(SessionData.Site.SiteId, Convert.ToInt32(locationnode.Value)))
                            {
                                foreach (SiteArea sitearea in siteareas)
                                {
                                    if (sitearea.AreaId == Convert.ToInt32(areanode.Value))
                                    {
                                        areafound = true;

                                        if (!areanode.Checked)
                                        {
                                            SiteAreaService.Delete(sitearea);
                                        }

                                        break;
                                    }
                                }

                                if (areanode.Checked)
                                {
                                    if (!areafound)
                                    {
                                        SiteArea sa = new SiteArea();
                                        sa.SiteId = SessionData.Site.SiteId;
                                        sa.SiteAreaName = areanode.Text;
                                        sa.AreaId = Convert.ToInt32(areanode.Value);
                                        sa.Valid = true;

                                        SiteAreaService.Insert(sa);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (locationfound)
                        {
                            SiteLocationService.CustomDeleteBySiteIDLocationID(SessionData.Site.SiteId, Convert.ToInt32(locationnode.Value));
                        }
                    }
                }
            }

            //using (TList<JXTPortal.Entities.Location> locations = LocationService.GetAll())
            //using (TList<JXTPortal.Entities.Area> areas = AreaService.GetAll())
            //using (TList<JXTPortal.Entities.SiteArea> siteareas = new TList<JXTPortal.Entities.SiteArea>())
            //using (TList<JXTPortal.Entities.SiteLocation> sitelocations = new TList<JXTPortal.Entities.SiteLocation>())
            //{
            //    using (TList<JXTPortal.Entities.SiteArea> backupsiteareas = SiteAreaService.GetBySiteId(SessionData.Site.SiteId))
            //    using (TList<JXTPortal.Entities.SiteLocation> backupsitelocations = SiteLocationService.GetBySiteId(SessionData.Site.SiteId))
            //    {
            //        SiteAreaService.Delete(backupsiteareas);
            //        SiteLocationService.Delete(backupsitelocations);

            //        foreach (TreeNode locationnode in TreeView2.Nodes)
            //        {
            //            if (locationnode.Checked)
            //            {
            //                locations.Filter = string.Format("LocationID = {0}", locationnode.Value);

            //                using (JXTPortal.Entities.Location location = locations[0])
            //                using (JXTPortal.Entities.SiteLocation sitelocation = new JXTPortal.Entities.SiteLocation())
            //                {
            //                    sitelocation.SiteId = SessionData.Site.SiteId;
            //                    sitelocation.SiteLocationName = locationnode.Text;
            //                    sitelocation.SiteLocationFriendlyUrl = JXTPortal.Common.Utils.UrlFriendlyName(locationnode.Text);
            //                    sitelocation.LocationId = location.LocationId;
            //                    sitelocation.Valid = locationnode.Checked;

            //                    backupsitelocations.Filter = String.Format("SiteID = {0} AND LocationID = {1}", sitelocation.SiteId, sitelocation.LocationId);
            //                    if (backupsitelocations.Count > 0)
            //                    {
            //                        using (JXTPortal.Entities.SiteLocation backupsitelocation = backupsitelocations[0])
            //                        {
            //                            sitelocation.SiteLocationName = backupsitelocation.SiteLocationName;
            //                            sitelocation.SiteLocationFriendlyUrl = JXTPortal.Common.Utils.UrlFriendlyName(backupsitelocation.SiteLocationName);
            //                        }
            //                    }

            //                    sitelocations.Add(sitelocation);
            //                }

            //                foreach (TreeNode areanode in locationnode.ChildNodes)
            //                {
            //                    if (areanode.Checked)
            //                    {
            //                        areas.Filter = string.Format("AreaID = {0}", areanode.Value);

            //                        using (JXTPortal.Entities.Area area = areas[0])
            //                        using (JXTPortal.Entities.SiteArea sitearea = new JXTPortal.Entities.SiteArea())
            //                        {
            //                            sitearea.SiteId = SessionData.Site.SiteId;
            //                            sitearea.SiteAreaName = areanode.Text;
            //                            sitearea.AreaId = area.AreaId;

            //                            backupsiteareas.Filter = String.Format("SiteID = {0} AND AreaID = {1}", sitearea.SiteId, sitearea.AreaId);
            //                            if (backupsiteareas.Count > 0)
            //                            {
            //                                using (JXTPortal.Entities.SiteArea backupsitearea = backupsiteareas[0])
            //                                {
            //                                    sitearea.SiteAreaName = backupsitearea.SiteAreaName;
            //                                }
            //                            }

            //                            siteareas.Add(sitearea);
            //                        }
            //                    }
            //                }
            //            }
            //        }

            //        SiteLocationService.Insert(sitelocations);
            //        SiteAreaService.Insert(siteareas);
            //    }
            //}

            TreeView1.Nodes.Clear();
            TreeView2.Nodes.Clear();
            LoadTree();
            ltlMessage.Text = "Location & Area allocated successfully.";
        }
        #endregion

        protected void dataCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTree();
        }
    }
}
