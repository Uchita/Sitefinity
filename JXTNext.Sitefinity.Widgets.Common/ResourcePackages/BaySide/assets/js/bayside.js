$(document).ready(function () {
    //$(".parallax-mirror").addClass("translate-fixed");

    $('body').removeClass('doc-loading');

    if (typeof WOW !== 'undefined') {
        new WOW().init();
    }
    $("#featuredInsights,#internalJobs1").owlCarousel({
        margin: 18,
        nav: true,
        autoplay: true,
        autoplayTimeout: 5000,
        dots: true,
        navText: [],
        responsive: {
            0: {
                items: 1
            },
            768: {
                items: 3,
                loop: false
            }
        }
    });

    $(function () {
        $('.left-sidebar').addClass('fadeInLeft wow');
    });

    $(".toggle-btn").on("click", function (e) {
        e.preventDefault();
        $($(this).attr("href")).slideToggle("slow");
    });

    $(".testimonial-carousel").owlCarousel({
        //margin: 20,
        nav: true,
        navText: [],
        items: 1,
        dots: true,
        autoplay: true,
        autoplayTimeout: 5000

    });

    $(".news-slider-mobile").owlCarousel({
        margin: 18,
        nav: false,
        dots: true,
        navText: [],
        responsive: {
            0: {
                items: 1
            },
            768: {
                items: 3,
                loop: false
            }
        }
    });

    /**Leaders Page accordion */
    $(".leader-list a").on("click", function (e) {
        e.preventDefault();
        if ($(this).hasClass("active")) {
            $(".leader-content").remove();
            $(".leader-list a").removeClass("active");
        } else {
            $(".leader-list a").removeClass("active");
            $(this).addClass("active");
            var thisContent = $(this).attr("data-desc");
            if (thisContent) {
                $(this).addClass("active");
                $(".leader-content").remove();
                var str = '<div class="md-row leader-content"><div class="col-12 col-sm-12 border-blue"><p>';
                str += thisContent;
                str += '</p><a href="javascript:void(0)" class="btn btn-link">Read less</a></div></div>';

                var tabView = window.matchMedia('(min-width:577px) and (max-width: 991px)');
                var desktopView = window.matchMedia('(min-width: 992px)');
                var mobileView = window.matchMedia('(max-width: 576px)');

                if (desktopView.matches) {
                    $(this).closest(".md-row").after(str);
                }
                if (tabView.matches) {
                    var activeListEq = $(this).closest('.leader-list').index();
                    if (activeListEq == 0 || activeListEq == 1) {
                        $(this).closest(".md-row").find(".leader-list:nth-child(2)").after(str);
                    } else {
                        $(this).closest(".md-row").find(".leader-list:nth-child(4)").after(str);
                    }
                }
                if (mobileView.matches) {
                    $(this).closest(".leader-list").after(str);
                }
            }
        }
    });

    $(".g-section").on("click", ".leader-content a", function () {
        $(".leader-content").remove();
        $(".leader-list a").removeClass("active");
    });

    // Leaders Categories filter
    $(".btn-leader-cat").on("click", function () {
        var $this = $(this);
        var thisCat = $this.attr("data-cat");
        $this.addClass("active");
        $(".btn-leader-cat").not($this).removeClass("active");
        if (thisCat != "all") {
            $(".leader-list-row").not($(thisCat)).slideUp().removeClass('show-list');
            $(thisCat).slideDown().addClass('show-list');
        } else {
            $(".leader-list-row").slideDown().removeClass('show-list');
        }
    });


    //$(".app-header .dropdown-toggle").on("click", function () {
    //    window.location.href = $(this).attr("href");
    //});

    /*
     * ------------------------------------
     * ------- AK Counter
     * ------------------------------------
     */
    (function ($) {
        "use strict";
        var winHeight = $(window).height();
        $(window).on("scroll", function () {
            var winScroll = $(window).scrollTop();
            var $counters = $(".item-count");
            $counters.each(function (idx, el) {
                var $counter = $(el);
                var elPos = $counter.closest(".section-graphics").offset().top;
                var dataSt = $counter.attr("data-st");
                var matchPos = (elPos - (winHeight - 100));
                var text = $counter.attr("data-text");
                if (winScroll > matchPos) {
                    if (dataSt == '1') {
                        $counter.attr("data-st", '0');
                        $counter.prop('Counter', 0).animate({
                            Counter: text
                        }, {
                                duration: 2000,
                                easing: 'swing',
                                step: function (now) {
                                    $counter.text(parseInt(now));
                                }
                            });
                    }
                } else {
                    $counter.attr("data-st", '1');
                    $counter.text("0");
                }
            });

        });

    }(jQuery));

    $(".find-talent").click(function () {
        $('#talent-form').show();
        $('#our-rtalent-image').hide();
        $('.find-talent-close-form').show();
        $('.find-talent').hide();
        setTimeout(function () {
            $(window).trigger('resize.px.parallax');
        }, 500);
    });
    $(".find-talent-close-form").click(function () {
        $('#talent-form').hide();
        $('#our-rtalent-image').show();
        $('.find-talent-close-form').hide();
        $('.find-talent').show();
        setTimeout(function () {
            $(window).trigger('resize.px.parallax');
        }, 500);
    });

    $('.ul-dropdown-toggle').click(function () {
        $(this).next('ul').slideToggle();
        $(this).toggleClass('active');
    });


    $('.show-contact input[value="Yes"]').click(function () {
        $('.contacted-show').slideDown();
    });

    $('.show-contact input[value="No"]').click(function () {
        $('.contacted-show').slideUp();
    });

    $('.white-bg-btn .btn').removeClass('btn-outline-white');
    $('.white-bg-btn .btn').addClass('btn-bg-white');

    $(".feedback_form .replace-h4 > strong").each(function () {
        //$(this).html("<h4>" + $(this).text().replace("<strong>", "").replace("</strong>", '') + "</h4>");
        $(this).replaceWith("<h4>" + $(this).text() + "</h4>");
    });
    $(".feedback_form .replace-h4 > label").each(function () {
        //$(this).html("<h4>" + $(this).text().replace("<strong>", "").replace("</strong>", '') + "</h4>");
        $(this).replaceWith("<h4>" + $(this).text() + "</h4>");
    });


    $(".filter_sidebar .sm-wrapper .dropdown-tree > .dropdown-toggle").wrap("<h3></h3>");

    /*$(".no-h1 h1").each(function () {
        $(this).replaceWith("<div class='hero-title'>" + $(this).text() + "</div>");
    });*/

    //////for add current page class to body 
    var pageTitle = window.location.pathname.replace(/\//gi, " ").trim().split(" ");
    if (pageTitle != "") {
        $("body").addClass(pageTitle[pageTitle.length - 1]);
        $("body").addClass('inner-pages');
        if (pageTitle.indexOf('/') > -1) {
            pageTitle = pageTitle.replace(/\//g, "-");
            $("body").addClass(pageTitle);
        }
    }
    else {
        $('body').addClass('home-page');
    }

    /* safari and chrome */
    var is_Safari = navigator.userAgent.indexOf("Safari") > -1;
    var is_chrome = navigator.userAgent.indexOf('Chrome') > -1;
    if (is_Safari && !is_chrome) {
        $("body").addClass('safari');
    }
    else {
        $("body").addClass('no-safari');

    }


    MakeActiveLinks($(location).attr('pathname'));


    $('a.social-download').attr('download', '');
    $('a.resume-templates-btn1').attr('download', '');
    $('a.resume-templates-btn2').attr('download', '');
    $('a.resume-templates-btn3').attr('download', '');
});

function MakeActiveLinks(currentLinkPath) {
    if (currentLinkPath == "/workplace-relations-resources")
        $('.custom-active').addClass('active');
    else if (currentLinkPath == "/specialist-recruitment/our-industries")
        $('.our-industries-active').addClass('active');
    else if (currentLinkPath == "/contact")
        $('.contact-active').addClass('active');
    else if (currentLinkPath == "/resources/resume-templates")
        $('.resume-template-active').addClass('active');
    else if (currentLinkPath == "/resource/interview-tips")
        $('.ultimate-interview-guide-active').addClass('active');
    else if (currentLinkPath == "/resources/social-media-job-applicants")
        $('.social-media-guide-active').addClass('active');
    else if (currentLinkPath == "/employer-services")
        $('.our-services-active').addClass('active');
    else if (currentLinkPath == "/resources/career-new")
        $('.career-new-active').addClass('active');
    else if (currentLinkPath == "/career-resources")
        $('.career-resources-active').addClass('active');
    else if (currentLinkPath == "/blogs/-in-category/categories/blog-categories/careers")
        $('.careers-news-active').addClass('active');
    else if (currentLinkPath == "/blogs/-in-category/categories/blog-categories/workplace-relations")
        $('.workplace-relations-news').addClass('active');
    else if (currentLinkPath == "/blogs/-in-category/categories/blog-categories/employers")
        $('.employer-news-active').addClass('active');
    else if (currentLinkPath == "/employer-resources")
        $('.employer-resources-active').addClass('active');
    else if (currentLinkPath == "/about/learn-more")
        $('.contact-active').addClass('active');
    else if (currentLinkPath == "/find-talent")
        $('.find-talent-active').addClass('active');
    else if (currentLinkPath == "/jobs/advancedsearch")
        $('.find-a-job-active').addClass('active');
    else if (currentLinkPath == "/feedback")
        $('.feedback-active').addClass('active');
    else if (currentLinkPath == "/blogs") {
        $('.blog-class-top').addClass('active');
        $('.blog-class').addClass('fadeInRight wow');
    }
    else if (currentLinkPath == "/register")
        $('.register-class').addClass('active');
    else if (currentLinkPath == "/login")
        $('.login-class').addClass('active');
}