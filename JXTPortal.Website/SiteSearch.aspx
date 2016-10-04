<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true"
    CodeBehind="SiteSearch.aspx.cs" Inherits="JXTPortal.Website.SiteSearch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
        <div class="content-holder">
        <JXTControl:ucSystemDynamicPage ID="ucSystemDynamicPage" runat="server" SetSystemPageCode="SystemPage_Site_Search_Page" />
            <div class="siteSearch-search-holder">
                <div class="form-all">
                    <ul class="form-section">
                        <li class="form-line" id="SiteSearch-searchkeyword-field">
                            <label class="form-label-left">
                                <JXTControl:ucLanguageLiteral ID="ltSearchKeyword" runat="server" SetLanguageCode="LabelSearchKeyword" />
                                :<span class="form-required">*</span>
                            </label>
                            <div class="form-input">
                                <asp:TextBox ID="txtSearchKeyword" runat="server" onkeypress="return doSiteSearch(event);" />
                                <asp:RequiredFieldValidator ID="ReqVal_SearchKeyword" runat="server" Display="Dynamic"
                                    ControlToValidate="txtSearchKeyword" ErrorMessage=" Required"></asp:RequiredFieldValidator>
                            </div>
                        </li>
                        <li class="form-line" id="SiteSearch-language-field">
                            <label class="form-label-left">
                                <JXTControl:ucLanguageLiteral ID="ltLanguage" runat="server" SetLanguageCode="LabelLanguage" />
                                : <span class="form-required">*</span>
                            </label>
                            <div class="form-input">
                                <asp:DropDownList ID="ddlLanguage" runat="server" />
                            </div>
                        </li>
                        <li class="form-line" id="SiteSearch-search-field">
                            <asp:Button ID="btnSearch" runat="server" CssClass="mini-new-buttons" Text="Search"
                                OnClick="btnSearch_Click" />
                        </li>
                    </ul>
                </div>
            </div>
            <asp:Panel ID="pnlSearchResultNumbers" runat="server" Visible="false">
                <div id="jobsearch-top">
                    <div class="num-results">
                        <JXTControl:ucLanguageLiteral ID="ltSearchResult" runat="server" SetLanguageCode="LabelSearchResult" />
                        <span class="searchresult-number">
                            <asp:Literal ID="litResultNumber" runat="server" Text="0" /></span>
                        <JXTControl:ucLanguageLiteral ID="ltPositions" runat="server" SetLanguageCode="LabelPages" />
                    </div>
                </div>
            </asp:Panel>
            <asp:Panel ID="pnlSearchResult" runat="server" Visible="false">
                <asp:Repeater ID="rptSiteSearch" runat="server" OnItemCommand="rptSiteSearch_ItemCommand"
                    OnItemDataBound="rptSiteSearch_ItemDataBound">
                    <HeaderTemplate>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div class="siteSearch-individual-container">
                            <div class="siteSearch-details">
                                <p>
                                    <strong>
                                        <asp:Literal ID="ltDynamicPageTitle" runat="server" /></strong>
                                </p>
                                <p>
                                    <asp:Literal ID="ltDynamicPageSearchField" runat="server" /><br />
                                    <br />
                                    <asp:HyperLink ID="hlViewPage" runat="server">
                                        <JXTControl:ucLanguageLiteral ID="ltViewPage" runat="server" SetLanguageCode="LabelViewPage" />
                                    </asp:HyperLink>
                                </p>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </asp:Panel>
            <asp:Panel ID="pnlSiteSearchPaging" runat="server" Visible="false">
                <asp:Repeater ID="rptPage" runat="server" OnItemCommand="rptPage_ItemCommand" OnItemDataBound="rptPage_ItemDataBound">
                    <HeaderTemplate>
                        <div id="tnt_pagination">
                            <asp:LinkButton ID="lnkButtonPrevious" runat="server" CommandName="Page" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="lbPageNo" runat="server" CommandName="Page" />
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:LinkButton ID="lnkButtonNext" runat="server" CommandName="Page" />
                        </div>
                    </FooterTemplate>
                </asp:Repeater>
            </asp:Panel>
        </div>
    </div>
</asp:Content>
