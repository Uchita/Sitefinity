// JS for Profile Builder
// regular js
$.fn.equalHeights = function()
{
	var maxHeight = 0;
	this.each(function(){
		maxHeight = $(this).outerHeight() > maxHeight ? $(this).outerHeight() : maxHeight;
	});
	this.css("min-height", maxHeight);
}
$(document).ready( function(){

    $.each($(".headingInfo"), function(){

        var attr = $(this).attr("title");
       if (typeof attr !== typeof undefined && attr !== false) {
            $(this).removeClass("hide").tooltip();
        }

    });


   $('#ctl00_ContentPlaceHolder1_ddlRolePreferenceSalaryRequirements').on("change", function () {
        SalaryTypeChanged();
    });

    SalaryTypeChanged();

    $('.multiselect').multiselect({
            maxHeight: 200,
            numberDisplayed: 2,
            buttonClass: 'form-control'
        });

	$('#content').removeClass('col-sm-8 col-md-9');
		/* scroll bar on summary section*/
	//run jscrollpane only if there is summary class element
	if( $('.summary').length ){	
		$('.summary').jScrollPane();
		
		$( window ).resize(function() {
			$('.summary').jScrollPane();
		});
	}

	$('#CV-content').on('click', '.fa-edit', function(){
		$(this).parents('.section-content').addClass('edit-mode');
		var editBlockId = $(this).attr('href');
		//only for personal details section
		if( editBlockId == "#personalDetailsform" || editBlockId == "#editRole" || editBlockId == '#editsupplementaryQuestions' ){
			if( editBlockId == "#personalDetailsform" ){
				$('body,html').animate({
					scrollTop: $(this).offset().top + $(this).height()
				},300);
			}
		}else{
			//close other edit-mode sections if any
			$('.profile-edit').not($(this).parents('.section-content').find('.profile-edit')).removeClass('in').addClass('collapse');
			$('.fa-edit').not(this).parents('.section-content').removeClass('edit-mode');
			$('.new-block-holder').addClass('hidden').find('.profile-edit').removeClass('in').addClass('collapse');
		}
		//in case of some bootstrap js (old version), there is issue with toggle collapse, as result it does not add class in second time. setTimeout is place to prevent from running before the bootstrap js does.
		setTimeout( function(){
			if( !$(editBlockId).hasClass('in') ){
				$(editBlockId).addClass('in').css('height','auto');
			}
		},200);

	});

	$('.close-btn, .cancel-btn').on( 'click', function(){
		var closeBlockID;
		if($(this).parents('.new-block-holder').length)
		{	
			var temp = $(this).attr('href');
			closeBlockID = $(temp).parents(".form-section");
		}
		else
		{
			var temp = $(this).attr('href');
			closeBlockID = $(temp).parent();
		}
		//scroll new block to visible area of screen
			$('body,html').animate({
					scrollTop: $(closeBlockID).offset().top - $("header").height()
				},300);
		// for add new section only
		if( $(this).parents('.new-block-holder').find('.profile-edit').is(':visible') ){
			$(this).parents('.new-block-holder').find('.profile-edit').slideUp(300,function(){
				$(this).parents('.new-block-holder').addClass('hidden');	
				$(this).removeClass('in').addClass('collapse');
			});
			return false;
		}
		$(this).parents('.section-content').removeClass('edit-mode');

		
	});

	$('.add-btn, .edit-resume').on( 'click', function(e){
		e.preventDefault();
		//close other edit-mode sectons if any
		$('.section-content:not(.new-block-holder) .profile-edit').removeClass('in').addClass('collapse');
		$('.section-content:not(.new-block-holder)').removeClass('edit-mode');

		var addBlockID = $(this).attr('href');
		if( !$(addBlockID).is(':visible') ){
			$(addBlockID).parent().removeClass('hidden');
			$(addBlockID)
				.removeAttr('style')
				.slideDown(300 , function(){
					$(this)
					.addClass('in')
					.removeAttr('style');
				})
				.parent().addClass('edit-mode');	
			
			//scroll new block to visible area of screen
			$('body,html').animate({
					scrollTop: $(addBlockID).height()>$(window).height()/1.5? $(addBlockID).offset().top : $(addBlockID).offset().top - 200
				},300);
				
		}else{
			return false;
		}
		
	});



	// Change the button text for profile image
	if($("#profilePic").length){
		var profile = $("#profilePic").attr("src");
		if(profile=="https://images.jxt.net.au/placeholder.png")
		{
			$(".fileupload-new").html("Update Image");    
		}  
	}
	
	/* disable end date with marked checkbox*/  
	$( ".date_wrap" ).each(function() {
		var ele = $(this);
		$(this).find(".current-date").change(function(){
			if($(this).is(":checked")){
				ele.find(".end-date-wrap select").prop('disabled', 'disabled');
			}
			else
			{
				ele.find(".end-date-wrap select").removeAttr("disabled");
			}
		});
	});



	/* upon request checkbox functionality */
	$(".uponrequest-btn").change(function(){
		$(".upon-request-submit-btn").css({"opacity":1,"width":'auto', "visibility":'visible'});
	});

	/* certificate validity date - checkbox action */
	$(".certificate_checkbox .btn-checkbox").change(function(){
		if($(this).is(":checked")){
				$(".certificate_validity_wrap select").prop('disabled', 'disabled');
			}
			else
			{
				$(".certificate_validity_wrap select").removeAttr("disabled");
			}
	});

	/* Upload Profile Image  - submit button */
	document.getElementById("fuProfile").onchange = function (event) {
		var _validFileExtensions = [".jpg", ".jpeg", ".bmp", ".gif", ".png"]; 
		var input_ele = document.getElementById("fuProfile");   
		var sFileName = input_ele.value;	
		if (sFileName.length > 0) {
            var blnValid = false;
            for (var j = 0; j < _validFileExtensions.length; j++) {
                var sCurExtension = _validFileExtensions[j];
                if (sFileName.substr(sFileName.length - sCurExtension.length, sCurExtension.length).toLowerCase() == sCurExtension.toLowerCase()) {
                    blnValid = true;
                    break;
                }
            }
            if (!blnValid) {
               var errmsg = "Sorry, " + sFileName + " is invalid, allowed extensions are: " + _validFileExtensions.join(", ");
               $("#upload-img-err").html(errmsg);
               input_ele.value = "";
               remove_btn()

            }
            else{
            	$("#upload-img-err").html("");
            	$(".profile-upload-btn").css({"opacity":1,"visibility":'visible'});

				var reader = new FileReader();
			    reader.onload = function(){
			    	var output = document.getElementById('profilePic');
			    	output.src = reader.result;
				};
			    reader.readAsDataURL(event.target.files[0]);
				var temp = $("#profilePic").attr("src");
			    $(".fileupload-new").html("Edit Image"); 
            }
        }
	};
	$(".remove-btn").on( 'click', function(e){
		e.preventDefault();
		remove_btn();
	});
	
	function remove_btn(){
		$("#profilePic").attr("src","https://images.jxt.net.au/COMMON/images/dummy_profile.jpg");
		 $(".fileupload-new").html("Upload Image");
		 $('.profile-upload-btn').css({"opacity":0,"visibility":'hidden'});
	}


	/* Quick links view more btn*/
	if($("#ctl00_ContentPlaceHolder1_upNavigation").length && $(".quick-links").length){
		var wrap_height = 1 * $(".quick-links").outerHeight() + 1 * $(".quick-links").css("marginBottom").replace('px', '');
		wrap_height+= 22;
		var autoHeight = $("#ctl00_ContentPlaceHolder1_upNavigation").css('height', 'auto').height(); //get auto height
        //only if no. is greater than 4, add height
		if( $(".quick-links").length > 4 ){
            $("#ctl00_ContentPlaceHolder1_upNavigation").css({"height":wrap_height,"opacity":1});
        }
		
		$(".viewmore_btn").on( 'click', function(){
			$(this).toggleClass("viewless");
			$("#ctl00_ContentPlaceHolder1_upNavigation").toggleClass("full").toggleClass("small");
			$(".full").css({ height: autoHeight });
			$(".small").css({ height: wrap_height });
			/*$(".full").stop().animate({ height: autoHeight });
			$(".small").stop().animate({ height: wrap_height });*/
		});
	}
    if( $(".quick-links").length < 5 ){
        $(".viewmore_btn").addClass('hidden');
    }
	
	/* profile pic - make height and width equal */
	if($(".profileImageHolder").length)
	{
		//profile_pic_sq();
	}
	
	$(window).on('resize', function(){
		//profile_pic_sq();
	});
	function profile_pic_sq()
	{
		var cw = $('.profileImageHolder').width();
		$('.profileImageHolder').css({'height':cw+'px'});
		$('.profileImageHolder').css({"opacity":1});

	}
	
	/* datepicker code */
	if( $( "#memberavailableDate" ).length ){
	 $( "#memberavailableDate" ).datepicker({ 
	 	minDate: new Date(1916, 1 - 1, 1),
	 	dateFormat: dateformat, 
	 });
	}

	/* Add button in upload resume/coverletter -----starts*/
	$( ".edit-list" ).each(function() {
		if(($(this).find("li").length)>=3)
		{

			$(this).parent().siblings().find(".add-btn").hide();
		}
		
	});
	/* Add button in upload resume/coverletter -----ends*/


   	/* Placement of the upload resume form -----starts*/
	var belowR = 0;

	function below_resume()
	{
		if(belowR==0)
		{
			$("#resume_container .form-all").append($("#resume_wrap"));
			$("#resume_container .form-all .full-width").removeClass("form-section");
			belowR=1;
		}
	}

	function below_coverletter()
	{
		if(belowR==1)
		{
			$("#attach_forms").append($("#resume_wrap"));
			belowR=0;
		}

	}
	
	if($(window).width()<992)
	{
		below_resume();
	}


	$(window).resize(function() {
		if($( window ).width()<992)
		{
			below_resume();
		}
		if($( window ).width()>991)
		{
			below_coverletter();
		}
	});
	/* Placement of the upload resume form -----starts*/


	// Profile status update 
	function update_status()
	{
		var pro_status = $.trim($('.status').html());
		var pro_wrap_height = $(".profile-status-wrap").height();
		//console.log(pro_wrap_height);
		var px_height = parseInt((pro_status / 100) * pro_wrap_height);
		$(".profile-status").stop().animate({ height: px_height }, 2000);
		$(".profile_status_info").stop().animate({ bottom: px_height - 1 }, 2000);
        if( px_height > pro_wrap_height - 15  ){
            $(".profile_status_info").addClass('info-btm');
        }
	}
	update_status();

	//animation trigger demo
	$(".profile_ani").on('click', function(){
		$('.status').html("80");
		update_status();
	});

	// if there is a hash, scroll down to it. Sticky header covers up top of content.
    $("#ctl00_ContentPlaceHolder1_upNavigation a").on('click', function(e){
    	var target_section = $(this).attr("href");
    	var target_form = $(this).attr("data-form");

        $("html, body").animate({
                scrollTop: $(target_section).offset().top - $(".navbar-wrapper").height() - 50
            }, 100);
        
        if($(this).is(".clicked"))
        {
        	//do nothing
        }
        else{
        	$(target_section).find(target_form).trigger( "click" );
        	 $("#ctl00_ContentPlaceHolder1_upNavigation a.clicked").removeClass("clicked");
        	$(this).addClass("clicked");

        }

	});

	//mailing address
	//set initial state of mailing address same as above.
    $('#ctl00_ContentPlaceHolder1_cbDetailsSameAsAbove').val($(this).is(':checked'));

	$('#ctl00_ContentPlaceHolder1_cbDetailsSameAsAbove').change(function() {
		if( $(this).is(':checked') ){
	        $('#ctl00_ContentPlaceHolder1_tbDetailsMailingAddress1').val($('#ctl00_ContentPlaceHolder1_tbDetailsAddress1').val());      
	        $('#ctl00_ContentPlaceHolder1_tbDetailsMailingAddress2').val($('#ctl00_ContentPlaceHolder1_tbDetailsAddress2').val());
	        $('#ctl00_ContentPlaceHolder1_tbDetailsMailingSuburb').val($('#ctl00_ContentPlaceHolder1_tbDetailsSuburb').val());      
	        $('#ctl00_ContentPlaceHolder1_tbDetailsMailingState').val($('#ctl00_ContentPlaceHolder1_tbDetailsState').val());      
	        $('#ctl00_ContentPlaceHolder1_tbDetailsMailingPostcode').val($('#ctl00_ContentPlaceHolder1_tbDetailsPostcode').val());      
	        $('#ctl00_ContentPlaceHolder1_ddlDetailsMailingCountry').val($('#ctl00_ContentPlaceHolder1_ddlDetailsCountry').val());      
    	}else{
    		$('#ctl00_ContentPlaceHolder1_tbDetailsMailingAddress1').val('');      
	        $('#ctl00_ContentPlaceHolder1_tbDetailsMailingAddress2').val('');      
	        $('#ctl00_ContentPlaceHolder1_tbDetailsMailingSuburb').val('');      
	        $('#ctl00_ContentPlaceHolder1_tbDetailsMailingState').val('');      
	        $('#ctl00_ContentPlaceHolder1_tbDetailsMailingPostcode').val('');
	        $('#ctl00_ContentPlaceHolder1_ddlDetailsMailingCountry').val('');
    	}
    });


	// [Custom Upload]
    $(".custom-fileUpload input:file").on("change", function () {
        $(this).parents('.custom-fileUpload').find('.filename-holder').text($(this).val().replace(/C:\\fakepath\\/i, ''));
    });
    
    //circular progress bar
    if($(".progress-bar").length ){
    	$(".progress-bar").loading();	
    }  

}); //end of document ready

// Equal Height	
$.fn.eqHeight = function(options) {

    var defaults = { child: false };
    var options = $.extend(defaults, options);
    var el = $(this);
    if (el.length > 0 && !el.data('eqHeight')) {
        $(window).bind('resize.eqHeight', function() {
            el.eqHeight();
        });
        el.data('eqHeight', true);
    }
    if (options.child && options.child.length > 0) {
        var elmtns = $(options.child, this);
    } else {
        var elmtns = $(this).children();
    }

    var prevTop = 0;
    var max_height = 0;
    var elements = [];
    elmtns.height('auto').each(function() {

        var thisTop = this.offsetTop;
        if (prevTop > 0 && prevTop != thisTop) {
            $(elements).height(max_height);
            max_height = $(this).height();
            elements = [];
        }
        max_height = Math.max(max_height, $(this).height());
        prevTop = this.offsetTop;
        elements.push(this);
    });

    $(elements).height(max_height);
};

// Equal Height - Usage
$(document).ready( function(){
	$(".equal-height-blocks .form-section").equalHeights();
});
        

function SalaryTypeChanged()
{
    var disabled = true;

    if ($('#ctl00_ContentPlaceHolder1_ddlRolePreferenceSalaryRequirements').val() == "")
    {
        $('#ctl00_ContentPlaceHolder1_tbRolePreferenceSalaryMin').val('');
        $('#ctl00_ContentPlaceHolder1_tbRolePreferenceSalaryMax').val('');
        $('#ctl00_ContentPlaceHolder1_tbRolePreferenceSalaryMin').attr('disabled','disabled');
        $('#ctl00_ContentPlaceHolder1_tbRolePreferenceSalaryMax').attr('disabled','disabled');
    }
    else
    {
      $('#ctl00_ContentPlaceHolder1_tbRolePreferenceSalaryMin').removeAttr('disabled');
      $('#ctl00_ContentPlaceHolder1_tbRolePreferenceSalaryMax').removeAttr('disabled');
    }

    
}

function ScrollToNextSection(callerID) {
    var callerSection = $(callerID).closest(".scroll-point");
    var listOfFormSections = $(".scroll-point");
    var actionOnNext = false;

    $.each(listOfFormSections, function () {

        if (actionOnNext) {
            $('html, body').animate({
                scrollTop: $(this).height() > $(window).height() / 1.5 ? $(this).offset().top : $(this).offset().top - 200
            }, 300);

            return false; //break
        }

        if (callerSection.is($(this))) {
            actionOnNext = true;
        }

    });

}