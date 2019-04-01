$(document).ready(function () {
    $('.form-validate form').validate();
    $("body").addClass("doc-ready");
    $(".btn-style-dropdown a").click(function () {
        $(this).closest(".dropdown").find(".selected-text").text($(this).text());
        $(".btn-style-dropdown a").removeClass("active-sort");
        $(this).addClass("active-sort");
        $(this).closest(".dropdown").removeClass("open");
        $(this).closest(".dropdown").find(".btn").attr("aria-expanded", false);
    });
    $('.jobdetail-sidebar-inner').append($('.job-apply'));
    $('.job-apply').removeClass("hidden");

    $(".news_pagination.pcn-pagination .pagination li").each(function () {
        var anchor = $(this).find("a");
        $(anchor).html("<span>" + anchor.html() + "</span>");
    });
    $(".filter-outer-wrapper .dropdowntree-name").each(function () {
        if ($(this).text() == "Classifications") {
            $(this).text("Sectors");
        }
    });
    var x = getCookie('concent');
    if (x != '') {
        //$('.cookie-banner-container').remove();
    } else {
        $('.cookie-banner-container').removeClass("hidden");
    }

    // Sticky Sidebar's
    $(".jobdetail-sidebar-inner").sticky({ topSpacing: 120, center: true, bottomSpacing: 175 });
    $(".news-sidebar").sticky({ topSpacing: 120, center: true, bottomSpacing: 175 });
    var mobMedia = window.matchMedia("(max-width: 767px)").matches;
    // Unsticky sidebar's on Mobile
    if (mobMedia) {
        $(".jobdetail-sidebar-inner").unstick();
        $(".news-sidebar").unstick();
    }

    $(window).resize(function () {
        var mobMedia = window.matchMedia("(max-width: 767px)").matches;
        if (mobMedia) {
            $(".jobdetail-sidebar-inner").unstick();
            $(".news-sidebar").unstick();
        } else {
            $(".jobdetail-sidebar-inner").sticky({ topSpacing: 120, center: true, bottomSpacing: 175 });
            $(".news-sidebar").sticky({ topSpacing: 120, center: true, bottomSpacing: 175 });
        }
    });


    // Video Auto Play
    var video = $(".bg-video video")[0];
    if (video) {
        video.autoplay = true;
        video.loop = true;
        video.muted = true;
    }
    /* logo_slider */
    $('.logo_slider').owlCarousel({
        center: true,
        loop: true,
        margin: 35,
        autoplay: true,
        autoplayTimeout: 2000,
        nav: false,
        responsive: {
            0: {
                items: 2
            },
            768: {
                items: 4
            },
            1200: {
                items: 7
            }
        }
    });

    /* logo_slider */
    $('.testimonial_slider').owlCarousel({
        loop: true,
        nav: false,
        dots: false,
        autoplay: true,
        items: 1
    });

    /* article - slider */
    $('.article-slider').owlCarousel({
        loop: true,
        nav: false,
        autoplay: true,
        items: 1
    });

    /* logo_slider */
    $('#wt-slider').owlCarousel({
        loop: true,
        nav: false,
        dots: true,
        autoplay: true,
        items: 1
    });

    /* job-slider */
    $('#job-slider').owlCarousel({
        loop: true,
        margin: 30,
        autoplay: true,
        autoplayTimeout: 2000,
        nav: false,
        dots: false,
        responsive: {
            0: {
                items: 1
            },
            768: {
                items: 2
            },
            992: {
                items: 3
            },
            1200: {
                items: 4
            }
        }
    });

    // Consultant Jobs Slider
    $('#consultantJobs_slider,#consultantPosts_slider').owlCarousel({
        loop: false,
        margin: 30,
        autoplay: true,
        autoplayTimeout: 2000,
        nav: false,
        dots: true,
        responsive: {
            0: {
                items: 1
            },
            768: {
                items: 2
            },
            992: {
                items: 3
            },
            1200: {
                items: 4
            }
        }
    });



    /* mobile menu */
    $('.menu_toogle').click(function () {
        $('.header_right').addClass('open');
        $('.header').addClass('menu_open');
        //$('.header .main_menu ul li span').addClass('fa-angle-right');
    });

    $('.menu_close').click(function () {
        $('.header_right').removeClass('open');
        $('.header').removeClass('menu_open');
        //$('.header .main_menu ul li span').removeClass('fa-angle-right');
    });

    $('.header .main_menu ul li .mobile-arrow').click(function () {
        $(this).next('ul').slideToggle();
        $(this).toggleClass('fa-angle-right');
        $(this).toggleClass('fa-angle-down');
    });


    function getParameterByName(name, url) {
        if (!url) url = window.location.href;
        name = name.replace(/[\[\]]/g, "\\$&");
        var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
            results = regex.exec(url);
        if (!results) return null;
        if (!results[2]) return '';
        return decodeURIComponent(results[2].replace(/\+/g, " "));
    }

    /* blog filter */
    var categoryQS = "";
    if (getParameterByName("categories") != null) { categoryQS = getParameterByName("categories"); }

    $('.blog-categories').change(function () {
        var title = $(this).attr('data-Title');
        if (this.checked) {
            categoryQS += title + ",";
        }
        else {
            categoryQS = categoryQS.replace(title + ",", '')
        }
        if (categoryQS.length > 0) {
            window.location.href = "/blog?categories=" + categoryQS;
        }
        else {
            window.location.href = "/blog"
        }

    });

    $(".btn-style-corner .btn").each(function () {
        $(this).html("<span>" + $(this).text() + "</span>");
    });


    $(".click-part").click(function () {
        var thisChildren = $(this).parent().children(".partner-popup");
        var allChildren = $(".partner-popup");
        if ($(thisChildren).css('display') == 'block') {
            $(thisChildren).slideUp("fast");
            $(".click-part").removeClass("active");
        }
        else {
            $(allChildren).slideUp("fast");
            $(".click-part").removeClass("active");
            $(thisChildren).slideDown("fast");
            $(this).addClass("active");
        }
    });

    // Blog sidebar redirect to blog page if filter checked
    $(".blog_sidebar .category a").click(function (e) {
        if ($(this).hasClass("active-link")) {
            e.preventDefault();
            window.location.href = "/news/blog/";
        }
    });


    //using dataTable plugin for pagination in table
    if ($('table.datatable').length) {
        $("table.datatable").each(function () {
            var tbl = $(this);
            var dateColIndex = tbl.find('th.date-col').index();
            var actColIndex = tbl.find('th.act-col').index();
            if (dateColIndex < 0) {
                dateColIndex = 0;
            }
            tbl.slimtable({
                itemsPerPage: 5,
                ippList: [5, 10, 20],
                sortList: [dateColIndex],
                colSettings: [{
                    sortDir: "desc",
                    colNumber: dateColIndex
                },
                {
                    enableSort: false,
                    colNumber: actColIndex
                }
                ],
            });

            if (tbl.parent().find('.slimtable-page-btn').length < 2) {
                tbl.parent().find('.slimtable-paging-div').hide();
            }
        });

    }
});


$(window).on('scroll', function () {
    if ($(window).scrollTop() >= 50) {
        $('.header').addClass('stickyheader');

    } else {
        $('.header').removeClass('stickyheader');
    }
});


/**
 * ==================
 * Equal Height 
 * =====================
 */
function equalHeightAp(container) {

    var currentTallest = 0;
    var currentRowStart = 0;
    var rowDivs = new Array();
    var $el;
    var $element;
    var topPosition = 0;
    var topPostion = 0;
    var currentDiv;

    $(container).each(function () {

        $element = $(this);
        $($element).height('auto');
        topPostion = $element.position().top;

        if (currentRowStart != topPostion) {

            for (currentDiv = 0; currentDiv < rowDivs.length; currentDiv++) {
                rowDivs[currentDiv].height(currentTallest);
            }

            rowDivs.length = 0;
            currentRowStart = topPostion;
            currentTallest = $element.height();
            rowDivs.push($element);

        } else {
            rowDivs.push($element);
            currentTallest = (currentTallest < $element.height()) ? ($element.height()) : (currentTallest);
        }

        for (currentDiv = 0; currentDiv < rowDivs.length; currentDiv++) {
            rowDivs[currentDiv].height(currentTallest);
        }
    });
}
$(window).on("load", function () {
    equalHeightAp('.equalHeight');
    $(".jobdetail-sidebar .bg-corner-inner").append($(".social-sidebar"));
});


$('.accept-link').click(function () {
    $('.cookie-banner-container').remove();
    var x = getCookie('concent');
    if (x == '' || x == null) {
        document.cookie = "concent=true";
    }
});

function getCookie(c_name) {
    if (document.cookie.length > 0) {
        c_start = document.cookie.indexOf(c_name + "=");
        if (c_start != -1) {
            c_start = c_start + c_name.length + 1;
            c_end = document.cookie.indexOf(";", c_start);
            if (c_end == -1) {
                c_end = document.cookie.length;
            }
            return unescape(document.cookie.substring(c_start, c_end));
        }
    }
    return "";
}

// Events load on window scroll
var $eventsWrap = $(".archive-postlist.upcoming-events");
if ($eventsWrap.length > 0) {
    var eventsWrapTop = $eventsWrap.offset().top;
    var $win = $(window);
    $(window).scroll(function () {
        var currentScroll = $win.scrollTop();
        var calcHeight = (eventsWrapTop + $eventsWrap.height()) - 350;
        if (currentScroll > calcHeight) {
            $(".archive-postlist.upcoming-events>.row>div:not(.active-list):lt(2)").addClass("active-list").slideDown("slow");
        }
    });
}