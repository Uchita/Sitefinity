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

namespace SitefinityWebApp.ResourcePackages.Bootstrap.MVC.Views.Reviews
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
    
    #line 3 "..\..\ResourcePackages\Bootstrap\MVC\Views\Reviews\Reviews.Default.cshtml"
    using Telerik.Sitefinity.Frontend.Mvc.Helpers;
    
    #line default
    #line hidden
    
    #line 4 "..\..\ResourcePackages\Bootstrap\MVC\Views\Reviews\Reviews.Default.cshtml"
    using Telerik.Sitefinity.Modules.Pages;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/ResourcePackages/Bootstrap/MVC/Views/Reviews/Reviews.Default.cshtml")]
    public partial class Reviews_Default : System.Web.Mvc.WebViewPage<Telerik.Sitefinity.Frontend.Comments.Mvc.Models.CommentsListViewModel>
    {
        public Reviews_Default()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 6 "..\..\ResourcePackages\Bootstrap\MVC\Views\Reviews\Reviews.Default.cshtml"
Write(Html.Script(ScriptRef.JQuery, "top", false));

            
            #line default
            #line hidden
WriteLiteral("\r\n<div");

WriteAttribute("id", Tuple.Create(" id=\"", 223), Tuple.Create("\"", 277)
, Tuple.Create(Tuple.Create("", 228), Tuple.Create("comments-", 228), true)
            
            #line 7 "..\..\ResourcePackages\Bootstrap\MVC\Views\Reviews\Reviews.Default.cshtml"
, Tuple.Create(Tuple.Create("", 237), Tuple.Create<System.Object, System.Int32>(HttpUtility.HtmlEncode(Model.ThreadKey)
            
            #line default
            #line hidden
, 237), false)
);

WriteLiteral(" data-sf-role=\"comments-wrapper\"");

WriteAttribute("class", Tuple.Create(" class=\"", 310), Tuple.Create("\"", 356)
            
            #line 7 "..\..\ResourcePackages\Bootstrap\MVC\Views\Reviews\Reviews.Default.cshtml"
                    , Tuple.Create(Tuple.Create("", 318), Tuple.Create<System.Object, System.Int32>(Model.CssClass
            
            #line default
            #line hidden
, 318), false)
, Tuple.Create(Tuple.Create(" ", 333), Tuple.Create("sf-Comments", 334), true)
, Tuple.Create(Tuple.Create(" ", 345), Tuple.Create("sf-Reviews", 346), true)
);

WriteLiteral(">\r\n    <input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" data-sf-role=\"comments-settings\"");

WriteAttribute("value", Tuple.Create(" value=\"", 417), Tuple.Create("\"", 456)
            
            #line 8 "..\..\ResourcePackages\Bootstrap\MVC\Views\Reviews\Reviews.Default.cshtml"
, Tuple.Create(Tuple.Create("", 425), Tuple.Create<System.Object, System.Int32>(Model.SerializedWidgetSettings
            
            #line default
            #line hidden
, 425), false)
);

WriteLiteral(" />\r\n    <input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" data-sf-role=\"comments-resources\"");

WriteAttribute("value", Tuple.Create(" value=\"", 520), Tuple.Create("\"", 560)
            
            #line 9 "..\..\ResourcePackages\Bootstrap\MVC\Views\Reviews\Reviews.Default.cshtml"
, Tuple.Create(Tuple.Create("", 528), Tuple.Create<System.Object, System.Int32>(Model.SerializedWidgetResources
            
            #line default
            #line hidden
, 528), false)
);

WriteLiteral(" />\r\n\r\n    <div");

WriteLiteral(" class=\"row sf-Comments-header\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"col-md-7\"");

WriteLiteral(">\r\n\r\n            <h3>\r\n                <span");

WriteLiteral(" data-sf-role=\"comments-total-count\"");

WriteLiteral("></span>\r\n                <span");

WriteLiteral(" data-sf-role=\"comments-header\"");

WriteLiteral("></span>\r\n            </h3>\r\n\r\n");

            
            #line 19 "..\..\ResourcePackages\Bootstrap\MVC\Views\Reviews\Reviews.Default.cshtml"
            
            
            #line default
            #line hidden
            
            #line 19 "..\..\ResourcePackages\Bootstrap\MVC\Views\Reviews\Reviews.Default.cshtml"
             if (!Model.ThreadIsClosed)
            {

            
            #line default
            #line hidden
WriteLiteral("                <a");

WriteAttribute("href", Tuple.Create(" href=\"", 886), Tuple.Create("\"", 972)
, Tuple.Create(Tuple.Create("", 893), Tuple.Create("#comment-submit-", 893), true)
            
            #line 21 "..\..\ResourcePackages\Bootstrap\MVC\Views\Reviews\Reviews.Default.cshtml"
, Tuple.Create(Tuple.Create("", 909), Tuple.Create<System.Object, System.Int32>(HttpUtility.HtmlEncode(HttpUtility.UrlEncode(Model.ThreadKey))
            
            #line default
            #line hidden
, 909), false)
);

WriteLiteral(" data-sf-role=\"comments-new-form-button\"");

WriteLiteral(">");

            
            #line 21 "..\..\ResourcePackages\Bootstrap\MVC\Views\Reviews\Reviews.Default.cshtml"
                                                                                                                                             Write(Html.Resource("WriteReview"));

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n");

            
            #line 22 "..\..\ResourcePackages\Bootstrap\MVC\Views\Reviews\Reviews.Default.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("            \r\n            <span");

WriteLiteral(" data-sf-role=\"comments-count-list-wrapper\"");

WriteLiteral(">\r\n                <span");

WriteLiteral(" class=\"text-muted\"");

WriteLiteral(">");

            
            #line 25 "..\..\ResourcePackages\Bootstrap\MVC\Views\Reviews\Reviews.Default.cshtml"
                                    Write(Html.Resource("AverageRating"));

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n");

WriteLiteral("                ");

            
            #line 26 "..\..\ResourcePackages\Bootstrap\MVC\Views\Reviews\Reviews.Default.cshtml"
           Write(Html.CommentsCount(string.Empty, Model.ThreadKey, Model.ThreadType));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </span>\r\n        </div>\r\n\r\n\r\n        <div");

WriteLiteral(" class=\"col-md-5 clearfix\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"pull-right\"");

WriteLiteral(">\r\n                <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(" data-sf-role=\"comments-sort-new-button\"");

WriteLiteral(" style=\"display:none;\"");

WriteLiteral(">");

            
            #line 33 "..\..\ResourcePackages\Bootstrap\MVC\Views\Reviews\Reviews.Default.cshtml"
                                                                                     Write(Html.Resource("NewestOnTop"));

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n                <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(" data-sf-role=\"comments-sort-old-button\"");

WriteLiteral(" style=\"display:none;\"");

WriteLiteral(">");

            
            #line 34 "..\..\ResourcePackages\Bootstrap\MVC\Views\Reviews\Reviews.Default.cshtml"
                                                                                     Write(Html.Resource("OldestOnTop"));

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n            </div>\r\n        </div>\r\n    </div>\r\n          \r\n    <div");

WriteLiteral(" data-sf-role=\"list-loading-indicator\"");

WriteLiteral(" style=\"display:none;\"");

WriteLiteral("></div>\r\n    <div");

WriteLiteral(" data-sf-role=\"comments-container\"");

WriteLiteral(" class=\"sf-Comments-list\"");

WriteLiteral("></div>\r\n\r\n");

            
            #line 42 "..\..\ResourcePackages\Bootstrap\MVC\Views\Reviews\Reviews.Default.cshtml"
    
            
            #line default
            #line hidden
            
            #line 42 "..\..\ResourcePackages\Bootstrap\MVC\Views\Reviews\Reviews.Default.cshtml"
     if(Model.EnablePaging)
    {

            
            #line default
            #line hidden
WriteLiteral("        <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(" data-sf-role=\"comments-load-more-button\"");

WriteLiteral(">");

            
            #line 44 "..\..\ResourcePackages\Bootstrap\MVC\Views\Reviews\Reviews.Default.cshtml"
                                                        Write(Html.Resource("LoadMoreReviews"));

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n");

            
            #line 45 "..\..\ResourcePackages\Bootstrap\MVC\Views\Reviews\Reviews.Default.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 47 "..\..\ResourcePackages\Bootstrap\MVC\Views\Reviews\Reviews.Default.cshtml"
    
            
            #line default
            #line hidden
            
            #line 47 "..\..\ResourcePackages\Bootstrap\MVC\Views\Reviews\Reviews.Default.cshtml"
     if (Model.ThreadIsClosed)
    {

            
            #line default
            #line hidden
WriteLiteral("        <div");

WriteLiteral(" class=\"alert alert-warning\"");

WriteLiteral(">");

            
            #line 49 "..\..\ResourcePackages\Bootstrap\MVC\Views\Reviews\Reviews.Default.cshtml"
                                    Write(Html.Resource("ReviewsThreadIsClosedMessage"));

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n");

            
            #line 50 "..\..\ResourcePackages\Bootstrap\MVC\Views\Reviews\Reviews.Default.cshtml"
    }
    else 
    {   

            
            #line default
            #line hidden
WriteLiteral("        <div");

WriteLiteral(" class=\"sf-Comments-form\"");

WriteLiteral(">\r\n           \r\n            <div");

WriteLiteral(" data-sf-role=\"comments-new-form\"");

WriteAttribute("id", Tuple.Create(" id=\"", 2302), Tuple.Create("\"", 2362)
, Tuple.Create(Tuple.Create("", 2307), Tuple.Create("comment-submit-", 2307), true)
            
            #line 55 "..\..\ResourcePackages\Bootstrap\MVC\Views\Reviews\Reviews.Default.cshtml"
, Tuple.Create(Tuple.Create("", 2322), Tuple.Create<System.Object, System.Int32>(HttpUtility.HtmlEncode(Model.ThreadKey)
            
            #line default
            #line hidden
, 2322), false)
);

WriteLiteral(" class=\"sf-Comments-form\"");

WriteLiteral(">\r\n");

            
            #line 56 "..\..\ResourcePackages\Bootstrap\MVC\Views\Reviews\Reviews.Default.cshtml"
                
            
            #line default
            #line hidden
            
            #line 56 "..\..\ResourcePackages\Bootstrap\MVC\Views\Reviews\Reviews.Default.cshtml"
                 if (Model.RequiresApproval)
                {

            
            #line default
            #line hidden
WriteLiteral("                    <div");

WriteLiteral(" class=\"alert alert-warning\"");

WriteLiteral(" data-sf-role=\"comments-new-pending-approval-message\"");

WriteLiteral(">");

            
            #line 58 "..\..\ResourcePackages\Bootstrap\MVC\Views\Reviews\Reviews.Default.cshtml"
                                                                                                     Write(Html.Resource("ReviewPendingApproval"));

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n");

            
            #line 59 "..\..\ResourcePackages\Bootstrap\MVC\Views\Reviews\Reviews.Default.cshtml"
                }

            
            #line default
            #line hidden
WriteLiteral("\r\n                <div");

WriteLiteral(" class=\"media sf-media\"");

WriteLiteral(">\r\n            \r\n                    <div");

WriteLiteral(" class=\"media-left sf-img-thmb\"");

WriteLiteral(">\r\n                       <img");

WriteAttribute("src", Tuple.Create(" src=\"", 2775), Tuple.Create("\"", 2806)
            
            #line 64 "..\..\ResourcePackages\Bootstrap\MVC\Views\Reviews\Reviews.Default.cshtml"
, Tuple.Create(Tuple.Create("", 2781), Tuple.Create<System.Object, System.Int32>(Model.UserAvatarImageUrl
            
            #line default
            #line hidden
, 2781), false)
);

WriteLiteral("  width=\"40\"");

WriteLiteral(" height=\"40\"");

WriteLiteral("/>\r\n                    </div>\r\n\r\n                    <div");

WriteLiteral(" class=\"media-body sf-media-body\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                            <label");

WriteLiteral(" class=\"sr-only\"");

WriteLiteral(">");

            
            #line 69 "..\..\ResourcePackages\Bootstrap\MVC\Views\Reviews\Reviews.Default.cshtml"
                                              Write(Html.Resource("WriteReview"));

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n                            <textarea");

WriteLiteral(" data-sf-role=\"comments-new-message\"");

WriteAttribute("placeholder", Tuple.Create(" placeholder=\"", 3138), Tuple.Create("\"", 3181)
            
            #line 70 "..\..\ResourcePackages\Bootstrap\MVC\Views\Reviews\Reviews.Default.cshtml"
       , Tuple.Create(Tuple.Create("", 3152), Tuple.Create<System.Object, System.Int32>(Html.Resource("WriteReview")
            
            #line default
            #line hidden
, 3152), false)
);

WriteLiteral(" class=\"form-control\"");

WriteLiteral("></textarea>\r\n                        </div>\r\n            \r\n                     " +
"   <div>\r\n                            <label>");

            
            #line 74 "..\..\ResourcePackages\Bootstrap\MVC\Views\Reviews\Reviews.Default.cshtml"
                              Write(Html.Resource("Rating"));

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n                            <div");

WriteLiteral(" class=\"sf-Ratings\"");

WriteLiteral(">\r\n                                <div");

WriteLiteral(" data-sf-role=\"submit-rating-container\"");

WriteLiteral(" class=\"sf-Ratings-stars\"");

WriteLiteral(">\r\n                                </div>\r\n                            </div>\r\n\r\n" +
"                        </div>\r\n\r\n                        <div");

WriteLiteral(" data-sf-role=\"comments-new-logged-out-view\"");

WriteLiteral(" style=\"display:none;\"");

WriteLiteral(">\r\n\r\n                            <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                                <label");

WriteLiteral(" class=\"sr-only\"");

WriteLiteral(" style=\"display: none;\"");

WriteLiteral(">");

            
            #line 85 "..\..\ResourcePackages\Bootstrap\MVC\Views\Reviews\Reviews.Default.cshtml"
                                                                         Write(Html.Resource("YourName"));

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n                                <input");

WriteAttribute("placeholder", Tuple.Create(" placeholder=\"", 3937), Tuple.Create("\"", 3977)
            
            #line 86 "..\..\ResourcePackages\Bootstrap\MVC\Views\Reviews\Reviews.Default.cshtml"
, Tuple.Create(Tuple.Create("", 3951), Tuple.Create<System.Object, System.Int32>(Html.Resource("YourName")
            
            #line default
            #line hidden
, 3951), false)
);

WriteLiteral(" data-sf-role=\"comments-new-name\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" />\r\n                            </div>\r\n\r\n                           <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                                <label");

WriteLiteral(" class=\"sr-only\"");

WriteLiteral(" style=\"display: none;\"");

WriteLiteral(">");

            
            #line 90 "..\..\ResourcePackages\Bootstrap\MVC\Views\Reviews\Reviews.Default.cshtml"
                                                                         Write(Html.Resource("EmailOptional"));

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n                                <input");

WriteLiteral(" type=\"email\"");

WriteAttribute("placeholder", Tuple.Create(" placeholder=\"", 4298), Tuple.Create("\"", 4343)
            
            #line 91 "..\..\ResourcePackages\Bootstrap\MVC\Views\Reviews\Reviews.Default.cshtml"
, Tuple.Create(Tuple.Create("", 4312), Tuple.Create<System.Object, System.Int32>(Html.Resource("EmailOptional")
            
            #line default
            #line hidden
, 4312), false)
);

WriteLiteral(" data-sf-role=\"comments-new-email\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral("/>\r\n                            </div>\r\n                        </div>\r\n\r\n");

            
            #line 95 "..\..\ResourcePackages\Bootstrap\MVC\Views\Reviews\Reviews.Default.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 95 "..\..\ResourcePackages\Bootstrap\MVC\Views\Reviews\Reviews.Default.cshtml"
                         if (Model.RequiresCaptcha)
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <div");

WriteLiteral(" data-sf-role=\"captcha-container\"");

WriteLiteral(" style=\"display:none;\"");

WriteLiteral(" class=\"sf-Comments-captcha\"");

WriteLiteral(">\r\n                                <div>\r\n                                    <im" +
"g");

WriteLiteral(" data-sf-role=\"captcha-image\"");

WriteAttribute("src", Tuple.Create(" src=\"", 4779), Tuple.Create("\"", 4832)
            
            #line 99 "..\..\ResourcePackages\Bootstrap\MVC\Views\Reviews\Reviews.Default.cshtml"
, Tuple.Create(Tuple.Create("", 4785), Tuple.Create<System.Object, System.Int32>(Url.WidgetContent("assets/dist/img/dummy.jpg")
            
            #line default
            #line hidden
, 4785), false)
);

WriteLiteral(" />\r\n                                </div>\r\n\r\n                                <a" +
"");

WriteLiteral(" data-sf-role=\"captcha-refresh-button\"");

WriteLiteral("> ");

            
            #line 102 "..\..\ResourcePackages\Bootstrap\MVC\Views\Reviews\Reviews.Default.cshtml"
                                                                     Write(Html.Resource("NewCode"));

            
            #line default
            #line hidden
WriteLiteral(" </a>\r\n\r\n                                <div");

WriteLiteral(" class=\"form-inline\"");

WriteLiteral(">\r\n\r\n                                    <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                                        <label>");

            
            #line 107 "..\..\ResourcePackages\Bootstrap\MVC\Views\Reviews\Reviews.Default.cshtml"
                                          Write(Html.Resource("TypeCodeAbove"));

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n                                        <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" data-sf-role=\"captcha-input\"");

WriteLiteral(" class=\"form-control input-sm\"");

WriteLiteral(" />\r\n                                    </div>\r\n\r\n                              " +
"  </div>\r\n                            </div>\r\n");

            
            #line 113 "..\..\ResourcePackages\Bootstrap\MVC\Views\Reviews\Reviews.Default.cshtml"
                        }

            
            #line default
            #line hidden
WriteLiteral("\r\n                        <div>\r\n                            <button");

WriteLiteral(" class=\"btn btn-primary\"");

WriteLiteral(" data-sf-role=\"comments-new-submit-button\"");

WriteLiteral(">");

            
            #line 116 "..\..\ResourcePackages\Bootstrap\MVC\Views\Reviews\Reviews.Default.cshtml"
                                                                                                 Write(Html.Resource("Submit"));

            
            #line default
            #line hidden
WriteLiteral("</button>\r\n                        </div>\r\n\r\n                    </div>\r\n\r\n      " +
"           </div>\r\n\r\n               </div>\r\n\r\n");

            
            #line 125 "..\..\ResourcePackages\Bootstrap\MVC\Views\Reviews\Reviews.Default.cshtml"
                
            
            #line default
            #line hidden
            
            #line 125 "..\..\ResourcePackages\Bootstrap\MVC\Views\Reviews\Reviews.Default.cshtml"
                 if (Model.AllowSubscription)
                {

            
            #line default
            #line hidden
WriteLiteral("                    <div");

WriteLiteral(" class=\"sf-Comment-subscribe\"");

WriteLiteral(">\r\n                        <span");

WriteLiteral(" data-sf-role=\"comments-subscribe-text\"");

WriteLiteral("></span>\r\n                        <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(" data-sf-role=\"comments-subscribe-button\"");

WriteLiteral(">\r\n                            <span");

WriteLiteral(" class=\"sf-icon-email\"");

WriteLiteral("></span>\r\n                            <span");

WriteLiteral(" data-sf-role=\"comments-subscribe-button-text\"");

WriteLiteral("></span>\r\n                        </a>\r\n                    </div>\r\n");

            
            #line 134 "..\..\ResourcePackages\Bootstrap\MVC\Views\Reviews\Reviews.Default.cshtml"
                }

            
            #line default
            #line hidden
WriteLiteral("\r\n                <div");

WriteLiteral(" class=\"has-error\"");

WriteLiteral(" data-sf-role=\"error-message\"");

WriteLiteral(">\r\n                    <span");

WriteLiteral(" class=\"help-block\"");

WriteLiteral("></span>\r\n                </div>\r\n        \r\n                <div");

WriteLiteral(" data-sf-role=\"submit-loading-indicator\"");

WriteLiteral(" class=\"sf-loading\"");

WriteLiteral(" style=\"display:none;\"");

WriteLiteral("></div>\r\n\r\n  \r\n        </div>  \r\n");

            
            #line 144 "..\..\ResourcePackages\Bootstrap\MVC\Views\Reviews\Reviews.Default.cshtml"
        

            
            #line default
            #line hidden
WriteLiteral("        <div");

WriteLiteral(" class=\"alert alert-warning sf-Review-already\"");

WriteLiteral(" data-sf-role=\"review-new-form-replacement\"");

WriteLiteral(">");

            
            #line 145 "..\..\ResourcePackages\Bootstrap\MVC\Views\Reviews\Reviews.Default.cshtml"
                                                                                                 Write(Html.Resource("UserAlreadySubmitedReview"));

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n");

            
            #line 146 "..\..\ResourcePackages\Bootstrap\MVC\Views\Reviews\Reviews.Default.cshtml"
        
        if (Model.RequiresAuthentication)
        {

            
            #line default
            #line hidden
WriteLiteral("            <div");

WriteLiteral(" class=\"alert alert-warning\"");

WriteLiteral(" data-sf-role=\"comments-new-requires-authentication\"");

WriteLiteral("><a");

WriteAttribute("href", Tuple.Create(" href=\'", 6886), Tuple.Create("\'", 6912)
            
            #line 149 "..\..\ResourcePackages\Bootstrap\MVC\Views\Reviews\Reviews.Default.cshtml"
                          , Tuple.Create(Tuple.Create("", 6893), Tuple.Create<System.Object, System.Int32>(Model.LoginPageUrl
            
            #line default
            #line hidden
, 6893), false)
);

WriteLiteral(">");

            
            #line 149 "..\..\ResourcePackages\Bootstrap\MVC\Views\Reviews\Reviews.Default.cshtml"
                                                                                                                          Write(Html.Resource("Login"));

            
            #line default
            #line hidden
WriteLiteral("</a>");

            
            #line 149 "..\..\ResourcePackages\Bootstrap\MVC\Views\Reviews\Reviews.Default.cshtml"
                                                                                                                                                     Write(Html.Resource("ToBeAbleToReview"));

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n");

            
            #line 150 "..\..\ResourcePackages\Bootstrap\MVC\Views\Reviews\Reviews.Default.cshtml"
        }
    }

            
            #line default
            #line hidden
WriteLiteral("    \r\n    <div");

WriteLiteral(" data-sf-role=\"single-comment-template\"");

WriteLiteral(">\r\n\r\n        <div");

WriteLiteral(" class=\"media sf-media\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"media-left sf-img-thmb\"");

WriteLiteral("> \r\n                <img");

WriteLiteral(" data-sf-role=\"comment-avatar\"");

WriteAttribute("src", Tuple.Create(" src=\"", 7198), Tuple.Create("\"", 7251)
            
            #line 157 "..\..\ResourcePackages\Bootstrap\MVC\Views\Reviews\Reviews.Default.cshtml"
, Tuple.Create(Tuple.Create("", 7204), Tuple.Create<System.Object, System.Int32>(Url.WidgetContent("assets/dist/img/dummy.jpg")
            
            #line default
            #line hidden
, 7204), false)
);

WriteLiteral(" width=\"40\"");

WriteLiteral(" height=\"40\"");

WriteLiteral("/>\r\n            </div>\r\n\r\n            <div");

WriteLiteral(" class=\"media-body sf-media-body\"");

WriteLiteral(">\r\n                <span");

WriteLiteral(" data-sf-role=\"comment-name\"");

WriteLiteral(" class=\"text-muted sf-Comments-list-author\"");

WriteLiteral("></span> | \r\n                <span");

WriteLiteral(" data-sf-role=\"comment-date\"");

WriteLiteral(" class=\"text-muted\"");

WriteLiteral("></span>\r\n\r\n                <div");

WriteLiteral(" data-sf-role=\"list-rating-wrapper\"");

WriteLiteral(" class=\"sf-Ratings\"");

WriteLiteral(">\r\n                    <span");

WriteLiteral(" data-sf-role=\"list-rating-container\"");

WriteLiteral(" class=\"sf-Ratings-stars sf-Ratings-stars--ronly\"");

WriteLiteral("></span>\r\n                    <span");

WriteLiteral(" class=\"text-muted sf-Ratings-average\"");

WriteLiteral(">\r\n                        (<span");

WriteLiteral(" data-sf-role=\"list-rating-value\"");

WriteLiteral("></span>)\r\n                    </span>\r\n                </div>\r\n\r\n               " +
" <p");

WriteLiteral(" data-sf-role=\"comment-message\"");

WriteLiteral("></p>\r\n\r\n            </div>\r\n\r\n        </div>\r\n\r\n    </div>\r\n</div>\r\n\r\n");

WriteLiteral("\r\n\r\n<div");

WriteLiteral(" data-sf-role=\"rating-template\"");

WriteLiteral("  style=\"display:none;\"");

WriteLiteral("><span>&#9733;</span></div>\r\n\r\n");

            
            #line 184 "..\..\ResourcePackages\Bootstrap\MVC\Views\Reviews\Reviews.Default.cshtml"
Write(Html.Script(Url.WidgetContent("Mvc/Scripts/Reviews/rating.js"), "bottom", false));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 185 "..\..\ResourcePackages\Bootstrap\MVC\Views\Reviews\Reviews.Default.cshtml"
Write(Html.Script(Url.WidgetContent("Mvc/Scripts/comments-list.js"), "bottom", false));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

        }
    }
}
#pragma warning restore 1591
