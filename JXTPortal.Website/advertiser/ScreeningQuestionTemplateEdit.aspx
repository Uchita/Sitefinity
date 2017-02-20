<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CustomMain.Master"
    AutoEventWireup="true" CodeBehind="ScreeningQuestionTemplateEdit.aspx.cs" Inherits="JXTPortal.Website.advertiser.ScreeningQuestionTemplateEdit" %>

<%@ Register Src="/usercontrols/navigation/ucAdvertiserAccountNavigation.ascx" TagName="ucAdvertiserAccountNavigation"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="robots" content="nofollow" />
    <link rel="stylesheet" href="//images.jxt.net.au/COMMON/newdash/lib/bootstrap.min.css" />
    <link rel="stylesheet" href="//images.jxt.net.au/COMMON/newdash/newDash.css" />
    <link rel="stylesheet" href="/styles/ScreeningQuestions/theme-style.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="endOfHead" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" ScriptMode="Release" />
    <div class="content-holder">
        <div id="jxt-wrapper-bootstrap">
            <div class="container-fluid">
                <div id="content-container" class="row">
                    <div class="container">
                        <div class="content-holder">
                            <JXTControl:ucSystemDynamicPage ID="ucSystemDynamicPage" runat="server" SetSystemPageCode="SystemPage_AdvertiserScreeningQuestionsEdit" />
                            <uc2:ucAdvertiserAccountNavigation ID="ucAdvertiserAccountNavigation1" runat="server" />
                            <span class="form-message">
                                <asp:Literal ID="ltlMessage" runat="server" />
                            </span>
                            <ul class="form-section">
                                <li class="form-line" id="admin-questiontitle">
                                    <asp:Label ID="lbTemplateName" runat="server" CssClass="form-label-left" AssociatedControlID="tbTemplateName">
                     <JXTControl:ucLanguageLiteral ID="ltTemplateName" runat="server" SetLanguageCode="LabelTemplateName" /><span class="form-required">*</span></asp:Label>
                                    <div class="form-input">
                                        <asp:TextBox ID="tbTemplateName" runat="server" MaxLength="256"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfTemplateName" runat="server" Display="Dynamic"
                                            ValidationGroup="Template" ErrorMessage="Required" ControlToValidate="tbTemplateName"
                                            SetFocusOnError="true" />
                                    </div>
                                </li>
                                <li class="form-line" id="Li1">
                                    <asp:Label ID="lbVisible" runat="server" CssClass="form-label-left" AssociatedControlID="cbVisible">
                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral1" runat="server" SetLanguageCode="LabelVisible" />:</asp:Label>
                                    <div class="form-input">
                                        <asp:CheckBox ID="cbVisible" runat="server" Checked="true" />
                                    </div>
                                </li>
                                <li class="form-line">
                                    <div class="form-input-wide">
                                        <div class="form-buttons-wrapper">
                                            <asp:Button ID="btnSubmit" runat="server" Text="Save" CssClass="mini-new-buttons" OnClick="btnSubmit_Click"
                                                ValidationGroup="Template" />
                                            <asp:Button ID="btnReturn" runat="server" Text="Return" CssClass="mini-new-buttons"
                                                OnClick="btnReturn_Click" CausesValidation="false" />
                                        </div>
                                    </div>
                                </li>
                            </ul>
                            <asp:PlaceHolder ID="phScreeningQuestions" runat="server" Visible="false">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:Repeater ID="rptScreeningQuestions" runat="server" OnItemDataBound="rptScreeningQuestions_ItemDataBound"
                                            OnItemCommand="rptScreeningQuestions_ItemCommand">
                                            <HeaderTemplate>
                                                   <h2><asp:Literal ID="ltScreeningQuestions" runat="server" Text="Screening Questions" /></h2>
                                                <table id="jobsTable" class="box-table table table-hover footable-loaded footable no-paging">
                                                    <thead>
                                                        <tr class="grid-header">
                                                            <th scope="col" width="50">
                                                                &nbsp;
                                                            </th>
                                                            <th scope="col" width="80">
                                                                 <JXTControl:ucLanguageLiteral ID="ltSequence" runat="server" SetLanguageCode="LabelSequence" />
                                                            </th>
                                                            <th scope="col" width="120">
                                                                <JXTControl:ucLanguageLiteral ID="ltQuestionType" runat="server" SetLanguageCode="LabelQuestionType" />
                                                            </th>
                                                            <th scope="col">
                                                                <JXTControl:ucLanguageLiteral ID="ltQuestionTitle" runat="server" SetLanguageCode="LabelQuestionTitle" />
                                                            </th>
                                                            <th scope="col" width="50">
                                                                <JXTControl:ucLanguageLiteral ID="ltMandatory" runat="server" SetLanguageCode="LabelMandatory" />
                                                            </th>
                                                            <th scope="col" width="50">
                                                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral2" runat="server" SetLanguageCode="LabelVisible" />
                                                            </th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr>
                                                    <td>
                                                        <asp:LinkButton ID="lbSelect" runat="server" CommandName="Select" Text="Select" CausesValidation="false" />
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="ltSequence" runat="server" />
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="ltQuestionType" runat="server" />
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="ltQuestionTitle" runat="server" />
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="ltMandatory" runat="server" />
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="ltVisible" runat="server" />
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                </tbody> </table>
                                            </FooterTemplate>
                                        </asp:Repeater>
                                        <h2>
                                            <asp:Literal ID="ltAddScreeningQuestions" runat="server" Text="Add Screening Questions" /></h2>
                                        <ul class="form-section">
                                            <li class="form-line" id="Li2">
                                                <asp:Label ID="lbTitle" runat="server" CssClass="form-label-left" AssociatedControlID="tbTitle">
                    Title:<span class="form-required">*</span></asp:Label>
                                                <div class="form-input">
                                                    <asp:HiddenField ID="hfScreeningQuestionId" runat="server" />
                                                    <asp:TextBox ID="tbTitle" runat="server" MaxLength="256"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfTitle" runat="server" Display="Dynamic" ErrorMessage="Required"
                                                        ControlToValidate="tbTitle" SetFocusOnError="true" ValidationGroup="Question" />
                                                </div>
                                            </li>
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <li class="form-line" id="admin-questiontype">
                                                        <asp:Label ID="lbType" runat="server" CssClass="form-label-left" AssociatedControlID="ddlType">
                    Type:<span class="form-required">*</span></asp:Label>
                                                        <div class="form-input">
                                                            <asp:DropDownList ID="ddlType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlType_SelectedIndexChanged">
                                                                
                                                            </asp:DropDownList>
                                                        </div>
                                                    </li>
                                                    <asp:PlaceHolder ID="phOptions" runat="server" Visible="false">
                                                        <li class="form-line" id="admin-questionoptions">
                                                            <asp:Label ID="lbOptions" runat="server" CssClass="form-label-left" AssociatedControlID="tbOptions">
                     <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral7" runat="server" SetLanguageCode="LabelOptions" /> (<JXTControl:ucLanguageLiteral ID="UcLanguageLiteral8" runat="server" SetLanguageCode="LabelSemicolonSeparated" />):<span class="form-required">*</span></asp:Label>
                                                            <div class="form-input">
                                                                <asp:TextBox ID="tbOptions" runat="server" MaxLength="500"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="rfOptions" runat="server" Display="Dynamic" ErrorMessage="Required"
                                                                    ControlToValidate="tbOptions" SetFocusOnError="true" ValidationGroup="Question" />
                                                            </div>
                                                        </li>
                                                    </asp:PlaceHolder>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                            <li class="form-line" id="admin-questionsequence">
                                                <asp:Label ID="lbSequence" runat="server" CssClass="form-label-left" AssociatedControlID="tbSequence">
                     <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral9" runat="server" SetLanguageCode="LabelSequence" />:<span class="form-required">*</span></asp:Label>
                                                <div class="form-input">
                                                    <asp:TextBox ID="tbSequence" runat="server" onkeypress="return event.charCode >= 48 && event.charCode <= 57"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfSequence" runat="server" Display="Dynamic" ErrorMessage="Required"
                                                        ControlToValidate="tbSequence" SetFocusOnError="true" ValidationGroup="Question" />
                                                    <asp:RangeValidator ID="rvSequence" runat="server" ErrorMessage="Please enter the valid sequence"
                                                        ValidationGroup="Question" ControlToValidate="tbSequence" MinimumValue="0" MaximumValue="99999"
                                                        Display="Dynamic"></asp:RangeValidator>
                                                </div>
                                            </li>
                                            <li class="form-line" id="admin-questionmandatory">
                                                <asp:Label ID="lbMandatory" runat="server" CssClass="form-label-left" AssociatedControlID="cbMandatory">
                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral10" runat="server" SetLanguageCode="LabelMandatory" />:</asp:Label>
                                                <div class="form-input">
                                                    <asp:CheckBox ID="cbMandatory" runat="server" />
                                                </div>
                                            </li>
                                            <li class="form-line" id="Li4">
                                                <asp:Label ID="Label1" runat="server" CssClass="form-label-left" AssociatedControlID="cbQuestionVisible">
                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral11" runat="server" SetLanguageCode="LabelVisible" />:</asp:Label>
                                                <div class="form-input">
                                                    <asp:CheckBox ID="cbQuestionVisible" runat="server" Checked="true" />
                                                </div>
                                            </li>
                                            <li class="form-line" id="Li3">
                                                <div class="form-input-wide">
                                                    <div class="form-buttons-wrapper">
                                                        <asp:Button ID="btnAdd" runat="server" Text="Add New" OnClick="btnAdd_Click"  CssClass="mini-new-buttons" ValidationGroup="Question">
                                                        </asp:Button>
                                                        <asp:Button ID="btnSave" runat="server" Text="Save" Visible="false" OnClick="btnSave_Click"  CssClass="mini-new-buttons"
                                                            ValidationGroup="Question"></asp:Button>
                                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" Visible="false" OnClick="btnCancel_Click"  CssClass="mini-new-buttons">
                                                        </asp:Button>
                                                    </div>
                                                </div>
                                            </li>
                                        </ul>
                                        <script type="text/javascript">

                                            $(function () {
                                                $('#jobsTable').footable();
                                            });
    
                                        </script>
                                        
                                        
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </asp:PlaceHolder>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script src="//images.jxt.net.au/COMMON/newdash/lib/footable.js" type="text/javascript"></script>
                                        <script src="//images.jxt.net.au/COMMON/newdash/lib/footable.sort.js" type="text/javascript"></script>
                                        <script src="//images.jxt.net.au/COMMON/newdash/lib/footable.filter.js" type="text/javascript"></script>
                                        <script src="//images.jxt.net.au/COMMON/newdash/lib/footable.paginate.js" type="text/javascript"></script>
                                        <script src="//images.jxt.net.au/COMMON/newdash/lib/footable.bookmarkable.js" type="text/javascript"></script>
                                        <!--[if lt IE 9]>
    <script src="//images.jxt.net.au/COMMON/newdash/lib/html5shiv.js" type="text/javascript"></script>
    <script src="//images.jxt.net.au/COMMON/newdash/lib/respond.min.js" type="text/javascript"></script>
    <![endif]-->
    <script src='//images.jxt.net.au/COMMON/newdash/lib/bootstrap.min.js'></script>
                                        <script src='//images.jxt.net.au/COMMON/newdash/newDash.js' type="text/javascript"></script>
</asp:Content>
