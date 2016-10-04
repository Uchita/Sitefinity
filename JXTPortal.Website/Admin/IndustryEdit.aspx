<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/admin.Master" AutoEventWireup="true"
    CodeBehind="IndustryEdit.aspx.cs" Inherits="JXTPortal.Website.Admin.IndustryEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    Industry Edit
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" ScriptMode="Release" />
    <div class="form-all">
        <span class="form-message">
            <asp:Literal ID="ltlMessage" runat="server" />
        </span>
        <asp:HiddenField ID="hfIndustryId" runat="server" />
        <ul class="form-section">
            <li class="form-line" id="admin-questiontitle">
                <asp:Label ID="lbIndustryName" runat="server" CssClass="form-label-left" AssociatedControlID="tbIndustryName">
                    Industry Name:<span class="form-required">*</span></asp:Label>
                <div class="form-input">
                    <asp:TextBox ID="tbIndustryName" runat="server" Width="400px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfIndustryName" runat="server" Display="Dynamic" ErrorMessage="Required"
                        ControlToValidate="tbIndustryName" SetFocusOnError="true" />
                </div>
            </li>
            <li class="form-line" id="Li1">
                <asp:Label ID="lbSequence" runat="server" CssClass="form-label-left" AssociatedControlID="tbSequence">
                    Sequence:<span class="form-required">*</span></asp:Label>
                <div class="form-input">
                    <asp:TextBox ID="tbSequence" runat="server" Width="400px" onkeypress="return event.charCode >= 48 && event.charCode <= 57"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvSequence" runat="server" Display="Dynamic" ErrorMessage="Required"
                        ControlToValidate="tbSequence" SetFocusOnError="true" />
                </div>
            </li>
            <li class="form-line" id="Li2">
                <asp:Label ID="lbValid" runat="server" CssClass="form-label-left" AssociatedControlID="cbValid">
                    Valid:</asp:Label>
                <div class="form-input">
                    <asp:CheckBox ID="cbValid" runat="server" Checked="true"></asp:CheckBox>
                </div>
            </li>
            <li class="form-line">
                <div class="form-input-wide">
                    <div class="form-buttons-wrapper">
                        <asp:Button ID="btnSubmit" runat="server" Text="Save" OnClick="btnSubmit_Click" CssClass="jxtadminbutton" />
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click"
                            CssClass="jxtadminbutton" OnClientClick="return confirm('Are you sure?')" Visible="false" />
                        <asp:Button ID="btnReturn" runat="server" Text="Return" OnClick="btnReturn_Click"
                            CssClass="jxtadminbutton" CausesValidation="false" />
                    </div>
                </div>
            </li>
        </ul>

        <asp:PlaceHolder ID="phMultilingual" runat="server" Visible="false">
            <asp:UpdatePanel ID="upMultiLingual" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <h2>
                        Multilingual</h2>
                    <span class="form-message">
                        <asp:Literal ID="ltMultilingualMessage" runat="server" /></span>
                    <asp:Repeater ID="rptMultilingual" runat="server" OnItemDataBound="rptMultilingual_ItemDataBound"
                        OnItemCommand="rptMultilingual_ItemCommand">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbLanguage" runat="server" CommandName="Language" />
                        </ItemTemplate>
                    </asp:Repeater>
                    <ul class="form-section">
                        <li class="form-line" id="Li24">
                            <label class="form-label-left">
                                Industry Name:
                            </label>
                            <div class="form-input">
                                <asp:TextBox ID="txtMultiIndustryName" runat="server" Width="400" />
                            </div>
                        </li>
                        <li class="form-line" id="Li38">
                            <div class="form-input-wide">
                                <div class="form-buttons-wrapper">
                                    <asp:Button ID="btnMultilingualSave" runat="server" Text="Save" OnClick="btnMultilingualSave_Click"
                                        CssClass="jxtadminbutton" ValidationGroup="MultiLingual" />
                                </div>
                            </div>
                        </li>
                    </ul>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:PlaceHolder>
    </div>
</asp:Content>
