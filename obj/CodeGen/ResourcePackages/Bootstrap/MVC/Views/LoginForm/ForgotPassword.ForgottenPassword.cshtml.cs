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

namespace SitefinityWebApp.ResourcePackages.Bootstrap.MVC.Views.LoginForm
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
    
    #line 4 "..\..\ResourcePackages\Bootstrap\MVC\Views\LoginForm\ForgotPassword.ForgottenPassword.cshtml"
    using Telerik.Sitefinity.Frontend.Mvc.Helpers;
    
    #line default
    #line hidden
    
    #line 3 "..\..\ResourcePackages\Bootstrap\MVC\Views\LoginForm\ForgotPassword.ForgottenPassword.cshtml"
    using Telerik.Sitefinity.UI.MVC;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/ResourcePackages/Bootstrap/MVC/Views/LoginForm/ForgotPassword.ForgottenPassword" +
        ".cshtml")]
    public partial class ForgotPassword_ForgottenPassword : System.Web.Mvc.WebViewPage<Telerik.Sitefinity.Frontend.Identity.Mvc.Models.LoginForm.ForgotPasswordViewModel>
    {
        public ForgotPassword_ForgottenPassword()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n<div");

WriteAttribute("class", Tuple.Create(" class=\"", 181), Tuple.Create("\"", 204)
            
            #line 6 "..\..\ResourcePackages\Bootstrap\MVC\Views\LoginForm\ForgotPassword.ForgottenPassword.cshtml"
, Tuple.Create(Tuple.Create("", 189), Tuple.Create<System.Object, System.Int32>(Model.CssClass
            
            #line default
            #line hidden
, 189), false)
);

WriteLiteral(">\r\n\r\n<h3>");

            
            #line 8 "..\..\ResourcePackages\Bootstrap\MVC\Views\LoginForm\ForgotPassword.ForgottenPassword.cshtml"
Write(Html.Resource("ForgotPasswordHeader"));

            
            #line default
            #line hidden
WriteLiteral("</h3>\r\n\r\n");

            
            #line 10 "..\..\ResourcePackages\Bootstrap\MVC\Views\LoginForm\ForgotPassword.ForgottenPassword.cshtml"
 if (Model.EmailSent)
{

            
            #line default
            #line hidden
WriteLiteral("    <p>");

            
            #line 12 "..\..\ResourcePackages\Bootstrap\MVC\Views\LoginForm\ForgotPassword.ForgottenPassword.cshtml"
  Write(Html.Resource("ForgotPasswordRequestSent"));

            
            #line default
            #line hidden
WriteLiteral(" <i>");

            
            #line 12 "..\..\ResourcePackages\Bootstrap\MVC\Views\LoginForm\ForgotPassword.ForgottenPassword.cshtml"
                                                 Write(Html.Encode(Model.Email));

            
            #line default
            #line hidden
WriteLiteral("</i></p>\r\n");

            
            #line 13 "..\..\ResourcePackages\Bootstrap\MVC\Views\LoginForm\ForgotPassword.ForgottenPassword.cshtml"


            
            #line default
            #line hidden
WriteLiteral("    <p>");

            
            #line 14 "..\..\ResourcePackages\Bootstrap\MVC\Views\LoginForm\ForgotPassword.ForgottenPassword.cshtml"
  Write(Html.Resource("ForgotPasswordRequestSentUseLink"));

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n");

            
            #line 15 "..\..\ResourcePackages\Bootstrap\MVC\Views\LoginForm\ForgotPassword.ForgottenPassword.cshtml"


            
            #line default
            #line hidden
WriteLiteral("    <a");

WriteAttribute("href", Tuple.Create(" href=\"", 449), Tuple.Create("\"", 475)
            
            #line 16 "..\..\ResourcePackages\Bootstrap\MVC\Views\LoginForm\ForgotPassword.ForgottenPassword.cshtml"
, Tuple.Create(Tuple.Create("", 456), Tuple.Create<System.Object, System.Int32>(Model.LoginPageUrl
            
            #line default
            #line hidden
, 456), false)
);

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(">");

            
            #line 16 "..\..\ResourcePackages\Bootstrap\MVC\Views\LoginForm\ForgotPassword.ForgottenPassword.cshtml"
                                                     Write(Html.Resource("ForgotPasswordBackToLogin"));

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n");

            
            #line 17 "..\..\ResourcePackages\Bootstrap\MVC\Views\LoginForm\ForgotPassword.ForgottenPassword.cshtml"
}
else
{
    using (Html.BeginForm("SendPasswordResetEmail", "LoginForm"))
    {


            
            #line default
            #line hidden
WriteLiteral("        <p>");

            
            #line 23 "..\..\ResourcePackages\Bootstrap\MVC\Views\LoginForm\ForgotPassword.ForgottenPassword.cshtml"
      Write(Html.Resource("EnterLoginEmailAddress"));

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n");

            
            #line 24 "..\..\ResourcePackages\Bootstrap\MVC\Views\LoginForm\ForgotPassword.ForgottenPassword.cshtml"


            
            #line default
            #line hidden
WriteLiteral("\t\t<div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n\t\t\t<label>");

            
            #line 26 "..\..\ResourcePackages\Bootstrap\MVC\Views\LoginForm\ForgotPassword.ForgottenPassword.cshtml"
              Write(Html.Resource("ForgotPasswordEmail"));

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n");

WriteLiteral("\t\t\t");

            
            #line 27 "..\..\ResourcePackages\Bootstrap\MVC\Views\LoginForm\ForgotPassword.ForgottenPassword.cshtml"
       Write(Html.TextBoxFor(u => u.Email, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n            </div>\r\n");

            
            #line 30 "..\..\ResourcePackages\Bootstrap\MVC\Views\LoginForm\ForgotPassword.ForgottenPassword.cshtml"


            
            #line default
            #line hidden
WriteLiteral("      <button");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" class=\"btn btn-primary\"");

WriteLiteral(">");

            
            #line 31 "..\..\ResourcePackages\Bootstrap\MVC\Views\LoginForm\ForgotPassword.ForgottenPassword.cshtml"
                                               Write(Html.Resource("ForgotPasswordSendButton"));

            
            #line default
            #line hidden
WriteLiteral("</button>\r\n");

            
            #line 32 "..\..\ResourcePackages\Bootstrap\MVC\Views\LoginForm\ForgotPassword.ForgottenPassword.cshtml"
    }
}

            
            #line default
            #line hidden
WriteLiteral("\r\n</div>\r\n");

        }
    }
}
#pragma warning restore 1591
