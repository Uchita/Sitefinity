var ThemeGlobal = {};

ThemeGlobal.QuickLinksToggle = function () {
    var trigger = $('[data-quick-links-toggle=""]'),
        target = $('[data-quick-links-content=""]'),
        close = $('[data-quick-links-close=""]');

    if (trigger.length > 0 && target.length > 0) {
        trigger.on("click", function () {
            trigger.toggleClass("active");
            target.toggleClass("active");
        });
    }

    if (close.length > 0 && target.length > 0) {
        close.on("click", function () {
            trigger.toggleClass("active");
            target.toggleClass("active");
        });
    }
}

ThemeGlobal.JobsFilterToggle = function (target) {
    var targetEl = $('[data-filter-target="' + target + '"]'),
        targetClose = $('[data-filter-trigger="close"]'),
        activeEl = $("[data-filter-target].active");

    //run if target obj is not active and is present    
    if (!activeEl.length && targetEl.length) {
        targetEl.toggleClass("active").slideToggle();

        $(".filter-job-close").show();
        targetClose.on("click", function () {
            activeEl.toggleClass("active").slideToggle();
            $(".filter.filter-active").removeClass("filter-active");
            $(".filter-job-close").hide();
        });
        //if target obj is not active
    } else if (!targetEl.is(activeEl)) {
        
        activeEl.toggleClass("active").slideToggle();
        targetEl.toggleClass("active").slideToggle();
    } else if( targetEl.is(activeEl) ){
        $(".filter-job-close").hide();
        targetEl.toggleClass("active").slideToggle();
    }

}

ThemeGlobal.SameHeight = function () {
    $('.same-height-wrapper').each(function () {
        var highestBox = 0;
        var box = $(this).find('.same-height-box');
        box.css('height', '');
        box.each(function () {
            if ($(this).height() > highestBox) {
                highestBox = $(this).height();
            }
        })
        box.height(highestBox);
    })
}

ThemeGlobal.HeaderToggleFixed = function () {
    var scrollTop = $(window).scrollTop(),
        header = $("#header > .navbar"),
        navbar = $("#header .header-top");

    if (navbar.length) {
        var navbarOffset = navbar.offset().top + navbar.height();
        if (scrollTop > navbarOffset && !header.hasClass("header-fixed-top")) {
            header.find(".header").addClass("navbar-fixed-top");
        } else {
            header.find(".header").removeClass("navbar-fixed-top");
        }
    }
}

ThemeGlobal.ParalaxInit = function () {
    if ($('.paralax-image').length) {
        var scrollTop = $(window).scrollTop(),
            scrollPercentage = -0.075,
            windowHeight = $(window).height(),
            offset = $('.paralax-image').offset();

        if (scrollTop + windowHeight >= offset.top) {
            $('.paralax-image').css('background-position-y', ((offset.top - scrollTop + windowHeight) * scrollPercentage) + 'px');
        }
    }
}

ThemeGlobal.MobileCarouselInit = function () {
    var checkWidth = $(window).width();
    var slider = $(".mobile-owl-carousel");
    if (slider.length > 0) {
        slider.each(function () {
            if (checkWidth >= 768) {
                $(this).trigger('destroy.owl.carousel');
                $(this).removeClass('owl-carousel owl-theme');
            } else if (checkWidth < 768 && !$(this).hasClass("owl-loaded")) {
                $(this).addClass("owl-carousel owl-theme");
                $(this).owlCarousel({
                    items: $(this).hasClass("mobile-owl-2-items") ? 2 : 1,
                    loop: false,
                    center: false,
                    //autoHeight: false
                });
            }
        });
    }    
}

ThemeGlobal.DynamicFormConditions = function () {
    if( $('form .dfcondition').length ){
        $('#C072_Col00,#C072_Col01').hide();
        var dropdownElem = $('#Dropdown-1');
        dropdownElem.change(function () {
            var selected = dropdownElem.find('option:selected').text();
            if (selected == "I am a Job Seeker") {
                $('#C017_Col00,#C017_Col01,#C045_Col00,#C045_Col01,#C072_Col00,#C072_Col01').hide();
                $('#C020_Col00,#C020_Col01,#C019_Col00,#C019_Col01,#C022_Col00,#C022_Col01,#C023_Col00,#C023_Col01').show();
                document.getElementById('functionText').innerHTML = "Which function do you want to work in?";
            }
            if (selected == "I'd like to submit my CV") {
                $('#C017_Col00,#C017_Col01,#C045_Col00,#C045_Col01,#C072_Col00,#C072_Col01').hide();
                $('#C052_Col00, #C053_Col01').parent().hide();
                $('#C020_Col00,#C020_Col01,#C019_Col00,#C019_Col01,#C022_Col00,#C022_Col01,#C023_Col00,#C023_Col01').show();
                document.getElementById('functionText').innerHTML = "Which function do you want to work in?";
            }
            if (selected == "Working for Hudson") {
                $('#C017_Col00,#C017_Col01,#C045_Col00,#C045_Col01,#C019_Col00,#C019_Col01,#C020_Col00,#C020_Col01').hide();
                $('#C072_Col00,#C072_Col01,#C022_Col00,#C022_Col01,#C023_Col00,#C023_Col01').show();
                document.getElementById('functionText').innerHTML = "Which function do you want to work in?";
            }
            if (selected == "Hiring candidates") {
                $('#C022_Col00,#C022_Col01,#C072_Col00,#C072_Col01,#C023_Col00,#C023_Col01').hide();
                $('#C017_Col00,#C017_Col01,#C045_Col00,#C045_Col01,#C020_Col00,#C020_Col01,#C019_Col00,#C019_Col01').show();
                document.getElementById('functionText').innerHTML = "Which function does the role sit in?";
            }
            if (selected == "Candidate profiling & assessment" || selected == "Leadership assessment & development" || selected == "Outplacement & redeployment" || selected == "General inquiry") {
                $('#C017_Col00,#C017_Col01,#C045_Col00,#C045_Col01').show();
                $('#C020_Col00,#C020_Col01,#C019_Col00,#C019_Col01,#C022_Col00,#C022_Col01,#C023_Col00,#C023_Col01,#C072_Col00,#C072_Col01').hide();
            }
        });

        //tiggering the above change function condition on the base of page
        //class are added on each page based to the form widget
        if( $('.jobseeker-sel').length ){
            dropdownElem.val("I am a Job Seeker").change();
        }else if( $('.submitCV-sel').length ){
            dropdownElem.val("I'd like to submit my CV").change();
        }else if( $('.workingForHudson-sel').length ){
            dropdownElem.val("Working for Hudson").change();
        }else if( $('.hiringCandidates-sel').length ){
            dropdownElem.val("Hiring candidates").change();
        }else if( $('.candidateProfiling-sel').length ){
            dropdownElem.val("Candidate profiling & assessment").change();
        }else if( $('.leadershipAssessment-sel').length ){
            dropdownElem.val("Leadership assessment & development").change();
        }else if( $('.outplacement-sel').length ){
            dropdownElem.val("Outplacement & redeployment").change();
        }else{
            dropdownElem.val("General inquiry").change();
        }
    }
}

ThemeGlobal.MobileSubNavigationToggle = function(){
    var backTrigger = "";
    var menuItem = $(".navbar-nav .dropdown");
    var lvlTrigger = menuItem.find('.custom-expander');
    lvlTrigger.on('click',function(){
        backTrigger = $(this);
        if( $('.navbar-header').find('.back-mnu').length ){
            $('.navbar-header').find('.back-mnu').addClass('hidden');
        }
        
        if( $(this).parent().hasClass("open") ){
            $('.navbar-header').prepend( '<span class="back-mnu">Back</span>' );
        }
        
    });
    $('.navbar-header').on('click','.back-mnu', function(){
        
        $(this).remove();
        backTrigger.trigger('click');
        if( $('.navbar-header').find('.back-mnu').length ){
            $('.navbar-header').find('.back-mnu').removeClass('hidden');
            backTrigger =  $(".navbar-nav .dropdown.open").find('>.custom-expander');
        }
       
    });

    $('.navbar-header').on('click', '.navbar-toggle', function(){
        $('.back-mnu').remove();
        $('.dropdown').removeClass('open');
        $('.page-wrapper').toggleClass('menu-opened');
    });
}

$(document).ready(function () {

    ThemeGlobal.QuickLinksToggle();
    ThemeGlobal.HeaderToggleFixed();
    ThemeGlobal.MobileSubNavigationToggle();
    window.requestAnimationFrame = window.requestAnimationFrame || window.mozRequestAnimationFrame || window.webkitRequestAnimationFrame || window.msRequestAnimationFrame || function (f) { setTimeout(f, 1000 / 60) }

    window.addEventListener('scroll', function () {
        ThemeGlobal.HeaderToggleFixed();
        //requestAnimationFrame(ThemeGlobal.ParalaxInit);
    }, false);

    $("[data-filter-trigger]").on("click", function () {
        if( $(this).parent().hasClass('filter-active') ){
            $(this).parent(".filter").removeClass("filter-active");
        }else{
            $(this).parent(".filter").addClass("filter-active");
        }
        $(".filter.filter-active").removeClass("filter-active");
        
        ThemeGlobal.JobsFilterToggle($(this).data("filter-trigger"));
    });

    $('.owl-carousel-testimonials').owlCarousel({
        items: 1,
        loop: true,
        autoplay: true,
        autoplayTimeout: 7000,
    });
    
    $('.owl-consultants').owlCarousel({
        margin: 25,
        autoplay: true,
        autoplayTimeout: 7000,
        autoplayHoverPause: true,
        loop: false,
        responsive: {
            0: {
                items: 1
            },
            500: {
                items: 2
            },
            768: {
                items: 3
            },
            1200: {
                items: 4,
                
            }
        },
        onInitialized: setToCenter
    });
    function setToCenter(event) {
        if( event.page.count == 0 ){
            $(event.target).addClass('item-centered');
        }
    }

    $('.owl-contact-gallery').owlCarousel({
        loop: false,
        autoplay: true,
        margin: 15,
        responsive: {
            0: {
                items: 1
            },
            768: {
                items: 2
            },
            1200: {
                items: 3
            }
        }
    });
    $('.owl-instagram').owlCarousel({
        loop: false,
        margin: 15,
        responsive: {
            0: {
                items: 1
            },
            768: {
                items: 2
            },
            1200: {
                items: 4
            }
        }
    });
    
    $('.owl-card-basic').each(function (i, obj) {
        if ($(this).children().length > 1) {
            $(this).owlCarousel({
                loop: false,
                margin: 15,
                responsive: {
                    0: {
                        items: 1
                    },
                    768: {
                        items: 2
                    },
                    1200: {
                        items: 3
                    }
                }
            });
        } else {
            $(this).show().addClass('flex flex-center');
        }
    });
    $('.owl-carousel-jumbotron').owlCarousel({
        items: 1,
        loop: true,
        autoplay: true,
        nav: true,
        dots: false,
        navContainerClass: 'owl-nav'
    });
    ThemeGlobal.SameHeight();
    ThemeGlobal.MobileCarouselInit();


    ThemeGlobal.DynamicFormConditions();

    

    if( window.location.pathname.indexOf('ApplyJob') > -1 ){
        var exceptionText = "Exception occured while executing the controller. Check error logs for details.";
        
        if( $('.profile-app-wrapper').text().indexOf('Exception occured') > -1 ){
            $('.profile-app-wrapper').remove();
        }
        $('#appFormState').hide();
    }else{
        if(  $('.profile-app-wrapper').length ){
            $('.profile-app-wrapper').fadeIn('fast').removeClass('hide');
        }
    }

    if( $('input[type="password"]').length ){
        $('#userid').change(function(){
            if( $(this).val() == "" ){
                $('input[type="password"]').val("");
            }
        });
    }

    if( $('input[type="number"]').length ){
        $('input[type="number"]').on('keydown',function(e){
            if( e.which == 69 || e.which == 190 ){
                return false;
            }
        });
    }

    if( $('.search-toggle').length ){
        $('body').on('click', '.search-toggle', function(){
           $('.keywordfilter').toggle(); 
        });
    }
    
    var ua = window.navigator.userAgent;
    var msie = ua.indexOf("MSIE ");

    if (msie > 0 || !!navigator.userAgent.match(/Trident.*rv\:11\./))  // If Internet Explorer, return version number
    {
        $('#userid').on('click',function(){
            $(this).removeAttr('readonly').blur().focus();
        });
    }
    $('#userid').on('focus touchstart',function(){
        $(this).removeAttr('readonly');
    });

    //contact page : office detail page
    //map replacement

    if( $('.contact-detail-page').length && $('.map-placeholder').length ){
        
            $('.map-placeholder').addClass('hidden-xs').clone().addClass('visible-xs').removeClass('hidden-xs').insertAfter( $('.mobile-breadcrumb') );
        
    }

    //user dashboard : job alert create and edit
    //scroll to the job alert widget
    if( window.location.pathname.toLowerCase().indexOf('user-dashboard/create') > -1 || window.location.pathname.toLowerCase().indexOf('user-dashboard/edit') > -1 ){
        $('body, html').stop().animate({
            scrollTop: $('#createalert-widget').offset().top - 150
        },10);
    }


    //office page
    //get in touch toggle collapse
    if( $('#officeAddress, .get-in-touch').length ){
        $('.get-in-touch h3[data-target="#officeAddress"]').on('click', function(e){
           $( $(this).data('target') ).toggle();
        });
    }

});

$(window).resize(function () {
    clearTimeout(window.resizedFinished);
    window.resizedFinished = setTimeout(function () {
        ThemeGlobal.SameHeight();
        ThemeGlobal.MobileCarouselInit();
    }, 250);
})