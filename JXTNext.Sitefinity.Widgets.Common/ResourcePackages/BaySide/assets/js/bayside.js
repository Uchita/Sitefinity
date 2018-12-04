$(document).ready(function () {
    if (typeof WOW !== 'undefined') {
        new WOW().init();
    }
    $("#featuredInsights,#internalJobs").owlCarousel({
        margin: 30,
        nav: true,
        dots: false,
        navText: ['<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24"><path d="M15.61 7.41L14.2 6l-6 6 6 6 1.41-1.41L11.03 12l4.58-4.59z"/></svg>',
            '<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24"><path d="M10.02 6L8.61 7.41 13.19 12l-4.58 4.59L10.02 18l6-6-6-6z"/></svg>'
        ],
        responsive: {
            0: {
                items: 1
            },
            768: {
                items: 2
            },
            992: {
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
        dots: true
    });

    /**Leaders Page accordion */
    $(".leader-list a").on("click", function (e) {
        e.preventDefault();
        var thisContent = $(this).attr("data-desc");
        if (thisContent) {
            $(".leader-content").remove();
            var str = `<div class="md-row leader-content"><div class="col-12 col-sm-12 border-blue"><p>`;
            str += thisContent;
            str += `</p><a href="javascript:void(0)" class="btn btn-link">Read less</a></div></div>`;
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



});