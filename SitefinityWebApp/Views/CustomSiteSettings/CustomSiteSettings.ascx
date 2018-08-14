﻿<%@ Control Language="C#" %>
<%@ Register Namespace="Telerik.Sitefinity.Web.UI.Fields" TagPrefix="sitefinity" Assembly="Telerik.Sitefinity" %>

<h2>
    <asp:Literal runat="server" ID="lGeneralSettings" Text="Custom Site Settings" />
</h2>

<h3>GOOGLE SETTINGS</h3><br />
<sitefinity:TextField ID="googleClientId" runat="server" DataFieldName="GoogleClientId" Title="Please Enter Google Client ID" CssClass="sfSettingsSection" DisplayMode="Write" />
<sitefinity:TextField ID="googleClientSecret" runat="server" DataFieldName="GoogleClientSecret" Title="Please Enter Google Client Secret" CssClass="sfSettingsSection" DisplayMode="Write" />
<sitefinity:TextField ID="googleClientAPIKey" runat="server" DataFieldName="GoogleClientAPIKey" Title="Please Enter Google API Key" CssClass="sfSettingsSection" DisplayMode="Write" />

<h3>GOOGLE MAPS API SETTINGS</h3><br />
<sitefinity:TextField ID="googleAPIKey" runat="server" DataFieldName="GoogleAPIKey" Title="Please Enter Google Maps API Key" CssClass="sfSettingsSection" DisplayMode="Write" />
<br />
<h3>DROPBOX SETTINGS</h3><br />
<sitefinity:TextField ID="dropboxAppId" runat="server" DataFieldName="DropboxAppId" Title="Please Enter Dropbox Application ID" CssClass="sfSettingsSection" DisplayMode="Write" />
<sitefinity:TextField ID="dropboxAppSecret" runat="server" DataFieldName="DropboxAppSecret" Title="Please Enter Dropbox Application Secret" CssClass="sfSettingsSection" DisplayMode="Write" />