<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true" Inherits="MemberStatusEdit" Title="MemberStatus Edit" Codebehind="MemberStatusEdit.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Member Status - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		
        
        <div class="form-all">
        <span class="form-message">
            <asp:Literal ID="ltlMessage" runat="server" /></span>
        <ul class="form-section">
            <li class="form-line" id="reg-username-field">
                <label class="form-label-left">
                    Status Name:<span class="form-required">*</span>
                </label>
                <div class="form-input">
                    <asp:TextBox ID="txtName" runat="server" /><asp:RequiredFieldValidator
                        ID="ReqVal_MembershipsName" runat="server" Display="Dynamic" ControlToValidate="txtName"
                        ErrorMessage="Required"></asp:RequiredFieldValidator>
                </div>
            </li>
            <li class="form-line" id="reg-num-employees">
                <label class="form-label-left">
                    Sequence:<span class="form-required">*</span></label>
                <div class="form-input">
                    <asp:TextBox ID="txtSequence" runat="server" CssClass="form-textbox validate[Numeric]"
                        Columns="5" />
                    <asp:RequiredFieldValidator ID="ReqVal_txtSequence" runat="server" Display="Dynamic"
                        ControlToValidate="txtSequence" ErrorMessage="Required" />
                    <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Please enter the valid sequence"
                        ControlToValidate="txtSequence" MinimumValue="0" MaximumValue="99999" Display="Dynamic"></asp:RangeValidator>
                </div>
            </li><li class="form-line" id="reg-external-job-apps">
                <label class="form-label-left">
                    Valid:</label>
                <div id="cid_21" class="form-input">
                    <div class="form-input" style="width: 500px;">
                        <span class="form-checkbox-item" style="clear: left;">
                            <asp:CheckBox ID="chkValid" runat="server" CssClass="form-checkbox" Text=" " />
                        </span>
                        <span class="clearfix"></span>
                    </div>
                </div>
            </li>
            <li class="form-line">
                <label class="form-label-left">
                    Last Modified:
                </label>
                <div class="form-input">
                    <asp:Literal ID="ltlLastModified" runat="server" Text="" />
                </div>
            </li>
            <li class="form-line">
                <label class="form-label-left">
                    Last Modified By:
                </label>
                <div class="form-input">
                    <asp:Literal ID="ltlLastModifiedBy" runat="server" Text="" />
                </div>
            </li>
            <li class="form-line" id="reg-bottom-button">
                <div class="form-input-wide">
                    <div class="form-buttons-wrapper">
                        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="jxtadminbutton" />
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click"
                            CausesValidation="false" CssClass="jxtadminbutton" />
                    </div>
                </div>
            </li>
        </ul>

    </div>

</asp:Content>

