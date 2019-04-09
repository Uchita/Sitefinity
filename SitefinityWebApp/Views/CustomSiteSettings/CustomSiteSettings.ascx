<%@ Control Language="C#" %>
<%@ Register Namespace="Telerik.Sitefinity.Web.UI.Fields" TagPrefix="sitefinity" Assembly="Telerik.Sitefinity" %>

<h2>
    <asp:Literal runat="server" ID="lGeneralSettings" Text="Custom Site Settings" />
</h2>

<h3>GOOGLE SETTINGS</h3><br />
<sitefinity:TextField ID="googleClientId" runat="server" DataFieldName="GoogleClientId" Title="Please Enter Google Client ID" CssClass="sfSettingsSection" DisplayMode="Write" />
<sitefinity:TextField ID="googleClientSecret" runat="server" DataFieldName="GoogleClientSecret" Title="Please Enter Google Client Secret" CssClass="sfSettingsSection" DisplayMode="Write" />
<sitefinity:TextField ID="googleClientAPIKey" runat="server" DataFieldName="GoogleClientAPIKey" Title="Please Enter Google API Key" CssClass="sfSettingsSection" DisplayMode="Write" />
<sitefinity:TextField ID="googleTagManagerKey" runat="server" DataFieldName="GoogleTagManagerKey" Title="Please Enter Google TagManager Key" CssClass="sfSettingsSection" DisplayMode="Write" />

<h3>GOOGLE MAPS API SETTINGS</h3><br />
<sitefinity:TextField ID="googleAPIKey" runat="server" DataFieldName="GoogleAPIKey" Title="Please Enter Google Maps API Key" CssClass="sfSettingsSection" DisplayMode="Write" />
<br />

<h3>DROPBOX SETTINGS</h3><br />
<sitefinity:TextField ID="dropboxAppId" runat="server" DataFieldName="DropboxAppId" Title="Please Enter Dropbox Application ID" CssClass="sfSettingsSection" DisplayMode="Write" />
<sitefinity:TextField ID="dropboxAppSecret" runat="server" DataFieldName="DropboxAppSecret" Title="Please Enter Dropbox Application Secret" CssClass="sfSettingsSection" DisplayMode="Write" />
<sitefinity:TextField ID="dropboxClientAPIKey" runat="server" DataFieldName="DropboxClientAPIKey" Title="Please Enter Dropbox API Key" CssClass="sfSettingsSection" DisplayMode="Write" />
<br />

<h3>SEEK SETTINGS</h3><br />
<sitefinity:TextField ID="seekClientId" runat="server" DataFieldName="SeekClientId" Title="Please Enter Seek Client ID" CssClass="sfSettingsSection" DisplayMode="Write" />
<sitefinity:TextField ID="seekClientSecret" runat="server" DataFieldName="SeekClientSecret" Title="Please Enter Seek Client Secret" CssClass="sfSettingsSection" DisplayMode="Write" />
<sitefinity:TextField ID="seekClientAdvertiserId" runat="server" DataFieldName="SeekClientAdvertiserId" Title="Please Enter Seek Client Advertiser ID" CssClass="sfSettingsSection" DisplayMode="Write" />
<sitefinity:TextField ID="seekRedirectUri" runat="server" DataFieldName="SeekRedirectUri" Title="Please Enter Seek redirect Uri" CssClass="sfSettingsSection" DisplayMode="Write" />
<br />

<h3>INDEED SETTINGS</h3><br />
<sitefinity:TextField ID="indeedClientAPIToken" runat="server" DataFieldName="IndeedClientAPIToken" Title="Please Enter Indeed Client API Token" CssClass="sfSettingsSection" DisplayMode="Write" />
<sitefinity:TextField ID="indeedClientSecret" runat="server" DataFieldName="IndeedClientSecret" Title="Please Enter Indeed Client Secret" CssClass="sfSettingsSection" DisplayMode="Write" />

<h3>LINKED-IN SETTINGS</h3><br />
<sitefinity:TextField ID="linkedinClientId" runat="server" DataFieldName="LinkedInClientId" Title="Please Enter LinkedIn Client ID" CssClass="sfSettingsSection" DisplayMode="Write" />
<sitefinity:TextField ID="linkedinClientSecret" runat="server" DataFieldName="LinkedInClientSecret" Title="Please Enter LinkedIn Client Secret" CssClass="sfSettingsSection" DisplayMode="Write" />
<sitefinity:TextField ID="linkedinCustomerClientId" runat="server" DataFieldName="LinkedInCustomerClientId" Title="Please Enter LinkedIn Customer Client ID" CssClass="sfSettingsSection" DisplayMode="Write" />
<sitefinity:TextField ID="linkedinCustomerClientSecret" runat="server" DataFieldName="LinkedInCustomerClientSecret" Title="Please Enter LinkedIn Customer Client Secret" CssClass="sfSettingsSection" DisplayMode="Write" />
<sitefinity:TextField ID="linkedinCustomerIntegrationContext" runat="server" DataFieldName="LinkedInCustomerIntegrationContext" Title="Please Enter LinkedIn Customer Integration Context" CssClass="sfSettingsSection" DisplayMode="Write" />
<sitefinity:TextField ID="linkedinSocialHandlerUrl" runat="server" DataFieldName="LinkedInSocialHandlerUrl" Title="Please Enter LinkedIn Social Handler URL" CssClass="sfSettingsSection" DisplayMode="Write" />
<br />

<h3>INSTAGRAM SETTINGS</h3><br />
<sitefinity:TextField ID="instagramClientIdToken" runat="server" DataFieldName="InstagramClientIdToken" Title="Please Enter Instagram Client Id Token" CssClass="sfSettingsSection" DisplayMode="Write" />
<sitefinity:TextField ID="instagramClientSecret" runat="server" DataFieldName="InstagramClientSecret" Title="Please Enter Instagram Client Secret" CssClass="sfSettingsSection" DisplayMode="Write" />
<sitefinity:TextField ID="instagramAccessToken" runat="server" DataFieldName="InstagramAccessToken" Title="Please Enter Instagram Access Token" CssClass="sfSettingsSection" DisplayMode="Write" />
<sitefinity:TextField ID="instagramExpiration" runat="server" DataFieldName="InstagramExpiration" Title="Please Enter Instagram Expiration" CssClass="sfSettingsSection" DisplayMode="Write" />
<sitefinity:TextField ID="instagramMaxItems" runat="server" DataFieldName="InstagramMaxItems" Title="Please Enter Instagram Max Items" CssClass="sfSettingsSection" DisplayMode="Write" />
