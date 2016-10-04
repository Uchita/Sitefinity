<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true" Inherits="SiteWorkTypeEdit" Title="SiteWorkType Edit" Codebehind="SiteWorkTypeEdit.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Site Work Type - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		
		<div class="form-all">
		    <span class="form-message">
                <asp:Literal ID="ltlMessage" runat="server" />
            </span>
            
            <ul class="form-section">
            
                <li class="form-line" id="admin-workTypeID">
                    <label id="Label1" class="form-label-left" runat="server">Work Type ID:</label>
                    <div class="form-input">
                        <asp:DropDownList ID="ddlWorkTypeID" TabIndex="11" runat="server" class="form-dropdown"></asp:DropDownList>                    
                    </div>
                </li>
                
                <li class="form-line" id="admin-siteID">
                    <label class="form-label-left">SiteID:</label>
                    <div class="form-input">                        
                        <div class="form-input">
                            <asp:Label runat="server" ID="lblAdminSiteWorkTypeSiteID" />
                        </div>  
                    </div>
                </li>
                
                <li class="form-line" id="admin-siteWorkTypeName">
                    <label class="form-label-left">Site Work Type Name:</label>
                    <div class="form-input">
                        <asp:TextBox runat="server" ID="txtAdminSiteWorkTypeName"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="ReqVal_AdminSiteWorkTypeName"
                            runat="server" Display="Dynamic" ControlToValidate="txtAdminSiteWorkTypeName" ErrorMessage="Required"></asp:RequiredFieldValidator>
                    </div>
                </li>
                
                <li class="form-line" id="admin-siteWorkTypeValid">
                    <label class="form-label-left">Valid:</label>
                    <div class="form-input">
                        <asp:CheckBox ID="chkSiteWorkTypeValid" runat="server" Width="250px"></asp:CheckBox>
                    </div>
                </li>
                
                <li class="form-line">
                    <div class="form-input-wide">
                        <div class="form-buttons-wrapper">
                            <asp:Button ID="btnSubmit" runat="server" Text="Save" OnClick="btnSubmit_Click" CssClass="form-submit-button" />                            
                            <asp:Button ID="btnReturn" runat="server" Text="Return" OnClick="btnReturn_Click" CssClass="form-submit-button" CausesValidation="false" />
                        </div>
                    </div>
                </li>
            
            </ul>            
        </div>

</asp:Content>

