<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/admin.Master" AutoEventWireup="true" CodeBehind="NewsTypeEdit.aspx.cs" Inherits="JXTPortal.Website.Admin.NewsTypeEdit" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    News Type - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="form-all">
        <span class="form-message">
            <asp:Literal ID="ltlMessage" runat="server" />
        </span>
        <ul class="form-section">
            <li class="form-line" id="admin-newstypeName">
                <label class="form-label-left">
                    News Type Name:<span class="form-required">*</span></label>
                <div class="form-input">
                    <asp:TextBox ID="txtnewsTypeName" runat="server" Width="250px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="ReqVal_newsTypeName" runat="server" ControlToValidate="txtnewsTypeName"
                        ErrorMessage="Required" />
                </div>
            </li>
            <li class="form-line" id="Li1">
                <label class="form-label-left">
                    Image URL:</label>
                <div class="form-input">
                    <asp:TextBox ID="tbImageURL" runat="server" Width="250px"></asp:TextBox>
                </div>
            </li>
            <li class="form-line" id="admin-newstypeValid">
                <label class="form-label-left">
                    Global Template:</label>
                <div class="form-input">
                    <asp:CheckBox ID="chknewsTypeGlobalTemplate" runat="server" Width="250px" Enabled="false" Checked="true"></asp:CheckBox>
                </div>
            </li>
            <li class="form-line" id="admin-newstypeSequence">
                <label class="form-label-left">
                    Sequence:<span class="form-required">*</span></label>
                <div class="form-input">
                    <asp:TextBox ID="txtnewsTypeSequence" runat="server" Width="50px"></asp:TextBox>
                    <asp:CompareValidator ID="cvSequence" runat="server" ControlToValidate="txtnewsTypeSequence"
                        Type="Integer" Operator="DataTypeCheck" ErrorMessage="Enter Valid Number" />
                </div>
            </li>
            <li class="form-line" id="admin-LastModifiedBy">
                <label class="form-label-left">
                    Last Modified By:</label>
                <div class="form-input">
                    <div class="form-input">
                        <asp:Label runat="server" ID="lblLastModifiedBy" />
                    </div>
                </div>
            </li>
            <li class="form-line" id="admin-LastModifiedDate">
                <label class="form-label-left">
                    Last Modified Date:</label>
                <div class="form-input">
                    <div class="form-input">
                        <asp:Label runat="server" ID="lblLastModifiedDate" />
                    </div>
                </div>
            </li>
            <li class="form-line">
                <div class="form-input-wide">
                    <div class="form-buttons-wrapper">
                        <asp:Button ID="btnSubmit" runat="server" Text="Save" OnClick="btnSubmit_Click" CssClass="jxtadminbutton" />
                        <asp:Button ID="btnReturn" runat="server" Text="Return" OnClick="btnReturn_Click"
                            CssClass="jxtadminbutton" CausesValidation="false" />
                    </div>
                </div>
            </li>
        </ul>
    </div>
</asp:Content>
