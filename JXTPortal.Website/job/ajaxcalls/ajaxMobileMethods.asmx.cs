using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using JXTPortal.Entities;

namespace JXTPortal.Website.job.ajaxcalls
{
    /// <summary>
    /// Summary description for ajaxMobileMethods
    /// </summary>
    [WebService(Namespace = "http://www.jobx.com.au/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ajaxMobileMethods : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        public string GetProfessions()
        {
            string result = string.Empty;
            SiteProfessionService service = new SiteProfessionService();
            List<Entities.SiteProfession> siteProfessionList = service.GetTranslatedProfessions(false, SessionData.Site.UseCustomProfessionRole);

            foreach (Entities.SiteProfession sp in siteProfessionList)
            {
                result += string.Format("<option value='{0}'>{1}</option>", sp.ProfessionId, sp.SiteProfessionName);
            }

            return result;
        }
    }
}
