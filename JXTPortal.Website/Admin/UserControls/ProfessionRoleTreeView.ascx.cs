using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JXTPortal.Website.Admin.UserControls
{
    public partial class ProfessionRoleTreeView : System.Web.UI.WebControls.TreeView
    {
        public ProfessionRoleTreeView()
            : base()
        {

        }

        protected override TreeNode CreateNode()
        {
            return new ProfessionRoleTreeNode(this, false);
        }

        public class ProfessionRoleTreeNode : TreeNode
        {
            CheckBox m_pCheckBox = CreateCheckBox();
            private static CheckBox CreateCheckBox()
            {
                CheckBox pCheckBox = new CheckBox();
                pCheckBox.ID = "CheckBox";
                pCheckBox.Enabled = false;
                return pCheckBox;
            }

            public ProfessionRoleTreeNode()
                : base()
            {
            }
            public ProfessionRoleTreeNode(string text)
                : base(text)
            {
            }
            public ProfessionRoleTreeNode(string text, string value)
                : base(text, value)
            {
            }

            protected internal ProfessionRoleTreeNode(TreeView owner, bool isRoot)
                : base(owner, isRoot)
            {
            }

            protected override void RenderPreText(HtmlTextWriter writer)
            {
                base.RenderPreText(writer);
                if (m_pCheckBox != null)
                    m_pCheckBox.RenderControl(writer);
            }

            protected override void RenderPostText(HtmlTextWriter writer)
            {
                writer.Write(' ');
                base.RenderPostText(writer);
            }

            public bool SiteChecked
            {
                get { return m_pCheckBox.Checked; }
                set { m_pCheckBox.Checked = value; }
            }
        }
    }
}