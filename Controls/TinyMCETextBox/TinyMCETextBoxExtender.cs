using System;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.ComponentModel;
using System.ComponentModel.Design;
using AjaxControlToolkit;


[assembly: System.Web.UI.WebResource("TinyMCETextBox.TinyMCETextBoxBehavior.js", "text/javascript")]

namespace TinyMCETextBox
{
	internal class TinyMCETextBoxContainer : System.Web.UI.Control, INamingContainer
	{

	}

	[ParseChildren(true)]
	[PersistChildren(true)]
	[Designer(typeof(TinyMCETextBoxDesigner))]
	[ClientScriptResource("TinyMCETextBox.TinyMCETextBoxBehavior", "TinyMCETextBox.TinyMCETextBoxBehavior.js")]
	[TargetControlType(typeof(TextBox))]
	public class TinyMCETextBoxExtender : ExtenderControlBase, INamingContainer
	{
		protected override void OnLoad(EventArgs e)
		{
			// ** load scripts
			if (Page.Items["tinymce"] == null)
			{
				HtmlGenericControl Include = new HtmlGenericControl("script");
				Include.Attributes.Add("type", "text/javascript");
				Include.Attributes.Add("src", Page.ResolveUrl("~/tinymce/tiny_mce.js"));
				this.Page.Header.Controls.Add(Include);
				Page.Items["tinymce"] = true;

				// ** write triggerSave script
				if (!Page.ClientScript.IsOnSubmitStatementRegistered(this.GetType(), "tinymcetriggersave"))
				{
					Page.ClientScript.RegisterOnSubmitStatement(this.GetType(), "tinymcetriggersave", "tinyMCE.triggerSave(false,true);");
				}
			}

			string sInitName = String.Format("{0}_init", (SkinID.Equals(String.Empty) ? ClientID : SkinID));
			if (Page.Items[sInitName] == null)
			{
				string selectorName = String.Format("{0}_class", sInitName);
				if (TargetControl != null)
				{

					if (TargetControl is WebControl)
					{
						((WebControl)TargetControl).CssClass = selectorName;
					}
				}

				// ** create tinymce init script
				InitOptions.Add("mode", "textareas");
				InitOptions.Add("theme", Theme.ToString().ToLower());
				InitOptions.Add("editor_selector", selectorName);

				System.Text.StringBuilder sbOptions = new System.Text.StringBuilder();
				foreach (string sKey in InitOptions.Keys)
					sbOptions.Append(String.Format("{0} : '{1}', ", sKey, InitOptions[sKey]));

				foreach (TinyMCETextBoxInit init in this.InitList)
					sbOptions.Append(String.Format("{0} : '{1}', ", init.Var.ToString(), init.Value.ToLower().ToString()));

				string opts = sbOptions.ToString().Substring(0, sbOptions.ToString().Length - 2);
				InitOpts = opts; // options after postback (retrieved by client)

				System.Text.StringBuilder sb = new System.Text.StringBuilder();
				sb.Append("tinyMCE.init({");
				sb.Append(opts);
				sb.Append("});");


				// ** write tinymce init script
				HtmlGenericControl Include2 = new HtmlGenericControl("script");
				Include2.Attributes.Add("type", "text/javascript");
				Include2.InnerHtml = sb.ToString();
				this.Page.Header.Controls.Add(Include2);

				Page.Items[sInitName] = true;
			}
			EnsureChildControls();
			base.OnLoad(e);
		}

		private TinyMCETextBoxInitList __InitList;
		[
		Browsable(false),
		DefaultValue(null),
		Description("The Init List."),
		PersistenceMode(PersistenceMode.InnerProperty),
		TemplateInstance(TemplateInstance.Single),
		]
		public TinyMCETextBoxInitList InitList
		{
			get
			{
				if (__InitList == null)
				{
					__InitList = new TinyMCETextBoxInitList();
				}
				return __InitList;
			}
			set
			{
				__InitList = value;
			}
		}

		private System.Collections.Generic.Dictionary<string, string> __InitOptions;
		protected System.Collections.Generic.Dictionary<string, string> InitOptions
		{
			get
			{
				if (__InitOptions == null) __InitOptions = new System.Collections.Generic.Dictionary<string, string>();
				return __InitOptions;
			}
			set { __InitOptions = value; }
		}

		[ExtenderControlProperty]
		[Category("Behavior")]
		public string InitOpts
		{
			get { return GetPropertyValue("InitOpts", ""); }
			set { SetPropertyValue("InitOpts", value); }
		}

		private TinyMCETheme __Theme = TinyMCETheme.Simple;
		public TinyMCETheme Theme
		{
			get { return __Theme; }
			set { __Theme = value; }
		}
	}
}
