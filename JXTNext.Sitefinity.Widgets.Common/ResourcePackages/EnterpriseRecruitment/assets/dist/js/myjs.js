!(function ($) {
    // regular js
    $.fn.equalHeights = function()
	{
		var maxHeight = 0;
		this.each(function(){
			maxHeight = $(this).outerHeight() > maxHeight ? $(this).outerHeight() : maxHeight;
		});
		this.css("min-height", maxHeight);
	};
	$.fn.equalHeights2 = function()
	{
		var maxHeight = 0;
		this.each(function(){
			maxHeight = $(this).outerHeight() > maxHeight ? $(this).outerHeight() : maxHeight;
		});
		this.css("height", maxHeight);
	};

    function formatDate(myDate) {
        var monthList = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"];
        var myDay = "<span class='rss-item-pubDate-date'>" + myDate.getUTCDate() + "</span> ";
        var myMonth = "<span class='rss-item-pubDate-month'>" + monthList[myDate.getUTCMonth()] + "</span> ";
        var myYear = "<span class='rss-item-pubDate-full-year'>" + myDate.getUTCFullYear() + "</span> ";

        return myDay + "<br>" + myMonth;
    }

    // jquery
    $(function () {

        //
        $('.loader').fadeOut(600);

        $('link[href="/media/COMMON/newdash/lib/bootstrap.min.css"]').remove();

        if ($('#site-topnav .user-loggedIn').length) {
            $('a#HiddenMemLog').prop("href", "/member/default.aspx").text('My Dashboard');
        }

        var currentPage = window.location.pathname.toLowerCase();

        // remove empty li's on the system pages.
        $("#side-left li:empty").remove();

        // remove empty left side bar
        if ($('#prefix_left-navigation').children().length == 0) {
            $('#prefix_left-navigation').remove();
        }
        if ($('#side-left').children().length == 0) {
            $('#side-left').remove();
        }

        if( $('.dynamic-content-holder p').last().text().trim() == '' ){
            $('.dynamic-content-holder p').last().remove();
        }

        /* Adding Bootstrap Classes */
        $('#dynamic-container, #content-container, #job-dynamic-container').addClass('container');
        $('#dynamic-side-right-container, #job-side-column, #side-right').addClass('hidden-xs hidden-sm hidden-md hidden-lg');
        if (!$.trim($('#dynamic-side-left-container, #side-left').html()).length) {
            $('#dynamic-content, #content-container #content').addClass('col-xs-12');
        } else {
            $('#dynamic-side-left-container, #side-left').addClass('col-sm-3 hidden-xs');
            $('#dynamic-content, #content-container #content').addClass('col-sm-9 col-xs-12');
        }
        $('#job-dynamic-container #content').addClass('col-xs-12');

        // form elements style
        $('input:not([type=checkbox]):not([type=radio]):not([type=submit]):not([type=reset]):not([type=file]):not([type=image]):not([type=date]), select, textarea').addClass('form-control');
        $('input[type=text]').addClass('form-control');
        $('input[type=submit]').addClass('btn btn-primary');
        $('.mini-new-buttons').addClass('btn btn-primary');
        $('input[type=reset]').addClass('btn btn-default');

        // Repsonsive image
        $('.dynamic-content-holder img').addClass('img-responsive');

        // Responsive table
        $('.dynamic-content-holder table, .content-holder table').addClass('table table-bordered').wrap('<div class="table-responsive"></div>');

        // Convert top menu to Boostrap Responsive menu
        $('.navbar .navbar-collapse > ul').addClass('nav navbar-nav');
        $('.navbar .navbar-collapse > ul > li').has('ul').addClass('dropdown');
        $('.navbar .navbar-collapse > ul > li.dropdown > a').addClass('disabled');
        $('.navbar .navbar-collapse > ul > li.dropdown').append('<a id="child-menu"></a>');
        $('.navbar .navbar-collapse > ul > li.dropdown > a#child-menu').append('<b class="caret"></b>').attr('data-toggle', 'dropdown').addClass('dropdown-toggle');
        $('.navbar .navbar-collapse > ul > li > ul').addClass('dropdown-menu');

        // add placeholder for search widget text field
        $('#keywords1').attr('placeholder', 'Keywords search');

        // add active class to links.
        $("li a[href='" + window.location.pathname.toLowerCase() + "']").parent().addClass("active");
        $("li.active li.active").parent().closest("li.active").removeClass("active");

        // add last-child class to navigation
        $("#prefix_navigation > ul > li:last").addClass("last-child");

        // add btn style
        $(".backtoresults a").addClass("btn btn-default");
        $(".apply-now-link a").addClass("btn btn-primary");
        $(".job-navbtns a").addClass("btn btn-default");

        //.left-hidden show
        if ((document.URL.indexOf("/advancedsearch.aspx") >= 0)) {
            $(".left-hidden").css("display", "block");
        }
        if ((document.URL.indexOf("/advancedsearch.aspx?") >= 0)) {
            $(".left-hidden").css("display", "none");
        }
        if ((document.URL.indexOf("/member/createjobalert.aspx") >= 0)) {
            $(".left-hidden").css("display", "block");
        }
        if ((document.URL.indexOf("/member/login.aspx") >= 0)) {
            $(".left-hidden").css("display", "block");
        }
        if ((document.URL.indexOf("/member/register.aspx") >= 0)) {
            $(".left-hidden").css("display", "block");
        }

        // Contact - Google map
        $("#footer").prepend($("#contact-map"));


        // generate select navigation from sidebar Dynamic menu
        $("#dynamic-content").convertNavigation({
            title: "Related Pages",
            links: "#site-topnav .navbar-nav li.active a:not([data-toggle=dropdown])"
        });

        // generate actions button on Job Listing page
        $(".job-navbtns").convertButtons({
            buttonTitle: "Actions&hellip;",
            title: "Please choose&hellip;",
            links: ".job-navbtns a"
        });

        // generate filters button on Job Listing page
        $(".job-navbtns").convertFilters({
            buttonTitle: "Filters&hellip;",
            filteredTitle: "Applied Filters",
            title: "Please choose&hellip;",
            filtered: ".search-query p",
            list: "ul#side-drop-menu",
            excludeFromList: "#AdvancedSearchFilter_PnlCompany"
        });

        // Adding page Title
        if( $('.inner-banner-txt').length ){
            $('.inner-banner-txt').html($('#dynamic-content h1').first());
        }
        if( $('.r25inner_banner').length ){
            if( $('.candidates-sec, .banner-ref').attr('data-bannerimg')!='' && $('.candidates-sec, .banner-ref').attr('data-bannerimg')!=undefined ){
                var imgUrl = $('.candidates-sec, .banner-ref').attr('data-bannerimg');
                $('.r25inner_banner img').attr('src',imgUrl);
            }else{
                $('#dynamic-container').addClass('without-banner');
                if( $('#aspnetForm[action*="/news"]').length <1){
                    $('.r25inner_banner img').remove();
                    $('#content-container').addClass('without-banner');
                }
            }
        }else if( $('#dynamic-side-left-container').length<1 && $('#dynamic-container').length ){
                $('#dynamic-container').addClass('without-banner');
        }


        /* System Page Forms */
        if (currentPage == "/member/createjobalert.aspx") {
            setTimeout('__doPostBack(\'ctl00$ContentPlaceHolder1$ucJobAlert1$ddlProfession\',\'\')', 0);
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function () {
                $('.alternate > li > select, #ctl00_ContentPlaceHolder1_ucJobAlert1_txtSalaryLowerBand, #ctl00_ContentPlaceHolder1_ucJobAlert1_txtSalaryUpperBand').addClass('form-control');
                $('#ctl00_ContentPlaceHolder1_ucJobAlert1_ddlProfession, #ctl00_ContentPlaceHolder1_ucJobAlert1_ddlRole, #ctl00_ContentPlaceHolder1_ucJobAlert1_ddlLocation, #ctl00_ContentPlaceHolder1_ucJobAlert1_lstBoxArea, #ctl00_ContentPlaceHolder1_ucJobAlert1_ddlSalary').addClass('form-control');
            });
        }

        if( $('#aspnetForm[action*="/news.aspx"]').length && $('#aspnetForm[action*="categories"]').length<1 ){
            $('.content-holder h1').first().text('Latest Stories');
        }else if( $('#aspnetForm[action*="categories"]').length  ){
            var pageTitle = [];
            $('.jxt-news-filter-multiple li a.active').each( function(){
                pageTitle.push( $(this).text() );
            });
            $('.content-holder h1').first().text( pageTitle.join(', ') );
        }
        $('.jxt-news-filter-category a').click( function(){
            RefineNews();
        });

        $('.back-to-news-index').text('Back to Stories Index');

        $('.search-query .red-remove a').each( function(){
            $(this).text('X');
        });

        $(document).ajaxComplete(function () {
            $('#divRoleID1 > select, #divAreaDropDown1 > div > select').addClass('form-control');
            $('#divRoleID > select, #divAreaDropDown > div > select').addClass('form-control');
        });
        $('#salaryID').change(function () {
            $(document).ajaxComplete(function () {
                $('#divSalaryFrom > input').addClass('form-control');
                $('#divSalaryTo > input').addClass('form-control');
            });
        });

        function SalaryFromChange1() {
            $(document).ajaxComplete(function () {
                $('#divSalaryTo1 > input').addClass('form-control');
                $('#divSalaryFrom1 > input').addClass('form-control');
            });
        }

        if (currentPage == "/member/register.aspx") {
            $(".uniForm").addClass("border-container");
        }
        if (currentPage == "/member/createjobalert.aspx") {
            $(".uniForm").addClass("border-container");
        }

        if( $('.sidebar-image').length && $('#dynamic-side-left-container').length ){
            $('#dynamic-side-left-container').append( $('.sidebar-image'));
        }

        $('.panel-collapse:not(.in)').parent().find('.panel-heading .panel-title a').addClass('collapsed');


    });



    $(document).ready(function () {


        /* Mandatory Fields */
       $("#ctl00_ContentPlaceHolder1_Label2").append('<span class="form-required">*</span>');
        $("#ctl00_ContentPlaceHolder1_Label3").append('<span class="form-required">*</span>');
        $("#ctl00_ContentPlaceHolder1_Label4").append('<span class="form-required">*</span>');
        $("<span class='error-field phone-num'>Phone number is required</span>").insertAfter($('#ctl00_ContentPlaceHolder1_txtTel'));
        $("<span class='error-field address-field'>Address is required</span>").insertAfter($('#ctl00_ContentPlaceHolder1_txtAddress'));
        $("<span class='error-field suburub-field'>Suburb is required</span>").insertAfter($('#ctl00_ContentPlaceHolder1_txtSuburb'));
        $('#btnSubmit').on('click', function(){ 
           if($.trim($("#ctl00_ContentPlaceHolder1_txtTel").val()).length <= 0){
            $('.phone-num').css('display','block');
           }
           else{$('.phone-num').css('display','none');}

           if($.trim($("#ctl00_ContentPlaceHolder1_txtAddress").val()).length <= 0){
            $('.address-field').css('display','block');
           }
           else{$('.address-field').css('display','none');}

           if($.trim($("#ctl00_ContentPlaceHolder1_txtSuburb").val()).length <= 0){
            $('.suburub-field').css('display','block');
           }
           else{$('.suburub-field').css('display','none');}

        });
        /*// Resize action
        var $window = $(window);
        	// Function to handle changes to style classes based on window width
        	function checkWidth() {
        	if ($window.width() < 992) {
        		$('.navbar .navbar-collapse > ul > li.dropdown > a').removeAttr('class');
        		}
        }
        	// Execute on load
        	checkWidth();
        	// Bind event listener
        	$(window).resize(checkWidth);*/



        // Home services - carousel
        $('.t-gallery').Gallerycarousel({
            autoRotate: 4000,
            visible: 4,
            speed: 1200,
            easing: 'easeOutExpo',
            itemMinWidth: 250,
            itemMargin: 30
        })


        // Latest Jobs widget
        $("#myJobsList ul").includeFeed({
            baseSettings: {
                rssURL: "/job/rss.aspx?search=1&addlocation=1"
            },
            elements: {
                pubDate: formatDate,
                title: 1,
                description: 1
            },
            complete: function () {
                /*if ($(this).children().length > 2){
                	$(this).simplyScroll({frameRate:60});
                }*/
            }
        });
        // Latest Jobs widget in sector candidate page
        if( $("#jobList-sector.sector-jobs").length ){
            var sectorJob = $("#jobList-sector.sector-jobs");

            if( $(".rssincl-content").length ){

                    $(".rssincl-entry").each(function(){
                        sectorJob.append('<div class="col-md-4 col-sm-6"><div class="white-bg"><header class="jobpost-head"><time>' + $(this).find(".rssincl-itemdate").html() + '</time>'+
                        '<h3><a href="' + $(this).find(".rssincl-itemtitle > a").attr("href") + '" >' + $(this).find(".rssincl-itemtitle > a").text() + '</a></h3></header>'+
                        '<div class="jobpost-desc">' + $(this).find(".rssincl-itemdesc").html() + $(this).find(".xmlLocation").prop("outerHTML").replace("\&nbsp;", " ") + $(this).find(".xmlWorktype").prop("outerHTML").replace("\&nbsp;", " ") + '</div></div></div>');
                    });
                    if ($(this).children().length && $(window).width() > 767 ){
                        $("#jobList-sector .white-bg").equalHeights2();
                    }

            }// end if
            $(window).resize(function(){
                $("#jobList-sector.sector-jobs").children().children().equalHeights2();
            });
        }//end if

        // Equal Height - Usage
        $('.service-holder, .case-study-section .col-md-4 .white-bg').equalHeights();

        // latest jobs of Candidate
        if( $('#jobList-sector.consultant-job-posting').length ){
            var candidateJobList = $('#jobList-sector.consultant-job-posting').data('url');
            if( candidateJobList.trim() != '' ){
                //candidateJobList = candidateJobList + '&addlocation=1&addworktype=1]';

                $("#jobList-sector.consultant-job-posting").addClass('loading');
                $("#jobList-sector.consultant-job-posting").includeFeed({
                    baseSettings: {
                        rssURL: [candidateJobList || "/job/rss.aspx?search=1&addlocation=1"],
                        limit: 30
                    },
                    templates: {
                            itemTemplate: '<div class="col-md-4 col-sm-6"><div class="white-bg"><header class="jobpost-head"><time>{{pubDate}}</time>'+
                            '<h3><a href="{{link}}" title="{{title}}">{{title}}</a></h3></header>'+
                            '<div class="jobpost-desc">{{description}}</div></div></div>'
                        },
                    complete: function () {
                        if ($(this).children().length ){
                            if( $(window).width() > 767 )   {
                                $(this).children().children().equalHeights();
                            }
                        }else{
                            $(this).append('<p>Please contact me for a confidential discussion regarding opportunities that suit your skills or advice on how to advance your&nbsp;career.</p>');
                            $(this).parent().find('.btn').remove();
                        }
                        $(this).removeClass('loading');
                    }
                });
            }else{
                $('.current-positions, .consultant-link-wrapper .view-all-jobs').hide();
            }
        }// end of candidate page check


        //consultant listing homepage
        $(".team-slider #owl-demo").addClass('loading');
        $(".team-slider #owl-demo").includeFeed({
            baseSettings: { rssURL: ["/consultantsrss.aspx"],limit:9, addNBSP:false, repeatTag:"consultant"},
            templates: {
                    itemTemplate: '<div class="item"><a href="/t/{{FriendlyURL}}" title="{{FirstName}} {{LastName}}"><img src="{{ImageURL}}" alt="{{FirstName}}"></a></div>'
                },
            complete: function(){
                $(this).owlCarousel({
                    autoPlay: 3000,
                    //pagination : true,
                    items:3,
                    itemsTablet: [1024,3],
                    itemsTabletSmall: [991,4],
                  });
                $(this).removeClass('loading');

            }
        });


        //consultant Listing team page
        $("#consultantsList ul").addClass('loading');
        $("#consultantsList ul").includeFeed({
            baseSettings: { rssURL: ["/consultantsrss.aspx"],limit:200, addNBSP:false, repeatTag:"consultant"},
            templates: {
                    itemTemplate: '<li class="col-md-2 col-sm-2 {{Categories}}"><div class="team-block">'+
                        '<div class="name-block"><h2>{{FirstName}} {{LastName}}</h2><h3>{{PositionTitle}}</h3><div class="loc">{{Location}}</div><div class="hidden">JobRSS: {{JobRSS}}</div></div>'+
                        '<figure class="image-block"><img alt="{{FirstName}}" src="{{ImageURL}}" />'+
                           '<div class="overlay"><span><i class="fa fa-phone"></i> {{Phone}}</span>'+
                                '<a href="mailto:{{Email}}"><i class="fa fa-envelope"></i> <cite>{{Email}}</cite></a>'+                                                     
                                '<a href="/t/{{FriendlyURL}}" class="btn btn-primary">Read more</a>'+
                                //'<span>{{ShortDescription}}</span>'+
                            '</div>'+
                        '</figure></div></li>'
                },
                complete: function(){


                    var $grid = $('#consultantsList ul');
                    $grid.find('li').hide().css('opacity',0);

                    $grid.isotope({
                        itemSelector: '#consultantsList li',
                        filter: '*',
                        // getSortData: {
                        //     category: '[data-category]', // text from querySelector
                        // }
                    });

                    $grid.imagesLoaded().progress( function(imgLoad, image) {

                        var $item = $( image.img ).parents( 'li' );

                        // un-hide item
                        $item.show();
                        $grid.isotope('layout');
                        setTimeout( function(){
                            $item.css('opacity',1);
                        },1500);
                    });

                    // filter items on button click
                    $('.filters.button-group').on( 'click', 'button', function(e) {
                      e.preventDefault();
                      var filterValue = $(this).attr('data-filter');
                      $grid.isotope({ filter: filterValue });
                    });

                    if( $(this).children().length ){
                        $(this).find('li').each( function(){
                            var item = $(this);
                            var email = item.find('a[href*="mailto:"]').attr('href');
                            var nameEm = email.substr(0, email.indexOf('@'));
                            nameEm = nameEm.substr(email.indexOf(':')+1);
                            item.find('a[href*="mailto:"] cite').text(nameEm);
                        });
                    }
                    $(this).removeClass('loading');

                }
            });



        // if there is a hash, scroll down to it. Sticky header covers up top of content.
        if ($(window.location.hash).length) {
            $("html, body").animate({
                scrollTop: $(window.location.hash).offset().top - $(".navbar-wrapper").height() - 40
            }, 100);
        }

    });

    $(window).load(function () {
        $("#site-topnav").addClass("dl-menuwrapper");
        $(".navbar-toggle").unwrap(".navbar-header");
        $(".navbar-toggle").addClass("dl-trigger").removeClass("navbar-toggle");
        $("ul.navbar-nav").unwrap();
        $("ul.navbar-nav").addClass("dl-menu");
        $("ul.navbar-nav ul").addClass("dl-submenu").removeClass("dropdown-menu");
        $("ul.navbar-nav .dropdown-toggle").each(function () {
            $(this).remove();
        });



        $('#site-topnav').dlmenu({
            animationClasses: {
                classin: 'dl-animate-in-2',
                classout: 'dl-animate-out-2'
            }
        });
	
    });
})(jQuery);
