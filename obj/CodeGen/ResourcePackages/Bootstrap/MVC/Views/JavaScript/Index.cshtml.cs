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

namespace SitefinityWebApp.ResourcePackages.Bootstrap.MVC.Views.JavaScript
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
    
    #line 3 "..\..\ResourcePackages\Bootstrap\MVC\Views\JavaScript\Index.cshtml"
    using Telerik.Sitefinity.Frontend.InlineClientAssets.Mvc.Models;
    
    #line default
    #line hidden
    
    #line 4 "..\..\ResourcePackages\Bootstrap\MVC\Views\JavaScript\Index.cshtml"
    using Telerik.Sitefinity.Frontend.Mvc.Helpers;
    
    #line default
    #line hidden
    
    #line 5 "..\..\ResourcePackages\Bootstrap\MVC\Views\JavaScript\Index.cshtml"
    using Telerik.Sitefinity.Services;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/ResourcePackages/Bootstrap/MVC/Views/JavaScript/Index.cshtml")]
    public partial class Index : System.Web.Mvc.WebViewPage<Telerik.Sitefinity.Frontend.InlineClientAssets.Mvc.Models.JavaScript.JavaScriptViewModel>
    {
        public Index()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 7 "..\..\ResourcePackages\Bootstrap\MVC\Views\JavaScript\Index.cshtml"
 if (Model.Position == EmbedPosition.InPlace && !(SystemManager.IsDesignMode && !SystemManager.IsPreviewMode && !SystemManager.IsInlineEditingMode))
{
    
            
            #line default
            #line hidden
            
            #line 9 "..\..\ResourcePackages\Bootstrap\MVC\Views\JavaScript\Index.cshtml"
Write(Html.Raw(Model.JavaScriptCode));

            
            #line default
            #line hidden
            
            #line 9 "..\..\ResourcePackages\Bootstrap\MVC\Views\JavaScript\Index.cshtml"
                                   
}

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 12 "..\..\ResourcePackages\Bootstrap\MVC\Views\JavaScript\Index.cshtml"
 if (!string.IsNullOrEmpty(Model.DesignModeContent))
{

            
            #line default
            #line hidden
WriteLiteral("    <div");

WriteLiteral(" class=\"sf-Code\"");

WriteLiteral(">\r\n        <pre>");

            
            #line 15 "..\..\ResourcePackages\Bootstrap\MVC\Views\JavaScript\Index.cshtml"
        Write(Model.DesignModeContent);

            
            #line default
            #line hidden
WriteLiteral("</pre>\r\n    </div>\r\n");

            
            #line 17 "..\..\ResourcePackages\Bootstrap\MVC\Views\JavaScript\Index.cshtml"
}
            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591
