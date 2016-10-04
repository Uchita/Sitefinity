
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true" Inherits="SiteSalaryType" Title="Site Locations - Site Salary Types" Codebehind="SiteSalaryType.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Site Salary Type List
<a href='http://support.jxt.com.au/solution/articles/116446-site-salary-type-list' class='jxt-help-page' title='click here for help on this page'  target='_blank'>help on this page</a>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="form-all">
        <span class="form-message">
            <asp:Label ID="lblErrorMsg" runat="server" class="form-required" />
        </span>
        <br />
        <asp:Repeater ID="rptSiteSalaryType" runat="server" OnItemDataBound="rptSiteSalaryType_ItemDataBound">
            <HeaderTemplate>
                <table cellpadding="3" border="0" class="grid">
                    <tbody>
                        <tr class="grid-header">
                            <th scope="col"><input type="checkbox" ID="chkSiteSalaryTypeSelectAll" onclick="SelectAll(this);" /> Select All</th>
                            <th scope="col">Default Salary Name</th>
                            <th scope="col">Site Salary Type Name</th>
                            <th scope="col">Sequence</th>
                        </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><asp:CheckBox ID="chkSiteSalaryTypeValid" runat="server"></asp:CheckBox></td>
                    <td><asp:Literal ID="lbSiteSalaryType" runat="server" Text='<%# Bind("SalaryTypeName") %>' /></td>
                    <td><asp:TextBox ID="txtSiteSalaryTypeName" runat="server" /></td>
                    <td><asp:TextBox ID="txtSiteSalaryTypeSequence" runat="server" Width="50px" />
                        <asp:CompareValidator id="cvSequence" Type="Integer" runat="server" ErrorMessage="Enter Valid Number" Operator="DataTypeCheck" />
                        <asp:HiddenField ID="hiddenSalaryTypeID" runat="server" Value='<%# Bind("SalaryTypeID") %>' />
                        <asp:HiddenField ID="hiddenSiteSalaryTypeID" runat="server" />
                    </td>
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



