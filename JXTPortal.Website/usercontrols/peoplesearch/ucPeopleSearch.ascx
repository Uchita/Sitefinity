<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucPeopleSearch.ascx.cs"
    Inherits="JXTPortal.Website.usercontrols.peoplesearch.ucPeopleSearch" %>
<%--<div id="content">
    <div class="content-holder">--%>
        <div class="adv-search-holder">
            <div class="adv-searchleft">
                <div class="form-all">
                    <ul class="form-section">
                        <li id="search-keywords" class="form-line">
                            <label class="form-label-left2">
                                <JXTControl:ucLanguageLiteral ID="ltpplSearchkeyword" runat="server" SetLanguageCode="LabelEnterKeywords" />
                                :
                            </label>
                            <div class="form-input">
                                <asp:TextBox ID="tbKeyword" runat="server" CssClass="form-textbox" /></div>
                        </li>
                        <li id="search-classification" class="form-line">
                            <label class="form-label-left2">
                                <JXTControl:ucLanguageLiteral ID="ltpplSearchClass" runat="server" SetLanguageCode="LabelClassification" />
                                :
                            </label>
                            <div class="form-input">
                                <asp:DropDownList ID="ddlCategory" runat="server" AutoPostBack="true" CssClass="form-dropdown"
                                    OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" />
                            </div>
                        </li>
                        <li id="reg-business-type" class="form-line">
                            <label class="form-label-left2">
                                <JXTControl:ucLanguageLiteral ID="ltpplSearchCountry" runat="server" SetLanguageCode="LabelCountry" />
                                :<span class="form-required">*</span>
                            </label>
                            <div class="form-input">
                                <asp:DropDownList ID="ddlCountry" runat="server" AutoPostBack="true" CssClass="form-dropdown"
                                    OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged" />
                                <asp:RequiredFieldValidator ID="rvCountry" runat="server" SetFocusOnError="true"
                                    Display="Dynamic" ControlToValidate="ddlCountry" InitialValue="0" ErrorMessage="*" Display="Dynamic" />
                            </div>
                        </li>
                        <li id="Li2" class="form-line">
                            <label class="form-label-left2">
                                <JXTControl:ucLanguageLiteral ID="ltpplSearchArea" runat="server" SetLanguageCode="LabelArea" />
                                :
                            </label>
                            <div class="form-input">
                                <asp:DropDownList ID="ddlArea" runat="server" CssClass="form-dropdown" />
                            </div>
                        </li>
                        <li id="reg-business-type" class="form-line">
                            <label class="form-label-left2">
                                <JXTControl:ucLanguageLiteral ID="ltpplSearchAvailability" runat="server" SetLanguageCode="LabelAvailabilityDate" />
                                :
                            </label>
                            <div class="form-input">
                                <asp:DropDownList ID="ddlAvailability" runat="server" CssClass="form-dropdown" />
                            </div>
                        </li>
                    </ul>
                </div>
            </div>
            <div class="adv-searchright">
                <div class="form-all">
                    <ul class="form-section">
                        <li class="form-line">
                            <label class="form-label-left2">
                                &nbsp;</label></li>
                        <li id="reg-business-type" class="form-line">
                            <label class="form-label-left2">
                                <JXTControl:ucLanguageLiteral ID="ltpplSearchSubClass" runat="server" SetLanguageCode="LabelSubClassification" />
                                :
                            </label>
                            <div class="form-input">
                                <asp:DropDownList ID="ddlSubCategory" runat="server" CssClass="form-dropdown" />
                            </div>
                        </li>
                        <li id="Li1" class="form-line">
                            <label class="form-label-left2">
                                <JXTControl:ucLanguageLiteral ID="ltpplSearchLocation" runat="server" SetLanguageCode="LabelLocation" />
                                :
                            </label>
                            <div class="form-input">
                                <asp:DropDownList ID="ddlLocation" runat="server" AutoPostBack="true" CssClass="form-dropdown"
                                    OnSelectedIndexChanged="ddlLocation_SelectedIndexChanged" />
                            </div>
                        </li>
                        <li id="reg-business-type" class="form-line">
                            <label class="form-label-left2">
                                <JXTControl:ucLanguageLiteral ID="ltpplSearchSalary" runat="server" SetLanguageCode="LabelSalary" />
                                :
                            </label>
                            <div class="form-input">
                                <div id="SalaryType">
                                    <asp:DropDownList ID="ddlSalary" runat="server" CssClass="form-dropdown" AutoPostBack="true"
                                        OnSelectedIndexChanged="ddlSalary_SelectedIndexChanged" />
                                </div>
                                <div id="divSalaryFrom">
                                    <asp:DropDownList ID="ddlSalaryLowerBand" runat="server" CssClass="form-dropdown"
                                        AutoPostBack="true" OnSelectedIndexChanged="ddlSalaryLowerBand_SelectedIndexChanged" />
                                </div>
                                &nbsp;<div id="divTo">
                                    <JXTControl:ucLanguageLiteral ID="ltTo" runat="server" SetLanguageCode="LabelTo" />
                                </div>
                                &nbsp;
                                <div id="divSalaryTo">
                                    <asp:DropDownList ID="ddlSalaryUpperBand" runat="server" CssClass="form-dropdown" />
                                </div>
                            </div>
                        </li>
                    </ul>
                </div>
            </div>
            <div class="adv-searchbottom">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="mini-new-buttons"
                    OnClick="btnSubmit_Click" />
            </div>
        </div>
        <asp:Panel ID="pnlSearchResult" runat="server" Visible="false">
            <div id="jobsearch-top">
                <div class="num-results">
                    <JXTControl:ucLanguageLiteral ID="ltpplSearchResults" runat="server" SetLanguageCode="LabelSearchResult" />
                    <span class="searchresult-number">
                        <asp:Literal ID="litResultNumber" runat="server" Text="0" /></span>
                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral1" runat="server" SetLanguageCode="LabelJobSeekers" />
                </div>
            </div>
            <asp:Repeater ID="rptPeopleSearchResults" runat="server" OnItemCommand="rptPeopleSearchResults_ItemCommand"
                OnItemDataBound="rptPeopleSearchResults_ItemDataBound">
                <HeaderTemplate>
                    <div class="people-individual-container-header">
                        <div class="people-location-header">
                            <JXTControl:ucLanguageLiteral ID="ltLocationUpdated" runat="server" SetLanguageCode="LabelLocationUpdated" />
                        </div>
                        <div class="people-details-header">
                            <JXTControl:ucLanguageLiteral ID="ltDetails" runat="server" SetLanguageCode="LabelDetails" />
                        </div>
                        <div class="people-photo-header">
                            <JXTControl:ucLanguageLiteral ID="ltPhoto" runat="server" SetLanguageCode="LabelPhoto" />
                        </div>
                    </div>
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="people-individual-container">
                        <div class="people-location">
                            <p>
                                <asp:Literal ID="litLocation" runat="server" /><br />
                                <asp:Literal ID="litArea" runat="server" /><br />
                                <asp:Literal ID="litLastUpdate" runat="server" /></p>
                        </div>
                        <div class="people-details">
                            <p>
                                <asp:HyperLink ID="hlName" runat="server">
                                    <strong>
                                        <asp:Literal ID="litName" runat="server" /></strong></asp:HyperLink>
                            </p>
                            <p>
                                <strong>
                                    <JXTControl:ucLanguageLiteral ID="ltClassification" runat="server" SetLanguageCode="LabelPreferredClassification" />
                                    :</strong>
                                <asp:Literal ID="litClassification" runat="server" /><br />
                                <strong>
                                    <JXTControl:ucLanguageLiteral ID="ltSubClassification" runat="server" SetLanguageCode="LabelPreferredSubClassification" />
                                    :</strong>
                                <asp:Literal ID="litSubClassification" runat="server" /><br />
                                <strong>
                                    <JXTControl:ucLanguageLiteral ID="ltDesiredPay" runat="server" SetLanguageCode="LabelDesiredPay" />
                                    :</strong>
                                <asp:Literal ID="litDesiredPay" runat="server" /><br />
                                <br />
                                <asp:HyperLink ID="hlViewProfile" runat="server">
                                    <JXTControl:ucLanguageLiteral ID="ltViewProfile" runat="server" SetLanguageCode="LabelViewProfile" />
                                </asp:HyperLink>
                            </p>
                        </div>
                        <div class="people-photo">
                            <asp:Image ID="imgPhoto" runat="server" ImageUrl="/Images/member-avatar.png" />
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <asp:Repeater ID="rptPaging" runat="server" OnItemCommand="rptPaging_ItemCommand"
                OnItemDataBound="rptPaging_ItemDataBound">
                <HeaderTemplate>
                    <div id="tnt_pagination">
                        <asp:LinkButton ID="lnkButtonPrevious" runat="server" CommandName="paging" />
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:LinkButton ID="lnkButtonPaging" runat="server" CommandName="paging" /></ItemTemplate>
                <FooterTemplate>
                    <asp:LinkButton ID="lnkButtonNext" runat="server" CommandName="paging" />
                    </div>
                </FooterTemplate>
            </asp:Repeater>
        </asp:Panel>
<%--    </div>
</div>
--%>