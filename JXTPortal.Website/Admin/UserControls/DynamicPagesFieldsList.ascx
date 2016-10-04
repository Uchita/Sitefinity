<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DynamicPagesFieldsList.ascx.cs"
    Inherits="JXTPortal.Website.Admin.UserControls.DynamicPagesFieldsList" %>
<div class="form-all">
    <span class="form-message">
        <asp:Literal ID="ltlMessage" runat="server" /></span>
    <ul class="form-section">
        <li class="form-line" id="Li1">
            <label class="form-label-left">
                Dynamic Page ID:</label>
            <div class="form-input">
                <asp:TextBox runat="server" ID="txtDynamicPageID" Enabled="false" />
            </div>
        </li>
        <li class="form-line" id="dyn-parentdynamicpage-field">
            <label class="form-label-left">
                Parent Dynamic Page:</label>
            <div class="form-input">
                <asp:DropDownList ID="ddlParentDynamicPage" runat="server" CssClass="form-multiple-column"
                    Enabled="true" />
                <asp:HiddenField ID="hiddenFieldLanguageID" runat="server" />
            </div>
        </li>
        <li class="form-line" id="dyn-pagetitle-field">
            <label class="form-label-left">
                Page Title:<span class="form-required">*</span></label>
            <div class="form-input">
                <asp:TextBox runat="server" ID="txtPageTitle" Width="250px"></asp:TextBox>
                <asp:PlaceHolder ID="phPageTitleError" runat="server" Visible="false"><span style="color: red;
                    display: inline;">Required</span> </asp:PlaceHolder>
            </div>
        </li>
        <li class="form-line" id="dyn-dynamicpagewebparttemplate-field">
            <label class="form-label-left">
                Dynamic Page Web Container:<span class="form-required">*</span></label>
            <div class="form-input">
                <asp:DropDownList runat="server" ID="ddlDynamicPageWebPartTemplate" CssClass="form-multiple-column">
                </asp:DropDownList>
                <asp:PlaceHolder ID="phDynamicPageWebPartTemplateError" runat="server" Visible="false">
                    <span style="color: red; display: inline;">Required</span> </asp:PlaceHolder>
            </div>
        </li>
        <li class="form-line" id="Li3">
            <label class="form-label-left">
                Update Child Pages Container:</label>
            <div class="form-input">
                <asp:CheckBox id="cbUpdateChildPages" runat="server" />
            </div>
        </li>
        <li class="form-line" id="Li4">
            <label class="form-label-left">&nbsp;</label>
            <div class="form-input" style="display: inline;">
                <i>By checking this box, you will be overwriting all the child pages with the above web container template.</i>
            </div>
        </li>
        
        <li class="form-line" id="dyn-pagecontent-field">
            <label class="form-label-left">
                Page Content:</label>
            <div class="form-input">
                <FredCK:CKEditorControl ID="txtPageContent" runat="server" Width="650px" Height="400px"
                    CustomConfig="custom_config.js">
                </FredCK:CKEditorControl>
            </div>
        </li>
        <li class="form-line" id="dyn-searchable-field">
            <label class="form-label-left">
                Searchable:</label>
            <div class="form-input">
                <asp:CheckBox ID="cbSearchable" runat="server" />
            </div>
        </li>
        <li class="form-line" id="Li2">
            <label class="form-label-left">
                Meta Title:
            </label>
            <div class="form-input">
                <asp:TextBox ID="txtMetaTitle" runat="server" TextMode="MultiLine" Rows="6" Columns="40" />&nbsp;<span
                    id="spTitleCount"></span>
            </div>
        </li>
        <li class="form-line" id="dyn-metakeywords-field">
            <label class="form-label-left">
                Meta Keywords:</label>
            <div class="form-input">
                <asp:TextBox ID="txtMetaKeywords" runat="server" TextMode="MultiLine" Rows="6" Columns="40" />&nbsp;<span
                    id="spKeywordsCount"></span>
            </div>
        </li>
        <li class="form-line" id="dyn-metadescription-field">
            <label class="form-label-left">
                Meta Description:</label>
            <div class="form-input">
                <asp:TextBox ID="txtMetaDescription" runat="server" TextMode="MultiLine" Rows="6"
                    Columns="40" />&nbsp;<span id="spDescriptionCount"></span>
            </div>
        </li>
        <%--<li class="form-line" id="dyn-pagefriendlyname-field">
            <label class="form-label-left">
                Page Friendly Name:</label>
            <div class="form-input">
                <asp:Label runat="server" ID="txtPageFriendlyName" Width="250px"></asp:Label>
            </div>
        </li>--%>
        <li class="form-line" id="dyn-lastmodified-field">
            <label class="form-label-left">
                Last Modified:</label>
            <div class="form-input">
                <asp:Label runat="server" ID="lblLastModified" MaxLength="10"></asp:Label>
            </div>
        </li>
        <li class="form-line" id="dyn-lastmodifiedby-field">
            <label class="form-label-left">
                Last Modified By:</label>
            <div class="form-input">
                <asp:Label ID="lblLastModifiedBy" runat="server" />
            </div>
        </li>
    </ul>
</div>
