<%@ Page Title="All Job Statistics - Advertiser Not Posted in x days" Language="C#" MasterPageFile="~/MasterPages/admin.Master" AutoEventWireup="true"
    CodeBehind="AdvertisersNotPostedSince.aspx.cs" Inherits="JXTPortal.Website.Admin.reports.AdvertisersNotPostedSince" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    Advertisers who have not posted in [X] days
    
<a href='http://support.jxt.com.au/solution/articles/149919-advertisers-not-posted-since' class='jxt-help-page' title='click here for help on this page'  target='_blank'>help on this page</a>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-all">
        <asp:Panel ID="pnlSite" runat="server">
            <ul class="form-section">
                <li class="form-line">
                    <label class="form-label-left">
                        Site:&nbsp;
                    </label>
                    <div class="form-input-wide" style="width: 600px;">
                        <asp:DropDownList ID="ddlSite" runat="server" />
                    </div>
                </li>
            </ul>
        </asp:Panel>
        <ul class="form-section">
            <li class="form-line">
                <label class="form-label-left">
                    <asp:Literal ID="litDaysSinceLastPost" runat="server" Text="Days Since Last Post" />
                </label>
                <div class="form-input-wide" style="width: 600px;">
                    <asp:TextBox runat="server" ID="tbDaysSinceLastPost"></asp:TextBox>&nbsp;Maximum:
                    99
                    <asp:RequiredFieldValidator ID="rvDuration" runat="server" ControlToValidate="tbDaysSinceLastPost"
                        ErrorMessage="Required" Display="Dynamic" />
                    <asp:CompareValidator ID="cvDuration" runat="server" ControlToValidate="tbDaysSinceLastPost"
                        Type="Integer" Operator="GreaterThan" ValueToCompare="0" ErrorMessage="Invalid Days Since Last Post. "
                        Display="Dynamic"></asp:CompareValidator>
                    <asp:CompareValidator ID="cvDuration2" runat="server" ControlToValidate="tbDaysSinceLastPost"
                        Type="Integer" Operator="LessThanEqual" ValueToCompare="99" ErrorMessage="Maximum duration is 99. "
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
    <asp:GridView ID="gvAdvertiserNotPostedSince" runat="server" AutoGenerateColumns="false"
        CssClass="grid" AlternatingRowStyle-CssClass="grid-alt-row">
        <HeaderStyle CssClass="grid-header" />
        <Columns>
            <asp:BoundField ReadOnly="true" HeaderText="ID" DataField="AdvertiserID" />
            <asp:BoundField ReadOnly="true" HeaderText="Company Name" DataField="CompanyName" />
            <asp:BoundField ReadOnly="true" HeaderText="Account Type" DataField="AdvertiserAccountTypeName" />
            <asp:BoundField ReadOnly="true" HeaderText="Business Type" DataField="AdvertiserBusinessTypeName" />
            <asp:BoundField ReadOnly="true" HeaderText="Account Status" DataField="AdvertiserAccountStatusName" />
            <asp:BoundField ReadOnly="true" HeaderText="Email" DataField="AccountsPayableEmail" />
            
        </Columns>
    </asp:GridView>
</asp:Content>
