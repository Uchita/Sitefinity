<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master"
    AutoEventWireup="true" Inherits="JobItemsTypeEdit" Title="JobItemsType Edit"
    CodeBehind="JobItemsTypeEdit.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    Job Items Type - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <data:MultiFormView ID="FormView1" DataKeyNames="JobItemTypeId" runat="server" DataSourceID="JobItemsTypeDataSource">
        <EditItemTemplatePaths>
            <data:TemplatePath Path="~/Admin/UserControls/JobItemsTypeFields.ascx" />
        </EditItemTemplatePaths>
        <InsertItemTemplatePaths>
            <data:TemplatePath Path="~/Admin/UserControls/JobItemsTypeFields.ascx" />
        </InsertItemTemplatePaths>
        <EmptyDataTemplate>
            <b>JobItemsType not found!</b>
        </EmptyDataTemplate>
        <FooterTemplate>
            <asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert"
                Text="Insert" CssClass="jxtadminbutton" />
            <asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update"
                Text="Update" CssClass="jxtadminbutton" />
            <asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
                Text="Cancel" CssClass="jxtadminbutton" />
        </FooterTemplate>
    </data:MultiFormView>
    <data:JobItemsTypeDataSource ID="JobItemsTypeDataSource" runat="server" SelectMethod="GetByJobItemTypeId">
        <Parameters>
            <asp:QueryStringParameter Name="JobItemTypeId" QueryStringField="JobItemTypeId" Type="String" />
        </Parameters>
    </data:JobItemsTypeDataSource>
    <br />
    <data:EntityGridView ID="GridViewJobs1" runat="server" AutoGenerateColumns="False"
        OnSelectedIndexChanged="GridViewJobs1_SelectedIndexChanged" DataSourceID="JobsDataSource1"
        DataKeyNames="JobId" AllowMultiColumnSorting="false" DefaultSortColumnName=""
        DefaultSortDirection="Ascending" ExcelExportFileName="Export_Jobs.xls" Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'>
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="JobName" HeaderText="Job Name" SortExpression="[JobName]" />
            <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="[Description]" />
            <asp:BoundField DataField="FullDescription" HeaderText="Full Description" SortExpression="[FullDescription]" />
            <asp:BoundField DataField="WebServiceProcessed" HeaderText="Web Service Processed"
                SortExpression="[WebServiceProcessed]" />
            <asp:BoundField DataField="ApplicationEmailAddress" HeaderText="Application Email Address"
                SortExpression="[ApplicationEmailAddress]" />
            <asp:BoundField DataField="RefNo" HeaderText="Ref No" SortExpression="[RefNo]" />
            <asp:BoundField DataField="Visible" HeaderText="Visible" SortExpression="[Visible]" />
            <asp:BoundField DataField="DatePosted" HeaderText="Date Posted" SortExpression="[DatePosted]" />
            <asp:BoundField DataField="ExpiryDate" HeaderText="Expiry Date" SortExpression="[ExpiryDate]" />
            <asp:BoundField DataField="Expired" HeaderText="Expired" SortExpression="[Expired]" />
            <asp:BoundField DataField="JobItemPrice" HeaderText="Job Item Price" SortExpression="[JobItemPrice]" />
            <asp:BoundField DataField="Billed" HeaderText="Billed" SortExpression="[Billed]" />
            <asp:BoundField DataField="LastModified" HeaderText="Last Modified" SortExpression="[LastModified]" />
            <asp:BoundField DataField="ShowSalaryDetails" HeaderText="Show Salary Details" SortExpression="[ShowSalaryDetails]" />
            <asp:BoundField DataField="SalaryText" HeaderText="Salary Text" SortExpression="[SalaryText]" />
            <data:HyperLinkField HeaderText="Job Item Type Id" DataNavigateUrlFormatString="JobItemsTypeEdit.aspx?JobItemTypeId={0}"
                DataNavigateUrlFields="JobItemTypeId" DataContainer="JobItemTypeIdSource" DataTextField="JobItemTypeParentId" />
            <asp:BoundField DataField="ApplicationMethod" HeaderText="Application Method" SortExpression="[ApplicationMethod]" />
            <asp:BoundField DataField="ApplicationUrl" HeaderText="Application Url" SortExpression="[ApplicationURL]" />
            <asp:BoundField DataField="UploadMethod" HeaderText="Upload Method" SortExpression="[UploadMethod]" />
            <asp:BoundField DataField="Tags" HeaderText="Tags" SortExpression="[Tags]" />
            <data:HyperLinkField HeaderText="Job Template Id" DataNavigateUrlFormatString="JobTemplatesEdit.aspx?JobTemplateId={0}"
                DataNavigateUrlFields="JobTemplateId" DataContainer="JobTemplateIdSource" DataTextField="JobTemplateParentId" />
            <asp:BoundField DataField="SearchField" HeaderText="Search Field" SortExpression="[SearchField]" />
            <asp:BoundField DataField="SearchFieldExtension" HeaderText="Search Field Extension"
                SortExpression="[SearchFieldExtension]" />
            <asp:BoundField DataField="AdvertiserJobTemplateLogoId" HeaderText="Advertiser Job Template Logo Id"
                SortExpression="[AdvertiserJobTemplateLogoID]" />
            <asp:BoundField DataField="CompanyName" HeaderText="Company Name" SortExpression="[CompanyName]" />
            <asp:BoundField DataField="HashValue" HeaderText="Hash Value" SortExpression="[HashValue]" />
            <asp:BoundField DataField="RequireLogonForExternalApplications" HeaderText="Require Logon For External Applications"
                SortExpression="[RequireLogonForExternalApplications]" />
            <asp:BoundField DataField="ShowLocationDetails" HeaderText="Show Location Details"
                SortExpression="[ShowLocationDetails]" />
            <asp:BoundField DataField="PublicTransport" HeaderText="Public Transport" SortExpression="[PublicTransport]" />
            <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="[Address]" />
            <asp:BoundField DataField="ContactDetails" HeaderText="Contact Details" SortExpression="[ContactDetails]" />
            <asp:BoundField DataField="JobContactPhone" HeaderText="Job Contact Phone" SortExpression="[JobContactPhone]" />
            <asp:BoundField DataField="JobContactName" HeaderText="Job Contact Name" SortExpression="[JobContactName]" />
            <asp:BoundField DataField="QualificationsRecognised" HeaderText="Qualifications Recognised"
                SortExpression="[QualificationsRecognised]" />
            <asp:BoundField DataField="ResidentOnly" HeaderText="Resident Only" SortExpression="[ResidentOnly]" />
            <asp:BoundField DataField="DocumentLink" HeaderText="Document Link" SortExpression="[DocumentLink]" />
            <asp:BoundField DataField="BulletPoint1" HeaderText="Bullet Point1" SortExpression="[BulletPoint1]" />
            <asp:BoundField DataField="BulletPoint2" HeaderText="Bullet Point2" SortExpression="[BulletPoint2]" />
            <asp:BoundField DataField="BulletPoint3" HeaderText="Bullet Point3" SortExpression="[BulletPoint3]" />
            <asp:BoundField DataField="HotJob" HeaderText="Hot Job" SortExpression="[HotJob]" />
        </Columns>
        <EmptyDataTemplate>
            <b>No Jobs Found! </b>
            <asp:HyperLink runat="server" ID="hypJobs" NavigateUrl="~/admin/JobsEdit.aspx">Add New</asp:HyperLink>
        </EmptyDataTemplate>
    </data:EntityGridView>
    <data:JobsDataSource ID="JobsDataSource1" runat="server" SelectMethod="Find" EnableDeepLoad="True">
        <DeepLoadProperties Method="IncludeChildren" Recursive="False">
            <Types>
                <data:JobsProperty Name="JobItemsType" />
                <data:JobsProperty Name="JobTemplates" />
            </Types>
        </DeepLoadProperties>
        <Parameters>
            <data:SqlParameter Name="Parameters">
                <Filters>
                    <data:JobsFilter Column="JobItemTypeId" QueryStringField="JobItemTypeId" />
                </Filters>
            </data:SqlParameter>
            <data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
        </Parameters>
    </data:JobsDataSource>
    <br />
    <data:EntityGridView ID="GridViewJobsArchive2" runat="server" AutoGenerateColumns="False"
        OnSelectedIndexChanged="GridViewJobsArchive2_SelectedIndexChanged" DataSourceID="JobsArchiveDataSource2"
        DataKeyNames="JobId" AllowMultiColumnSorting="false" DefaultSortColumnName=""
        DefaultSortDirection="Ascending" ExcelExportFileName="Export_JobsArchive.xls"
        Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'>
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="JobName" HeaderText="Job Name" SortExpression="[JobName]" />
            <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="[Description]" />
            <asp:BoundField DataField="FullDescription" HeaderText="Full Description" SortExpression="[FullDescription]" />
            <asp:BoundField DataField="WebServiceProcessed" HeaderText="Web Service Processed"
                SortExpression="[WebServiceProcessed]" />
            <asp:BoundField DataField="ApplicationEmailAddress" HeaderText="Application Email Address"
                SortExpression="[ApplicationEmailAddress]" />
            <asp:BoundField DataField="RefNo" HeaderText="Ref No" SortExpression="[RefNo]" />
            <asp:BoundField DataField="Visible" HeaderText="Visible" SortExpression="[Visible]" />
            <asp:BoundField DataField="DatePosted" HeaderText="Date Posted" SortExpression="[DatePosted]" />
            <asp:BoundField DataField="ExpiryDate" HeaderText="Expiry Date" SortExpression="[ExpiryDate]" />
            <asp:BoundField DataField="Expired" HeaderText="Expired" SortExpression="[Expired]" />
            <asp:BoundField DataField="JobItemPrice" HeaderText="Job Item Price" SortExpression="[JobItemPrice]" />
            <asp:BoundField DataField="Billed" HeaderText="Billed" SortExpression="[Billed]" />
            <asp:BoundField DataField="LastModified" HeaderText="Last Modified" SortExpression="[LastModified]" />
            <asp:BoundField DataField="ShowSalaryDetails" HeaderText="Show Salary Details" SortExpression="[ShowSalaryDetails]" />
            <asp:BoundField DataField="SalaryText" HeaderText="Salary Text" SortExpression="[SalaryText]" />
            <data:HyperLinkField HeaderText="Job Item Type Id" DataNavigateUrlFormatString="JobItemsTypeEdit.aspx?JobItemTypeId={0}"
                DataNavigateUrlFields="JobItemTypeId" DataContainer="JobItemTypeIdSource" DataTextField="JobItemTypeParentId" />
            <asp:BoundField DataField="ApplicationMethod" HeaderText="Application Method" SortExpression="[ApplicationMethod]" />
            <asp:BoundField DataField="ApplicationUrl" HeaderText="Application Url" SortExpression="[ApplicationURL]" />
            <asp:BoundField DataField="UploadMethod" HeaderText="Upload Method" SortExpression="[UploadMethod]" />
            <asp:BoundField DataField="Tags" HeaderText="Tags" SortExpression="[Tags]" />
            <data:HyperLinkField HeaderText="Job Template Id" DataNavigateUrlFormatString="JobTemplatesEdit.aspx?JobTemplateId={0}"
                DataNavigateUrlFields="JobTemplateId" DataContainer="JobTemplateIdSource" DataTextField="JobTemplateParentId" />
            <asp:BoundField DataField="SearchField" HeaderText="Search Field" SortExpression="[SearchField]" />
            <asp:BoundField DataField="SearchFieldExtension" HeaderText="Search Field Extension"
                SortExpression="[SearchFieldExtension]" />
            <asp:BoundField DataField="AdvertiserJobTemplateLogoId" HeaderText="Advertiser Job Template Logo Id"
                SortExpression="[AdvertiserJobTemplateLogoID]" />
            <asp:BoundField DataField="CompanyName" HeaderText="Company Name" SortExpression="[CompanyName]" />
            <asp:BoundField DataField="HashValue" HeaderText="Hash Value" SortExpression="[HashValue]" />
            <asp:BoundField DataField="RequireLogonForExternalApplications" HeaderText="Require Logon For External Applications"
                SortExpression="[RequireLogonForExternalApplications]" />
            <asp:BoundField DataField="ShowLocationDetails" HeaderText="Show Location Details"
                SortExpression="[ShowLocationDetails]" />
            <asp:BoundField DataField="PublicTransport" HeaderText="Public Transport" SortExpression="[PublicTransport]" />
            <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="[Address]" />
            <asp:BoundField DataField="ContactDetails" HeaderText="Contact Details" SortExpression="[ContactDetails]" />
            <asp:BoundField DataField="JobContactPhone" HeaderText="Job Contact Phone" SortExpression="[JobContactPhone]" />
            <asp:BoundField DataField="JobContactName" HeaderText="Job Contact Name" SortExpression="[JobContactName]" />
            <asp:BoundField DataField="QualificationsRecognised" HeaderText="Qualifications Recognised"
                SortExpression="[QualificationsRecognised]" />
            <asp:BoundField DataField="ResidentOnly" HeaderText="Resident Only" SortExpression="[ResidentOnly]" />
            <asp:BoundField DataField="DocumentLink" HeaderText="Document Link" SortExpression="[DocumentLink]" />
            <asp:BoundField DataField="BulletPoint1" HeaderText="Bullet Point1" SortExpression="[BulletPoint1]" />
            <asp:BoundField DataField="BulletPoint2" HeaderText="Bullet Point2" SortExpression="[BulletPoint2]" />
            <asp:BoundField DataField="BulletPoint3" HeaderText="Bullet Point3" SortExpression="[BulletPoint3]" />
            <asp:BoundField DataField="HotJob" HeaderText="Hot Job" SortExpression="[HotJob]" />
        </Columns>
        <EmptyDataTemplate>
            <b>No Jobs Archive Found! </b>
            <asp:HyperLink runat="server" ID="hypJobsArchive" NavigateUrl="~/admin/JobsArchiveEdit.aspx">Add New</asp:HyperLink>
        </EmptyDataTemplate>
    </data:EntityGridView>
    <data:JobsArchiveDataSource ID="JobsArchiveDataSource2" runat="server" SelectMethod="Find"
        EnableDeepLoad="True">
        <DeepLoadProperties Method="IncludeChildren" Recursive="False">
            <Types>
                <data:JobsArchiveProperty Name="JobItemsType" />
                <data:JobsArchiveProperty Name="JobTemplates" />
            </Types>
        </DeepLoadProperties>
        <Parameters>
            <data:SqlParameter Name="Parameters">
                <Filters>
                    <data:JobsArchiveFilter Column="JobItemTypeId" QueryStringField="JobItemTypeId" />
                </Filters>
            </data:SqlParameter>
            <data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
        </Parameters>
    </data:JobsArchiveDataSource>
    <br />
</asp:Content>
