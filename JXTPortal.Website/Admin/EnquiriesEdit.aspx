<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true" Inherits="EnquiriesEdit" Title="Sites - Enquiries Edit" Codebehind="EnquiriesEdit.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Enquiries - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	
		<div class="form-all">
            <ul class="form-section">
            
                <li class="form-line" id="admin-enquiriesEdit-name">
                    <label class="form-label-left">Enquirer Name:</label>
                    <div class="form-input">
                        <asp:TextBox runat="server" ID="txtEnquiriesName"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="ReqVal_EnquiriesName"
                            runat="server" Display="Dynamic" ControlToValidate="txtEnquiriesName" ErrorMessage="Required"></asp:RequiredFieldValidator>
                    </div>
                </li>
                
                <li class="form-line" id="admin-enquiriesEdit-email">
                    <label class="form-label-left">Enquirer Email:</label>
                    <div class="form-input">
                        <asp:TextBox runat="server" ID="txtEnquiriesEmail"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="ReqVal_EnquiriesEmail"
                            runat="server" Display="Dynamic" ControlToValidate="txtEnquiriesEmail" ErrorMessage="Required"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revEmailAddress" runat="server" 
                            ControlToValidate="txtEnquiriesEmail" ErrorMessage="A valid email address is required"
                            ValidationExpression="^(([A-Za-z0-9]+_+)|([A-Za-z0-9]+\-+)|([A-Za-z0-9]+\.+)|([A-Za-z0-9]+\++))*[A-Za-z0-9]+@((\w+\-+)|(\w+\.))*\w{1,63}\.[a-zA-Z]{2,6}$">  
                        </asp:RegularExpressionValidator>
                    </div>
                </li>
                
                <li class="form-line" id="admin-enquiriesEdit-phone">
                    <label class="form-label-left">Enquirer Phone:</label>
                    <div class="form-input">
                        <asp:TextBox runat="server" ID="txtEnquiriesPhone"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="ReqVal_EnquiriesPhone"
                            runat="server" Display="Dynamic" ControlToValidate="txtEnquiriesPhone" ErrorMessage="Required"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cvPhone" runat="server" ControlToValidate="txtEnquiriesPhone" Type="Integer" Operator="DataTypeCheck"
                                                ErrorMessage="Enquirer Phone cannot be letters" />
                    </div>
                </li>
                
                <li class="form-line" id="admin-enquiriesEdit-siteID">
                    <label class="form-label-left">Site ID:</label>
                    <div class="form-input">                        
                        <div class="form-input">
                            <asp:Label runat="server" ID="lblEnquirySiteID" />
                        </div>  
                    </div>
                </li>
                
                <li class="form-line" id="admin-enquiriesEdit-date">
                    <label class="form-label-left">Date</label>
                    <div class="form-input">
                        <asp:Label runat="server" ID="lblEnquiryDate" />
                    </div>
                </li>
                
                <li class="form-line" id="admin-enquiriesEdit-ipAddress">
                    <label class="form-label-left">IpAddress</label>
                    <div class="form-input">
                        <asp:Label runat="server" ID="lblEnquiryIpAddress" />
                    </div>
                </li>
                
                <li class="form-line" id="admin-enquiriesEdit-content">
                    <label class="form-label-left">Enquiry Content:</label>
                    <div class="form-input">
                        <asp:TextBox runat="server" ID="txtEnquiriesContent" TextMode="MultiLine" Width="400px" Rows="20"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="ReqVal_EnquiriesContent"
                            runat="server" Display="Dynamic" ControlToValidate="txtEnquiriesContent" ErrorMessage="Required"></asp:RequiredFieldValidator>
                    </div>
                </li>
                
                <li class="form-line" id="admin-enquiriesEdit-button">
                    <div class="form-input-wide">
                    <div style="margin-left:156px" class="form-buttons-wrapper">
                        <asp:Button ID="btnSubmit" runat="server" Text="Save" onclick="btnSubmit_Click" CssClass="jxtadminbutton" Visible="false" />                
                    </div>
                </div>
                      
            </ul>            
        </div>
</asp:Content>

