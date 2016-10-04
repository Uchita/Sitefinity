<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/admin.Master" AutoEventWireup="true"
    CodeBehind="CustomQuestionsEdit.aspx.cs" Inherits="JXTPortal.Website.Admin.CustomQuestionsEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    Custom Questions - Add/Edit
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <div class="form-all">
        <span class="form-message">
            <asp:Literal ID="ltlMessage" runat="server" />
        </span>
        <ul class="form-section">
            <li class="form-line" id="admin-questiontitle">
                <asp:Label ID="lbTitle" runat="server" CssClass="form-label-left" AssociatedControlID="tbTitle">
                    Title:<span class="form-required">*</span></asp:Label>
                <div class="form-input">
                    <asp:TextBox ID="tbTitle" runat="server" Width="400px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfTitle" runat="server" Display="Dynamic" ErrorMessage="Required"
                        ControlToValidate="tbTitle" SetFocusOnError="true" />
                </div>
            </li>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <li class="form-line" id="admin-questiontype">
                        <asp:Label ID="lbType" runat="server" CssClass="form-label-left" AssociatedControlID="ddlType">
                    Type:<span class="form-required">*</span></asp:Label>
                        <div class="form-input">
                            <asp:DropDownList ID="ddlType" runat="server" Width="400px" AutoPostBack="true" OnSelectedIndexChanged="ddlType_SelectedIndexChanged">
                                <asp:ListItem Value="textbox">Text Box</asp:ListItem>
                                <asp:ListItem Value="textarea">Text Area</asp:ListItem>
                                <asp:ListItem Value="dropdown">Dropdown</asp:ListItem>
                                <asp:ListItem Value="multiselect">MultiSelect</asp:ListItem>
                                <asp:ListItem Value="radio">Radio Buttons</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </li>
                    <asp:PlaceHolder ID="phOptions" runat="server" Visible="false">
                        <li class="form-line" id="admin-questionoptions">
                            <asp:Label ID="lbOptions" runat="server" CssClass="form-label-left" AssociatedControlID="tbOptions">
                    Options:<span class="form-required">*</span></asp:Label>
                            <div class="form-input">
                                <asp:TextBox ID="tbOptions" runat="server" Width="400px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfOptions" runat="server" Display="Dynamic" ErrorMessage="Required"
                                    ControlToValidate="tbOptions" SetFocusOnError="true" />
                            </div>
                        </li>
                    </asp:PlaceHolder>
                </ContentTemplate>
            </asp:UpdatePanel>
            <li class="form-line" id="admin-questionsequence">
                <asp:Label ID="lbSequence" runat="server" CssClass="form-label-left" AssociatedControlID="tbSequence">
                    Sequence:<span class="form-required">*</span></asp:Label>
                <div class="form-input">
                    <asp:TextBox ID="tbSequence" runat="server" Width="400px"  onkeypress="return event.charCode >= 48 && event.charCode <= 57"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfSequence" runat="server" Display="Dynamic" ErrorMessage="Required"
                        ControlToValidate="tbSequence" SetFocusOnError="true" />
                    <asp:RangeValidator ID="rvSequence" runat="server" ErrorMessage="Please enter the valid sequence"
                        ControlToValidate="tbSequence" MinimumValue="0" MaximumValue="99999" Display="Dynamic"></asp:RangeValidator>
                </div>
            </li>
            <li class="form-line" id="admin-questionmandatory">
                <asp:Label ID="lbMandatory" runat="server" CssClass="form-label-left" AssociatedControlID="cbMandatory">
                    Mandatory:</asp:Label>
                <div class="form-input">
                    <asp:CheckBox ID="cbMandatory" runat="server" />
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
                                Title:
                            </label>
                            <div class="form-input">
                                <asp:TextBox ID="txtMultiTitle" runat="server" Width="400" />
                            </div>
                        </li>
                        <asp:PlaceHolder ID="phMultilingualOptions" runat="server" Visible="false">
                            <li class="form-line" id="Li25">
                                <label class="form-label-left">
                                    Options:
                                </label>
                                <div class="form-input">
                                    <asp:TextBox ID="txtMultiOptions" runat="server" Width="400" />
                                </div>
                            </li>
                        </asp:PlaceHolder>
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
