<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true" Inherits="WorkTypeEdit" Title="Global - Default Work Type Edit" Codebehind="WorkTypeEdit.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Work Type - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		
		<div class="form-all">
		    <span class="form-message">
                <asp:Literal ID="ltlMessage" runat="server" />
            </span>
            
            <ul class="form-section">
            
                <li class="form-line" id="admin-workTypeName">
                    <label class="form-label-left">Work Type Name:<span class="form-required">*</span></label>
                    <div class="form-input">
                        <asp:TextBox ID="txtWorkTypeName" runat="server" Width="250px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="ReqVal_WorkTypeName" runat="server" ControlToValidate="txtWorkTypeName" ErrorMessage="Required" />
                    </div>
                </li>
                
                <li class="form-line" id="admin-workTypeValid">
                    <label class="form-label-left">Valid:</label>
                    <div class="form-input">
                        <asp:CheckBox ID="chkWorkTypeValid" runat="server" Width="250px"></asp:CheckBox>
                    </div>
                </li>
                
                <li class="form-line">
                    <div class="form-input-wide">
                        <div class="form-buttons-wrapper">
                            <asp:Button ID="btnSubmit" runat="server" Text="Save" OnClick="btnSubmit_Click" CssClass="jxtadminbutton" />                            
                            <asp:Button ID="btnReturn" runat="server" Text="Return" OnClick="btnReturn_Click" CssClass="jxtadminbutton" CausesValidation="false" />
                        </div>
                    </div>
                </li>
            
            </ul>            
        </div>		

</asp:Content>

