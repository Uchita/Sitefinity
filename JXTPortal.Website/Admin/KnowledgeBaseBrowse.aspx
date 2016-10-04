<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master"
    AutoEventWireup="true" CodeBehind="KnowledgeBaseBrowse.aspx.cs" Title="Knowledgebase Browse"
    Inherits="JXTPortal.Website.Admin.KnowledgeBaseBrowse" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    Knowledge Base Browse<a href='http://support.jxt.com.au/solution/articles/116437-create-edit-admin-content-editor-and-external-users'
        class='jxt-help-page' title='click here for help on this page' target='_blank'>help
        on this page</a>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="form-all">
        <span class="form-message">
            <asp:Literal ID="ltlMessage" runat="server" />
        </span>
        <asp:Repeater ID="rptCategories" runat="server" OnItemDataBound="CategoryList_ItemDataBound">
            <ItemTemplate>
                <h4>
                    <%# Eval("KnowledgeBaseCategoryName")%></h4>
                <hr />
                <%--Child Repeater--%>
                <asp:Repeater ID="rptChildCategory" runat="server" OnItemDataBound="ChildCategoryList_ItemDataBound">
                    <HeaderTemplate>
                        <ul>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <li><strong>
                            <%# Eval("KnowledgeBaseCategoryName")%></strong></li>
                        <br />
                        <%--Knowledge Base Repeater--%>
                        <asp:Repeater ID="rptKnowledgebase" runat="server">
                            <HeaderTemplate>
                                <ul>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <li><strong><a href="/admin/KnowledgeBaseView.aspx?Id=<%# Eval("ID") %>">
                                    <%# Eval("Subject")%></strong> </a> </li>
                                <br />
                            </ItemTemplate>
                            <FooterTemplate>
                                </ul>
                            </FooterTemplate>
                        </asp:Repeater>
                        <asp:HiddenField ID="hfKnowledgeBaseCategoryId" runat="server" Value='<%# Eval("ID") %>' />
                    </ItemTemplate>
                    <FooterTemplate>
                        </ul>
                    </FooterTemplate>
                </asp:Repeater>
                <asp:HiddenField ID="hfParentId" runat="server" Value='<%# Eval("ID") %>' />
            </ItemTemplate>
            <SeparatorTemplate>
                <%--<hr size="10" noshade>--%>
            </SeparatorTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
