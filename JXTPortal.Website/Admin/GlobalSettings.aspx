<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master"
    AutoEventWireup="true" Inherits="GlobalSettings" Title="GlobalSettings List"
    CodeBehind="GlobalSettings.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    Global Settings List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <data:EntityGridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
        DataSourceID="GlobalSettingsDataSource" DataKeyNames="GlobalSettingId" AllowMultiColumnSorting="false"
        DefaultSortColumnName="" DefaultSortDirection="Ascending" ExcelExportFileName="Export_GlobalSettings.xls">
        <Columns>
            <asp:CommandField ShowSelectButton="True" ShowEditButton="False" />
            <asp:CheckBoxField DataField="PublicJobsSearch" HeaderText="Public Jobs Search" SortExpression="[PublicJobsSearch]"  />
			<asp:CheckBoxField DataField="PublicMembersSearch" HeaderText="Public Members Search" SortExpression="[PublicMembersSearch]"  />
			<asp:CheckBoxField DataField="PublicCompaniesSearch" HeaderText="Public Companies Search" SortExpression="[PublicCompaniesSearch]"  />
			<asp:CheckBoxField DataField="PublicSponsoredAdverts" HeaderText="Public Sponsored Adverts" SortExpression="[PublicSponsoredAdverts]"  />
			<asp:CheckBoxField DataField="PrivateJobs" HeaderText="Private Jobs" SortExpression="[PrivateJobs]"  />
			<asp:CheckBoxField DataField="PrivateMembers" HeaderText="Private Members" SortExpression="[PrivateMembers]"  />
			<asp:CheckBoxField DataField="PrivateCompanies" HeaderText="Private Companies" SortExpression="[PrivateCompanies]"  />
            
            <asp:BoundField DataField="PageTitlePrefix" HeaderText="Page Title Prefix" SortExpression="[PageTitlePrefix]" />            
            <asp:BoundField DataField="LastModified" DataFormatString="{0:dd/MM/yyyy tt:mm:ss tt}"
                HtmlEncode="False" HeaderText="Last Modified" SortExpression="[LastModified]" />
        </Columns>
        <EmptyDataTemplate>
            <b>No GlobalSettings Found!</b>
        </EmptyDataTemplate>
    </data:EntityGridView>
    <br />
    <asp:Button runat="server" ID="btnGlobalSettings" OnClientClick="javascript:location.href='GlobalSettingsEdit.aspx'; return false;"
        Text="Add New"></asp:Button>
    <data:GlobalSettingsDataSource ID="GlobalSettingsDataSource" runat="server" SelectMethod="GetBySiteId"
        EnablePaging="True" EnableSorting="True" EnableDeepLoad="True">
        <DeepLoadProperties Method="IncludeChildren" Recursive="False">
            <Types>
            </Types>
        </DeepLoadProperties>
        <Parameters>
            <data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
            <data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
            <asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex"
                Type="Int32" />
            <asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize"
                Type="Int32" />
            <data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
        </Parameters>
    </data:GlobalSettingsDataSource>
</asp:Content>
