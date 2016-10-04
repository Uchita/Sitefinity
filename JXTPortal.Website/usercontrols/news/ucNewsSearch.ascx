<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucNewsSearch.ascx.cs"
    Inherits="JXTPortal.Website.usercontrols.news.ucNewsSearch" %>
<div class="adv-search-holder">
    <div class="adv-searchleft">
        <div class="form-all">
            <ul class="form-section">
                <li id="search-keywords" class="form-line">
                    <label class="form-label-left">
                        <JXTControl:ucLanguageLiteral ID="ltpplSearchkeyword" runat="server" SetLanguageCode="LabelEnterKeywords" />
                        :<span class="form-required">*</span>
                    </label>
                    <div class="form-input">
                        <asp:TextBox ID="tbKeyword" runat="server" CssClass="form-textbox" /></div>
                </li>
            </ul>
        </div>
        <div class="news-searchbtn">
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="mini-new-buttons" OnClick="btnSubmit_Click" />
        </div>
    </div>
</div>
<asp:Panel ID="pnlSearchResult" runat="server" Visible="false">
    <div id="jobsearch-top">
        <div class="num-results">
            <JXTControl:ucLanguageLiteral ID="ltpplSearchResults" runat="server" SetLanguageCode="LabelSearchResult" />
            <span class="searchresult-number">
                <asp:Literal ID="litResultNumber" runat="server" Text="0" /></span>
            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral1" runat="server" SetLanguageCode="LabelNews" />
        </div>
    </div>
    <asp:Repeater ID="rptNewsResults" runat="server" OnItemCommand="rptNewsResults_ItemCommand"
        OnItemDataBound="rptNewsResults_ItemDataBound">
        <HeaderTemplate>
        </HeaderTemplate>
        <ItemTemplate>
            <asp:Literal ID="ltlNews" runat="server" />
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
