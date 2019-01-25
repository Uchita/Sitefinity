$(document).ready(function () {
    //$(".parallax-mirror").addClass("translate-fixed");

    if (typeof WOW !== 'undefined') {
        new WOW().init();
    }
    $("#featuredInsights,#internalJobs1").owlCarousel({
        margin: 18,
        nav: true,
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
    $(".testimonial-carousel").owlCarousel({
        //margin: 20,
        nav: true,
        navText: [],
        items: 1,
        dots: true,
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
        var thisContent = $(this).attr("data-desc");
        if (thisContent) {
            $(".leader-content").remove();
            var str = '<div class="md-row leader-content"><div class="col-12 col-sm-12 border-blue"><p>';
            str += thisContent;
            str += '</p><a href="javascript:void(0)" class="btn btn-link">Read less</a></div></div>';
            $(this).closest(".md-row").after(str);
        }
    });

    $(".g-section").on("click", ".leader-content a", function () {
        $(this).closest(".leader-content").remove();
    });

    // Leaders Categories filter
    $(".btn-leader-cat").on("click", function () {
        var $this = $(this);
        var thisCat = $this.attr("data-cat");
        $this.addClass("active");
        $(".btn-leader-cat").not($this).removeClass("active");
        if (thisCat != "all") {
            $(".leader-list-row").not($(thisCat)).slideUp();
            $(thisCat).slideDown();
        } else {
            $(".leader-list-row").slideDown();
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

});