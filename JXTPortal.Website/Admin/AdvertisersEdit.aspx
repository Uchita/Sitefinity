<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master"
    AutoEventWireup="true" Inherits="AdvertisersEdit" Title="Advertisers Edit" CodeBehind="AdvertisersEdit.aspx.cs" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
    <script type="text/javascript">

        $(document).ready(function () {

            <%-- if ($("#ctl00$ContentPlaceHolder1$dataAdvertiserAccountStatusID option:selected").text() == "Approved") { --%>

                $("#panelTrialSettingsLi").css("display","none");
        });
    
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    Advertisers - Add/Edit <a href='http://support.jxt.com.au/solution/articles/116457-advertisers'
        class='jxt-help-page' title='click here for help on this page' target='_blank'>help
        on this page</a>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ajaxToolkit:ToolkitScriptManager ID="toolkitScriptManager" runat="server" CombineScripts="true"
        ScriptMode="Release">
    </ajaxToolkit:ToolkitScriptManager>
    <div class="form-all">
        <asp:MultiView ID="FormView1" runat="server" ActiveViewIndex="0">
            <asp:View ID="ViewAdvertiser" runat="server">
                <span class="form-message">
                    <asp:Literal ID="ltlMessage" runat="server" /></span>
                <ul class="form-section">
                    <li class="form-line" id="adv-accountsettings-field">
                        <label class="form-label-left">
                            <strong>General Settings</strong></label>
                        <div class="form-input">
                        </div>
                    </li>
                    <li class="form-line" id="adv-advertiser-field">
                        <label class="form-label-left">
                            Account Type:<span class="form-required">*</span></label>
                        <div class="form-input">
                            <data:EntityDropDownList runat="server" ID="dataAdvertiserAccountTypeId" DataSourceID="AdvertiserAccountTypeDataSource"
                                DataTextField="AdvertiserAccountTypeName" DataValueField="AdvertiserAccountTypeID"
                                AppendNullItem="true" Required="true" NullItemText=" Please Choose ..." CssClass="form-multiple-column" />
                            <data:AdvertiserAccountTypeDataSource ID="AdvertiserAccountTypeDataSource" runat="server"
                                SelectMethod="GetAll" />
                        </div>
                    </li>
                    <li class="form-line" id="adv-accountstatus-field">
                        <label class="form-label-left">
                            Account Status:<span class="form-required">*</span></label>
                        <div class="form-input">
                            <data:EntityDropDownList runat="server" ID="dataAdvertiserAccountStatusID" DataSourceID="AdvertiserAccountStatusDataSource"
                                DataTextField="AdvertiserAccountStatusName" DataValueField="AdvertiserAccountStatusID"
                                AppendNullItem="true" Required="true" NullItemText=" Please Choose ..." CssClass="form-multiple-column" />
                            <asp:PlaceHolder ID="phAdvertiserStatus" runat="server" Visible="false">
                                <asp:CheckBox ID="cbSendAdvertiserStatus" runat="server" Checked="false" AutoPostBack="false" />&nbsp;Send
                                status notification</asp:PlaceHolder>
                            <data:AdvertiserAccountStatusDataSource ID="AdvertiserAccountStatusDataSource" runat="server"
                                SelectMethod="GetAll" />
                            <div>
                                <i>
                                    <asp:Literal ID="ApprovedDate" runat="server" Visible="false"></asp:Literal></i>
                            </div>
                        </div>
                    </li>
                    <li class="form-line hide" id="panelTrialSettingsLi">
                        <label class="form-label-left">
                            Trial Settings:<span class="form-required">*</span></label>
                        <div class="form-line-column">
                            <div class="form-line">
                                <asp:CheckBox ID="cbTrialEnabled" runat="server" OnCheckedChanged="cbTrailSettings_CheckedChange"
                                    AutoPostBack="true" />
                                <asp:Label runat="server" AssociatedControlID="cbTrialEnabled">
                                    Enable Trial Restrictions</asp:Label>
                            </div>
                            <asp:Panel ID="panelTrialSettingsDates" runat="server" Visible="false">
                                <div class="form-line-column">
                                    <label>
                                        Start Date</label>
                                    <div>
                                        <asp:TextBox runat="server" ID="dataFreeTrialStartDate" MaxLength="10" Width="125px"></asp:TextBox>
                                        <asp:ImageButton ID="ibFreeTrialStartDate" runat="server" SkinID="CalendarImageButton"
                                            CausesValidation="False" />
                                        <ajaxToolkit:CalendarExtender ID="cal_dataFreeTrialStartDate" runat="server" Format="dd/MM/yyyy"
                                            TargetControlID="dataFreeTrialStartDate" PopupButtonID="ibFreeTrialStartDate">
                                        </ajaxToolkit:CalendarExtender>
                                        <div>
                                            <asp:CustomValidator ID="cvFreeTrialStartDate" runat="server" ControlToValidate="dataFreeTrialStartDate" OnServerValidate="cvFreeTrialStartDate_ServerValidate" />
                                        </div>
                                    </div>
                                </div>
                                <div class="form-line-column">
                                    <label>
                                        End Date</label>
                                    <div>
                                        <asp:TextBox runat="server" ID="dataFreeTrialEndDate" MaxLength="10" Width="125px"></asp:TextBox>
                                        <asp:ImageButton ID="ibFreeTrialEndDate" runat="server" SkinID="CalendarImageButton"
                                            CausesValidation="False" />
                                        <ajaxToolkit:CalendarExtender ID="cal_dataFreeTrialEndDate" runat="server" Format="dd/MM/yyyy"
                                            TargetControlID="dataFreeTrialEndDate" PopupButtonID="ibFreeTrialEndDate">
                                        </ajaxToolkit:CalendarExtender>
                                        <div>
                                                <asp:CustomValidator ID="cvFreeTrialEndDate" runat="server" ControlToValidate="dataFreeTrialEndDate" OnServerValidate="cvFreeTrialEndDate_ServerValidate" />
                                        </div>
                                    </div>
                                </div>
                                <div>
                                    <asp:CompareValidator ID="cvtxtStartDate" runat="server" ControlToCompare="dataFreeTrialStartDate"
                                        CultureInvariantValues="true" Display="Dynamic" EnableClientScript="true" ControlToValidate="dataFreeTrialEndDate"
                                        ErrorMessage="Start date must be earlier than finish date" Type="Date" SetFocusOnError="true"
                                        Operator="GreaterThanEqual" Text="Start date must be earlier than finish date"></asp:CompareValidator>
                                </div>
                            </asp:Panel>
                        </div>
                    </li>
                    <li class="form-line" id="adv-companyname-field">
                        <label class="form-label-left">
                            Company Name:<span class="form-required">*</span></label>
                        <div class="form-input">
                            <asp:TextBox runat="server" ID="dataCompanyName" TextMode="SingleLine" Width="250px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ReqVal_dataCompanyName" runat="server" Display="Dynamic"
                                ControlToValidate="dataCompanyName" ErrorMessage="Required"></asp:RequiredFieldValidator>
                        </div>
                    </li>
                    <li class="form-line" id="adv-businesstype-field">
                        <label class="form-label-left">
                            Business Type:<span class="form-required">*</span></label>
                        <div class="form-input">
                            <asp:DropDownList ID="dataBusinessTypeId" runat="server" class="form-dropdown" />
                        </div>
                    </li>
                    <li class="form-line" id="adv-businessno-field">
                        <label class="form-label-left">
                            Business Number</label>
                        <div class="form-input">
                            <asp:TextBox runat="server" ID="dataBusinessNumber" TextMode="SingleLine" Width="250px"></asp:TextBox>
                        </div>
                    </li>
                    <li class="form-line" id="adv-noofemployees-field">
                        <label class="form-label-left">
                            No Of Employees:</label>
                        <div class="form-input">
                            <asp:TextBox runat="server" ID="dataNoOfEmployees" MaxLength="10"></asp:TextBox>
                        </div>
                    </li>
                    <li class="form-line" id="adv-contactdetails-field">
                        <label class="form-label-left">
                            <strong>Contact Details</strong></label>
                        <div class="form-input">
                        </div>
                    </li>
                    <li class="form-line" id="adv-streetaddress1-field">
                        <label class="form-label-left">
                            Street Address1:</label>
                        <div class="form-input">
                            <asp:TextBox runat="server" ID="dataStreetAddress1" TextMode="MultiLine" Width="250px"
                                Rows="5"></asp:TextBox>
                        </div>
                    </li>
                    <li class="form-line" id="adv-streetaddress2-field">
                        <label class="form-label-left">
                            Street Address2:
                        </label>
                        <div class="form-input">
                            <asp:TextBox runat="server" ID="dataStreetAddress2" TextMode="MultiLine" Width="250px"
                                Rows="5"></asp:TextBox>
                        </div>
                    </li>
                    <li class="form-line" id="adv-postaladdress1-field">
                        <label class="form-label-left">
                            Postal Address1:</label>
                        <div class="form-input">
                            <asp:TextBox runat="server" ID="dataPostalAddress1" TextMode="MultiLine" Width="250px"
                                Rows="5"></asp:TextBox>
                        </div>
                    </li>
                    <li class="form-line" id="adv-postaladdress2-field">
                        <label class="form-label-left">
                            Postal Address2:</label>
                        <div class="form-input">
                            <asp:TextBox runat="server" ID="dataPostalAddress2" TextMode="MultiLine" Width="250px"
                                Rows="5"></asp:TextBox>
                        </div>
                    </li>
                    <li class="form-line" id="adv-webaddress-field">
                        <label class="form-label-left">
                            Web Address:</label>
                        <div class="form-input">
                            <asp:TextBox runat="server" ID="dataWebAddress" TextMode="SingleLine" Width="250px"></asp:TextBox>
                        </div>
                    </li>
                    <li class="form-line" id="adv-accountsettings-field">
                        <label class="form-label-left">
                            <strong>Account Settings</strong></label>
                        <div class="form-input">
                        </div>
                    </li>
                    <li class="form-line" id="adv-accountpayableemail-field">
                        <label class="form-label-left">
                            Accounts Payable Email:</label>
                        <div class="form-input">
                            <asp:TextBox runat="server" ID="dataAccountsPayableEmail" TextMode="SingleLine" Width="250px"></asp:TextBox>
                        </div>
                    </li>
                    <%--                    <li class="form-line" id="adv-firstapproveddate-field">
                        <label class="form-label-left">
                            Approved Date:</label>
                        <div class="form-input">
                            <asp:TextBox runat="server" ID="dataFirstApprovedDate" MaxLength="10"></asp:TextBox>
                            <asp:ImageButton ID="ibFirstApprovedDate" runat="server" SkinID="CalendarImageButton"
                                CausesValidation="False" />
                            <ajaxToolkit:CalendarExtender ID="cal_dataFirstApprovedDate" runat="server" Format="dd/MM/yyyy"
                                TargetControlID="dataFirstApprovedDate" PopupButtonID="ibFirstApprovedDate">
                            </ajaxToolkit:CalendarExtender>
                            <asp:CompareValidator ID="cvFirstApprovedDate" runat="server" ControlToValidate="dataFirstApprovedDate"
                                Type="Date" Operator="DataTypeCheck" ErrorMessage="Invalid Date. "></asp:CompareValidator>
                            <asp:RangeValidator ID="rvFirstApprovedDate" runat="server" ControlToValidate="dataFirstApprovedDate"
                                Type="Date" ErrorMessage='Date out of range.'></asp:RangeValidator>
                        </div>
                    </li>--%>
                    <li class="form-line" id="adv-profile-field">
                        <label class="form-label-left">
                            Profile:</label>
                        <div class="form-input">
                            <asp:TextBox runat="server" ID="dataProfile" TextMode="MultiLine" Width="250px" Rows="5"></asp:TextBox>
                        </div>
                    </li>
                    <li class="form-line" id="Li2">
                        <label class="form-label-left">
                            Video Link:</label>
                        <div class="form-input">
                            <asp:TextBox runat="server" ID="tbVideoLink" Width="250px"></asp:TextBox>
                        </div>
                    </li>
                    <asp:PlaceHolder ID="phIndustry" runat="server">
                        <li class="form-line" id="Li3">
                            <label class="form-label-left">
                                Industry:</label>
                            <div class="form-input">
                                <asp:DropDownList ID="ddlIndustry" runat="server" class="form-dropdown" />
                            </div>
                        </li>
                    </asp:PlaceHolder>
                    <li class="form-line" id="Li4">
                        <label class="form-label-left">
                            Nominated Company Role:</label>
                        <div class="form-input">
                            <asp:TextBox runat="server" ID="tbNominatedCompanyRole" Width="250px"></asp:TextBox>
                        </div>
                    </li>
                    <li class="form-line" id="Li5">
                        <label class="form-label-left">
                            Nominated Company First Name:</label>
                        <div class="form-input">
                            <asp:TextBox runat="server" ID="tbNominatedCompanyFirstName" Width="250px"></asp:TextBox>
                        </div>
                    </li>
                    <li class="form-line" id="Li6">
                        <label class="form-label-left">
                            Nominated Company Last Name:</label>
                        <div class="form-input">
                            <asp:TextBox runat="server" ID="tbNominatedCompanyLastName" Width="250px"></asp:TextBox>
                        </div>
                    </li>
                    <li class="form-line" id="Li7">
                        <label class="form-label-left">
                            Nominated Company Email Address:</label>
                        <div class="form-input">
                            <asp:TextBox runat="server" ID="tbNominatedCompanyEmailAddress" Width="250px"></asp:TextBox>
                        </div>
                    </li>
                    <li class="form-line" id="Li8">
                        <label class="form-label-left">
                            Nominated Company Phone:</label>
                        <div class="form-input">
                            <asp:TextBox runat="server" ID="tbNominatedCompanyPhone" Width="250px"></asp:TextBox>
                        </div>
                    </li>
                    <li class="form-line" id="Li9">
                        <label class="form-label-left">
                            Preferred Contact Method:</label>
                        <div class="form-input">
                            <asp:DropDownList ID="ddlPreferredContactMethod" runat="server" class="form-dropdown" />
                        </div>
                    </li>

                    <asp:PlaceHolder ID="phExternalID" runat="server" Visible="false">
                        <li class="form-line" id="Li3">
                            <label class="form-label-left">
                                External ID:</label>
                            <div class="form-input">
                                <asp:Literal ID="ltExternalID" runat="server" />
                            </div>
                        </li>
                    </asp:PlaceHolder>
                    <li class="form-line" id="adv-registereddate-field">
                        <label class="form-label-left">
                            Registered Date:</label>
                        <div class="form-input">
                            <asp:Label runat="server" ID="dataRegisteredDate"></asp:Label>
                        </div>
                    </li>
                    <li class="form-line" id="adv-lastmodified-field">
                        <label class="form-label-left">
                            Last Modified:</label>
                        <div class="form-input">
                            <asp:Label runat="server" ID="dataLastModified"></asp:Label>
                        </div>
                    </li>
                    <li class="form-line" id="adv-modifiedby-field">
                        <label class="form-label-left">
                            Modified By:</label>
                        <div class="form-input">
                            <asp:Label runat="server" ID="dataModifiedBy"></asp:Label>
                        </div>
                    </li>
                    <li class="form-line" id="adv-advertiserlogo-field">
                        <label class="form-label-left">
                            <strong>Upload Advertiser Logo</strong></label>
                        <div class="form-input">
                        </div>
                    </li>
                    <li class="form-line" id="adv-selectDocument-field">
                        <label class="form-label-left">
                            Select Document:</label>
                        <div class="form-input">
                            <asp:FileUpload ID="docInput" runat="server" class="form-textbox" />
                        </div>
                    </li>
                    <li class="form-line" id="adv-advertiserlogo-field">
                        <label id="lblNoLogo" runat="server">
                            You currently have no logo.</label>
                        <div class="form-input">
                            <asp:Image ID="imgLogo" runat="server"></asp:Image>
                            <asp:CustomValidator ID="cvalFileName" runat="server" ErrorMessage="Invalid file type. GIF, JPG and JPEG are the only valid images types allowed for upload."
                                Display="None"></asp:CustomValidator>
                            <asp:CustomValidator ID="cvalFile" runat="server" ErrorMessage="CustomValidator"
                                Display="None"></asp:CustomValidator>
                            <asp:CustomValidator ID="cvalFileType" runat="server" Display="None" ErrorMessage="The image uploaded is not a valid image format. Please check the file is either a GIF, JPG or JPEG format and try again."></asp:CustomValidator>
                        </div>
                    </li>
                    <li class="form-line" id="Li1">
                        <label id="lblRemoveLogo" runat="server" class="form-label-left">
                            Remove Logo:</label>
                        <div class="form-input">
                            <asp:CheckBox ID="chkRemoveLogo" runat="server" />
                        </div>
                    </li>
                    <li class="form-line" id="reg-bottom-button">
                        <div class="form-input-wide">
                            <div class="form-buttons-wrapper">
                                <asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert"
                                    Text="Insert" CssClass="form-submit-button" OnClick="InsertButton_Click" />
                                <asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update"
                                    Text="Update" CssClass="form-submit-button" OnClick="UpdateButton_Click" />
                                <asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
                                    Text="Cancel" CssClass="form-submit-button" OnClick="CancelButton_Click" />
                                <asp:HyperLink ID="hypAdvertiserUsers" runat="server" Visible="false">Advertiser Users List</asp:HyperLink>
                            </div>
                        </div>
                    </li>
                </ul>
            </asp:View>
        </asp:MultiView>
        <br />
        <br />
    </div>
</asp:Content>
