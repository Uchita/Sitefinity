<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.Master"
    AutoEventWireup="true" CodeBehind="Countries.aspx.cs" Inherits="JXTPortal.Website.Admin.Countries"
    Title="Global - Default Countries" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    Countries List
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1"
        PersistenceMethod="Session" />
    <br />
    <data:EntityGridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
        DataSourceID="CountriesDataSource" DataKeyNames="CountryId" AllowMultiColumnSorting="false"
        DefaultSortColumnName="" DefaultSortDirection="Ascending" ExcelExportFileName="Export_Countries.xls">
        <Columns>
            <asp:CommandField ShowSelectButton="True" ShowEditButton="False" />
            <asp:BoundField DataField="CountryName" HeaderText="Country Name" SortExpression="[CountryName]" />
            <asp:BoundField DataField="Abbr" HeaderText="Abbr" SortExpression="[Abbr]" />
            <asp:CheckBoxField DataField="Valid" HeaderText="Valid" SortExpression="[Valid]" />
        </Columns>
        <EmptyDataTemplate>
            <b>No Countries Found!</b>
        </EmptyDataTemplate>
    </data:EntityGridView>
    <br />
    <asp:Button runat="server" ID="btnCountries" OnClientClick="javascript:location.href='CountriesEdit.aspx'; return false;"
        Text="Add New" Visible="false"></asp:Button>
    <data:CountriesDataSource ID="CountriesDataSource" runat="server" SelectMethod="GetPaged"
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
    </data:CountriesDataSource>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
