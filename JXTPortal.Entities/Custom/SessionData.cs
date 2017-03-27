using System;
using System.Web;

namespace JXTPortal.Entities
{
    [Serializable]
    public static class SessionData
    {
        public static SessionSite Site
        {
            get
            {
                if (HttpContext.Current == null || HttpContext.Current.Session == null)
                {
                    return null;
                }

                if (HttpContext.Current.Session[PortalConstants.Session.SessionSite] != null)
                {
                    return (SessionSite)HttpContext.Current.Session[PortalConstants.Session.SessionSite];
                }

                return null;
            }
        }

        public static SessionAdminUser AdminUser
        {
            get
            {
                if (HttpContext.Current.Session[PortalConstants.Session.SessionAdminUser] != null)
                {
                    return (SessionAdminUser)HttpContext.Current.Session[PortalConstants.Session.SessionAdminUser];
                }
                else
                {
                    return null;
                }
            }
        }

        public static SessionAdvertiserUser AdvertiserUser
        {
            get
            {
                if (HttpContext.Current.Session[PortalConstants.Session.SessionAdvertiserUser] != null)
                {
                    return (SessionAdvertiserUser)HttpContext.Current.Session[PortalConstants.Session.SessionAdvertiserUser];
                }
                else
                {
                    return null;
                }
            }
        }

        public static SessionMember Member
        {
            get
            {
                if (HttpContext.Current.Session[PortalConstants.Session.SessionMember] != null)
                {
                    return (SessionMember)HttpContext.Current.Session[PortalConstants.Session.SessionMember];
                }
                else
                {
                    return null;
                }
            }
        }

        public static Languages Language
        {
            get
            {
                if (HttpContext.Current.Session[PortalConstants.Session.SessionLanguage] != null)
                {
                    return (Languages)HttpContext.Current.Session[PortalConstants.Session.SessionLanguage];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                HttpContext.Current.Session[PortalConstants.Session.SessionLanguage] = value;
            }
        }

        public static JobSearch JobSearch
        {
            get
            {
                if (HttpContext.Current.Session[PortalConstants.Session.SessionJobSearch] != null)
                {
                    return (JobSearch)HttpContext.Current.Session[PortalConstants.Session.SessionJobSearch];
                }
                else
                {
                    // Instead of returning null it returns a Empty JobSearch 
                    JobSearch jobSearch = new JobSearch();
                    HttpContext.Current.Session[PortalConstants.Session.SessionJobSearch] = jobSearch;

                    return (JobSearch)HttpContext.Current.Session[PortalConstants.Session.SessionJobSearch];
                }
            }
        }

        public static WebServiceSearch WebServiceSearch
        {
            get
            {
                if (HttpContext.Current.Session[PortalConstants.Session.SessionWebServiceSearch] != null)
                {
                    return (WebServiceSearch)HttpContext.Current.Session[PortalConstants.Session.SessionWebServiceSearch];
                }
                else
                {
                    // Instead of returning null it returns a Empty JobSearch 
                    WebServiceSearch webwervicesearch = new WebServiceSearch();
                    HttpContext.Current.Session[PortalConstants.Session.SessionWebServiceSearch] = webwervicesearch;

                    return (WebServiceSearch)HttpContext.Current.Session[PortalConstants.Session.SessionWebServiceSearch];
                }
            }
        }
        
    }
}
