<%@ Page Title="Job Board Settings" Language="C#" MasterPageFile="~/MasterPages/admin.Master"
    AutoEventWireup="true" CodeBehind="JobBoardSettings.aspx.cs" Inherits="JXTPortal.Website.Admin.JobBoardSettings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    Job Board Settings
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="scriptManager" runat="server" />
    <div class="form-all">
        <asp:UpdatePanel ID="updatePanelPaypalSettings" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <ul>
                    <li class="form-line" id="Li8">
                        <h3>
                            Paypal Settings</h3>
                        <span class="form-message">
                            <asp:Literal ID="ltPaypalMessage" runat="server" />
                        </span></li>
                    <li>
                        <h5>
                            Paypal Payflow <a href="https://www.paypal.com/au/webapps/mpp/payment-solutions">(payment
                                solutions)</a>&nbsp;<a href="http://www.paypalobjects.com/en_US/vhelp/paypalmanager_help/result_values_for_transaction_declines_or_errors.htm">(Response
                                    Codes)</a></h5>
                        <label class="help-label">
                            Money received with this method will be directly credited to your internet merchant
                            account (IMA) you hold with your financial institution.</label>
                    </li>
                    <li class="form-line" id="Li14">
                        <label class="form-label-left">
                            Paypal User:</label>
                        <div class="form-input">
                            <asp:TextBox runat="server" ID="tbPaypalUser" TextMode="SingleLine" ClientIDMode="Static"
                                Width="500px"></asp:TextBox>
                        </div>
                    </li>
                    <li class="form-line" id="Li15">
                        <label class="form-label-left">
                            Vendor:</label>
                        <div class="form-input">
                            <asp:TextBox runat="server" ID="tbVendor" TextMode="SingleLine" ClientIDMode="Static"
                                Width="500px"></asp:TextBox>
                        </div>
                    </li>
                    <li class="form-line" id="Li16">
                        <label class="form-label-left">
                            Partner:</label>
                        <div class="form-input">
                            <asp:TextBox runat="server" ID="tbPartner" TextMode="SingleLine" ClientIDMode="Static"
                                Width="500px"></asp:TextBox>
                        </div>
                    </li>
                    <li class="form-line" id="Li17">
                        <label class="form-label-left">
                            Paypal Password:</label>
                        <div class="form-input">
                            <asp:TextBox runat="server" ID="tbPaypalProPassword" TextMode="SingleLine" ClientIDMode="Static"
                                Width="500px"></asp:TextBox>
                        </div>
                    </li>
                    <li>
                        <h5>
                            Paypal Express Checkout / Paypal Website Payments Pro – Hosted Solution <a href="https://www.paypal.com/au/webapps/mpp/payment-solutions">
                                (payment solutions)</a></h5>
                        <label class="help-label">
                            Money received with this method will be credited into your Paypal account.</label>
                    </li>
                    <li class="form-line" id="Li9">
                        <label class="form-label-left">
                            Paypal Username:</label>
                        <div class="form-input">
                            <asp:TextBox runat="server" ID="tbPaypalUserName" TextMode="SingleLine" ClientIDMode="Static"
                                Width="500px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="tbPaypalUserName"
                                ValidationGroup="valGrpPaypal">&nbsp;Required</asp:RequiredFieldValidator>
                        </div>
                    </li>
                    <li class="form-line" id="Li10">
                        <label class="form-label-left">
                            Paypal Password:</label>
                        <div class="form-input">
                            <asp:TextBox runat="server" ID="tbPaypalPassword" TextMode="SingleLine" ClientIDMode="Static"
                                Width="500px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="tbPaypalPassword"
                                ValidationGroup="valGrpPaypal">&nbsp;Required</asp:RequiredFieldValidator>
                        </div>
                    </li>
                    <li class="form-line" id="Li11">
                        <label class="form-label-left">
                            Paypal Signature:</label>
                        <div class="form-input">
                            <asp:TextBox runat="server" ID="tbPaypalSignature" TextMode="SingleLine" ClientIDMode="Static"
                                Width="500px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="tbPaypalSignature"
                                ValidationGroup="valGrpPaypal">&nbsp;Required</asp:RequiredFieldValidator>
                        </div>
                    </li>
                    <li class="form-line">
                        <div class="form-input-wide">
                            <div class="form-buttons-wrapper">
                                <asp:Button ID="Button1" runat="server" Text="Update Paypal Settings" OnClick="btnPaypalSave_Click"
                                    ValidationGroup="valGrpPaypal" CssClass="jxtadminbutton" />
                            </div>
                        </div>
                    </li>
                </ul>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel ID="updatePanelJobBoardSettings" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <span class="form-message">
                    <asp:Literal ID="ltlMessage" runat="server" /></span>
                <asp:PlaceHolder ID="phJobBoardSettings" runat="server" Visible="false">
                    <ul>
                        <li class="form-line" id="Li5">
                            <h3>
                                Job Board Settings</h3>
                        </li>
                        <li class="form-line" id="adv-advertiser-field">
                            <label class="form-label-left">
                                GST:<span class="form-required">*</span></label>
                            <div class="form-input">
                                <asp:TextBox runat="server" ID="tbGST" TextMode="SingleLine" ClientIDMode="Static"
                                    Width="50px" MaxLength="10" PlaceHolder="eg. 0.10"></asp:TextBox>
                                (<span id="gstPercentDisplay"><asp:Literal ID="gstPercentDisplayInit" runat="server"
                                    ClientIDMode="Static" /></span>%)
                                <asp:RequiredFieldValidator ID="ReqVal_GST" runat="server" Display="Dynamic" ControlToValidate="tbGST"
                                    ErrorMessage="Required" SetFocusOnError="true">&nbsp; Required</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegExpVal_GST" ControlToValidate="tbGST" ValidationExpression="[\d\.]+"
                                    Display="Static" runat="server">&nbsp;Please enter numbers only</asp:RegularExpressionValidator>
                            </div>
                        </li>
                        <li class="form-line" id="Li1">
                            <label class="form-label-left">
                                GST Label:<span class="form-required">*</span></label>
                            <div class="form-input">
                                <asp:TextBox runat="server" ID="tbGSTLabel" TextMode="SingleLine" Width="100px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ReqVal_GSTLabel" runat="server" Display="Dynamic"
                                    ControlToValidate="tbGSTLabel" ErrorMessage="Required" SetFocusOnError="true">&nbsp; Required</asp:RequiredFieldValidator>
                            </div>
                        </li>
                        <li class="form-line" id="Li6">
                            <label class="form-label-left">
                                Currency:</label>
                            <div class="form-input">
                                <asp:DropDownList runat="server" ID="ddlCurrency" OnSelectedIndexChanged="ddlCurrency_Changed"
                                    AutoPostBack="true">
                                </asp:DropDownList>
                                <asp:Literal ID="currencyRoundingText" runat="server" Visible="false">
                                    This currency does not support decimals. Roundings will be automatically applied.
                                </asp:Literal>
                            </div>
                        </li>
                    </ul>
                </asp:PlaceHolder>
                <ul class="form-section">
                    <li class="form-line" id="gse-generalsettings-field">
                        <h5>
                        Job Type Settings</h3> </li>
                    <li>
                        <asp:UpdatePanel ID="updatePanel2" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <table>
                                    <thead>
                                        <th>
                                            Active
                                        </th>
                                        <th>
                                            Type
                                        </th>
                                        <th>
                                            Display Name
                                        </th>
                                        <th>
                                            Cost Per Type
                                        </th>
                                        <th>
                                            Jobs Count
                                        </th>
                                        <th>
                                            Sequence
                                        </th>
                                        <th>
                                            Last Modified Date
                                        </th>
                                        <th>
                                            Actions
                                        </th>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="rptJobItemType" runat="server" OnItemDataBound="rptJobItemType_ItemDataBound"
                                            OnItemCommand="rptJobItemType_ItemCommand">
                                            <HeaderTemplate>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Panel ID="plThisJobItemTypeRow" runat="server">
                                                    <tr>
                                                        <td>
                                                            <asp:CheckBox ID="cbSelect" runat="server" AutoPostBack="true" OnCheckedChanged="cbSelect_CheckedChanged" />
                                                        </td>
                                                        <td>
                                                            <asp:HiddenField ID="hfParentTypeID" runat="server" />
                                                            <asp:HiddenField ID="hfJobItemTypeID" runat="server" />
                                                            <asp:HiddenField ID="hfIsSingleJobType" runat="server" />
                                                            <asp:Literal ID="ltJobItemTypeName" runat="server" />
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbJobTypeNameOverride" runat="server" Height="22px" Width="300px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:Literal runat="server" ID="ltlCurrencyDisp"></asp:Literal>
                                                            <asp:TextBox runat="server" ID="tbTotalAmount" TextMode="SingleLine" Width="60px"
                                                                Height="22px" MaxLength="7"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfVal_tbTotalAmount" ControlToValidate="tbTotalAmount"
                                                                ValidationGroup="valGrpJobType" ErrorMessage="Required" runat="server" Display="Dynamic"></asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator ID="revTotalAmount" runat="server" ControlToValidate="tbTotalAmount"
                                                                ValidationGroup="valGrpJobType" ErrorMessage="Numbers and decimals only" ValidationExpression="[\.\d]+"
                                                                Display="Dynamic">  
                                                            </asp:RegularExpressionValidator>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbJobsCount" runat="server" Width="50px" Height="22px">                                                            
                                                            </asp:TextBox>
                                                            <asp:RangeValidator ID="tbJobsCountRangeValidator" ControlToValidate="tbJobsCount"
                                                                MinimumValue="2" MaximumValue="9999" Type="Integer" ValidationGroup="valGrpJobType"
                                                                ErrorMessage="Value must be > 1" runat="server" Display="Dynamic"></asp:RangeValidator>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbSequence" runat="server" Width="50px" Height="22px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:Literal ID="ltLastModified" runat="server" />
                                                        </td>
                                                        <td>
                                                            <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="Delete" Visible="false" />
                                                        </td>
                                                    </tr>
                                                </asp:Panel>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                            </FooterTemplate>
                                        </asp:Repeater>
                                        <asp:Panel ID="plAddJobPackForm" runat="server">
                                            <tr>
                                                <td colspan="9">
                                                    <strong>Add New Job Packs</strong>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:CheckBox ID="cbJobPackValid" runat="server" />
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlJobPackAddType" runat="server" DataTextField="JobTypeDisplayText"
                                                        DataValueField="JobItemTypeID" ClientIDMode="Static">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="tbJobPackAddName" runat="server" Height="22px" Width="300px" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic"
                                                        ValidationGroup="valGrpJobPacks" ControlToValidate="tbJobPackAddName" ErrorMessage="Required"
                                                        SetFocusOnError="true">&nbsp; Required</asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:Literal runat="server" ID="ltlCurrencyDisp2"></asp:Literal>
                                                    <asp:TextBox ID="tbJobPackAddPrice" runat="server" Width="60px" Height="22px" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                                                        ValidationGroup="valGrpJobPacks" ControlToValidate="tbJobPackAddPrice" ErrorMessage="Required"
                                                        SetFocusOnError="true">&nbsp; Required</asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="tbJobPackAddPrice"
                                                        ValidationGroup="valGrpJobPacks" ValidationExpression="[\d\.]+" Display="Dynamic"
                                                        runat="server">&nbsp;Please enter numbers only</asp:RegularExpressionValidator>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="tbJobPackAddQty" runat="server" Width="60px" Height="22px" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic"
                                                        ValidationGroup="valGrpJobPacks" ControlToValidate="tbJobPackAddQty" ErrorMessage="Required"
                                                        SetFocusOnError="true">&nbsp; Required</asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="tbJobPackAddQty"
                                                        ValidationGroup="valGrpJobPacks" ValidationExpression="\d+" Display="Dynamic"
                                                        runat="server">&nbsp;Please enter numbers only</asp:RegularExpressionValidator>
                                                    <asp:RangeValidator runat="server" MinimumValue="2" MaximumValue="10001" Type="Integer"
                                                        ValidationGroup="valGrpJobPacks" ControlToValidate="tbJobPackAddQty" Text="Value must be > 1"
                                                        Display="Dynamic" />
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="tbJobPackAddSequence" runat="server" Width="60px" Height="22px" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Display="Dynamic"
                                                        ValidationGroup="valGrpJobPacks" ControlToValidate="tbJobPackAddSequence" ErrorMessage="Required"
                                                        SetFocusOnError="true">&nbsp; Required</asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ControlToValidate="tbJobPackAddSequence"
                                                        ValidationGroup="valGrpJobPacks" ValidationExpression="\d+" Display="Dynamic"
                                                        runat="server">&nbsp;Please enter numbers only</asp:RegularExpressionValidator>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                    <asp:Button ID="btnAddJobPack" runat="server" Text="Add" OnClick="btnAddJobPack_Click"
                                                        ValidationGroup="valGrpJobPacks" CssClass="jxtadminbutton" />
                                                </td>
                                            </tr>
                                        </asp:Panel>
                                    </tbody>
                                </table>
                                <asp:PlaceHolder ID="phPremium" runat="server" Visible="false">
                                    <ul class="form-section">
                                        <li class="form-line" id="Li7">
                                            <h5>
                                                Premium Job Type Settings:</h5>
                                        </li>
                                        <li class="form-line" id="Li3">
                                            <label class="form-label-left">
                                                Amount of Premium Jobs Shown Above Results:</label>
                                            <div class="form-input">
                                                <asp:DropDownList ID="ddlNoOfPremiumJobs" runat="server">
                                                    <asp:ListItem Value="1">1</asp:ListItem>
                                                    <asp:ListItem Value="2">2</asp:ListItem>
                                                    <asp:ListItem Value="3">3</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </li>
                                        <li class="form-line" id="Li2">
                                            <label class="form-label-left">
                                                Premium Active Days:<span class="form-required">*</span></label>
                                            <div class="form-input">
                                                <asp:TextBox runat="server" ID="tbPremiumActiveDays" TextMode="SingleLine" Width="50px"
                                                    MaxLength="7"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="ReqVal_ActiveDays" runat="server" Display="Dynamic"
                                                    ValidationGroup="valGrpJobType" ControlToValidate="tbPremiumActiveDays" SetFocusOnError="true">&nbsp;Required</asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegExpVal_ActiveDays" ControlToValidate="tbPremiumActiveDays"
                                                    ValidationGroup="valGrpJobType" ValidationExpression="\d+" Display="Dynamic"
                                                    runat="server">&nbsp;Please enter numbers only</asp:RegularExpressionValidator>
                                                <asp:RangeValidator ID="RangeVal_ActiveDays" runat="server" ControlToValidate="tbPremiumActiveDays"
                                                    ValidationGroup="valGrpJobType" Display="Dynamic" MinimumValue="1" MaximumValue="999"
                                                    Enabled="false">&nbsp;Days must be greater than 0</asp:RangeValidator>
                                            </div>
                                        </li>
                                        <li class="form-line" id="Li4">
                                            <label class="form-label-left">
                                                Display Premium Jobs On Result:</label>
                                            <div class="form-input">
                                                <asp:CheckBox ID="cbDisplayPremiumJobs" runat="server" />
                                            </div>
                                        </li>
                                    </ul>
                                </asp:PlaceHolder>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </li>
                    <asp:PlaceHolder ID="phInvoice" runat="server">
                    <ul>
                        <li class="form-line" id="Li12">
                            <h3>
                                Invoice Settings</h3>
                        </li>
                        <li class="form-line" id="Li13">
                            <label class="form-label-left">
                                Invoice Site Info:<span class="form-required">*</span></label>
                            <div class="form-input">
                                <asp:TextBox runat="server" ID="tbInvoiceSiteInfo" TextMode="MultiLine" ClientIDMode="Static"
                                    Width="500px" Rows="6"></asp:TextBox>
                            </div>
                        </li>
                        <li class="form-line" id="Li18">
                            <label class="form-label-left">
                                Invoice Site Footer:<span class="form-required">*</span></label>
                            <div class="form-input">
                                <asp:TextBox runat="server" ID="tbInvoiceSiteFooter" TextMode="MultiLine" ClientIDMode="Static"
                                    Width="500px" Rows="6"></asp:TextBox>
                            </div>
                        </li>
                    </ul>
                    </asp:PlaceHolder>
                    <li class="form-line">
                        <div class="form-input-wide">
                            <div class="form-buttons-wrapper">
                                <asp:Button ID="btnEditSave" runat="server" Text="Update Job Board Settings" OnClick="btnEditSave_Click"
                                    ValidationGroup="valGrpJobType" CssClass="jxtadminbutton" />
                                <asp:Button ID="btnReturn" runat="server" Text="Return" OnClick="btnReturn_Click"
                                    CssClass="jxtadminbutton" CausesValidation="false" />
                            </div>
                        </div>
                    </li>
                </ul>
                <br />
                <br />
            </ContentTemplate>
        </asp:UpdatePanel>
        
    </div>
    <script type="text/javascript">

        $(document).ready(function () {

            $("#tbGST").on("keyup", function () {

                var percent = $("#tbGST").val().length == 0 ? 0 : ($("#tbGST").val() * 100);

                $("#gstPercentDisplay").html(percent.toFixed(2));
            });


            //            $("#ddlJobPackAddType").on("change", function () {
            //                alert("33");
            //                //value == 3 means premium job type
            //                if ($("#ddlJobPackAddType").val() == 3) {
            //                    $("#tbJobPackAddActiveDays").css("display", "block");
            //                }
            //                else {
            //                    $("#tbJobPackAddActiveDays").css("display", "none").val(0);
            //                }

            //            });

            //init
            $("#ddlJobPackAddType").change();

        });
    
    </script>
</asp:Content>
