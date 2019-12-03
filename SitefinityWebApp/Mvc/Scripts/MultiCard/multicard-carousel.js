(function ($) {
    $(document).ready(function () {
        var slidesToShow = $('.o-multicard--carousel').attr('data-slides-to-show');

        $('.o-multicard__cardListing').slick({
            autoplay: true,
            arrows: true,
            infinite: true,
            rows: 1,
            slidesToShow: slidesToShow,
            slidesToScroll: 1,
            swipeToSlide: true,
            centerMode: true,
            focusOnSelect: true,
            adaptiveHeight: true,
            prevArrow: $(".o-multicard-nav__left"),
            nextArrow: $(".o-multicard-nav__right"),
            responsive: [
                {
                    breakpoint: 768,
                    settings: {
                        slidesToShow: 3,
                    }
                },
                {
                    breakpoint: 480,
                    settings: {
                        slidesToShow: 1,
                    }
                }
            ]
        });
    });
}(jQuery));
