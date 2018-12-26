$(document).ready(function () {

    /* logo_slider */
    $('.logo_slider').owlCarousel({
        center: true,
        loop: true,
        margin: 20,
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

    /* mobile menu */
    $('.menu_toogle').click(function () {
        $('.header_right').addClass('open');
        $('.header').addClass('menu_open');
        $('.header .main_menu ul li span').addClass('fa-angle-right');
    });

    $('.menu_close').click(function () {
        $('.header_right').removeClass('open');
        $('.header').removeClass('menu_open');
        $('.header .main_menu ul li span').removeClass('fa-angle-right');
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
});








