<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucMemberApplicationTracker.ascx.cs" Inherits="JXTPortal.Website.usercontrols.member.ucMemberApplicationTracker" %>

    <asp:Repeater ID="rptMemberApplicationTracker" runat="server" OnItemDataBound="rptMemberApplicationTracker_ItemDataBound">
        <HeaderTemplate>
            <table id="box-table">
                <tbody>
                    <tr>                        
                        <th scope="col">
                            <JXTControl:ucLanguageLiteral ID="ltHeaderMemberAppTrackerJobsName" runat="server" SetLanguageCode="LabelJobTitle" />
                        </th>
                        <th scope="col">
                            <JXTControl:ucLanguageLiteral ID="ltHeaderMemberAppTrackerAdvertiser" runat="server" SetLanguageCode="LabelAdvertiser" />                            
                        </th>
                        <th scope="col">
                            <JXTControl:ucLanguageLiteral ID="ltHeaderMemberAppTrackerDate" runat="server" SetLanguageCode="LabelApplicationDate" />                            
                        </th>
                    </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <asp:HyperLink runat="server" ID="hypJobUrl" />
                </td>
                <td scope="col">
                     <asp:Literal ID="ltAdvertiserName" runat="server" />                    
                </td>
                <td scope="col">
                    <asp:Literal ID="ltDateApplied" runat="server" />                    
                </td>                                        
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </tbody></table>
        </FooterTemplate>
    </asp:Repeater>
    
    <div class="Member-nojob-tracker">
        <label>
            <asp:Literal ID="ltMemberNoJobTracker" runat="server" Visible="false" />
        </label>
    </div>

    <asp:Repeater ID="rptPage" runat="server" OnItemCommand="rptPage_ItemCommand" OnItemDataBound="rptPage_ItemDataBound">
        <HeaderTemplate>
            <div id="tnt_pagination">
        </HeaderTemplate>
        <ItemTemplate>
            <asp:LinkButton ID="lbPageNo" runat="server" CommandName="Page" />
        </ItemTemplate>
        <FooterTemplate>
            </div>
        </FooterTemplate>
    </asp:Repeater>
        
    <div class="linkMemberBroadcastViewMore">
        <asp:HyperLink ID="hypApplicationTrackerViewLink" runat="server" NavigateUrl="/member/applicationTracker.aspx" Visible="false"></asp:HyperLink>
    </div>
      