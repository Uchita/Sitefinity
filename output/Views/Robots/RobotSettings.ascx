<%@ Control Language="C#" %>
<%@ Register Namespace="Telerik.Sitefinity.Web.UI.Fields" TagPrefix="sitefinity" Assembly="Telerik.Sitefinity" %>

<h2>
    <asp:Literal runat="server" ID="lGeneralSettings" Text="Robot Settings" />
</h2>

<sitefinity:TextField ID="robotTextData" runat="server" DataFieldName="RobotTextData" Title="Please Enter Robot Text Data" CssClass="sfSettingsSection" DisplayMode="Write" />
