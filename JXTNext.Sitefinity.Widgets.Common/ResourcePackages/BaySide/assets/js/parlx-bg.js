(function($) {
  $.fn.parlx = function(options) {

    var options = $.extend({
      speed: 0.3
    }, options);

    return this.each(function() {

      const backImage = $(this);
      let speed = options.speed;

      if(speed > 0.5 || speed < 0.1) {
        speed = 0.3;
      }

	    backImage.css({
    		width: "100vw",
    		height: "100vh"
  		});

      const scrolled = $(window).scrollTop() - backImage.parent().offset().top;

      backImage.css({"background-position": "center center", "transform": "translateY(" + speed * scrolled + "px)"});
    });
  }
})(jQuery);
