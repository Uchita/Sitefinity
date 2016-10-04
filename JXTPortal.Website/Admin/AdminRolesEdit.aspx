<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true" Inherits="AdminRolesEdit" Title="Global - AdminRoles Edit" Codebehind="AdminRolesEdit.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Admin Roles - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	
		<div class="form-all">
            <ul class="form-section">
                
                <li class="form-line" id="admin-adminRoleName">
                    <label class="form-label-left">Role Name:</label>
                    <div class="form-input">
                        <asp:TextBox runat="server" ID="txtAdminRoleName"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="ReqVal_AdminRoleName"
                            runat="server" Display="Dynamic" ControlToValidate="txtAdminRoleName" ErrorMessage="Required"></asp:RequiredFieldValidator>
                    </div>
                </li>
                
                <li class="form-line" id="admin-adminRole-button">
                    <div class="form-input-wide">
                    <div style="margin-left:156px" class="form-buttons-wrapper">
                        <asp:Button ID="btnSubmit" runat="server" Text="Save" onclick="btnSubmit_Click" class="form-submit-button />                
                    </div>
                    </div>
                </li>
            
            </ul>            
        </div>

</asp:Content>

