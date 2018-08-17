(function ($) {
    var activeLink = $('.left-sidebar').find('.dropdown-active');
    var dropdownMenu = $('ul.dropdown-menu');
    var dropdownSubMenu = $('.dropdown-submenu-level');
    if (activeLink.length) {
        activeLink.each(function (i, obj) {
            activeLink.addClass('open');
        });
    }
    if (dropdownMenu.length) {
        dropdownMenu.on('click', function (event) {
            event.stopPropagation();
        });
    }
    if (dropdownSubMenu.length) {
        $('.dropdown-toggle').click(function () {
            dropdownSubMenu.removeClass('open');
        })
        dropdownSubMenu.find('.submenu-toggle').each(function (i, obj) { 
            $(this).on('click', function () {
                $(this).parent().toggleClass('open');
                if ($(this).parent().find('ul').length) {
                    $(this).parent().find('.open').removeClass('open');
                }
            })
        });
    }
}(jQuery));