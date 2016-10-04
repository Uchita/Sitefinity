<%@ Page Language="C#" MasterPageFile="~/MasterPages/admin.Master" AutoEventWireup="true" CodeBehind="CampaignList.aspx.cs" Inherits="JXTPortal.Website.Admin.CampaignList" Title="Campaigns" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
Campaigns
<a href='http://support.jxt.com.au/solution/articles/116436-campaign-creation' class='jxt-help-page' title='click here for help on this page'  target='_blank'>help on this page</a>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Button ID="btnCreateCampaign" runat="server" Text="Create Campaign" 
        CssClass="jxtadminbutton" onclick="btnCreateCampaign_Click" /><br /><br />

    <asp:Repeater ID="rptCampaignList" runat="server" OnItemDataBound="rptCampaignList_ItemDataBound">
        <HeaderTemplate>
            <table cellpadding="3" border="0" class="grid">
                <thead>
                    <tr class="grid-header">
                        <th scope="col">
                            Select
                        </th>
                        <th scope="col">
                            Campaign Name
                        </th>
                        <th scope="col">
                            Url
                        </th>
                        <th scope="col">
                            Tag code
                        </th>
                        <th scope="col">
                            Date Created
                        </th>
                        <th scope="col">
                            Status
                        </th>
                    </tr>
                </thead>
                <tbody>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <asp:CheckBox ID="chkSelect" runat="server" />  
                    <asp:HiddenField ID="hiddenID" runat="server" />                        
                </td>
                <td scope="col">
                    <asp:HyperLink ID="hypCampaignName" runat="server" />
                </td>
                <td scope="col">
                     <asp:HyperLink ID="hypLinkUrl" runat="server" />                        
                </td>
                <td scope="col">
                    <asp:Literal ID="ltlTagCode" runat="server" />                        
                </td>
                <td scope="col">
                    <asp:Literal ID="ltlDateCreated" runat="server" />                        
                </td>
                <td scope="col">
                    <asp:Literal ID="ltlStatus" runat="server" />                        
                </td>                 
            </tr>
        </ItemTemplate>
        <FooterTemplate>
                </tbody>
            </table>
        </FooterTemplate>
    </asp:Repeater>

    <br />
    <asp:Button ID="btnMakeActive" runat="server" Text="Make Active" 
        CssClass="jxtadminbutton" onclick="btnMakeActive_Click" /> 
    <asp:Button ID="btnMakeInActive" runat="server" Text="De-activate" 
        CssClass="jxtadminbutton" onclick="btnMakeInActive_Click" />
    
    <p><i>select checkbox and adjust campaigns</i></p>
</asp:Content>
