$(document).ready(function () {
    
    /* logo_slider */
    $('.logo_slider').owlCarousel({
        center:true,
        loop:true,
        margin:40,
        autoWidth:true,
        autoplay:true,
        autoplayTimeout:2000,
        nav:false,
        responsive:{
            0:{
                items:2
            },
            768:{
                items:4
            },
            1200:{
                items:6
            }
        }
    });
    
    /* mobile menu */
    $('.menu_toogle').click(function(){
        $('.header_right').addClass('open');
        $('.header').addClass('menu_open');
    });
    
    $('.menu_close').click(function(){
        $('.header_right').removeClass('open');
        $('.header').removeClass('menu_open');
    });
    
});



