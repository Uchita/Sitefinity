<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JobFields.ascx.cs" Inherits="JXTPortal.Website.Admin.UserControls.JobFields" %>

<div class="content-holder">
    
    <%--<div class="form-header-group">
        <h2 class="form-header">
            <asp:Label ID="lblJobCreate" runat="server" Text="Job Description"></asp:Label>
        </h2>
    </div>--%>

    <div class="form-all">
        <!--DO NOT REMOVE - THIS IS GLOBAL CONTAINER-->
        <span class="form-message">
            <asp:Literal ID="ltlMessage" runat="server" /></span>
        <asp:MultiView ID="MultiViewJobs" runat="server" ActiveViewIndex="0">
            <asp:View ID="ViewJobs" runat="server">
                <ul class="form-section">
                    
                    <%-- Sample of label Language Translation design
                    <label class="form-label-left">
                        <asp:Literal ID="ltMemberFilesDocumentTitle" runat="server" />: <span class="form-required">*</span>
                    </label>
                    --%>
                    
                    <li>
                        <div class="form-header-group">
                            <h2 class="form-header">
                            <JXTControl:ucLanguageLiteral ID="ltJobFieldHeaderJobDescription" runat="server" SetLanguageCode="LabelJobDescription" /> 
<%--                                <asp:Label ID="lblJobCreate" runat="server" Text="Job Description"></asp:Label>--%>
                            </h2>
                        </div>
                    </li>
        
                    <li class="form-line" id="jobs-jobname-field">
                        <label class="form-label-left">
                            <JXTControl:ucLanguageLiteral ID="ltJobFieldJobName" runat="server" SetLanguageCode="LabelJobName" /> :<span class="form-required">*</span></label>
                        <div class="form-input">
                            <asp:TextBox ID="dataJobName" runat="server" class="form-textbox2" />
                            <asp:RequiredFieldValidator ID="ReqVal_JobName" runat="server" ErrorMessage="Required"
                                ControlToValidate="dataJobName" />
                        </div>
                    </li>
                    <li class="form-line" id="jobs-refno-field">
                        <label class="form-label-left">
                            <JXTControl:ucLanguageLiteral ID="ltJobFieldReferenceNumber" runat="server" SetLanguageCode="LabelReferenceNumber" /> :</label>
                        <div class="form-input">
                            <asp:TextBox ID="dataRefNo" runat="server" class="form-textbox2" />
                        </div>
                    </li>
                    <li class="form-line" id="jobs-bulletpoint1-field">
                        <label class="form-label-left">
                            <JXTControl:ucLanguageLiteral ID="ltJobFieldBulletPoint1" runat="server" SetLanguageCode="LabelBulletPoint1" /> :</label>
                        <div class="form-input">
                            <asp:TextBox ID="dataBulletPoint1" runat="server" class="form-textbox2" />
                        </div>
                    </li>
                    <li class="form-line" id="jobs-bulletpoint2-field">
                        <label class="form-label-left">
                            <JXTControl:ucLanguageLiteral ID="ltJobFieldBulletPoint2" runat="server" SetLanguageCode="LabelBulletPoint2" /> :</label>
                        <div class="form-input">
                            <asp:TextBox ID="dataBulletPoint2" runat="server" class="form-textbox2" />
                        </div>
                    </li>
                    <li class="form-line" id="jobs-bulletpoint3-field">
                        <label class="form-label-left">
                            <JXTControl:ucLanguageLiteral ID="ltJobFieldBulletPoint3" runat="server" SetLanguageCode="LabelBulletPoint3" /> :</label>
                        <div class="form-input">
                            <asp:TextBox ID="dataBulletPoint3" runat="server" class="form-textbox2" />
                        </div>
                    </li>
                    <li class="form-line" id="jobs-hotjob-field">
                        <label class="form-label-left">
                            <JXTControl:ucLanguageLiteral ID="ltJobFieldHotJob" runat="server" SetLanguageCode="LabelHotJob" /> :</label>
                        <div class="form-input">
                            <asp:CheckBox ID="dataHotJob" runat="server" />
                        </div>
                    </li>
                    
                    <li class="form-line" id="jobs-worktype-field">
                        <label class="form-label-left">
                            <JXTControl:ucLanguageLiteral ID="ltJobFieldWorkType" runat="server" SetLanguageCode="LabelWorkType" /> :<span class="form-required">*</span></label>
                        <div class="form-input">
                            <asp:DropDownList runat="server" ID="dataWorkType" DataTextField="SiteWorkTypeName"
                                DataValueField="WorkTypeID" CssClass="form-multiple-column" />
                            <asp:RequiredFieldValidator ID="ReqVal_WorkType" runat="server" ErrorMessage="Required"
                                InitialValue="0" ControlToValidate="dataWorkType" />
                        </div>
                    </li>
                    
                    <li class="form-line" id="jobs-description-field">
                        <label class="form-label-left">
                            <JXTControl:ucLanguageLiteral ID="ltJobFieldShortDescription" runat="server" SetLanguageCode="LabelShortDescription" /> :<span class="form-required">*</span></label>
                        <div class="form-input">
                            <asp:TextBox ID="dataDescription" runat="server" TextMode="MultiLine" class="form-textarea"
                                Rows="3" />
                            <asp:RequiredFieldValidator ID="ReqVal_Description" runat="server" ErrorMessage="Required"
                                ControlToValidate="dataDescription" />
                        </div>
                    </li>
                    <li class="form-line" id="jobs-fuldescription-field">
                        <label class="form-label-left">
                            <JXTControl:ucLanguageLiteral ID="ltJobFieldFullDescription" runat="server" SetLanguageCode="LabelFullDescription" /> :<span class="form-required">*</span></label>
                        <div class="form-input">
                            <asp:TextBox ID="dataFullDescription" runat="server" TextMode="MultiLine" class="form-textarea"
                                Rows="15" />
                            <%--
                                <JXTControl:TinyMCETextBoxExtender ID="TinyMCETextBoxExtender1" runat="server" TargetControlID="dataFullDescription"
                                    Theme="advanced">
                                    <InitList>
                                        <JXTControl:TinyMCETextBoxInit Var="Plugins" Value="inlinepopups,style,layer,table,save,advhr,advimage,advlink,emotions,iespell,insertdatetime,preview,media,searchreplace,print,contextmenu,paste,directionality,fullscreen,noneditable,visualchars,nonbreaking,xhtmlxtras" />
                                        <JXTControl:TinyMCETextBoxInit Var="Theme_Advanced_Buttons1" Value="bold,italic,underline,strikethrough,|,justifyleft,justifycenter,justifyright,justifyfull,|,styleselect,formatselect,fontselect,fontsizeselect" />
                                        <JXTControl:TinyMCETextBoxInit Var="Theme_Advanced_Buttons2" Value="cut,copy,paste,pastetext,pasteword,|,search,replace,|,bullist,numlist,|,outdent,indent,|,undo,redo,|,link,unlink,anchor,image,cleanup,help,code,|,insertdate,inserttime,preview,|,forecolor,backcolor" />
                                        <JXTControl:TinyMCETextBoxInit Var="Theme_Advanced_Buttons3" Value="tablecontrols,|,hr,removeformat,visualaid,|,sub,sup,|,charmap,emotions,iespell,media,advhr,|,print,|,ltr,rtl,|,fullscreen" />
                                        <JXTControl:TinyMCETextBoxInit Var="Theme_Advanced_Buttons4" Value="insertlayer,moveforward,movebackward,absolute,|,styleprops,|,cite,abbr,acronym,del,ins,|,visualchars,nonbreaking" />
                                        <JXTControl:TinyMCETextBoxInit Var="Theme_Advanced_Toolbar_Location" Value="top" />
                                        <JXTControl:TinyMCETextBoxInit Var="Theme_Advanced_Toolbar_Align" Value="left" />
                                        <JXTControl:TinyMCETextBoxInit Var="Theme_Advanced_Statusbar_Location" Value="bottom" />
                                        <JXTControl:TinyMCETextBoxInit Var="Extended_Valid_Elements" Value="a[name|href|target|title|onclick],img[class|src|border=0|alt|title|hspace|vspace|width|height|align|onmouseover|onmouseout|name],hr[class|width|size|noshade],font[face|size|color|style],span[class|align|style]" />
                                    </InitList>
                                </JXTControl:TinyMCETextBoxExtender>
                                --%>
                        </div>
                    </li>
                    
                    <li class="form-line" id="jobs-documentlink-field">
                        <label class="form-label-left">
                            <JXTControl:ucLanguageLiteral ID="ltJobFieldDocumentLink" runat="server" SetLanguageCode="LabelDocumentLink" /> :</label>
                        <div class="form-input">
                            <asp:TextBox ID="dataDocumentLink" runat="server" class="form-textbox2" />
                        </div>
                    </li>
                    
                    <li class="form-line" id="jobs-tags-field">
                        <label class="form-label-left">
                            <JXTControl:ucLanguageLiteral ID="ltJobFieldTags" runat="server" SetLanguageCode="LabelTags" /> :</label>
                        <div class="form-input">
                            <asp:TextBox ID="dataTags" runat="server" class="form-textbox2" />
                        </div>
                    </li>
                    
                    <%--<li class="form-line" id="jobs-searchfieldextension-field">
                        <label class="form-label-left">
                            Search Field Extension:</label>
                        <div class="form-input">
                            <asp:TextBox ID="dataSearchFieldExtension" runat="server" class="form-textbox2" />
                            
                        </div>
                    </li>--%>
                    
                    <hr />
                    
                    <li>
                        <div class="form-header-group">
                            <h2 class="form-header">
                            <JXTControl:ucLanguageLiteral ID="ltJobFieldJobSalaryDetail" runat="server" SetLanguageCode="LabelJobSalaryDetail" />
<%--                                <asp:Label ID="Label1" runat="server" Text="Job Salary Details"></asp:Label>--%>
                            </h2>
                        </div>
                    </li>
                    
                    <li class="form-line" id="jobs-salary-field">
                        <label class="form-label-left">
                            <JXTControl:ucLanguageLiteral ID="ltJobFieldSalary" runat="server" SetLanguageCode="LabelSalary" /> :
                            <span class="form-required">*</span></label>
                        <div class="form-input">
                            <asp:DropDownList runat="server" ID="dataSalary" DataTextField="SiteSalaryName" DataValueField="SalaryID"
                                CssClass="form-multiple-column" />
                            <asp:RequiredFieldValidator ID="ReqVal_Salary" runat="server" ErrorMessage="Required"
                                InitialValue="0" ControlToValidate="dataSalary" />
                        </div>
                    </li>
                    <li class="form-line" id="jobs-salarytext-field">
                        <label class="form-label-left">
                            <JXTControl:ucLanguageLiteral ID="ltJobFieldSalaryText" runat="server" SetLanguageCode="LabelSalaryText" /> :</label>
                        <div class="form-input">
                            <asp:TextBox ID="dataSalaryText" runat="server" class="form-textbox2" />
                        </div>
                    </li>
                    <li class="form-line" id="jobs-showsalarydetails-field">
                        <label class="form-label-left">
                            <JXTControl:ucLanguageLiteral ID="ltJobFieldShowSalaryDetail" runat="server" SetLanguageCode="LabelShowSalaryDetail" /> :</label>
                        <div class="form-input">
                            <asp:CheckBox ID="dataShowSalaryDetails" runat="server" />
                        </div>
                    </li>
                    
                    <hr />
                    
                    <li>
                        <div class="form-header-group">
                            <h2 class="form-header">
                            <JXTControl:ucLanguageLiteral ID="ltJobFieldJobLocation" runat="server" SetLanguageCode="LabelJobLocation" />
                  <%--              <asp:Label ID="lblJobCreateLocation" runat="server" Text="Job Location"></asp:Label>--%>
                            </h2>
                        </div>
                    </li>
                    
                    <li class="form-line" id="jobs-SiteCountries">
                        <label class="form-label-left">
                            <JXTControl:ucLanguageLiteral ID="ltJobFieldCountry" runat="server" SetLanguageCode="LabelCountry" /> :<span class="form-required">*</span></label>
                        <div class="form-input">
                            <asp:DropDownList runat="server" ID="ddlSiteCountry" CssClass="form-multiple-column" AutoPostBack="true" OnSelectedIndexChanged="ddlSiteCountry_SelectedIndexChanged"/>
                            <asp:RequiredFieldValidator ID="ReqVal_SiteCountry" runat="server" ErrorMessage="Required"
                                InitialValue="0" ControlToValidate="ddlSiteCountry" />
                        </div>
                    </li>
                    
                    <li class="form-line" id="jobs-location-area">
                        <label class="form-label-left">
                            <JXTControl:ucLanguageLiteral ID="ltJobFieldLocationArea" runat="server" SetLanguageCode="LabelLocationArea" /> :<span class="form-required">*</span></label>
                        <div class="form-input">
                            <table>
                                <tr>
                                    <td>
                                        <asp:DropDownList ID="ddlLocation" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlLocation_SelectedIndexChanged" />
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlArea" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </li>
                    
                    <li class="form-line" id="jobs-address-field">
                        <label class="form-label-left">
                             <JXTControl:ucLanguageLiteral ID="ltJobFieldAddress" runat="server" SetLanguageCode="LabelAddress" /> :</label>
                        <div class="form-input">
                            <asp:TextBox ID="dataAddress" runat="server" class="form-textbox2" />
                        </div>
                    </li>
                    
                    <li class="form-line" id="jobs-publictransport-field">
                        <label class="form-label-left">
                             <JXTControl:ucLanguageLiteral ID="ltJobFieldPublicTransport" runat="server" SetLanguageCode="LabelPublicTransport" /> :</label>
                        <div class="form-input">
                            <asp:TextBox ID="dataPublicTransport" runat="server" class="form-textbox2" />
                        </div>
                    </li>
                    
                    <li class="form-line" id="jobs-showlocationdetails-field">
                        <label class="form-label-left">
                            <JXTControl:ucLanguageLiteral ID="ltJobFieldShowLocationDetail" runat="server" SetLanguageCode="LabelShowLocationDetail" /> :</label>
                        <div class="form-input">
                            <asp:CheckBox ID="dataShowLocationDetails" runat="server" />
                        </div>
                    </li>   
                    
                    <hr />
                    
                    <li>
                        <div class="form-header-group">
                            <h2 class="form-header">
                            <JXTControl:ucLanguageLiteral ID="ltJobFieldJobClassificationDetail" runat="server" SetLanguageCode="LabelJobClassificationDetail" />
    <%--                            <asp:Label ID="Label2" runat="server" Text="Job Classification Details"></asp:Label>--%>
                            </h2>
                        </div>
                    </li>
                    
                    <li class="form-line" id="jobs-profession-role-1">
                        <label class="form-label-left">
                            <JXTControl:ucLanguageLiteral ID="ltJobFieldJobProfession1" runat="server" SetLanguageCode="LabelProfession" /> 1:<span class="form-required">*</span></label>
                        <div class="form-input">
                            <table>
                                <tr>
                                    <td>
                                        <asp:DropDownList ID="ddlProfession1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlProfession1_SelectedIndexChanged" />
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlRole1" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </li>
                    <li class="form-line" id="jobs-profession-role-2">
                        <label class="form-label-left">
                            <JXTControl:ucLanguageLiteral ID="ltJobFieldJobProfession2" runat="server" SetLanguageCode="LabelProfession" /> 2:</label>
                        <div class="form-input">
                            <table>
                                <tr>
                                    <td>
                                        <asp:DropDownList ID="ddlProfession2" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlProfession2_SelectedIndexChanged" />
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlRole2" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </li>
                    <li class="form-line" id="jobs-profession-role-1">
                        <label class="form-label-left">
                            <JXTControl:ucLanguageLiteral ID="ltJobFieldJobProfession3" runat="server" SetLanguageCode="LabelProfession" /> 3:</label>
                        <div class="form-input">
                            <table>
                                <tr>
                                    <td>
                                        <asp:DropDownList ID="ddlProfession3" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlProfession3_SelectedIndexChanged" />
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlRole3" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </li>
                    
                    <hr />
                    
                    <li>
                        <div class="form-header-group">
                            <h2 class="form-header">
                            <JXTControl:ucLanguageLiteral ID="ltJobFieldJobApplicationDetail" runat="server" SetLanguageCode="LabelJobApplicationDetail" />
                                <%--<asp:Label ID="lblJobCreateApplication" runat="server" Text="Job Application Details"></asp:Label>--%>
                            </h2>
                        </div>
                    </li>
                    
                    <li class="form-line" id="jobs-applicationemailaddress-field">
                        <label class="form-label-left">
                            <JXTControl:ucLanguageLiteral ID="ltJobFieldApplicationEmailAddress" runat="server" SetLanguageCode="LabelApplicationEmailAddress" /> :<span class="form-required">*</span></label>
                        <div class="form-input">
                            <asp:TextBox ID="dataApplicationEmailAddress" runat="server" class="form-textbox2" />
                            <asp:RequiredFieldValidator ID="ReqVal_ApplicationEmailAddress" runat="server" ErrorMessage="Required"
                                ControlToValidate="dataApplicationEmailAddress" />
                        </div>
                    </li>
                    
                    <li class="form-line" id="jobs-applicationmethod-field">
                        <label class="form-label-left">
                             <JXTControl:ucLanguageLiteral ID="ltJobFieldApplicationMethod" runat="server" SetLanguageCode="LabelApplicationMethod" /> :</label>
                        <div class="form-input">
                            <asp:TextBox ID="dataApplicationMethod" runat="server" class="form-textbox2" />
                            <asp:RangeValidator ID="RangeVal_ApplicationMethod" runat="server" MinimumValue="1"
                                MaximumValue="9999" Type="Integer" ErrorMessage="Application Method Range must be between 1 - 9999"
                                ControlToValidate="dataApplicationMethod" />
                        </div>
                    </li>
                    <li class="form-line" id="jobs-applicationurl-field">
                        <label class="form-label-left">
                             <JXTControl:ucLanguageLiteral ID="ltJobFieldApplicationURL" runat="server" SetLanguageCode="LabelApplicationURL" /> :</label>
                        <div class="form-input">
                            <asp:TextBox ID="dataApplicationURL" runat="server" class="form-textbox2" />
                        </div>
                    </li>
                    <li class="form-line" id="jobs-uploadmethod-field">
                        <label class="form-label-left">
                            <JXTControl:ucLanguageLiteral ID="ltJobFieldUploadMethod" runat="server" SetLanguageCode="LabelUploadMethod" /> :</label>
                        <div class="form-input">
                            <asp:TextBox ID="dataUploadMethod" runat="server" class="form-textbox2" />
                            <asp:RangeValidator ID="RangeVal_UploadMethod" runat="server" MinimumValue="1" MaximumValue="9999"
                                Type="Integer" ErrorMessage="Upload Method Range must be between 1 - 9999" ControlToValidate="dataUploadMethod" />
                        </div>
                    </li>
                    <li class="form-line" id="jobs-requirelogonforexternalapplications-field">
                        <label class="form-label-left">
                             <JXTControl:ucLanguageLiteral ID="ltJobFieldRequireLogonForExternalApplications" runat="server" SetLanguageCode="LabelRequireLogonForExternalApplications" /> :</label>
                        <div class="form-input">
                            <asp:CheckBox ID="dataRequireLogonForExternalApplications" runat="server" />
                        </div>
                    </li>
                    
                    <hr />
                    
                    <li>
                        <div class="form-header-group">
                            <h2 class="form-header">
                              <JXTControl:ucLanguageLiteral ID="ltJobFieldJobContactDetails" runat="server" SetLanguageCode="LabelJobContactDetails" />
        <%--                        <asp:Label ID="lblJobCreateContactDetails" runat="server" Text="Job Contact Details"></asp:Label>--%>
                            </h2>
                        </div>
                    </li>
                    
                    <li class="form-line" id="jobs-contactdetails-field">
                        <label class="form-label-left">
                             <JXTControl:ucLanguageLiteral ID="ltJobFieldContactDetails" runat="server" SetLanguageCode="LabelContactDetails" /> :<span class="form-required">*</span></label>
                        <div class="form-input">
                            <asp:TextBox ID="dataContactDetails" runat="server" class="form-textbox2" />
                            <asp:RequiredFieldValidator ID="ReqVal_ContactDetails" runat="server" ErrorMessage="Required"
                                InitialValue="0" ControlToValidate="dataContactDetails" />
                        </div>
                    </li>
                    
                    <li class="form-line" id="jobs-jobcontactphone-field">
                        <label class="form-label-left">
                             <JXTControl:ucLanguageLiteral ID="ltJobFieldJobContactPhone" runat="server" SetLanguageCode="LabelPhone" /> :</label>
                        <div class="form-input">
                            <asp:TextBox ID="dataJobContactPhone" runat="server" class="form-textbox2" />
                        </div>
                    </li>
                    
                    <li class="form-line" id="jobs-jobcontactname-field">
                        <label class="form-label-left">
                              <JXTControl:ucLanguageLiteral ID="ltJobFieldJobContactName" runat="server" SetLanguageCode="LabelName" /> :</label>
                        <div class="form-input">
                            <asp:TextBox ID="dataJobContactName" runat="server" class="form-textbox2" />
                        </div>
                    </li>
                    
                    <hr />
                    
                    <li>
                        <div class="form-header-group">
                            <h2 class="form-header">
                               <JXTControl:ucLanguageLiteral ID="ltJobFieldJobCreateTemplate" runat="server" SetLanguageCode="LabelJobTemplate" />
                            <%--    <asp:Label ID="lblJobCreateTemplate" runat="server" Text="Job Template"></asp:Label>--%>
                            </h2>
                        </div>
                    </li>
                    
                    <li class="form-line" id="jobs-jobtemplateid-field">
                        <label class="form-label-left">
                               <JXTControl:ucLanguageLiteral ID="ltJobFieldJobTemplate" runat="server" SetLanguageCode="LabelJobTemplate" /> :<span class="form-required">*</span></label>
                        <div class="form-input">
                            <asp:DropDownList runat="server" ID="dataJobTemplateID" DataTextField="JobTemplateDescription"
                                DataValueField="JobTemplateID" CssClass="form-multiple-column" />
                            <asp:RequiredFieldValidator ID="ReqValJobTemplate" runat="server" ControlToValidate="dataJobTemplateID"
                                ErrorMessage="Required" InitialValue="0" />
                        </div>
                    </li>
                    
                    <li class="form-line" id="jobs-advertiserjobtemplatelogoid-field">
                        <label class="form-label-left">
                         <JXTControl:ucLanguageLiteral ID="ltJobFieldAdvertiserJobTemplate" runat="server" SetLanguageCode="LabelAdvertiserJobTemplateLogoSelectDoc" /> :</label>
                        <div class="form-input">
                            <%--<asp:TextBox ID="dataAdvertiserJobTemplateLogoID" runat="server" class="form-textbox2" />
                            <asp:RangeValidator ID="RangeValidator1" runat="server" MinimumValue="1" MaximumValue="9999"
                                Type="Integer" ErrorMessage="Upload Method Range must be between 1 - 9999" ControlToValidate="dataAdvertiserJobTemplateLogoID" />--%>
                            <asp:DropDownList runat="server" ID="ddlAdvertiserJobTemplateLogo" DataTextField="JobLogoName"
                                DataValueField="AdvertiserJobTemplateLogoID" CssClass="form-multiple-column" />
                        </div>
                    </li>
                    
                    <hr />
                    
                    <li>
                        <div class="form-header-group">
                            <h2 class="form-header">
                            <JXTControl:ucLanguageLiteral ID="ltJobFieldHeaderJobItems" runat="server" SetLanguageCode="LabelJobItem" />
                              <%--  <asp:Label ID="lblJobCreateJobItems" runat="server" Text="Job Items"></asp:Label>--%>
                            </h2>
                        </div>
                    </li>
                    
                    <li class="form-line" id="jobs-jobitemprice-field">
                        <label class="form-label-left">
                            <JXTControl:ucLanguageLiteral ID="ltJobFieldJobItemPrice" runat="server" SetLanguageCode="LabelJobItemPrice" /> :<span class="form-required">*</span></label>
                        <div class="form-input">
                            <asp:TextBox ID="dataJobItemPrice" runat="server" class="form-textbox2" />
                            <asp:RequiredFieldValidator ID="ReqVal_JobItemPrice" runat="server" ControlToValidate="dataJobItemPrice"
                                ErrorMessage="Required" />
                            <asp:RangeValidator ID="RangeVal_JobItemPrice" runat="server" MinimumValue="1" MaximumValue="9999"
                                Type="Double" ErrorMessage="Price Range must be between 1 - 9999" ControlToValidate="dataJobItemPrice" />
                        </div>
                    </li>
                    
                    <li class="form-line" id="jobs-jobitemstypeid-field">
                        <label class="form-label-left">
                            <JXTControl:ucLanguageLiteral ID="ltJobFieldJobItemType" runat="server" SetLanguageCode="LabelJobItemType" /> :<span class="form-required">*</span></label>
                        <div class="form-input">
                            <asp:DropDownList runat="server" ID="dataJobItemsTypeId" DataTextField="JobItemTypeDescription"
                                DataValueField="JobItemTypeID" CssClass="form-multiple-column" />
                            <asp:RequiredFieldValidator ID="ReqValJobItemsType" runat="server" ControlToValidate="dataJobItemsTypeId"
                                ErrorMessage="Required" InitialValue="0" />
                        </div>
                    </li>
                    
                    <hr />
                    
                    <li>
                        <div class="form-header-group">
                            <h2 class="form-header">
                             <JXTControl:ucLanguageLiteral ID="ltJobFieldJobAdOptions" runat="server" SetLanguageCode="LabelJobAdOptions" />
                              <%--  <asp:Label ID="lblJobCreateOptions" runat="server" Text="Job Ad Options"></asp:Label>--%>
                            </h2>
                        </div>
                    </li>
                    
                    <li class="form-line" id="jobs-qualificationsrecognised-field">
                        <label class="form-label-left">
                             <JXTControl:ucLanguageLiteral ID="ltJobFieldQualificationsRecognised" runat="server" SetLanguageCode="LabelQualificationsRecognised" /> :</label>
                        <div class="form-input">
                            <asp:CheckBox ID="dataQualificationsRecognised" runat="server" />
                        </div>
                    </li>
                    <li class="form-line" id="jobs-residentonly-field">
                        <label class="form-label-left">
                             <JXTControl:ucLanguageLiteral ID="ltJobFieldResidentOnly" runat="server" SetLanguageCode="LabelResidentOnly" /> :</label>
                        <div class="form-input">
                            <asp:CheckBox ID="dataResidentOnly" runat="server" />
                        </div>
                    </li>
                    
                    <hr />
                    
                    <li class="form-line" id="jobs-dateposted-field">
                        <label class="form-label-left">
                             <JXTControl:ucLanguageLiteral ID="ltJobFieldDatePosted" runat="server" SetLanguageCode="LabelDatePosted" /> :</label>
                        <div class="form-input">
                            <asp:Label ID="dataDatePosted" runat="server" />
                        </div>
                    </li>
                    
                    <li class="form-line" id="jobs-expirydate-field">
                        <label class="form-label-left">
                            <JXTControl:ucLanguageLiteral ID="ltJobFieldExpiryDate" runat="server" SetLanguageCode="LabelExpiryDate" /> :</label>
                        <div class="form-input">
                            <asp:Label ID="dataExpiryDate" runat="server" />
                        </div>
                    </li>
                    
                    <li class="form-line" id="jobs-lastmodified-field">
                        <label class="form-label-left">
                            <JXTControl:ucLanguageLiteral ID="ltJobFieldLastModified" runat="server" SetLanguageCode="LabelLastModified" /> :</label>
                        <div class="form-input">
                            <asp:Label ID="dataLastModified" runat="server" />
                        </div>
                    </li>
                    
                    <li class="form-line" id="jobs-expiried-field">
                        <label class="form-label-left">
                            <JXTControl:ucLanguageLiteral ID="ltJobFieldExpired" runat="server" SetLanguageCode="LabelExpired" /> :</label>
                        <div class="form-input">
                            <asp:CheckBox ID="chkJobExpired" runat="server" />
                        </div>
                    </li>
                    
                    <%--<asp:Panel ID="pnlAdvertiser" runat="server">
                        <li class="form-line" id="jobs-advertiserid-field">
                            <label class="form-label-left">
                                Advertiser:<span class="form-required">*</span></label>
                            <div class="form-input">
                                <asp:DropDownList runat="server" ID="dataAdvertiserId" DataTextField="CompanyName"
                                    DataValueField="AdvertiserID" CssClass="form-multiple-column" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required"
                                    InitialValue="0" ControlToValidate="dataAdvertiserId" />
                            </div>
                        </li>
                    </asp:Panel>--%>
                    
                    
                    <%--Hidden Fields--%>
                    <li class="form-line" id="jobs-billed-field" style="display:none;">
                        <label class="form-label-left">
                            <JXTControl:ucLanguageLiteral ID="ltJobFieldBilled" runat="server" SetLanguageCode="LabelBilled" /> :</label>
                        <div class="form-input">
                            <asp:CheckBox ID="dataBilled" runat="server" />
                        </div>
                    </li>
                    <li class="form-line" id="jobs-visible-field" style="display:none;">
                        <label class="form-label-left">
                            <JXTControl:ucLanguageLiteral ID="ltJobFieldVisible" runat="server" SetLanguageCode="LLabelVisible" /> :</label>
                        <div class="form-input">
                            <asp:CheckBox ID="dataVisible" runat="server" />
                        </div>
                    </li>                    
                    <li class="form-line" id="jobs-lastmodifiedbyadvertiseruserid-field" style="display:none;">
                        <label class="form-label-left">
                            <JXTControl:ucLanguageLiteral ID="ltJobFieldLastModifiedByAdvertiserUser" runat="server" SetLanguageCode="LabelLastModifiedByAdvertiserUser" /> :</label>
                        <div class="form-input">
                            <asp:Label ID="dataLastModifiedByAdvertiserUserId" runat="server" />
                        </div>
                    </li>
                    <li class="form-line" id="jobs-lastmodifiedbyadminuserid-field" style="display:none;">
                        <label class="form-label-left">
                            <JXTControl:ucLanguageLiteral ID="ltJobFieldLastModifiedByAdminUser" runat="server" SetLanguageCode="LabelLastModifiedByAdminUser" /> :</label>
                        <div class="form-input">
                            <asp:Label ID="dataLastModifiedByAdminUserId" runat="server" />
                        </div>
                    </li>
                    <%--End of Hidden Fields--%>
                    
                    <hr />
                    
                    <li class="form-line" id="reg-bottom-button">
                        <div class="form-input-wide">
                            <div class="form-buttons-wrapper">
                                <asp:Button ID="InsertButton" runat="server" CausesValidation="True" Text="Insert"
                                    CssClass="form-submit-button" OnClick="InsertButton_Click" />
                                <asp:Button ID="UpdateButton" runat="server" CausesValidation="True" Text="Update"
                                    CssClass="form-submit-button" OnClick="UpdateButton_Click" />
                                <asp:Button ID="CancelButton" runat="server" CausesValidation="False" Text="Cancel"
                                    CssClass="form-submit-button" OnClick="CancelButton_Click" />
                            </div>
                        </div>
                    </li>
                </ul>
            </asp:View>
        </asp:MultiView>
    </div>
    
</div>
