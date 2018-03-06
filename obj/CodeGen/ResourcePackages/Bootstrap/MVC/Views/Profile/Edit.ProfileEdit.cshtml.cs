#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SitefinityWebApp.ResourcePackages.Bootstrap.MVC.Views.Profile
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    
    #line 3 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
    using Telerik.Sitefinity.Frontend.Mvc.Helpers;
    
    #line default
    #line hidden
    
    #line 4 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
    using Telerik.Sitefinity.Modules.Pages;
    
    #line default
    #line hidden
    
    #line 7 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
    using Telerik.Sitefinity.Services;
    
    #line default
    #line hidden
    
    #line 5 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
    using Telerik.Sitefinity.UI.MVC;
    
    #line default
    #line hidden
    
    #line 6 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
    using Telerik.Sitefinity.Utilities;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/ResourcePackages/Bootstrap/MVC/Views/Profile/Edit.ProfileEdit.cshtml")]
    public partial class Edit_ProfileEdit : System.Web.Mvc.WebViewPage<Telerik.Sitefinity.Frontend.Identity.Mvc.Models.Profile.ProfileEditViewModel>
    {
        public Edit_ProfileEdit()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 9 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
Write(Html.Script(ScriptRef.JQuery, "top"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 10 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
Write(Html.Script("//ajax.aspnetcdn.com/ajax/jquery.validate/1.8.1/jquery.validate.js", "top"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 11 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
Write(Html.Script("//ajax.aspnetcdn.com/ajax/mvc/4.0/jquery.validate.unobtrusive.min.js", "top"));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<div");

WriteAttribute("class", Tuple.Create(" class=\"", 519), Tuple.Create("\"", 542)
            
            #line 13 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
, Tuple.Create(Tuple.Create("", 527), Tuple.Create<System.Object, System.Int32>(Model.CssClass
            
            #line default
            #line hidden
, 527), false)
);

WriteLiteral(">\r\n\r\n\t<h3>");

            
            #line 15 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
   Write(Html.Resource("EditProfileLink"));

            
            #line default
            #line hidden
WriteLiteral("</h3>\r\n\r\n");

            
            #line 17 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
    
            
            #line default
            #line hidden
            
            #line 17 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
     if (Model.ShowProfileChangedMsg)
    {

            
            #line default
            #line hidden
WriteLiteral("        <div");

WriteLiteral(" class=\"alert alert-success\"");

WriteLiteral(">");

            
            #line 19 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
                                    Write(Html.Resource("ChangesAreSaved"));

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n");

            
            #line 20 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 22 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
    
            
            #line default
            #line hidden
            
            #line 22 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
     using (Html.BeginFormSitefinity("Index", "EditProfileForm", FormMethod.Post, new { enctype = "multipart/form-data" }))
    {
        

            
            #line default
            #line hidden
WriteLiteral("    <div");

WriteLiteral(" class=\"media sf-profile\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"media-left sf-pr-xl\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 27 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
       Write(Html.HiddenFor(u => u.DeletePicture, new Dictionary<string, object>() { { "data-sf-role", "edit-profile-delete-picture" } }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("            ");

            
            #line 28 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
       Write(Html.HiddenFor(u => u.DefaultAvatarUrl, new Dictionary<string, object>() { { "data-sf-role", "edit-profile-default-avatar-url" } }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"media-object\"");

WriteLiteral(">\r\n            \t<div");

WriteLiteral(" class=\"sf-profile-avatar\"");

WriteLiteral(">\r\n\t                <img");

WriteLiteral(" data-sf-role=\"edit-profile-user-image\"");

WriteAttribute("src", Tuple.Create(" src=\"", 1384), Tuple.Create("\"", 1411)
            
            #line 31 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
, Tuple.Create(Tuple.Create("", 1390), Tuple.Create<System.Object, System.Int32>(Model.AvatarImageUrl
            
            #line default
            #line hidden
, 1390), false)
);

WriteAttribute("alt", Tuple.Create(" alt=\"", 1412), Tuple.Create("\"", 1433)
            
            #line 31 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
                 , Tuple.Create(Tuple.Create("", 1418), Tuple.Create<System.Object, System.Int32>(Model.UserName
            
            #line default
            #line hidden
, 1418), false)
);

WriteLiteral(" width=\"100\"");

WriteLiteral(" height=\"100\"");

WriteLiteral("/>\r\n\t                ");

WriteLiteral("\r\n\t            </div>\r\n\r\n\t            <div>\r\n\t                <input");

WriteLiteral(" type=\"file\"");

WriteLiteral(" data-sf-role=\"edit-profile-upload-picture-input\"");

WriteLiteral(" name=\"UploadedImage\"");

WriteLiteral(" style=\"display: none;\"");

WriteLiteral(" />\r\n\t                <a");

WriteLiteral(" href=\"javascript:void(0)\"");

WriteLiteral(" data-sf-role=\"edit-profile-upload-picture-button\"");

WriteLiteral(">");

            
            #line 37 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
                                                                                              Write(Html.Resource("EditProfileUploadImage"));

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n\t            </div>\r\n            </div>\r\n\r\n        </div> \r\n\t\t\r\n        <di" +
"v");

WriteLiteral(" class=\"media-body\"");

WriteLiteral(">\r\n");

            
            #line 44 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
             
            
            #line default
            #line hidden
            
            #line 44 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
              if (!string.IsNullOrEmpty(ViewBag.ErrorMessage))
            {


            
            #line default
            #line hidden
WriteLiteral("                <div");

WriteLiteral(" class=\"alert alert-danger\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 48 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
               Write(ViewBag.ErrorMessage);

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n");

            
            #line 50 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"

            }

            
            #line default
            #line hidden
WriteLiteral("            <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                <label>\r\n");

WriteLiteral("                    ");

            
            #line 54 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
               Write(Html.Resource("EditProfileFirstName"));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </label>\r\n");

WriteLiteral("                ");

            
            #line 56 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
           Write(Html.TextBoxFor(u => u.Profile["FirstName"], new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                \r\n");

            
            #line 58 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
                
            
            #line default
            #line hidden
            
            #line 58 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
                 if (Html.ValidationMessageFor(u => u.Profile["FirstName"]) != null)
                {

            
            #line default
            #line hidden
WriteLiteral("                    <div");

WriteLiteral(" class=\"has-error\"");

WriteLiteral(">\r\n                        <span");

WriteLiteral(" class=\"help-block\"");

WriteLiteral(">");

            
            #line 61 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
                                            Write(Html.ValidationMessageFor(u => u.Profile["FirstName"]));

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n                    </div>\r\n");

            
            #line 63 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
                } 

            
            #line default
            #line hidden
WriteLiteral("            </div>\r\n        \r\n            <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                <label>\r\n");

WriteLiteral("                    ");

            
            #line 68 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
               Write(Html.Resource("EditProfileLastName"));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </label>\r\n");

WriteLiteral("                ");

            
            #line 70 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
           Write(Html.TextBoxFor(u => u.Profile["LastName"], new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                \r\n");

            
            #line 72 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
                
            
            #line default
            #line hidden
            
            #line 72 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
                 if (Html.ValidationMessageFor(u => u.Profile["LastName"]) != null)
                {

            
            #line default
            #line hidden
WriteLiteral("                    <div");

WriteLiteral(" class=\"has-error\"");

WriteLiteral(">\r\n                        <span");

WriteLiteral(" class=\"help-block\"");

WriteLiteral(">");

            
            #line 75 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
                                            Write(Html.ValidationMessageFor(u => u.Profile["LastName"]));

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n                    </div>\r\n");

            
            #line 77 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
                } 

            
            #line default
            #line hidden
WriteLiteral("            </div>\t\t\r\n\t\t\t\r\n            <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                <label>\r\n");

WriteLiteral("                    ");

            
            #line 82 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
               Write(Html.Resource("EditProfileNickname"));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </label>\r\n");

WriteLiteral("                ");

            
            #line 84 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
           Write(Html.TextBoxFor(u => u.Profile["Nickname"], new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                \r\n");

            
            #line 86 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
                
            
            #line default
            #line hidden
            
            #line 86 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
                 if (Html.ValidationMessageFor(u => u.Profile["Nickname"]) != null)
                {

            
            #line default
            #line hidden
WriteLiteral("                    <div");

WriteLiteral(" class=\"has-error\"");

WriteLiteral(">\r\n                        <span");

WriteLiteral(" class=\"help-block\"");

WriteLiteral(">");

            
            #line 89 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
                                            Write(Html.ValidationMessageFor(u => u.Profile["Nickname"]));

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n                    </div>\r\n");

            
            #line 91 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
                } 

            
            #line default
            #line hidden
WriteLiteral("            </div>\r\n\r\n            <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                <label>\r\n");

WriteLiteral("                    ");

            
            #line 96 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
               Write(Html.Resource("EditProfileAbout"));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </label>\r\n");

WriteLiteral("               ");

            
            #line 98 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
          Write(Html.TextAreaFor(u => u.Profile["About"], new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n            </div>\r\n        \r\n\t\t\r\n");

            
            #line 103 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
		    
            
            #line default
            #line hidden
            
            #line 103 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
             if (string.IsNullOrEmpty(Model.ExternalProviderName))
			{

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t<div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n\t\t\t\t\t<label>\r\n");

WriteLiteral("\t\t\t\t\t\t");

            
            #line 107 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
                   Write(Html.Resource("EditProfileEmail"));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t</label>\r\n");

WriteLiteral("\t\t\t\t\t");

            
            #line 109 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
               Write(Html.TextBoxFor(u => u.Email, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\r\n");

            
            #line 111 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
					
            
            #line default
            #line hidden
            
            #line 111 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
                     if (Html.ValidationMessageFor(u => u.Email) != null)
					{

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t\t\t<div");

WriteLiteral(" class=\"has-error\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t<span");

WriteLiteral(" class=\"help-block\"");

WriteLiteral(">");

            
            #line 114 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
                                                Write(Html.ValidationMessageFor(u => u.Email));

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n\t\t\t\t\t\t</div>\r\n");

            
            #line 116 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
					} 

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t</div>\r\n");

            
            #line 118 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
				

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t<div");

WriteLiteral(" class=\"sf-mb-xl\"");

WriteLiteral("><a");

WriteLiteral(" href=\"#\"");

WriteLiteral(" data-sf-role=\"edit-profile-change-password-button\"");

WriteLiteral(">");

            
            #line 119 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
                                                                                                Write(Html.Resource("EditProfileChangePasswordButton"));

            
            #line default
            #line hidden
WriteLiteral("</a></div>\r\n");

            
            #line 120 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"


            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t<div");

WriteLiteral(" data-sf-role=\"edit-profile-change-password-holder\"");

WriteLiteral(" style=\"display:none\"");

WriteLiteral(">\r\n\r\n\t\t\t\t\t<h4>");

            
            #line 123 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
                   Write(Html.Resource("EditProfileEditChangePasswordHeader"));

            
            #line default
            #line hidden
WriteLiteral("</h4>\r\n\t\t\t\t\r\n\t\t\t\t\t<div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n\t\t\t\t\t\t<label>\r\n");

WriteLiteral("\t\t\t\t\t\t\t");

            
            #line 127 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
                       Write(Html.Resource("EditProfileOldPassword"));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\t</label>\r\n\r\n");

WriteLiteral("\t\t\t\t\t\t");

            
            #line 130 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
                   Write(Html.PasswordFor(u => u.OldPassword, new { @class = "form-control", autocomplete = "off" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

            
            #line 132 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
						
            
            #line default
            #line hidden
            
            #line 132 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
                         if (Html.ValidationMessageFor(u => u.OldPassword) != null)
						{

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"has-error\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t\t<span");

WriteLiteral(" class=\"help-block\"");

WriteLiteral(">");

            
            #line 135 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
                                                    Write(Html.ValidationMessageFor(u => u.OldPassword));

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n\t\t\t\t\t\t\t</div>\r\n");

            
            #line 137 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
						} 

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t\t</div>\r\n\r\n\t\t\t\t\t<div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n\t\t\t\t\t\t<label>\r\n");

WriteLiteral("\t\t\t\t\t\t\t");

            
            #line 142 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
                       Write(Html.Resource("EditProfileNewPassword"));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\t</label>\r\n");

WriteLiteral("\t\t\t\t\t\t");

            
            #line 144 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
                   Write(Html.PasswordFor(u => u.NewPassword, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

            
            #line 146 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
						
            
            #line default
            #line hidden
            
            #line 146 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
                         if (Html.ValidationMessageFor(u => u.NewPassword) != null)
						{

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"has-error\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t\t<span");

WriteLiteral(" class=\"help-block\"");

WriteLiteral(">");

            
            #line 149 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
                                                    Write(Html.ValidationMessageFor(u => u.NewPassword));

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n\t\t\t\t\t\t\t</div>\r\n");

            
            #line 151 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
						} 

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t\t</div>\r\n\r\n\t\t\t\t\t<div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n\t\t\t\t\t\t<label>\r\n");

WriteLiteral("\t\t\t\t\t\t\t");

            
            #line 156 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
                       Write(Html.Resource("EditProfileRepeatPassword"));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\t</label>\r\n");

WriteLiteral("\t\t\t\t\t\t");

            
            #line 158 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
                   Write(Html.PasswordFor(u => u.RepeatPassword, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\t\r\n");

            
            #line 160 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
						
            
            #line default
            #line hidden
            
            #line 160 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
                         if (Html.ValidationMessageFor(u => u.RepeatPassword) != null)
						{

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"has-error\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t\t<span");

WriteLiteral(" class=\"help-block\"");

WriteLiteral(">");

            
            #line 163 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
                                                    Write(Html.ValidationMessageFor(u => u.RepeatPassword));

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n\t\t\t\t\t\t\t</div>\r\n");

            
            #line 165 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
						} 

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t\t</div>\r\n\t\t\t\t</div>\r\n");

            
            #line 168 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
			}
			else
			{

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t<h4>");

            
            #line 171 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
               Write(string.Format(Html.Resource("RegistratedWithExternal"), Model.ExternalProviderName));

            
            #line default
            #line hidden
WriteLiteral("</h4>\r\n");

            
            #line 172 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
			

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t<div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n\t\t\t\t\t<label>\r\n");

WriteLiteral("\t\t\t\t\t\t");

            
            #line 175 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
                   Write(Html.Resource("EditProfileEmail"));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t</label>\r\n\t\t\t\t\t<div>\r\n");

WriteLiteral("\t\t\t\t\t\t");

            
            #line 178 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
                   Write(Html.HiddenFor(u => u.Email));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("\t\t\t\t\t\t");

            
            #line 179 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
                   Write(Model.Email);

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t</div>\r\n\t\t\t\t</div>\r\n");

            
            #line 182 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
				

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t<div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n\t\t\t\t\t<label>\r\n");

WriteLiteral("\t\t\t\t\t\t");

            
            #line 185 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
                   Write(Html.Resource("Password"));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t</label>\r\n\t\t\t\t\t<div>\r\n");

WriteLiteral("\t\t\t\t\t\t");

            
            #line 188 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
                   Write(string.Format(Html.Resource("ExternalProviderNoPassword"), Model.ExternalProviderName));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t</div>\r\n\t\t\t\t</div>\r\n");

            
            #line 191 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
			}		

            
            #line default
            #line hidden
WriteLiteral("\t\t\r\n");

            
            #line 193 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
            
            
            #line default
            #line hidden
            
            #line 193 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
             if (SystemManager.IsDesignMode)
            {

            
            #line default
            #line hidden
WriteLiteral("                <button");

WriteLiteral(" data-sf-role=\"profile-submit\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-primary\"");

WriteLiteral(">");

            
            #line 195 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
                                                                                       Write(Html.Resource("EditProfileSave"));

            
            #line default
            #line hidden
WriteLiteral("</button>\r\n");

            
            #line 196 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
            }
            else 
            {

            
            #line default
            #line hidden
WriteLiteral("                <button");

WriteLiteral(" data-sf-role=\"profile-submit\"");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" class=\"btn btn-primary\"");

WriteLiteral(">");

            
            #line 199 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
                                                                                       Write(Html.Resource("EditProfileSave"));

            
            #line default
            #line hidden
WriteLiteral("</button>\r\n");

            
            #line 200 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 202 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
            
            
            #line default
            #line hidden
            
            #line 202 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
             if (SystemManager.IsPreviewMode)
            {

            
            #line default
            #line hidden
WriteLiteral("                <div");

WriteLiteral(" class=\"has-error\"");

WriteLiteral(" data-sf-role=\"profile-submit-preview-message\"");

WriteLiteral(" style=\"display:none\"");

WriteLiteral(">\r\n                    <span");

WriteLiteral(" class=\"help-block\"");

WriteLiteral("><span");

WriteLiteral(" class=\"field-validation-error\"");

WriteLiteral(">");

            
            #line 205 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
                                                                             Write(Html.Resource("PreviewProfileSaveMessage"));

            
            #line default
            #line hidden
WriteLiteral("</span></span>\r\n                </div>\r\n");

            
            #line 207 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("        </div>\r\n     </div>\r\n");

            
            #line 210 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n\r\n");

            
            #line 213 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
  
	bool hasPasswordErrors = ViewBag.HasPasswordErrors is bool && ViewBag.HasPasswordErrors == true;

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" data-sf-role=\"has-password-errors\"");

WriteAttribute("value", Tuple.Create(" value=\"", 7949), Tuple.Create("\"", 8005)
            
            #line 217 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
, Tuple.Create(Tuple.Create("", 7957), Tuple.Create<System.Object, System.Int32>(hasPasswordErrors.ToString().ToLowerInvariant()
            
            #line default
            #line hidden
, 7957), false)
);

WriteLiteral(" />\r\n \r\n");

            
            #line 219 "..\..\ResourcePackages\Bootstrap\MVC\Views\Profile\Edit.ProfileEdit.cshtml"
Write(Html.Script(Url.WidgetContent("Mvc/Scripts/Profile/profile-edit.js"), "bottom"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

        }
    }
}
#pragma warning restore 1591