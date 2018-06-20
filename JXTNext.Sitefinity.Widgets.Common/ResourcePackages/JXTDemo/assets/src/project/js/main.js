$(document).foundation();


$('.soc_share .popup').on('click', function(event) {
	event.preventDefault();
	var href = $(this).attr("href");
	window.open(href, "_blank", "scrollbars=1,resizable=1,height=381,width=555");
})

$('video').on('ended', function () {
  this.load();
  this.play();
});