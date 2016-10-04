<%@ Page Language="C#" MasterPageFile="~/MasterPages/CustomMain.Master" AutoEventWireup="true"
    CodeBehind="PeopleSearch.aspx.cs" Inherits="JXTPortal.Website.PeopleSearch" %>

<%@ Register TagPrefix="uc1" Namespace="JXTPortal.Website.usercontrols.common" Assembly="JXTPortal.WebSite" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- PEOPLE SEARCH CODE STARTS HERE -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"
        integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u"
        crossorigin="anonymous">
    <link rel="stylesheet" href="https://f.jxt.com.au/FORMS/JXT-PeopleSearch/css/bootstrap-multiselect.css" />
    <link rel="stylesheet" href="https://f.jxt.com.au/FORMS/JXT-PeopleSearch/css/jquery-ui.structure.css" />
    <link rel="stylesheet" href="https://f.jxt.com.au/FORMS/JXT-PeopleSearch/css/jquery-ui.theme.css" />
    <link rel="stylesheet" href="https://f.jxt.com.au/FORMS/JXT-PeopleSearch/css/people-search.css" />
    <link rel="stylesheet" href="https://f.jxt.com.au/FORMS/JXT-PeopleSearch/css/people-search-color.css" />
    <link rel="stylesheet" href="https://f.jxt.com.au/FORMS/JXT-PeopleSearch/css/bootstrap-slider.css" />
    <script type="text/javascript">
        var dateformat = '<%=DateFormat %>';
    </script>
    <% if (this.Page.Master.FindControl("ltlMetaContent") != null && (!(((Literal)this.Page.Master.FindControl("ltlMetaContent")).Text.Contains("bootstrap.min.js")) && !(((Literal)this.Page.Master.FindControl("ltlMetaContent")).Text.Contains("bootstrap.js"))))
       { %>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <% } %>
    <script type="text/javascript" src="https://f.jxt.com.au/FORMS/JXT-PeopleSearch/js/bootstrap-multiselect.js"></script>
    <script type="text/javascript" src="https://f.jxt.com.au/FORMS/JXT-PeopleSearch/js/bootstrap-slider.js"></script>
    <script type="text/javascript" src="https://f.jxt.com.au/FORMS/JXT-PeopleSearch/js/jquery.twbsPagination.min.js"></script>
    <script src='https://f.jxt.com.au/FORMS/JXT-PeopleSearch/js/jquery-ui.js'></script>
    <script src='/scripts/member/people-search.js'></script>
    <!-- PEOPLE SEARCH CODE ENDS HERE -->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div id="content-container">
            <div id="Div1">
                <div class="content-holder">
                    <div class="jxt-search-content" id="peoplesearch">
                        <div class="row">
                            <div class="col-sm-4">
                                <div class="jxt-page-sidebar">
                                    <h3>
                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral1" runat="server" SetLanguageCode="LabelFilterResults" />
                                    </h3>
                                    <div class="row">
                                        <asp:Label ID="Label1" runat="server" CssClass="col-sm-12" AssociatedControlID="tbKeywords">
                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral2" runat="server" SetLanguageCode="LabelEnterKeywords" />
                                        </asp:Label>
                                        <div class="col-md-12">
                                            <asp:TextBox ID="tbKeywords" runat="server" CssClass="form-control search-filter-keyword"
                                                placeholder="LabelEnterKeywords" onkeydown="if (event.keyCode == 13) { $('#lbSearch').click(); eval($('#lbSearch').prop('href')); event.preventDefault(); return false; }" />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-12 col-xs-12 col-md-12">
                                            <label for="selectpicker">
                                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral3" runat="server" SetLanguageCode="LabelCountry" />
                                                |
                                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral4" runat="server" SetLanguageCode="LabelCity" />
                                                |
                                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral5" runat="server" SetLanguageCode="LabelRegion" />
                                            </label>
                                            <div id="divCountryCityRegion" class="form-input">
                                                <asp:Literal ID="ltCountryCityRegion" runat="server" />
                                                <asp:HiddenField ID="hfCountryCityRegion" runat="server" ClientIDMode="Static" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-12 col-xs-12 col-md-12">
                                            <label for="ddlProfessionsRoles">
                                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral6" runat="server" SetLanguageCode="LabelProfessions" />
                                                |
                                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral7" runat="server" SetLanguageCode="LabelRoles" />
                                                :</label>
                                            <div id="divProfessionsRoles" class="form-input">
                                                <asp:Literal ID="ltProfessionsRoles" runat="server" />
                                                <asp:HiddenField ID="hfProfessionsRoles" runat="server" ClientIDMode="Static" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-12 col-xs-12 col-md-12">
                                            <asp:Label ID="Label4" runat="server" AssociatedControlID="ddlWorkType">
                                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral8" runat="server" SetLanguageCode="LabelWorkType" />
                                                :</asp:Label>
                                            <div class="form-input">
                                                <asp:DropDownList ID="ddlWorkType" runat="server" CssClass="selectpicker-withoutsearch"
                                                    multiple="multiple" onchange="$('#hfWorkType').val($('#ddlWorkType').val())"
                                                    ClientIDMode="Static" />
                                                <asp:HiddenField ID="hfWorkType" runat="server" ClientIDMode="Static" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-12 col-xs-12 col-md-12">
                                            <asp:Label ID="Label5" runat="server" AssociatedControlID="salaryRange">
                                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral9" runat="server" SetLanguageCode="LabelSalaryTypeFull" />
                                                :</asp:Label>
                                            <div class="form-input">
                                                <div class="controls">
                                                    <asp:DropDownList ID="salaryRange" runat="server" CssClass="selectpicker-withoutsearch"
                                                        ClientIDMode="Static">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row range" style="display: none" id="1">
                                        <div class="col-md-12 col-sm-4 col-xs-12">
                                            <asp:Label ID="Label6" runat="server" AssociatedControlID="ex2">
                                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral10" runat="server" SetLanguageCode="LabelAnnualRange" />
                                            </asp:Label>
                                            <div class="form-input">
                                                <asp:TextBox ID="ex2" runat="server" CssClass="span2" data-slider-min="15000" data-slider-max="300000"
                                                    data-slider-step="1000" data-slider-value="[15000,300000]" ClientIDMode="Static" />
                                                <span class="rangespan">$15000 - $300000</span>
                                            </div>
                                            <asp:HiddenField ID="hfAnnualRange" runat="server" ClientIDMode="Static" Value="15000,300000" />
                                        </div>
                                    </div>
                                    <div class="row range" style="display: none" id="2">
                                        <div class="col-md-12 col-sm-4 col-xs-12">
                                            <asp:Label ID="Label7" runat="server" AssociatedControlID="ex3">
                                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral11" runat="server" SetLanguageCode="LabelHourlyRange" />
                                            </asp:Label>
                                            <div class="form-input">
                                                <asp:TextBox ID="ex3" runat="server" CssClass="span2" data-slider-min="15" data-slider-max="350"
                                                    data-slider-step="5" data-slider-value="[15,350]" ClientIDMode="Static" />
                                                <span class="rangespan">$15 - $350</span>
                                            </div>
                                            <asp:HiddenField ID="hfHourlyRange" runat="server" ClientIDMode="Static" Value="15,350" />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-12 col-xs-12 col-md-12">
                                            <asp:Label ID="Label8" runat="server" AssociatedControlID="ddlStatus">
                                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral12" runat="server" SetLanguageCode="LabelStatus" />
                                                :</asp:Label>
                                            <div class="form-input">
                                                <asp:DropDownList ID="ddlStatus" runat="server" CssClass="selectpicker-withoutsearch" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-12 col-xs-12 col-md-12">
                                            <div class="form-line">
                                                <asp:Label ID="Label9" runat="server" AssociatedControlID="availableDate">
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral13" runat="server" SetLanguageCode="LabelAvailableDateFrom" />
                                                    :</asp:Label>
                                                <div class="form-input">
                                                    <asp:TextBox ID="availableDate" runat="server" CssClass="form-control" placeholder="LabelAvailableDateFrom"
                                                        ClientIDMode="Static" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-12 col-xs-12 col-md-12">
                                            <asp:Label ID="Label10" runat="server" AssociatedControlID="ddlEligibleToWorkIn">
                                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral14" runat="server" SetLanguageCode="LabelEligibleToWorkIn" />
                                                :</asp:Label>
                                            <div class="form-input">
                                                <div class="controls multiselect-group">
                                                    <asp:DropDownList ID="ddlEligibleToWorkIn" runat="server" CssClass="selectpicker-withoutsearch"
                                                        multiple="multiple" onchange="$('#hfEligibleToWorkIn').val($('#ddlEligibleToWorkIn').val())"
                                                        ClientIDMode="Static" />
                                                    <asp:HiddenField ID="hfEligibleToWorkIn" runat="server" ClientIDMode="Static" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-xs-12 text-center">
                                        <asp:LinkButton ID="lbSearch" runat="server" CssClass="btn btn-primary btn-sm" Text="Search"
                                            OnClick="lbSearch_Click" OnClientClick="$('#hfAnnualRange').val($('#ex2').val());$('#hfHourlyRange').val($('#ex3').val()); " ClientIDMode="Static" />
                                        <a class="btn btn-primary btn-sm cancel-btn" href="#basicProfileEdit" data-toggle="collapse" onclick="PeopleSearchReset(); return false;"><JXTControl:ucLanguageLiteral ID="ltReset" runat="server" SetLanguageCode="LabelReset" /></a>
                                    </div>
                                    <div class="clearfix">
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-8 col-sm-8 page-content">
                                <div id="searchresult">
                                    <h3 class="bottom-line">
                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral15" runat="server" SetLanguageCode="LabelYourSearchReturned" />
                                        <span class="result-number">
                                            <asp:Literal ID="ltResultCount" runat="server" /></span>
                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral16" runat="server" SetLanguageCode="LabelCandidates" />
                                    </h3>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-sm-6 col-xs-12" style="margin-left: 0px">
                                                <div class="form-input">
                                                    <span class="custom-select">
                                                        <asp:DropDownList ID="ddlSort" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSort_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </span>
                                                </div>
                                            </div>
                                            <div class="col-sm-2 col-xs-12" style="margin-left: 0px">
                                                <div class="form-input">
                                                    <span class="custom-select">
                                                        <asp:DropDownList ID="ddlPageSize" runat="server" CssClass="form-control" AutoPostBack="True"
                                                            OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
                                                            <asp:ListItem Value="10" Selected="True">10</asp:ListItem>
                                                            <asp:ListItem Value="20">20</asp:ListItem>
                                                            <asp:ListItem Value="30">30</asp:ListItem>
                                                            <asp:ListItem Value="40">40</asp:ListItem>
                                                            <asp:ListItem Value="50">50</asp:ListItem>
                                                            <asp:ListItem Value="100">100</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </span>
                                                </div>
                                            </div>
                                            <asp:PlaceHolder ID="phPage" runat="server">
                                                <ul class="pagination-sm pull-right pagination-demo pagination">
                                                    <asp:Repeater ID="rptPage" runat="server" OnItemDataBound="rptPage_ItemDataBound" OnItemCommand="rptPage_ItemCommand">
                                                        <ItemTemplate>
                                                            <asp:Literal ID="ltHead" runat="server" />
                                                            <asp:LinkButton ID="lbPage" runat="server" CommandName="Page" />
                                                            <asp:Literal ID="ltTail" runat="server" />
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </ul>
                                            </asp:PlaceHolder>
                                        </div>
                                    </div>
                                    <asp:Repeater ID="rptPeopleSearch" runat="server" OnItemDataBound="rptPeopleSearch_ItemDataBound"
                                        OnItemCommand="rptPeopleSearch_ItemCommand">
                                        <ItemTemplate>
                                            <div class="jobs-list">
                                                <h4>
                                                    <span>
                                                        <asp:Literal ID="ltFirstName" runat="server" />
                                                        <asp:Literal ID="ltLastName" runat="server" /></span>
                                                    <ul class="job-btns">
                                                        <!--  <li><a href="#" class="btn btn-default"><i class="fa fa-plus"></i> </a></li> -->
                                                        <li>
                                                            <asp:Literal ID="ltMail" runat="server" />
                                                        </li>
                                                        <!-- <li><a href="#" class="btn btn-default"><i class="fa fa-user tip"></i> </a></li> -->
                                                        <!-- <li class="custom-fileUpload"><a href="#" class="btn btn-default">
    <span class="upload-lbl"></span><input type="file" id="attach-Resume1" class="form-control"></a></li> -->
                                                        <li><asp:LinkButton ID="lbDownload" runat="server" CommandName="Download" CssClass="btn btn-default"><span class="fa fa-download"
                                                            aria-hidden="true"></span></asp:LinkButton></li>
                                                    </ul>
                                                </h4>
                                                <asp:Literal ID="ltShortBio" runat="server" />
                                                <div class="clearfix">
                                                </div>
                                                <!-- <div class="btn-viewprofile pull-right"><a class="viewmore toggle" data-toggle="tooltip" data-placement="top" data-original-title="expand listing" >View Profile</a></div> -->
                                                <ul class="content-list col-md-6">
                                                    <asp:Literal ID="ltLocation" runat="server" />
                                                    <asp:Literal ID="ltWorkType" runat="server" />
                                                    <asp:Literal ID="ltProfession" runat="server" />
                                                    <asp:Literal ID="ltAvailableDate" runat="server" />
                                                </ul>
                                                <ul class="content-list col-md-6">
                                                    <asp:Literal ID="ltSalary" runat="server" />
                                                    <asp:Literal ID="ltStatus" runat="server" />
                                                    <asp:Literal ID="ltEligibleToWorkIn" runat="server" />
                                                </ul>
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                    <ul class="pagination-sm pull-right pagination-demo">
                                    </ul>
                                </div>
                            </div>
                            <!-- end .page-content -->
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- Company Enquiry Model Box -->
        <!-- script src='https://images.jxt.net.au/COMMON/cvbuilder/js/lib/bootstrap-multiselect.js'></script -->
    </div>
    <div id="content" style="display: none;">
        <div class="content-holder">
            <JXTControl:ucSystemDynamicPage ID="ucSystemDynamicPage" runat="server" SetSystemPageCode="SystemPage_PeopleSearch" />
            <h2>
                <asp:Literal ID="ltlException" runat="server" /></h2>
        </div>
    </div>
</asp:Content>
