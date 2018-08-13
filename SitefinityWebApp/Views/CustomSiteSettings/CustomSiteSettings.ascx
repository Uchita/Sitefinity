<%@ Control Language="C#" %>
<%@ Register Namespace="Telerik.Sitefinity.Web.UI.Fields" TagPrefix="sitefinity" Assembly="Telerik.Sitefinity" %>

<h2>
    <asp:Literal runat="server" ID="lGeneralSettings" Text="Custom Site Settings" />
</h2>

<sitefinity:TextField ID="googleAPIKey" runat="server" DataFieldName="GoogleAPIKey" Title="Please Enter Google Maps API Key" CssClass="sfSettingsSection" DisplayMode="Write" />
