<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master"
    AutoEventWireup="true" Inherits="RolesEdit" Title="Global - Default Roles Edit"
    CodeBehind="RolesEdit.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    Roles - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="form-all">
        <span class="form-message">
            <asp:Literal ID="ltlMessage" runat="server" /></span>
        <asp:MultiView ID="MultiViewRoles" runat="server" ActiveViewIndex="0">
            <asp:View ID="ViewRoles" runat="server">
                <ul class="form-section">
                    <li class="form-line" id="role-profession-field">
                        <label class="form-label-left">
                            Profession:<span class="form-required">*</span></label>
                        <div class="form-input">
                            <asp:DropDownList ID="dataProfession" runat="server" DataTextField="ProfessionName"
                                DataValueField="ProfessionID" />
                            <asp:RequiredFieldValidator ID="ReqVal_Profession" runat="server" ControlToValidate="dataProfession"
                                NullItemText=" Please Choose ..." ErrorMessage="Required" InitialValue="0"></asp:RequiredFieldValidator>
                        </div>
                    </li>
                    <li class="form-line" id="role-rolename-field">
                        <label class="form-label-left">
                            Role Name:<span class="form-required">*</span></label>
                        <div class="form-input">
                            <asp:TextBox ID="dataRoleName" runat="server" Width="250px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ReqVal_RoleName" runat="server" ControlToValidate="dataRoleName"
                                ErrorMessage="Required" />
                        </div>
                    </li>
                    <li class="form-line" id="role-valid-field">
                        <label class="form-label-left">
                            Valid:</label>
                        <div class="form-input">
                            <asp:CheckBox ID="dataValid" runat="server" Width="250px"></asp:CheckBox>
                        </div>
                    </li>
                    <li class="form-line" id="role-metatitle-field">
                        <label class="form-label-left">
                            Meta Title:</label>
                        <div class="form-input">
                            <asp:TextBox ID="dataMetaTitle" runat="server" />
                        </div>
                    </li>
                    <li class="form-line" id="role-metakeywords-field">
                        <label class="form-label-left">
                            Meta Keywords:</label>
                        <div class="form-input">
                            <asp:TextBox ID="dataMetaKeywords" runat="server" />
                        </div>
                    </li>
                    <li class="form-line" id="role-metadescription-field">
                        <label class="form-label-left">
                            Meta Description:</label>
                        <div class="form-input">
                            <asp:TextBox ID="dataMetaDescription" runat="server" />
                        </div>
                    </li>
                    <li class="form-line">
                        <div class="form-input-wide">
                            <div class="form-buttons-wrapper">
                                <%--<asp:Button ID="btnInsert" runat="server" Text="Insert" OnClick="btnInsert_Click"
                                    CssClass="jxtadminbutton" />--%>
                                <asp:Button ID="btnEditSave" runat="server" Text="Update" OnClick="btnEditSave_Click"
                                    CssClass="jxtadminbutton" />
                                <asp:Button ID="btnReturn" runat="server" Text="Return" OnClick="btnReturn_Click"
                                    CssClass="jxtadminbutton" CausesValidation="false" />
                            </div>
                        </div>
                    </li>
                    <li class="form-line" id="role-roles-field">
                        <div class="form-input">
                            <data:EntityGridView ID="GridViewSiteRoles1" runat="server" AutoGenerateColumns="False"
                                OnSelectedIndexChanged="GridViewSiteRoles1_SelectedIndexChanged" DataSourceID="SiteRolesDataSource1"
                                DataKeyNames="SiteRoleId" AllowMultiColumnSorting="false" DefaultSortColumnName=""
                                DefaultSortDirection="Ascending" ExcelExportFileName="Export_SiteRoles.xls" Visible='<%# (RoleId == 0) ? false : true %>'>
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True" />
                                    <data:HyperLinkField HeaderText="Role Id" DataNavigateUrlFormatString="RolesEdit.aspx?RoleId={0}"
                                        DataNavigateUrlFields="RoleId" DataContainer="RoleIdSource" DataTextField="RoleName" />
                                    <asp:BoundField DataField="SiteRoleName" HeaderText="Site Role Name" SortExpression="[SiteRoleName]" />
                                    <asp:CheckBoxField DataField="Valid" HeaderText="Valid" SortExpression="[Valid]" />
                                    <asp:BoundField DataField="MetaTitle" HeaderText="Meta Title" SortExpression="[MetaTitle]" />
                                    <asp:BoundField DataField="MetaKeywords" HeaderText="Meta Keywords" SortExpression="[MetaKeywords]" />
                                    <asp:BoundField DataField="MetaDescription" HeaderText="Meta Description" SortExpression="[MetaDescription]" />
                                </Columns>
                                <EmptyDataTemplate>
                                    <b>No Site Roles Found! </b>
                                    <asp:HyperLink runat="server" ID="hypSiteRoles" NavigateUrl="~/admin/SiteRolesEdit.aspx">Add New</asp:HyperLink>
                                </EmptyDataTemplate>
                            </data:EntityGridView>
                        </div>
                    </li>
                </ul>
                <data:SiteRolesDataSource ID="SiteRolesDataSource1" runat="server" SelectMethod="Find"
                    EnableDeepLoad="True">
                    <DeepLoadProperties Method="IncludeChildren" Recursive="False">
                        <Types>
                            <data:SiteRolesProperty Name="Roles" />
                        </Types>
                    </DeepLoadProperties>
                    <Parameters>
                        <data:SqlParameter Name="Parameters">
                            <Filters>
                                <data:SiteRolesFilter Column="RoleId" QueryStringField="RoleId" />
                            </Filters>
                        </data:SqlParameter>
                        <data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
                    </Parameters>
                </data:SiteRolesDataSource>
            </asp:View>
        </asp:MultiView>
    </div>
    <br />
</asp:Content>
