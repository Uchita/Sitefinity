<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master"
    AutoEventWireup="true" Inherits="WorkType" Title="Global - Default Work Types"
    CodeBehind="WorkType.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    Work Type List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <data:EntityGridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
        DataSourceID="WorkTypeDataSource" DataKeyNames="WorkTypeId" AllowMultiColumnSorting="false"
        DefaultSortColumnName="" DefaultSortDirection="Ascending" ExcelExportFileName="Export_WorkType.xls">
        <Columns>
            <asp:CommandField ShowSelectButton="True" ShowEditButton="True" />
            <asp:BoundField DataField="WorkTypeName" HeaderText="Work Type Name" SortExpression="[WorkTypeName]" />
            <asp:CheckBoxField DataField="Valid" HeaderText="Valid" SortExpression="[Valid]" />
        </Columns>
        <EmptyDataTemplate>
            <b>No WorkType Found!</b>
        </EmptyDataTemplate>
    </data:EntityGridView>
    <br />

    <%--<asp:Button runat="server" ID="btnWorkType" OnClientClick="javascript:location.href='WorkTypeEdit.aspx'; return false;"
        Text="Add New"></asp:Button>--%>

    <data:WorkTypeDataSource ID="WorkTypeDataSource" runat="server" SelectMethod="GetPaged"
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
    </data:WorkTypeDataSource>
</asp:Content>
