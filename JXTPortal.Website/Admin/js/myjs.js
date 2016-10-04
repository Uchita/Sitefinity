$(function(){

	$(".edit-detail-link").click(function(e){
		e.preventDefault();
		$(this).parent().next(".detail-edit").show();
	});
	$(".cancel-button").click(function(e){
		e.preventDefault();
		$(this).closest(".detail-edit").hide();
	});

});