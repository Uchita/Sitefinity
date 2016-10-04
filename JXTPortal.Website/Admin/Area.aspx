<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master"
    AutoEventWireup="true" Inherits="Area" Title="Global - Default Areas" CodeBehind="Area.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    Area List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1"
        PersistenceMethod="Session" />
    <br />
    <data:EntityGridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
        DataSourceID="AreaDataSource" DataKeyNames="AreaId" AllowMultiColumnSorting="false"
        DefaultSortColumnName="" DefaultSortDirection="Ascending" ExcelExportFileName="Export_Area.xls">
        <Columns>
            <asp:CommandField ShowSelectButton="True" ShowEditButton="False" />
            <asp:BoundField DataField="AreaName" HeaderText="Area Name" SortExpression="[AreaName]" />
            <data:HyperLinkField HeaderText="Location Id" DataNavigateUrlFormatString="LocationEdit.aspx?LocationId={0}"
                DataNavigateUrlFields="LocationId" DataContainer="LocationIdSource" DataTextField="LocationName" />
            <asp:CheckBoxField DataField="Valid" HeaderText="Valid" SortExpression="[Valid]" />
        </Columns>
        <EmptyDataTemplate>
            <b>No Area Found!</b>
        </EmptyDataTemplate>
    </data:EntityGridView>
    <br />
    <%--<asp:Button runat="server" ID="btnArea" OnClientClick="javascript:location.href='AreaEdit.aspx'; return false;"
        Text="Add New"></asp:Button>--%>
    <data:AreaDataSource ID="AreaDataSource" runat="server" SelectMethod="GetPaged" EnablePaging="True"
        EnableSorting="True" EnableDeepLoad="True">
        <DeepLoadProperties Method="IncludeChildren" Recursive="False">
            <Types>
                <data:AreaProperty Name="Location" />
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
    </data:AreaDataSource>
</asp:Content>
