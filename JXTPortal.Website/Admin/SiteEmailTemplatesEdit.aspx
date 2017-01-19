<%@ Page Language="C#" MasterPageFile="~/MasterPages/admin.Master" AutoEventWireup="true"
    CodeBehind="SiteEmailTemplatesEdit.aspx.cs" Inherits="JXTPortal.Website.Admin.SiteEmailTemplatesEdit"
    Title="Sites - Site Email Template Edit" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <link rel="stylesheet" href="css/3col.css" />

    <meta http-equiv="X-UA-Compatible" content="IE=9" />
    <script type="text/javascript" src="//admin/js/jquery.js"></script>
    <script src="http://cdn.ckeditor.com/4.4.7/standard/ckeditor.js"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    Site Email Templates Edit
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <script type="text/javascript">
        function SubjectFieldsClick(obj) {

            if (document.getElementById("ctl00_ContentPlaceHolder2_dataNewEmailSubject")) {

                document.getElementById("ctl00_ContentPlaceHolder2_dataNewEmailSubject").value += "{" + obj.value + "}";
            }
            else {
                document.getElementById("ContentPlaceHolder2_dataNewEmailSubject").value += "{" + obj.value + "}";
            }
        }


        function BodyTextFieldsClick(obj) {
            if (document.getElementById("ctl00_ContentPlaceHolder2_dataNewEmailBodyText")) {

                document.getElementById("ctl00_ContentPlaceHolder2_dataNewEmailBodyText").value += "{" + obj.value + "}";
            }
            else {
                document.getElementById("ContentPlaceHolder2_dataNewEmailBodyText").value += "{" + obj.value + "}";
            }
        }
    </script>
    <div class="form-all add-edit-page">
        <div id="left-column-100">
            <script>
                $(document).ready(function () {

                    $(".form-elements-group").find(".help-block-success, .help-block-error, .help-block").each(function () {
                        $(this).closest('.form-elements-group').css("margin-bottom", "0");
                    });

                    $('#DefaultEmailSettings').click(function () {
                        $('.defaultEmailSetting').slideToggle(500);
                        var icon = $(this).find("i");
                        $(icon).toggleClass('fa-caret-up fa-caret-down');
                        if ($(icon).hasClass('fa-caret-up')) {
                            $('.expandText').text('Click to close');
                        } else {
                            $('.expandText').text('Click to expand');
                        }
                    });
                });

            </script>
            <h2 class="section-header">
                Default email template <a class="pull-right" id="DefaultEmailSettings"><span class="expandText">
                    Click to expand</span> <i class="fa fa-caret-down"></i></a>
            </h2>
            <div class="form-elements-linebreak">
            </div>
            <div class="defaultEmailSetting" style="display: none;">
                <div class="form-elements-group">
                    <div class="label-holder">
                        <label for="">
                            Email Code:</label></div>
                    <div class="form-element-holder">
                        <asp:TextBox ID="lbDefaultEmailCode" runat="server" Enabled="false" ReadOnly="true"
                            CssClass="form-element med" /></div>
                </div>
                <div class="form-elements-group">
                    <div class="label-holder">
                        <label for="">
                            Email Description:</label></div>
                    <div class="form-element-holder">
                        <asp:TextBox ID="lbDefaultEmailDescription" runat="server" Enabled="false" ReadOnly="true"
                            CssClass="form-element med" /></div>
                </div>
                <div class="form-elements-linebreak">
                </div>
                <div class="form-elements-group">
                    <div class="label-holder">
                        <label for="">
                            Email Subject:</label></div>
                    <div class="form-element-holder">
                        <asp:TextBox ID="lbDefaultEmailSubject" runat="server" Enabled="false" ReadOnly="true"
                            CssClass="form-element med" />
                    </div>
                </div>
                <div class="form-elements-group">
                    <div class="label-holder">
                        <label for="">
                            Email Fields:</label></div>
                    <div class="form-element-holder">
                        <asp:Label ID="lbDefaultEmailFields" runat="server" /></div>
                </div>
                <div class="form-elements-group">
                    <div class="label-holder">
                        <label for="">
                            From Name:</label></div>
                    <div class="form-element-holder">
                        <asp:TextBox ID="lbDefaultEmailAddressName" runat="server" Enabled="false" ReadOnly="true"
                            CssClass="form-element med" /></div>
                </div>
                <div class="form-elements-group">
                    <div class="label-holder">
                        <label for="">
                            From Address:</label></div>
                    <div class="form-element-holder">
                        <asp:TextBox ID="lbDefaultEmailAddressFrom" runat="server" Enabled="false" ReadOnly="true"
                            CssClass="form-element med" /></div>
                </div>
                <asp:PlaceHolder ID="phDefaultTo" runat="server" Visible="false">
                    <div class="form-elements-group">
                        <div class="label-holder">
                            <label for="">
                                Recipient:</label></div>
                        <div class="form-element-holder">
                            <asp:TextBox ID="lbDefaultEmailAddressToName" runat="server" CssClass="form-element med"
                                placeholder="Enter recipient" Enabled="false" ReadOnly="true" /></div>
                    </div>
                    <div class="form-elements-group">
                        <div class="label-holder">
                            <label for="">
                                Recipient Address:</label></div>
                        <div class="form-element-holder">
                            <asp:TextBox ID="lbDefaultEmailAddressTo" runat="server" CssClass="form-element med"
                                Enabled="false" ReadOnly="true" /></div>
                    </div>
                </asp:PlaceHolder>
                <div class="form-elements-group">
                    <div class="label-holder">
                        <label for="">
                            Recipient CC:</label></div>
                    <div class="form-element-holder">
                        <asp:TextBox ID="lbDefaultEmailAddressCC" runat="server" CssClass="form-element med"
                            Enabled="false" ReadOnly="true" /></div>
                </div>
                <div class="form-elements-group">
                    <div class="label-holder">
                        <label for="">
                            Recipient BCC:</label></div>
                    <div class="form-element-holder">
                        <asp:TextBox ID="lbDefaultEmailAddressBCC" runat="server" CssClass="form-element med"
                            Enabled="false" ReadOnly="true" /></div>
                </div>
                <div class="form-elements-linebreak">
                </div>
                <div class="form-elements-group">
                    <div class="label-holder">
                        <label for="">
                            Email Body Text:</label></div>
                    <div class="form-element-holder">
                        <div class="emailContentPreview">
                            <asp:Literal ID="ltDefaultEmailBodyText" runat="server" />
                        </div>
                    </div>
                    <p class="help-block">
                        The above is the text preview version of default email</p>
                </div>
                <div class="form-elements-group">
                    <div class="label-holder">
                        <label for="">
                            Email Body HTML:</label></div>
                    <div class="form-element-holder">
                        <div class="emailContentPreview">
                            <asp:Label ID="lbDefaultEmailBodyHTML" runat="server" />
                        </div>
                    </div>
                    <p class="help-block">
                        The above is the html preview version of default email</p>
                </div>
            </div>
            <!-- end of default email details -->
            <h2 class="section-header">
                Custom template settings</h2>
            <div class="form-elements-linebreak">
            </div>
            <div class="form-elements-group">
                <div class="label-holder">
                    <label for="">
                        Email Description: <span class="required">*</span></label></div>
                <div class="form-element-holder">
                    <asp:TextBox ID="dataNewEmailDescription" runat="server" CssClass="form-element med"
                        placeholder="Enter description" />

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                            ErrorMessage="Required" ControlToValidate="dataNewEmailDescription" />
                </div>
            </div>
            <div class="form-elements-linebreak">
            </div>
            <div class="form-elements-group">
                <div class="label-holder">
                    <label for="">
                        From Name: <span class="required">*</span></label></div>
                <div class="form-element-holder">
                    <asp:TextBox ID="dataNewEmailAddressName" runat="server" CssClass="form-element med"
                        placeholder="Enter from name" /><asp:RequiredFieldValidator ID="rfvFromName" runat="server"
                            ErrorMessage="Required" ControlToValidate="dataNewEmailAddressName" /></div>
            </div>
            <div class="form-elements-group">
                <div class="label-holder">
                    <label for="">
                        From Address: <span class="required">*</span></label></div>
                <div class="form-element-holder">
                    <asp:TextBox ID="dataNewEmailAddressFrom" runat="server" CssClass="form-element med"
                        placeholder="Enter from address" /><asp:RequiredFieldValidator ID="rfvFromAddress"
                            runat="server" ErrorMessage="Required" ControlToValidate="dataNewEmailAddressFrom" /></div>
            </div>
            <asp:PlaceHolder ID="phEmailTo" runat="server" Visible="false">
                <div class="form-elements-group">
                    <div class="label-holder">
                        <label for="">
                            Recipient: <span class="required">*</span></label></div>
                    <div class="form-element-holder">
                        <asp:TextBox ID="tbEmailAddressToName" runat="server" CssClass="form-element med"
                            placeholder="Enter recipient name" /><asp:RequiredFieldValidator ID="rfvRecipient"
                                runat="server" ErrorMessage="Required" ControlToValidate="tbEmailAddressToName" /></div>
                </div>
                <div class="form-elements-group">
                    <div class="label-holder">
                        <label for="">
                            Recipient Address: <span class="required">*</span></label></div>
                    <div class="form-element-holder">
                        <asp:TextBox ID="tbEmailTo" runat="server" CssClass="form-element med" placeholder="Enter recipient email address" /><asp:RequiredFieldValidator
                            ID="rfvRecipientAddress" runat="server" ErrorMessage="Required" ControlToValidate="tbEmailTo" /></div>
                </div>
            </asp:PlaceHolder>
            <div class="form-elements-group">
                <div class="label-holder">
                    <label for="">
                        Recipient CC:</label></div>
                <div class="form-element-holder">
                    <asp:TextBox ID="dataNewEmailAddressCC" runat="server" CssClass="form-element med"
                        placeholder="Enter CC address" /></div>
            </div>
            <div class="form-elements-group">
                <div class="label-holder">
                    <label for="">
                        Recipient BCC:</label></div>
                <div class="form-element-holder">
                    <asp:TextBox ID="dataNewEmailAddressBCC" runat="server" CssClass="form-element med"
                        placeholder="Enter BCC address" /></div>
            </div>
            <div class="form-elements-linebreak">
            </div>
            <asp:UpdatePanel ID="upLanguage" runat="server">
                <ContentTemplate>
                    <div class="versionTemplateHolder">
                        <asp:PlaceHolder ID="phLanguage" runat="server" Visible="false">
                            <div class="form-elements-group">
                                <div class="label-holder">
                                    <label for="">
                                        Select Language <span class="required">*</span></label></div>
                                <div class="form-element-holder">
                                    <asp:DropDownList ID="ddlSelectLanguage" runat="server" CssClass="form-element" AutoPostBack="true"
                                        OnSelectedIndexChanged="ddlSelectLanguage_SelectedIndexChanged" />
                                </div>
                            </div>
                        </asp:PlaceHolder>
                        <div id="divEmailSubject" class="form-elements-group">
                            <div class="label-holder">
                                <label for="">
                                    Email Subject: <span class="required">*</span></label></div>
                            <div class="form-element-holder">
                                <asp:TextBox ID="dataNewEmailSubject" runat="server" CssClass="form-element med"
                                    placeholder="Enter email subject" />
                                <asp:RequiredFieldValidator ID="rfvEmailSubject" runat="server" ErrorMessage="Required"
                                    ControlToValidate="dataNewEmailSubject" /></div>
                        </div>
                        <div class="form-elements-group">
                            <div class="label-holder">
                                <label for="">
                                    Email Fields:</label></div>
                            <div class="form-element-holder">
                                <asp:Label ID="ltNewEmailField" runat="server" /></div>
                        </div>
                        <div class="form-elements-group">
                            <div class="label-holder">
                                <label>
                                    Email body (html) <span class="required">*</span></label>
                            </div>
                            <div class="form-element-holder">
                                <FredCK:CKEditorControl ID="dataNewEmailBodyHTML" runat="server" CssClass="form-element"
                                    CustomConfig="custom_config.js" Toolbar="FullToolbar" EnableViewState="false" Height="400px">
                                </FredCK:CKEditorControl>
                                <asp:RequiredFieldValidator ID="rfvNewEmailBodyHTML" runat="server" ErrorMessage="Required"
                                    ControlToValidate="dataNewEmailBodyHTML" />
                            </div>
                        </div>
                        <div class="form-elements-group">
                            <div class="label-holder">
                                <label>
                                    Email body (text) <span class="required">*</span></label>
                            </div>
                            <div class="form-element-holder">
                                <asp:TextBox ID="dataNewEmailBodyText" runat="server" TextMode="MultiLine" Rows="10"
                                    CssClass="form-element" />
                                <asp:RequiredFieldValidator ID="rfvNewEmailBodyText" runat="server" ErrorMessage="Required"
                                    ControlToValidate="dataNewEmailBodyText" /></div>
                            <p class="help-block">
                                Some email clients don't support html. Please supply text version of your email
                                template.</p>
                        </div>
                        <div class="form-elements-group">
                            <div class="label-holder">
                                <label for="">
                                    Last Modified:</label></div>
                            <div class="form-element-holder">
                                <asp:Label runat="server" ID="lbCurrentLastModified"></asp:Label></div>
                        </div>
                        <div class="form-elements-group">
                            <div class="label-holder">
                                <label for="">
                                    Modified By:</label></div>
                            <div class="form-element-holder">
                                <asp:Label runat="server" ID="lbCurrentModifiedBy"></asp:Label></div>
                        </div>
                        <asp:PlaceHolder ID="phUpdateVersion" runat="server" Visible="false">
                            <div class="form-elements-group">
                                <div class="label-holder">
                                    &nbsp;</div>
                                <div class="form-element-holder">
                                    <asp:LinkButton ID="lbUpdateVersion" runat="server" CssClass="btn" Text="Update Version"
                                        OnClick="lbUpdateVersion_Click" />
                                </div>
                            </div>
                        </asp:PlaceHolder>
                    </div>
                    <div class="form-elements-linebreak">
                    </div>
                    <asp:PlaceHolder ID="phMultiLingual" runat="server" Visible="false">
                        <asp:PlaceHolder ID="phCurrentVersion" runat="server" Visible="false">
                            <div class="form-elements-group">
                                <div class="label-holder">
                                    Current Language versions</div>
                                <div class="form-element-holder">
                                    <asp:Repeater ID="rptCurrentVersion" runat="server" OnItemDataBound="rptCurrentVersion_ItemDataBound"
                                        OnItemCommand="rptCurrentVersion_ItemCommand">
                                        <HeaderTemplate>
                                            <table class="table table-hover" style="width: 100%;" id="languageTableVersions">
                                                <thead>
                                                    <tr>
                                                        <th>
                                                            Language
                                                        </th>
                                                        <th>
                                                            Author
                                                        </th>
                                                        <th>
                                                            Last Modified
                                                        </th>
                                                        <th>
                                                            Actions
                                                        </th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <span class="SavedTemplatelanguage">
                                                        <asp:Literal ID="ltLanguage" runat="server" /></span>
                                                </td>
                                                <td>
                                                    <asp:Literal ID="ltAuthor" runat="server" />
                                                </td>
                                                <td>
                                                    <asp:Literal ID="ltLastModified" runat="server" />
                                                </td>
                                                <td>
                                                    <asp:LinkButton ID="lbEdit" CssClass="editVersion" runat="server" Text="Edit" CommandName="Edit"
                                                        CausesValidation="false" />
                                                    |
                                                    <asp:LinkButton ID="lbDelete" CssClass="DeleteLanguageTempBtn" runat="server" Text="Delete"
                                                        CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete this record?');"
                                                        CausesValidation="false" />
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </tbody> </table></FooterTemplate>
                                    </asp:Repeater>
                                    <br />
                                </div>
                            </div>
                            <div class="form-elements-linebreak">
                            </div>
                        </asp:PlaceHolder>
                    </asp:PlaceHolder>
                    <div class="form-elements-group">
                        <div class="label-holder">
                            &nbsp;</div>
                        <div class="form-element-holder">
                            <asp:LinkButton ID="btnEditSave" runat="server" Text="Save settings" OnClick="btnEditSave_Click"
                                CssClass="btn" />
                            <asp:LinkButton ID="btnUseDefault" runat="server" Text="Revert to
                        default" OnClick="btnUseDefault_Click" CssClass="btn default" />
                            <asp:LinkButton ID="btnReturn" runat="server" Text="Return" OnClick="btnReturn_Click"
                                CssClass="btn default" CausesValidation="false" />
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <hr class="noscreen" />
    </div>
    <script type='text/javascript' language='javascript' src='/admin/scripts/coda-slider/jquery.coda-slider-2.0.js'></script>
    <script type='text/javascript' language='javascript' src='/admin/scripts/coda-slider/jquery.easing.1.3.js'></script>
    <script type='text/javascript'>
        $().ready(function () {
            $('#coda-slider-1').codaSlider({
                dynamicArrows: false,
                autoHeight: true,
                firstPanelToLoad: 1
            });
        })

    </script>
    <script type="text/javascript" language="javascript" src="/scripts/jquery.hoveraccordion.min.js"></script>
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {

            $('#navlist ul').hide();

            var lis = $('#navlist li ul li a');
            var i;
            for (i = 0; i < lis.length; i++) {
                if (lis[i].href.toLowerCase().indexOf(location.pathname.toLowerCase()) > 0) {
                    $('#navlist li ul li a[href$=\'' + lis[i].getAttribute("href") + '\']').parent().parent().slideDown('normal');
                    break;
                }
            }

            $('#navlist li a').click(function () {
                var checkElement = $(this).next();
                if ((checkElement.is('ul')) && (checkElement.is(':visible'))) {
                    return false;
                }
                if ((checkElement.is('ul')) && (!checkElement.is(':visible'))) {
                    $('#navlist ul:visible').slideUp('normal');
                    checkElement.slideDown('normal');
                    return false;
                }
            });
        });
    </script>
    <script type="text/javascript" language="javascript" src="/admin/scripts/JXTAdminScript.js"></script>
</asp:Content>
