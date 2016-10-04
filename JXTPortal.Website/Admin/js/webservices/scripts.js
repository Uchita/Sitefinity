$(function () {

    // INSTANTIATE MIXITUP

    $('#all-postings').mixitup({
        targetDisplayList: 'table',
        layoutMode: 'list', // Start in list mode (display: block) by default
        listClass: 'list', // Container class for when in list mode
        sortOnLoad: ['data-posting', 'desc'], // Display list items in order of: Failed, Archived, Added, Updated
        effects: ['fade', 'blur'], // List of effects 
        // listEffects: ['fade','rotateX'], List of effects ONLY for list mode
        transitionSpeed: 10,
        easing: 'snap'
    });




    // Check if ERROR

    $('li.mix').each(function () {

        if (!$(this).find(".additional-info").is(':empty')) {

            if ($(this).hasClass('error')) {

                $(this).find('.posting').append('<i class="fa fa-exclamation-triangle"></i>');
                $(this).find('.details').append('<a href="#" class="detail-btn btn btn-success clickable"><i class="fa fa-th"></i> Details</a>');

            } else {

                $(this).find('.posting').append('<i class="fa fa-info-circle"></i>');
                $(this).find('.details').append('<a href="#" class="detail-btn btn btn-success clickable"><i class="fa fa-th"></i> Details</a>');

            }
        }
    });






    // Dropdown info

    $("#all-postings .clickable").click(function (e) {
        e.preventDefault();
        $(this).toggleClass("active");
        if ($(this).hasClass("active")) {
            $(this).parents().parents("li.mix").find(".additional-info").fadeIn("fast");
        }
        else {
            $(this).parents().parents("li.mix").find(".additional-info").fadeOut("fast");
        }
        return false;
    });


});