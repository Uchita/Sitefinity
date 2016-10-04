	

#region Using Directives
using System;
using System.ComponentModel;
using System.Collections;
using System.Xml.Serialization;
using System.Data;

using JXTPortal.Entities;
using JXTPortal.Entities.Validation;

using JXTPortal.Data;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using JXTPortal.Entities.Models;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Script.Serialization;
using System.Linq;

#endregion

namespace JXTPortal
{		
	/// <summary>
	/// An component type implementation of the 'Integrations' table.
	/// </summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class IntegrationsService : JXTPortal.IntegrationsServiceBase
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the IntegrationsService class.
		/// </summary>
		public IntegrationsService() : base()
		{
		}
		#endregion Constructors

        public AdminIntegrations.Integrations AdminIntegrationsForSiteGet(int siteID)
        {
            //get site's integrations
            TList<Entities.Integrations> siteIntegrations = GetBySiteId(siteID);

            AdminIntegrations.Integrations returnModel = new AdminIntegrations.Integrations();

            foreach (Entities.Integrations thisIntegration in siteIntegrations)
            {
                PortalEnums.SocialMedia.SocialMediaType thisType = (PortalEnums.SocialMedia.SocialMediaType) thisIntegration.IntegrationType;

                JavaScriptSerializer ser = new JavaScriptSerializer();
                string jsonToDeser = thisIntegration.JsonText;

                switch (thisType)
                {
                    case PortalEnums.SocialMedia.SocialMediaType.Google:
                        AdminIntegrations.Google gg = ser.Deserialize(jsonToDeser, typeof(AdminIntegrations.Google)) as AdminIntegrations.Google;
                        gg.Valid = thisIntegration.Valid;
                        returnModel.Google = gg;
                        break;
                    case PortalEnums.SocialMedia.SocialMediaType.GoogleMap:
                        AdminIntegrations.GoogleMap gm = ser.Deserialize(jsonToDeser, typeof(AdminIntegrations.GoogleMap)) as AdminIntegrations.GoogleMap;
                        gm.Valid = thisIntegration.Valid;
                        returnModel.GoogleMap = gm;
                        break;
                    case PortalEnums.SocialMedia.SocialMediaType.Facebook:
                        AdminIntegrations.Facebook fb = ser.Deserialize(jsonToDeser, typeof(AdminIntegrations.Facebook)) as AdminIntegrations.Facebook;
                        fb.Valid = thisIntegration.Valid;
                        returnModel.Facebook = fb;
                        break;
                    //case PortalEnums.SocialMedia.SocialMediaType.Twitter:
                    //    AdminIntegrations.Twitter tt = ser.Deserialize(jsonToDeser, typeof(AdminIntegrations.Twitter)) as AdminIntegrations.Twitter;
                    //    tt.Valid = thisIntegration.Valid;
                    //    returnModel.Twitter = tt;
                    //    break;
                    case PortalEnums.SocialMedia.SocialMediaType.LinkedIn:
                        break;
                    case PortalEnums.SocialMedia.SocialMediaType.Indeed:
                        AdminIntegrations.Indeed id = ser.Deserialize(jsonToDeser, typeof(AdminIntegrations.Indeed)) as AdminIntegrations.Indeed;
                        id.Valid = thisIntegration.Valid;
                        returnModel.Indeed = id;

                        break;
                    case PortalEnums.SocialMedia.SocialMediaType.Seek:
                        AdminIntegrations.Seek sk = ser.Deserialize(jsonToDeser, typeof(AdminIntegrations.Seek)) as AdminIntegrations.Seek;
                        sk.Valid = thisIntegration.Valid;
                        returnModel.Seek = sk;
                        break;
                    case PortalEnums.SocialMedia.SocialMediaType.Dropbox:
                        AdminIntegrations.Dropbox db = ser.Deserialize(jsonToDeser, typeof(AdminIntegrations.Dropbox)) as AdminIntegrations.Dropbox;
                        db.Valid = thisIntegration.Valid;
                        returnModel.Dropbox = db;
                        break;

                    case PortalEnums.SocialMedia.SocialMediaType.GoogleDrive:
                        AdminIntegrations.GoogleDrive gd = ser.Deserialize(jsonToDeser, typeof(AdminIntegrations.GoogleDrive)) as AdminIntegrations.GoogleDrive;
                        gd.Valid = thisIntegration.Valid;
                        returnModel.GoogleDrive = gd;
                        break;

                    case PortalEnums.SocialMedia.SocialMediaType.Salesforce:
                        AdminIntegrations.Salesforce sf = ser.Deserialize(jsonToDeser, typeof(AdminIntegrations.Salesforce)) as AdminIntegrations.Salesforce;
                        sf.Valid = thisIntegration.Valid;
                        returnModel.Salesforce = sf;
                        break;

                    case PortalEnums.SocialMedia.SocialMediaType.Bullhorn:
                        AdminIntegrations.Bullhorn bh = ser.Deserialize(jsonToDeser, typeof(AdminIntegrations.Bullhorn)) as AdminIntegrations.Bullhorn;
                        bh.Valid = thisIntegration.Valid;
                        returnModel.Bullhorn = bh;
                        break;
                    case PortalEnums.SocialMedia.SocialMediaType.BullhornOnBoardingSSO:
                        AdminIntegrations.BullhornOnBoardingSSO bhsso = ser.Deserialize(jsonToDeser, typeof(AdminIntegrations.BullhornOnBoardingSSO)) as AdminIntegrations.BullhornOnBoardingSSO;
                        bhsso.Valid = thisIntegration.Valid;
                        returnModel.BullhornOnBoardingSSO = bhsso;
                        break;
                    default:
                        break;
                }
            }

            return returnModel;
        }

        /// <summary>
        /// Returns all of the site IDs that has a VALID SalesForce integrations credentials
        /// </summary>
        public List<int> AdminAllSalesForceIntegrationsSiteIDGet()
        {
            List<int> results = new List<int>();

            //TODO: optimize
            List<Integrations> allIntegrations = GetAll().Where( c => c.Valid && c.IntegrationType == (int) PortalEnums.SocialMedia.SocialMediaType.Salesforce).ToList();

            JavaScriptSerializer ser = new JavaScriptSerializer();

            foreach (Integrations i in allIntegrations)
            {
                string jsonToDeser = i.JsonText;
                AdminIntegrations.Salesforce sf = ser.Deserialize(jsonToDeser, typeof(AdminIntegrations.Salesforce)) as AdminIntegrations.Salesforce;
                sf.Valid = true;
                results.Add(i.SiteId);
            }

            return results;
        }

        public bool BullhornRESTTokenUpdate(int siteID, string accessToken, string refreshToken)
        {
            Entities.Integrations BHIntegration = GetBySiteId(siteID).Where(c => c.IntegrationType == (int)PortalEnums.SocialMedia.SocialMediaType.Bullhorn).FirstOrDefault();

            if (BHIntegration == null)
                return false;

            string jsonToDeser = BHIntegration.JsonText;
            JavaScriptSerializer ser = new JavaScriptSerializer();
            AdminIntegrations.Bullhorn bh = ser.Deserialize(jsonToDeser, typeof(AdminIntegrations.Bullhorn)) as AdminIntegrations.Bullhorn;

            bh.RESTAuthToken = accessToken;
            bh.RESTAuthRefreshToken = refreshToken;

            string newBH = ser.Serialize(bh);

            BHIntegration.JsonText = newBH;

            base.Update(BHIntegration);

            return true;
        }


	}//End Class

} // end namespace
