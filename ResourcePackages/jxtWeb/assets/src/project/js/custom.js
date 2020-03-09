$(document).ready(function () {

  if (typeof WOW !== 'undefined') {
    new WOW().init();
  }
  
  $('.menuToggle').click(function () {
    $('.main-menu').slideToggle();
  });

  //internal navigation
  $('.tabs-menu li a, .nav-pills li a').click( function(e){
    $(this).parents('ul').find('li a').removeClass('active');
    $(this).addClass('active');
  });

  $('.open-submenu').click(function () {
    $(this).next('.megamenu').slideToggle();
    $(this).toggleClass('active');
  });

  //tabination
  if( $('.tabs-menu.nav-pills, .nav-tabs.nav-pills').length ){
    $('.tabs-menu.nav-pills li a, .nav-tabs.nav-pills li a').click( function(){
      var elem = $(this).data('content');
      if( $(elem).length ){
        $(elem).parent().find('.tab-pane').removeClass('active');
        $(elem).addClass('active') ;
      }
    });
  }


     $('.read-more-content').addClass('hidden');

      // Set up the toggle.
      $('.read-more-toggle').on('click', function(e) {
          e.preventDefault();
        $(this).parents('.cta-block').find('.read-more-content').slideToggle();
        $(this).parents('.cta-block').toggleClass('active');
        $(this).toggleClass('less');
        if($(this).hasClass("less")) {
          $(this).text("READ LESS");
        }
        else
        {
          $(this).text("READ MORE");
        }
      });


  /** Owl Carousels */
  if( $(".slide-section").length ){  
    $(".slide-section").owlCarousel({
      autoplay: true,
      loop: true,
      margin: 25,
      nav: true,
      dots: true,
      responsive: {
        0: {
          items: 1
        },

        600: {
          items: 3,
          nav: false
        },

        1024: {
          items: 4
        },

        1366: {
          items: 4
        }
      }
    });
  }

  if( $(".testimonials").length ){  
    $(".testimonials").owlCarousel({
      autoplay: true,
      loop: true,
      responsiveClass: true,
      nav: false,
      dots: true,
      items: 1
    });
  }

  if( $("#quote-carousel").length ){  
    $("#quote-carousel").owlCarousel({
      autoplay: true,
      loop: true,
      responsiveClass: true,
      nav: false,
      dots: true,
      items: 1
    });
  }
 
  if( $("#post-slider").length ){    
    $("#post-slider").owlCarousel({
      autoplay: true,
      loop: true,
      margin: 20,
      nav: true,
      dots:false,
      responsive: {
        0: {
          items: 1
        },
    
        600: {
          items: 2,
          nav:false
        },
    
        1024: {
          items: 3
        }
      }
    });
  }

  // #region #️⃣testimonialsSlider :AK:
  if( $("#testimonialsSlider").length ){
    $("#testimonialsSlider").slick({
    dots: true,
    slidesPerRow: 2,
    rows: 2,
    arrows:false,
    responsive: [
    {
      breakpoint: 991,
      settings: {
        slidesPerRow: 1,
        rows: 1,
      }
    }
  ]
});
  }


/*megnific popup*/
 if( $(".popup-link").length ){
$('.popup-link').magnificPopup({
        type:'inline',
        midClick: true // Allow opening popup on middle mouse click. Always set it to true if you don't provide alternative source in href.
    });
}
  // #region #️⃣trustedCompanies slider :AK:
  if( $("#trustedCompanies").length ){
    $("#trustedCompanies").owlCarousel({
      items: 6,
      nav: false,
      dots: false,
      responsive: {
        0: {
          items: 3
        },
        992: {
          items: 6
        }
      }
    });
  }
  // #endregion :: End

  if( $(".brands").length ){
    $(".brands").owlCarousel({
      //items: 4,
      autoplay: true,
      nav: false,
      dots: true,
      autoWidth: true,
    });
  }


  /* searchToggle */
  $('.searchToggle').click(function () {
    $('.search-bar').slideToggle();
    $(this).toggleClass('active');
  });

  /* searchToggle */
  $('.searchPhoneToggle').click(function () {
    $('.phone-search-bar').slideToggle();
    $(this).toggleClass('active');
  });

  // #endregion :: End

  
  window.onscroll = function() { 
    if( $('.stickyElem').length ){
      stickOnScroll('.stickyElem', '.stickyElem > div'); 
      highlightOnScroll();
    }
  };

  function stickOnScroll(obj, targetObj) {
    var elem = document.querySelector(obj);
    var targElem = document.querySelector(targetObj);
    var sticky = elem.offsetTop;
    if (window.pageYOffset > sticky) {
      targElem.classList.add("sticky");
    } else {
      targElem.classList.remove("sticky");
    }
  }

  function highlightOnScroll(){
    //var elem = $(obj);
    var elem = $('.stickyElem .tabs-menu li');
    //looping through the tab menu item to get the id
    elem.each( function(){
      //get the id of element
      var elemId = $(this).find('a').attr('href');
      console.log(elemId);
      //checking if element with that id exists.
      if( $(elemId).length ){
        var targElem = $(elemId);
        var sticky = targElem.offset().top;
        //checking if scroll vertical position has cross the element top position 
        console.log(window.pageYOffset + ' - ' + sticky);
        if (window.pageYOffset < sticky + targElem.height() - 120) {
          console.log('in');
          $(this).siblings().find('a').removeClass('active');
          $(this).find('a').addClass('active');
          return false;
        }
      }
    });
  }

  highlightOnScroll();

  //page class based on page url
  var pageUrl = window.location.pathname;
  if( pageUrl.split('/')[1].length > 0 ){
    pageUrl = "pg__" + pageUrl.split('/')[1];
  }else{ //homepage
    pageUrl = "pg__home";
  }
  $('body').addClass(pageUrl);


  
  // Add smooth scrolling to all links
  $("a").on('click', function(event) {

    // Make sure this.hash has a value before overriding default behavior
    if (this.hash !== "" && $(hash).length) {
      // Prevent default anchor click behavior
      event.preventDefault();

      // Store hash
      var hash = this.hash;

      // Using jQuery's animate() method to add smooth page scroll
      // The optional number (800) specifies the number of milliseconds it takes to scroll to the specified area
    
      $('html, body').animate({
        scrollTop: $(hash).offset().top - 120
      }, 300, function(){

        // Add hash (#) to URL when done scrolling (default click behavior)
        //window.location.hash = hash;
      });
    } // End if
  });
  
  //category based tab links
  //need to have taxa-links in the template
  if( $('.taxa-links').length ){
    var taxaUrl = window.location.href;
    var taxaLinks = $('.taxa-links li a');
    var activeFlag = false;
    if( taxaLinks.length ){
      taxaLinks.each( function(){
        var taxaName = $(this).attr('href');
        if( taxaName == taxaUrl ){
          $(this).addClass('active');
          activeFlag = true;
          return false;
        }
      });
      if( activeFlag == false ){
        $('.taxa-links li').first().find('a').addClass('active');
      }
    }
  }


});

