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

        const scrolled = backImage.parent().offset().top - $(window).scrollTop() - backImage.height();

      backImage.css({"background-position": "center top", "transform": "translateY(" + speed * scrolled + "px)"});
    });
  }
})(jQuery);
