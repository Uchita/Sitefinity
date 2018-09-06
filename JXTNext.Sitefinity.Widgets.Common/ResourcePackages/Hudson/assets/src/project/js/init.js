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
        //if not target obj is active
    } else if (!targetEl.is(activeEl)) {
        activeEl.toggleClass("active").slideToggle();
        targetEl.toggleClass("active").slideToggle();
    } else if( targetEl.is(activeEl) ){
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

ThemeGlobal.DynamicFormConditions = function () {
    if( $('form .dfcondition').length ){
        $('#Dropdown-5').hide();
        $('#Dropdown-1').change(function(){
        var selected = $('#Dropdown-1 option:selected').text();
        if(selected == "I am a Job Seeker"){
            $('#C017_Col00, #C017_Col01').hide();
            $('#C045_Col00, #C045_Col01').hide();
            $('#C020_Col00, #C020_Col01').show();
            $('#C019_Col00, #C019_Col01').show();
            $('#C022_Col00, #C022_Col01').show();
            $('#C023_Col00, #C023_Col01').show();
        }
        if(selected == "I'd like to submit my CV"){
            $('#C017_Col00, #C017_Col01').hide();
            $('#C045_Col00, #C045_Col01').hide();
            $('#C020_Col00, #C020_Col01').show();
            $('#C019_Col00, #C019_Col01').show();
            $('#C022_Col00, #C022_Col01').show();
            $('#C023_Col00, #C023_Col01').show();
        }
        if(selected == "Working for Hudson"){
            $('#C017_Col00, #C017_Col01').hide();
            $('#C045_Col00, #C045_Col01').hide();
            $('#C019_Col00, #C019_Col01').hide();
            $('#Dropdown-4').hide();
            $('#Dropdown-5').show();
            $('#C022_Col00, #C022_Col01').show();
            $('#C023_Col00, #C023_Col01').show();

        }
        if(selected == "Hiring candidates"){
            $('#C022_Col00, #C022_Col01').hide();
            $('#C017_Col00, #C017_Col01').show();
            $('#C045_Col00, #C045_Col01').show();
            $('#C020_Col00, #C020_Col01').show();
            $('#C019_Col00, #C019_Col01').show();
            $('#C023_Col00, #C023_Col01').show();
        }
        if(selected == "Candidate profiling & assessment" || selected ==  "Leadership assessment & development" || selected == "Outplacement & redeployment" || selected == "General inquiry"){
            $('#C017_Col00, #C017_Col01').show();
            $('#C045_Col00, #C045_Col01').show();
            $('#C020_Col00, #C020_Col01').hide();
            $('#C019_Col00, #C019_Col01').hide();
            $('#C022_Col00, #C022_Col01').hide();
            $('#C023_Col00, #C023_Col01').hide();
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
    });

    $('.owl-consultants').owlCarousel({
        margin: 25,
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
        if ($(this).children().length > 1) {
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
        } else {
            $(this).show().addClass('flex flex-center');
        }
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


    ThemeGlobal.DynamicFormConditions();
});

$(window).resize(function () {
    clearTimeout(window.resizedFinished);
    window.resizedFinished = setTimeout(function () {
        ThemeGlobal.SameHeight();
        ThemeGlobal.MobileCarouselInit();
    }, 250);
})