<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master"
    AutoEventWireup="true" Inherits="DynamicPageFilesEdit" Title="DynamicPageFiles Edit"
    CodeBehind="DynamicPageFilesEdit.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    Dynamic Page Files - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="/ckeditor/ckeditor.js"></script>
    <data:MultiFormView ID="FormView1" DataKeyNames="DynamicPageFileId" runat="server"
        DataSourceID="DynamicPageFilesDataSource">
        <EditItemTemplatePaths>
            <data:TemplatePath Path="~/admin/usercontrols/dynamicpagefilesfields.ascx" />
        </EditItemTemplatePaths>
        <InsertItemTemplatePaths>
            <data:TemplatePath Path="~/admin/usercontrols/dynamicpagefilesfields.ascx" />
        </InsertItemTemplatePaths>
        <EmptyDataTemplate>
            <b>DynamicPageFiles not found!</b>
        </EmptyDataTemplate>
        <FooterTemplate>
            <asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert"
                Text="Insert" CssClass="jxtadminbutton" />
            <asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update"
                Text="Update" CssClass="jxtadminbutton" />
            <asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
                Text="Cancel" CssClass="jxtadminbutton" />
        </FooterTemplate>
    </data:MultiFormView>
    <data:DynamicPageFilesDataSource ID="DynamicPageFilesDataSource" runat="server" SelectMethod="GetByDynamicPageFileId">
        <Parameters>
            <asp:QueryStringParameter Name="DynamicPageFileId" QueryStringField="DynamicPageFileId"
                Type="String" />
        </Parameters>
    </data:DynamicPageFilesDataSource>
    <br />
</asp:Content>
