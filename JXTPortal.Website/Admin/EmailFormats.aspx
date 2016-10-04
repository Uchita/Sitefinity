<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master"
    AutoEventWireup="true" Inherits="EmailFormats" Title="Global - Email Formats"
    CodeBehind="EmailFormats.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    Email Formats List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <data:EntityGridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
        DataSourceID="EmailFormatsDataSource" DataKeyNames="EmailFormatId" AllowMultiColumnSorting="false"
        DefaultSortColumnName="" DefaultSortDirection="Ascending" ExcelExportFileName="Export_EmailFormats.xls">
        <Columns>
            <asp:CommandField ShowSelectButton="False" ShowEditButton="True" />
            <asp:BoundField DataField="EmailFormatID" HeaderText="Email Format ID" SortExpression="[EmailFormatID]"
                ReadOnly="true" />
            <asp:BoundField DataField="EmailFormatName" HeaderText="Email Format Name" SortExpression="[EmailFormatName]" />
        </Columns>
        <EmptyDataTemplate>
            <b>No EmailFormats Found!</b>
        </EmptyDataTemplate>
    </data:EntityGridView>
    <br />
    <asp:Button runat="server" ID="btnEmailFormats" OnClientClick="javascript:location.href='EmailFormatsEdit.aspx'; return false;"
        Text="Add New" Enabled="false"></asp:Button>
    <data:EmailFormatsDataSource ID="EmailFormatsDataSource" runat="server" SelectMethod="GetPaged"
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
    </data:EmailFormatsDataSource>
</asp:Content>
