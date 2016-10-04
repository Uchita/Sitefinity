<%@ Page Title="Global - Default Resources" Theme="Default" Language="C#" MasterPageFile="~/MasterPages/admin.Master"
    AutoEventWireup="true" CodeBehind="DefaultResources.aspx.cs" Inherits="JXTPortal.Website.Admin.DefaultResources" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    Default Resources List
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <data:EntityGridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
        DataSourceID="DefaultResourcesDataSource" DataKeyNames="DefaultResourceId" AllowMultiColumnSorting="false"
        DefaultSortColumnName="" DefaultSortDirection="Ascending" ExcelExportFileName="Export_DefaultResources.xls">
        <Columns>
            <asp:CommandField ShowSelectButton="True" ShowEditButton="False" />
            <asp:BoundField DataField="ResourceFileID" HeaderText="Resource File ID" SortExpression="[ResourceFileID]" />
            <asp:BoundField DataField="ResourceCode" HeaderText="Resource Code" SortExpression="[ResourceCode]" />
            <asp:BoundField DataField="ResourceDescription" HeaderText="Resource Description"
                SortExpression="[ResourceDescription]" />
        </Columns>
        <EmptyDataTemplate>
            <b>No Files Found!</b>
        </EmptyDataTemplate>
    </data:EntityGridView>
    <br />
    <asp:Button runat="server" ID="btnFiles" OnClientClick="javascript:location.href='DefaultResourcesEdit.aspx'; return false;"
        Text="Add New" CssClass="jxtadminbutton"></asp:Button>
    <data:DefaultResourcesDataSource ID="DefaultResourcesDataSource" runat="server" SelectMethod="GetPaged"
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
    </data:DefaultResourcesDataSource>
</asp:Content>
