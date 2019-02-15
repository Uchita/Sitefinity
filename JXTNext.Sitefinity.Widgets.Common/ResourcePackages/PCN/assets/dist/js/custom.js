$(document).ready(function () {
    $('.jobdetail-sidebar-inner').append($('.job-apply'));
    $('.job-apply').removeClass("hidden");

    $(".news_pagination.pcn-pagination .pagination li").each(function () {
        var anchor = $(this).find("a");
        $(anchor).html("<span>" + anchor.html() + "</span>");
    });
    $(".filter-outer-wrapper .dropdowntree-name").each(function () {
        if ($(this).text() == "Classifications") {
            $(this).text("Sectors");
        }
    });
    var x = getCookie('concent');
    if (x != '') {
        //$('.cookie-banner-container').remove();
    } else {
        $('.cookie-banner-container').removeClass("hidden");
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

    /* job-slider */
    $('#job-slider').owlCarousel({
        loop: true,
        margin: 30,
        autoplay: true,
        autoplayTimeout: 2000,
        nav: false,
        dots: false,
        responsive: {
            0: {
                items: 1
            },
            768: {
                items: 2
            },
            992: {
                items: 3
            },
            1200: {
                items: 4
            }
        }
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


    $(".click-part").click(function () {
        var thisChildren = $(this).parent().children(".partner-popup");
        var allChildren = $(".partner-popup");
        if ($(thisChildren).css('display') == 'block') {
            $(thisChildren).slideUp("fast");
            $(".click-part").removeClass("active");
        }
        else {
            $(allChildren).slideUp("fast");
            $(".click-part").removeClass("active");
            $(thisChildren).slideDown("fast");
            $(this).addClass("active");
        }
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
    $(".jobdetail-sidebar .bg-corner-inner").append($(".social-sidebar"));
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


// Sticky Plugin v1.0.4 for jQuery
// =============
// Author: Anthony Garand
// Improvements by German M. Bravo (Kronuz) and Ruud Kamphuis (ruudk)
// Improvements by Leonardo C. Daronco (daronco)
// Created: 02/14/2011
// Date: 07/20/2015
// Website: http://stickyjs.com/
// Description: Makes an element on the page stick on the screen as you scroll
//              It will only set the 'top' and 'position' of your element, you
//              might need to adjust the width in some cases.

(function (factory) {
    if (typeof define === 'function' && define.amd) {
        // AMD. Register as an anonymous module.
        define(['jquery'], factory);
    } else if (typeof module === 'object' && module.exports) {
        // Node/CommonJS
        module.exports = factory(require('jquery'));
    } else {
        // Browser globals
        factory(jQuery);
    }
}(function ($) {
    var slice = Array.prototype.slice; // save ref to original slice()
    var splice = Array.prototype.splice; // save ref to original slice()

    var defaults = {
        topSpacing: 0,
        bottomSpacing: 0,
        className: 'is-sticky',
        wrapperClassName: 'sticky-wrapper',
        center: false,
        getWidthFrom: '',
        widthFromWrapper: true, // works only when .getWidthFrom is empty
        responsiveWidth: false,
        zIndex: 'inherit'
    },
        $window = $(window),
        $document = $(document),
        sticked = [],
        windowHeight = $window.height(),
        scroller = function () {
            var scrollTop = $window.scrollTop(),
                documentHeight = $document.height(),
                dwh = documentHeight - windowHeight,
                extra = (scrollTop > dwh) ? dwh - scrollTop : 0;

            for (var i = 0, l = sticked.length; i < l; i++) {
                var s = sticked[i],
                    elementTop = s.stickyWrapper.offset().top,
                    etse = elementTop - s.topSpacing - extra;

                //update height in case of dynamic content
                s.stickyWrapper.css('height', s.stickyElement.outerHeight());

                if (scrollTop <= etse) {
                    if (s.currentTop !== null) {
                        s.stickyElement
                            .css({
                                'width': '',
                                'position': '',
                                'top': '',
                                'z-index': ''
                            });
                        s.stickyElement.parent().removeClass(s.className);
                        s.stickyElement.trigger('sticky-end', [s]);
                        s.currentTop = null;
                    }
                }
                else {
                    var newTop = documentHeight - s.stickyElement.outerHeight()
                        - s.topSpacing - s.bottomSpacing - scrollTop - extra;
                    if (newTop < 0) {
                        newTop = newTop + s.topSpacing;
                    } else {
                        newTop = s.topSpacing;
                    }
                    if (s.currentTop !== newTop) {
                        var newWidth;
                        if (s.getWidthFrom) {
                            padding = s.stickyElement.innerWidth() - s.stickyElement.width();
                            newWidth = $(s.getWidthFrom).width() - padding || null;
                        } else if (s.widthFromWrapper) {
                            newWidth = s.stickyWrapper.width();
                        }
                        if (newWidth == null) {
                            newWidth = s.stickyElement.width();
                        }
                        s.stickyElement
                            .css('width', newWidth)
                            .css('position', 'fixed')
                            .css('top', newTop)
                            .css('z-index', s.zIndex);

                        s.stickyElement.parent().addClass(s.className);

                        if (s.currentTop === null) {
                            s.stickyElement.trigger('sticky-start', [s]);
                        } else {
                            // sticky is started but it have to be repositioned
                            s.stickyElement.trigger('sticky-update', [s]);
                        }

                        if (s.currentTop === s.topSpacing && s.currentTop > newTop || s.currentTop === null && newTop < s.topSpacing) {
                            // just reached bottom || just started to stick but bottom is already reached
                            s.stickyElement.trigger('sticky-bottom-reached', [s]);
                        } else if (s.currentTop !== null && newTop === s.topSpacing && s.currentTop < newTop) {
                            // sticky is started && sticked at topSpacing && overflowing from top just finished
                            s.stickyElement.trigger('sticky-bottom-unreached', [s]);
                        }

                        s.currentTop = newTop;
                    }

                    // Check if sticky has reached end of container and stop sticking
                    var stickyWrapperContainer = s.stickyWrapper.parent();
                    var unstick = (s.stickyElement.offset().top + s.stickyElement.outerHeight() >= stickyWrapperContainer.offset().top + stickyWrapperContainer.outerHeight()) && (s.stickyElement.offset().top <= s.topSpacing);

                    if (unstick) {
                        s.stickyElement
                            .css('position', 'absolute')
                            .css('top', '')
                            .css('bottom', 0)
                            .css('z-index', '');
                    } else {
                        s.stickyElement
                            .css('position', 'fixed')
                            .css('top', newTop)
                            .css('bottom', '')
                            .css('z-index', s.zIndex);
                    }
                }
            }
        },
        resizer = function () {
            windowHeight = $window.height();

            for (var i = 0, l = sticked.length; i < l; i++) {
                var s = sticked[i];
                var newWidth = null;
                if (s.getWidthFrom) {
                    if (s.responsiveWidth) {
                        newWidth = $(s.getWidthFrom).width();
                    }
                } else if (s.widthFromWrapper) {
                    newWidth = s.stickyWrapper.width();
                }
                if (newWidth != null) {
                    s.stickyElement.css('width', newWidth);
                }
            }
        },
        methods = {
            init: function (options) {
                return this.each(function () {
                    var o = $.extend({}, defaults, options);
                    var stickyElement = $(this);

                    var stickyId = stickyElement.attr('id');
                    var wrapperId = stickyId ? stickyId + '-' + defaults.wrapperClassName : defaults.wrapperClassName;
                    var wrapper = $('<div></div>')
                        .attr('id', wrapperId)
                        .addClass(o.wrapperClassName);

                    stickyElement.wrapAll(function () {
                        if ($(this).parent("#" + wrapperId).length == 0) {
                            return wrapper;
                        }
                    });

                    var stickyWrapper = stickyElement.parent();

                    if (o.center) {
                        stickyWrapper.css({ width: stickyElement.outerWidth(), marginLeft: "auto", marginRight: "auto" });
                    }

                    if (stickyElement.css("float") === "right") {
                        stickyElement.css({ "float": "none" }).parent().css({ "float": "right" });
                    }

                    o.stickyElement = stickyElement;
                    o.stickyWrapper = stickyWrapper;
                    o.currentTop = null;

                    sticked.push(o);

                    methods.setWrapperHeight(this);
                    methods.setupChangeListeners(this);
                });
            },

            setWrapperHeight: function (stickyElement) {
                var element = $(stickyElement);
                var stickyWrapper = element.parent();
                if (stickyWrapper) {
                    stickyWrapper.css('height', element.outerHeight());
                }
            },

            setupChangeListeners: function (stickyElement) {
                if (window.MutationObserver) {
                    var mutationObserver = new window.MutationObserver(function (mutations) {
                        if (mutations[0].addedNodes.length || mutations[0].removedNodes.length) {
                            methods.setWrapperHeight(stickyElement);
                        }
                    });
                    mutationObserver.observe(stickyElement, { subtree: true, childList: true });
                } else {
                    if (window.addEventListener) {
                        stickyElement.addEventListener('DOMNodeInserted', function () {
                            methods.setWrapperHeight(stickyElement);
                        }, false);
                        stickyElement.addEventListener('DOMNodeRemoved', function () {
                            methods.setWrapperHeight(stickyElement);
                        }, false);
                    } else if (window.attachEvent) {
                        stickyElement.attachEvent('onDOMNodeInserted', function () {
                            methods.setWrapperHeight(stickyElement);
                        });
                        stickyElement.attachEvent('onDOMNodeRemoved', function () {
                            methods.setWrapperHeight(stickyElement);
                        });
                    }
                }
            },
            update: scroller,
            unstick: function (options) {
                return this.each(function () {
                    var that = this;
                    var unstickyElement = $(that);

                    var removeIdx = -1;
                    var i = sticked.length;
                    while (i-- > 0) {
                        if (sticked[i].stickyElement.get(0) === that) {
                            splice.call(sticked, i, 1);
                            removeIdx = i;
                        }
                    }
                    if (removeIdx !== -1) {
                        unstickyElement.unwrap();
                        unstickyElement
                            .css({
                                'width': '',
                                'position': '',
                                'top': '',
                                'float': '',
                                'z-index': ''
                            })
                            ;
                    }
                });
            }
        };

    // should be more efficient than using $window.scroll(scroller) and $window.resize(resizer):
    if (window.addEventListener) {
        window.addEventListener('scroll', scroller, false);
        window.addEventListener('resize', resizer, false);
    } else if (window.attachEvent) {
        window.attachEvent('onscroll', scroller);
        window.attachEvent('onresize', resizer);
    }

    $.fn.sticky = function (method) {
        if (methods[method]) {
            return methods[method].apply(this, slice.call(arguments, 1));
        } else if (typeof method === 'object' || !method) {
            return methods.init.apply(this, arguments);
        } else {
            $.error('Method ' + method + ' does not exist on jQuery.sticky');
        }
    };

    $.fn.unstick = function (method) {
        if (methods[method]) {
            return methods[method].apply(this, slice.call(arguments, 1));
        } else if (typeof method === 'object' || !method) {
            return methods.unstick.apply(this, arguments);
        } else {
            $.error('Method ' + method + ' does not exist on jQuery.sticky');
        }
    };
    $(function () {
        setTimeout(scroller, 0);
    });
}));


$(document).ready(function () {
    $(".jobdetail-sidebar-inner").sticky({ topSpacing: 120, center: true, bottomSpacing: 175 });
});