<%@ Page Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true"
    CodeBehind="ErrorPage.aspx.cs" Inherits="JXTPortal.Website.ErrorPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
        <div class="content-holder">
            <asp:Repeater ID="rptFile" runat="server" onitemcommand="rptFile_ItemCommand" 
                onitemdatabound="rptFile_ItemDataBound">  
                <HeaderTemplate>
                    <table>
                        <tr>
                            <th>&nbsp;</th>
                            <th>&nbsp;</th>
                            <th>File Name</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:LinkButton ID="lbDelete" runat="server" Text="Delete" CommandName="Delete" />
                        </td>
                        <td>
                            <asp:LinkButton ID="lbDownload" runat="server" Text="Download" CommandName="Download" />
                        </td>
                        <td>
                            <asp:Literal ID="ltFileName" runat="server" />
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
            <br />
            <asp:FileUpload ID="fuFile" runat="server" /> <asp:Button ID="btnUpload" 
                runat="server" Text="Upload" onclick="btnUpload_Click" />

            <JXTControl:ucSystemDynamicPage ID="ucSystemDynamicPage" runat="server" SetSystemPageCode="SystemPage_ErrorPage" />
            <h2>
                <asp:Literal ID="ltlException" runat="server" /></h2>
        </div>
    </div>
</asp:Content>
