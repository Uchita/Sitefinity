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

    if (!activeEl.length && targetEl.length) {
        targetEl.toggleClass("active").slideToggle();

        $(".filter-job-close").show();
        targetClose.on("click", function () {
            activeEl.toggleClass("active").slideToggle();
            $(".filter.filter-active").removeClass("filter-active");
            $(".filter-job-close").hide();
        });

    } else if (!targetEl.is(activeEl)) {
        activeEl.toggleClass("active").slideToggle();
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
            if (checkWidth >= 767) {
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


$(document).ready(function () {

    ThemeGlobal.QuickLinksToggle();
    ThemeGlobal.HeaderToggleFixed();
    window.requestAnimationFrame = window.requestAnimationFrame || window.mozRequestAnimationFrame || window.webkitRequestAnimationFrame || window.msRequestAnimationFrame || function (f) { setTimeout(f, 1000 / 60) }

    window.addEventListener('scroll', function () {
        ThemeGlobal.HeaderToggleFixed();
        requestAnimationFrame(ThemeGlobal.ParalaxInit);
    }, false);

    $("[data-filter-trigger]").on("click", function () {
        $(".filter.filter-active").removeClass("filter-active");
        $(this).parent(".filter").addClass("filter-active");
        ThemeGlobal.JobsFilterToggle($(this).data("filter-trigger"));
    });

    $('.owl-carousel-testimonials').owlCarousel({
        items: 1,
        loop: true,
    });

    $('.owl-consultants').owlCarousel({
        margin: 25,
        responsive: {
            0: {
                items: 1
            },
            768: {
                items: 3
            },
            1200: {
                items: 4
            }
        }
    })
    $('.owl-contact-gallery').owlCarousel({
        loop: true,
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
    $('.owl-life-at-hudson').owlCarousel({
        loop: true,
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
        $(this).owlCarousel({
            loop: true,
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
    });
    $('.owl-carousel-jumbotron').owlCarousel({
        items: 1,
        loop: true,
        nav: true,
        dots: false,
        navContainerClass: 'owl-nav'
    });
    ThemeGlobal.SameHeight();
    ThemeGlobal.MobileCarouselInit();
});

$(window).resize(function () {
    clearTimeout(window.resizedFinished);
    window.resizedFinished = setTimeout(function () {
        ThemeGlobal.SameHeight();
        ThemeGlobal.MobileCarouselInit();
    }, 250);
})