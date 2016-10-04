<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JobAlerts.aspx.cs" MasterPageFile="~/MasterPages/admin.Master" Inherits="JXTPortal.Website.Admin.reports.JobAlerts" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    Member Job Alerts Export
    <a href='http://support.jxt.com.au/solution/articles/116432-job-alerts' class='jxt-help-page' title='click here for help on this page'  target='_blank'>help on this page</a>

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
                    <div class="form-input-wide" style="width: 600px;">
                        <asp:DropDownList ID="ddlSite" runat="server" />
                    </div>
                </li>
            </ul>
        </asp:Panel>
        <ul class="form-section">
            <li class="form-line">
                <label class="form-label-left">
                    Date From:
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
                    Date To:
                </label>
                <div class="form-input-wide" style="width: 600px;">
                    <asp:TextBox runat="server" ID="tbDateTo" MaxLength="10"></asp:TextBox>
                    <asp:ImageButton ID="ibDateTo" runat="server" SkinID="CalendarImageButton" CausesValidation="False"
                        ImageUrl="/images/minical.gif" />
                    <asp:RequiredFieldValidator ID="ReqValDateTo" runat="server" ControlToValidate="tbDateTo"
                        ErrorMessage="Required" Display="Dynamic" />
                    <ajaxToolkit:CalendarExtender ID="cal_tbDateTo" runat="server" Format="dd/MM/yyyy"
                        TargetControlID="tbDateTo" PopupButtonID="ibDateTo">
                    </ajaxToolkit:CalendarExtender>
                    
                    <asp:CustomValidator ID="cvDateTo" runat="server" ControlToValidate="tbDateTo" OnServerValidate="cvDateTo_ServerValidate" />
                </div>
            </li>
            <li class="form-line" id="reg-bottom-button">
                <div class="form-input-wide">
                    <div class="form-buttons-wrapper">
                        <asp:Button ID="btnRun" runat="server" CausesValidation="True"
                            Text="Download" CssClass="jxtadminbutton" OnClick="btnRun_Click" />
                    </div>
                </div>
            </li>
        </ul>
    </div>
</asp:Content>
