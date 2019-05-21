$(document).ready(function () {
    //$(".parallax-mirror").addClass("translate-fixed");

    $('body').removeClass('doc-loading');

    if (typeof WOW !== 'undefined') {
        new WOW().init();
    }
    if ($("#featuredInsights,#internalJobs1").find('.item').length > 1) {

     $("#featuredInsights,#internalJobs1").owlCarousel({
        margin: 18,
        nav: true,
        autoplay: false,
        autoplayTimeout: 5000,
        dots: true,
        loop: true,
        navText: [],
        responsive: {
            0: {
                items: 1
            },
            768: {
                items: 3
                //loop: false
            }
         },
         onInitialized: function () {
             if ($(this)[0].settings.dots == true && $(this)[0].$element.find('.owl-dots .owl-dot').length < 2) {
                 $(this)[0].$element.find('.owl-dots').hide();
             }
         },
         onResize: function () {
             if ($(this)[0].settings.dots == true && $(this)[0].$element.find('.owl-dots .owl-dot').length > 1) {
                 $(this)[0].$element.find('.owl-dots').show();
             }
         }
    });
    }

    $('.play-btn').click(function () {
        //document.getElementById('is-video').play();
        $('.video-bg>video')[0].play();
        //$('.video-bg>video').get(0).play();
    });

    $(window).resize(function () {
        var viewportWidth = $(window).width();
        if (viewportWidth <= 991 && $('.primary-nav-wrap .col-auto.ml-auto').length) {
            $(".primary-nav-wrap .col-auto.ml-auto").addClass("collapse");
        }
        else if (viewportWidth > 991 && $('.primary-nav-wrap .col-auto.ml-auto').length) {
            $('.primary-nav-wrap .col-auto.ml-auto').removeClass("collapse");

        }
    });

 

    $(function () {
        $('.left-sidebar').addClass('fadeInLeft wow');
    });

    $(".toggle-btn, .read-less").on("click", function (e) {
        e.preventDefault();
        $($(this).attr("href")).slideToggle("slow");
    });

    //to have hover/click state on tablet or touch device
    $("a").bind("touchstart", function (e) {
        $('a').removeClass('active');
        $(this).addClass('active');
    });


    $(".testimonial-carousel").owlCarousel({
        //margin: 20,
        nav: true,
        navText: [],
        items: 1,
        dots: true,
        autoplay: true,
        autoplayTimeout: 5000

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

    if ($(".location-hover li").length) {
        $(".location-hover li").each(function () {
            if ($(this).find('div').text().trim() == "") {
                $(this).hide();
            }
        });
    }



    if ($(".save-job-wrapper").length) {
        if ($(".save-job-wrapper").text()=='') {
            $(".save-job-wrapper").hide();
        }
    }


    /**Leaders Page accordion */
    $(".leader-list a").on("click", function (e) {
        e.preventDefault();
        if ($(this).hasClass("active")) {
            $(".leader-content").remove();
            $(".leader-list a").removeClass("active");
        } else {
            $(".leader-list a").removeClass("active");
            $(this).addClass("active");
            var thisContent = $(this).attr("data-desc");
            if (thisContent) {
                $(this).addClass("active");
                $(".leader-content").remove();
                var str = '<div class="md-row leader-content"><div class="col-12 col-sm-12 border-blue"><p>';
                str += thisContent;
                str += '</p><a href="javascript:void(0)" class="btn btn-link">Read less</a></div></div>';

                var tabView = window.matchMedia('(min-width:577px) and (max-width: 991px)');
                var desktopView = window.matchMedia('(min-width: 992px)');
                var mobileView = window.matchMedia('(max-width: 576px)');

                if (desktopView.matches) {
                    $(this).closest(".md-row").after(str);
                }
                if (tabView.matches) {
                    var activeListEq = $(this).closest('.leader-list').index();
                    if (activeListEq == 0 || activeListEq == 1) {
                        $(this).closest(".md-row").find(".leader-list:nth-child(2)").after(str);
                    } else {
                        $(this).closest(".md-row").find(".leader-list:nth-child(4)").after(str);
                    }
                }
                if (mobileView.matches) {
                    $(this).closest(".leader-list").after(str);
                }
            }
        }
    });

    $(".g-section").on("click", ".leader-content a", function () {
        $(".leader-content").remove();
        $(".leader-list a").removeClass("active");
    });

    // Leaders Categories filter
    $(".btn-leader-cat").on("click", function () {
        var $this = $(this);
        var thisCat = $this.attr("data-cat");
        $this.addClass("active");
        $(".btn-leader-cat").not($this).removeClass("active");
        if (thisCat != "all") {
            $(".leader-list-row").not($(thisCat)).slideUp().removeClass('show-list');
            $(thisCat).slideDown().addClass('show-list');
        } else {
            $(".leader-list-row").slideDown().removeClass('show-list');
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

    $("a.find-talent").click(function () {
        $('#talent-form').show();
        $('#our-talent-image').hide();
        $('.find-talent-close-form').show();
        $(this).hide();
        setTimeout(function () {
            $(window).trigger('resize.px.parallax');
        }, 500);
    });
    $("a.find-talent-close-form").click(function () {
        $('#talent-form').hide();
        $('#our-talent-image').show();
        $(this).hide();
        $('a.find-talent').show();
        setTimeout(function () {
            $(window).trigger('resize.px.parallax');
        }, 500);
    });

    $('.ul-dropdown-toggle').click(function () {
        $(this).next('ul').slideToggle();
        $(this).toggleClass('active');
    });


    $('.show-contact input[value="Yes"]').click(function () {
        $('.contacted-show').slideDown();
    });

    $('.show-contact input[value="No"]').click(function () {
        $('.contacted-show').slideUp();
    });

    $('.white-bg-btn .btn').removeClass('btn-outline-white');
    $('.white-bg-btn .btn').addClass('btn-bg-white');

    $(".feedback_form .replace-h4 > strong").each(function () {
        //$(this).html("<h4>" + $(this).text().replace("<strong>", "").replace("</strong>", '') + "</h4>");
        $(this).replaceWith("<h4>" + $(this).text() + "</h4>");
    });
    $(".feedback_form .replace-h4 > label").each(function () {
        //$(this).html("<h4>" + $(this).text().replace("<strong>", "").replace("</strong>", '') + "</h4>");
        $(this).replaceWith("<h4>" + $(this).text() + "</h4>");
    });


    $(".filter_sidebar .sm-wrapper .dropdown-tree > .dropdown-toggle").wrap("<h3></h3>");

    /*$(".no-h1 h1").each(function () {
        $(this).replaceWith("<div class='hero-title'>" + $(this).text() + "</div>");
    });*/

    //////for add current page class to body 
    var pageTitle = window.location.pathname.replace(/\//gi, " ").trim().split(" ");
    if (pageTitle != "") {
        $("body").addClass(pageTitle[pageTitle.length - 1]);
        $("body").addClass('inner-pages');
        if (pageTitle.indexOf('/') > -1) {
            pageTitle = pageTitle.replace(/\//g, "-");
            $("body").addClass(pageTitle);
        }
    }
    else {
        $('body').addClass('home-page');
    }

    /* safari and chrome */
    var is_Safari = navigator.userAgent.indexOf("Safari") > -1;
    var is_chrome = navigator.userAgent.indexOf('Chrome') > -1;
    if (is_Safari && !is_chrome) {
        $("body").addClass('safari');
    }
    else {
        $("body").addClass('no-safari');

    }


    MakeActiveLinks($(location).attr('pathname'));


    $('a.social-download').attr('download', '');
    $('a.resume-templates-btn1').attr('download', '');
    $('a.resume-templates-btn2').attr('download', '');
    $('a.resume-templates-btn3').attr('download', '');


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

            //if (tbl.parent().find('.slimtable-page-btn').length < 2) {
            //    tbl.parent().find('.slimtable-paging-div').hide();
            //}
        });

    }

});

function MakeActiveLinks(currentLinkPath) {
    if (currentLinkPath == "/workplace-relations-resources")
        $('.custom-active').addClass('active');
    else if (currentLinkPath == "/specialist-recruitment/our-industries")
        $('.our-industries-active').addClass('active');
    else if (currentLinkPath == "/contact")
        $('.contact-active').addClass('active');
    else if (currentLinkPath == "/resources/resume-templates")
        $('.resume-template-active').addClass('active');
    else if (currentLinkPath == "/resource/interview-tips")
        $('.ultimate-interview-guide-active').addClass('active');
    else if (currentLinkPath == "/resources/social-media-job-applicants")
        $('.social-media-guide-active').addClass('active');
    else if (currentLinkPath == "/employer-services")
        $('.our-services-active').addClass('active');
    else if (currentLinkPath == "/resources/career-new")
        $('.career-new-active').addClass('active');
    else if (currentLinkPath == "/career-resources")
        $('.career-resources-active').addClass('active');
    else if (currentLinkPath == "/blogs/-in-category/categories/blog-categories/careers")
        $('.careers-news-active').addClass('active');
    else if (currentLinkPath == "/blogs/-in-category/categories/blog-categories/workplace-relations")
        $('.workplace-relations-news').addClass('active');
    else if (currentLinkPath == "/blogs/-in-category/categories/blog-categories/employers")
        $('.employer-news-active').addClass('active');
    else if (currentLinkPath == "/employer-resources")
        $('.employer-resources-active').addClass('active');
    else if (currentLinkPath == "/about/learn-more")
        $('.contact-active').addClass('active');
    else if (currentLinkPath == "/find-talent")
        $('.find-talent-active').addClass('active');
    else if (currentLinkPath == "/jobs/advancedsearch")
        $('.find-a-job-active').addClass('active');
    else if (currentLinkPath == "/feedback")
        $('.feedback-active').addClass('active');
    else if (currentLinkPath == "/blogs") {
        $('.blog-class-top').addClass('active');
        $('.blog-class').addClass('fadeInRight wow');
    }
    else if (currentLinkPath == "/register")
        $('.register-class').addClass('active');
    else if (currentLinkPath == "/login")
        $('.login-class').addClass('active');
}

var linkedInHandler = linkedInHandler || {};
(function ($) {
    var storagePrefix = 'LinkedIn_';
    var errorUnableToApply = 'Unable to apply for the job due to an error. Please try again.';

    linkedInHandler.submitJobApplyData = function (widgetHolder, jobId, profileData) {
        widgetHolder = $(widgetHolder);

        if (widgetHolder.hasClass('applying')) {
            return;
        }

        var data = {
            jobId: jobId,
            profileJson: JSON.stringify(profileData)
        };

        widgetHolder.addClass('applying');

        var wait = widgetHolder.find('.linkedin-processing');
        wait.show();

        showLinkedInErrors(widgetHolder, null);
        showLinkedInMessages(widgetHolder, null);

        $.ajax({
            method: "POST",
            url: widgetHolder.data('apply-url'),
            data: data,
            dataType: 'json'
        })
            .done(function (response) {
                try {
                    if (response.Success) {
                        if (response.RedirectUrl) {
                            window.location.href = response.RedirectUrl;
                        }
                        else {
                            showLinkedInMessages(widgetHolder, response.Messages);
                        }

                        return;
                    }

                    if (response.Errors && response.Errors.length > 0) {
                        showLinkedInErrors(widgetHolder, response.Errors);
                    }
                    else {
                        showLinkedInErrors(widgetHolder, [errorUnableToApply]);
                    }
                }
                catch (err) {
                    console.log(err);

                    showLinkedInErrors(widgetHolder, [err.message]);
                }
            })
            .fail(function (response) {
                console.log(response);

                showLinkedInErrors(widgetHolder, [errorUnableToApply]);
            })
            .always(function () {
                wait.hide();

                widgetHolder.removeClass('applying');
            });
    };

    function showLinkedInErrors(widgetHolder, errors) {
        var container = $(widgetHolder).find('.linkedin-alerts');

        var errorEl = container.find('.alert-linkedin-errors');
        if (errorEl.length == 0) {
            errorEl = $('<div class="alert alert-danger alert-linkedin-errors"></div>');

            container.append(errorEl);
        }

        if (errors === null) {
            errorEl.hide();
        }
        else {
            errorEl.html(errors.join('<br>'));
            errorEl.show();
        }
    }

    function showLinkedInMessages(widgetHolder, messages) {
        var container = $(widgetHolder).find('.linkedin-alerts');

        var messageEl = container.find('.alert-linkedin-messages');
        if (messageEl.length == 0) {
            messageEl = $('<div class="alert alert-success alert-linkedin-messages"></div>');

            container.append(messageEl);
        }

        if (messages === null) {
            messageEl.hide();
        }
        else {
            messageEl.html(messages.join('<br>'));
            messageEl.show();
        }
    }

    function setShowHideWidgetHolderOnLoad(widgetHolderId, value) {
        sessionStorage.setItem(storagePrefix + widgetHolderId, value);
    }

    function getShowHideWidgetHolderOnLoad(widgetHolderId) {
        return sessionStorage.getItem(storagePrefix + widgetHolderId);
    }

    var linkedInTogglers = $('[data-linkedin-toggle]');

    linkedInTogglers.on('click', function (event) {
        event.preventDefault();

        var linkedInWidgetHolder = $($(this).data('linkedin-toggle'));
        if (linkedInWidgetHolder.length == 0) {
            return;
        }

        if (linkedInWidgetHolder.is(':visible')) {
            linkedInWidgetHolder.slideUp();

            setShowHideWidgetHolderOnLoad(linkedInWidgetHolder.attr('id'), '0');
        }
        else {
            linkedInWidgetHolder.slideDown();
        }
    });

    linkedInTogglers.each(function () {
        var toggler = $(this);

        var linkedInWidgetHolder = $($(this).data('linkedin-toggle'));
        if (linkedInWidgetHolder.length == 0) {
            return;
        }

        if (getShowHideWidgetHolderOnLoad(linkedInWidgetHolder.attr('id')) === '1') {
            linkedInWidgetHolder.show();
        }
    });

    $('.btn-linkedin-signin').on('click', function () {
        var linkedInWidgetHolder = $($(this).data('widget-holder'));
        if (linkedInWidgetHolder.length == 0) {
            return;
        }

        setShowHideWidgetHolderOnLoad(linkedInWidgetHolder.attr('id'), '1');
    });
})(jQuery);