<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true" Inherits="MemberFileTypesEdit" Title="Members - Member File Type Edit" Codebehind="MemberFileTypesEdit.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Member File Types - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		
		<div class="form-all">
		    <span class="form-message">
                <asp:Literal ID="ltlMessage" runat="server" />
            </span>
            <ul class="form-section">
            
                <li class="form-line" id="admin-memberFileTypeName">
                    <label class="form-label-left">Member File Type Name:</label>
                    <div class="form-input">
                        <asp:TextBox runat="server" ID="txtMemberFileTypeName"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="ReqVal_MemberFileTypeName"
                            runat="server" Display="Dynamic" ControlToValidate="txtMemberFileTypeName" ErrorMessage="Required"></asp:RequiredFieldValidator>
                    </div>
                </li>
                
                <li class="form-line" id="admin-MemberFileExtensions">
                    <label class="form-label-left">Member File Type Extensions:</label>
                    <div class="form-input">
                        <asp:TextBox runat="server" ID="txtMemberFileTypeExtensions"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                            runat="server" Display="Dynamic" ControlToValidate="txtMemberFileTypeExtensions" ErrorMessage="Required"></asp:RequiredFieldValidator>
                    </div>
                </li>
                
                <li class="form-line" id="admin-memberFileType-button">
                    <div class="form-input-wide">
                    <div style="margin-left:156px" class="form-buttons-wrapper">
                        <asp:Button ID="btnSubmit" runat="server" Text="Save" onclick="btnSubmit_Click" CssClass="jxtadminbutton" />
                        <asp:Button ID="btnReturn" runat="server" Text="Return" OnClick="btnReturn_Click" CssClass="jxtadminbutton" CausesValidation="false" />
                    </div>
                    </div>
                </li>
            
            </ul>            
        </div>		

</asp:Content>

