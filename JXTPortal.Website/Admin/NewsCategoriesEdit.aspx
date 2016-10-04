<%@ Page Language="C#" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"
    Inherits="NewsCategoriesEdit" Title="News Categories Edit" CodeBehind="NewsCategoriesEdit.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    News Categories - Add/Edit
    <a href='http://support.jxt.com.au/solution/articles/116440-news-categories-' class='jxt-help-page' title='click here for help on this page'  target='_blank'>help on this page</a>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="form-all">
        <span class="form-message">
            <asp:Literal ID="ltlMessage" runat="server" /></span>
        <ul class="form-section">
            <li class="form-line" id="reg-username-field">
                <label class="form-label-left">
                    News Category Name:<span class="form-required">*</span>
                </label>
                <div class="form-input">
                    <asp:TextBox ID="txtCategoryName" runat="server" /><asp:RequiredFieldValidator ID="ReqVal_CategoryName"
                        runat="server" Display="Dynamic" ControlToValidate="txtCategoryName" ErrorMessage="Required"></asp:RequiredFieldValidator>
                </div>
            </li>
            <li class="form-line" id="Li6">
                <label class="form-label-left">
                    Friendly Name:
                </label>
                <div class="form-input">
                    <asp:TextBox ID="txtPageFriendlyName" runat="server" />&nbsp;<a href="javascript:void(0);"
                        onclick="checkFriendlyUrlChanged()">Generate</a>
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
            </li>
            <li class="form-line" id="reg-external-job-apps">
                <label class="form-label-left">
                    Valid:</label>
                <div id="cid_21" class="form-input">
                    <div class="form-input" style="width: 500px;">
                        <span class="form-checkbox-item" style="clear: left;">
                            <asp:CheckBox ID="chkValid" runat="server" CssClass="form-checkbox" AutoPostBack="true"
                                OnCheckedChanged="chkValid_CheckedChanged" Text=" " />
                        </span>
                        <asp:Panel ID="pnlMoveTo" runat="server" Visible="false">
                            Move To:
                            <asp:DropDownList ID="ddlMoveTo" runat="server">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvMoveTo" runat="server" ControlToValidate="ddlMoveTo" Display="Dynamic"
                                InitialValue="0" ErrorMessage="*" SetFocusOnError="true" />
                        </asp:Panel>
                        <span class="clearfix"></span>
                    </div>
                </div>
            </li>
            <asp:PlaceHolder ID="phMetaTags" runat="server" Visible="false">
                <li class="form-line" id="Li1">
                    <label class="form-label-left">
                        Meta Title:<span class="form-required">*</span>
                    </label>
                    <div class="form-input">
                        <asp:TextBox ID="txtMetaTitle" runat="server" TextMode="MultiLine" Rows="6" Columns="40" /><asp:RequiredFieldValidator
                            ID="ReqVal_MetaTitle" runat="server" Display="Dynamic" ControlToValidate="txtMetaTitle"
                            ErrorMessage="Required"></asp:RequiredFieldValidator>
                    </div>
                </li>
                <li class="form-line" id="Li2">
                    <label class="form-label-left">
                        Meta Keywords:<span class="form-required">*</span>
                    </label>
                    <div class="form-input">
                        <asp:TextBox ID="txtMetaKeywords" runat="server" TextMode="MultiLine" Rows="6" Columns="40" /><asp:RequiredFieldValidator
                            ID="ReqVal_MetaKeywords" runat="server" Display="Dynamic" ControlToValidate="txtMetaKeywords"
                            ErrorMessage="Required"></asp:RequiredFieldValidator>
                    </div>
                </li>
                <li class="form-line" id="Li3">
                    <label class="form-label-left">
                        Meta Description:<span class="form-required">*</span>
                    </label>
                    <div class="form-input">
                        <asp:TextBox ID="txtMetaDescription" runat="server" TextMode="MultiLine" Rows="6"
                            Columns="40" /><asp:RequiredFieldValidator ID="ReqVal_MetaDescription" runat="server"
                                Display="Dynamic" ControlToValidate="txtMetaDescription" ErrorMessage="Required"></asp:RequiredFieldValidator>
                    </div>
                </li>
            </asp:PlaceHolder>
            <li class="form-line" id="Li4">
                <label class="form-label-left">
                    Last Modified:
                </label>
                <div class="form-input">
                    <asp:Literal ID="ltlLastModified" runat="server"></asp:Literal>
                </div>
            </li>
            <li class="form-line" id="Li5">
                <label class="form-label-left">
                    Last Modified By:
                </label>
                <div class="form-input">
                    <asp:Literal ID="ltlLastModifiedBy" runat="server"></asp:Literal>
                </div>
            </li>
            <li class="form-line" id="reg-bottom-button">
                <div class="form-input-wide">
                    <div class="form-buttons-wrapper">
                        <asp:Button ID="btnSave" runat="server" Text="Insert" OnClick="btnSave_Click" CssClass="jxtadminbutton" />
                    </div>
                </div>
            </li>
        </ul>
    </div>
    <script type='text/javascript'>

        var FriendlyUrlValue = $('#<%= txtPageFriendlyName.ClientID %>').val().toLowerCase();

        function checkFriendlyUrlChanged() {
            var currentValue = $('#<%= txtPageFriendlyName.ClientID %>').val().toLowerCase();

            FriendlyUrlValue = currentValue;
            FriendlyUrlValue = $('#<%= txtCategoryName.ClientID %>').val().toLowerCase();

            FriendlyUrlValue = FriendlyUrlValue.replace("+", "plus").replace("?", "").replace("&", "and").replace("'", "-").replace(/  +/g, "-").replace(/[\W]/gi, "-").replace(/[-]+/gi, "-");

            if (FriendlyUrlValue.substring(FriendlyUrlValue.length - 1, FriendlyUrlValue.length) == '-')
                FriendlyUrlValue = FriendlyUrlValue.substring(0, FriendlyUrlValue.length - 1);

            $("#<%= txtPageFriendlyName.ClientID %>").val(FriendlyUrlValue);
        }
    </script>
</asp:Content>
