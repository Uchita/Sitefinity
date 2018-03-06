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

namespace SitefinityWebApp.ResourcePackages.Bootstrap.MVC.Views.ImageGallery
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
    
    #line 3 "..\..MVC\Views\ImageGallery\List.OverlayGallery.cshtml"
    using Telerik.Sitefinity;
    
    #line default
    #line hidden
    
    #line 5 "..\..MVC\Views\ImageGallery\List.OverlayGallery.cshtml"
    using Telerik.Sitefinity.Frontend.Media.Mvc.Helpers;
    
    #line default
    #line hidden
    
    #line 6 "..\..MVC\Views\ImageGallery\List.OverlayGallery.cshtml"
    using Telerik.Sitefinity.Frontend.Media.Mvc.Models.ImageGallery;
    
    #line default
    #line hidden
    
    #line 4 "..\..MVC\Views\ImageGallery\List.OverlayGallery.cshtml"
    using Telerik.Sitefinity.Frontend.Mvc.Helpers;
    
    #line default
    #line hidden
    
    #line 7 "..\..MVC\Views\ImageGallery\List.OverlayGallery.cshtml"
    using Telerik.Sitefinity.Modules.Pages;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/MVC/Views/ImageGallery/List.OverlayGallery.cshtml")]
    public partial class List_OverlayGallery : System.Web.Mvc.WebViewPage<Telerik.Sitefinity.Frontend.Mvc.Models.ContentListViewModel>
    {
        public List_OverlayGallery()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 9 "..\..MVC\Views\ImageGallery\List.OverlayGallery.cshtml"
Write(Html.Script(ScriptRef.JQuery, "top"));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

            
            #line 11 "..\..MVC\Views\ImageGallery\List.OverlayGallery.cshtml"
Write(Html.StyleSheet(Url.WidgetContent("assets/magnific/magnific-popup.css"), "head"));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

            
            #line 13 "..\..MVC\Views\ImageGallery\List.OverlayGallery.cshtml"
Write(Html.Script(Url.WidgetContent("assets/magnific/jquery.magnific-popup.min.js"), "bottom"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 14 "..\..MVC\Views\ImageGallery\List.OverlayGallery.cshtml"
Write(Html.Script(Url.WidgetContent("Mvc/Scripts/ImageGallery/overlay-gallery.js"), "bottom"));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<div");

WriteLiteral(" class=\"sf-Gallery-thumbs-container\"");

WriteLiteral(">\r\n  <div");

WriteAttribute("class", Tuple.Create(" class=\"", 671), Tuple.Create("\"", 712)
, Tuple.Create(Tuple.Create("", 679), Tuple.Create("sf-Gallery-thumbs", 679), true)
            
            #line 17 "..\..MVC\Views\ImageGallery\List.OverlayGallery.cshtml"
, Tuple.Create(Tuple.Create(" ", 696), Tuple.Create<System.Object, System.Int32>(Model.CssClass
            
            #line default
            #line hidden
, 697), false)
);

WriteLiteral(">\r\n");

            
            #line 18 "..\..MVC\Views\ImageGallery\List.OverlayGallery.cshtml"
    
            
            #line default
            #line hidden
            
            #line 18 "..\..MVC\Views\ImageGallery\List.OverlayGallery.cshtml"
      int itemIndex = 0;
            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 19 "..\..MVC\Views\ImageGallery\List.OverlayGallery.cshtml"
    
            
            #line default
            #line hidden
            
            #line 19 "..\..MVC\Views\ImageGallery\List.OverlayGallery.cshtml"
     foreach (var item in Model.Items)
    {
        var thumbnailViewModel = (ThumbnailViewModel)item;


            
            #line default
            #line hidden
WriteLiteral("        <a");

WriteLiteral(" class=\"text-center image-link\"");

WriteAttribute("href", Tuple.Create("\r\n            href=\"", 893), Tuple.Create("\"", 943)
            
            #line 24 "..\..MVC\Views\ImageGallery\List.OverlayGallery.cshtml"
, Tuple.Create(Tuple.Create("", 913), Tuple.Create<System.Object, System.Int32>(thumbnailViewModel.MediaUrl
            
            #line default
            #line hidden
, 913), false)
);

WriteAttribute("title", Tuple.Create("\r\n            title=\"", 944), Tuple.Create("\"", 993)
            
            #line 25 "..\..MVC\Views\ImageGallery\List.OverlayGallery.cshtml"
, Tuple.Create(Tuple.Create("", 965), Tuple.Create<System.Object, System.Int32>(item.Fields.AlternativeText
            
            #line default
            #line hidden
, 965), false)
);

WriteLiteral(">\r\n            <img");

WriteAttribute("src", Tuple.Create(" src=\"", 1013), Tuple.Create("\"", 1053)
            
            #line 26 "..\..MVC\Views\ImageGallery\List.OverlayGallery.cshtml"
, Tuple.Create(Tuple.Create("", 1019), Tuple.Create<System.Object, System.Int32>(thumbnailViewModel.ThumbnailUrl
            
            #line default
            #line hidden
, 1019), false)
);

WriteLiteral(" \r\n                 data-detail-url=\"");

            
            #line 27 "..\..MVC\Views\ImageGallery\List.OverlayGallery.cshtml"
                             Write(HyperLinkHelpers.GetDetailPageUrl(item, ViewBag.DetailsPageId, ViewBag.OpenInSamePage, Model.UrlKeyPrefix, itemIndex));

            
            #line default
            #line hidden
WriteLiteral("\"");

WriteAttribute("alt", Tuple.Create(" \r\n                 alt=\"", 1210), Tuple.Create("\"", 1263)
            
            #line 28 "..\..MVC\Views\ImageGallery\List.OverlayGallery.cshtml"
, Tuple.Create(Tuple.Create("", 1235), Tuple.Create<System.Object, System.Int32>(item.Fields.AlternativeText
            
            #line default
            #line hidden
, 1235), false)
);

WriteLiteral("\r\n                      ");

            
            #line 29 "..\..MVC\Views\ImageGallery\List.OverlayGallery.cshtml"
                 Write(Html.GetWidthAttributeIfExists(thumbnailViewModel.Width));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                      ");

            
            #line 30 "..\..MVC\Views\ImageGallery\List.OverlayGallery.cshtml"
                 Write(Html.GetHeightAttributeIfExists(thumbnailViewModel.Height));

            
            #line default
            #line hidden
WriteLiteral(" ");

            
            #line 30 "..\..MVC\Views\ImageGallery\List.OverlayGallery.cshtml"
                                                                             Write(Html.GetDetailsImageWidthAttributeIfExists(thumbnailViewModel.DetailsImageWidth));

            
            #line default
            #line hidden
WriteLiteral(" />\r\n        </a>\r\n");

            
            #line 32 "..\..MVC\Views\ImageGallery\List.OverlayGallery.cshtml"
        itemIndex++;
    }

            
            #line default
            #line hidden
WriteLiteral("  </div>\r\n</div>\r\n\r\n");

            
            #line 37 "..\..MVC\Views\ImageGallery\List.OverlayGallery.cshtml"
 if (Model.ShowPager)
{
    
            
            #line default
            #line hidden
            
            #line 39 "..\..MVC\Views\ImageGallery\List.OverlayGallery.cshtml"
Write(Html.Action("Index", "ContentPager", new
       {
           currentPage = Model.CurrentPage,
           totalPagesCount = Model.TotalPagesCount.Value,
           redirectUrlTemplate = ViewBag.RedirectPageUrlTemplate
       }));

            
            #line default
            #line hidden
            
            #line 44 "..\..MVC\Views\ImageGallery\List.OverlayGallery.cshtml"
         
}

            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591