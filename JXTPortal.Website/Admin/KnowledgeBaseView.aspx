<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master"
    AutoEventWireup="true" CodeBehind="KnowledgeBaseView.aspx.cs" Title="Knowledgebase View"
    Inherits="JXTPortal.Website.Admin.KnowledgeBaseView" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    Knowledge Base View <a href='http://support.jxt.com.au/solution/articles/116437-create-edit-admin-content-editor-and-external-users'
        class='jxt-help-page' title='click here for help on this page' target='_blank'>help
        on this page</a>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="form-all">
        <h2>
            <asp:Literal ID="ltSubject" runat="server" />
        </h2>
        <asp:Literal ID="ltDate" runat="server" />
        <div>
            <asp:Literal ID="ltKnowledgeBaseContent" runat="server" />
        </div>
        <hr />
    </div>
</asp:Content>
