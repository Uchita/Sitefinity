jQuery(document).ready(function($) {
    //main top navigation
    if( $('.navbar-toggle').length ){
        $('.navbar-toggle').on('click',function(e){
            //to prevent from bootstrap default toggle function executing
            e.stopPropagation();
            
            $(this).toggleClass('active');
            $('body').toggleClass('menu-opened');

            var targetNav = $(this).data('target');
            if( $(targetNav).length ){
                $(targetNav).toggleClass('show');
            }
        });

        // $('.navbar-close').on('click', function(){
        //     $('.navbar-toggle').removeClass('active');
        //     $('body').removeClass('menu-opened');
        // });
        $('.navbar-close').on('click', function(){
            $('.navbar-toggle').trigger('click');
        });
    }

    //callback function for dots display
    function dotState(target){
        if( $(target).find('.owl-dot').length < 2 ){
            $(target).find('.owl-dots').hide();
            $(target).find('.owl-stage').css({
                margin: '0 auto'
            });
        }
    }
    

    //quick job search scroller
    if( jQuery().owlCarousel ){

        // word scroller
        if( $('.jn_word-scroller').length ){
            $('.jn_word-scroller ul').addClass('owl-carousel').owlCarousel({
                //merge:true,
                dots:false,
                nav:true,
                autoWidth:true,
                navText:'',
            });
        }

        if ($('.jn_scroller').length && $('.jn_scroller .sc-item').length > 0) {
            $('.jn_scroller').addClass('owl-carousel').owlCarousel({
                dots: false,
                nav: true,
                navText: '',
                items: 2,
                slideBy: 1,
                responsive: {
                    0: {
                        items: 1
                    },
                    767: {
                        items: 2
                    }
                }
            });

        }

        // jobFeed scroller
        if( $('.jn_scroller-full').length ){
            $('.jn_scroller-full').addClass('owl-carousel').owlCarousel({
                dots:false,
                nav:true,
                navText:'',
                items: 1,
                slideBy: 1
            });
        }
        

        // card icon horizontal list: convert to scroller if more
        if( $('.multi-card-1').length & $('.multi-card-1 .card-copy').length > 3 ){
            $('.multi-card-1 .jn_cards').addClass('owl-carousel').owlCarousel({
                dots: true,
                nav: false,
                autoWidth: true,
                onInitialized: function(e){
                    dotState(e.target);
                 }
            });
        }

        //fullwidth scroller
        if( $('.jn_scroller-fullwidth').length ){
            $('.jn_scroller-fullwidth').addClass('owl-carousel').owlCarousel({
                dots:true,
                nav:false,
                autoWidth:true,
                slideBy: 1,
                margin: 0,
                //center:true,
                onInitialized: function(e){
                   dotState(e.target);
                }
            });
        }

        //Testimonial slider
        if( $('.testimonial-slider').length && $('.testimonial-slider .slide-item').length > 1 ){
            $('.testimonial-slider').addClass('owl-carousel').owlCarousel({
                dots:false,
                nav:true,
                navText:'',
                items: 1,
                slideBy: 1,
            });
        }

        //Image scroller
        if( $('.image-scroller').length && $('.image-scroller img').length > 2 ){
            $('.image-scroller').addClass('owl-carousel').owlCarousel({
                dots: true,
                nav: false,
                autoWidth: true,
                slideBy: 2,
                margin: 30
            });
        }

        //Image scroller for multirows grid layout
        if( $('.image-grid-scroller').length && $('.image-grid-scroller img').length > 4 ){
            $('.image-grid-scroller').addClass('owl-carousel').owlCarousel({
                dots:true,
                nav:false,
                autoWidth: true,
                items: 2,
                slideBy: 2,
                margin:20,
            });
        }

        
        
        //jxt next plugin
        (function ($){
            $.fn.jxtFunc = function( options ){
                var settings = $.extend({
                    funcType: 'filter',
                    filterTarget: '.jn_teamlist .sc-item'
                }, options);

                //filter: team category wise filter
                if( settings.funcType == 'filter' ){
                    if( this.length ){
                        this.on('click', function(e){
                            e.preventDefault();
                            var filterCat = $(this).data('filter');
                            var filterItem = $(settings.filterTarget);
                            filterItem.removeClass('hidden');
                        
                            if( filterCat!= undefined && filterCat != "" ){
                                if( filterCat == "all" ){
                                    filterItem.removeClass('hidden');
                                }else{
                                    filterItem.each( function(e){
                                        if( $(this).data('cat').indexOf(filterCat) == -1 ){
                                            $(this).addClass('hidden');
                                        }
                                    });
                                }
                            }
                        });
                    }
                }
                else if( settings.funcType == 'navigation' ){
                    //navigation script
                }

                return this;
            };
        }(jQuery));

        $('.team-filter a').jxtFunc({
            funcType: 'filter',
            filterTarget: '.jn_teamlist .sc-item'
        });

        
    }

    $('.selectpicker').selectpicker();

    //bootstrap range slider
    if( $('.rangeSlider').length ){
        $('.rangeSlider').slider({});
    }


    //prevent from jumping to the top for link with #
    $('a[href="#"]').on('click', function(e){
        e.preventDefault();
    });

    //for the form input & label element
    //if need label as placeholder & move up when focus and has value
    /* Requirement
     * *animate-label is parent class required for this to work
     * *label should be just after the input field
     * *label input should be wrap with div class form-group
     * *input must have class form-control
    */
    if ($('.animate-label input.form-control').length) {
        //onload: in case of form error
        $('.animate-label input.form-control').each(function () {
            if ($(this).val() != "") {
                $(this).addClass('hasValue');
            }
        });

        $('.animate-label input.form-control').on('focus', function () {
            $(this).addClass('hasValue');
        });
        $('.animate-label input.form-control').on('blur', function () {
            if ($(this).val() == "") {
                $(this).removeClass('hasValue');
            }
        });
    }

});