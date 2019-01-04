$(document).ready(function () {
    $(".parallax-mirror").addClass("translate-fixed");

    if (typeof WOW !== 'undefined') {
        new WOW().init();
    }
    $("#featuredInsights,#internalJobs1").owlCarousel({
        margin: 18,
        nav: true,
        dots: true,
        navText: ['<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24"><path d="M15.61 7.41L14.2 6l-6 6 6 6 1.41-1.41L11.03 12l4.58-4.59z"/></svg>',
            '<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24"><path d="M10.02 6L8.61 7.41 13.19 12l-4.58 4.59L10.02 18l6-6-6-6z"/></svg>'
        ],
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
        navText: ['<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24"><path d="M15.61 7.41L14.2 6l-6 6 6 6 1.41-1.41L11.03 12l4.58-4.59z"/></svg>',
            '<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24"><path d="M10.02 6L8.61 7.41 13.19 12l-4.58 4.59L10.02 18l6-6-6-6z"/></svg>'
        ],
        items: 1,
        dots: true,
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


    $(".app-header .dropdown-toggle").on("click", function () {
        window.location.href = $(this).attr("href");
    });

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


            // Parallax image top
            if (winScroll < 50) {
                $(".parallax-mirror").addClass("translate-fixed");
            } else {
                $(".parallax-mirror").removeClass("translate-fixed");
            }

        });

    }(jQuery));

});