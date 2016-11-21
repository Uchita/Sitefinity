<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true"
    CodeBehind="register.aspx.cs" Inherits="JXTPortal.Website.members.register" %>

<%@ Register Src="~/usercontrols/member/ucMemberSocialLogin.ascx" TagName="ucMemberSocialLogin"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="/scripts/strength.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<ajaxToolkit:ToolkitScriptManager ID="toolkitScriptManager" runat="server">
    </ajaxToolkit:ToolkitScriptManager>--%>
    <asp:ScriptManager ID="scriptManager" runat="server" />
    <script type="text/javascript" src="/scripts/uni-form.jquery.js"></script>
    <script type="text/javascript" src="//maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>
    <script src="/scripts/bootstrap-datepicker/js/bootstrap-datepicker.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {

            $('div.uniForm').jxt_uniform();

            // specific for this page
            $(".browse a").click(function (e) {
                e.preventDefault();
                $("#formStyle").attr("href", $(this).attr('rel'));
                return false;
            });

            $('#ckAddMailingAddress').change(function () {
                if ($(this).is(":checked")) {
                    $("#divMailingAddress").show();
                    $("#divMailingSuburb").show();
                    $("#divMailingPostcode").show();
                    $("#divMailingState").show();
                    $("#divMailingCountry").show();
                }
                else {
                    $("#divMailingAddress").hide();
                    $("#divMailingSuburb").hide();
                    $("#divMailingPostcode").hide();
                    $("#divMailingState").hide();
                    $("#divMailingCountry").hide();
                }
            });

        });

        

    </script>
    <script type="text/javascript">
        function toggle() {
            var ctrlID = document.getElementById('<%= pnlFullRegistration.ClientID %>');

            if (ctrlID.style.display == 'none') {
                ctrlID.style.display = 'block';
            }
            else {
                ctrlID.style.display = 'none';
            }
        }
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#content input').keydown(function (event) {
                if (event.keyCode == 13) {
                    $('#btnSubmit').click();

                    event.preventDefault();
                    return false;
                }
            });

            $('#txtPassword').strength({
                strengthClass: 'strength',
                strengthMeterClass: 'strength_meter',
                strengthButtonClass: 'button_strength',
                strengthButtonText: '',
                strengthButtonTextToggle: ''
            });
        });
    </script>
    <div id="content">
        <div class="uniForm">
            <fieldset class="inlineLabels">
                <JXTControl:ucSystemDynamicPage ID="ucSystemDynamicPage" runat="server" SetSystemPageCode="SystemPage_MemberRegister" />
                <div id="socialLoginWrapper">
                    <uc1:ucMemberSocialLogin ID="ucMemberSocialLogin1" runat="server" />
                </div>
                <asp:Panel ID="pnlRequiredRegistration" runat="server">
                    <h3>
                        <JXTControl:ucLanguageLiteral ID="ltMemberRegisterHeaderTitle" runat="server" SetLanguageCode="LabelLoginDetails" />
                    </h3>
                    <asp:CustomValidator ID="ctmUsername" runat="server" ControlToValidate="txtUsername"
                        OnServerValidate="ctmUsername_ServerValidate" SetFocusOnError="true" Display="Dynamic"></asp:CustomValidator>
                    <asp:CustomValidator ID="ctmEmailAddress" runat="server" ControlToValidate="txtEmailAddress"
                        OnServerValidate="ctmEmailAddress_ServerValidate" SetFocusOnError="true" Display="Dynamic"></asp:CustomValidator>
                    <div class="ctrlHolder">
                        <label for="ctl00_ContentPlaceHolder1_ddlTitle">
                            <JXTControl:ucLanguageLiteral ID="ltMemberRegisterTitle" runat="server" SetLanguageCode="LabelTitle" />
                        </label>
                        <asp:DropDownList ID="ddlTitle" runat="server" class="selectInput small" TabIndex="1">
                            <asp:ListItem Value="Mr">Mr</asp:ListItem>
                            <asp:ListItem Value="Mrs">Mrs</asp:ListItem>
                            <asp:ListItem Value="Ms">Ms</asp:ListItem>
                            <asp:ListItem Value="Miss">Miss</asp:ListItem>
                            <asp:ListItem Value="Dr">Dr</asp:ListItem>
                            <asp:ListItem Value="Professor">Professor</asp:ListItem>
                            <asp:ListItem Value="Other">Other</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="ctrlHolder">
                        <label for="ctl00_ContentPlaceHolder1_txtFirstName">
                            <JXTControl:ucLanguageLiteral ID="ltMemberRegisterFirstName" runat="server" SetLanguageCode="LabelFirstName" />
                            <span class="form-required">*</span>
                        </label>
                        <asp:TextBox ID="txtFirstName" runat="server" CssClass="textInput medium error" TabIndex="2" />
                        <asp:RequiredFieldValidator ID="rfvFirstname" runat="server" ControlToValidate="txtFirstname"
                            SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="rgvFirstname" runat="server" ControlToValidate="txtFirstname"
                             SetFocusOnError="true" Display="Dynamic"
                            ErrorMessage="ValidateNoHTMLContent"></asp:RegularExpressionValidator>
                    </div>
                    <div class="ctrlHolder">
                        <label for="ctl00_ContentPlaceHolder1_txtSurname">
                            <JXTControl:ucLanguageLiteral ID="ltMemberRegisterSurname" runat="server" SetLanguageCode="LabelSurname" />
                            <span class="form-required">*</span>
                        </label>
                        <asp:TextBox ID="txtSurname" runat="server" CssClass="textInput medium error" TabIndex="3" />
                        <asp:RequiredFieldValidator ID="rfvSurname" runat="server" ControlToValidate="txtSurname"
                            SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="rgvSurname" runat="server" ControlToValidate="txtSurname"
                             SetFocusOnError="true" Display="Dynamic"
                            ErrorMessage="ValidateNoHTMLContent"></asp:RegularExpressionValidator>
                    </div>
                    <div id="divMultilingualName">
                        <div class="ctrlHolder">
                            <label for="ctl00_ContentPlaceHolder1_txtMultiLingualFirstname">
                                <JXTControl:ucLanguageLiteral ID="ltMultiLingualFirstName" runat="server" SetLanguageCode="LabelFirstName" />
                                &nbsp;(<JXTControl:ucLanguageLiteral ID="UcLanguageLiteral14" runat="server" SetLanguageCode="LabelLocalLanguage" />
                                )
                            </label>
                            <asp:TextBox ID="txtMultiLingualFirstname" runat="server" CssClass="textInput medium error"
                                TabIndex="3" />
                            <asp:RegularExpressionValidator ID="rgvMultiLingualFirstname" runat="server" ControlToValidate="txtMultiLingualFirstname"
                                 SetFocusOnError="true" Display="Dynamic"
                                ErrorMessage="ValidateNoHTMLContent"></asp:RegularExpressionValidator>
                        </div>
                        <div class="ctrlHolder">
                            <label for="ctl00_ContentPlaceHolder1_txtMultiLingualSurname">
                                <JXTControl:ucLanguageLiteral ID="ltMultiLingualSurname" runat="server" SetLanguageCode="LabelSurname" />
                                &nbsp;(<JXTControl:ucLanguageLiteral ID="UcLanguageLiteral11" runat="server" SetLanguageCode="LabelLocalLanguage" />
                                )
                            </label>
                            <asp:TextBox ID="txtMultiLingualSurname" runat="server" CssClass="textInput medium error"
                                TabIndex="3" />
                            <asp:RegularExpressionValidator ID="rgvMultiLingualSurname" runat="server" ControlToValidate="txtMultiLingualSurname"
                                 SetFocusOnError="true" Display="Dynamic"
                                ErrorMessage="ValidateNoHTMLContent"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="ctrlHolder">
                        <label for="ctl00_ContentPlaceHolder1_txtUsername">
                            <JXTControl:ucLanguageLiteral ID="ltMemberRegisterUsername" runat="server" SetLanguageCode="LabelUsername" />
                            <span class="form-required">*</span>
                        </label>
                        <asp:TextBox ID="txtUsername" runat="server" CssClass="textInput medium error" TabIndex="4" />
                        <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ControlToValidate="txtUsername"
                            SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="rgvUsername" runat="server" ControlToValidate="txtUsername"
                             SetFocusOnError="true" Display="Dynamic"
                            ErrorMessage="ValidateNoHTMLContent"></asp:RegularExpressionValidator>
                    </div>
                    <div class="ctrlHolder">
                        <label for="txtPassword">
                            <JXTControl:ucLanguageLiteral ID="ltMemberRegisterPassword" runat="server" SetLanguageCode="LabelPassword" />
                            <span class="form-required">*</span>
                        </label>
                        <asp:TextBox ID="txtPassword" runat="server" MaxLength="25" TextMode="Password" CssClass="textInput medium error"
                            TabIndex="5" autocomplete="off" ClientIDMode="Static" />
                        <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword"
                            SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                        <p id="pPasswordError" class="help-block">
                            <asp:RegularExpressionValidator ID="revPassword" runat="server" ErrorMessage="" Display="Dynamic"
                                ClientIDMode="Static" ControlToValidate="txtPassword" ValidationExpression="^(?=.{8,}$)(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9]).*$" /><JXTControl:ucLanguageLiteral
                                    ID="ltPasswordPrompt" runat="server" SetLanguageCode="LabelPasswordPrompt" />
                        </p>
                    </div>
                    <div class="ctrlHolder">
                        <label for="ctl00_ContentPlaceHolder1_txtConfirmPassword">
                            <JXTControl:ucLanguageLiteral ID="ltMemberRegisterConfirmPassword" runat="server"
                                SetLanguageCode="LabelConfirmPassword" />
                            <span class="form-required">*</span>
                        </label>
                        <asp:TextBox ID="txtConfirmPassword" runat="server" MaxLength="25" TextMode="Password"
                            CssClass="textInput medium error" TabIndex="6" autocomplete="off" />
                        <asp:RequiredFieldValidator ID="rfvConfirmPassword" runat="server" ControlToValidate="txtConfirmPassword"
                            SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="comvPassword" runat="server" ControlToValidate="txtConfirmPassword"
                            ControlToCompare="txtPassword" SetFocusOnError="true" Display="Dynamic"></asp:CompareValidator>
                    </div>
                    <div class="ctrlHolder">
                        <label for="ctl00_ContentPlaceHolder1_txtEmailAddress">
                            <JXTControl:ucLanguageLiteral ID="ltMemberRegisterEmail" runat="server" SetLanguageCode="LabelEmail" />
                            <span class="form-required">*</span>
                        </label>
                        <asp:TextBox ID="txtEmailAddress" runat="server" CssClass="textInput medium error"
                            TabIndex="7" />
                        <asp:RequiredFieldValidator ID="rfvEmailAddress" runat="server" ControlToValidate="txtEmailAddress"
                            SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revEmailAddress" runat="server" ControlToValidate="txtEmailAddress"
                            SetFocusOnError="true" Display="Dynamic">  
                        </asp:RegularExpressionValidator>
                    </div>
                    <div class="ctrlHolder">
                        <label for="ctl00_ContentPlaceHolder1_txtConfirmEmail">
                            <JXTControl:ucLanguageLiteral ID="ltMemberRegisterConfirmEmail" runat="server" SetLanguageCode="LabelConfirmEmail" />
                            <span class="form-required">*</span>
                        </label>
                        <asp:TextBox ID="txtConfirmEmail" runat="server" CssClass="textInput medium error"
                            TabIndex="8" />
                        <asp:CompareValidator ID="cvEmailAddress" runat="server" ControlToValidate="txtConfirmEmail"
                            ControlToCompare="txtEmailAddress" SetFocusOnError="true" Display="Dynamic"></asp:CompareValidator>
                    </div>
                </asp:Panel>
                <asp:PlaceHolder ID="phLanguage" runat="server" Visible="false">
                    <div class="ctrlHolder">
                        <label id="Label17" for="ctl00_ContentPlaceHolder1_ddlLanguage">
                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral10" runat="server" SetLanguageCode="LabelPreferredEmailLanguage" />
                        </label>
                        <asp:DropDownList ID="ddlLanguage" runat="server" AutoPostBack="false">
                        </asp:DropDownList>
                    </div>
                </asp:PlaceHolder>
                <h3 onclick="javascript:toggle();" class="MemberFullRegisterHeader">
                    <JXTControl:ucLanguageLiteral ID="ltMemberFullRegister" runat="server" SetLanguageCode="LabelMemberFullRegister" />
                </h3>
                <asp:Panel ID="pnlFullRegistration" runat="server" Style="display: none;">
                    <div class="ctrlHolder hidden">
                        <asp:Label id="lbDOB" runat="server" AssociatedControlID="tbDOB">
                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral13" runat="server" SetLanguageCode="LabelDateOfBirth" />
                        </asp:Label>
                        <asp:TextBox ID="tbDOB" runat="server" CssClass="textInput medium error" TabIndex="8"
                            MaxLength="10" ClientIDMode="Static" />
                            <asp:CustomValidator ID="cvDOB" runat="server" CssClass="fieldstar" SetFocusOnError="true" Display="Dynamic" OnServerValidate="cvDOB_ServerValidate"></asp:CustomValidator>
                    </div>
                    <div class="ctrlHolder">
                        <label id="Label2" runat="server" for="ctl00_ContentPlaceHolder1_txtTel">
                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral1" runat="server" SetLanguageCode="LabelTel" />
                        </label>
                        <asp:TextBox ID="txtTel" runat="server" CssClass="textInput medium error" TabIndex="9"
                            MaxLength="38" />
                        <%--                        <asp:CompareValidator ID="cmpTel" runat="server" ControlToValidate="txtTel" Type="Integer"
                            Operator="DataTypeCheck" ErrorMessage="Telephone field must be numbers only"
                            Display="Dynamic" SetFocusOnError="true" />
                        --%>
                        <%--<asp:RequiredFieldValidator ID="rfvTel" runat="server" ControlToValidate="txtTel"
                            SetFocusOnError="true" Display="Dynamic" />--%>
                        <asp:RegularExpressionValidator ID="validatorPhone" runat="server" ControlToValidate="txtTel"
                            SetFocusOnError="true" Display="Dynamic" ValidationExpression="^[ \+\(\)\d]*$"
                            ErrorMessage="ValidationPhoneNumbers">  
                        </asp:RegularExpressionValidator>
                    </div>
                    <div class="ctrlHolder">
                        <label id="Label3" runat="server" for="ctl00_ContentPlaceHolder1_txtAddress">
                            <JXTControl:ucLanguageLiteral ID="ltMemberRegisterAddress" runat="server" SetLanguageCode="LabelAddress" />
                        </label>
                        <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" class="form-textarea medium"
                            Rows="4" Columns="40" TabIndex="10" />
                        <asp:RegularExpressionValidator ID="revAddress" runat="server" ControlToValidate="txtAddress"
                            Display="Dynamic" ErrorMessage="Please enter maximum 1500 characters for Suburb"
                            ValidationExpression="[\s\S]{1,1500}"></asp:RegularExpressionValidator>
                        <asp:RegularExpressionValidator ID="rgvAddress" runat="server" ControlToValidate="txtAddress"
                             SetFocusOnError="true" Display="Dynamic"
                            ErrorMessage="ValidateNoHTMLContent"></asp:RegularExpressionValidator>
                    </div>
                    <div class="ctrlHolder">
                        <label id="Label4" runat="server" for="ctl00_ContentPlaceHolder1_txtSuburb">
                            <JXTControl:ucLanguageLiteral ID="ltMemberRegisterSuburb" runat="server" SetLanguageCode="LabelSuburb" />
                        </label>
                        <asp:TextBox ID="txtSuburb" runat="server" CssClass="textInput medium error" TabIndex="11" />
                        <asp:RegularExpressionValidator ID="revSuburb" runat="server" ControlToValidate="txtSuburb"
                            Display="Dynamic" ErrorMessage="Please enter maximum 20 characters for Suburb"
                            ValidationExpression="[\s\S]{1,20}"></asp:RegularExpressionValidator>
                       <asp:RegularExpressionValidator ID="rgvSuburb" runat="server" ControlToValidate="txtSuburb"
                             SetFocusOnError="true" Display="Dynamic"
                            ErrorMessage="ValidateNoHTMLContent"></asp:RegularExpressionValidator>
                     </div>
                    <div class="ctrlHolder">
                        <label id="Label1" runat="server" for="ctl00_ContentPlaceHolder1_txtPostcode">
                            <JXTControl:ucLanguageLiteral ID="ltMemberRegisterPostcode" runat="server" SetLanguageCode="LabelPostcode" />
                        </label>
                        <asp:TextBox ID="txtPostcode" runat="server" CssClass="textInput medium error" TabIndex="12" />
                        <asp:RegularExpressionValidator ID="revPostcode" runat="server" ControlToValidate="txtPostcode"
                            Display="Dynamic" ErrorMessage="Please enter maximum 10 characters for Postcode"
                            ValidationExpression="[\s\S]{1,10}"></asp:RegularExpressionValidator>
                       <asp:RegularExpressionValidator ID="rgvPostcode" runat="server" ControlToValidate="txtPostcode"
                             SetFocusOnError="true" Display="Dynamic"
                            ErrorMessage="ValidateNoHTMLContent"></asp:RegularExpressionValidator>
                    </div>
                    <div class="ctrlHolder">
                        <label id="Label6" runat="server" for="ctl00_ContentPlaceHolder1_txtState">
                            <JXTControl:ucLanguageLiteral ID="ltMemberRegisterStates" runat="server" SetLanguageCode="LabelState" />
                        </label>
                        <asp:TextBox ID="txtState" runat="server" CssClass="textInput medium error" TabIndex="13" />
                        <asp:RegularExpressionValidator ID="revState" runat="server" ControlToValidate="txtState"
                            Display="Dynamic" ErrorMessage="Please enter maximum 20 characters for State"
                            ValidationExpression="[\s\S]{1,20}"></asp:RegularExpressionValidator>
                       <asp:RegularExpressionValidator ID="rgvState" runat="server" ControlToValidate="txtState"
                             SetFocusOnError="true" Display="Dynamic"
                            ErrorMessage="ValidateNoHTMLContent"></asp:RegularExpressionValidator>
                    </div>
                    <div class="ctrlHolder">
                        <label for="ctl00_ContentPlaceHolder1_ddlCountry">
                            <JXTControl:ucLanguageLiteral ID="ltMemberRegisterCountry" runat="server" SetLanguageCode="LabelCountry" />
                        </label>
                        <asp:DropDownList runat="server" ID="ddlCountry" CssClass="selectInput medium" TabIndex="14" />
                        <%--<asp:RequiredFieldValidator ID="rfvCountry" runat="server" InitialValue="0" ControlToValidate="ddlCountry"
                            SetFocusOnError="true" Display="Dynamic" />--%>
                    </div>
                    <div class="ctrlHolder">
                        <label for="ckAddMailingAddress">
                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral4" runat="server" SetLanguageCode="LabelAddMailingAddress" />
                        </label>
                        <asp:CheckBox runat="server" ID="ckAddMailingAddress" TabIndex="15" ClientIDMode="Static" />
                    </div>
                    <div id="divMailingAddress" class="ctrlHolder" style="display: none;" runat="server"
                        clientidmode="Static">
                        <label id="Label12" runat="server" for="ctl00_ContentPlaceHolder1_tbMailingAddress">
                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral5" runat="server" SetLanguageCode="LabelMailingAddress" />
                        </label>
                        <asp:TextBox ID="tbMailingAddress" runat="server" TextMode="MultiLine" class="form-textarea medium"
                            Columns="40" Rows="4" TabIndex="16" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="tbMailingAddress"
                            Display="Dynamic" ErrorMessage="Please enter maximum 1500 characters for Suburb"
                            ValidationExpression="[\s\S]{1,1500}"></asp:RegularExpressionValidator>
                       <asp:RegularExpressionValidator ID="rgvMailingAddress" runat="server" ControlToValidate="tbMailingAddress"
                             SetFocusOnError="true" Display="Dynamic"
                            ErrorMessage="ValidateNoHTMLContent"></asp:RegularExpressionValidator>
                    </div>
                    <div id="divMailingSuburb" class="ctrlHolder" style="display: none;" runat="server"
                        clientidmode="Static">
                        <label id="Label13" runat="server" for="ctl00_ContentPlaceHolder1_tbMailingSuburb">
                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral6" runat="server" SetLanguageCode="LabelMailingSuburb" />
                        </label>
                        <asp:TextBox ID="tbMailingSuburb" runat="server" CssClass="textInput medium error"
                            TabIndex="17" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="tbMailingSuburb"
                            Display="Dynamic" ErrorMessage="Please enter maximum 20 characters for Suburb"
                            ValidationExpression="[\s\S]{1,20}"></asp:RegularExpressionValidator>
                       <asp:RegularExpressionValidator ID="rgvMailingSuburb" runat="server" ControlToValidate="tbMailingSuburb"
                             SetFocusOnError="true" Display="Dynamic"
                            ErrorMessage="ValidateNoHTMLContent"></asp:RegularExpressionValidator>
                    </div>
                    <div id="divMailingPostcode" class="ctrlHolder" style="display: none;" runat="server"
                        clientidmode="Static">
                        <label id="Label14" runat="server" for="ctl00_ContentPlaceHolder1_tbMailingPostcode">
                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral7" runat="server" SetLanguageCode="LabelMailingPostcode" />
                        </label>
                        <asp:TextBox ID="tbMailingPostcode" runat="server" CssClass="textInput medium error"
                            TabIndex="18" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="tbMailingPostcode"
                            Display="Dynamic" ErrorMessage="Please enter maximum 10 characters for Postcode"
                            ValidationExpression="[\s\S]{1,10}"></asp:RegularExpressionValidator>
                       <asp:RegularExpressionValidator ID="rgvMailingPostcode" runat="server" ControlToValidate="tbMailingPostcode"
                             SetFocusOnError="true" Display="Dynamic"
                            ErrorMessage="ValidateNoHTMLContent"></asp:RegularExpressionValidator>
                    </div>
                    <div id="divMailingState" class="ctrlHolder" style="display: none;" runat="server"
                        clientidmode="Static">
                        <label id="Label15" runat="server" for="ctl00_ContentPlaceHolder1_tbMailingState">
                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral8" runat="server" SetLanguageCode="LabelMailingState" />
                        </label>
                        <asp:TextBox ID="tbMailingState" runat="server" CssClass="textInput medium error"
                            TabIndex="19" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="tbMailingState"
                            Display="Dynamic" ErrorMessage="Please enter maximum 20 characters for State"
                            ValidationExpression="[\s\S]{1,20}"></asp:RegularExpressionValidator>
                       <asp:RegularExpressionValidator ID="rgvMailingState" runat="server" ControlToValidate="tbMailingState"
                             SetFocusOnError="true" Display="Dynamic"
                            ErrorMessage="ValidateNoHTMLContent"></asp:RegularExpressionValidator>
                    </div>
                    <div id="divMailingCountry" class="ctrlHolder" style="display: none;" runat="server"
                        clientidmode="Static">
                        <label for="ctl00_ContentPlaceHolder1_ddlMailingCountry">
                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral9" runat="server" SetLanguageCode="LabelMailingCountry" />
                        </label>
                        <asp:DropDownList runat="server" ID="ddlMailingCountry" CssClass="selectInput medium"
                            TabIndex="20" />
                        <%--<asp:RequiredFieldValidator ID="rfvCountry" runat="server" InitialValue="0" ControlToValidate="ddlCountry"
                            SetFocusOnError="true" Display="Dynamic" />--%>
                    </div>
                    <asp:UpdatePanel ID="updatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="ctrlHolder">
                                <label id="Label7" for="ctl00_ContentPlaceHolder1_ddlClassification">
                                    <JXTControl:ucLanguageLiteral ID="ucClassificationAndSubClassification" runat="server"
                                        SetLanguageCode="LabelClassification" />
                                </label>
                                <asp:DropDownList ID="ddlClassification" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlClassification_SelectedIndexChanged"
                                    AutoPostBack="true" TabIndex="21" />
                            </div>
                            <div class="ctrlHolder">
                                <label id="Label8" for="ddlSubClassification">
                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral2" runat="server" SetLanguageCode="LabelSubClassification" />
                                </label>
                                <asp:DropDownList ID="ddlSubClassification" runat="server" CssClass="form-control"
                                    ClientIDMode="Static" TabIndex="22" />
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <div class="ctrlHolder" id="memberregister-passportnumber-field">
                        <label id="Label9" for="ctl00_ContentPlaceHolder1_txtPassport">
                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral3" runat="server" SetLanguageCode="LabelPassportNumber" />
                        </label>
                        <asp:TextBox ID="txtPassport" runat="server" CssClass="textInput medium error" TabIndex="23"
                            MaxLength="75" />
                    </div>
                    <div class="ctrlHolder">
                        <label id="Label10" for="ctl00_ContentPlaceHolder1_docInput">
                            <JXTControl:ucLanguageLiteral ID="ltMemberFilesSelectDocument" runat="server" SetLanguageCode="LabelSelectDocument" />
                        </label>
                        <asp:FileUpload ID="docInput" runat="server" CssClass="form-textbox2" TabIndex="24" />
                        <asp:CustomValidator ID="cvalDocument" runat="server" CssClass="fieldstar" ErrorMessage="CustomValidator"
                            SetFocusOnError="true" Display="Dynamic" OnServerValidate="cvalDocument_ServerValidate"></asp:CustomValidator>
                    </div>
                    <div class="ctrlHolder">
                        <asp:Label ID="lbCoverLetter" runat="server" AssociatedControlID="fuCoverLetter">
                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral12" runat="server" SetLanguageCode="LabelCoverLetter" />
                        </asp:Label>
                        <asp:FileUpload ID="fuCoverLetter" runat="server" CssClass="form-textbox2" TabIndex="24" />
                        <asp:CustomValidator ID="cvalCoverLetter" runat="server" CssClass="fieldstar" ErrorMessage="CustomValidator"
                            SetFocusOnError="true" Display="Dynamic" OnServerValidate="cvalCoverLetter_ServerValidate"></asp:CustomValidator>
                    </div>
                    <%--<div class="ctrlHolder">
                          
                          <ul class="blockLabels">
                            <li>
                                <label for=""><input id="" name="" type="radio"> Html</label>
                            </li>
                            
                            <li>
                                <label for=""><input id="" name="" type="radio"> Text</label>
                            </li>
                       </ul>
                          <p class="formHint">Format of Email</p>
                        </div>--%>
                    <div class="ctrlHolder">
                        <p class="label">
                            <JXTControl:ucLanguageLiteral ID="ltMemberRegisterEmailFormat" runat="server" SetLanguageCode="LabelEmailFormat" />
                        </p>
                        <ul class="blockLabels">
                            <li>
                                <asp:RadioButtonList ID="radlEmailFormat" RepeatDirection="Horizontal" RepeatLayout="Flow"
                                    runat="server" class="form-radio2" TabIndex="25">
                                    <asp:ListItem Value="1" Selected="True"></asp:ListItem>
                                    <asp:ListItem Value="2"></asp:ListItem>
                                </asp:RadioButtonList>
                            </li>
                        </ul>
                    </div>
                </asp:Panel>
                <div class="buttonHolder">
                    <asp:Button ID="btnSubmit" runat="server" Text="Register" OnClick="btnSubmit_Click"
                        CssClass="mini-new-buttons" TabIndex="26" ClientIDMode="Static" OnClientClick="ApplyCheck(event);" />
                </div>
                <JXTControl:ucPrivacySettings ID="ucPrivacySettings" runat="server" />
            </fieldset>
        </div>
    </div>
    <script type="text/javascript">
        function ApplyCheck(event) {

            if ($("#revPassword").css("display") == "inline") {
                $("#pPasswordError").prop("class", "help-block error");
            }
            else {
                $("#pPasswordError").prop("class", "help-block");
            }

        }

        $(document).ready(function () {

            var nowTemp = new Date();
            var now = new Date(nowTemp.getFullYear(), nowTemp.getMonth(), nowTemp.getDate() + 1, 0, 0, 0, 0);

            $('#tbDOB').datepicker({
                format: '<%=DateFormat %>',
                onRender: function (date) {
                    return date.valueOf() >= now.valueOf() ? 'disabled' : '';
                }
            });


        });
    </script>
</asp:Content>
