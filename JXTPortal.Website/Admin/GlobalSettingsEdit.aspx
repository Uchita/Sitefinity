<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master"
    ValidateRequest="false" AutoEventWireup="true" Inherits="JXTPortal.Website.Admin.GlobalSettingsEdit"
    Title="GlobalSettings Edit" CodeBehind="GlobalSettingsEdit.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    Global Settings - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="scriptManager" runat="server" />
    <script type="text/javascript">
        function CharaterCount(textboxid, spanid, max) {
            var len = $("#ctl00_ContentPlaceHolder1_" + textboxid).val().length;
            $("#" + spanid).text("Character Count: " + len);
            if (len > max) {
                $("#" + spanid).css("color", "red");
            }
            else {
                $("#" + spanid).css("color", "black");
            }
        }
    </script>
    <div class="form-all">
        <span class="form-message">
            <asp:Literal ID="ltlMessage" runat="server" /></span>
        <asp:MultiView ID="MultiViewSiteResource" runat="server" ActiveViewIndex="0">
            <asp:View ID="ViewSiteResource" runat="server">
                <ul class="form-section">
                    <li class="form-line" id="gse-generalsettings-field">
                        <h3>
                            General Settings</h3>
                    </li>
                    <asp:UpdatePanel ID="updatePanel" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <li class="form-line" id="Li6">
                                <label class="form-label-left">
                                    Site Type:<span class="form-required">*</span></label>
                                <div class="form-input">
                                    <asp:DropDownList ID="ddlSiteType" runat="server" CssClass="form-multiple-column"
                                        AutoPostBack="true" OnSelectedIndexChanged="ddlSiteType_SelectedIndexChanged"
                                        Width="180px">
                                        <asp:ListItem Value="1">Recruiter</asp:ListItem>
                                        <asp:ListItem Value="2">Job Board</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </li>
                            <li class="form-line">
                                <label class="form-label-left">
                                    Advertiser Approval Process:
                                </label>
                                <div class="form-input">
                                    <asp:PlaceHolder ID="phRecruiterOption" runat="server">
                                        <label class="help-label">
                                            <asp:CheckBox ID="cbAdvertiserApprovalProcess" runat="server" />
                                            Important: Please update email templates "<a href='/admin/siteemailtemplatesedit.aspx?ParentEmailTemplateID=4667'>New
                                                Advertiser Alert</a>" &amp; "<a href='/admin/siteemailtemplatesedit.aspx?ParentEmailTemplateID=4668'>Advertiser
                                                    Update Status</a>" after checking this option
                                        </label>
                                    </asp:PlaceHolder>
                                    <asp:PlaceHolder ID="phJobBoardOption" runat="server">
                                        <asp:DropDownList ID="ddlAdvertiserApprovalProcess" runat="server" CssClass="form-multiple-column">
                                            <asp:ListItem Value="0">All advertisers auto approved</asp:ListItem>
                                            <asp:ListItem Value="1">All advertisers types approval process</asp:ListItem>
                                            <asp:ListItem Value="2">Account type approval process / Credit card type is auto approved</asp:ListItem>
                                        </asp:DropDownList>
                                        <%-- <label class="help-label">
                                            Important: Please update email templates "<a href='/admin/siteemailtemplatesedit.aspx?ParentEmailTemplateID=4667'>New
                                                Advertiser Alert</a>" &amp; "<a href='/admin/siteemailtemplatesedit.aspx?ParentEmailTemplateID=4668'>Advertiser
                                                    Update Status</a>" after checking this option
                                        </label>--%>
                                    </asp:PlaceHolder>
                                </div>
                            </li>
                            <li class="form-line" id="gse-language-field">
                                <label class="form-label-left">
                                    Default Language:<span class="form-required">*</span></label>
                                <div class="form-input">
                                    <asp:DropDownList ID="dataLanguage" runat="server" CssClass="form-multiple-column"
                                        AutoPostBack="True" OnSelectedIndexChanged="dataLanguage_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="ReqVal_Language" runat="server" ControlToValidate="dataLanguage"
                                        ErrorMessage="Required" InitialValue="0" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                </div>
                            </li>
                             <li class="form-line" id="Li7">
                                <label class="form-label-left">
                                    Default Email Language:<span class="form-required">*</span></label>
                                <div class="form-input">
                                    <asp:DropDownList ID="ddlDefaultEmailLanguage" runat="server" CssClass="form-multiple-column">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlDefaultEmailLanguage"
                                        ErrorMessage="Required" InitialValue="0" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                </div>
                            </li>
                            <li class="form-line" id="Li4">
                                <label class="form-label-left">
                                    Default Country:<span class="form-required">*</span></label>
                                <div class="form-input">
                                    <asp:DropDownList ID="dataCountry" runat="server" CssClass="form-multiple-column">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="ReqVal_Country" runat="server" ControlToValidate="dataCountry"
                                        ErrorMessage="Required" InitialValue="" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                </div>
                            </li>
                            <li class="form-line" id="gse-dynamicpage-field">
                                <label class="form-label-left">
                                    Homepage:<span class="form-required">*</span></label>
                                <div class="form-input">
                                    <asp:DropDownList ID="dataDynamicPage" runat="server" CssClass="form-multiple-column">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="dataDynamicPage"
                                        ErrorMessage="Required" InitialValue="0" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                </div>
                            </li>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <li class="form-line" id="gse-sitedoctype-field">
                        <label class="form-label-left">
                            Site Doc Type:</label>
                        <div class="form-input">
                            <asp:TextBox ID="dataSiteDocType" runat="server" />
                        </div>
                    </li>
                    <li class="form-line">
                        <label class="form-label-left">
                            Member Registration Notification:
                        </label>
                        <div class="form-input">
                            <asp:TextBox ID="txtSiteEmailMemberRegistration" runat="server" />
                            <asp:CustomValidator ID="ctmEmailMemberRegistration" runat="server" ControlToValidate="txtSiteEmailMemberRegistration"
                                Display="Dynamic" OnServerValidate="ctmEmailMemberRegistration_ServerValidate"
                                SetFocusOnError="true" />
                        </div>
                    </li>
                    <li class="form-line">
                        <label class="form-label-left">
                            WWW Redirect:
                        </label>
                        <div class="form-input">
                            <asp:CheckBox runat="server" ID="dataWWWRedirect" CssClass="form-radio-column" Checked="true">
                            </asp:CheckBox>&nbsp;
                        </div>
                    </li>
                    <li class="form-line">
                        <label class="form-label-left">
                            SSL Enabled:
                        </label>
                        <div class="form-input">
                            <label class="help-label">
                                <asp:CheckBox runat="server" ID="cbSSLEnabled" CssClass="form-radio-column"></asp:CheckBox>&nbsp;
                                When enabled, logins and payments page will use HTTPS for secured connections. SSL is required for this settings.
                            </label>
                        </div>
                    </li>
                    <li class="form-line">
                        <label class="form-label-left">
                            Use Custom Profession Roles:
                        </label>
                        <div class="form-input">
                            <asp:CheckBox ID="cbUseCustomProfessionRoles" runat="server" OnCheckedChanged="cbUseCustomProfessionRoles_CheckedChanged" />
                        </div>
                    </li>
                    <li class="form-line">
                        <label class="form-label-left">
                            Generate Job XML:
                        </label>
                        <div class="form-input">
                            <asp:CheckBox ID="chkGenerateJobXML" runat="server" />
                        </div>
                    </li>
                    <li class="form-line">
                        <label class="form-label-left">
                            Job Expiry Notification:
                        </label>
                        <div class="form-input">
                            <label class="help-label">
                                <asp:CheckBox ID="cbJobExpiryNotification" runat="server" />
                                Main switch for advertiser users to receive email notifications on expiring jobs.
                                Each advertiser users' account must also enable the receive expiring jobs notifications
                                settings in order to recieve notifications.
                            </label>
                        </div>
                    </li>
                    <asp:Panel ID="phProcess" runat="server">
                        <li class="form-line">
                            <label class="form-label-left">
                                Job Screening Process:
                            </label>
                            <div class="form-input">
                                <label class="help-label">
                                    <asp:CheckBox ID="cbJobScreeningProcess" runat="server" />
                                    Important: Please update email templates "<a href='/admin/siteemailtemplatesedit.aspx?ParentEmailTemplateID=4669'>New
                                        Job Created</a>" &amp; "<a href='/admin/siteemailtemplatesedit.aspx?ParentEmailTemplateID=4670'>Advertiser
                                            Job Status Result</a>" after checking this option
                                </label>
                            </div>
                        </li>
                    </asp:Panel>
                    <li class="form-line">
                            <label class="form-label-left">
                                Date Format:
                            </label>
                            <div class="form-input">
                                <label class="help-label">
                                    <asp:DropDownList ID="ddlDateFormat" runat="server" CssClass="form-multiple-column">
                                        <asp:ListItem Value="dd/MM/yyyy" Text="DD/MM/YYYY" />
                                        <asp:ListItem Value="MM/dd/yyyy" Text="MM/DD/YYYY" />
                                        <asp:ListItem Value="yyyy/MM/dd" Text="YYYY/MM/DD" />
                                    </asp:DropDownList>
                                </label>
                            </div>
                        </li>
                    <li class="form-line" id="Li3">
                        <h3>
                            Private Whitelabel</h3>
                    </li>
                    <li class="form-line">
                        <label class="form-label-left">
                            Is Private Site:
                        </label>
                        <div class="form-input">
                            <asp:CheckBox ID="chkPrivateSite" runat="server" />
                        </div>
                    </li>
                    <asp:PlaceHolder ID="phPrivateHolder" runat="server" Visible="false">
                        <li class="form-line">
                            <label class="form-label-left">
                                Redirect URL:
                            </label>
                            <div class="form-input">
                                <asp:TextBox ID="txtPrivateRedirectUrl" runat="server" width="400" />
                            </div>
                        </li>
                    </asp:PlaceHolder>
                    <li class="form-line" id="Li12">
                        <h3>
                            People Search Settings</h3>
                    </li>
                    <li class="form-line">
                        <label class="form-label-left">
                            Enable People Search:
                        </label>
                        <div class="form-input">
                            <asp:CheckBox ID="cbPeopleSearchCB" runat="server" />
                        </div>
                    </li>
                    <li class="form-line" id="Li13">
                        <h3>
                            Screening Questions Settings</h3>
                    </li>
                    <li class="form-line">
                        <label class="form-label-left">
                            Enable Screening Questions:
                        </label>
                        <div class="form-input">
                            <asp:CheckBox ID="cbScreeningQuestions" runat="server" />
                        </div>
                    </li>
                    <li class="form-line" id="Li5">
                        <h3>
                            Job Application</h3>
                    </li>
                    <li class="form-line">
                        <label class="form-label-left">
                            Enable Job Custom Questionnaire:
                        </label>
                        <div class="form-input">
                            <asp:CheckBox ID="chkEnableJobCustomQuestionnaire" runat="server" />
                        </div>
                    </li>
                    <li class="form-line">
                        <label class="form-label-left">
                            Job Application Type:
                        </label>
                        <div class="form-input">
                            <asp:DropDownList ID="ddlJobApplicationTypeID" runat="server" CssClass="form-multiple-column">
                            </asp:DropDownList>
                        </div>
                    </li>
                    <li class="form-line" id="Li8">
                        <h3>
                            Google Settings</h3>
                    </li>
                    <li class="form-line" id="Li10">
                        <label class="form-label-left">
                            Google Analytics Code:</label>
                        <div class="form-input">
                            <asp:TextBox ID="tbGoogleAnalytics" runat="server" Width="400" PlaceHolder="Example: UA-33568220-1"></asp:TextBox>
                        </div>
                    </li>
                    <li class="form-line" id="Li9">
                        <label class="form-label-left">
                            Google Tag Manager Code:</label>
                        <div class="form-input">
                            <asp:TextBox ID="tbGoogleTagManager" runat="server" Width="400" PlaceHolder="Example: GTM-K5KLMN"></asp:TextBox>
                        </div>
                    </li>
                    <li class="form-line" id="Li11">
                        <label class="form-label-left">
                            Google Web Master Code:</label>
                        <div class="form-input">
                            <asp:TextBox ID="tbGoogleWebMaster" runat="server" Width="400" PlaceHolder="Example: 0fQayhSKZtytDm8_TbDY6dDg4WikxceOMvy-K90bU1s"></asp:TextBox>
                        </div>
                    </li>
                    <li class="form-line" id="Li3">
                        <h3>
                            SEO</h3>
                    </li>
                    <li class="form-line" id="gse-pagetitleprefix-field">
                        <label class="form-label-left">
                            Page Title Prefix:</label>
                        <div class="form-input">
                            <asp:TextBox ID="dataPageTitlePrefix" runat="server" width="400"></asp:TextBox>
                            <asp:CustomValidator ID="cvPageTitlePrefix" runat="server" ErrorMessage="Page Title Prefix contains more than 510 characters"
                                SetFocusOnError="true" ControlToValidate="dataPageTitlePrefix" OnServerValidate="cvPageTitlePrefix_ServerValidate" />
                        </div>
                    </li>
                    <li class="form-line" id="gse-pagetitlesuffix-field">
                        <label class="form-label-left">
                            Page Title Suffix:</label>
                        <div class="form-input">
                            <asp:TextBox ID="dataPageTitleSuffix" runat="server" width="400"></asp:TextBox>
                            <asp:CustomValidator ID="cvPageTitleSuffix" runat="server" ErrorMessage="Page Title Suffix contains more than 510 characters"
                                SetFocusOnError="true" ControlToValidate="dataPageTitleSuffix" OnServerValidate="cvPageTitleSuffix_ServerValidate" />
                        </div>
                    </li>
                    <li class="form-line" id="gse-hometitle-field">
                        <label class="form-label-left">
                            Home Title:</label>
                        <div class="form-input">
                            <asp:TextBox ID="dataHomeTitle" runat="server" width="400" onkeyup="CharaterCount('dataHomeTitle', 'spHomeTitleCount', 69);"
                                onmouseup="CharaterCount('dataHomeTitle', 'spHomeTitleCount', 69);"></asp:TextBox>&nbsp;<span
                                    id="spHomeTitleCount"></span>
                            <asp:CustomValidator ID="cvHomeTitle" runat="server" ErrorMessage="Home Title contains more than 510 characters"
                                SetFocusOnError="true" ControlToValidate="dataHomeTitle" OnServerValidate="cvHomeTitle_ServerValidate" />
                        </div>
                    </li>
                    <li class="form-line" id="gse-homedescription-field">
                        <label class="form-label-left">
                            Home Description:</label>
                        <div class="form-input">
                            <asp:TextBox ID="dataHomeDescription" runat="server" TextMode="MultiLine" Rows="6"
                                Columns="40" onkeyup="CharaterCount('dataHomeDescription', 'spHomeDescriptionCount', 160);"
                                onmouseup="CharaterCount('dataHomeDescription', 'spHomeDescriptionCount', 160);"></asp:TextBox>&nbsp;<span
                                    id="spHomeDescriptionCount"></span>
                            <asp:CustomValidator ID="cvHomeDescription" runat="server" ErrorMessage="Home Description contains more than 510 characters"
                                SetFocusOnError="true" ControlToValidate="dataHomeDescription" OnServerValidate="cvHomeDescription_ServerValidate" />
                        </div>
                    </li>
                    <li class="form-line" id="gse-homekeywords-field">
                        <label class="form-label-left">
                            Home Keywords:</label>
                        <div class="form-input">
                            <asp:TextBox ID="dataHomeKeywords" runat="server" TextMode="MultiLine" Rows="6" Columns="40"
                                onkeyup="CharaterCount('dataHomeKeywords', 'spHomeKeywordsCount', 256);" onmouseup="CharaterCount('dataHomeKeywords', 'spHomeKeywordsCount', 256);"></asp:TextBox>
                            <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="Dynamic"
                                ControlToValidate="dataHomeKeywords" ErrorMessage="Home Description can not exceed 256 characters"
                                ValidationExpression="(?:[\r\n]*.[\r\n]*){0,256}" />--%>
                            <span id="spHomeKeywordsCount"></span>
                            <asp:CustomValidator ID="cvHomeKeywords" runat="server" ErrorMessage="Home Keywords contains more than 510 characters"
                                SetFocusOnError="true" ControlToValidate="dataHomeKeywords" OnServerValidate="cvHomeKeywords_ServerValidate" />
                        </div>
                    </li>
                    <li class="form-line" id="gse-defaulttitle-field">
                        <label class="form-label-left">
                            Default Title:</label>
                        <div class="form-input">
                            <asp:TextBox ID="dataDefaultTitle" runat="server" width="400" onkeyup="CharaterCount('dataDefaultTitle', 'spTitleCount', 69);"
                                onmouseup="CharaterCount('dataDefaultTitle', 'spTitleCount', 69);"></asp:TextBox>&nbsp;<span
                                    id="spTitleCount"></span>
                            <asp:CustomValidator ID="cvDefaultTitle" runat="server" ErrorMessage="Default Title contains more than 510 characters"
                                SetFocusOnError="true" ControlToValidate="dataDefaultTitle" OnServerValidate="cvDefaultTitle_ServerValidate" />
                        </div>
                    </li>
                    <li class="form-line" id="gse-defaultdescription-field">
                        <label class="form-label-left">
                            Default Description:</label>
                        <div class="form-input">
                            <asp:TextBox ID="dataDescription" runat="server" TextMode="MultiLine" Rows="6" Columns="40"
                                onkeyup="CharaterCount('dataDescription', 'spDescriptionCount', 160);" onmouseup="CharaterCount('dataDescription', 'spDescriptionCount', 160);"></asp:TextBox>&nbsp;<span
                                    id="spDescriptionCount"></span>
                            <asp:CustomValidator ID="cvDescription" runat="server" ErrorMessage="Default Description contains more than 510 characters"
                                SetFocusOnError="true" ControlToValidate="dataDescription" OnServerValidate="cvDescription_ServerValidate" />
                        </div>
                    </li>
                    <li class="form-line" id="gse-defaultkeywords-field">
                        <label class="form-label-left">
                            Default Keywords:</label>
                        <div class="form-input">
                            <asp:TextBox ID="dataDefaultKeywords" runat="server" TextMode="MultiLine" Rows="6"
                                Columns="40" onkeyup="CharaterCount('dataDefaultKeywords', 'spKeywordsCount', 256);"
                                onmouseup="CharaterCount('dataDefaultKeywords', 'spKeywordsCount', 256);"></asp:TextBox>&nbsp;<span
                                    id="spKeywordsCount"></span>
                            <asp:CustomValidator ID="cvDefaultKeywords" runat="server" ErrorMessage="Default Keywords contains more than 510 characters"
                                SetFocusOnError="true" ControlToValidate="dataDefaultKeywords" OnServerValidate="cvDefaultKeywords_ServerValidate" />
                        </div>
                    </li>
                    <asp:Panel ID="pnlMeta" runat="server">
                        <ul class="form-section">
                            <li class="form-line" id="gse-metatags1-field">
                                <label class="form-label-left">
                                    Meta Tags 1 (Global):<br />
                                </label>
                                <div class="form-input">
                                    <b>(can contain javascript tags, css tags, favicon, meta tags etc - will be applied
                                        to the whole site)</b><br />
                                    <asp:TextBox ID="txtMetaTags" runat="server" TextMode="MultiLine" Width="600px" Height="400px"></asp:TextBox>
                                    <br />
                                </div>
                            </li>
                            <li class="form-line" id="gse-metatags2-field">
                                <label class="form-label-left">
                                    Meta Tags 2 (System Pages only):<br />
                                    Excludes Homepage & Dynamic Pages
                                </label>
                                <div class="form-input">
                                    <b>(can contain javascript tags, css tags, favicon, meta tags etc - will be applied
                                        to the System pages)</b><br />
                                    <b>Max 2000 characters</b><br />
                                    <asp:TextBox ID="txtSystemPages" runat="server" TextMode="MultiLine" Width="600px"
                                        Height="200px"></asp:TextBox><br />
                                    <asp:CustomValidator ID="cvMetaTags2" runat="server" ErrorMessage="Meta Tags 2 contains more than 2000 characters"
                                        SetFocusOnError="true" ControlToValidate="txtSystemPages" OnServerValidate="cvMetaTags2_ServerValidate" />
                                </div>
                            </li>
                        </ul>
                    </asp:Panel>
                    <ul class="form-section">
                        <li class="form-line" id="gse-ftpfolder-field">
                            <label class="form-label-left">
                                FTP Folder:</label>
                            <div class="form-input">
                                <asp:TextBox ID="dataFTPFolder" runat="server"></asp:TextBox>
                            </div>
                        </li>
                        <li class="form-line" id="Li1">
                            <h3>
                                Privacy Settings</h3>
                        </li>
                        <li class="form-line" id="Li2">
                            <label class="form-label-left">
                                Privacy Settings
                            </label>
                            <div class="form-input">
                                <asp:TextBox ID="dataPrivacySettings" runat="server" TextMode="MultiLine" Width="600px"
                                    Height="200px"></asp:TextBox>
                            </div>
                        </li>
                        <li class="form-line" id="gse-accesssettings-field">
                            <h3>
                                Job Access Settings</h3>
                        </li>
                        <li class="form-line" id="gse-publicjobsearch-field">
                            <label class="form-label-left">
                                Public Job Search:</label>
                            <div class="form-input">
                                <asp:CheckBox runat="server" ID="dataPublicJobSearch" CssClass="form-radio-column">
                                </asp:CheckBox>&nbsp;
                                <%--<label class="form-required">Note: It allows all Jobs to be displayed </label>--%>
                            </div>
                        </li>
                        <li class="form-line" id="gse-privatejobs-field">
                            <label class="form-label-left">
                                Private Jobs:</label>
                            <div class="form-input">
                                <asp:CheckBox runat="server" ID="dataPrivateJobs" CssClass="form-radio-column"></asp:CheckBox>&nbsp;
                                <%--<label class="form-required">Note: It allows all Jobs to be displayed </label>--%>
                            </div>
                        </li>
                        <li class="form-line" id="gse-useadvertiserfilter-field">
                            <label class="form-label-left">
                                Use Advertiser Filter</label>
                            <div class="form-input">
                                <asp:CheckBox runat="server" ID="dataUseAdvertiserFilter" CssClass="form-check-column">
                                </asp:CheckBox>
                                <asp:HyperLink ID="hypLinkAdvertiserFilter" runat="server" NavigateUrl="~/Admin/SiteAdvertisersFilter.aspx">Advertiser Filter</asp:HyperLink>&nbsp;
                                <%--<label class="form-required">Note: It allows all Jobs to be displayed </label>--%>
                            </div>
                        </li>
                    </ul>
                    <asp:Panel ID="pnlLinkedIn" runat="server">
                        <ul class="form-section">
                            <li class="form-line" id="gse-linkedinsettings-field">
                                <h3>
                                    LinkedIn Settings</h3>
                            </li>
                            <li class="form-line" id="gse-linkedinapi-field">
                                <label class="form-label-left">
                                    LinkedIn API:</label>
                                <div class="form-input">
                                    <asp:TextBox ID="tbLinkedInAPI" runat="server"></asp:TextBox>
                                </div>
                            </li>
                            <li class="form-line" id="gse-linkedinapisecret-field">
                                <label class="form-label-left">
                                    LinkedIn API Secret:</label>
                                <div class="form-input">
                                    <asp:TextBox ID="tbLinkedInAPISecret" runat="server"></asp:TextBox>
                                </div>
                            </li>
                            <li class="form-line" id="gse-linkedinlogo-field">
                                <label class="form-label-left">
                                    LinkedIn Logo URL:</label>
                                <div class="form-input">
                                    <asp:TextBox ID="tbLinkedInLogo" runat="server"></asp:TextBox>
                                </div>
                            </li>
                            <li class="form-line" id="gse-linkedincompanyid-field">
                                <label class="form-label-left">
                                    LinkedIn Company ID:</label>
                                <div class="form-input">
                                    <asp:TextBox ID="tbLinkedInCompanyID" runat="server"></asp:TextBox><asp:RangeValidator ID="rvLinkedInCompanyID" runat="server" ControlToValidate="tbLinkedInCompanyID" Type="Integer" ErrorMessage="LinkedIn Company ID must be number." MaximumValue="9999999" MinimumValue="0"></asp:RangeValidator>
                                </div>
                            </li>
                            <li class="form-line" id="gse-linkedinemail-field">
                                <label class="form-label-left">
                                    LinkedIn Email:</label>
                                <div class="form-input">
                                    <asp:TextBox ID="tbLinkedInEmail" runat="server"></asp:TextBox>
                                </div>
                            </li>
                        </ul>
                    </asp:Panel>
                    <%--<asp:Panel ID="pnlGoogle" runat="server">
                        <ul class="form-section">
                            <li class="form-line" id="gse-googlesettings-field">
                                <h3>
                                    Google Settings</h3>
                            </li>
                            <li class="form-line" id="gse-googleclientid-field">
                                <label class="form-label-left">
                                    Google Client ID:</label>
                                <div class="form-input">
                                    <asp:TextBox ID="tbGoogleClientID" runat="server"></asp:TextBox>
                                </div>
                            </li>
                            <li class="form-line" id="gse-googleclientsecret-field">
                                <label class="form-label-left">
                                    Google Client Secret:</label>
                                <div class="form-input">
                                    <asp:TextBox ID="tbGoogleClientSecret" runat="server"></asp:TextBox>
                                </div>
                            </li>
                        </ul>
                    </asp:Panel>
                    <asp:Panel ID="pnlFacebook" runat="server">
                        <ul class="form-section">
                            <li class="form-line" id="gse-facebooksettings-field">
                                <h3>
                                    Facebook Settings</h3>
                            </li>
                            <li class="form-line" id="gse-facebookappid-field">
                                <label class="form-label-left">
                                    Facebook App ID:</label>
                                <div class="form-input">
                                    <asp:TextBox ID="tbFacebookAppID" runat="server"></asp:TextBox>
                                </div>
                            </li>
                            <li class="form-line" id="gse-facebookappsecret-field">
                                <label class="form-label-left">
                                    Facebook App Secret:</label>
                                <div class="form-input">
                                    <asp:TextBox ID="tbFacebookAppSecret" runat="server"></asp:TextBox>
                                </div>
                            </li>
                        </ul>
                    </asp:Panel>--%>
                    <ul class="form-section">
                        <li class="form-line" id="gse-modifiedsettings-field">
                            <h3>
                                Modified Settings</h3>
                        </li>
                        <li class="form-line" id="gse-lastmodified-field">
                            <label class="form-label-left">
                                Last Modified:</label>
                            <div class="form-input">
                                <asp:Label runat="server" ID="lblLastModified" MaxLength="10"></asp:Label>
                            </div>
                        </li>
                        <li class="form-line" id="gse-lastmodifiedby-field">
                            <label class="form-label-left">
                                Last Modified By:</label>
                            <div class="form-input">
                                <asp:Label ID="lblLastModifiedBy" runat="server" />
                            </div>
                        </li>
                        <li class="form-line">
                            <div class="form-input-wide">
                                <div class="form-buttons-wrapper">
                                    <%--<asp:Button ID="btnApply" runat="server" Text="Apply" OnClick="btnEditSave_Click"
                                        CssClass="jxtadminbutton" />--%>
                                    <asp:Button ID="btnEditSave" runat="server" Text="Update" OnClick="btnEditSave_Click"
                                        CssClass="jxtadminbutton" />
                                    <asp:Button ID="btnReturn" runat="server" Text="Return" OnClick="btnReturn_Click"
                                        CssClass="jxtadminbutton" CausesValidation="false" />
                                </div>
                            </div>
                        </li>
                    </ul>
                    <script type="text/javascript">
                        CharaterCount("dataDefaultTitle", "spTitleCount", 69);
                        CharaterCount("dataDescription", "spDescriptionCount", 160);
                        CharaterCount("dataDefaultKeywords", "spKeywordsCount", 256);
                        CharaterCount("dataHomeTitle", "spHomeTitleCount", 69);
                        CharaterCount("dataHomeDescription", "spHomeDescriptionCount", 160);
                        CharaterCount("dataHomeKeywords", "spHomeKeywordsCount", 256);
                    </script>
            </asp:View>
        </asp:MultiView>
    </div>
</asp:Content>
