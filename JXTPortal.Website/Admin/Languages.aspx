<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master"
    AutoEventWireup="true" Inherits="Languages" Title="Sites - Languages List" ValidateRequest="false"
    CodeBehind="Languages.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    Languages List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="scriptManager" runat="server" />
    <div class="form-all">
        <span class="form-message">
            <asp:Literal ID="ltlMessage" runat="server" /></span>
        <asp:MultiView ID="MultiViewSiteLanguagesEdit" runat="server" ActiveViewIndex="0">
            <asp:View ID="ViewSiteLanguages" runat="server">
                <ul class="form-section">
                    <li class="form-line" id="reg-password-field">
                        <div class="form-input">
                            <asp:GridView ID="gridViewSiteLanguages" runat="server" AutoGenerateColumns="false"
                                AllowMultiColumnSorting="false" DefaultSortColumnName="" DefaultSortDirection="Ascending"
                                GridLines="None" CssClass="grid" AlternatingRowStyle-CssClass="grid-alt-row"
                                OnRowEditing="gridViewSiteLanguages_OnRowEditing" 
                                onrowdeleting="gridViewSiteLanguages_RowDeleting">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkDeleteSiteLanguages" runat="server" OnClientClick="return confirm('Are you sure you want to delete this site language?');"
                                                CommandName="Delete" CommandArgument='<%# Eval("SiteLanguageID") %>' CausesValidation="false"
                                                OnClick="lnkDeleteSiteLanguages_Click">Delete</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Site Language Name" SortExpression="SiteLanguageName">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkEditSiteLanguages" runat="server" CommandName="Edit" CommandArgument='<%# Eval("SiteLanguageID") %>'
                                                CausesValidation="false" OnClick="lnkEditSiteLanguages_Click" Text='<%# Eval("SiteLanguageName") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </li>
                </ul>
                <br />
                <asp:HiddenField ID="hfSiteLanguageId" runat="server" Value="-1" />
                <asp:Button runat="server" ID="btnLanguage" Text="Add New" OnClick="btnLanguage_Click"
                    CssClass="form-submit-button" />
            </asp:View>
            <asp:View ID="ViewEditSiteLanguage" runat="server">
                <ul class="form-section">
                    <li class="form-line">
                        <label class="form-label-left">
                            Site Language Name:<span class="form-required">*</span>
                        </label>
                        <div class="form-input">
                            <asp:TextBox ID="txtSiteLanguageName" runat="server" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic"
                                ControlToValidate="txtSiteLanguageName" ErrorMessage="Required"></asp:RequiredFieldValidator><br />
                        </div>
                    </li>
                    <li class="form-line">
                        <label class="form-label-left">
                            Languages:<span class="form-required">*</span>
                        </label>
                        <div class="form-input">
                            <asp:DropDownList ID="ddlLanguages" runat="server" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                                ControlToValidate="ddlLanguages" ErrorMessage="Required"></asp:RequiredFieldValidator><br />
                        </div>
                    </li>
                    <li class="form-line">
                        <div class="form-input-wide">
                            <div class="form-buttons-wrapper">
                                <asp:Button ID="btnEditSave" runat="server" Text="Update" OnClick="btnEditSave_Click"
                                    CssClass="jxtadminbutton" />
                                <asp:Button ID="btnReturn" runat="server" Text="Return" OnClick="btnReturn_Click"
                                    CssClass="jxtadminbutton" CausesValidation="false" />
                            </div>
                        </div>
                    </li>
                </ul>
            </asp:View>
        </asp:MultiView>
    </div>
</asp:Content>
