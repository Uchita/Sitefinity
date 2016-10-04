<%@ Page Language="C#" MasterPageFile="~/MasterPages/admin.Master" AutoEventWireup="true" CodeBehind="CampaignEdit.aspx.cs" Inherits="JXTPortal.Website.Admin.CampaignEdit" Title="Campaign Creation Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">Campaign Creation Page
<a href='http://support.jxt.com.au/solution/articles/116436-campaign-creation' class='jxt-help-page' title='click here for help on this page'  target='_blank'>help on this page</a>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="form-all">
    
    <br />
    
    <ul class="form-section">
        <li class="form-line" id="reg-username-field">
            <label class="form-label-left">
                Campaign Name:<span class="form-required">*</span>
            </label>
            <div class="form-input">
                <asp:TextBox ID="txtPageName" runat="server" style="width:250px;" /> <asp:RequiredFieldValidator ID="ReqVal_PageName"
                    runat="server" Display="Dynamic" ControlToValidate="txtPageName" ErrorMessage="Required"
                    SetFocusOnError="true"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="ReqVal_PageName_validation" runat="server" Display="Dynamic"
                                ControlToValidate="txtPageName" ValidationExpression="^[a-zA-Z0-9_\s]*$" ErrorMessage="Campaign name only allows letters and numbers" />
                    <br /><div class="form-notation">name of the campaign (only allows letters, numbers and underscore)</div>
                <asp:HiddenField ID="hiddenID" runat="server" />
            </div>
        </li>
        <li class="form-line">
            <label class="form-label-left">
                Keyword Nomination <br />(Campaign URL):<span class="form-required">*</span></label>
            <div class="form-input">
                <asp:TextBox ID="txtPageFriendlyName" runat="server" style="width:250px;" /> <asp:RequiredFieldValidator ID="ReqVal_PageFriendlyName"
                    runat="server" Display="Dynamic" ControlToValidate="txtPageFriendlyName" ErrorMessage="Required"
                    SetFocusOnError="true"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="Dynamic"
                                ControlToValidate="txtPageFriendlyName" ValidationExpression="^[a-zA-Z0-9_-]*$" ErrorMessage="Keyword Nomination only allows letters, numbers, underscore or hyphen" />
                    <br /><div class="form-notation">keyword which will be added to end of campaign URL (only allows letters, numbers, underscore or hyphen)</div>
            </div>
        </li>

        <li class="form-line">
            <label class="form-label-left">
                Tag code Nomination:<span class="form-required">*</span></label>
            <div class="form-input">
                <asp:TextBox ID="txtTagCode" runat="server" style="width:250px;" /> <asp:RequiredFieldValidator ID="ReqVal_TagCode"
                    runat="server" Display="Dynamic" ControlToValidate="txtTagCode" ErrorMessage="Required"
                    SetFocusOnError="true"></asp:RequiredFieldValidator>
                    <br /><div class="form-notation">This must be entered exactly in the tags section when you are creating a Job</div>
            </div>
        </li>
        
        <li class="form-line" id="dyn-pagecontent-field">
            <label class="form-label-left">
                Campaign Details:</label>
            <div class="form-input">
                <FredCK:CKEditorControl ID="txtPageContent" runat="server" Width="650px" Height="400px"
                    CustomConfig="custom_config.js" Toolbar="FullToolbar" EnableViewState="false">
                </FredCK:CKEditorControl>
            <br />
            <div class="form-notation">add the details of the campaign into the editor</div>
            </div>
        </li>

        
        <li class="form-line">
            <label class="form-label-left">
                Valid:</label>
            <div id="cid_21" class="form-input">
                <div class="form-single-column">
                    <asp:CheckBox ID="chkValid" runat="server" />  
                    <span class="clearfix"></span>
                </div>
            </div>
        </li>
        
        <li class="form-line">
            <label class="form-label-left">
                Last Modified:</label>
            <div class="form-input">
                <asp:Literal runat="server" ID="ltlLastModified" />
            </div>
        </li>
        
        <li class="form-line">
            <label class="form-label-left"></label>
            <div class="form-input">                
                <asp:Button ID="btnCreateCampaign" runat="server" Text="Create Campaign" 
                    CssClass="jxtadminbutton" onclick="btnCreateCampaign_Click" />
                <asp:HyperLink ID="hypLinkViewPage" runat="server" Text="View Campaign" Target="_blank" Visible="false" />
                <span class="form-required"><asp:Literal ID="ltlMessage" runat="server" /></span>
            </div>
        </li>

        
        <li class="form-line">
            <label class="form-label-left">
                Campaign Url:</label>
            <div class="form-input">
                <asp:TextBox runat="server" ID="txtCampaignUrl" ReadOnly="true" style="width:500px;" />
                <br /><div class="form-notation">nominated keyword is added to end of string</div>
            </div>
        </li>

    </ul>

    <br />
    <asp:Button ID="btnCampaignList" runat="server" Text="Go back to Campaign List" 
        CssClass="jxtadminbutton" onclick="btnCampaignList_Click" />
</div>

</asp:Content>
