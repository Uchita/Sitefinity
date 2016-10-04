<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucJobFieldsMultiLingual.ascx.cs"
    Inherits="JXTPortal.Website.usercontrols.job.ucJobFieldsMultiLingual" %>
<%@ Register TagPrefix="uc1" Namespace="JXTPortal.Website.usercontrols.common" Assembly="JXTPortal.WebSite" %>

<asp:HiddenField ID="hfLanguageID" runat="server" />
<asp:Literal ID="ltDivLang" runat="server" />
<asp:PlaceHolder ID="phEnableLanguage" runat="server" Visible="false">
    <li class="checkbox-holder"><span class="custom-input">
        <asp:label ID="lbEnableLanguage" runat="server" AssociatedControlID="cbEnableLanguage">
            <input type="checkbox" id="cbEnableLanguage" runat="server" onchange="MultiLingualCheck();" />&nbsp;<asp:Literal
                ID="ltEnableLanguage" runat="server"  />
        </asp:label>
    </span></li>
</asp:PlaceHolder>
<li id="jobs-jobname-field">
    <asp:label ID="lbJobFieldJobName" runat="server" AssociatedControlID="txtJobName">
        <JXTControl:ucLanguageLiteral ID="ltJobFieldJobName" runat="server" SetLanguageCode="LabelJobName" /> <span class="form-required">*</span></asp:label>
    <div>
        <asp:TextBox ID="txtJobName" runat="server" autocomplete="off" />
        <asp:RequiredFieldValidator ID="ReqVal_JobName" runat="server" ControlToValidate="txtJobName"
            SetFocusOnError="true" Display="Dynamic" Enabled="false" />
    </div>
</li>
<li id="jobs-jobname-field">
    <asp:label ID="lbBulletPoint1" runat="server" AssociatedControlID="txtBulletPoint1">
        <JXTControl:ucLanguageLiteral ID="ltJobFieldBulletPoint1" runat="server" SetLanguageCode="LabelBulletPoint1" /></asp:label>
    <div>
        <asp:TextBox ID="txtBulletPoint1" runat="server" autocomplete="off" MaxLength="160" />
    </div>
</li>
<li id="jobs-jobname-field">
    <asp:label ID="lbBulletPoint2" runat="server" AssociatedControlID="txtBulletPoint2">
        <JXTControl:ucLanguageLiteral ID="ltJobFieldBulletPoint2" runat="server" SetLanguageCode="LabelBulletPoint2" /></asp:label>
    <div>
        <asp:TextBox ID="txtBulletPoint2" runat="server" autocomplete="off" MaxLength="160" />
    </div>
</li>
<li id="jobs-jobname-field">
    <asp:label ID="lbBulletPoint3" runat="server" AssociatedControlID="txtBulletPoint3">
        <JXTControl:ucLanguageLiteral ID="ltJobFieldBulletPoint3" runat="server" SetLanguageCode="LabelBulletPoint3" /></asp:label>
    <div>
        <asp:TextBox ID="txtBulletPoint3" runat="server" autocomplete="off" MaxLength="160" />
    </div>
</li>
<li id="jobs-description-field">
    <asp:label ID="lbDescription" runat="server" AssociatedControlID="txtDescription">
        <JXTControl:ucLanguageLiteral ID="ltJobFieldShortDescription" runat="server" SetLanguageCode="LabelShortDescription" /> <span class="form-required">*</span></asp:label>
    <div>
        <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Rows="3" Columns="20" /><asp:RequiredFieldValidator ID="ReqVal_Description" runat="server"
                ControlToValidate="txtDescription" SetFocusOnError="true" Display="Dynamic" Enabled="false" />
    </div>
</li>
<li id="jobs-description-field">
    <asp:label ID="lbFullDescription" runat="server" AssociatedControlID="txtFullDescription">
        <JXTControl:ucLanguageLiteral ID="ltJobFieldFullDescription" runat="server" SetLanguageCode="LabelFullDescription" /> <span class="form-required">*</span></asp:label>
    <div>
        <FredCK:CKEditorControl ID="txtFullDescription" runat="server" TextMode="MultiLine" Rows="3"
            Columns="20" CustomConfig="custom_config.js" Toolbar="SmallToolbar" EnableViewState="false" /></FredCK:CKEditorControl>
        <asp:RequiredFieldValidator ID="rvjobFieldFullDescription" runat="server" SetFocusOnError="true"
            Display="Dynamic" ControlToValidate="txtFullDescription" Enabled="false" />
    </div>
</li>
</div>