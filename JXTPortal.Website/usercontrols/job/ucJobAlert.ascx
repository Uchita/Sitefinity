<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucJobAlert.ascx.cs"
    Inherits="JXTPortal.Website.usercontrols.job.ucJobAlert" %>
<%@ Register TagPrefix="uc1" Namespace="JXTPortal.Website.usercontrols.common" Assembly="JXTPortal.WebSite" %>
<%--<ajaxToolkit:ToolkitScriptManager ID="toolkitScriptManager" runat="server" CombineScripts="true" ScriptMode="Release">
    </ajaxToolkit:ToolkitScriptManager>--%>
<asp:ScriptManager ID="scriptManager" runat="server" />
<h3>
    <JXTControl:ucLanguageLiteral ID="ltMemberCreateAlertHeader" runat="server" SetLanguageCode="LabelJobAlertCriteria" />
</h3>
<div id="search-keyword" class="ctrlHolder">
    <asp:Label ID="lbKeywords" runat="server" CssClass="form-label-left2" AssociatedControlID="txtKeywords">
        <JXTControl:ucLanguageLiteral ID="ltUcJobAlertKeyword" runat="server" SetLanguageCode="LabelEnterKeywords" />
    </asp:Label>
    <asp:TextBox ID="txtKeywords" runat="server" CssClass="form-textbox" MaxLength="100" />
</div>
<div id="search-classification" class="ctrlHolder">
    <p class="label section-heading">
        <JXTControl:ucLanguageLiteral ID="ltUcJobAlertClassificationSubClassification" runat="server"
            SetLanguageCode="LabelClassificationSubClassification" />
    </p>
    <asp:UpdatePanel ID="upProfession" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="ctrlHolder">
                <asp:Label ID="lbProfession" runat="server" AssociatedControlID="ddlProfession" CssClass="form-label-left">
                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral1" runat="server" SetLanguageCode="LabelClassification" />
                </asp:Label>
                <asp:DropDownList ID="ddlProfession" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlProfession_SelectedIndexChanged" />
            </div>
            <div class="ctrlHolder">
                <asp:Label ID="lbRole" runat="server" AssociatedControlID="ddlRole" CssClass="form-label-left">
                    <JXTControl:ucLanguageLiteral ID="ltUcJobAlertSubclassification" runat="server" SetLanguageCode="LabelSubClassification" />
                </asp:Label>
                <asp:DropDownList ID="ddlRole" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
<div id="search-locationarea" class="ctrlHolder">
    <p class="label section-heading">
        <JXTControl:ucLanguageLiteral ID="LabelLocationArea" runat="server" SetLanguageCode="LabelLocationArea" />
        <%--<span class="form-required">*</span>--%>
    </p>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="ctrlHolder">
                <asp:Label ID="lbLocation" runat="server" AssociatedControlID="ddlLocation" CssClass="form-label-left">
                    <JXTControl:ucLanguageLiteral ID="ltUcJobAlertLocation" runat="server" SetLanguageCode="LabelLocation" />
                </asp:Label>
                <%--<span class="form-required">*</span>--%>
                <uc1:DropDownListX ID="ddlLocation" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlLocation_SelectedIndexChanged" />
            </div>
            <div class="ctrlHolder">
                <asp:Label ID="lbBoxArea" runat="server" AssociatedControlID="lstBoxArea" CssClass="form-label-left">
                    <JXTControl:ucLanguageLiteral ID="ltUcJobAlertArea" runat="server" SetLanguageCode="LabelArea" />
                </asp:Label>
                <asp:ListBox ID="lstBoxArea" runat="server" SelectionMode="Multiple" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
<div id="search-salary" class="ctrlHolder">
    <p class="label section-heading">
        <JXTControl:ucLanguageLiteral ID="ltUcJobAlertSalary" runat="server" SetLanguageCode="LabelSalary" />
    </p>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <ul class="alternate">
                <li>
                    <asp:Label ID="lbSalaryType" runat="server" CssClass="salary-type" AssociatedControlID="ddlSalary">
                        <JXTControl:ucLanguageLiteral ID="ltUcJobAlertSalaryType" runat="server" SetLanguageCode="LabelSalaryType" />
                    </asp:Label>
                    <asp:DropDownList runat="server" ID="ddlSalary" DataTextField="SalaryTypeName" AutoPostBack="true" DataValueField="SalaryTypeID"
                        CssClass="form-multiple-column" OnSelectedIndexChanged="ddlSalary_SelectedIndexChanged" />
                </li>
                <li>
                    <asp:Label ID="lbSalaryFrom" runat="server" CssClass="salary-from" AssociatedControlID="txtSalaryLowerBand">
                        <JXTControl:ucLanguageLiteral ID="ltUcJobAlertSalaryFrom" runat="server" SetLanguageCode="LabelSalaryFrom" />
                    </asp:Label>
                    <%--<asp:DropDownList ID="ddlSalaryFrom" runat="server" CssClass="form-multiple-column"
                        AutoPostBack="true" OnSelectedIndexChanged="ddlSalaryFrom_SelectedIndexChanged">
                    </asp:DropDownList>--%>
                    <div class="jobalert-salary-bands">
                        <span class="divSalaryCurrency">
                            <asp:Literal ID="ltlLowerCurrency" runat="server" /></span>
                        <asp:TextBox ID="txtSalaryLowerBand" runat="server" size="10" CssClass="textInput numbersOnly"></asp:TextBox>
                    </div>
                </li>
                <li>
                    <asp:Label ID="lbSalaryTO" runat="server" CssClass="salary-to" AssociatedControlID="txtSalaryUpperBand">
                        <JXTControl:ucLanguageLiteral ID="ltUcJobAlertSalaryTo" runat="server" SetLanguageCode="LabelSalaryTo" />
                    </asp:Label>
                    <%--<asp:DropDownList ID="ddlSalaryTo" runat="server" CssClass="form-multiple-column">
                    </asp:DropDownList>--%>
                    <div class="jobalert-salary-bands">
                        <span class="divSalaryCurrency">
                            <asp:Literal ID="ltlUpperCurrency" runat="server" /></span>
                        <asp:TextBox ID="txtSalaryUpperBand" runat="server" size="10" CssClass="textInput numbersOnly"></asp:TextBox>
                    </div>
                </li>
            </ul>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
<div id="search-worktype" class="ctrlHolder">
    <asp:Label ID="lbWorkType" runat="server" CssClass="form-label-left2" AssociatedControlID="ddlWorkType">
        <JXTControl:ucLanguageLiteral ID="ltUcJobAlertWorktype" runat="server" SetLanguageCode="LabelWorkType" />
    </asp:Label>
    <asp:DropDownList runat="server" ID="ddlWorkType" DataTextField="SiteWorkTypeName"
        DataValueField="WorkTypeID" CssClass="form-multiple-column" />
</div>
