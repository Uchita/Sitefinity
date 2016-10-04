<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master"
    AutoEventWireup="True" Inherits="SiteWorkType" Title="Site Locations - Site Work Types" CodeBehind="SiteWorkType.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    Site Work Type List
    <a href='http://support.jxt.com.au/solution/articles/116447-site-work-type-list' class='jxt-help-page' title='click here for help on this page'  target='_blank'>help on this page</a>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="form-all">
        <span class="form-message">
            <asp:Label ID="lblErrorMsg" runat="server" class="form-required" />
        </span>        
        <br />
        <asp:Repeater ID="rptWorktype" runat="server" OnItemDataBound="rptWorktype_ItemDataBound">
            <HeaderTemplate>
                <table cellpadding="3" border="0" class="grid">
                    <tbody>
                        <tr class="grid-header">
                            <th scope="col"><input type="checkbox" ID="chkSiteWorkTypeSelectAll" onclick="SelectAll(this);" /> Select All</th>
                            <th scope="col">Default Work Type Name</th>
                            <th scope="col">Site Work Type Name</th>
                            <th scope="col">Friendly Url</th>
                            <th scope="col">Sequence</th>
                        </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><asp:CheckBox ID="chkSiteWorkTypeValid" runat="server"></asp:CheckBox></td>
                    <td><asp:Literal ID="lbWorkType" runat="server"  Text='<%# Bind("WorkTypeName") %>' /></td>
                    <td><asp:TextBox ID="txtSiteWorkTypeName" runat="server" /></td>
                    <td><asp:TextBox ID="tbFriendlyUrl" runat="server" /></td>
                    <td><asp:TextBox ID="txtSiteWorkTypeSequence" runat="server" Width="50px" />
                        <asp:CompareValidator id="cvSequence" Type="Integer" runat="server" ErrorMessage="Enter Valid Number" Operator="DataTypeCheck" />
                        <asp:HiddenField ID="hiddenWorkTypeID" runat="server" Value='<%# Bind("WorkTypeID") %>' />
                        <asp:HiddenField ID="hiddenSiteWorkTypeID" runat="server" />
                        <asp:HiddenField ID="hiddenSiteID" runat="server" />
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                    </tbody>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        
        <ul class="form-section">
            <li class="form-line">
                <div class="form-input-wide">
                    <div class="form-buttons-wrapper-left">
                        <asp:Button ID="btnSubmit" runat="server" Text="Save" OnClick="btnSubmit_Click" CssClass="jxtadminbutton" />
                    </div>
                </div>
            </li>
        </ul>    
        
    </div>    
</asp:Content>
