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

namespace SitefinityWebApp.ResourcePackages.Bootstrap.MVC.Views.DropdownListField
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
    
    #line 4 "..\..\ResourcePackages\Bootstrap\MVC\Views\DropdownListField\Write.Default.cshtml"
    using Telerik.Sitefinity.Frontend.Forms.Mvc.Helpers;
    
    #line default
    #line hidden
    
    #line 5 "..\..\ResourcePackages\Bootstrap\MVC\Views\DropdownListField\Write.Default.cshtml"
    using Telerik.Sitefinity.Frontend.Mvc.Helpers;
    
    #line default
    #line hidden
    
    #line 6 "..\..\ResourcePackages\Bootstrap\MVC\Views\DropdownListField\Write.Default.cshtml"
    using Telerik.Sitefinity.Modules.Pages;
    
    #line default
    #line hidden
    
    #line 3 "..\..\ResourcePackages\Bootstrap\MVC\Views\DropdownListField\Write.Default.cshtml"
    using Telerik.Sitefinity.UI.MVC;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/ResourcePackages/Bootstrap/MVC/Views/DropdownListField/Write.Default.cshtml")]
    public partial class Write_Default : System.Web.Mvc.WebViewPage<Telerik.Sitefinity.Frontend.Forms.Mvc.Models.Fields.DropdownListField.DropdownListFieldViewModel>
    {
        public Write_Default()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 8 "..\..\ResourcePackages\Bootstrap\MVC\Views\DropdownListField\Write.Default.cshtml"
Write(Html.Script(ScriptRef.JQuery, "top", false));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<div");

WriteAttribute("class", Tuple.Create(" class=\"", 342), Tuple.Create("\"", 376)
            
            #line 10 "..\..\ResourcePackages\Bootstrap\MVC\Views\DropdownListField\Write.Default.cshtml"
, Tuple.Create(Tuple.Create("", 350), Tuple.Create<System.Object, System.Int32>(Model.CssClass
            
            #line default
            #line hidden
, 350), false)
, Tuple.Create(Tuple.Create(" ", 365), Tuple.Create("form-group", 366), true)
);

WriteLiteral(" data-sf-role=\"dropdown-list-field-container\"");

WriteLiteral(">\r\n    <input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" data-sf-role=\"violation-messages\"");

WriteAttribute("value", Tuple.Create(" value=\'", 483), Tuple.Create("\'", 539)
, Tuple.Create(Tuple.Create("", 491), Tuple.Create("{", 491), true)
, Tuple.Create(Tuple.Create(" ", 492), Tuple.Create("\"required\":", 493), true)
, Tuple.Create(Tuple.Create(" ", 504), Tuple.Create("\"", 505), true)
            
            #line 11 "..\..\ResourcePackages\Bootstrap\MVC\Views\DropdownListField\Write.Default.cshtml"
  , Tuple.Create(Tuple.Create("", 506), Tuple.Create<System.Object, System.Int32>(Model.RequiredViolationMessage
            
            #line default
            #line hidden
, 506), false)
, Tuple.Create(Tuple.Create("", 537), Tuple.Create("\"}", 537), true)
);

WriteLiteral(" />\r\n    <label");

WriteAttribute("for", Tuple.Create(" for=\'", 555), Tuple.Create("\'", 587)
            
            #line 12 "..\..\ResourcePackages\Bootstrap\MVC\Views\DropdownListField\Write.Default.cshtml"
, Tuple.Create(Tuple.Create("", 561), Tuple.Create<System.Object, System.Int32>(Html.UniqueId("Dropdown")
            
            #line default
            #line hidden
, 561), false)
);

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 13 "..\..\ResourcePackages\Bootstrap\MVC\Views\DropdownListField\Write.Default.cshtml"
   Write(Model.MetaField.Title);

            
            #line default
            #line hidden
WriteLiteral("\r\n    </label>\r\n");

            
            #line 15 "..\..\ResourcePackages\Bootstrap\MVC\Views\DropdownListField\Write.Default.cshtml"
    
            
            #line default
            #line hidden
            
            #line 15 "..\..\ResourcePackages\Bootstrap\MVC\Views\DropdownListField\Write.Default.cshtml"
     if (!string.IsNullOrEmpty(Model.MetaField.Description)) 
    { 

            
            #line default
            #line hidden
WriteLiteral("        <p");

WriteLiteral(" class=\"text-muted\"");

WriteLiteral(">");

            
            #line 17 "..\..\ResourcePackages\Bootstrap\MVC\Views\DropdownListField\Write.Default.cshtml"
                         Write(Model.MetaField.Description);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n");

            
            #line 18 "..\..\ResourcePackages\Bootstrap\MVC\Views\DropdownListField\Write.Default.cshtml"
    } 

            
            #line default
            #line hidden
WriteLiteral("\r\n    <select");

WriteAttribute("id", Tuple.Create(" id=\'", 793), Tuple.Create("\'", 824)
            
            #line 20 "..\..\ResourcePackages\Bootstrap\MVC\Views\DropdownListField\Write.Default.cshtml"
, Tuple.Create(Tuple.Create("", 798), Tuple.Create<System.Object, System.Int32>(Html.UniqueId("Dropdown")
            
            #line default
            #line hidden
, 798), false)
);

WriteLiteral(" data-sf-role=\"dropdown-list-field-select\"");

WriteAttribute("name", Tuple.Create(" name=\"", 867), Tuple.Create("\"", 900)
            
            #line 20 "..\..\ResourcePackages\Bootstrap\MVC\Views\DropdownListField\Write.Default.cshtml"
             , Tuple.Create(Tuple.Create("", 874), Tuple.Create<System.Object, System.Int32>(Model.MetaField.FieldName
            
            #line default
            #line hidden
, 874), false)
);

WriteLiteral(" ");

            
            #line 20 "..\..\ResourcePackages\Bootstrap\MVC\Views\DropdownListField\Write.Default.cshtml"
                                                                                                                   Write(MvcHtmlString.Create(Model.ValidationAttributes));

            
            #line default
            #line hidden
WriteLiteral(" class=\"form-control\">\r\n");

            
            #line 21 "..\..\ResourcePackages\Bootstrap\MVC\Views\DropdownListField\Write.Default.cshtml"
    
            
            #line default
            #line hidden
            
            #line 21 "..\..\ResourcePackages\Bootstrap\MVC\Views\DropdownListField\Write.Default.cshtml"
     foreach (var choice in Model.Choices)
    {
        string value = !string.IsNullOrEmpty(Model.Value as string) ? Model.Value as string : string.Empty;
 		bool isSelected = (!string.IsNullOrEmpty(value) && choice == value) ||
 						  (string.IsNullOrEmpty(value) && !Model.IsRequired && choice == Model.MetaField.DefaultValue as string);
 
 		var optionAttributes = isSelected ? "selected" : string.Empty;
        var optionValue = Model.IsRequired && choice == Model.Choices.FirstOrDefault() ? string.Empty : choice;


            
            #line default
            #line hidden
WriteLiteral("        <option ");

            
            #line 30 "..\..\ResourcePackages\Bootstrap\MVC\Views\DropdownListField\Write.Default.cshtml"
           Write(optionAttributes);

            
            #line default
            #line hidden
WriteLiteral(" value=\"");

            
            #line 30 "..\..\ResourcePackages\Bootstrap\MVC\Views\DropdownListField\Write.Default.cshtml"
                                    Write(optionValue);

            
            #line default
            #line hidden
WriteLiteral("\">");

            
            #line 30 "..\..\ResourcePackages\Bootstrap\MVC\Views\DropdownListField\Write.Default.cshtml"
                                                  Write(choice);

            
            #line default
            #line hidden
WriteLiteral("</option>\r\n");

            
            #line 31 "..\..\ResourcePackages\Bootstrap\MVC\Views\DropdownListField\Write.Default.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("    </select>\r\n    \r\n</div>\r\n\r\n");

            
            #line 36 "..\..\ResourcePackages\Bootstrap\MVC\Views\DropdownListField\Write.Default.cshtml"
Write(Html.Script(Url.WidgetContent("Mvc/Scripts/DropdownListField/dropdown-list-field.js"), "bottom", false));

            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591