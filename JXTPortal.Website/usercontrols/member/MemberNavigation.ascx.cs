using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JXTPortal.Website.usercontrols.navigation
{
    public partial class MemberNavigation : System.Web.UI.UserControl
    {
        #region Declare Variables

        private int memberID = 0;

        #endregion

        #region "Properties"

        MembersService _membersService;
        MembersService MembersService
        {
            get
            {
                if (_membersService == null)
                {
                    _membersService = new MembersService();
                }
                return _membersService;
            }
        }

        #endregion

        #region Methods

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadForm();
            }

            SetFormValues();

        }

        public void SetFormValues()
        {
            lnkLogout.Text = CommonFunction.GetResourceValue("LabelLogout");
        }


        protected void loadForm()
        {
            if (Entities.SessionData.Member != null && Entities.SessionData.Member.MemberId > 0)
            {
                memberID = Entities.SessionData.Member.MemberId;

                using (Entities.Members objMembers = MembersService.GetByMemberId(memberID))
                {
                    if (objMembers != null)
                    {
                        string tmpfirstname = objMembers.FirstName;
                        if (tmpfirstname == null || tmpfirstname.Length == 0)
                            ltMemberLoginName.Text = objMembers.Username;
                        else
                            ltMemberLoginName.Text = objMembers.FirstName;
                    }
                }
            }
        }

        #endregion

        #region Click Event handlers
        
        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            SessionService.RemoveMember();
            SessionService.SessionAbandon();

            Response.Redirect("~/");
        }

        #endregion
    }
}