(function ($) {
    $(function () {
        if ($('.inner-page-slider > .c-person-slider').length) {
            $('.inner-page-slider > .c-person-slider').slick({
                autoplay: true,
                arrows: false,
                dots: false,
                infinite: true,
                rows: 1,
                slidesToShow: 3,
                slidesToScroll: 1,
                swipeToSlide: true,
                centerMode: false,
                focusOnSelect: true,
                adaptiveHeight: true,
                prevArrow: $(".o-instagramfeed-nav__left"),
                nextArrow: $(".o-instagramfeed-nav__right"),
                responsive: [
                    {
                        breakpoint: 1024,
                        settings: {
                            slidesToShow: 3,
                        }
                    },
                    {
                        breakpoint: 991,
                        settings: {
                            slidesToShow: 2,
                        }
                    },
                    {
                        breakpoint: 767,
                        settings: {
                            slidesToShow: 1,
                        }
                    }
                ]
            });
        }

        else {
            $('.c-person-slider').slick({
                autoplay: true,
                arrows: false,
                dots: true,
                infinite: true,
                rows: 2,
                slidesToShow: 3,
                slidesToScroll: 1,
                swipeToSlide: true,
                centerMode: false,
                focusOnSelect: true,
                adaptiveHeight: true,
                prevArrow: $(".o-instagramfeed-nav__left"),
                nextArrow: $(".o-instagramfeed-nav__right"),
                responsive: [
                    {
                        breakpoint: 1024,
                        settings: {
                            slidesToShow: 3,
                        }
                    },
                    {
                        breakpoint: 991,
                        settings: {
                            slidesToShow: 2,
                        }
                    },
                    {
                        breakpoint: 767,
                        settings: {
                            slidesToShow: 1,
                        }
                    }
                ]
            });
        }
    });
}(jQuery));