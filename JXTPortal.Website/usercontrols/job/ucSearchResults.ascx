<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucSearchResults.ascx.cs"
    Inherits="JXTPortal.Website.usercontrols.job.ucSearchResults" %>
<%@ Register Src="~/usercontrols/job/ucSearchResultsGoogleMap.ascx" TagName="ucSearchResultsGoogleMap"
    TagPrefix="uc1" %>
<div id="content">
    <div class="content-holder">
        <asp:Literal ID="ltlCampaign" runat="server" EnableViewState="false" />
        <div id="jobsearch-top">
            <div class="num-results">
                <JXTControl:ucLanguageLiteral ID="ltjobSearchResults" runat="server" SetLanguageCode="LabelSearchResult" />
                <span class="searchresult-number">
                    <asp:Literal ID="ltlResultCount" runat="server" /></span>
                <JXTControl:ucLanguageLiteral ID="ltjobSearchPosition" runat="server" SetLanguageCode="LabelPositions" />
                <span class="boardy-search-bar">|</span> <a href="/advancedsearch.aspx" class="boardy-back-to-search">
                    <JXTControl:ucLanguageLiteral ID="ltjobSearchNew" runat="server" SetLanguageCode="ButtonNewSearch" />
                </a>
            </div>
            <div class="search-options">
            </div>
        </div>
        <div class="job-navbtns">
            <div class="button rss-feed-button">
                <asp:HyperLink ID="hypLinkRSSFeed" runat="server" role="button"></asp:HyperLink></div>
            <%--<div class="button save-selected-button">
                <a href="#" onclick="SaveSelectedJobs();">
                    <JXTControl:ucLanguageLiteral ID="ltjobSearchSaveSelected" runat="server" SetLanguageCode="ButtonSaveSelected" />
                </a>
            </div>
            <div class="button new-search-button">
                <a href="/advancedsearch.aspx">
                    <JXTControl:ucLanguageLiteral ID="ltjobSearchNew" runat="server" SetLanguageCode="ButtonNewSearch" />
                </a>
            </div>--%>
            <div class="button favourite-search-button">
                <a href="#boardy-popbox-fav" name="boardy-modal-fav" data-ignore="true" role="button">
                    <JXTControl:ucLanguageLiteral ID="ucLiteral1" runat="server" SetLanguageCode="LabelFavouriteThisSearch" />
                </a>
            </div>
            <div id="boardy-popup-fav">
                <div id="boardy-popbox-fav" class="window-fav">
                    <a href="#" class="boardy-popclose-fav" data-ignore="true"></a>
                    <div class="boardy-styleBox" id="boardy-favsearch-cont">
                        <div class="boardy-poptitle">
                            <h2>
                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral1" runat="server" SetLanguageCode="LabelFavouriteThisSearch" />
                            </h2>
                        </div>
                        <div class="boardy-popcontent">
                            <div class='boardy-favsearch-holder'>
                                <div id="divFavSearchSave" class="boardy-favsearch-save">
                                    <div class='boardy-favsearch-form'>
                                        <input type='text' id='tbFavSearchName' placeholder='Name this search' class='boardy-favsearch-input' />
                                        <a href='#' class='boardy-favsearch-btn' onclick="SaveFavSearch();" data-ignore="true" role="button">
                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral9" runat="server" SetLanguageCode="LabelSave" />
                                        </a>
                                    </div>
                                    <p>
                                        <small>
                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral2" runat="server" SetLanguageCode="LabelEGAccountingJobInSydney" />
                                        </small>
                                    </p>
                                    <h4>
                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral3" runat="server" SetLanguageCode="LabelSearchDetails" />
                                    </h4>
                                    <p id='pFavSearchDetail' class='fav-search-detail'>
                                    </p>
                                    <p id='pFavSearchAll' class='fav-search-all'>
                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral4" runat="server" SetLanguageCode="LabelSearchedAllJobs" />
                                    </p>
                                </div>
                                <div id="divFavSearchSaved" class="boardy-favsearch-saved-succ">
                                    <h4>
                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral5" runat="server" SetLanguageCode="LabelSuccessfullySavedYourSearch" />
                                        <a href="#" class="boardy-popclose-favhere" data-ignore="true">
                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral22" runat="server" SetLanguageCode="LabelClick" />
                                            &nbsp;<JXTControl:ucLanguageLiteral ID="UcLanguageLiteral23" runat="server" SetLanguageCode="LabelHere" />
                                        </a>&nbsp;<JXTControl:ucLanguageLiteral ID="UcLanguageLiteral24" runat="server" SetLanguageCode="LabelGoBackToSearchResults" />
                                    </h4>
                                </div>
                                <div id="divFavSearchNotSaved" class="boardy-favsearch-saved-error">
                                    <h4>
                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral20" runat="server" SetLanguageCode="LabelFailedToSavedYourSearch" />
                                    </h4>
                                </div>
                                <div id="divFavSearchNameMissing" class="boardy-favsearch-saved-error">
                                    <h4>
                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral6" runat="server" SetLanguageCode="LabelFavouriteSearchNameIsMissing" />
                                    </h4>
                                </div>
                                <hr />
                                <p>
                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral7" runat="server" SetLanguageCode="LabelPleaseSeeThe" />
                                    <a href="/member/myjobalerts.aspx">
                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral8" runat="server" SetLanguageCode="LabelMyFavouriteSearches" />
                                    </a>
                                </p>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- Mask to cover the whole screen -->
                <div id="boardy-popshadow-fav">
                    <!-- -->
                </div>
            </div>
            <div class="button create-alert-button">
                <a href="#boardy-popbox-alert" name="boardy-modal-alert" data-ignore="true">
                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral10" runat="server" SetLanguageCode="LabelCreateAsAlert" />
                </a>
            </div>
            <div id="boardy-popup-alert">
                <div id="boardy-popbox-alert" class="window-alert">
                    <a href="#" class="boardy-popclose-alert" data-ignore="true" role="button"></a>
                    <div class="boardy-styleBox" id="boardy-createalert-cont">
                        <div class="boardy-poptitle">
                            <h2>
                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral11" runat="server" SetLanguageCode="LabelCreateAsAlert" />
                            </h2>
                        </div>
                        <div class="boardy-popcontent">
                            <div class='boardy-createalert-holder'>
                                <div id="divCreateAlertSave" class="boardy-createalert-save">
                                    <div class='boardy-createalert-form'>
                                        <input type='text' id='tbCreateAlertName' placeholder='Name this alert' class='boardy-createalert-input' />
                                        <a href='#' class='boardy-createalert-btn' onclick="CreateJobAlert();" data-ignore="true">
                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral15" runat="server" SetLanguageCode="LabelSave" />
                                        </a>
                                    </div>
                                    <p>
                                        <small>
                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral12" runat="server" SetLanguageCode="LabelEGAccountingJobInSydney" />
                                        </small>
                                    </p>
                                    <h4>
                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral13" runat="server" SetLanguageCode="LabelSearchDetails" />
                                    </h4>
                                    <p id='pCreateAlertDetail' class='create-alert-detail'>
                                    </p>
                                    <p id='pCreateAlertAll' class='create-alert-all'>
                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral14" runat="server" SetLanguageCode="LabelSearchedAllJobs" />
                                    </p>
                                </div>
                                <div id="divCreateAlertSaved" class="boardy-created-alert-succ">
                                    <h4>
                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral16" runat="server" SetLanguageCode="LabelSuccessfullyCreatedYouJobAlert" />
                                        <a href="#" class="boardy-popclose-alerthere" data-ignore="true">
                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral25" runat="server" SetLanguageCode="LabelClick" />
                                            &nbsp;<JXTControl:ucLanguageLiteral ID="UcLanguageLiteral26" runat="server" SetLanguageCode="LabelHere" />
                                        </a>&nbsp;<JXTControl:ucLanguageLiteral ID="UcLanguageLiteral27" runat="server" SetLanguageCode="LabelGoBackToSearchResults" />
                                    </h4>
                                </div>
                                <div id="divCreateAlertNotSaved" class="boardy-created-alert-error">
                                    <h4>
                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral21" runat="server" SetLanguageCode="LabelFailedToCreatedYouJobAlert" />
                                    </h4>
                                </div>
                                <div id="divCreateAlertNameMissing" class="boardy-favsearch-saved-error">
                                    <h4>
                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral17" runat="server" SetLanguageCode="LabelCreateJobAlertNameIsMissing" />
                                    </h4>
                                </div>
                                <hr />
                                <p>
                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral18" runat="server" SetLanguageCode="LabelPleaseSeeThe" />
                                    <a href="/member/myjobalerts.aspx">
                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral19" runat="server" SetLanguageCode="LabelMyJobAlert_s" />
                                    </a>
                                </p>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- Mask to cover the whole screen -->
                <div id="boardy-popshadow-alert">
                    <!-- -->
                </div>
            </div>
            <div class="button sorting-button">
                <asp:DropDownList ID="ddlSorting" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSorting_SelectedIndexChanged">
                </asp:DropDownList>
                <a href="javascript:void(0);" data-ignore="true">
                    <asp:Literal ID="ltlSortSelected" runat="server"></asp:Literal></a>
            </div>
            <asp:PlaceHolder runat="server" ID="phMapSwitchOptions" Visible="false">
                <div class="switch_options">
                    <div class="switch_enable defaultListingView selected" title="Listing view" data-type="list" onclick="ToggleSearchView(this);">
                        <i class="fa fa-bars"></i>
                    </div>
                    <div class="switch_disable MapListingView " title="Map View" data-type="map" onclick="ToggleSearchView(this);">
                        <i id="toggleSearchMapBtn" class="fa fa-map-marker"></i>
                    </div>
                    <input type="hidden" class="switch_val" value="0">
                </div>
            </asp:PlaceHolder>
        </div>
        <%--<asp:HiddenField ID="hfCurrency" runat="server" ClientIDMode="Static" />--%>
        <div id="resultsList">
            <asp:Repeater ID="rptPremiumJobResults" runat="server" OnItemDataBound="rptPremiumJobResults_ItemDataBound"
                EnableViewState="false">
                <ItemTemplate>
                    <asp:Literal ID="ltlJob" runat="server" />
                </ItemTemplate>
                <FooterTemplate>
                    <hr />
                </FooterTemplate>
            </asp:Repeater>
            <%-- REMOVE hr --%>
            <asp:Repeater ID="rptJobResults" runat="server" OnItemDataBound="rptJobResults_ItemDataBound">
                <ItemTemplate>
                    <asp:Literal ID="ltlJob" runat="server" />
                </ItemTemplate>
            </asp:Repeater>
            <asp:Repeater ID="rptPaging" runat="server" OnItemDataBound="rptPaging_ItemDataBound"
                OnItemCommand="rptPaging_ItemCommand">
                <HeaderTemplate>
                    <div id="tnt_pagination">
                        <asp:LinkButton ID="lbFirst" runat="server" CommandName="paging" Text="<<" CssClass="pagination_previous" />
                        <asp:LinkButton ID="lnkButtonPrevious" runat="server" CommandName="paging" CssClass="search-previous-button" />
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:LinkButton ID="lnkButtonPaging" runat="server" CommandName="paging" /></ItemTemplate>
                <FooterTemplate>
                    <asp:LinkButton ID="lnkButtonNext" runat="server" CommandName="paging" CssClass="search-next-button" />
                    <asp:LinkButton ID="lbLast" runat="server" CommandName="paging" Text=">>" CssClass="pagination_next" />
                    </div>
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <asp:PlaceHolder runat="server" ID="phMapResultsMap" Visible="false">
            <div id="resultsMap" class="BoardyMapContainer">
                <uc1:ucSearchResultsGoogleMap ID="ucSearchResultsGoogleMap1" runat="server" />
            </div>
        </asp:PlaceHolder>
    </div>
</div>
<script type="text/javascript">
    var processed = true;
    function SaveFavSearch() {
        if ($('#tbFavSearchName').val() == '') {
            $('#divFavSearchNameMissing').css('display', 'initial');
        }
        else {
            if (processed) {
                processed = false;
                // Saving Favourite Search
                $.post("<%=sPrefix %>/job/ajaxcalls/ajaxMethods.asmx/SaveJobAlert", { 'CreateAlertName': $('#tbFavSearchName').val(), 'SearchString': $('#hfSearchFor').val(), 'isJobAlert': 'false' })
              .done(function (data) {
                  var msg = $(data).find('string:first').text();
                  if (msg == "Success") {
                      $('#divFavSearchSave').css('display', 'none');
                      $('#divFavSearchNameMissing').css('display', 'none');
                      $('#divFavSearchNotSaved').css('display', 'none');
                      $('#divFavSearchSaved').css('display', 'initial');
                  }
                  else if (msg == "Error") {
                      $('#divFavSearchSave').css('display', 'initial');
                      $('#divFavSearchNameMissing').css('display', 'none');
                      $('#divFavSearchNotSaved').css('display', 'initial');
                      $('#divFavSearchSaved').css('display', 'none');
                  }
                  else {
                      location.href = '/member/login.aspx?returnurl=' + encodeURIComponent('/member/createjobalert.aspx?isfav=1&retainsearch=1');
                  }

                  processed = true;
              });
            }

        }
    }

    function CreateJobAlert() {
        if ($('#tbCreateAlertName').val() == '') {
            $('#divCreateAlertNameMissing').css('display', 'initial');
        }
        else {
            if (processed) {
                processed = false;
                // Saving Job Alert
                $.post("<%=sPrefix %>/job/ajaxcalls/ajaxMethods.asmx/SaveJobAlert", { 'CreateAlertName': $('#tbCreateAlertName').val(), 'SearchString': $('#hfSearchFor').val(), 'isJobAlert': 'true' })
              .done(function (data) {
                  var msg = $(data).find('string:first').text();
                  if (msg == "Success") {
                      $('#divCreateAlertSave').css('display', 'none');
                      $('#divCreateAlertNameMissing').css('display', 'none');
                      $('#divCreateAlertNotSaved').css('display', 'none');
                      $('#divCreateAlertSaved').css('display', 'initial');
                  }
                  else if (msg == "Error") {
                      $('#divCreateAlertSave').css('display', 'initial');
                      $('#divCreateAlertNameMissing').css('display', 'none');
                      $('#divCreateAlertNotSaved').css('display', 'initial');
                      $('#divCreateAlertSaved').css('display', 'none');
                  }
                  else {
                      location.href = '/member/login.aspx?returnurl=' + encodeURIComponent('/member/createjobalert.aspx?retainsearch=1');
                  }

                  processed = true;
              });
            }
        }
    }

    function ToggleSearchView(target) {

        $(".defaultListingView, .MapListingView").removeClass("selected");

        var exdate = new Date();
        exdate.setHours(exdate.getHours() + 1); //set 1 hour

        if ($(target).data("type") == "map") {

            //store to cookie
            document.cookie = "SearchResultType=map; expires=" + exdate.toUTCString();

            $(".MapListingView").addClass("selected");
            $("#resultsMap").show();
            $("#resultsList").hide();

            if (parseInt($("#searchResultsMapCount").html()) > 0)
                $(".map-address").show();
            else
                $(".map-address").hide();

            if (map == null)
                initializeGoogleMap();
        }
        else if ($(target).data("type") == "list") {

            //store to cookie
            document.cookie = "SearchResultType=list; expires=" + exdate.toUTCString();

            $(".defaultListingView").addClass("selected");
            $("#resultsMap, .map-address").hide();
            $("#resultsList").show();
        }
    }

    function getCookie(cname) {
        var name = cname + "=";
        var ca = document.cookie.split(';');
        for (var i = 0; i < ca.length; i++) {
            var c = ca[i];
            while (c.charAt(0) == ' ') c = c.substring(1);
            if (c.indexOf(name) == 0) return c.substring(name.length, c.length);
        }
        return "";
    }

</script>
<script type="text/javascript">
    /* Start of Modal popup for Search Results - Favourite Search / Create as Alert */

    $(document).ready(function () {

        //by default, use JS to hide the map filters
        $(".map-address").hide();

        //check last search type: list/map
        var lastSearchType = getCookie("SearchResultType");
        if (lastSearchType == "map")
            $("#toggleSearchMapBtn").click();

        $("#mapSearchAddress").on("keyup", function () {
            if ($("#mapSearchAddress").val().length > 0) {
                $("#mapRadiusSearchBtn, #mapRadiusSearchClearBtn").removeAttr("disabled");

            }
            else {
                $("#mapRadiusSearchBtn, #mapRadiusSearchClearBtn").attr("disabled", "disabled");
            }
        });


        /*FAV SEARCH ************************************************************/
        $('a[name=boardy-modal-fav]').click(function (e) {
            //Cancel the link behavior
            e.preventDefault();


            //Get the A tag
            var id = $(this).attr('href');

            //Get the screen height and width
            var maskHeight = $(document).height();
            var maskWidth = $(window).width();

            //Set heigth and width to mask to fill up the whole screen
            $('#boardy-popshadow-fav').css({ 'width': maskWidth, 'height': maskHeight });

            //transition effect		
            $('#boardy-popshadow-fav').fadeIn(500);
            $('#boardy-popshadow-fav').fadeTo("fast", 0.7);

            //Get the window height and width
            var winH = $(window).height();
            var winW = $(window).width();

            //Set the popup window to center
            //$(id).css('top',  winH/2-$(id).height()/2);
            $(id).css('left', winW / 2 - $(id).width() / 2);

            //Initialize panel
            $('#divFavSearchSave').css('display', 'initial');
            $('#tbFavSearchName').val('');
            $('#pFavSearchDetail').css('display', 'none');
            $('#pFavSearchAll').css('display', 'none');
            $('#divFavSearchSaved').css('display', 'none');
            $('#divFavSearchNotSaved').css('display', 'none');
            $('#divFavSearchNameMissing').css('display', 'none');
            var searchFor = $('#hfSearchFor').val();

            if (searchFor == '') {
                $('#pFavSearchAll').css('display', 'initial');
            }
            else {
                $('#pFavSearchDetail').css('display', 'initial');
                var currency = $('#hfCurrency').val();
                // split the hidden field 
                var arr = searchFor.split('|');
                var i, seg, text = '';
                for (i = 0; i < arr.length; i++) {
                    if (arr[i] != '') {
                        seg = arr[i].split('^');

                        text += seg[2] + "<br />";

                    }
                }
                $('#pFavSearchDetail').html(text);
            }

            //transition effect
            $(id).fadeIn(500);
            $('#tbFavSearchName').focus();
            $('#tbFavSearchName').bind('keypress', function (e) {
                if (e.keyCode == 13) {
                    SaveFavSearch();
                }
            });
        });


        //if boardy-popclose button is clicked
        $('.window-fav .boardy-popclose-fav').click(function (e) {
            //Cancel the link behavior
            e.preventDefault();

            $('#boardy-popshadow-fav').hide();
            $('.window-fav').hide();
        });

        $('.window-fav .boardy-popclose-favhere').click(function (e) {
            //Cancel the link behavior
            e.preventDefault();

            $('#boardy-popshadow-fav').hide();
            $('.window-fav').hide();
        });

        //if mask is clicked
        $('#boardy-popshadow-fav').click(function () {
            $(this).hide();
            $('.window-fav').hide();
        });

        $(window).resize(function () {

            var box = $('#boardy-popup-fav .window-fav');

            //Get the screen height and width
            var maskHeight = $(document).height();
            var maskWidth = $(window).width();

            //Set height and width to mask to fill up the whole screen
            $('#boardy-popshadow-fav').css({ 'width': maskWidth, 'height': maskHeight });

            //Get the window height and width
            var winH = $(window).height();
            var winW = $(window).width();

            //Set the popup window to center
            //box.css('top',  winH/2 - box.height()/2);
            box.css('left', winW / 2 - box.width() / 2);

        });

        $('#boardy-popup-fav').appendTo('body');




        /*CREATE ALERT ************************************************************/
        $('a[name=boardy-modal-alert]').click(function (e) {
            //Cancel the link behavior
            e.preventDefault();

            //Get the A tag
            var id = $(this).attr('href');

            //Get the screen height and width
            var maskHeight = $(document).height();
            var maskWidth = $(window).width();

            //Set heigth and width to mask to fill up the whole screen
            $('#boardy-popshadow-alert').css({ 'width': maskWidth, 'height': maskHeight });

            //transition effect		
            $('#boardy-popshadow-alert').fadeIn(500);
            $('#boardy-popshadow-alert').fadeTo("fast", 0.7);

            //Get the window height and width
            var winH = $(window).height();
            var winW = $(window).width();

            //Set the popup window to center
            //$(id).css('top',  winH/2-$(id).height()/2);
            $(id).css('left', winW / 2 - $(id).width() / 2);

            //Initialize panel
            $('#divCreateAlertSave').css('display', 'initial');
            $('#tbCreateAlertName').val('');
            $('#pCreateAlertDetail').css('display', 'none');
            $('#pCreateAlertAll').css('display', 'none');
            $('#divCreateAlertSaved').css('display', 'none');
            $('#divCreateAlertNameMissing').css('display', 'none');
            $('#divCreateAlertNotSaved').css('display', 'none');

            var searchFor = $('#hfSearchFor').val();

            if (searchFor == '') {
                $('#pCreateAlertAll').css('display', 'initial');
            }
            else {
                $('#pCreateAlertDetail').css('display', 'initial');
                var currency = $('#hfCurrency').val();
                // split the hidden field 
                var arr = searchFor.split('|');
                var i, seg, text = '';
                for (i = 0; i < arr.length; i++) {
                    if (arr[i] != '') {
                        seg = arr[i].split('^');

                        text += seg[2] + "<br />";

                    }
                }
                $('#pCreateAlertDetail').html(text);
            }

            //transition effect
            $(id).fadeIn(500);
            $('#tbCreateAlertName').focus();
            $('#tbCreateAlertName').bind('keypress', function (e) {
                if (e.keyCode == 13) {
                    CreateJobAlert();
                }
            });
        });


        //if boardy-popclose button is clicked
        $('.window-alert .boardy-popclose-alert').click(function (e) {
            //Cancel the link behavior
            e.preventDefault();

            $('#boardy-popshadow-alert').hide();
            $('.window-alert').hide();
        });

        //if boardy-popclose button is clicked
        $('.window-alert .boardy-popclose-alerthere').click(function (e) {
            //Cancel the link behavior
            e.preventDefault();

            $('#boardy-popshadow-alert').hide();
            $('.window-alert').hide();
        });

        //if mask is clicked
        $('#boardy-popshadow-alert').click(function () {
            $(this).hide();
            $('.window-alert').hide();
        });

        $(window).resize(function () {

            var box = $('#boardy-popup-alert .window-alert');

            //Get the screen height and width
            var maskHeight = $(document).height();
            var maskWidth = $(window).width();

            //Set height and width to mask to fill up the whole screen
            $('#boardy-popshadow-alert').css({ 'width': maskWidth, 'height': maskHeight });

            //Get the window height and width
            var winH = $(window).height();
            var winW = $(window).width();

            //Set the popup window to center
            //box.css('top',  winH/2 - box.height()/2);
            box.css('left', winW / 2 - box.width() / 2);

        });

        $('#boardy-popup-alert').appendTo('body');

    });

</script>
<asp:PlaceHolder ID="phNotLoggedInJS" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $('a[name=boardy-modal-fav]').unbind();
            $('a[name=boardy-modal-fav]').attr('onclick', 'location.href="/member/login.aspx?returnurl=' + escape("/member/createjobalert.aspx?isfav=1&retainsearch=1") + '"; return false;');
            $('a[name=boardy-modal-alert]').unbind();
            $('a[name=boardy-modal-alert]').attr('onclick', 'location.href="/member/login.aspx?returnurl=' + escape("/member/createjobalert.aspx?retainsearch=1") + '"; return false;');
        });
    </script>
</asp:PlaceHolder>
