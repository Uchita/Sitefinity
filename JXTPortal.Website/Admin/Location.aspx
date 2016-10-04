<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master"
    AutoEventWireup="true" Inherits="Location" Title="Global - Default Locations "
    CodeBehind="Location.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    Location List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1"
        PersistenceMethod="Session" />
    <br />
    <data:EntityGridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
        DataSourceID="LocationDataSource" DataKeyNames="LocationId" AllowMultiColumnSorting="false"
        DefaultSortColumnName="" DefaultSortDirection="Ascending" ExcelExportFileName="Export_Location.xls">
        <Columns>
            <asp:CommandField ShowSelectButton="True" ShowEditButton="False" />
            <asp:BoundField DataField="LocationName" HeaderText="Location Name" SortExpression="[LocationName]" />
            <asp:CheckBoxField DataField="Valid" HeaderText="Valid" SortExpression="[Valid]" />
        </Columns>
        <EmptyDataTemplate>
            <b>No Location Found!</b>
        </EmptyDataTemplate>
    </data:EntityGridView>
    <br />
    <%--<asp:Button runat="server" ID="btnLocation" OnClientClick="javascript:location.href='LocationEdit.aspx'; return false;"
        Text="Add New"></asp:Button>--%>
    <data:LocationDataSource ID="LocationDataSource" runat="server" SelectMethod="GetPaged"
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
    </data:LocationDataSource>
</asp:Content>
