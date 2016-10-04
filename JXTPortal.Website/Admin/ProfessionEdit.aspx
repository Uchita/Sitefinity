<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master"
    AutoEventWireup="true" Inherits="ProfessionEdit" Title="Global - Default Profession Edit"
    CodeBehind="ProfessionEdit.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    Profession - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="form-all">
        <span class="form-message">
            <asp:Literal ID="ltlMessage" runat="server" /></span>
        <asp:MultiView ID="MultiViewProfession" runat="server" ActiveViewIndex="0">
            <asp:View ID="ViewProfession" runat="server">
                <ul class="form-section">
                    <li class="form-line" id="pf-professionname-field">
                        <label class="form-label-left">
                            Profession Name:<span class="form-required">*</span></label>
                        <div class="form-input">
                            <asp:TextBox ID="dataProfessionName" runat="server" Width="250px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ReqVal_ProfessionName" runat="server" ControlToValidate="dataProfessionName"
                                ErrorMessage="Required" />
                        </div>
                    </li>
                    <li class="form-line" id="pf-valid-field">
                        <label class="form-label-left">
                            Valid:</label>
                        <div class="form-input">
                            <asp:CheckBox ID="dataValid" runat="server" Width="250px"></asp:CheckBox>
                        </div>
                    </li>
                    <li class="form-line" id="pf-metatitle-field">
                        <label class="form-label-left">
                            Meta Title:</label>
                        <div class="form-input">
                            <asp:TextBox ID="dataMetaTitle" runat="server" />
                        </div>
                    </li>
                    <li class="form-line" id="pf-metakeywords-field">
                        <label class="form-label-left">
                            Meta Keywords:</label>
                        <div class="form-input">
                            <asp:TextBox ID="dataMetaKeywords" runat="server" />
                        </div>
                    </li>
                    <li class="form-line" id="pf-metadescription-field">
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
                    <li class="form-line" id="pf-roles-field">
                        <label class="form-label-left">
                            Roles:</label>
                        <div class="form-input">
                            <data:EntityGridView ID="GridViewRoles1" runat="server" AutoGenerateColumns="False"
                                OnSelectedIndexChanged="GridViewRoles1_SelectedIndexChanged" DataSourceID="RolesDataSource1"
                                DataKeyNames="RoleId" AllowMultiColumnSorting="false" DefaultSortColumnName=""
                                DefaultSortDirection="Ascending" ExcelExportFileName="Export_Roles.xls" Visible='<%# (ProfessionId == 0) ? false : true %>'>
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True" />
                                    <data:HyperLinkField HeaderText="Profession Id" DataNavigateUrlFormatString="ProfessionEdit.aspx?ProfessionId={0}"
                                        DataNavigateUrlFields="ProfessionId" DataContainer="ProfessionIdSource" DataTextField="ProfessionName" />
                                    <asp:BoundField DataField="RoleName" HeaderText="Role Name" SortExpression="[RoleName]" />
                                    <asp:CheckBoxField DataField="Valid" HeaderText="Valid" SortExpression="[Valid]" />
                                    <asp:BoundField DataField="MetaTitle" HeaderText="Meta Title" SortExpression="[MetaTitle]" />
                                    <asp:BoundField DataField="MetaKeywords" HeaderText="Meta Keywords" SortExpression="[MetaKeywords]" />
                                    <asp:BoundField DataField="MetaDescription" HeaderText="Meta Description" SortExpression="[MetaDescription]" />
                                </Columns>
                                <EmptyDataTemplate>
                                    <b>No Roles Found! </b>
                                    <asp:HyperLink runat="server" ID="hypRoles" NavigateUrl="~/admin/RolesEdit.aspx">Add New</asp:HyperLink>
                                </EmptyDataTemplate>
                            </data:EntityGridView>
                        </div>
                    </li>
                    <%--<li class="form-line" id="pf-siteprofession-field">
                        <label class="form-label-left">
                            Site Profession:</label>
                        <div class="form-input">
                            <data:EntityGridView ID="GridViewSiteProfession2" runat="server" AutoGenerateColumns="False"
                                OnSelectedIndexChanged="GridViewSiteProfession2_SelectedIndexChanged" DataSourceID="SiteProfessionDataSource2"
                                DataKeyNames="SiteProfessionId" AllowMultiColumnSorting="false" DefaultSortColumnName=""
                                DefaultSortDirection="Ascending" ExcelExportFileName="Export_SiteProfession.xls"
                                Visible='<%# (ProfessionId == 0) ? false : true %>'>
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True" />
                                    <data:HyperLinkField HeaderText="Profession Id" DataNavigateUrlFormatString="ProfessionEdit.aspx?ProfessionId={0}"
                                        DataNavigateUrlFields="ProfessionId" DataContainer="ProfessionIdSource" DataTextField="ProfessionName" />
                                    <asp:BoundField DataField="SiteProfessionName" HeaderText="Site Profession Name"
                                        SortExpression="[SiteProfessionName]" />
                                    <asp:CheckBoxField DataField="Valid" HeaderText="Valid" SortExpression="[Valid]" />
                                    <asp:BoundField DataField="MetaTitle" HeaderText="Meta Title" SortExpression="[MetaTitle]" />
                                    <asp:BoundField DataField="MetaKeywords" HeaderText="Meta Keywords" SortExpression="[MetaKeywords]" />
                                    <asp:BoundField DataField="MetaDescription" HeaderText="Meta Description" SortExpression="[MetaDescription]" />
                                </Columns>
                                <EmptyDataTemplate>
                                    <b>No Site Profession Found! </b>
                                    <asp:HyperLink runat="server" ID="hypSiteProfession" NavigateUrl="~/admin/SiteProfessionEdit.aspx">Add New</asp:HyperLink>
                                </EmptyDataTemplate>
                            </data:EntityGridView>
                        </div>
                    </li>--%>
                </ul>
                <data:RolesDataSource ID="RolesDataSource1" runat="server" SelectMethod="Find" EnableDeepLoad="True">
                    <DeepLoadProperties Method="IncludeChildren" Recursive="False">
                        <Types>
                            <data:RolesProperty Name="Profession" />
                            <data:RolesProperty Name="SiteRolesCollection" />
                        </Types>
                    </DeepLoadProperties>
                    <Parameters>
                        <data:SqlParameter Name="Parameters">
                            <Filters>
                                <data:RolesFilter Column="ProfessionId" QueryStringField="ProfessionId" />
                            </Filters>
                        </data:SqlParameter>
                        <data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
                    </Parameters>
                </data:RolesDataSource>
                <%--<data:SiteProfessionDataSource ID="SiteProfessionDataSource2" runat="server" SelectMethod="Find"
                    EnableDeepLoad="True">
                    <DeepLoadProperties Method="IncludeChildren" Recursive="False">
                        <Types>
                            <data:SiteProfessionProperty Name="Profession" />
                        </Types>
                    </DeepLoadProperties>
                    <Parameters>
                        <data:SqlParameter Name="Parameters">
                            <Filters>
                                <data:SiteProfessionFilter Column="ProfessionId" QueryStringField="ProfessionId" />
                            </Filters>
                        </data:SqlParameter>
                        <data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
                    </Parameters>
                </data:SiteProfessionDataSource>--%>
            </asp:View>
        </asp:MultiView>
    </div>
</asp:Content>
