<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/admin.Master" AutoEventWireup="true"
    CodeBehind="ScreeningQuestionsTemplateEdit.aspx.cs" Inherits="JXTPortal.Website.Admin.ScreeningQuestionsTemplateEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    Screening Questions Template - Add/Edit
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" ScriptMode="Release" />
    <div class="form-all">
        <span class="form-message">
            <asp:Literal ID="ltlMessage" runat="server" />
        </span>
        <ul class="form-section">
            <li class="form-line" id="admin-questiontitle">
                <asp:Label ID="lbTemplateName" runat="server" CssClass="form-label-left" AssociatedControlID="tbTemplateName">
                    Template Name:<span class="form-required">*</span></asp:Label>
                <div class="form-input">
                    <asp:TextBox ID="tbTemplateName" runat="server" Width="400px" MaxLength="256"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfTemplateName" runat="server" Display="Dynamic"
                        ValidationGroup="Template" ErrorMessage="Required" ControlToValidate="tbTemplateName"
                        SetFocusOnError="true" />
                </div>
            </li>
            <li class="form-line" id="Li1">
                <asp:Label ID="lbVisible" runat="server" CssClass="form-label-left" AssociatedControlID="cbVisible">
                    Visible:</asp:Label>
                <div class="form-input">
                    <asp:CheckBox ID="cbVisible" runat="server" Checked="true" />
                </div>
            </li>
            <li class="form-line">
                <div class="form-input-wide">
                    <div class="form-buttons-wrapper">
                        <asp:Button ID="btnSubmit" runat="server" Text="Save" CssClass="jxtadminbutton" OnClick="btnSubmit_Click"
                            ValidationGroup="Template" />
                        <asp:Button ID="btnReturn" runat="server" Text="Return" CssClass="jxtadminbutton"
                            OnClick="btnReturn_Click" CausesValidation="false" />
                    </div>
                </div>
            </li>
        </ul>
        <asp:PlaceHolder ID="phScreeningQuestions" runat="server" Visible="false">
            
            <asp:Repeater ID="rptScreeningQuestions" runat="server" OnItemDataBound="rptScreeningQuestions_ItemDataBound"
                OnItemCommand="rptScreeningQuestions_ItemCommand">
                <HeaderTemplate>
                    <h2>
                <asp:Literal ID="ltScreeningQuestions" runat="server" Text="Screening Questions" /></h2>
                    <table>
                        <thead>
                            <tr class="grid-header">
                                <th scope="col" width="50">
                                    &nbsp;
                                </th>
                                <th scope="col" width="100">
                                    Sequence
                                </th>
                                <th scope="col" width="100">
                                    Question Type
                                </th>
                                <th scope="col">
                                    Question Title
                                </th>
                                <th scope="col" width="50">
                                    Mandatory
                                </th>
                                <th scope="col" width="50">
                                    Visible
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:LinkButton ID="lbSelect" runat="server" CommandName="Select" Text="Select" CausesValidation="false" />
                        </td>
                        <td>
                            <asp:Literal ID="ltSequence" runat="server" />
                        </td>
                        <td>
                            <asp:Literal ID="ltQuestionType" runat="server" />
                        </td>
                        <td>
                            <asp:Literal ID="ltQuestionTitle" runat="server" />
                        </td>
                        <td>
                            <asp:Literal ID="ltMandatory" runat="server" />
                        </td>
                        <td>
                            <asp:Literal ID="ltVisible" runat="server" />
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody> </table>
                </FooterTemplate>
            </asp:Repeater>
            <h2>
                <asp:Literal ID="ltAddScreeningQuestions" runat="server" Text="Add Screening Questions" /></h2>
            <ul class="form-section">
                <li class="form-line" id="Li2">
                    <asp:Label ID="lbTitle" runat="server" CssClass="form-label-left" AssociatedControlID="tbTitle">
                    Title:<span class="form-required">*</span></asp:Label>
                    <div class="form-input">
                        <asp:HiddenField ID="hfScreeningQuestionId" runat="server" />
                        <asp:TextBox ID="tbTitle" runat="server" Width="400px" MaxLength="256"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfTitle" runat="server" Display="Dynamic" ErrorMessage="Required"
                            ControlToValidate="tbTitle" SetFocusOnError="true" ValidationGroup="Question" />
                    </div>
                </li>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <li class="form-line" id="admin-questiontype">
                            <asp:Label ID="lbType" runat="server" CssClass="form-label-left" AssociatedControlID="ddlType">
                    Type:<span class="form-required">*</span></asp:Label>
                            <div class="form-input">
                                <asp:DropDownList ID="ddlType" runat="server" Width="400px" AutoPostBack="true" OnSelectedIndexChanged="ddlType_SelectedIndexChanged">
                                    <asp:ListItem Value="1">Text Box</asp:ListItem>
                                    <asp:ListItem Value="2">Text Area</asp:ListItem>
                                    <asp:ListItem Value="3">Dropdown</asp:ListItem>
                                    <asp:ListItem Value="4">MultiSelect</asp:ListItem>
                                    <asp:ListItem Value="5">Radio Buttons</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </li>
                        <asp:PlaceHolder ID="phOptions" runat="server" Visible="false">
                            <li class="form-line" id="admin-questionoptions">
                                <asp:Label ID="lbOptions" runat="server" CssClass="form-label-left" AssociatedControlID="tbOptions">
                    Options (Comma seperated):<span class="form-required">*</span></asp:Label>
                                <div class="form-input">
                                    <asp:TextBox ID="tbOptions" runat="server" Width="400px" MaxLength="500"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfOptions" runat="server" Display="Dynamic" ErrorMessage="Required"
                                        ControlToValidate="tbOptions" SetFocusOnError="true" ValidationGroup="Question" />
                                </div>
                            </li>
                        </asp:PlaceHolder>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <li class="form-line" id="admin-questionsequence">
                    <asp:Label ID="lbSequence" runat="server" CssClass="form-label-left" AssociatedControlID="tbSequence">
                    Sequence:<span class="form-required">*</span></asp:Label>
                    <div class="form-input">
                        <asp:TextBox ID="tbSequence" runat="server" Width="400px" onkeypress="return event.charCode >= 48 && event.charCode <= 57"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfSequence" runat="server" Display="Dynamic" ErrorMessage="Required"
                            ControlToValidate="tbSequence" SetFocusOnError="true" ValidationGroup="Question" />
                        <asp:RangeValidator ID="rvSequence" runat="server" ErrorMessage="Please enter the valid sequence"
                            ValidationGroup="Question" ControlToValidate="tbSequence" MinimumValue="0" MaximumValue="99999"
                            Display="Dynamic"></asp:RangeValidator>
                    </div>
                </li>
                <li class="form-line" id="admin-questionmandatory">
                    <asp:Label ID="lbMandatory" runat="server" CssClass="form-label-left" AssociatedControlID="cbMandatory">
                    Mandatory:</asp:Label>
                    <div class="form-input">
                        <asp:CheckBox ID="cbMandatory" runat="server" />
                    </div>
                </li>
                <li class="form-line" id="Li4">
                    <asp:Label ID="Label1" runat="server" CssClass="form-label-left" AssociatedControlID="cbQuestionVisible">
                    Visible:</asp:Label>
                    <div class="form-input">
                        <asp:CheckBox ID="cbQuestionVisible" runat="server" Checked="true" />
                    </div>
                </li>
                <li class="form-line" id="Li3">
                    <div class="form-input-wide">
                        <div class="form-buttons-wrapper">
                            <asp:Button ID="btnAdd" runat="server" Text="Add New" OnClick="btnAdd_Click" ValidationGroup="Question">
                            </asp:Button>
                            <asp:Button ID="btnSave" runat="server" Text="Save" Visible="false" OnClick="btnSave_Click"
                                ValidationGroup="Question"></asp:Button>
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" Visible="false" OnClick="btnCancel_Click">
                            </asp:Button>
                        </div>
                    </div>
                </li>
            </ul>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phOwners" runat="server" Visible="false">
            <h2>
                <asp:Literal ID="ltOwners" runat="server" Text="Owners" /></h2>
            <ul class="form-section">
                <li class="form-line" id="mlr-language-field">
                    <label class="form-label-left">
                        Advertiser ID:<span class="form-required">*</span>
                    </label>
                    <div class="form-input">
                        <asp:TextBox ID="tbAdvertiserId" runat="server" Width="400px" onkeypress="return event.charCode >= 48 && event.charCode <= 57" />
                        <asp:RequiredFieldValidator ID="rvAdvertiserId" runat="server" ControlToValidate="tbAdvertiserId"
                            ErrorMessage="Required" ValidationGroup="Owner" />
                        <asp:CustomValidator ID="cvAdvertiserId" runat="server" ValidationGroup="Owner" OnServerValidate="cvAdvertiserId_ServerValidate" />
                    </div>
                </li>
                <li class="form-line" id="Li5">
                    <div class="form-input" style="width: 400px">
                        <asp:Button ID="btnAddAdvertiser" runat="server" Text="Add Advertiser" ValidationGroup="Owner"
                            OnClick="btnAddAdvertiser_Click" />
                    </div>
                </li>
            </ul>
            <asp:Repeater ID="rptAdvertiser" runat="server" OnItemDataBound="rptAdvertiser_ItemDataBound"
                OnItemCommand="rptAdvertiser_ItemCommand">
                <HeaderTemplate>
                    <table border="0" class="grid">
                        <tbody>
                            <tr class="grid-header">
                                <th scope="col">
                                </th>
                                <th scope="col">
                                    AdvertiserID
                                </th>
                                <th scope="col">
                                    Company Name
                                </th>
                            </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:LinkButton CssClass="red" ID="lbDelete" runat="server" CommandName="Delete"
                                CausesValidation="false">Delete</asp:LinkButton>
                        </td>
                        <td>
                            <asp:Literal ID="ltAdvertiserID" runat="server" />
                        </td>
                        <td>
                            <asp:Literal ID="ltCompanyName" runat="server" />
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody> </table>
                </FooterTemplate>
            </asp:Repeater>
        </asp:PlaceHolder>
    </div>
</asp:Content>
