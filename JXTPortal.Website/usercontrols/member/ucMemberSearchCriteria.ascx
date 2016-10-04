<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucMemberSearchCriteria.ascx.cs" Inherits="JXTPortal.Website.usercontrols.member.ucMemberSearchCriteria" %>
<div class="form-header-group">
    <h1 class="form-header">
        <JXTControl:ucLanguageLiteral ID="ltucMemberSearchCriteria" runat="server" SetLanguageCode="LabelSearchCriteria" />
    </h1>
</div>
<p>
    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral1" runat="server" SetLanguageCode="LabelSearchCriteriaWelcome" />
</p>
<div class="form-all">
    <ul class="form-section">
        <li class="form-line" id="ucmembersearchcriteria-avail-status">
            <label class="form-label-left">
                <JXTControl:ucLanguageLiteral ID="ucAvailableStatus" runat="server" SetLanguageCode="LabelAvailableStatus" />
                </label>
            <div class="form-input">
                <asp:DropDownList ID="ddlAvailability" TabIndex="25" runat="server" class="form-dropdown">
                </asp:DropDownList>
            </div>
        </li>
        <li class="form-line" id="ucmembersearchcriteria-avail-date">
            <label class="form-label-left">
                <JXTControl:ucLanguageLiteral ID="ucAvailabilityDate" runat="server" SetLanguageCode="LabelAvailabilityDate" />
                </label>
            <div class="form-input">
                <span class="form-sub-label-container">
                    <asp:TextBox runat="server" ID="txtAvailabilityDate" Text='<%# Bind("AvailabilityFromDate", "{0:dd/MM/yyyy}") %>'
                        MaxLength="10" CssClass="form-textbox2"></asp:TextBox>
                    <asp:ImageButton ID="ibFirstApprovedDate" runat="server" SkinID="CalendarImageButton"
                        ImageUrl="/images/minical.gif" CausesValidation="False" />
                    <ajaxToolkit:CalendarExtender ID="cal_dataFirstApprovedDate" runat="server" Format="dd/MM/yyyy"
                        TargetControlID="txtAvailabilityDate" PopupButtonID="ibFirstApprovedDate">
                    </ajaxToolkit:CalendarExtender>
                    <asp:CompareValidator ID="cvFirstApprovedDate" runat="server" ControlToValidate="txtAvailabilityDate"
                        Type="Date" Operator="DataTypeCheck" ValidationGroup="MemberSearchCriteria" SetFocusOnError="true" Display="Dynamic"></asp:CompareValidator>
                    <%--<asp:RangeValidator ID="rvFirstApprovedDate" runat="server" ControlToValidate="txtAvailabilityDate"
                        Type="Date" SetFocusOnError="true" Display="Dynamic" ValidationGroup="MemberSearchCriteria">
                    </asp:RangeValidator>--%>
                </span>
            </div>
        </li>
        <li class="form-line" id="ucmemberedit-salarytype">
            <label class="form-label-left">
                <JXTControl:ucLanguageLiteral ID="ucSalaryType" runat="server" SetLanguageCode="LabelSalaryType" /></label>
            <div class="form-input">
                <asp:DropDownList runat="server" ID="ddlSalary" DataTextField="SalaryTypeName" DataValueField="SalaryTypeID"
                CssClass="form-multiple-column" />
            </div>
        </li>
            
        <li class="form-line" id="ucmemberedit-desired-pay">
            <label class="form-label-left">
                <JXTControl:ucLanguageLiteral ID="ucExpectedSalary" runat="server" SetLanguageCode="LabelSalary" />
                </label>
            
            <div class="form-input">
                <span class="form-sub-label-container"><span class='salary-from'><JXTControl:ucLanguageLiteral ID="ucFrom" runat="server" SetLanguageCode="LabelFrom" /></span>
                    
                        <span class="divSalaryCurrency"><asp:Literal ID="ltlLowerCurrency" runat="server" /></span>
                        <asp:TextBox ID="txtSalaryLowerBand" runat="server" size="10" CssClass="textInput numbersOnly"></asp:TextBox>
                </span>
                <span class="form-sub-label-container"><span class='salary-to'><JXTControl:ucLanguageLiteral ID="ucTo" runat="server" SetLanguageCode="LabelTo" /></span>
                    <span class="divSalaryCurrency"><asp:Literal ID="ltlUpperCurrency" runat="server" /></span>
                        <asp:TextBox ID="txtSalaryUpperBand" runat="server" size="10" CssClass="textInput numbersOnly"></asp:TextBox>
                </span>

            </div>
        </li>
        <li class="form-line" id="memberEdit-PrefClassification">
            <label class="form-label-left">
                <JXTControl:ucLanguageLiteral ID="ucPreferredClassification" runat="server" SetLanguageCode="LabelPreferredClassification" />
                </label>
            <div class="form-input">
                <asp:DropDownList ID="ddlprefClassification" TabIndex="25" runat="server" class="form-dropdown"
                    AutoPostBack="true" OnSelectedIndexChanged="ddlprefClassification_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
        </li>
        <li class="form-line" id="memberEdit-PrefSubClassification">
            <label class="form-label-left">
                <JXTControl:ucLanguageLiteral ID="ucPreferredSubClassification" runat="server" SetLanguageCode="LabelPreferredSubClassification" />
                </label>
            <div class="form-input">
                <asp:UpdatePanel ID="upSubClassification" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlprefSubClassification" TabIndex="25" runat="server" class="form-dropdown" />
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlprefClassification" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </li>
        <li class="form-line" id="memberSearchCriteria-Country">
            <label class="form-label-left">
                <JXTControl:ucLanguageLiteral ID="ucCountry" runat="server" SetLanguageCode="LabelCountry" />
                <span class="form-required">*</span>
            </label>
            <div class="form-input">
                <asp:DropDownList ID="ddlCountry" TabIndex="11" runat="server" AutoPostBack="True"
                    class="form-dropdown" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvCountry" runat="server" ControlToValidate="ddlCountry"
                    InitialValue="0" ValidationGroup="MemberSearchCriteria" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
        </li>
        <li class="form-line" id="memberSearchCriteria-Location">
            <label class="form-label-left">
                <JXTControl:ucLanguageLiteral ID="ucLocation" runat="server" SetLanguageCode="LabelPreferredLocation" />
                <span class="form-required">*</span>
            </label>
            <div class="form-input">
                <asp:UpdatePanel ID="upLocation" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlLocation" TabIndex="11" runat="server" AutoPostBack="True"
                            class="form-dropdown" OnSelectedIndexChanged="ddlLocation_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:CustomValidator ID="ctmMemberLocation" runat="server" OnServerValidate="ctmMemberLocation_ServerValidate"
                            ValidationGroup="MemberSearchCriteria" SetFocusOnError="true" Display="Dynamic"></asp:CustomValidator>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlCountry" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </li>
        <li class="form-line" id="memberSearchCriteria-Area">
            <label class="form-label-left">
                <JXTControl:ucLanguageLiteral ID="ucArea" runat="server" SetLanguageCode="LabelPreferredArea" />
                <span class="form-required">*</span>
            </label>
            <div class="form-input">
                <asp:UpdatePanel ID="upArea" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlArea" TabIndex="11" runat="server" class="form-dropdown">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvArea" runat="server" ControlToValidate="ddlArea"
                            InitialValue="0" ValidationGroup="MemberSearchCriteria" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlLocation" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </li>
        
        <li class="form-line" id="ucmembersearchcriteria-bottom-button">
            <div class="form-input-wide">
                <div class="form-buttons-wrapper">
                    <asp:Button ID="btnSubmit" runat="server" Text="Save" OnClick="btnSubmit_Click" CssClass="mini-new-buttons"
                        ValidationGroup="MemberSearchCriteria" />
                </div>
            </div>
        </li>
    </ul>
</div>