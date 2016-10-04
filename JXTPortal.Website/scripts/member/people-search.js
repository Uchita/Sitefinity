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

    $('#content').removeClass('col-sm-8 col-md-9');
        /* scroll bar on summary section*/
    //run jscrollpane only if there is summary class element
    if( $('.summary').length ){ 
        $('.summary').jScrollPane();
        $( window ).resize(function() {
            $('.summary').jScrollPane();
        });
    }

    $('.fa-edit').on('click', function(){
        $(this).parents('.section-content').addClass('edit-mode');
        var editBlockId = $(this).attr('href');
        //only for personal details section
        if( editBlockId == "#personalDetails-form" || editBlockId == "#edit-Role" || editBlockId == '#edit-supplementaryQuestions' ){
            // $('body,html').animate({
            //  scrollTop: $(this).offset().top + $(this).height()
            // },300);
        }else{
            //close other edit-mode sections if any
            $('.profile-edit').not($(this).parents('.section-content').find('.profile-edit')).removeClass('in').addClass('collapse');
            $('.fa-edit').not(this).parents('.section-content').removeClass('edit-mode');
            $('.new-block-holder').addClass('hidden').find('.profile-edit').removeClass('in').addClass('collapse');
        }


    });

  

// $('.jobs-list').each(function () {
//                         var $item = $(this),
//                             $content = $item.find('.content'),
//                             $toggle = $item.find('.btn-viewprofile .toggle');

//                         $toggle.on('click', function (event) {
//                             event.preventDefault();

//                             if ($item.hasClass('active')) {
//                                 $content.slideUp();
//                                 $item.removeClass('active');
//                                // $toggle.removeClass('fa-minus').addClass('fa-plus');
//                                 $('.jobs-list .btn-viewprofile').css('top', '15px');
//                             } else {
//                                 $content.slideDown();
//                                 $item.addClass('active');
//                                 //$toggle.removeClass('fa-plus').addClass('fa-minus');
//                                 $('.jobs-list .btn-viewprofile').css('top', '15px');
//                             }
//                         });

//                         $item.find('.read-more').on('click', function (event) {
//                             event.preventDefault();

//                             $content.slideDown();
//                             $item.addClass('active');
//                             //$toggle.removeClass('fa-plus').addClass('fa-minus');
//                         });
//                     });

//location search files 
$(document).ready(function(){
    $("#filter").keyup(function(){
 
        // Retrieve the input field text and reset the count to zero
        var filter = $(this).val(), count = 0;
 
        // Loop through the comment list
        $(".listStyleNone  .sub").each(function(){
 
            // If the list item does not contain the text phrase fade it out
            if ($(this).text().search(new RegExp(filter, "i")) < 0) {
                $(this).fadeOut();
 
            // Show the list item if the phrase matches and increase the count by 1
            } else {
                $(this).show();
                count++;
            }
        });
 
       // var numberItems = count;
       //  $(".location-label").text(count);
    
    });
});
 
$('.view').each(function () {
    var $item = $(this),
        $content = $item.find('.content'),
        $toggle = $item.find('.toggle');

    $toggle.on('click', function (event) {
        event.preventDefault();

        if ($item.hasClass('active')) {
            $content.slideUp();
            $item.removeClass('active');
            // $toggle.removeClass('fa-minus').addClass('fa-plus');
            $('.jobs-list .btn-viewprofile').css('top', '15px');
        } else {
            $content.slideDown();
            $item.addClass('active');
            //$toggle.removeClass('fa-plus').addClass('fa-minus');
            $('.jobs-list .btn-viewprofile').css('top', '15px');
        }
    });

    $item.find('.read-more').on('click', function (event) {
        event.preventDefault();

        $content.slideDown();
        $item.addClass('active');
        //$toggle.removeClass('fa-plus').addClass('fa-minus');
    });
}); 
 
//Booststrap pagenation limit
 
// $('.pagination-demo').twbsPagination({
//        totalPages: 3,
//		first : false,
//		last : false,
//		next: '»',
//		prev: '«',
//        visiblePages: 2,
//    });


// location menu list open on focus

$('.dropdown-menu a').on({
    "click":function(e){
      e.stopPropagation();
    }
});

// location search list open on focus
$('.dropdown-menu input').on({
    "click":function(e){
      e.stopPropagation();
    }
});


//range slider

if($('#hfAnnualRange').val() == '')
{
var slider = new Slider('#ex2', {});
}
if($('#hfHourlyRange').val() == '')
{
var slider = new Slider('#ex3', {});
}

// [Custom Upload]
    $(".custom-fileUpload input:file").on("change", function () {
        $(this).parents('.custom-fileUpload').find('.filename-holder').text($(this).val().replace(/C:\\fakepath\\/i, ''));
    });

    
    /* datepicker code */
    if( $( "#availableDate" ).length ){
     $( "#availableDate" ).datepicker({ 
        minDate: new Date(1916, 1 - 1, 1),
        dateFormat: dateformat, 
     });
    };

}); //end of document ready

// Select location on the basis of are

// $('.dropdown-menu a').on('click', function(){    
//     $('.dropdown-toggle').html($(this).html() + '<span class="caret"></span>');    
// });

 $(document).ready(function() {
                                                $('.selectpicker').multiselect({
                                                    enableClickableOptGroups: true,
                                                    enableCollapsibleOptGroups: true,
                                                    enableFiltering: true,
                                                    includeSelectAllOption: false
                                                });
                                            });


 $(document).ready(function() {
                                                $('.selectpicker-withoutsearch').multiselect({
                                                    enableClickableOptGroups: true,
                                                });
                                            });

 $(document).ready(function() {
                                              $('#divCountryCityRegion input').change(function() {
                                                  $('#hfCountryCityRegion').val($('#ddlCountryCityRegion').val());
                                              });
                                            });
 $(document).ready(function() {
                                              $('#divProfessionsRoles input').change(function() {
                                                  $('#hfProfessionsRoles').val($('#ddlProfessionsRoles').val());
                                              });
                                            });
 $(document).ready(function() {
                                              $('#divProfessionsRoles input').change(function() {
                                                  $('#hfProfessionsRoles').val($('#ddlProfessionsRoles').val());
                                              });
                                            });

$(function() {
        $('.customAutoOuter a').click( function(){
            
            var state;
            if( $(this).hasClass('active') ){
                $(this).removeClass('active');
                state = false;
            }else{
                $(this).addClass('active');
                state = true;
            }
            if( $(this).parent().hasClass('sub') || $(this).parent().hasClass('listingCountry') ){
                var child = $(this).parent().children();
                child.each( function(){
                    if ( state == true ){
                        $(this).find('a').addClass('active');
                    }else{
                        $(this).find('a').removeClass('active');
                    }
                })
                //$(this).parent('.sub').children().find('a').toggleClass('active');
            }
        })
    });

// On selection change salary range

 $(function() {
        $('#salaryRange').change(function(){
            $('.range').hide();
            $('#' + $(this).val()).show();
        });
    });


function PeopleSearchReset()
{
    $('#ctl00_ContentPlaceHolder1_tbKeywords').val('');
    
    $("#ddlCountryCityRegion option:selected").prop("selected", false);
    $("#ddlCountryCityRegion").multiselect('refresh');
    $("#hfCountryCityRegion").val('');


    $("#ddlProfessionsRoles option:selected").prop("selected", false);
    $("#ddlProfessionsRoles").multiselect('refresh');
    $("#hfProfessionsRoles").val('');

    $("#ddlWorkType option:selected").prop("selected", false);
    $("#ddlWorkType").multiselect('refresh');
    $("#hfWorkType").val('');
    
    $("#ddlEligibleToWorkIn option:selected").prop("selected", false);
    $("#ddlEligibleToWorkIn").multiselect('refresh');
    $("#hfEligibleToWorkIn").val('');
    
    $("#salaryRange").val('');
    $("#salaryRange").multiselect('refresh');
    $('.range').hide();

     $("#ctl00_ContentPlaceHolder1_ddlStatus option:selected").prop("selected", false);
    $("#ctl00_ContentPlaceHolder1_ddlStatus").multiselect('refresh');
     $('#availableDate').val('');

    return false;
}
