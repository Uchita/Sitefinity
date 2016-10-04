<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DynamicPageRevisionsFields.ascx.cs"
    Inherits="JXTPortal.Website.Admin.UserControls.DynamicPageRevisionsFields" %>
<ul class="form-section">
    <li class="form-line" id="Li1">
        <asp:Label ID="Label1" runat="server" AssociatedControlID="ddlParentDynamicPage"
            CssClass="form-label-left">
                                        Dynamic Page ID</asp:Label>
        <div class="form-input">
            <asp:Literal ID="txtDynamicPageID" runat="server" />
        </div>
        <asp:HiddenField ID="hfRevisionID" runat="server" />
    </li>
    <li class="form-line" id="Li2">
        <asp:Label ID="lbParentDynamicPage" runat="server" AssociatedControlID="ddlParentDynamicPage"
            CssClass="form-label-left">
                                        Parent Page</asp:Label>
        <div class="form-input">
            <asp:DropDownList ID="ddlParentDynamicPage" runat="server" CssClass="form-multiple-column"
                Enabled="true" />
            <asp:HiddenField ID="hiddenFieldLanguageID" runat="server" />
        </div>
    </li>
    <li class="form-line" id="Li3">
        <asp:Label ID="lbPageTitle" runat="server" AssociatedControlID="txtPageTitle" CssClass="form-label-left">
                                        Page Title <span class="required">*</span></asp:Label>
        <div class="form-input">
            <asp:TextBox runat="server" ID="txtPageTitle" Width="250px"></asp:TextBox>
            <asp:PlaceHolder ID="phPageTitleError" runat="server" Visible="false"><span style="color: red;
                display: inline;">Required</span> </asp:PlaceHolder>
        </div>
    </li>
    <li class="form-line" id="Li4">
        <asp:Label ID="lbPageTheme" runat="server" AssociatedControlID="ddlDynamicPageWebPartTemplate"
            CssClass="form-label-left">
                                        Page Theme <span class="required">*</span></asp:Label>
        <div class="form-input">
            <asp:DropDownList runat="server" ID="ddlDynamicPageWebPartTemplate" CssClass="form-multiple-column">
            </asp:DropDownList>
            <asp:PlaceHolder ID="phDynamicPageWebPartTemplateError" runat="server" Visible="false">
                <span style="color: red; display: inline;">Required</span> </asp:PlaceHolder>
        </div>
    </li>
    <li class="form-line" id="Li7">
        <asp:Label ID="lbUpdateChildPages" runat="server" AssociatedControlID="cbUpdateChildPages"
            CssClass="form-label-left">
                                        Update Child Pages</asp:Label>
        <div class="form-input">
            <asp:CheckBox ID="cbUpdateChildPages" runat="server" />
        </div>
    </li>
    <li class="form-line" id="Li8">
        <label class="form-label-left">
            &nbsp;</label>
        <div class="form-input" style="display: inline;">
            <i>By checking this box, you will be overwriting all the child pages with the above
                web container template.</i>
        </div>
    </li>
    <li class="form-line" id="Li5">
        <asp:Label ID="lbPageContent" runat="server" AssociatedControlID="txtPageContent"
            CssClass="form-label-left">Content</asp:Label>
        <div class="form-input">
            <FredCK:CKEditorControl ID="txtPageContent" runat="server" Width="650px" Height="400px"
                CustomConfig="custom_config.js">
            </FredCK:CKEditorControl>
        </div>
    </li>
    <li class="form-line" id="Li6">
        <asp:Label ID="lbSearchable" runat="server" AssociatedControlID="cbSearchable" CssClass="form-label-left">
                                        Searchable</asp:Label>
        <div class="form-input">
            <asp:CheckBox ID="cbSearchable" runat="server" />
        </div>
    </li>
    <li class="form-line" id="Li10">
        <asp:Label ID="lbMetaTitle" runat="server" AssociatedControlID="txtPageContent" CssClass="form-label-left">Meta Title</asp:Label>
        <div class="form-input">
            <asp:TextBox runat="server" ID="txtMetaTitle" TextMode="MultiLine" Columns="60"></asp:TextBox><br /><span
                    id="spTitleCount"></span>
        </div>
    </li>
    <li class="form-line" id="Li11">
        <asp:Label ID="lbMetaKeywords" runat="server" AssociatedControlID="txtMetaKeywords"
            CssClass="form-label-left">Meta Keywords</asp:Label>
        <div class="form-input">
            <asp:TextBox runat="server" ID="txtMetaKeywords" TextMode="MultiLine" Columns="60"
                Rows="10"></asp:TextBox><br /><span
                    id="spKeywordsCount"></span>
        </div>
    </li>
    <li class="form-line" id="Li12">
        <asp:Label ID="lbMetaDescription" runat="server" AssociatedControlID="txtMetaDescription"
            CssClass="form-label-left">Meta Description</asp:Label>
        <div class="form-input">
            <asp:TextBox runat="server" ID="txtMetaDescription" TextMode="MultiLine" Columns="60"
                Rows="10"></asp:TextBox><br /><span id="spDescriptionCount"></span>
        </div>
    </li>
</ul>
