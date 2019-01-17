

$(document).ready(function () {
    var x = getCookie('concent');
    if (x != '') {
        $('.cookie-banner-container').remove();
    }

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




