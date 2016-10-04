<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master"
    AutoEventWireup="true" Inherits="JobTemplatesEdit" Title="Sites - Site Job Template Edit"
    ValidateRequest="false" CodeBehind="JobTemplatesEdit.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    Job Templates - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<asp:ScriptManager ID="scriptManager" runat="server" />
    <script type="text/javascript">
        $(document).ready(function() {
            if (document.getElementById("ctl00_ContentPlaceHolder1_lstJobFields")) {

                $('#ctl00_ContentPlaceHolder1_lstJobFields option').click(function() {
                    $("#ctl00_ContentPlaceHolder1_txtJobTemplateHTML").insertAtCaret($(this).text());
                    return false
                });
            }
            else {
                $('#ContentPlaceHolder1_lstJobFields option').click(function() {
                    $("#ContentPlaceHolder1_txtJobTemplateHTML").insertAtCaret($(this).text());
                    return false
                });
            }
        });
        $.fn.insertAtCaret = function(myValue) {
            return this.each(function() {
                //IE support
                if (document.selection) {
                    this.focus();
                    sel = document.selection.createRange();
                    sel.text = myValue;
                    this.focus();
                }
                //MOZILLA / NETSCAPE support
                else if (this.selectionStart || this.selectionStart == '0') {
                    var startPos = this.selectionStart;
                    var endPos = this.selectionEnd;
                    var scrollTop = this.scrollTop;
                    this.value = this.value.substring(0, startPos) + myValue + this.value.substring(endPos, this.value.length);
                    this.focus();
                    this.selectionStart = startPos + myValue.length;
                    this.selectionEnd = startPos + myValue.length;
                    this.scrollTop = scrollTop;
                } else {
                    this.value += myValue;
                    this.focus();
                }
            });
        };
    </script>

    <div class="form-all">
        <span class="form-message">
            <asp:Literal ID="ltlMessage" runat="server" />
        </span>
        <ul class="form-section">
            <li class="form-line" id="admin-jobTemplateThumbValidation">
                <asp:CustomValidator ID="cvalThumbnail" runat="server" ValidationGroup="GroupThumbnailValidation"
                    OnServerValidate="cvalThumbnail_ServerValidate" Display="Dynamic" SetFocusOnError="true"></asp:CustomValidator>
            </li>
            <li>
                <asp:CustomValidator ID="cvalThumbnailName" runat="server" ValidationGroup="GroupThumbnailValidation"
                    OnServerValidate="cvalThumbnailName_ServerValidate" Display="Dynamic" SetFocusOnError="true"></asp:CustomValidator>
            </li>
        </ul>
        <ul class="form-section">
            <li class="form-line">
                <label class="form-label-left">
                    Advertiser:<span class="form-required">*</span>
                </label>
                <div class="form-input">
                    <asp:DropDownList ID="ddlAdvertiser" runat="server" />
                    <asp:RequiredFieldValidator ID="rvAdvertiser" runat="server" ErrorMessage="Required"
                        Display="Dynamic" ControlToValidate="ddlAdvertiser" InitialValue="0" SetFocusOnError="true" />
                </div>
            </li>
            <li class="form-line" id="admin-jobTemplateDescription">
                <label class="form-label-left">
                    Job Template Description:<span class="form-required">*</span></label>
                <div class="form-input">
                    <asp:TextBox ID="txtJobTemplateDescription" runat="server" Width="250px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="ReqVal_txtJobTemplateDescription" runat="server"
                        ControlToValidate="txtJobTemplateDescription" ErrorMessage="Required" SetFocusOnError="true" />
                </div>
            </li>
            <li class="form-line" id="admin-jobTemplateJobFields">
                <label class="form-label-left">
                    Job Fields:<span class="form-required">*</span></label>
                <div class="form-input">
                    <asp:ListBox ID="lstJobFields" runat="server" />
                </div>
            </li>
            <li class="form-line" id="admin-jobTemplateThumbUpload">
                <label class="form-label-left">
                    Thumbnail:<span class="form-required">*</span></label>
                <div id="thumb" style="float: left; width: 300px;">
                    <asp:Image ID="imgAdvJobTemplateLogo" runat="server" Visible="false"></asp:Image>
                    <asp:FileUpload ID="docThumbnail" runat="server" CssClass="form-textbox2" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="docThumbnail"
                        ErrorMessage="Required Image" SetFocusOnError="true" />
                </div>
            </li>
            <li class="form-line" id="admin-jobTemplateHTML">
                <label class="form-label-left">
                    Job Template HTML:<span class="form-required">*</span></label>
                <div class="form-input">
                    <FredCK:CKEditorControl ID="txtJobTemplateHTML" runat="server" Width="650px" Height="400px"
                        CustomConfig="custom_config.js" Toolbar="FullToolbar" EnableViewState="false">
                    </FredCK:CKEditorControl>
                    <asp:RequiredFieldValidator ID="rvJobTemplateHTML" runat="server" ErrorMessage="Required"
                        Display="Dynamic" ControlToValidate="txtJobTemplateHTML" SetFocusOnError="true" />
                </div>
            </li>
            <li class="form-line" id="admin-jobGlobalTemplate">
                <label class="form-label-left">
                    Global Template:</label>
                <div class="form-input">
                    <asp:CheckBox ID="chkEducationGlobalTemplate" runat="server" Width="250px"></asp:CheckBox>
                </div>
            </li>
            <li class="form-line">
                <div class="form-input-wide">
                    <div class="form-buttons-wrapper">
                        <asp:Button ID="btnApply" runat="server" Text="Apply" CssClass="jxtadminbutton" OnClick="btnUpdate_Click"
                            CausesValidation="True" />
                        <asp:Button ID="btnUpdate" runat="server" Text="Save" CssClass="jxtadminbutton" OnClick="btnUpdate_Click"
                            CausesValidation="True" />
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="jxtadminbutton"
                            CausesValidation="False" onclick="btnDelete_Click" Visible="false" />
                        <asp:Button ID="btnReturn" runat="server" Text="Return" OnClick="btnReturn_Click"
                            CssClass="jxtadminbutton" CausesValidation="false" />
                    </div>
                </div>
            </li>
        </ul>
    </div>
</asp:Content>
