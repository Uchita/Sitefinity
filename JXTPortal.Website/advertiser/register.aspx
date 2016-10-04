<%@ Page Language="C#" MasterPageFile="~/MasterPages/CustomMain.Master" AutoEventWireup="true"
    CodeBehind="register.aspx.cs" Inherits="JXTPortal.Website.advertiser.register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="/scripts/strength.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
            $('#dataPassword').strength({
                strengthClass: 'strength',
                strengthMeterClass: 'strength_meter',
                strengthButtonClass: 'button_strength',
                strengthButtonText: '',
                strengthButtonTextToggle: ''
            });
        });
    </script>
    <div id="content-container">
        <div id="content">
            <div class="content-holder">
                <JXTControl:ucSystemDynamicPage ID="ucSystemDynamicPage" runat="server" SetSystemPageCode="SystemPage_AdvertiserRegistration" />
                <div class="jxt-form jxt-form-advertiser-register">
                    <section class="jxt-form-section jxt-form-section-register-your-details">
		<h2><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral1" runat="server" SetLanguageCode="LabelRegisterYourDetails" /></h2>
        <asp:PlaceHolder ID="phMessage" runat="server" Visible="false"><span class="jxt-error">
                <asp:Literal ID="litMessage" runat="server" /></span></asp:PlaceHolder>
        <asp:PlaceHolder ID="pnlCompanySection" runat="server">
            <asp:PlaceHolder ID="phAccountType" runat="server">
		<fieldset class="jxt-form-fieldset jxt-form-fieldset-account-type">
			    <legend><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral2" runat="server" SetLanguageCode="LabelAccountType" /></legend>
			    <div class="jxt-form-group jxt-form-account-type">
				    <div class="jxt-form-combined">
					    <label for="rbAccount"><input id="rbAccount" runat="server" type="radio" name="account-type" value="1" checked clientidmode="Static" /> <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral4" runat="server" SetLanguageCode="LabelOngoingAccount" /></label>
				    </div>
				    <div class="jxt-form-combined">
					    <label for="rbCreditCard">
                        <input id="rbCreditCard" runat="server" type="radio" name="account-type" value="2" clientidmode="Static" /> <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral5" runat="server" SetLanguageCode="LabelPayByCreditCard" /></label>
				    </div>
			    </div>  
			    <div class="jxt-form-group jxt-form-more-information">
				    <div class="jxt-form-text">
					    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral6" runat="server" SetLanguageCode="LabelMoreInfoOnAcc" />, <a href="" class="advertiserMoreInfo"><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral7" runat="server" SetLanguageCode="LabelClickHere" />.</a>
				    </div>
			    </div>
            
		</fieldset>
        </asp:PlaceHolder></asp:PlaceHolder>

		<fieldset class="jxt-form-fieldset jxt-form-fieldset-personal-details">
			<legend><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral8" runat="server" SetLanguageCode="LabelPersonalDetails" /></legend>
			<div class="jxt-form-group jxt-form-email">
				<div class="jxt-form-label">
					<label for="ctl00_ContentPlaceHolder1_dataEmailAddress"><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral9" runat="server" SetLanguageCode="LabelEmail" />&nbsp;<span class="form-required">*</span></label>
				</div>
				<div class="jxt-form-field">
					<asp:TextBox ID="dataEmailAddress" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ReqVal_EmailAddress" runat="server" ControlToValidate="dataEmailAddress"
                                ErrorMessage="Required" SetFocusOnError="true" Display="Dynamic" CssClass="jxt-error"></asp:RequiredFieldValidator>
                            <asp:CustomValidator ID="CusVal_EmailAddress" runat="server" ControlToValidate="dataEmailAddress"
                                ErrorMessage="Invalid Email Format" OnServerValidate="CusVal_EmailAddress_ServerValidate"
                                SetFocusOnError="true" Display="Dynamic" CssClass="jxt-error"></asp:CustomValidator>
				</div>
			</div>
			<div class="jxt-form-group jxt-form-username">
				<div class="jxt-form-label">
					<label for="ctl00_ContentPlaceHolder1_dataUserName"><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral10" runat="server" SetLanguageCode="LabelUsername" />&nbsp;<span class="form-required">*</span></label>
				</div>
				<div class="jxt-form-field">
					<asp:TextBox ID="dataUserName" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ReqVal_UserName" runat="server" ControlToValidate="dataUserName"
                                ErrorMessage="Required" SetFocusOnError="true" Display="Dynamic" CssClass="jxt-error"></asp:RequiredFieldValidator>
                            <asp:CustomValidator ID="CusVal_UserName" runat="server" ControlToValidate="dataUserName"
                                ErrorMessage="User Name already exists" OnServerValidate="CusVal_UserName_ServerValidate"
                                SetFocusOnError="true" Display="Dynamic" CssClass="jxt-error"></asp:CustomValidator>
				</div>
			</div>
			<div class="jxt-form-group jxt-form-password">
				<div class="jxt-form-label">
					<label for="dataPassword"><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral11" runat="server" SetLanguageCode="LabelPassword" />&nbsp;<span class="form-required">*</span></label>
				</div>
				<div class="jxt-form-field">
					<asp:TextBox ID="dataPassword" runat="server" TextMode="Password" autocomplete="off" ClientIDMode="Static"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ReqVal_Password" runat="server" ControlToValidate="dataPassword" ClientIDMode="Static"
                                ErrorMessage="Required" SetFocusOnError="true" Display="Dynamic" CssClass="jxt-error"></asp:RequiredFieldValidator>
                                
                            <p id="pPasswordError" class="help-block"><asp:RegularExpressionValidator ID="revPassword" runat="server" ErrorMessage="" Display="Dynamic" ClientIDMode="Static"
                            ControlToValidate="dataPassword" ValidationExpression="^(?=.{8,}$)(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9]).*$" /><JXTControl:ucLanguageLiteral ID="ltPasswordPrompt" runat="server" SetLanguageCode="LabelPasswordPrompt" /></p>
				</div>
			</div>

			<div class="jxt-form-group jxt-form-confirm-password">
				<div class="jxt-form-label">
					<label for="ctl00_ContentPlaceHolder1_dataConfirmPassword"><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral12" runat="server" SetLanguageCode="LabelConfirmPassword" />&nbsp;<span class="form-required">*</span></label>
				</div>
				<div class="jxt-form-field">
					 <asp:TextBox ID="dataConfirmPassword" runat="server" TextMode="Password" autocomplete="off"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ReqVal_ConfirmPassword" runat="server" ControlToValidate="dataConfirmPassword"
                                ErrorMessage="Required" SetFocusOnError="true" Display="Dynamic" CssClass="jxt-error"></asp:RequiredFieldValidator>
				</div>
			</div>
			<div class="jxt-form-group jxt-form-first-name">
				<div class="jxt-form-label">
					<label for="ctl00_ContentPlaceHolder1_dataFirstName"><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral13" runat="server" SetLanguageCode="LabelFirstName" />&nbsp;<span class="form-required">*</span></label>
				</div>
				<div class="jxt-form-field">
					<asp:TextBox ID="dataFirstName" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ReqVal_FirstName" runat="server" ControlToValidate="dataFirstName"
                                ErrorMessage="Required" SetFocusOnError="true" Display="Dynamic" CssClass="jxt-error"></asp:RequiredFieldValidator>
				</div>
			</div>
			<div class="jxt-form-group jxt-form-last-name">
				<div class="jxt-form-label">
					<label for="ctl00_ContentPlaceHolder1_dataLastName"><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral14" runat="server" SetLanguageCode="LabelLastName" />&nbsp;<span class="form-required">*</span></label>
				</div>
				<div class="jxt-form-field">
					<asp:TextBox ID="dataLastName" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ReqVal_LastName" runat="server" ControlToValidate="dataLastName"
                                ErrorMessage="Required" SetFocusOnError="true" Display="Dynamic" CssClass="jxt-error"></asp:RequiredFieldValidator>
				</div>
			</div>
			
		</fieldset>
        <asp:PlaceHolder ID="pnlCompanyDetails" runat="server">
		<fieldset class="jxt-form-fieldset jxt-form-fieldset-company-details">
			<legend><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral16" runat="server" SetLanguageCode="LabelCompanyDetails" /></legend>
            <div class="jxt-form-group jxt-form-phone">
				<div class="jxt-form-label">
					<label for="ctl00_ContentPlaceHolder1_dataPhone"><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral15" runat="server" SetLanguageCode="LabelPhone" />&nbsp;<span class="form-required">*</span></label>
				</div>
				<div class="jxt-form-field">
					<asp:TextBox ID="dataPhone" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ReqVal_Phone" runat="server" ControlToValidate="dataPhone"
                                ErrorMessage="Required" SetFocusOnError="true" Display="Dynamic" CssClass="jxt-error"></asp:RequiredFieldValidator>
				</div>
			</div>
			<div class="jxt-form-group jxt-form-company">
				<div class="jxt-form-label">
					<label for="ctl00_ContentPlaceHolder1_dataCompanyName"><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral17" runat="server" SetLanguageCode="LabelCompany" /> / <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral18" runat="server" SetLanguageCode="LabelBusinessName" />&nbsp;<span class="form-required">*</span></label>
				</div>
				<div class="jxt-form-field">
					<asp:TextBox ID="dataCompanyName" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ReqVal_CompanyName" runat="server" ControlToValidate="dataCompanyName"
                                    ErrorMessage="Required" SetFocusOnError="true" Display="Dynamic" CssClass="jxt-error"></asp:RequiredFieldValidator>
				</div>
			</div>
			<div class="jxt-form-group jxt-form-application-email">
				<div class="jxt-form-label">
					<label for="ctl00_ContentPlaceHolder1_dataApplicationEmail"><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral19" runat="server" SetLanguageCode="LabelApplicationEmail" />&nbsp;<span class="form-required">*</span></label>
				</div>
				<div class="jxt-form-field">
					<asp:TextBox ID="dataApplicationEmail" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ReqVal_ApplicationEmail" runat="server" ControlToValidate="dataApplicationEmail"
                                ErrorMessage="Required" SetFocusOnError="true" Display="Dynamic" CssClass="jxt-error"></asp:RequiredFieldValidator>
                            <asp:CustomValidator ID="CusVal_ApplicationEmail" runat="server" ControlToValidate="dataApplicationEmail"
                                ErrorMessage="Invalid Email Format" OnServerValidate="CusVal_ApplicationEmail_ServerValidate"
                                SetFocusOnError="true" Display="Dynamic" CssClass="jxt-error"></asp:CustomValidator>
				</div>
			</div>
			<div class="jxt-form-group jxt-form-business-type">
				<div class="jxt-form-label">
					<label for="ctl00_ContentPlaceHolder1_ddlBusinessType"><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral20" runat="server" SetLanguageCode="LabelBusinessType" />&nbsp;<span class="form-required">*</span></label>
				</div>
				<div class="jxt-form-field">
					<asp:DropDownList ID="ddlBusinessType" runat="server" />
                                <asp:RequiredFieldValidator ID="rfvBusinessType" runat="server" ControlToValidate="ddlBusinessType" 
                                        InitialValue="0" SetFocusOnError="true" Display="Dynamic" CssClass="jxt-error" ></asp:RequiredFieldValidator>
				</div>
			</div>
			<div class="jxt-form-group jxt-form-business-number">
				<div class="jxt-form-label">
					<label for="ctl00_ContentPlaceHolder1_txtBusinessNumber"><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral21" runat="server" SetLanguageCode="LabelBusinessNumber" /></label>
				</div>
				<div class="jxt-form-field">
					<asp:TextBox ID="txtBusinessNumber" runat="server" MaxLength="100"></asp:TextBox>
				</div>
			</div>
			<div class="jxt-form-group jxt-form-number-of-employees">
				<div class="jxt-form-label">
					<label for="ctl00_ContentPlaceHolder1_dataNoOfEmployees"><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral22" runat="server" SetLanguageCode="LabelNumberOfEmployees" /></label>
				</div>
				<div class="jxt-form-field">
					<asp:TextBox ID="dataNoOfEmployees" runat="server" MaxLength="10"></asp:TextBox>
				</div>
			</div>
            <asp:PlaceHolder ID="phLanguage" runat="server" Visible= "false">
                <div class="jxt-form-group jxt-form-language">
				    <div class="jxt-form-label">
					    <label for="ctl00_ContentPlaceHolder1_ddlLanguage"><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral3" runat="server" SetLanguageCode="LabelLanguage" /></label>
				    </div>
				    <div class="jxt-form-field">
					    <asp:DropDownList ID="ddlLanguage" runat="server" AutoPostBack="false"></asp:DropDownList>
				    </div>
			    </div>
            </asp:PlaceHolder>
			<div class="jxt-form-group jxt-form-company-logo">
				<div class="jxt-form-label">
					<label for="ctl00_ContentPlaceHolder1_fuCompanyLogo"><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral23" runat="server" SetLanguageCode="LabelCompanyLogo" /></label>
				</div>
				<div class="jxt-form-field">
					<asp:FileUpload ID="fuCompanyLogo" runat="server" />
                    <asp:CustomValidator ID="cvalDocument" runat="server" CssClass="fieldstar" ErrorMessage="CustomValidator"
                                SetFocusOnError="true" Display="Dynamic" OnServerValidate="cvalDocument_ServerValidate"></asp:CustomValidator>
					<span id="helpBlock" class="help-block"><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral24" runat="server" SetLanguageCode="LabelMaxWidth" />:&nbsp;300px / <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral25" runat="server" SetLanguageCode="LabelMaxSize" />:&nbsp;1mb / file&nbsp;type: jpg,&nbsp;png,&nbsp;gif</span>
				</div>
			</div>
		</fieldset>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phAdvertiserFullRegister" runat="server">
             <h3 onclick="javascript:toggle();" class="MemberFullRegisterHeader" id="MemberFullRegisterHeader">
                    <JXTControl:ucLanguageLiteral ID="ltAdvertiserFullRegister" runat="server" SetLanguageCode="LabelAdvertiserFullRegister" />
                </h3>
                <asp:Panel ID="pnlFullRegistration" runat="server" Style="display: none;">
                    <fieldset class="jxt-form-fieldset jxt-form-fieldset-personal-details">
                        <div class="jxt-form-group jxt-form-video-url">
				            <div class="jxt-form-label">
					            <asp:label id="Label2" runat="server" AssociatedControlID="tbVideoLink">
                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral26" runat="server" SetLanguageCode="LabelVideoLink" />
                                </asp:label>
				            </div>
				            <div class="jxt-form-field">
					            <asp:TextBox ID="tbVideoLink" runat="server" MaxLength="500" />
				            </div>
			            </div>
                        <div class="jxt-form-group jxt-form-nominated-company-first-name">
				            <div class="jxt-form-label">
					            <asp:label id="Label1" runat="server" AssociatedControlID="tbNominatedCompanyFirstName">
                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral27" runat="server" SetLanguageCode="LabelNominatedCompanyFirstName" />
                                </asp:label>
				            </div>
				            <div class="jxt-form-field">
					            <asp:TextBox ID="tbNominatedCompanyFirstName" runat="server"
                            MaxLength="500" />
				            </div>
			            </div>
                        <div class="jxt-form-group jxt-form-nominated-company-email">
				            <div class="jxt-form-label">
					            <asp:label id="Label4" runat="server" AssociatedControlID="tbNominatedCompanyEmailAddress">
                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral29" runat="server" SetLanguageCode="LabelNominatedCompanyEmailAddress" />
                                </asp:label>
				            </div>
				            <div class="jxt-form-field">
					            <asp:TextBox ID="tbNominatedCompanyEmailAddress" runat="server"
                            MaxLength="255" />
                            <asp:CustomValidator ID="CusVal_NominatedCompanyEmailAddress" runat="server" ControlToValidate="tbNominatedCompanyEmailAddress"
                                ErrorMessage="Invalid Email Format" OnServerValidate="CusVal_NominatedCompanyEmailAddress_ServerValidate"
                                SetFocusOnError="true" Display="Dynamic" CssClass="jxt-error"></asp:CustomValidator>
				            </div>
			            </div>
                        <div class="jxt-form-group jxt-form-nominated-company-role">
				            <div class="jxt-form-label">
					            <asp:label id="Label6" runat="server" AssociatedControlID="tbNominatedCompanyRole">
                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral31" runat="server" SetLanguageCode="LabelNominatedCompanyRole" />
                                </asp:label>
				            </div>
				            <div class="jxt-form-field">
					            <asp:TextBox ID="tbNominatedCompanyRole" runat="server" MaxLength="500" />
				            </div>
			            </div>
                    </fieldset>
                   <fieldset class="jxt-form-fieldset jxt-form-fieldset-company-details">
                            <div class="jxt-form-group jxt-form-industry">
                                <asp:PlaceHolder ID="phIndustry" runat="server">
				                    <div class="jxt-form-label">
					                    <asp:label id="Label9" runat="server" AssociatedControlID="ddlIndustry">
                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral34" runat="server" SetLanguageCode="LabelIndustry" />
                                        </asp:label>
				                    </div>
				                    <div class="jxt-form-field">
					                    <asp:DropDownList ID="ddlIndustry" runat="server" MaxLength="500" />
				                    </div>
                                </asp:PlaceHolder>
                                <asp:PlaceHolder ID="phIndustrySub" runat="server">
                                    <div class="jxt-form-label">
					                    <label>&nbsp;</label>
				                    </div>
				                    <div class="jxt-form-field" style="height: 34px;">
					                    &nbsp;
				                    </div>
                                </asp:PlaceHolder>
			                </div>
                        
                        <div class="jxt-form-group jxt-form-nominated-company-last-name">
				            <div class="jxt-form-label">
					            <asp:label id="Label3" runat="server" AssociatedControlID="tbNominatedCompanyLastName">
                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral28" runat="server" SetLanguageCode="LabelNominatedCompanyLastName" />
                                </asp:label>
				            </div>
				            <div class="jxt-form-field">
					            <asp:TextBox ID="tbNominatedCompanyLastName" runat="server" MaxLength="510" />
				            </div>
			            </div>
                        <div class="jxt-form-group jxt-form-nominated-company-phone">
				            <div class="jxt-form-label">
					            <asp:label id="Label5" runat="server" AssociatedControlID="tbNominatedCompanyPhone">
                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral30" runat="server" SetLanguageCode="LabelNominatedCompanyPhone" />
                                </asp:label>
				            </div>
				            <div class="jxt-form-field">
					            <asp:TextBox ID="tbNominatedCompanyPhone" runat="server" MaxLength="100" />
				            </div>
			            </div>
                        <div class="jxt-form-group jxt-form-nominated-company-preferred-contact-method">
				            <div class="jxt-form-label">
					            <asp:label id="Label7" runat="server" AssociatedControlID="ddlPreferredContactMethod">
                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral32" runat="server" SetLanguageCode="LabelPreferredContactMethod" />
                                </asp:label>
				            </div>
				            <div class="jxt-form-field">
					            <asp:DropDownList runat="server" ID="ddlPreferredContactMethod" />
				            </div>
			            </div>
                   </fieldset>
                  <%--  <div class="ctrlHolder">
                        <asp:label id="Label3" runat="server" AssociatedControlID="tbNominatedCompanyRole">
                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral28" runat="server" SetLanguageCode="LabelNominatedCompanyRole" />
                        </asp:label>
                        <asp:TextBox ID="tbNominatedCompanyRole" runat="server" CssClass="textInput medium error"
                            MaxLength="500" />
                    </div>
                    <div class="ctrlHolder">
                        <asp:label id="Label4" runat="server" AssociatedControlID="tbNominatedCompanyFirstName">
                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral29" runat="server" SetLanguageCode="LabelNominatedCompanyFirstName" />
                        </asp:label>
                        <asp:TextBox ID="tbNominatedCompanyFirstName" runat="server" CssClass="textInput medium error"
                            MaxLength="510" />
                    </div>
                    <div class="ctrlHolder">
                        <asp:label id="Label5" runat="server" AssociatedControlID="tbNominatedCompanyLastName">
                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral30" runat="server" SetLanguageCode="LabelNominatedCompanyLastName" />
                        </asp:label>
                        <asp:TextBox ID="tbNominatedCompanyLastName" runat="server" CssClass="textInput medium error"
                            MaxLength="510" />
                    </div>
                    <div class="ctrlHolder">
                        <asp:label id="Label6" runat="server" AssociatedControlID="tbNominatedCompanyEmailAddress">
                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral31" runat="server" SetLanguageCode="LabelNominatedCompanyEmailAddress" />
                        </asp:label>
                        <asp:TextBox ID="tbNominatedCompanyEmailAddress" runat="server" CssClass="textInput medium error"
                            MaxLength="255" />
                    </div>
                    <div class="ctrlHolder">
                        <asp:label id="Label7" runat="server" AssociatedControlID="tbNominatedCompanyPhone">
                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral32" runat="server" SetLanguageCode="LabelNominatedCompanyPhone" />
                        </asp:label>
                        <asp:TextBox ID="tbNominatedCompanyPhone" runat="server" CssClass="textInput medium error"
                            MaxLength="100" />
                    </div>
                    <div class="ctrlHolder">
                        <asp:label id="Label8" runat="server" AssociatedControlID="ddlPreferredContactMethod">
                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral33" runat="server" SetLanguageCode="LabelPreferredContactMethod" />
                        </asp:label>
                        <asp:DropDownList runat="server" ID="ddlPreferredContactMethod" CssClass="selectInput medium" />
                    </div>--%>
                </asp:Panel>
        </asp:PlaceHolder>
		<div class="jxt-form-submit">
			<div class="jxt-form-text">
				<JXTControl:ucPrivacySettings ID="ucPrivacySettings" runat="server" />
			</div>
			<div class="jxt-form-button">
                <asp:LinkButton ID="btnRegister" runat="server" OnClick="btnRegister_Click" Text="Register" CssClass="mini-new-buttons" OnClientClick="ApplyCheck(event);" />
			</div>
		</div>
	</section>
                </div>
            </div>
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
    </script>
</asp:Content>
