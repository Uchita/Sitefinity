<%@ Page Title="Site Custom Country Location Area Import" Language="C#" MasterPageFile="~/MasterPages/admin.Master" AutoEventWireup="true" CodeBehind="SiteCustomCountryLocationAreaImport.aspx.cs" Inherits="JXTPortal.Website.Admin.SiteCustomCountryLocationAreaImport" %>
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
                        <asp:Repeater ID="rptCountry" runat="server" OnItemDataBound="rptCountry_ItemDataBound">
                            <HeaderTemplate>
                                <table cellpadding="3" border="0" style="margin-right: 150px; float: left">
                                    <thead>
                                        <tr>
                                            <th>
                                                Country
                                            </th>
                                        </tr>
                                    </thead>
                                    <tbody>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:Literal ID="ltName" runat="server" />
                                        <asp:HiddenField ID="hfCountryID" runat="server" />
                                        <asp:HiddenField ID="hfCountryName" runat="server" />
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
                                            <strong>Total Countries:</strong>
                                            <asp:Literal ID="ltTotal" runat="server" />
                                            <br />
                                        </td>
                                    </tr>
                                </tfoot>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                        <asp:Repeater ID="rptLocation" runat="server" OnItemDataBound="rptLocation_ItemDataBound">
                            <HeaderTemplate>
                                <table cellpadding="3" border="0" style="margin-right: 150px; float: left">
                                    <thead>
                                        <tr>
                                            <th>
                                                Country
                                            </th>
                                            <th>
                                                Location
                                            </th>
                                        </tr>
                                    </thead>
                                    <tbody>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:Literal ID="ltCountryName" runat="server" />
                                    </td>
                                    <td>
                                        <asp:Literal ID="ltName" runat="server" />
                                        <asp:HiddenField ID="hfLocationID" runat="server" />
                                        <asp:HiddenField ID="hfLocationName" runat="server" />
                                        <asp:HiddenField ID="hfCountryID" runat="server" />
                                        <asp:HiddenField ID="hfCountryName" runat="server" />
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
                                            <strong>Total Location:</strong>
                                            <asp:Literal ID="ltTotal" runat="server" />
                                            <br />
                                        </td>
                                    </tr>
                                </tfoot>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                        <asp:Repeater ID="rptArea" runat="server" OnItemDataBound="rptArea_ItemDataBound">
                            <HeaderTemplate>
                                <table cellpadding="3" border="0" style="margin-right: 150px;">
                                    <thead>
                                        <tr>
                                            <th>
                                                Country
                                            </th>
                                            <th>
                                                Location
                                            </th>
                                            <th>
                                                Area
                                            </th>
                                        </tr>
                                    </thead>
                                    <tbody>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:Literal ID="ltCountryName" runat="server" />
                                    </td>
                                    <td>
                                        <asp:Literal ID="ltLocationName" runat="server" />
                                    </td>
                                    <td>
                                        <asp:Literal ID="ltName" runat="server" />
                                        <asp:HiddenField ID="hfAreaID" runat="server" />
                                        <asp:HiddenField ID="hfAreaName" runat="server" />
                                        <asp:HiddenField ID="hfLocationID" runat="server" />
                                        <asp:HiddenField ID="hfLocationName" runat="server" />
                                        <asp:HiddenField ID="hfCountryID" runat="server" />
                                        <asp:HiddenField ID="hfCountryName" runat="server" />
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
                                            <strong>Total Area:</strong>
                                            <asp:Literal ID="ltTotal" runat="server" />
                                            <br />
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
                                    <i>Please confirm, this will delete all existing Site Country Location Area and replaced by imported ones</i>
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
    Custom Site Country Location Area Import
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
