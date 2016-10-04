<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master"
    AutoEventWireup="true" Inherits="Folders" Title="File Management - Folders List"
    CodeBehind="Folders.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    Folders List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <data:EntityGridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="FoldersDataSource"
        DataKeyNames="FolderID" AllowMultiColumnSorting="false" DefaultSortColumnName=""
        DefaultSortDirection="Ascending" ExcelExportFileName="Export_Folder.xls" AlternatingRowStyle-CssClass="grid-alt-row">
        <Columns>
            <asp:CommandField ShowSelectButton="False" ShowEditButton="False" />
            <asp:TemplateField>
                <ItemTemplate>
                    <a href='Folders.aspx?FolderId=<%# Eval("FolderID") %>'>Edit</a></ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="FolderID" HeaderText="Folder ID" SortExpression="[FolderID]"
                ReadOnly="true" />
            <asp:BoundField DataField="FolderName" HeaderText="Folder Name" SortExpression="[FolderName]" />
        </Columns>
        <EmptyDataTemplate>
            <b>No Folder Found!</b>
        </EmptyDataTemplate>
    </data:EntityGridView>
    <br />
    <p class="subHeader">
        Create New Folder</p>
    <asp:TextBox ID="txtFolderName" runat="server" /><asp:RequiredFieldValidator ID="ReqVal_txtFolderName"
        runat="server" Display="Dynamic" ControlToValidate="txtFolderName" ErrorMessage="Required"
        ValidationGroup="vgNewFolder" />
    <asp:Button runat="server" ID="btnSave" Text="Add New Folder" OnClick="btnSave_Click"
        ValidationGroup="vgNewFolder"></asp:Button>
    <data:FoldersDataSource ID="FoldersDataSource" runat="server" SelectMethod="GetBySiteId"
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
    </data:FoldersDataSource>
</asp:Content>
