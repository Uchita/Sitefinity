<%@ Page Language="C#" MasterPageFile="~/MasterPages/admin.master" ValidateRequest="false"
    AutoEventWireup="true" Inherits="DynamicPagesEdit" Title="Dynamic Pages Edit"
    CodeBehind="DynamicPagesEdit.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    Dynamic Pages - Add/Edit
    <a href='http://support.jxt.com.au/solution/articles/116442-dynamic-pages' class='jxt-help-page' title='click here for help on this page'  target='_blank'>help on this page</a>

</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type='text/javascript'>

        var FriendlyUrlValue = '';

        function checkFriendlyUrlChanged() {

            var currentValue = $('#ctl00_ContentPlaceHolder1_txtPageFriendlyName').val().toLowerCase();

            FriendlyUrlValue = currentValue;
            FriendlyUrlValue = $('#ctl00_ContentPlaceHolder1_txtPageName').val().toLowerCase();

            FriendlyUrlValue = FriendlyUrlValue.replace("+", "plus").replace("?", "").replace("&", "and").replace("'", "-").replace(/  +/g, "-").replace(/[\W]/gi, "-").replace(/[-]+/gi, "-");

            if (FriendlyUrlValue.substring(FriendlyUrlValue.length - 1, FriendlyUrlValue.length) == '-')
                FriendlyUrlValue = FriendlyUrlValue.substring(0, FriendlyUrlValue.length - 1);

            $("#ctl00_ContentPlaceHolder1_txtPageFriendlyName").val(FriendlyUrlValue);

        }

    </script>
    <div class="form-all">
        <span class="form-required">
            <asp:Literal ID="ltlMessage" runat="server" /></span><br />
        <br />
        <asp:HiddenField ID="hfCode" runat="server" />
        <ul class="form-section">
            <li class="form-line" id="reg-username-field">
                <label class="form-label-left">
                    Unique Page Code:<span class="form-required">*</span>
                </label>
                <div class="form-input">
                    <asp:TextBox ID="txtPageName" runat="server" Style="width: 300px;" /><asp:RequiredFieldValidator
                        ID="ReqVal_PageName" runat="server" Display="Dynamic" ControlToValidate="txtPageName"
                        ErrorMessage="Required" SetFocusOnError="true"></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="CusVal_PageName" runat="server" ControlToValidate="txtPageName"
                        Display="Dynamic" OnServerValidate="CusVal_PageName_ServerValidate"></asp:CustomValidator>
                </div>
            </li>
            <li class="form-line" id="reg-num-employees">
                <label class="form-label-left">
                    Page Friendly Name:<span class="form-required">*</span></label>
                <div class="form-input">
                    <asp:TextBox ID="txtPageFriendlyName" runat="server" Style="width: 300px;"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="ReqVal_PageFriendlyName" runat="server" Display="Dynamic"
                        ControlToValidate="txtPageFriendlyName" ErrorMessage="Required" SetFocusOnError="true"></asp:RequiredFieldValidator>
                    &nbsp;<a href="javascript:void(0);" onclick="checkFriendlyUrlChanged()">Generate</a>
                </div>
            </li>
            <li class="form-line" id="Li3">
                <label class="form-label-left">
                    Custom URL (optional):</label>
                <div class="form-input">
                    <asp:Literal ID="ltSiteUrl" runat="server" />
                    <asp:TextBox ID="tbCustomUrl" runat="server" MaxLength="512" Style="width: 300px;"></asp:TextBox>
                    <asp:CustomValidator ID="CusVal_tbCustomUrl" runat="server" ControlToValidate="tbCustomUrl"
                        Display="Dynamic" OnServerValidate="CusVal_tbCustomUrl_ServerValidate"></asp:CustomValidator>
                    <br />
                    <i>This url will overwrite both page friendly name and overwrite link. e.g. contact-us,
                        about/meet-the-team</i>
                </div>
            </li>
            <li class="form-line" id="dyn-hyperlink-field">
                <label class="form-label-left">
                    Overwrite Link:</label>
                <div class="form-input">
                    <asp:TextBox runat="server" ID="txtHyperlink" Width="250px"></asp:TextBox>
                    <asp:CustomValidator ID="CusVal_txtHyperLink" runat="server" ControlToValidate="txtHyperLink"
                        Display="Dynamic" OnServerValidate="CusVal_txtHyperLink_ServerValidate" />
                    <br />
                    <i>e.g. Sitemap.aspx, http://www.google.com</i>
                </div>
            </li>
            <li class="form-line" id="dyn-sequence-field">
                <label class="form-label-left">
                    Sequence:<span class="form-required">*</span></label>
                <div class="form-input">
                    <asp:TextBox runat="server" ID="txtSequence" Width="50px" Text="10"></asp:TextBox><asp:RequiredFieldValidator
                        ID="ReqVal_dataSequence" runat="server" Display="Dynamic" ControlToValidate="txtSequence"
                        ErrorMessage="Required" SetFocusOnError="true"></asp:RequiredFieldValidator><asp:RangeValidator
                            ID="RangeVal_dataSequence" runat="server" Display="Dynamic" ControlToValidate="txtSequence"
                            ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648"
                            Type="Integer" SetFocusOnError="true"></asp:RangeValidator>
                </div>
            </li>
            <li class="form-line" id="dyn-openinnewwindow-field">
                <label class="form-label-left">
                    Open In New Window:</label>
                <div class="form-input">
                    <asp:CheckBox ID="cbOpenNewWindow" runat="server" />
                </div>
            </li>
            <li class="form-line" id="dyn-ontopnav-field">
                <label class="form-label-left">
                    On Main Navigation:</label>
                <div class="form-input">
                    <asp:CheckBox ID="cbOnTopNav" runat="server" />
                </div>
            </li>
            <li class="form-line" id="reg-external-job-apps">
                <label class="form-label-left">
                    On Dynamic Navigation:</label>
                <div id="cid_21" class="form-input">
                    <div class="form-single-column">
                        <span class="form-checkbox-item" style="clear: left;">
                            <input type="checkbox" class="form-checkbox" value="Valid" runat="server" id="chkValid" /></span>
                        <span class="clearfix"></span>
                    </div>
                </div>
            </li>
            <li class="form-line" id="dyn-onleftnav-field">
                <label class="form-label-left">
                    On Left Navigation:</label>
                <div class="form-input">
                    <asp:CheckBox ID="cbOnLeftNav" runat="server" />
                </div>
            </li>
            <li class="form-line" id="dyn-onbottomnav-field">
                <label class="form-label-left">
                    On Footer Nav:</label>
                <div class="form-input">
                    <asp:CheckBox ID="cbOnBottomNav" runat="server" />
                </div>
            </li>
            <li class="form-line" id="dyn-onsitemap-field">
                <label class="form-label-left">
                    On Site Map:</label>
                <div class="form-input">
                    <asp:CheckBox ID="cbOnSiteMap" runat="server" />
                </div>
            </li>
            <li class="form-line" id="dyn-secured-field">
                <label class="form-label-left">
                    Secured:</label>
                <div class="form-input">
                    <asp:CheckBox ID="chkSecured" runat="server" />
                </div>
            </li>
            <li class="form-line" id="Li4">
                <label class="form-label-left">
                    Generate Breadcrumb:</label>
                <div class="form-input">
                    <asp:CheckBox ID="chkBreadcrumb" runat="server" />
                </div>
            </li>
            <li class="form-line" id="dyn-related-field">
                <label class="form-label-left">
                    Related Dynamic Pages:</label>
                <div class="form-input">
                    <asp:HiddenField ID="ddlRelatedDynamicPages" runat="server" 
                        ClientIDMode="Static"></asp:HiddenField>
                </div>
            </li>
        </ul>
        <asp:Panel ID="pnlCSSJS" runat="server">
            <ul class="form-section">
                <li class="form-line" id="Li1">
                    <label class="form-label-left">
                        CSS Files:</label>
                    <div class="form-input">
                        <JXTControl:SiteRepeaters runat="server" ID="siteRepeaterCSSFile" />
                    </div>
                </li>
                <li class="form-line" id="Li2">
                    <label class="form-label-left">
                        Javascript Files:</label>
                    <div class="form-input">
                        <JXTControl:SiteRepeaters runat="server" ID="siteRepeaterJavascriptFile" />
                    </div>
                </li>
            </ul>
        </asp:Panel>
        <ul class="form-section">
            
            <li class="form-line" id="reg-view-page">
                <label class="form-label-left">
                    View Page:</label>
                <div id="cid_22" class="form-input">
                    <div class="form-single-column">
                        <asp:Literal ID="litViewPage" runat="server" />
                    </div>
                </div>
            </li>
        </ul>
        <ul class="form-section">
            <li class="form-line" id="Li5">
                <label class="form-label-left">
                    <strong>Widgets</strong></label>
            </li>
            <li class="form-line" id="Li6">
                <label class="form-label-left">
                    Left Column:</label>
                <div id="Div1" class="form-input">
                    <div class="form-single-column">
                        <asp:HiddenField ID="ddlLeftColumn" runat="server" ClientIDMode="Static" />
                    </div>
                </div>
            </li>
            <li class="form-line" id="Li7">
                <label class="form-label-left">
                    Right Column:</label>
                <div id="Div2" class="form-input">
                    <div class="form-single-column">
                        <asp:HiddenField ID="ddlRightColumn" runat="server" ClientIDMode="Static" />
                    </div>
                </div>
            </li>
        </ul>
    </div>
    <asp:HiddenField ID="hfRelatedDynamicPages" runat="server" ClientIDMode="Static" />
    <asp:Repeater ID="rptDynamicPages" runat="server" OnItemDataBound="rptDynamicPages_ItemDataBound"
        OnItemCommand="rptDynamicPages_ItemCommand">
        <HeaderTemplate>
            <div class="coda-slider-wrapper">
                <div class="coda-slider preload" id="coda-slider-1">
        </HeaderTemplate>
        <ItemTemplate>
            <div class="panel">
                <div class="panel-wrapper">
                    <h2 class="title">
                        <asp:Literal ID="litLanguageName" runat="server"></asp:Literal></h2>
                    <JXTControl:DynamicPagesField ID="ucDynamicPage" runat="server" />
                </div>
            </div>
        </ItemTemplate>
        <FooterTemplate>
            </div> </div>
            <br />
            <asp:Button ID="btnApply" runat="server" Text="Apply" CommandName="Apply" CssClass="jxtadminbutton" />
            <asp:Button ID="btnSave" runat="server" Text="Save" CommandName="Save" CssClass="jxtadminbutton" />
            <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="Delete" CausesValidation="false"
                OnClientClick="return confirm('Are you certain you want to delete this page(s)?');"
                CssClass="jxtadminbutton" />
        </FooterTemplate>
    </asp:Repeater>
    <asp:Button runat="server" ID="btnReturn" OnClientClick="javascript:location.href='DynamicPages.aspx'; return false;"
        Text="Return"></asp:Button>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
    
    <link href="/admin/css/select2.css" rel="stylesheet"/>
    <script type="text/javascript" src="/admin/js/select2.js"></script>

    <link rel="stylesheet" href="/admin/styles/coda-slider/coda-slider-2.0.css" type="text/css"
        media="screen" />
    <script type="text/javascript">
        function CharaterCount(textboxid, spanid, max) {
            var len = $("#" + textboxid).val().length;
            $("#" + spanid).text("Character Count: " + len);
            if (len > max) {
                $("#" + spanid).css("color", "red");
            }
            else {
                $("#" + spanid).css("color", "black");
            }
        }
        /*
        $(function () {

            var hostName = (window.location.hostname);
            //alert(hostName.toLowerCase().indexOf("fmplus.com"));

            if (hostName.toLowerCase().indexOf("chandlermacleod.com") >= 0) {
                $('#Li3').hide();
            }
        });*/
    </script>
    
</asp:Content>
