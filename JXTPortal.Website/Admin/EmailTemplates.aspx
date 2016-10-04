<%@ Page Title="Global - Email Templates" Theme="Default" Language="C#" MasterPageFile="~/MasterPages/admin.Master"
    AutoEventWireup="true" CodeBehind="EmailTemplates.aspx.cs" Inherits="JXTPortal.Website.Admin.EmailTemplates" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    Email Templates List
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <data:EntityGridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
        DataSourceID="EmailTemplatesDataSource" DataKeyNames="EmailTemplateID" AllowMultiColumnSorting="false"
        DefaultSortColumnName="" DefaultSortDirection="Ascending" ExcelExportFileName="Export_EmailTemplates.xls">
        <Columns>
            <asp:CommandField ShowSelectButton="True" ShowEditButton="False" />
            <asp:BoundField DataField="EmailCode" HeaderText="Email Code" SortExpression="[EmailCode]" />
            <asp:BoundField DataField="EmailDescription" HeaderText="Email Description" SortExpression="[EmailDescription]" />
            <asp:BoundField DataField="EmailSubject" HeaderText="Email Subject" SortExpression="[EmailSubject]" />
            <asp:TemplateField HeaderText="Global Template" SortExpression="[GlobalTemplate]">
                <ItemTemplate>
                    <asp:Label ID="lbGlobalTemplate" runat="server" Text='<%# Eval("GlobalTemplate") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            <b>No Email Templates Found!</b>
        </EmptyDataTemplate>
    </data:EntityGridView>
    <br />
    <asp:Button runat="server" ID="btnEmailTemplates" OnClientClick="javascript:location.href='EmailTemplatesEdit.aspx'; return false;"
        Text="Add New"></asp:Button>
    <data:EmailTemplatesDataSource ID="EmailTemplatesDataSource" runat="server" SelectMethod="GetBySiteId"
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
    </data:EmailTemplatesDataSource>
</asp:Content>
