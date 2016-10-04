<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true"
    CodeBehind="enquiry.aspx.cs" Inherits="JXTPortal.Website.pages.enquiry" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
        <div class="content-holder">
            <JXTControl:ucSystemDynamicPage ID="ucSystemDynamicPage" runat="server" SetSystemPageCode="SystemPage_EnquiryPages" />
            <div class="form-all">
                <ul class="form-section">
                    <li class="form-line" id="enquiry-name">
                        <label class="form-label-left">
                            <JXTControl:ucLanguageLiteral ID="ltEnquiryName" runat="server" SetLanguageCode="LabelName" />
                            : <span class="form-required">*</span>
                        </label>
                        <div class="form-input">
                            <asp:TextBox ID="txtName" runat="server" CssClass="form-textbox2"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvEnquiryName" runat="server" ControlToValidate="txtName" Display="Dynamic"
                                ErrorMessage="Name is required"></asp:RequiredFieldValidator>
                        </div>
                    </li>
                    <li class="form-line" id="enquiry-email">
                        <label class="form-label-left">
                            <JXTControl:ucLanguageLiteral ID="ltEnquiryEmail" runat="server" SetLanguageCode="LabelContactEmail" />
                            : <span class="form-required">*</span>
                        </label>
                        <div class="form-input">
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-textbox2"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvEmailAddress" runat="server" ControlToValidate="txtEmail" Display="Dynamic"
                                ErrorMessage="Email address is required"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revEnquiryEmailAddress" runat="server" ControlToValidate="txtEmail" Display="Dynamic"
                                ErrorMessage="A valid email address is required" ValidationExpression="^(([A-Za-z0-9]+_+)|([A-Za-z0-9]+\-+)|([A-Za-z0-9]+\.+)|([A-Za-z0-9]+\++))*[A-Za-z0-9]+@((\w+\-+)|(\w+\.))*\w{1,63}\.[a-zA-Z]{2,6}$">  
                            </asp:RegularExpressionValidator>
                        </div>
                    </li>
                    <li class="form-line" id="enquiry-phone">
                        <label class="form-label-left">
                            <JXTControl:ucLanguageLiteral ID="ltEnquiryPhone" runat="server" SetLanguageCode="LabelContactNumber" />
                            :
                        </label>
                        <div class="form-input">
                            <asp:TextBox ID="txtPhone" runat="server" CssClass="form-textbox2"></asp:TextBox>
                            <asp:CompareValidator ID="cvPhone" runat="server" ControlToValidate="txtPhone" Type="Integer" Display="Dynamic"
                                Operator="DataTypeCheck" ErrorMessage="Phone cannot be letters" />
                        </div>
                    </li>
                    <li class="form-line" id="enquiry-content">
                        <label class="form-label-left">
                            <JXTControl:ucLanguageLiteral ID="ltEnquiryContent" runat="server" SetLanguageCode="LabelComments" />
                            : <span class="form-required">*</span>
                        </label>
                        <div class="form-input">
                            <asp:TextBox ID="txtContent" runat="server" CssClass="form-textbox2" TextMode="MultiLine"
                                Height="200"></asp:TextBox>&nbsp;
                            <asp:RequiredFieldValidator ID="rfvEnquiryContent" runat="server" ControlToValidate="txtContent" Display="Dynamic"
                                ErrorMessage="Content must not be empty"></asp:RequiredFieldValidator>
                        </div>
                    </li>
                    <li class="form-line" id="enquiry-button">
                        <div class="form-input-wide">
                            <div class="form-buttons-wrapper">
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="mini-new-buttons" OnClick="btnSubmit_Click" />
                            </div>
                        </div>
                    </li>
                </ul>
            </div>
        </div>
    </div>
</asp:Content>
