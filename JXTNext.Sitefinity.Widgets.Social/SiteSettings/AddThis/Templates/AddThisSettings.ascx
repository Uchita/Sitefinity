<%@ Control Language="C#" %>
<%@ Register Namespace="Telerik.Sitefinity.Web.UI.Fields" TagPrefix="sitefinity" Assembly="Telerik.Sitefinity" %>

<h2>
    <asp:Literal runat="server" ID="lGeneralSettings" Text="AddThis Settings" />
</h2>

<sitefinity:TextField
    ID="publisherId"
    Title="Publisher ID"
    DataFieldName="PublisherId"
    CssClass="sfSettingsSection"
    DisplayMode="Write"
    runat="server" />

<table class="add-this-services">
    <thead>
        <tr>
            <th>Service</th>
            <th>Enabled</th>
            <th>Icon Class</th>
            <th>Image URL</th>
            <th>Position</th>
        </tr>
    </thead>

    <tbody>
        <tr>
            <td>Facebook</td>
            <td>
                <sitefinity:ChoiceField
                    ID="facebookEnabled"
                    DataFieldName="FacebookEnabled"
                    DisplayMode="Write"
                    RenderChoicesAs="SingleCheckBox"
                    DataItemType="bool"
                    runat="server">
                    <Choices>
                        <sitefinity:ChoiceItem Value="true" />
                    </Choices>
                </sitefinity:ChoiceField>
            </td>
            <td>
                <sitefinity:TextField
                    ID="facebookIcon"
                    DataFieldName="FacebookIcon"
                    DisplayMode="Write"
                    runat="server" />
            </td>
            <td>
                <sitefinity:TextField
                    ID="facebookImage"
                    DataFieldName="FacebookImage"
                    DisplayMode="Write"
                    runat="server" />
            </td>
            <td>
                <sitefinity:TextField
                    ID="facebookPosition"
                    DataFieldName="FacebookPosition"
                    DisplayMode="Write"
                    runat="server" />
            </td>
        </tr>

        <tr>
            <td>Twitter</td>
            <td>
                <sitefinity:ChoiceField
                    ID="twitterEnabled"
                    DataFieldName="TwitterEnabled"
                    DisplayMode="Write"
                    RenderChoicesAs="SingleCheckBox"
                    DataItemType="bool"
                    runat="server">
                    <Choices>
                        <sitefinity:ChoiceItem Value="true" />
                    </Choices>
                </sitefinity:ChoiceField>
            </td>
            <td>
                <sitefinity:TextField
                    ID="twitterIcon"
                    DataFieldName="TwitterIcon"
                    DisplayMode="Write"
                    runat="server" />
            </td>
            <td>
                <sitefinity:TextField
                    ID="twitterImage"
                    DataFieldName="TwitterImage"
                    DisplayMode="Write"
                    runat="server" />
            </td>
            <td>
                <sitefinity:TextField
                    ID="twitterPosition"
                    DataFieldName="TwitterPosition"
                    DisplayMode="Write"
                    runat="server" />
            </td>
        </tr>

        <tr>
            <td>LinkedIn</td>
            <td>
                <sitefinity:ChoiceField
                    ID="linkedInEnabled"
                    DataFieldName="LinkedInEnabled"
                    DisplayMode="Write"
                    RenderChoicesAs="SingleCheckBox"
                    DataItemType="bool"
                    runat="server">
                    <Choices>
                        <sitefinity:ChoiceItem Value="true" />
                    </Choices>
                </sitefinity:ChoiceField>
            </td>
            <td>
                <sitefinity:TextField
                    ID="linkedInIcon"
                    DataFieldName="LinkedInIcon"
                    DisplayMode="Write"
                    runat="server" />
            </td>
            <td>
                <sitefinity:TextField
                    ID="linkedInImage"
                    DataFieldName="LinkedInImage"
                    DisplayMode="Write"
                    runat="server" />
            </td>
            <td>
                <sitefinity:TextField
                    ID="linkedInPosition"
                    DataFieldName="LinkedInPosition"
                    DisplayMode="Write"
                    runat="server" />
            </td>
        </tr>

        <tr>
            <td>WeChat</td>
            <td>
                <sitefinity:ChoiceField
                    ID="weChatEnabled"
                    DataFieldName="WeChatEnabled"
                    DisplayMode="Write"
                    RenderChoicesAs="SingleCheckBox"
                    DataItemType="bool"
                    runat="server">
                    <Choices>
                        <sitefinity:ChoiceItem Value="true" />
                    </Choices>
                </sitefinity:ChoiceField>
            </td>
            <td>
                <sitefinity:TextField
                    ID="weChatIcon"
                    DataFieldName="WeChatIcon"
                    DisplayMode="Write"
                    runat="server" />
            </td>
            <td>
                <sitefinity:TextField
                    ID="weChatImage"
                    DataFieldName="WeChatImage"
                    DisplayMode="Write"
                    runat="server" />
            </td>
            <td>
                <sitefinity:TextField
                    ID="weChatPosition"
                    DataFieldName="WeChatPosition"
                    DisplayMode="Write"
                    runat="server" />
            </td>
        </tr>
    </tbody>
</table>
<p>Icon Class - e.g fab fa-facebook</p>
<p>Image URL - e.g https://www.example.com/images/facebook.png</p>
<p>If both icon and image is specified then icon is used.</p>

<hr />

<h2>
    <asp:Literal runat="server" ID="lViewSettings" Text="View Settings" />
</h2>

<p>View settings may be overridden at widget level.</p><br />

<sitefinity:TextField
    ID="cssClass"
    Title="CSS Class"
    DataFieldName="CssClass"
    CssClass="sfSettingsSection"
    DisplayMode="Write"
    runat="server" />

<style type="text/css">
    .add-this-services
    {
        padding: 0;
        margin: 0;
        border-collapse: collapse;
    }

    .add-this-services td,
    .add-this-services th
    {
        border: 1px solid #ccc;
        padding: 5px;
    }

    .add-this-services th
    {
        font-weight: bold;
    }

    .add-this-services td input
    {
        width: auto;
    }
</style>
