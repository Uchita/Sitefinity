using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using JXTPortal.Entities;
using System.Text;

namespace JXTPortal.Website
{
    public partial class ajaxMethods : System.Web.UI.Page
    {

        #region Properties

        private SiteRolesService _siteRolesService;
        private SiteRolesService SiteRolesService
        {
            get
            {
                if (_siteRolesService == null)
                    _siteRolesService = new SiteRolesService();
                return _siteRolesService;
            }
        }

        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
        }

        [WebMethod]
        public static string GetDate()
        {
            System.Threading.Thread.Sleep(2000);
            return DateTime.Now.ToString();
        }

        [WebMethod]
        public static string GetRoles(string ProfessionId)
        {
            int intProfessionId;
            if (int.TryParse(ProfessionId, out intProfessionId) && intProfessionId > 0)
            {

                StringBuilder strSelectHtml = new StringBuilder();
                strSelectHtml.AppendFormat("<div id='divRoleID'><select class='form-dropdown' id=\"{0}\">", "roleIDs");
                SiteRolesService siteRolesService = new SiteRolesService();
                List<Entities.SiteRoles> siteRolesList = siteRolesService.GetTranslatedByProfessionID(intProfessionId);

                strSelectHtml.AppendFormat("<option value=\"-1\" SELECTED>- All SubClassifications -</option>");

                foreach (Entities.SiteRoles siteRole in siteRolesList)
                {
                    if (siteRole.SiteRoleName == "")
                    {
                        strSelectHtml.AppendFormat("<option value=\"{0}\" SELECTED>{1}</option>", siteRole.RoleId.ToString(), siteRole.SiteRoleName);
                    }
                    else
                    {
                        strSelectHtml.AppendFormat("<option value=\"{0}\">{1}</option>", siteRole.RoleId.ToString(), siteRole.SiteRoleName);
                    }
                }
                strSelectHtml.Append("</select></div>");

                return strSelectHtml.ToString();
            }

            return @"<div id='divRoleID'><select class='form-dropdown' id='roleIDs'><option value='-1'>- Select a Classification First -</option></select></div>";
        }
        
        [WebMethod]
        public static string GetLocations(string CountryId, string DefaultLocationID)
        {
            int intCountryId;
            if (int.TryParse(CountryId, out intCountryId) && intCountryId > 0)
            {

                StringBuilder strSelectHtml = new StringBuilder();
                strSelectHtml.AppendFormat("<div id='divLocation'><select class='form-dropdown' id=\"{0}\">", "locationID");
                SiteLocationService siteLocationService = new SiteLocationService();
                List<Entities.SiteLocation> siteLocationList = siteLocationService.GetTranslatedLocations(intCountryId); //intCountryId

                strSelectHtml.AppendFormat("<option value=\"-1\" SELECTED>- All Locations -</option>");

                foreach (Entities.SiteLocation siteLocation in siteLocationList)
                {
                    if (!String.IsNullOrEmpty(DefaultLocationID) && siteLocation.LocationId.ToString() == DefaultLocationID)
                    {
                        strSelectHtml.AppendFormat("<option value=\"{0}\" SELECTED>{1}</option>", siteLocation.LocationId.ToString(), siteLocation.SiteLocationName);
                    }
                    else
                    {
                        strSelectHtml.AppendFormat("<option value=\"{0}\">{1}</option>", siteLocation.LocationId.ToString(), siteLocation.SiteLocationName);
                    }
                }

                strSelectHtml.Append(@"</select></div>
<script>
    $('#locationID').change(function() {
        $('#divArea').html(""<img src='/images/loading.gif' />"");

        var locationID = '';
        $('#locationID option:selected').each(function() {
            locationID += $(this).val();
        });

        $.ajax({
            type: 'POST',
            cache: false,
            url: '/job/ajaxcalls/ajaxmethods.aspx/GetAreas',
            data: ""{'LocationId':"" + locationID + ""}"",
            contentType: ""application/json; charset=utf-8"",
            dataType: ""json"",
            success: function(msg) {
                // Replace the div's content with the page method's return.
                $(""#divArea"").html(msg.d);
            },
            fail: function() {
                // Replace the div's content with the page method's return.
                $(""#divArea"").html(""It didn't work"");
            }
        });

    });
</script>");

                return strSelectHtml.ToString();
            }
            return @"<div id='divLocation'><select class='form-dropdown' id='locationID'><option value='-1'>- Select a Country First -</option></select></div>";
        }

        [WebMethod]
        public static string GetAreas(string LocationId)
        {

            int intLocationId;
            if (int.TryParse(LocationId, out intLocationId) && intLocationId > 0)
            {

                StringBuilder strSelectHtml = new StringBuilder();
                strSelectHtml.AppendFormat("<div id='divArea'><select class='form-dropdown' id=\"{0}\" multiple='multiple' size='4'>", "areaIDs");
                SiteAreaService siteAreaService = new SiteAreaService();
                List<Entities.SiteArea> siteAreaList = siteAreaService.GetTranslatedAreas(intLocationId); //intAreaId

                strSelectHtml.AppendFormat("<option value=\"-1\" SELECTED>- All Areas -</option>");

                foreach (Entities.SiteArea siteArea in siteAreaList)
                {
                    if (siteArea.SiteAreaName == "")
                    {
                        strSelectHtml.AppendFormat("<option value=\"{0}\" SELECTED>{1}</option>", siteArea.AreaId.ToString(), siteArea.SiteAreaName);
                    }
                    else
                    {
                        strSelectHtml.AppendFormat("<option value=\"{0}\">{1}</option>", siteArea.AreaId.ToString(), siteArea.SiteAreaName);
                    }
                }
                strSelectHtml.Append("</select></div>");

                return strSelectHtml.ToString();
            }

            return @"<div id='divArea'><select class='form-dropdown' id='areaIDs' multiple='multiple' size='4'><option value='-1'>- Select a Location First -</option></select></div>";
        }


    }
}
