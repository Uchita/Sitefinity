<%@ Page Title="Custom Profession/Role Import" Language="C#" MasterPageFile="~/MasterPages/admin.Master"
    AutoEventWireup="true" CodeBehind="SiteProfessionRoleImport.aspx.cs" Inherits="JXTPortal.Website.Admin.SiteProfessionRoleImport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:MultiView ID="FormView1" runat="server" ActiveViewIndex="0">
        <asp:View ID="ViewProfessionRole" runat="server">
        <asp:ScriptManager ID="scriptManager" runat="server" />
            <div class="form-all">
                <span class="form-message">
                    <asp:Literal ID="ltlMessage" runat="server" /></span>

                    <asp:Button ID="btnDownloadSample" runat="server" Text="Download Sample .xlsx file for Custom Import" 
                                CssClass="jxtadminbutton" onclick="btnDownloadSample_Click" style="float: right" /><br />
                    <i style="float: right; clear:both;">Please download the sample file, make changes and upload the same file</i>
                <ul class="form-section">
                    <li class="form-line" id="adv-selectDocument-field">
                        <label class="form-label-left">
                            Select Document:</label>
                        <div class="form-input" style="width: 100%;">
                            <asp:FileUpload ID="docInput" runat="server" class="form-textbox" />&nbsp;<asp:Button
                                ID="btnSubmit" runat="server" Text="Submit" CssClass="jxtadminbutton" OnClick="btnSubmit_Click" />
                                <br /><i>Allows only .xls and .xlsx format</i>
                        </div>
                    </li>
                </ul>
                <asp:Repeater ID="rptList" runat="server" OnItemDataBound="rptList_ItemDataBound">
                    <ItemTemplate>
                        <h3>
                            <asp:Literal ID="ltLanguage" runat="server" /></h3>
                        <asp:HiddenField ID="hfLanguageID" runat="server" />
                        <asp:Repeater ID="rptProfession" runat="server" OnItemDataBound="rptProfession_ItemDataBound">
                            <HeaderTemplate>
                                <table cellpadding="3" border="0" style="margin-right: 150px; float: left">
                                    <thead>
                                        <tr>
                                            <th>
                                                Profession
                                            </th>
                                            <th>
                                                Friendly Name
                                            </th>
                                            <th>
                                                Result
                                            </th>
                                        </tr>
                                    </thead>
                                    <tbody>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Literal ID="ltRow" runat="server" />
                                    <td>
                                        <asp:Literal ID="ltName" runat="server" />
                                        <asp:HiddenField ID="hfProfessionID" runat="server" />
                                        <asp:HiddenField ID="hfProfessionName" runat="server" />
                                    </td>
                                    <td>
                                        <asp:Literal ID="ltFriendlyName" runat="server" />
                                    </td>
                                    <td>
                                        <asp:Literal ID="ltAction" runat="server" />
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </tbody>
                                <tfoot>
                                    <tr>
                                        <td colspan="3">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <strong>Total Professions:</strong>
                                            <asp:Literal ID="ltTotal" runat="server" />
                                            <br />
                                            <strong>Already Exist:</strong>
                                            <asp:Literal ID="ltExist" runat="server" /><br />
                                            <strong>New Professions:</strong>
                                            <asp:Literal ID="ltNew" runat="server" /><br />
                                        </td>
                                    </tr>
                                </tfoot>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                        <asp:Repeater ID="rptRoles" runat="server" OnItemDataBound="rptRoles_ItemDataBound">
                            <HeaderTemplate>
                                <table>
                                    <thead>
                                        <tr>
                                            <th>
                                                Profession
                                            </th>
                                            <th>
                                                Role
                                            </th>
                                            <th>
                                                Friendly Name
                                            </th>
                                            <th>
                                                Result
                                            </th>
                                        </tr>
                                    </thead>
                                    <tbody>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Literal ID="ltRow" runat="server" />
                                    <td>
                                        <asp:Literal ID="ltProfessionName" runat="server" />
                                    </td>
                                    <td>
                                        <asp:Literal ID="ltName" runat="server" />
                                        <asp:HiddenField ID="hfRoleID" runat="server" />
                                        <asp:HiddenField ID="hfRoleName" runat="server" />
                                        <asp:HiddenField ID="hfProfessionID" runat="server" />
                                        <asp:HiddenField ID="hfProfessionName" runat="server" />
                                    </td>
                                    <td>
                                        <asp:Literal ID="ltFriendlyName" runat="server" />
                                    </td>
                                    <td>
                                        <asp:Literal ID="ltAction" runat="server" />
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </tbody>
                                <tfoot>
                                    <tr>
                                        <td colspan="4">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <strong>Total Roles:</strong>
                                            <asp:Literal ID="ltTotal" runat="server" />
                                            <br />
                                            <strong>Already Exist:</strong>
                                            <asp:Literal ID="ltExist" runat="server" /><br />
                                            <strong>New Roles:</strong>
                                            <asp:Literal ID="ltNew" runat="server" /><br />
                                        </td>
                                    </tr>
                                </tfoot>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                    </ItemTemplate>
                </asp:Repeater>
                <ul>
                    <li class="form-line">
                        <div class="form-input-wide">
                            <div class="form-buttons-wrapper-left">
                                <asp:PlaceHolder ID="phConfirm" runat="server" Visible="false">
                                    <asp:CheckBox ID="cbConfirm" runat="server" Text="" AutoPostBack="true" OnCheckedChanged="cbConfirm_CheckedChanged" />&nbsp;
                                    <i>Please confirm, this will only upload the new Profression/Roles</i>
                                    <asp:Button ID="btnConfirm" runat="server" Text="Save" CssClass="jxtadminbutton"
                                        OnClick="btnConfirm_Click" Visible="false" />
                                    
                                </asp:PlaceHolder>
                            </div>
                            <br /><br />
                            <div class="form-buttons-wrapper-left">
                                <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="jxtadminbutton" OnClick="btnBack_Click" />
                            </div>

                        </div>
                    </li>
                </ul>
            </div>
        </asp:View>
    </asp:MultiView>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    Custom Profession/Role Import <a href='http://support.jxt.com.au/solution/articles/116445-site-professions-roles'
        class='jxt-help-page' title='click here for help on this page' target='_blank'>help
        on this page</a>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
