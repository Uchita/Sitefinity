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
<br />

<h3>AMAZON S3 BUCKET SETTINGS</h3><br />
<sitefinity:TextField ID="amazonS3AccessKeyId" runat="server" DataFieldName="AmazonS3AccessKeyId" Title="Please Enter Access Key Id" CssClass="sfSettingsSection" DisplayMode="Write" />
<sitefinity:TextField ID="amazonS3SecretKey" runat="server" DataFieldName="AmazonS3SecretKey" Title="Please Enter Secret Key" CssClass="sfSettingsSection" DisplayMode="Write" />
<sitefinity:TextField ID="amazonS3BucketName" runat="server" DataFieldName="AmazonS3BucketName" Title="Please Enter Bucket Name" CssClass="sfSettingsSection" DisplayMode="Write" />
<sitefinity:TextField ID="amazonS3RegionEndpoint" runat="server" DataFieldName="AmazonS3RegionEndpoint" Title="Please Enter Region End Point" CssClass="sfSettingsSection" DisplayMode="Write" />
<sitefinity:TextField ID="amazonS3ProviderName" runat="server" DataFieldName="AmazonS3ProviderName" Title="Please Enter Provider Name" CssClass="sfSettingsSection" DisplayMode="Write" />
<sitefinity:TextField ID="amazonS3ApplicationName" runat="server" DataFieldName="AmazonS3ApplicationName" Title="Please Enter Application Name" CssClass="sfSettingsSection" DisplayMode="Write" />
<sitefinity:TextField ID="amazonS3UrlName" runat="server" DataFieldName="AmazonS3UrlName" Title="Please Enter Url Name" CssClass="sfSettingsSection" DisplayMode="Write" />

<h3>SALARY TYPE FILTER</h3><br />
<table class="jxtnext-table">
    <thead>
        <tr>
            <th>Salary Type</th>
            <th>Maximum Value</th>
        </tr>
    </thead>

    <tbody>
        <tr>
            <td>Hourly</td>
            <td><sitefinity:TextField ID="salaryTypeHourlyRangeMax" DataFieldName="SalaryTypeHourlyRangeMax" DisplayMode="Write" runat="server" /></td>
        </tr>

        <tr>
            <td>Daily</td>
            <td><sitefinity:TextField ID="salaryTypeDailyRangeMax" DataFieldName="SalaryTypeDailyRangeMax" DisplayMode="Write" runat="server" /></td>
        </tr>

        <tr>
            <td>Weekly</td>
            <td><sitefinity:TextField ID="salaryTypeWeeklyRangeMax" DataFieldName="SalaryTypeWeeklyRangeMax" DisplayMode="Write" runat="server" /></td>
        </tr>

        <tr>
            <td>Fortnightly</td>
            <td><sitefinity:TextField ID="salaryTypeFortnightlyRangeMax" DataFieldName="SalaryTypeFortnightlyRangeMax" DisplayMode="Write" runat="server" /></td>
        </tr>

        <tr>
            <td>Monthly</td>
            <td><sitefinity:TextField ID="salaryTypeMonthlyRangeMax" DataFieldName="SalaryTypeMonthlyRangeMax" DisplayMode="Write" runat="server" /></td>
        </tr>

        <tr>
            <td>Annual</td>
            <td><sitefinity:TextField ID="salaryTypeAnnualRangeMax" DataFieldName="SalaryTypeAnnualRangeMax" DisplayMode="Write" runat="server" /></td>
        </tr>
    </tbody>
</table>
<br />

<h3>Other settings</h3><br />
<sitefinity:TextField ID="cultureIsEnabled" runat="server" DataFieldName="CultureIsEnabled" Title="Please Enter Culture Value" CssClass="sfSettingsSection" DisplayMode="Write" />
<sitefinity:TextField ID="jobCurrencySymbol" runat="server" DataFieldName="JobCurrencySymbol" Title="The currency used in job views" CssClass="sfSettingsSection" DisplayMode="Write" />

<style type="text/css">
    .jxtnext-table
    {
        border-collapse: collapse;
        padding: 0;
        margin: 0;
        width: 410px;
    }

    .jxtnext-table th, 
    .jxtnext-table td
    {
        border: 1px solid #ccc;
        padding: 5px;
    }

    .jxtnext-table th
    {
        font-weight: bold;
    }

    .jxtnext-table input[type="text"]
    {
        width: 100%;
        box-sizing:border-box;
    }    
</style>
