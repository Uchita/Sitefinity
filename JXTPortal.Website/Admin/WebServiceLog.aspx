<%@ Page Language="C#" MasterPageFile="~/MasterPages/admin.Master" AutoEventWireup="true"
    Theme="Default" CodeBehind="WebServiceLog.aspx.cs" Inherits="JXTPortal.Website.Admin.WebServiceLog"
    Title="Web  Service Log" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    Web Service Log <a href='#' class='jxt-help-page' title='click here for help on this page'
        target='_blank'>help on this page</a>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="toolkitScriptManager" runat="server" CombineScripts="true"
        ScriptMode="Release">
    </ajaxToolkit:ToolkitScriptManager>
    <div class="form-all">
        <asp:UpdatePanel ID="updatePanel" runat="server">
            <ContentTemplate>
                <asp:MultiView ID="ViewWevServiceLog" runat="server" ActiveViewIndex="0">
                    <asp:View ID="ViewAdvertiser" runat="server">
                        <%--<asp:ScriptManager ID="scriptManager" runat="server" />--%>
                        <table class="tblNoBorder">
                            <tbody>
                                <tr>
                                    <asp:PlaceHolder ID="phSite" runat="server">
                                        <td>
                                            <label>
                                                Site</label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlSite" runat="server" DataTextField="SiteName" DataValueField="SiteID"
                                                Width="250" AutoPostBack="true" class="form-dropdown" OnSelectedIndexChanged="ddlSite_SelectedIndexChanged" />
                                            <asp:RequiredFieldValidator ID="rfvSite" runat="server" ControlToValidate="ddlSite"
                                                InitialValue="0" ErrorMessage="Please select a Site" ValidationGroup="DownloadExport" />
                                        </td>
                                    </asp:PlaceHolder>
                                    <td>
                                        <label>
                                            Advertiser</label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlAdvertiser" class="form-dropdown" runat="server" Width="250" />
                                        <asp:RequiredFieldValidator ID="rfvAdvertiser" runat="server" ControlToValidate="ddlAdvertiser"
                                            InitialValue="0" ErrorMessage="Please select a Advertiser" ValidationGroup="DownloadExport" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label>
                                            Date From</label>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="tbDateFrom" MaxLength="10" Width="250"></asp:TextBox>
                                        <asp:ImageButton ID="ibDateFrom" runat="server" SkinID="CalendarImageButton" CausesValidation="False" />
                                        <ajaxToolkit:CalendarExtender ID="cal_DateFrom" runat="server" Format="dd/MM/yyyy"
                                            TargetControlID="tbDateFrom" PopupButtonID="ibDateFrom">
                                        </ajaxToolkit:CalendarExtender>
                                        <asp:CustomValidator ID="cvDateFrom" runat="server" ControlToValidate="tbDateFrom"
                                            OnServerValidate="cvDateFrom_ServerValidate" />
                                    </td>
                                    <td>
                                        <label>
                                            Date To</label>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="tbDateTo" MaxLength="10" Width="250"></asp:TextBox>
                                        <asp:ImageButton ID="ibDateTo" runat="server" SkinID="CalendarImageButton" CausesValidation="False" />
                                        <ajaxToolkit:CalendarExtender ID="cal_DateTo" runat="server" Format="dd/MM/yyyy"
                                            TargetControlID="tbDateTo" PopupButtonID="ibDateTo">
                                        </ajaxToolkit:CalendarExtender>
                                        <asp:CustomValidator ID="cvDateTo" runat="server" ControlToValidate="tbDateFrom"
                                            OnServerValidate="cvDateTo_ServerValidate" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="cbShowOnlyFailed" runat="server" Text="Show Only Failed" /><asp:Button
                                            ID="btnSearch" runat="server" Text="Search" CssClass="jxtadminbutton" OnClick="btnSearch_Click"
                                            Style="margin-left: 94px" />
                                    </td>
                                    <td colspan="2">
                                        <asp:Button ID="btnDownloadExcel" runat="server" Text="Download Export List" CssClass="jxtadminbutton"
                                            Style="background: #5bb75b" ValidationGroup="DownloadExport" OnClick="btnDownloadExcel_Click" />
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        <asp:Label ID="lblErrorMsg" runat="server" class="form-required" Visible="false"
                            CssClass="form-message" />
                        <asp:Repeater ID="rptWebServiceLog" runat="server" OnItemDataBound="rptWebServiceLog_ItemDataBound"
                            OnItemCommand="rptWebServiceLog_ItemCommand">
                            <HeaderTemplate>
                                <table cellpadding="3" border="0" class="grid">
                                    <tbody>
                                        <tr class="grid-header">
                                            <th scope="col">
                                                Site Name
                                            </th>
                                            <th scope="col">
                                                Advertiser
                                            </th>
                                            <th scope="col">
                                                Created Date
                                            </th>
                                            <th scope="col">
                                                Method Invoked
                                            </th>
                                            <th scope="col">
                                                View
                                            </th>
                                            <th scope="col">
                                                Download
                                            </th>
                                            <th scope="col">
                                                Total Sent
                                            </th>
                                            <th scope="col">
                                                Total Inserted
                                            </th>
                                            <th scope="col">
                                                Total Updated
                                            </th>
                                            <th scope="col">
                                                Total Archived
                                            </th>
                                            <th scope="col">
                                                Total Failed
                                            </th>
                                            <th scope="col">
                                                &nbsp;
                                            </th>
                                        </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:HiddenField ID="hfWebServiceLogID" runat="server" />
                                        <asp:Literal ID="ltSiteName" runat="server"></asp:Literal>
                                    </td>
                                    <td>
                                        <asp:HyperLink ID="hlAdvertiser" runat="server" />
                                    </td>
                                    <td>
                                        <asp:Literal ID="ltCreatedDate" runat="server"></asp:Literal>
                                    </td>
                                    <td>
                                        <asp:Literal ID="ltMethodInvoked" runat="server"></asp:Literal>
                                    </td>
                                    <td>
                                        <asp:HyperLink ID="hlViewRequest" runat="server" Text="Request" Target="_blank" />
                                        &nbsp;
                                        <asp:HyperLink ID="hlViewResponse" runat="server" Text="Response" Target="_blank" />
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="lbInputXML" runat="server" Text="Request" CommandName="DownloadInputXML" />
                                        &nbsp;
                                        <asp:LinkButton ID="lbOutputResponse" runat="server" Text="Response" CommandName="DownloadResponse" />
                                    </td>
                                    <td>
                                        <asp:Literal ID="ltTotalSent" runat="server"></asp:Literal>
                                    </td>
                                    <td>
                                        <asp:Literal ID="ltTotalInserted" runat="server"></asp:Literal>
                                    </td>
                                    <td>
                                        <asp:Literal ID="ltTotalUpdated" runat="server"></asp:Literal>
                                    </td>
                                    <td>
                                        <asp:Literal ID="ltTotalArchived" runat="server"></asp:Literal>
                                    </td>
                                    <td>
                                        <asp:Literal ID="ltTotalFailed" runat="server"></asp:Literal>
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="lbDetail" runat="server" Text="Detail" />
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </tbody> </table>
                            </FooterTemplate>
                        </asp:Repeater>
                        <asp:Repeater ID="rptPage" runat="server" OnItemCommand="rptPage_ItemCommand" OnItemDataBound="rptPage_ItemDataBound">
                            <HeaderTemplate>
                                <tfoot>
                                    <tr>
                                        <td colspan="10">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="litPage" runat="server" Text="Page:" />
                                                    </td>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <td>
                                    <asp:LinkButton ID="lbPageNo" runat="server" CommandName="Page" ValidationGroup="WebSeviceLog" />
                                </td>
                            </ItemTemplate>
                            <FooterTemplate>
                                </tr> </table> </td> </tr> </tfoot>
                            </FooterTemplate>
                        </asp:Repeater>
                    </asp:View>
                </asp:MultiView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
