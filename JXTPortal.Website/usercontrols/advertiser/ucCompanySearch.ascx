<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucCompanySearch.ascx.cs"
    Inherits="JXTPortal.Website.usercontrols.advertiser.ucCompanySearch" %>
    
        <div class="companySearch-search-holder">
            <div class="form-all">
                <ul class="form-section">
                    <li id="search-keywords" >
                        <label class="form-label-left">
                            <JXTControl:ucLanguageLiteral ID="ltpplSearchkeyword" runat="server" SetLanguageCode="LabelEnterKeywords" />
                            :<span class="form-required">*</span>
                        </label>
                        <div class="form-input">
                            <asp:TextBox ID="tbKeyword" runat="server"/>
                            <asp:RequiredFieldValidator ID="ReqVal_SearchKeyword" runat="server" SetFocusOnError="true" Display="Dynamic"
                                        ControlToValidate="tbKeyword" ErrorMessage=" Required"></asp:RequiredFieldValidator>
                        </div>
                    </li>
                </ul>
            </div>
            <div class="adv-searchbottom">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" CssClass="mini-new-buttons" />
            </div>
        </div>

<%--<div class="adv-search-holder">
    <div class="adv-searchleft">
        <div class="form-all">--%>
            <%--<ul class="form-section">
                <li id="search-keywords" >
                    <label class="form-label-left">
                        <JXTControl:ucLanguageLiteral ID="ltpplSearchkeyword" runat="server" SetLanguageCode="LabelEnterKeywords" />
                        :<span class="form-required">*</span>
                    </label>
                    <div class="form-input">
                        <asp:TextBox ID="tbKeyword" runat="server"/>
                        <asp:RequiredFieldValidator ID="ReqVal_SearchKeyword" runat="server" Display="Dynamic"
                                    ControlToValidate="tbKeyword" ErrorMessage=" Required"></asp:RequiredFieldValidator>
                    </div>
                </li>
            </ul>--%>
        <%--</div>--%>
        <%--<div class="adv-searchbottom">
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
        </div>--%>
    <%--</div>
</div>--%>

<asp:Panel ID="pnlSearchResult" runat="server" Visible="false">
    <div id="jobsearch-top">
        <div class="num-results">
            <JXTControl:ucLanguageLiteral ID="ltpplSearchResults" runat="server" SetLanguageCode="LabelSearchResult" />
            <span class="searchresult-number">
                <asp:Literal ID="litResultNumber" runat="server" Text="0" /></span>
            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral1" runat="server" SetLanguageCode="LabelAdvertiser" />
        </div>
    </div>
    <asp:Repeater ID="rptAdvertiserResults" runat="server" OnItemCommand="rptAdvertiserResults_ItemCommand"
        OnItemDataBound="rptAdvertiserResults_ItemDataBound">
        <HeaderTemplate>
        </HeaderTemplate>
        <ItemTemplate>
            <asp:Literal ID="ltlAdvertiser" runat="server" />
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
