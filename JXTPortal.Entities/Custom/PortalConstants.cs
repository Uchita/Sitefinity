using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JXTPortal.Entities
{
    public class PortalConstants
    {
        public class Session
        {
            public const string SessionAdminUser = "SessionAdminUser";

            public const string SessionAdvertiserUser = "SessionAdvertiserUser";

            public const string SessionMember = "SessionMember";

            public const string SessionSite = "SessionSite";

            public const string SessionLanguage = "SessionLanguage";

            public const string SessionJobSearch = "SessionJobSearch";

            public const string SessionWebServiceSearch = "SessionWebServiceSearch";

            public const string SessionMemberRegistrationNotification = "SessionMemberRegistrationNotification";


            // Custom Job Application Form Session
            public const string SESSION_FORMDATA_KEY = "CustomJobApplicationData"; // Per site job application so session per site is good.
        }

        public class SiteCookie
        {
            public const string AdvertiserUserCookie = "a";

            public const string MemberCookie = "m";
        }

        // Thumbnail Dimensions
        public const int THUMBNAIL_WIDTH = 200;
        public const int THUMBNAIL_HEIGHT = 100;

        //default language ID /English language TODO: to confirm
        public const int DEFAULT_LANGUAGE_ID = 1;
        public const int DEFAULT_EMAIL_LANGUAGE_ID = 1;

        public class XMLTranslationFiles
        {
            // Multilingual XML File name prefixes
            public const string XML_PROFESSION_FILENAME = "profession";
            public const string XML_ROLE_FILENAME = "roles";
            public const string XML_CUSTOMPROFESSION_FILENAME = "custom_profession";
            public const string XML_CUSTOMROLE_FILENAME = "custom_roles";
            public const string XML_COUNTRY_FILENAME = "country";
            public const string XML_LOCATION_FILENAME = "location";
            public const string XML_AREA_FILENAME = "area";
            public const string XML_SALARY_FILENAME = "salary";
            public const string XML_WORKTYPE_FILENAME = "worktype";
            public const string XML_AVAILABLESTATUS_FILENAME = "availablestatus";
            public const string XML_EDUCATIONS_FILENAME = "educations";
            public const string XML_ADVERTISERACCOUNTTYPE_FILENAME = "advertiseraccounttype";
            public const string XML_ADVERTISERBUSINESSTYPE_FILENAME = "advertiserbusinesstype";
            public const string XML_SITECOUNTRY_FILENAME = "sitecountry";
            public const string XML_SITELOCATION_FILENAME = "sitelocation";
            public const string XML_SITEAREA_FILENAME = "sitearea";
        }

        /// <summary>
        /// Dynamic Navigation
        /// </summary>
        public class DynamicNavigation
        {
            //sf-menu
            //class="sf-menu sf-vertical"
            //class="sf-menu sf-navbar"

            /// <summary>
            /// Top Navigation
            /// </summary>
            public const string TOP_DEFAULT_MENU = "[[top-default]]";
            public const string TOP_VERTICAL_MENU = "[[top-vertical]]";
            public const string TOP_NAVBAR_MENU = "[[top-navbar]]";

            /// <summary>
            /// Left Navigation
            /// </summary>
            public const string LEFT_DEFAULT_MENU = "[[left-default]]";
            public const string LEFT_VERTICAL_MENU = "[[left-vertical]]";
            public const string LEFT_NAVBAR_MENU = "[[left-navbar]]";

            /// <summary>
            /// Footer Navigation
            /// </summary>
            public const string FOOTER_DEFAULT_MENU = "[[footer-default]]";

            /// <summary>
            /// Dynamic Left Navigation
            /// </summary>
            public const string DYNAMIC_NAVIGATION = "[[dynamic-navigation]]";
            public const string RELATED_PAGES = "[[related-pages]]";

            public const string WEBPART_BREADCRUMB = "[[webpart-breadcrumb]]";
            public const string DYNAMIC_BREAD = "[[dynamic-bread]]";

            // Custom Widget
            public const string CUSTOM_WIDGET_GROUP_LEFT = "[[custom-widget-group-left]]";
            public const string CUSTOM_WIDGET_GROUP_RIGHT = "[[custom-widget-group-right]]";

            // Member Sign In / Out
            public const string MEMBER_SIGNIN_SIGNOUT = "[[member-status]]";

            // Member Dashboard
            public const string MEMBER_DASHBOARD = "[[member-status-dashboard]]";

            // Member Dashboard Widgets
            public const string MEMBER_DASHBOARD_SAVEDJOBS = "[[member-dashboard-savedjobs]]";
            public const string MEMBER_DASHBOARD_APPLICATIONTRACKER = "[[member-dashboard-applicationtracker]]";
            public const string MEMBER_DASHBOARD_JOBALERTS = "[[member-dashboard-jobalerts]]";
            public const string MEMBER_DASHBOARD_FAVOURITESEARCHES = "[[member-dashboard-favsearches]]";

            public const string MEMBER_DASHBOARD_FIRSTNAME = "[[member-dashboard-firstname]]";
            public const string MEMBER_DASHBOARD_LASTNAME = "[[member-dashboard-lastname]]";
            public const string MEMBER_DASHBOARD_PROFILEPICTURE = "[[member-dashboard-profile-picture]]";
            public const string MEMBER_DASHBOARD_LASTMODIFIED = "[[member-dashboard-lastmodified]]";

            // Dynamic Login Status Display
            public const string USER_LOGINSTATUS_NO_MENU = "[[user-loginstatus-no-menu]]";
            public const string USER_LOGINSTATUS_WITH_MENU = "[[user-loginstatus-with-menu]]";

            // Member Results Counters
            public const string MEMBER_COUNTER_SAVED_JOBS = "[[member-savedjobs-count]]";
            public const string MEMBER_COUNTER_JOB_APPLICATIONS = "[[member-applicationtracker-count]]";
            public const string MEMBER_COUNTER_FAVOURITE_SEARCHES = "[[member-favsearches-count]]";

            // CLIENT SPECIFIC SHORTCODES
            // WeVideo
            public const string MEMBER_WEVIDEO_VIDEO_PROFILE = "[[member-wevideo-video-profile]]";
            // Bullhorn OnBoarding SSO
            public const string MEMBER_BULLHORN_ONBOARDING_SSO_LINK = "[[member-bullhorn-onboarding-sso-link]]";


            // ADVERTISER Dashboard
            public const string ADVERTISER_DASHBOARD_DROPDOWN_LINKS = "[[advertiser-dashboard-dropdown-links]]";
            public const string ADVERTISER_DASHBOARD_AVAILABLE_CREDITS = "[[advertiser-dashboard-available-credits]]";
            public const string ADVERTISER_DASHBOARD_CURRENT_JOBS = "[[advertiser-dashboard-currentjobs]]";
            public const string ADVERTISER_DASHBOARD_JOB_TRACKER = "[[advertiser-dashboard-jobtracker]]";
            public const string ADVERTISER_DASHBOARD_DRAFT_JOBS = "[[advertiser-dashboard-draft]]";
            public const string ADVERTISER_DASHBOARD_ARCHIVED = "[[advertiser-dashboard-archived]]";
            public const string ADVERTISER_DASHBOARD_STATISTICS = "[[advertiser-dashboard-statistics]]";
            public const string ADVERTISER_DASHBOARD_SUSPENDED_JOBS = "[[advertiser-dashboard-suspended]]";

            //Advertiser Profile
            public const string ADVERTISER_DASHBOARD_FIRSTNAME = "[[advertiser-dashboard-firstname]]";
            public const string ADVERTISER_DASHBOARD_LASTNAME = "[[advertiser-dashboard-lastname]]";
            public const string ADVERTISER_DASHBOARD_PROFILEPICTURE = "[[advertiser-dashboard-profile-picture]]";
            public const string ADVERTISER_DASHBOARD_LASTMODIFIED = "[[advertiser-dashboard-lastmodified]]";

        }

        public class ConsultantData
        {
            public const string CONSULTANT_CONSULTANTID = "[[consultant-consultantid]]";
            public const string CONSULTANT_SITEID = "[[consultant-siteid]]";
            public const string CONSULTANT_TITLE = "[[consultant-title]]";
            public const string CONSULTANT_FIRSTNAME = "[[consultant-firstname]]";
            public const string CONSULTANT_LASTNAME = "[[consultant-lastname]]";
            public const string CONSULTANT_EMAIL = "[[consultant-email]]";
            public const string CONSULTANT_PHONE = "[[consultant-phone]]";
            public const string CONSULTANT_MOBILE = "[[consultant-mobile]]";
            public const string CONSULTANT_POSITIONTITLE = "[[consultant-positiontitle]]";
            public const string CONSULTANT_OFFICELOCATION = "[[consultant-officelocation]]";
            public const string CONSULTANT_CATEGORIES = "[[consultant-categories]]";
            public const string CONSULTANT_LOCATION = "[[consultant-location]]";
            public const string CONSULTANT_FRIENDLYURL = "[[consultant-friendlyurl]]";
            public const string CONSULTANT_SHORTDESCRIPTION = "[[consultant-shortdescription]]";
            public const string CONSULTANT_TESTIMONIAL = "[[consultant-testimonial]]";
            public const string CONSULTANT_FULLDESCRIPTION = "[[consultant-fulldescription]]";
            public const string CONSULTANT_LINKEDINURL = "[[consultant-linkedinurl]]";
            public const string CONSULTANT_TWITTERURL = "[[consultant-twitterurl]]";
            public const string CONSULTANT_FACEBOOKURL = "[[consultant-facebookurl]]";
            public const string CONSULTANT_GOOGLEURL = "[[consultant-googleurl]]";
            public const string CONSULTANT_LINK = "[[consultant-link]]";
            public const string CONSULTANT_WECHATURL = "[[consultant-wechaturl]]";
            public const string CONSULTANT_FEATUREDTEAMMEMBER = "[[consultant-featuredteammeber]]";
            public const string CONSULTANT_IMAGEURL = "[[consultant-imageurl]]";
            public const string CONSULTANT_VIDEOURL = "[[consultant-videourl]]";
            public const string CONSULTANT_BLOGRSS = "[[consultant-blogrss]]";
            public const string CONSULTANT_NEWSRSS = "[[consultant-newsrss]]";
            public const string CONSULTANT_JOBRSS = "[[consultant-jobrss]]";
            public const string CONSULTANT_TESTIMONIALSRSS = "[[consultant-testimonialsrss]]";
            public const string CONSULTANT_VALID = "[[consultant-status]]";
            public const string CONSULTANT_METATITLE = "[[consultant-metatitle]]";
            public const string CONSULTANT_METADESCRIPTION = "[[consultant-metadescription]]";
            public const string CONSULTANT_METAKEYWORDS = "[[consultant-metakeywords]]";
            public const string CONSULTANT_LASTMODIFIEDBY = "[[consultant-lastmodifiedby]]";
            public const string CONSULTANT_LASTMODIFIED = "[[consultant-lastmodified]]";
            public const string CONSULTANT_SEQUENCE = "[[consultant-sequence]]";
        }

        public const string LANGUAGE_MENU = "[[languages]]";

        public class WebConfigurationKeys
        {
            public const string WEBSITEURLPOSTFIX = "WebsiteUrlPostfix";
        }
    }
}
