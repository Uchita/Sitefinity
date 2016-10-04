// v2
(function($){

	$.fn.dropdown = function(dropdownPageList)
	{
		if ( !dropdownPageList[window.location.pathname] )
		{ 
			return;
		}
	
		var ddSelector = dropdownPageList[window.location.pathname][0];
		var ddEnd = dropdownPageList[window.location.pathname][1];
		var ddOpenFirst = dropdownPageList[window.location.pathname][2];
		if (ddSelector)
		{
			$(ddSelector).nextUntil(ddSelector).each(function(){
				$(this).width($(this).width());
			});
			$(ddSelector).nextUntil(ddEnd).hide();
			$(ddSelector).click(function(){
				$(ddSelector).not(this).removeClass("active");
				$(this).toggleClass("active");
				$(ddSelector).not(this).nextUntil(ddEnd).slideUp();
				$(this).nextUntil(ddEnd).slideToggle();
			});
			
			// give each h2 an id equal to its text. replace & with 'and' and spaces with '-'
			$(ddSelector).each(function(){
				$(this).addClass("dropdown-heading");
				$(this).text($.trim($(this).text()));
				var headingText = $(this).text()
					.toLowerCase()
					.replace(/\&amp;/g,"&")
					.replace(/\&/g, "and")
					.replace(/\W/g, "")
					.replace(/\s/g, "-");
				$(this).attr("id", headingText);
			});
			
			// check if there is a # in the URL and click the link and scroll to it if there is.
			if ("" != window.location.hash && $(window.location.hash).length)
			{
				$(window.location.hash).click();
				$("html, body").animate({
					scrollTop: $(window.location.hash).offset().top
				}, 100);
			}
			
			// IF there isn't an active class by now, open the first by default.
			if (ddOpenFirst && !$(ddSelector + ".active").length)
			{
				$(ddSelector + ":first").click();
			}
			
			// Make each link to the ID trigger the javascript.
			$(".dropdown-heading").each(function(){
				var headingID = "#" + $(this).attr("id");
				$("a[href='" + window.location.pathname + headingID + "']").click(function(e){
					
					// if the user clicked on a non dropdown heading link, scroll to it. 
					if ( !$(this).hasClass("dropdown-heading") )
					{
						var clickedItem = this;
						$("html, body").animate({
							scrollTop: $(clickedItem).offset().top
						}, 100);
					}
					
					$(headingID).click();
					
					e.preventDefault();
					return false;
				});
			});
		}
	}

})(jQuery);