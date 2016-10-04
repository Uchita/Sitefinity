<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master"
    AutoEventWireup="true" Inherits="SalaryType" Title="Global - Default Salary Types"
    CodeBehind="SalaryType.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    Salary Type List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1"
        PersistenceMethod="Session" />
    <br />
    <data:EntityGridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
        DataSourceID="SalaryTypeDataSource" DataKeyNames="SalaryTypeId" AllowMultiColumnSorting="false"
        DefaultSortColumnName="" DefaultSortDirection="Ascending" ExcelExportFileName="Export_SalaryType.xls">
        <Columns>
            <asp:CommandField ShowSelectButton="True" ShowEditButton="False" />
            <asp:BoundField DataField="SalaryTypeName" HeaderText="Salary Type Name" SortExpression="[SalaryTypeName]" />
            <asp:CheckBoxField DataField="Valid" HeaderText="Valid" SortExpression="[Valid]" />
        </Columns>
        <EmptyDataTemplate>
            <b>No SalaryType Found!</b>
        </EmptyDataTemplate>
    </data:EntityGridView>
    <br />

    <%--<asp:Button runat="server" ID="btnSalaryType" OnClientClick="javascript:location.href='SalaryTypeEdit.aspx'; return false;"
        Text="Add New"></asp:Button>--%>

    <data:SalaryTypeDataSource ID="SalaryTypeDataSource" runat="server" SelectMethod="GetPaged"
        EnablePaging="True" EnableSorting="True">
        <Parameters>
            <data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
            <data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
            <asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex"
                Type="Int32" />
            <asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize"
                Type="Int32" />
            <data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
        </Parameters>
    </data:SalaryTypeDataSource>
</asp:Content>
