using System.Web.UI;
using Telerik.Sitefinity.Web.UI;
using Telerik.Sitefinity.Web.UI.Fields;

namespace JXTNext.Sitefinity.Common.Models.Robots
{
    public class RobotSettings : SimpleView
    {
        #region Properties
        /// <summary>
        /// Obsolete. Use LayoutTemplatePath instead.
        /// </summary>
        protected override string LayoutTemplateName
        {
            get
            {
                return string.Empty;
            }
        }

        protected override HtmlTextWriterTag TagKey
        {
            get
            {
                //we use div wrapper tag to make easier common styling
                return HtmlTextWriterTag.Div;
            }
        }

        /// <summary>
        /// Gets the layout template's relative or virtual path.
        /// </summary>
        public override string LayoutTemplatePath
        {
            get
            {
                if (string.IsNullOrEmpty(base.LayoutTemplatePath))
                    return RobotSettings.layoutTemplatePath;
                return base.LayoutTemplatePath;
            }
            set
            {
                base.LayoutTemplatePath = value;
            }
        }
        #endregion

        
        protected virtual TextField RobotTextData
        {
            get
            {
                return this.Container.GetControl<TextField>("robotTextData", true);
            }
        }
        protected override void InitializeControls(GenericContainer container)
        {
            
        }

        #region Private members & constants
        public static readonly string layoutTemplatePath = "~/Views/Robots/RobotSettings.ascx";
        #endregion
    }
}
