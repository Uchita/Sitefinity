<%@ Page Title="All Job Statistics - Job Application and Views Detail" Language="C#" MasterPageFile="~/MasterPages/admin.Master" AutoEventWireup="true"
    CodeBehind="JobApplicationAndViewsDetail.aspx.cs" Inherits="JXTPortal.Website.Admin.reports.JobApplicationAndViewsDetail" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    Job Application And Views Detail
    <a href='http://support.jxt.com.au/solution/articles/116430-job-application-and-views-detail' class='jxt-help-page' title='click here for help on this page'  target='_blank'>help on this page</a>

</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<ajaxToolkit:ToolkitScriptManager ID="toolkitScriptManager" runat="server" CombineScripts="true" ScriptMode="Release" ></ajaxToolkit:ToolkitScriptManager>
    <div class="form-all">
        <asp:Panel ID="pnlSite" runat="server">
            <ul class="form-section">
                <li class="form-line">
                    <label class="form-label-left">
                        Site:&nbsp;
                    </label>
                    <div class="form-input-wide">
                        <asp:DropDownList ID="ddlSite" runat="server" />
                    </div>
                </li>
            </ul>
        </asp:Panel>
        <ul class="form-section">
            <li class="form-line">
                <label class="form-label-left">
                    <asp:Literal ID="litDateFrom" runat="server" Text="Date From" />
                </label>
                <div class="form-input-wide" style="width: 600px;">
                    <asp:TextBox runat="server" ID="tbDateFrom" MaxLength="10"></asp:TextBox>
                    <asp:ImageButton ID="ibDateFrom" runat="server" SkinID="CalendarImageButton" CausesValidation="False"
                        ImageUrl="/images/minical.gif" />
                    <asp:RequiredFieldValidator ID="ReqValDateFrom" runat="server" ControlToValidate="tbDateFrom"
                        ErrorMessage="Required" Display="Dynamic" />
                    <ajaxToolkit:CalendarExtender ID="cal_tbDateFrom" runat="server" Format="dd/MM/yyyy"
                        TargetControlID="tbDateFrom" PopupButtonID="ibDateFrom">
                    </ajaxToolkit:CalendarExtender>
                    <asp:CustomValidator ID="cvDateFrom" runat="server" ControlToValidate="tbDateFrom" OnServerValidate="cvDateFrom_ServerValidate" />
                </div>
            </li>
            <li class="form-line">
                <label class="form-label-left">
                    <asp:Literal ID="litDuration" runat="server" Text="Duration" />
                </label>
                <div class="form-input-wide" style="width: 600px;">
                    <asp:TextBox runat="server" ID="tbDuration"></asp:TextBox>&nbsp;Maximum: 99
                    <asp:RequiredFieldValidator ID="rvDuration" runat="server" ControlToValidate="tbDuration"
                        ErrorMessage="Required" Display="Dynamic" />
                    <asp:CompareValidator ID="cvDuration" runat="server" ControlToValidate="tbDuration"
                        Type="Integer" Operator="GreaterThan" ValueToCompare="0" ErrorMessage="Invalid Duration. "
                        Display="Dynamic"></asp:CompareValidator>
                    <asp:CompareValidator ID="cvDuration2" runat="server" ControlToValidate="tbDuration"
                        Type="Integer" Operator="LessThanEqual" ValueToCompare="99" ErrorMessage="Maximum duration is 99."
                        Display="Dynamic"></asp:CompareValidator>
                </div>
            </li>
            <li class="form-line" id="reg-bottom-button">
                <div class="form-input-wide">
                    <div class="form-buttons-wrapper">
                        <asp:Button ID="btnRun" runat="server" CausesValidation="True" CommandName="Run"
                            Text="Run" CssClass="jxtadminbutton" OnClick="btnRun_Click" />
                    </div>
                </div>
            </li>
        </ul>
    </div>
    <table>
        <tr>
            <th>Views</th>
            <th>Applications</th>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gvViewsDetail" runat="server" AutoGenerateColumns="false"
                    CssClass="grid" AlternatingRowStyle-CssClass="grid-alt-row">
                    <HeaderStyle />
                    <Columns>
                        <asp:BoundField ReadOnly="true" HeaderText="Date" DataField="ViewDate" DataFormatString="{0:MMMM d, yyyy}" />
                        <asp:BoundField ReadOnly="true" HeaderText="View Referral" DataField="ViewDomainReferral" />
                        <asp:BoundField ReadOnly="true" HeaderText="View Count" DataField="ViewCount" />
                        <%--<asp:BoundField ReadOnly="true" HeaderText="Application Date" DataField="ApplicationDate" DataFormatString="{0:MMMM d, yyyy}" />
                        <asp:BoundField ReadOnly="true" HeaderText="Application Referral" DataField="ApplicationDomainReferral" />
                        <asp:BoundField ReadOnly="true" HeaderText="Application Count" DataField="ApplicationCount" />--%>
                    </Columns>
                </asp:GridView>

            </td>
            <td>
                
                <asp:GridView ID="gvJobApplicationDetail" runat="server" AutoGenerateColumns="false"
                    CssClass="grid" AlternatingRowStyle-CssClass="grid-alt-row" onrowdatabound="gvJobApplicationDetail_RowDataBound">
                    <HeaderStyle CssClass="grid-header" />
                    <Columns>
                        <asp:BoundField ReadOnly="true" HeaderText="Date" DataField="ApplicationDate" DataFormatString="{0:MMMM d, yyyy}" />
                        <asp:BoundField ReadOnly="true" HeaderText="Referral" DataField="URL_Referral" />
                        <asp:BoundField ReadOnly="true" HeaderText="Applied With" DataField="AppliedWith" />
                        <asp:BoundField ReadOnly="true" HeaderText="Application Count" DataField="ApplicationCount" />
                        <%--<asp:BoundField ReadOnly="true" HeaderText="Application Date" DataField="ApplicationDate" DataFormatString="{0:MMMM d, yyyy}" />
                        <asp:BoundField ReadOnly="true" HeaderText="Application Referral" DataField="ApplicationDomainReferral" />
                        <asp:BoundField ReadOnly="true" HeaderText="Application Count" DataField="ApplicationCount" /><asp:HyperLinkField DataNavigateUrlFields="ApplicationDate" DataNavigateUrlFormatString="JobApplicationDetail.aspx?date={0}" Text="View Details" />--%>
                        
                    <asp:TemplateField HeaderText="View Details"  ItemStyle-HorizontalAlign="Center"          FooterStyle-HorizontalAlign="Center">
                      <ItemTemplate>
                          <asp:HyperLink ID="link" runat="server" Text='View Details by Date' Target="_blank" />
                      </ItemTemplate>
                    </asp:TemplateField>
                    </Columns>
                </asp:GridView>

            </td>
        </tr>

    </table>
    
</asp:Content>
