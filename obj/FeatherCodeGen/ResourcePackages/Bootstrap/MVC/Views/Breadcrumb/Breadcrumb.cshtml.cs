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

namespace SitefinityWebApp.ResourcePackages.Bootstrap.MVC.Views.Breadcrumb
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/MVC/Views/Breadcrumb/Breadcrumb.cshtml")]
    public partial class Breadcrumb : System.Web.Mvc.WebViewPage<dynamic>
    {
        public Breadcrumb()
        {
        }
        public override void Execute()
        {
WriteLiteral("<div");

WriteAttribute("class", Tuple.Create(" class=\"", 4), Tuple.Create("\"", 27)
            
            #line 1 "..\..MVC\Views\Breadcrumb\Breadcrumb.cshtml"
, Tuple.Create(Tuple.Create("", 12), Tuple.Create<System.Object, System.Int32>(Model.CssClass
            
            #line default
            #line hidden
, 12), false)
);

WriteLiteral(">\r\n    <ul");

WriteLiteral(" class=\"sf-breadscrumb breadcrumb\"");

WriteLiteral(">\r\n");

            
            #line 3 "..\..MVC\Views\Breadcrumb\Breadcrumb.cshtml"
        
            
            #line default
            #line hidden
            
            #line 3 "..\..MVC\Views\Breadcrumb\Breadcrumb.cshtml"
         for (int i = 0; i < Model.SiteMapNodes.Count; i++)
        {
            var node = Model.SiteMapNodes[i];
            
            if (i == Model.SiteMapNodes.Count - 1 && Model.ShowCurrentPageInTheEnd)
            {

            
            #line default
            #line hidden
WriteLiteral("                <li");

WriteLiteral(" class=\"active\"");

WriteLiteral(">");

            
            #line 9 "..\..MVC\Views\Breadcrumb\Breadcrumb.cshtml"
                              Write(node.Title);

            
            #line default
            #line hidden
WriteLiteral("</li>\r\n");

            
            #line 10 "..\..MVC\Views\Breadcrumb\Breadcrumb.cshtml"
            }
            else
            {

            
            #line default
            #line hidden
WriteLiteral("                <li><a");

WriteAttribute("href", Tuple.Create(" href=\"", 431), Tuple.Create("\"", 447)
            
            #line 13 "..\..MVC\Views\Breadcrumb\Breadcrumb.cshtml"
, Tuple.Create(Tuple.Create("", 438), Tuple.Create<System.Object, System.Int32>(node.Url
            
            #line default
            #line hidden
, 438), false)
);

WriteLiteral(">");

            
            #line 13 "..\..MVC\Views\Breadcrumb\Breadcrumb.cshtml"
                                   Write(node.Title);

            
            #line default
            #line hidden
WriteLiteral(" </a></li>\r\n");

            
            #line 14 "..\..MVC\Views\Breadcrumb\Breadcrumb.cshtml"
            }
        }

            
            #line default
            #line hidden
WriteLiteral("    </ul>\r\n</div>");

        }
    }
}
#pragma warning restore 1591
